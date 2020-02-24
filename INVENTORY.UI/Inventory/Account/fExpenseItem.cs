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
    public partial class fExpenseItem : Form
    {
        private ExpenseItem _ExpenseItem = null;
        public Action ItemChanged;
        bool _IsNew = false;

        public fExpenseItem()
        {
            InitializeComponent();
        }

        public void ShowDlg(ExpenseItem oExpenseItem,bool IsNew)
        {
            _IsNew = IsNew;
            _ExpenseItem = oExpenseItem;
            PopulateInvTypeCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void PopulateInvTypeCbo()
        {
            cboExpenseType.DisplayMember = "Name";
            cboExpenseType.ValueMember = "ID";
            cboExpenseType.DataSource = Enum.GetValues(typeof(EnumExpenseType)).Cast<EnumExpenseType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        }

        private void RefreshValue()
        {
            txtCode.Text = _ExpenseItem.Code;
            txtName.Text = _ExpenseItem.Description;
            cboExpenseType.SelectedValue = _ExpenseItem.Status;

        }


        private void RefreshObject()
        {
            _ExpenseItem.Code = txtCode.Text;
            _ExpenseItem.Description = txtName.Text;
            _ExpenseItem.Status = (int)cboExpenseType.SelectedValue;

        }

        private string GenerateExoenseCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;

                if (db.ExpenseItems.ToList().Count > 0)
                {
                    maxValue = db.ExpenseItems.Max(x => x.ExpenseItemID);
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
        private void ExpenseItem_Load(object sender, EventArgs e)
        {
            if(_IsNew)
                txtCode.Text = GenerateExoenseCode();
        }

        private bool IsValid()
        {

            if(cboExpenseType.SelectedItem==null)
            {
                MessageBox.Show("Please select Expense/Income Head.", "Expense and Income", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboExpenseType.Focus();
                return false;
            }

            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Expense/Income Item.", "Expense and Income", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
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
                    if (_ExpenseItem.ExpenseItemID <= 0)
                    {
                        #region Validation Check
                        if (txtName.Text.Length > 0)
                        {
                            ExpenseItem oExpenseItem = (ExpenseItem)(db.ExpenseItems.FirstOrDefault(o => o.Description.Trim().ToUpper() == txtName.Text.Trim().ToUpper()));
                            if (oExpenseItem != null)
                            {
                                MessageBox.Show("Expense name already Exists.", "Duplicate Expense Item.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtName.Focus();
                                return;
                            }
                        }

                        #endregion

                        RefreshObject();
                        _ExpenseItem.ExpenseItemID = db.ExpenseItems.Count() > 0 ? db.ExpenseItems.Max(obj => obj.ExpenseItemID) + 1 : 1;
                        db.ExpenseItems.Add(_ExpenseItem);
                        isNew = true;
                    }
                    else
                    {
                        _ExpenseItem = db.ExpenseItems.FirstOrDefault(obj => obj.ExpenseItemID == _ExpenseItem.ExpenseItemID);
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
                        _ExpenseItem = new ExpenseItem();
                        RefreshValue();
                        txtCode.Text = GenerateExoenseCode();
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
    }
}
