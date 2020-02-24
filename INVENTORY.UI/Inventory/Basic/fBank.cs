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
    public partial class fBank : Form
    {
        
        private Bank _Bank = null;
        public Action ItemChanged;
        bool _IsNew = false;
        bool _CheckBangla = false;
        public fBank()
        {
            InitializeComponent();
        }
        public void ShowDlg(Bank oBank,bool IsNew)
        {
            _IsNew = IsNew;
            _Bank = oBank;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {

            if (!_IsNew)
                numOpeningBalance.Enabled = false;
            else
                numOpeningBalance.Enabled = true;


            txtCode.Text = _Bank.Code;
            txtName.Text = _Bank.BankName;
            txtAccountNo.Text = _Bank.AccountNo;
            txtBranch.Text = _Bank.BranchName;
            numOpeningBalance.Value = _Bank.OpeningBalance;
            numTotalAmt.Value = _Bank.TotalAmount;
            txtAccName.Text = _Bank.AccountName;

        }

        private void RefreshObject()
        {
            _Bank.Code = txtCode.Text;
            _Bank.BankName = txtName.Text;
            _Bank.BranchName = txtBranch.Text;
            _Bank.AccountNo = txtAccountNo.Text;
            _Bank.OpeningBalance = numOpeningBalance.Value;
            _Bank.TotalAmount = numTotalAmt.Value;
            _Bank.AccountName = txtAccName.Text;
        }
        #region Events

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Bank Name.", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        //if (_Bank.BankID <= 0)
                        //{
                        //    if (txtName.Text.Length > 0)
                        //    {
                        //        Bank oBank = null;

                        //        oBank = (Bank)db.Banks.FirstOrDefault(o => o.BankName.Trim().ToUpper() == txtName.Text.Trim().ToUpper());
                        //        if (oBank != null)
                        //        {
                        //            MessageBox.Show("This Bank already Exists.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            txtName.Focus();
                        //            return;
                        //        }
                        //    }
                        //}
                        if (_Bank.BankID <= 0)
                        {
                            RefreshObject();
                            _Bank.BankID = db.Banks.Count() > 0 ? db.Banks.Max(obj => obj.BankID) + 1 : 1;
                            db.Banks.Add(_Bank);
                            IsNew = true;
                        }
                        else
                        {
                            _Bank = db.Banks.FirstOrDefault(obj => obj.BankID == _Bank.BankID);
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
                            _Bank = new Bank();
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
                if (db.Banks.ToList().Count > 0)
                {
                    maxValue = db.Banks.Max(x => x.BankID);
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

      

        private void numOpeningBalance_ValueChanged(object sender, EventArgs e)
        {
           if(_IsNew)
            numTotalAmt.Value = _Bank.TotalAmount + numOpeningBalance.Value;
        }

        private void fBank_Load(object sender, EventArgs e)
        {
            if (_IsNew)
                txtCode.Text = GenerateCategoryCode();
        }

    }
}
