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
using System.IO;

namespace INVENTORY.UI
{
    public partial class fBranch : Form
    {

        private Branch _Branch = null;
        public Action ItemChanged;
        private INVENTORY.DA.SystemInformation _SystemInformation = null;
        bool _IsNew = false;
        Category _oCategory = null;

        public fBranch()
        {
            InitializeComponent();
        }
        public void ShowDlg(Branch oBranch,bool IsNew)
        {
            _IsNew = IsNew;
            _Branch = oBranch;
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var _SysInfos = db.SystemInformations;

                _SystemInformation = (from c in db.SystemInformations
                                      where c.SystemInfoID == 1
                                      select c).FirstOrDefault();
                                      
            }
            //PopulateCategoryCbo();
            RefreshValue();
            this.ShowDialog();
        }
        private void PopulateCategoryCbo()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                //cboCategory.DisplayMember = "Description";
                //cboCategory.ValueMember = "CategoryID";
                //cboCategory.DataSource = db.Categorys.OrderBy(x => x.Description).ToList();

            }
        }        
        private void RefreshValue()
        {
            txtCode.Text = _Branch.Code;
            txtName.Text = _Branch.BranchName;
            ctlBank.SelectedID = _Branch.BankID;
            txtAccountNo.Text=_Branch.AccountNo;
            txtAddress.Text = _Branch.Address != null ? _Branch.Address : "";
            numOpeningBalance.Value=_Branch.OpeningBalance;
            numTotalAmt.Value = _Branch.TotalAmount;
           // cboCategory.SelectedValue = _Product.CategoryID != null ? _Product.CategoryID : 1;
            //numSalesRate.Value = _Product.SalesRate!=null?(decimal)_Product.SalesRate:0;
            //numPurchaseRate.Value = _Product.PurchaseRate!=null?(decimal)_Product.PurchaseRate:0;
        }

        private void RefreshObject()
        {

            _Branch.Code = txtCode.Text;
            _Branch.BranchName = txtName.Text;
            _Branch.Address = txtAddress.Text;
            _Branch.AccountNo = txtAccountNo.Text;
            _Branch.OpeningBalance = numOpeningBalance.Value;
            _Branch.TotalAmount = numTotalAmt.Value;
            _Branch.BankID = ctlBank.SelectedID;
         
         
        }

        #region Events
        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Product Name.", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            if (_oCategory == null)
            {
                MessageBox.Show("Please Enter Category", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlBank.Focus();
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
                    
                      
                        //if (_Branch.BranchID <= 0)
                        //{
                        //    if (txtName.Text.Length > 0)
                        //    {
                        //       Branch oBranch = null;

                        //        oBranch = (Branch)db.Branches.FirstOrDefault(o => o.BranchName.Trim().ToUpper() == txtName.Text.Trim().ToUpper());
                        //        if (oBranch != null)
                        //        {
                        //            MessageBox.Show("This Barnch already Exists.", "Duplicate Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            txtName.Focus();
                        //            return;
                        //        }
                        //    }
                        //}

                        if (_Branch.BranchID<= 0)
                        {
                            RefreshObject();
                            _Branch.BranchID = db.Branches.Count() > 0 ? db.Branches.Max(obj => obj.BranchID) + 1 : 1;
                            db.Branches.Add(_Branch);
                            IsNew = true;
                        }
                        else
                        {
                            _Branch = db.Branches.FirstOrDefault(obj => obj.BranchID == _Branch.BranchID);
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
                            _Branch = new Branch();
                            RefreshValue();
                            txtCode.Text = GenerateProductCode();

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

        private string GenerateProductCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Branches.ToList().Count > 0)
                {
                    maxValue = db.Branches.Max(x => x.BranchID);
                    if (maxValue != null)
                        i = (int)maxValue;
                }
                else
                {
                    i = 0;
                }

                if (i >= 0)
                {
                    if (i.ToString().Length == 1)
                    {
                        sCode = "00000" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 2)
                    {
                        sCode = "0000" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 3)
                    {
                        sCode = "000" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 4)
                    {
                        sCode = "00" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 5)
                    {
                        sCode = "0" + Convert.ToString(i + 1);
                    }
                    else
                    {
                        sCode = "0" + Convert.ToString(i + 1);
                    }
                }
            }
            return sCode;
        }
        private void fProduct_Load(object sender, EventArgs e)
        {

            if (!_IsNew)
                numOpeningBalance.Enabled = false;

            if(_IsNew)
                txtCode.Text = GenerateProductCode();
        }

        private void btnItemShow_Click(object sender, EventArgs e)
        {
            fBanks oB = new fBanks();
            oB.ShowDialog();
        }
        private void btnNewItem_Click(object sender, EventArgs e)
        {
            fBank oF = new fBank();
            oF.ShowDlg(new Bank(), true);
           // PopulateCategoryCbo();
        }

        private void ctlCategory_SelectedItemChanged(object sender, EventArgs e)
        { 
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                _oCategory = (Category)(db.Categorys.FirstOrDefault(o => o.CategoryID == ctlBank.SelectedID));

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void numOpeningBalance_ValueChanged(object sender, EventArgs e)
        {
            if(_IsNew)
            numTotalAmt.Value = numOpeningBalance.Value;
        }
    }
}
