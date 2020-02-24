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
using DevExpress.XtraGrid.Views.Grid;

namespace INVENTORY.UI
{
    public partial class fExpenditureAndIncomes : Form
    {
        DEWSRMEntities db = null;
         public fExpenditureAndIncomes()
        {
            InitializeComponent();
        }
        private void fExpenditures_Load(object sender, EventArgs e)
        {
            db = new DEWSRMEntities();
            RefreshList();
            ControlPermission();
        }

        public void ControlPermission()
        {
            User oUser = Global.CurrentUser;
            if (oUser != null && oUser.UserType == 2)
            {
                btnEdit.Enabled = false;
            }
        }

        private void RefreshList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("ID");
            dt.Columns.Add("ExpenseDate");
            dt.Columns.Add("Expense");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount");
            dt.Columns.Add("VoucherName");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Expenditures = db.Expenditures.OrderByDescending(ex => ex.EntryDate);


                    if (_Expenditures != null)
                    {

                        foreach (Expenditure grd in _Expenditures)
                        { 
                            if(grd.ExpenseItem.Status==2)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.ExpenditureID;
                                dr["ExpenseDate"] = Convert.ToDateTime(grd.EntryDate).ToString("dd MMM yyyy");
                                dr["Expense"] = grd.ExpenseItem.Description;
                                dr["Description"] = grd.Purpose;
                                dr["Amount"] = grd.Amount.ToString();
                                dr["VoucherName"] = grd.VoucherName != null ? grd.VoucherName : "";
                                dt.Rows.Add(dr);
                            }
                            

                        }
                    }
                    grdExpenditures.DataSource = dt;
                    lblTotal.Text = "Total :" + _Expenditures.Where(o => o.Status == 2).Count().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            fExpenditureAndIncome frm = new fExpenditureAndIncome();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Expenditure());

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                int[] selRows = ((GridView)grdExpenditures.MainView).GetSelectedRows();
                DataRowView oExpenditureID = (DataRowView)(((GridView)grdExpenditures.MainView).GetRow(selRows[0]));
                DataRowView oExpenseDate = (DataRowView)(((GridView)grdExpenditures.MainView).GetRow(selRows[0]));


                int nExpenditureID = Convert.ToInt32(oExpenditureID["ID"]);
                DateTime ExpenseDate = Convert.ToDateTime(oExpenseDate["ExpenseDate"]);

                Expenditure oExpenditure = db.Expenditures.FirstOrDefault(p => p.ExpenditureID == nExpenditureID);

                if (oExpenditure == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Global.CurrentUser.ISEditable == 1)
                {
                    if (ExpenseDate < DateTime.Today)
                    {
                        MessageBox.Show("This Item can't be editable, Please contact BD Team.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                fExpenditureAndIncome frm = new fExpenditureAndIncome();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oExpenditure);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int[] selRows = ((GridView)grdExpenditures.MainView).GetSelectedRows();
                DataRowView oExpenditureID = (DataRowView)(((GridView)grdExpenditures.MainView).GetRow(selRows[0]));

                int nExpenditureID = Convert.ToInt32(oExpenditureID["ExpenditureID"]);
                Expenditure oExpenditure = db.Expenditures.FirstOrDefault(p => p.ExpenditureID == nExpenditureID);

                if (oExpenditure == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Expenditures.Attach(oExpenditure);
                    db.Expenditures.Remove(oExpenditure);
                    db.SaveChanges();
                    MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshList();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvExpenditure_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void grdExpenditures_Click(object sender, EventArgs e)
        {

        }
    }
}
