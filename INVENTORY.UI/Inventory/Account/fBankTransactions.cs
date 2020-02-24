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
    public partial class fBankTransactions : Form
    {

        DEWSRMEntities db = null;

        double TotalRec = 0;
        double TotalPay = 0;
        public fBankTransactions()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void fCashTransactions_Load(object sender, EventArgs e)
        {
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
            dt.Columns.Add("TranDate");
            dt.Columns.Add("BankName");
            dt.Columns.Add("BranchName");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _BankTrans = db.BankTransactions.OrderByDescending(ex => ex.TranDate);


                    if (_BankTrans != null)
                    {

                        foreach (BankTransaction grd in _BankTrans)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.BankTranID;
                            dr["TranDate"] = Convert.ToDateTime(grd.TranDate).ToString("dd MMM yyyy");
                           // Branch br=db.Branches.FirstOrDefault(b=>b.BranchID==grd.BranchID);
                            dr["BankName"] = grd.Bank.BankName;
                            dr["BranchName"] = grd.Bank.BranchName;
                            dr["Amount"] = grd.Amount.ToString();
                            if (grd.TransactionType == 1)
                                dr["Status"] = "Deposit";
                            else if (grd.TransactionType == 2)
                                dr["Status"] = "Widthdrwal";
                            else if (grd.TransactionType == 3)
                                dr["Status"] = "Cash Collection";
                            else if (grd.TransactionType == 4)
                                dr["Status"] = "Cash Delivery";
                            else if (grd.TransactionType == 5)
                                dr["Status"] = "Fund Transfer";
                            dt.Rows.Add(dr);

                        }
                    }
                    grdExpenditures.DataSource = dt;
                    lblTotal.Text = "Total :" + _BankTrans.Count().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                
                fBankTransaction frm = new fBankTransaction();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new BankTransaction(),false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdExpenditures.MainView).GetSelectedRows();
                DataRowView oBankTransID = (DataRowView)(((GridView)grdExpenditures.MainView).GetRow(selRows[0]));
                DataRowView TranDate = (DataRowView)(((GridView)grdExpenditures.MainView).GetRow(selRows[0]));

                int noBankTransID = Convert.ToInt32(oBankTransID["ID"]);
                DateTime dTranDate = Convert.ToDateTime(TranDate["TranDate"]);

                BankTransaction oBankTran= db.BankTransactions.FirstOrDefault(p => p.BankTranID == noBankTransID);

                if (oBankTran == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //if (Global.CurrentUser.IsEditable == 1)
                //{
                //    if (dTranDate < DateTime.Today)
                //    {
                //        MessageBox.Show("This transaction can't be editable, Please contact BD Team", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}

                fBankTransaction frm = new fBankTransaction();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oBankTran,true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
            //try
            //{
            //    if (lsvCashTran.SelectedItems.Count <= 0)
            //    {
            //        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    CashTransaction oCashTransaction = null;
            //    fCashTransaction frm = new fCashTransaction();

            //    if (lsvCashTran.SelectedItems != null && lsvCashTran.SelectedItems.Count > 0)
            //    {
            //        oCashTransaction = (CashTransaction)lsvCashTran.SelectedItems[0].Tag;
            //    }
            //    frm.ItemChanged = RefreshList;
            //    frm.ShowDlg(oCashTransaction, true);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    CashTransaction oCashTransaction = new CashTransaction();
            //    if (lsvCashTran.SelectedItems != null && lsvCashTran.SelectedItems.Count > 0)
            //    {
            //        oCashTransaction = (CashTransaction)lsvCashTran.SelectedItems[0].Tag;

            //        if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            db.CashTransactions.Attach(oCashTransaction);
            //            db.CashTransactions.Remove(oCashTransaction);
            //            db.SaveChanges();
            //            RefreshList();
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvCashTran_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void grdExpenditures_Click(object sender, EventArgs e)
        {

        }
    }
}
