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
    public partial class fDesignation : Form
    {
        private Designation _Designation = null;
        public Action ItemChanged;
        bool _IsNew = false;
        public fDesignation()
        {
            InitializeComponent();
        }

        public void ShowDlg(Designation oDesignation,bool IsNew)
        {
            _IsNew = IsNew;
            _Designation = oDesignation;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtCode.Text = _Designation.Code;
            txtName.Text = _Designation.Description;
        }

        private string GenerateDegCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                i = db.Designations.Count();

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(db.Designations.Count() + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(db.Designations.Count() + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(db.Designations.Count() + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(db.Designations.Count() + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(db.Designations.Count() + 1);
                }
            }
            return sCode;
        }

        private void fDesignation_Load(object sender, EventArgs e)
        {

            if(_IsNew)
             txtCode.Text = GenerateDegCode();
        }

        private void RefreshObject()
        {
            _Designation.Code = txtCode.Text;
            _Designation.Description = txtName.Text;
        }

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Designation Name.", "Designation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (_Designation.DesignationID <= 0)
                        {
                            RefreshObject();
                            _Designation.DesignationID = db.Designations.Count() > 0 ? db.Designations.Max(obj => obj.DesignationID) + 1 : 1;
                            db.Designations.Add(_Designation);
                        }
                        else
                        {
                            _Designation = db.Designations.FirstOrDefault(obj => obj.DesignationID == _Designation.DesignationID);
                            RefreshObject();
                        }

                        db.SaveChanges();
                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Do you want to create another Designation?", "Create Designation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                            _Designation = new Designation();
                            RefreshValue();
                            txtCode.Text = GenerateDegCode();
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

    }
}
