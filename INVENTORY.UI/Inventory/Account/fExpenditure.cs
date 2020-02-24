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
    public partial class fExpenditure : Form
    {
        bool ForExpense = false;
        private Expenditure _Expenditure = null;
        public Action ItemChanged;
        private ExpenseItem _ExpenseItem = null;
        DEWSRMEntities db = null;
        public fExpenditure()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }
        public void ShowDlg(Expenditure oExpenditure)
        {
            _Expenditure = oExpenditure;

            if (_Expenditure.ExpenditureID == 0)
            {
                _Expenditure = new Expenditure();
                _Expenditure.CreatedBy = Global.CurrentUser.UserID;
                _Expenditure.CreateDate = DateTime.Now;
            }
            else
            {
                _Expenditure.ModifiedDate = (DateTime)DateTime.Today;
                _Expenditure.ModifiedBy= (int)Global.CurrentUser.UserID;
            }

            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtDescription.Text = _Expenditure.Purpose;
            dtpExpenseDate.Value = _Expenditure.EntryDate != DateTime.MinValue ?(DateTime)_Expenditure.EntryDate : DateTime.Now;
            numAmount.Value = _Expenditure.Amount != null ? (decimal)_Expenditure.Amount : 0; 

            if (_Expenditure != null)
                ctlExpense.SelectedID = _Expenditure.ExpenseItemID;

            txtVoucherNo.Text = _Expenditure.VoucherName;

        }

        private void RefreshObject()
        {

            if (_Expenditure.ExpenditureID == 0)
            {
                _Expenditure = new Expenditure();
                _Expenditure.CreatedBy = Global.CurrentUser.UserID;
                _Expenditure.CreateDate = DateTime.Now;
            }
            else
            {
                _Expenditure.ModifiedDate = (DateTime)DateTime.Today;
                _Expenditure.ModifiedBy = (int)Global.CurrentUser.UserID;
            }

            _Expenditure.EntryDate = dtpExpenseDate.Value;
            _Expenditure.ExpenseItemID = _ExpenseItem.ExpenseItemID;
            _Expenditure.Status = _ExpenseItem.Status;
            _Expenditure.Purpose = txtDescription.Text;
            _Expenditure.Amount = numAmount.Value;
            _Expenditure.VoucherName = txtVoucherNo.Text;
        }

        #region Events
        private bool IsValid()
        {
            if (txtDescription.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Expense Purpose.", "Expense and Income", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return false;
            }
         
            
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNew = false;
                if (!IsValid()) return;
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    if (_Expenditure.ExpenditureID <= 0)
                    {
                        RefreshObject();
                        _Expenditure.ExpenditureID = db.Expenditures.Count()>0? db.Expenditures.Max(obj => obj.ExpenditureID) + 1:1;
                        db.Expenditures.Add(_Expenditure);
                        isNew = true;
                    }
                    else
                    {
                        _Expenditure = db.Expenditures.FirstOrDefault(obj => obj.ExpenditureID == _Expenditure.ExpenditureID);
                        RefreshObject();
                    }

                    db.SaveChanges();

                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!isNew)
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
                        _Expenditure = new Expenditure();
                        RefreshValue();
                        txtVoucherNo.Text = GenerateVoucher();

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

        private string GenerateVoucher()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Expenditures.ToList().Count > 0)
                {
                    maxValue = db.Expenditures.Max(x => x.ExpenditureID);
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

        private void fExpenditure_Load(object sender, EventArgs e)
        {
            if (_Expenditure.ExpenditureID<=0)
            txtVoucherNo.Text= GenerateVoucher();
        }

        private void numAmount_Enter(object sender, EventArgs e)
        {
            numAmount.Select(0, numAmount.Text.Length);
        }
        private void ctlExpense_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                _ExpenseItem = db.ExpenseItems.FirstOrDefault(ex => ex.ExpenseItemID == ctlExpense.SelectedID);
               
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewCompany_Click(object sender, EventArgs e)
        {
            try
            {
                ForExpense = true;
                fExpenseItem frm = new fExpenseItem();
                frm.ShowDlg(new ExpenseItem(), true);

                if (ForExpense)
                {
                    db = new DEWSRMEntities();
                    List<ExpenseItem> oExpenseList = db.ExpenseItems.ToList();
                    ctlExpense.SelectedID = oExpenseList[oExpenseList.Count - 1].ExpenseItemID;
                    ForExpense = false;
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
