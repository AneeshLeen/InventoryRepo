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
    public partial class fRole : Form
    {
        
        private Role _Role = null;
        public Action ItemChanged;
        bool _IsNew = false;
        public fRole()
        {
            InitializeComponent();
        }
        public void ShowDlg(Role oRole,bool IsNew)
        {
            _IsNew = IsNew;
            _Role = oRole;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {

            txtDescription.Text = _Role.Description;
            txtName.Text = _Role.RoleName;
        }

        private void RefreshObject()
        {
            _Role.Description = txtDescription.Text;
            _Role.RoleName = txtName.Text;
        }

        #region Events
        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Role Name.", "Role", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) return;
                bool IsNew = false;

                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    if (_Role.RoleID <= 0)
                    {
                        if (txtDescription.Text.Length > 0)
                        {
                            Role oRole = (Role)(db.Roles.FirstOrDefault(o => o.Description.Trim().ToUpper() == txtDescription.Text.Trim().ToUpper()));
                            if (oRole != null)
                            {
                                MessageBox.Show("This Role already Exists for this Company.", "Duplicate Role", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDescription.Focus();
                                return;
                            }
                        }

                        RefreshObject();
                        _Role.RoleID = db.Roles.Count() > 0 ? db.Roles.Max(obj => obj.RoleID) + 1 : 1;
                        db.Roles.Add(_Role);

                        IsNew = true;
                    }
                    else
                    {
                        _Role = db.Roles.FirstOrDefault(obj => obj.RoleID == _Role.RoleID);
                        RefreshObject();
                    }

                    db.SaveChanges();

                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!IsNew)
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
                        _Role = new Role();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
        private void fRole_Load(object sender, EventArgs e)
        {
            //if (_IsNew)
            //    txtName.Text = GenerateRoleCode();
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
