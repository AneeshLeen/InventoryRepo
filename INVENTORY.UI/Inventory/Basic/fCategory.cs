using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVENTORY.DA;

namespace INVENTORY.UI
{
    public partial class fCategory : Form
    {
        private DataTable AgeList = null;
        private Category _Category = null;
        public Action ItemChanged;
        bool _IsNew = false;
        public fCategory()
        {
            InitializeComponent();
        }
        public void ShowDlg(Category oCategory,bool IsNew)
        {
            _IsNew = IsNew;
            _Category = oCategory;
            PopulateTaxCbo();
            PopulateAgeCbo();
            PopulateColorCbo();
            SetDefaultValues();
            RefreshValue();
            this.ShowDialog();
        }

        private void SetDefaultValues()
        {
            cmbAge.SelectedIndex = 0;
            cmbVat.SelectedIndex = 0;
            cmbVat.Enabled = false;
        }

        private void PopulateTaxCbo()
        {
            cmbVat.DisplayMember = "Name";
            cmbVat.ValueMember = "ID";
            cmbVat.DataSource = Enum.GetValues(typeof(EnumTax)).Cast<EnumTax>().Select(x => new { ID = (int)x, Name = Convert.ToInt32(x).ToString() }).ToList();
        }
        private void PopulateAgeCbo()
        {
            AgeList = new DataTable();
            AgeList.Columns.Add("Age");
            AgeList.Rows.Add("N/A");
            AgeList.Rows.Add("16");
            AgeList.Rows.Add("18");
            AgeList.Rows.Add("21");
            cmbAge.DisplayMember = "Age";
            cmbAge.ValueMember = "Age";
            cmbAge.DataSource = AgeList;
        }
        private void PopulateColorCbo()
        {
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.cmbbackcolor.Items.Add(c.Name);
                this.cmbforecolor.Items.Add(c.Name);
            }
        }
        private void RefreshValue()
        {
            txtCode.Text = _Category.Code;
            txtName.Text = _Category.Description;

            cmbAge.SelectedValue = _Category.Age != null ? _Category.Age : cmbAge.SelectedValue;

            cmbbackcolor.SelectedItem = _Category.BackColor != null ? _Category.BackColor : null;
            cmbforecolor.SelectedItem = _Category.ForeColor != null ? _Category.ForeColor : null;
            chkInactive.Checked = _Category.Inactive;
            chkIsVat.Checked = _Category.IsVat;

            EnumTax enuumTax = (EnumTax)Convert.ToInt32(_Category.VAT);
            cmbVat.SelectedValue = (int)enuumTax;

            chkPayout.Checked = _Category.IsPayOut;
            chkSeperateSale.Checked = _Category.IsSeperateSale;
        }

        private void RefreshObject()
        {
            _Category.Code = txtCode.Text;
            _Category.Description = txtName.Text;

            _Category.Age = cmbAge.SelectedValue.ToString();
            _Category.BackColor = cmbbackcolor.SelectedItem != null ? cmbbackcolor.SelectedItem.ToString() : null;
            _Category.ForeColor = cmbforecolor.SelectedItem != null ? cmbforecolor.SelectedItem.ToString() : null;
            _Category.Inactive = chkInactive.Checked;
            _Category.IsVat = chkIsVat.Checked;
            _Category.VAT = Convert.ToDecimal(cmbVat.SelectedValue);
            _Category.IsPayOut = chkPayout.Checked;
            _Category.IsSeperateSale = chkSeperateSale.Checked;
        }

        #region Events

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Category Name.", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    bool IsNew = false;

                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_Category.CategoryID <= 0)
                        {
                            if (txtName.Text.Length > 0)
                            {
                                INVENTORY.DA.Category oCategory = null;
                                oCategory = (INVENTORY.DA.Category)db.Categorys.FirstOrDefault(o => o.Description.Trim().ToUpper() == txtName.Text.Trim().ToUpper());

                                if (oCategory != null)
                                {
                                    MessageBox.Show("This Category already Exists.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtName.Focus();
                                    return;
                                }
                            }

                            RefreshObject();
                            _Category.CategoryID = db.Categorys.Count() > 0 ? db.Categorys.Max(obj => obj.CategoryID) + 1 : 1;
                            db.Categorys.Add(_Category);
                            IsNew = true;
                        }
                        else
                        {
                            _Category = db.Categorys.FirstOrDefault(obj => obj.CategoryID == _Category.CategoryID);
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
                            _Category = new Category();
                            RefreshValue();
                            txtCode.Text = GenerateCategoryCode();
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
        #endregion

        private string GenerateCategoryCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Categorys.ToList().Count > 0)
                {
                    maxValue = db.Categorys.Max(x => x.CategoryID);
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

        private void fCategory_Load(object sender, EventArgs e)
        {
            if (_IsNew)
                txtCode.Text = GenerateCategoryCode();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btncolorprev.Text = txtName.Text;

        }

        private void cmbbackcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btncolorprev.BackColor = System.Drawing.Color.FromName(cmbbackcolor.Text);
        }

        private void cmbforecolor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            btncolorprev.ForeColor = System.Drawing.Color.FromName(cmbforecolor.Text);
        }

        private void chkIsVat_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIsVat.Checked==false)
            {
                cmbVat.SelectedIndex = 0;
                cmbVat.Enabled = false;
            }
            else
            {
                cmbVat.Enabled = true;
            }
        }
    }
}
