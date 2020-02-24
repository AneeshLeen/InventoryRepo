using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVENTORY.DA;

namespace INVENTORY.UI
{
    public partial class fUser : Form
    {
        private User _User = null;
        public Action ItemChanged;

        public fUser()
        {
            InitializeComponent();
        }

        public void ShowDlg(User oUser)
        {
            _User = oUser;
            PopulatUserTypeCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtUserName.Text = _User.UserName;
            txtUserPassword.Text = _User.UserPassword;
            txtEmailID.Text = _User.EmailAddress;
            txtContact.Text = _User.ContactNo;
            cboUserType.SelectedValue = _User.UserType;
        }

        private void PopulatUserTypeCbo()
        {
            cboUserType.DisplayMember = "Name";
            cboUserType.ValueMember = "ID";
            cboUserType.DataSource = Enum.GetValues(typeof(EnumUserType)).Cast<EnumUserType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        }

        private void RefreshObject()
        {
            _User.UserName = txtUserName.Text;
            _User.UserPassword = txtUserPassword.Text;
            _User.ContactNo = txtContact.Text;
            _User.EmailAddress = txtEmailID.Text;
            _User.UserType = 2;//(int)cboUserType.SelectedValue;
            _User.CreateDate = DateTime.Now;
            _User.CreatedBy = 1;
            _User.Status = (int)EnumUserStatus.Active;
        }

        private bool IsValid()
        {
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter User Name.", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }

            if (txtUserPassword.Text.Length == 0)
            {
                MessageBox.Show("Please Enter User Password.", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (!IsValid()) return;

                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_User.UserID <= 0)
                        {
                            if (txtUserName.Text.Length > 0)
                            {
                                User oUser = (User)(db.Users.FirstOrDefault(o => o.UserName.Trim().ToUpper() == txtUserName.Text.Trim().ToUpper()));

                                if (oUser != null)
                                {
                                    MessageBox.Show("This User already exists.", "Duplicate User.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtUserName.Focus();
                                    return;
                                }
                            }

                            RefreshObject();
                            _User.UserID = db.Users.Count() > 0 ? db.Users.Max(obj => obj.UserID) + 1 : 1;
                            db.Users.Add(_User);
                        }
                        else
                        {
                            _User = db.Users.FirstOrDefault(obj => obj.UserID == _User.UserID);
                            RefreshObject();
                        }

                        db.SaveChanges();

                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Do you want to create another User?", "Create User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            if (ItemChanged != null)
                            {
                                ItemChanged();
                            }
                            this.Close();
                        }
                        else
                        {
                            if (ItemChanged != null)
                            {
                                ItemChanged();
                            }
                            _User = new User();
                            RefreshValue();
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException == null)
                        MessageBox.Show(ex.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.InnerException.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fUser_Load(object sender, EventArgs e)
        {

        }
    }
}
