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
    public partial class fSMSFormate : Form
    {

        private SMSFormate _SMSFormate = null;
        public Action ItemChanged;
        bool _IsNew = false;
        public fSMSFormate()
        {
            InitializeComponent();
        }
        public void ShowDlg(SMSFormate oSMSFormate, bool IsNew)
        {
            _IsNew = IsNew;
            _SMSFormate = oSMSFormate;
            PopulatSMSTypeCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void PopulatSMSTypeCbo()
        {
            cboSMSType.DisplayMember = "Name";
            cboSMSType.ValueMember = "ID";
            cboSMSType.DataSource = Enum.GetValues(typeof(EnumSMSType)).Cast<EnumSMSType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        }

        private void RefreshValue()
        {
            txtCode.Text = _SMSFormate.Code;
            txtName.Text = _SMSFormate.SMSDescription;
            cboSMSType.SelectedValue = _SMSFormate.SMSType;

        }

        private void RefreshObject()
        {
            _SMSFormate.Code = txtCode.Text;
            _SMSFormate.SMSDescription = txtName.Text;
            _SMSFormate.SMSType = (int)cboSMSType.SelectedValue;
        }
        #region Events

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter SMS.", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (!IsValid()) return;
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_SMSFormate.SMSFormateID <= 0)
                        {
                            RefreshObject();
                            _SMSFormate.SMSFormateID = db.SMSFormates.Count() > 0 ? db.SMSFormates.Max(obj => obj.SMSFormateID) + 1 : 1;
                            db.SMSFormates.Add(_SMSFormate);
                        }
                        else
                        {
                            _SMSFormate = db.SMSFormates.FirstOrDefault(obj => obj.SMSFormateID == _SMSFormate.SMSFormateID);
                            RefreshObject();
                        }

                        db.SaveChanges();
                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (MessageBox.Show("Do you want to create another Brand?", "Create Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        //{
                        //    if (ItemChanged != null)
                        //    {
                        //        ItemChanged();
                        //    }
                        //    this.Close();
                        //}
                        //else
                        //{
                            if (ItemChanged != null)
                            {
                                ItemChanged();
                            }
                            _SMSFormate = new SMSFormate();
                            RefreshValue();
                            txtCode.Text = GenerateSMSCode();
                        //}
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
        #endregion

        private string GenerateSMSCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                i = db.SMSFormates.Count();

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(db.SMSFormates.Count() + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(db.SMSFormates.Count() + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(db.SMSFormates.Count() + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(db.SMSFormates.Count() + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(db.SMSFormates.Count() + 1);
                }
            }
            return sCode;
        }

        private void fSMSFormate_Load(object sender, EventArgs e)
        {
            if (_IsNew)
                txtCode.Text = GenerateSMSCode();
        }

    }
}
