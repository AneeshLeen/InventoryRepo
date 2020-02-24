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
    public partial class fCompany : Form
    {
        private Company _Company = null;
        public Action ItemChanged;
        bool _IsNew = false;

        public fCompany()
        {
            InitializeComponent();
        }

        public void ShowDlg(Company oCompany, bool IsNew)
        {
            _IsNew = IsNew;
            _Company = oCompany;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtCode.Text = _Company.Code;
            txtName.Text = _Company.Description;
        }

        private void RefreshObject()
        {
            _Company.Code = txtCode.Text;
            _Company.Description = txtName.Text;
        }

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Company Name.", "Company", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
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
                    if (_Company.CompanyID <= 0)
                    {

                        if (txtName.Text.Length > 0)
                        {
                            Company oCompany = (Company)(db.Companies.FirstOrDefault(o => o.Description.Trim().ToUpper() == txtName.Text.Trim().ToUpper()));

                            if (oCompany != null)
                            {
                                MessageBox.Show("This Company already exists.", "Duplicate Company.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtName.Focus();
                                return;
                            }
                        }
                        RefreshObject();
                        _Company.CompanyID = db.Companies.Count() > 0 ? db.Companies.Max(obj => obj.CompanyID) + 1 : 1;
                        db.Companies.Add(_Company);
                        IsNew = true;
                    }
                    else
                    {
                        _Company = db.Companies.FirstOrDefault(obj => obj.CompanyID == _Company.CompanyID);
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
                        _Company = new Company();
                        RefreshValue();
                        txtCode.Text = GenerateCode();
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

        private string GenerateCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Companies.ToList().Count > 0)
                {
                    maxValue = db.Companies.Max(x => x.CompanyID);
                    if (maxValue != null)
                        i = (int)maxValue;
                }
                else
                {
                    i = 0;
                }

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(i + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(i + 1);
                }
            }
            return sCode;
        }
        private void fCompany_Load(object sender, EventArgs e)
        {
            if (_IsNew)
            {
                txtCode.Text = GenerateCode();
                FillHoBranchList();
            }
               

        }

        private void FillHoBranchList()
        {
           
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
              var  Companylist =db.Companies.ToList();
                cmbHoBranchList.DataSource = Companylist;
                cmbHoBranchList.ValueMember = "CompanyID";
                cmbHoBranchList.DisplayMember = "Code";
            }
        }
    }
}
