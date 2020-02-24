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

    public partial class fCashCollections : Form
    {
        DEWSRMEntities db = null;
        public fCashCollections()
        {
            db=new DEWSRMEntities();
            InitializeComponent();
        }

        private void fCashCollections_Load(object sender, EventArgs e)
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
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {


                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("CashCollectionID");
                    dt.Columns.Add("EntryDate");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("ContactNo");
                    dt.Columns.Add("AccountNo");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("Status");


                    var _CashCollections = db.CashCollections.Where( t=>t.TransactionType==2).OrderByDescending(c => c.EntryDate).ToList();

                    //    var _CashCollectoins = db.CashCollections.OrderByDescending(c => c.EntryDate).ToList();





                    if (_CashCollections != null)
                    {

                        foreach (CashCollection oCashColl in _CashCollections)
                        {

                            dr = dt.NewRow();
                            dr["CashCollectionID"] = oCashColl.CashCollectionID;
                            dr["EntryDate"] = Convert.ToDateTime(oCashColl.EntryDate).ToString("dd MMM yyyy");//oCashColl.EntryDate.ToString();

                            if (oCashColl.Customer != null)
                            {
                                dr["name"] = oCashColl.Customer.Name;
                                dr["ContactNo"] = oCashColl.Customer.ContactNo;


                            }
                            else if (oCashColl.Supplier != null)
                            {
                                dr["name"] = oCashColl.Supplier.Name;
                                dr["ContactNo"] = oCashColl.Supplier.ContactNo;


                            }
                            else
                            {
                                dr["name"] = " ";
                                dr["ContactNo"] = " ";
                            }

                            if (oCashColl.AccountNo != "")
                            {
                                dr["AccountNo"] = oCashColl.AccountNo;

                            }
                            else if (oCashColl.BKashNo != "")
                            {
                                dr["AccountNo"] = oCashColl.BKashNo;

                            }
                            else if (oCashColl.MBAccountNo != "")
                            {
                                dr["AccountNo"] = oCashColl.MBAccountNo;

                            }
                            else
                            {
                                dr["AccountNo"] = "Cash";

                            }
                            dr["Amount"] = oCashColl.Amount.ToString();



                            if (oCashColl.TransactionType == (int)EnumTranType.FromCustomer)
                            {
                                dr["Status"] = "Cash Collection";

                            }
                            else if (oCashColl.TransactionType == (int)EnumTranType.ToCompany)
                            {
                                dr["Status"] = "Cash Delivery";

                            }
                            else
                            {
                                dr["Status"] = "Bank Deposite";

                            }



                            dt.Rows.Add(dr);

                        }

                        grdCashCollections.DataSource = dt;

                        lblTotal.Text = "Total :" + _CashCollections.Count().ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //try
            //{
            //    using (DEWSRMEntities db = new DEWSRMEntities())
            //    {
            //    var _CashCollectoins = db.CashCollections.OrderByDescending(c => c.EntryDate);

            //    ListViewItem item = null;
            //    lsvCashCollection.Items.Clear();

            //    if (_CashCollectoins != null)
            //    {
            //        foreach (CashCollection oCashColl in _CashCollectoins)
            //        {
            //            item = new ListViewItem();
            //            item.Text = Convert.ToDateTime(oCashColl.EntryDate).ToString("dd MMM yyyy");//oCashColl.EntryDate.ToString();

            //            if (oCashColl.Customer != null)
            //            {
            //                item.SubItems.Add(oCashColl.Customer.Name);
            //                item.SubItems.Add(oCashColl.Customer.ContactNo);
            //            }
            //            else if (oCashColl.Supplier != null)
            //            {
            //                item.SubItems.Add(oCashColl.Supplier.Name);
            //                item.SubItems.Add(oCashColl.Supplier.ContactNo);
            //            }
            //            else
            //            {
            //                item.SubItems.Add("");
            //                item.SubItems.Add("");
            //            }

            //            if (oCashColl.AccountNo != "")
            //            {
            //                item.SubItems.Add(oCashColl.AccountNo);
            //            }
            //            else if (oCashColl.BKashNo != "")
            //            {
            //                item.SubItems.Add(oCashColl.BKashNo);
            //            }
            //            else if (oCashColl.MBAccountNo != "")
            //            {
            //                item.SubItems.Add(oCashColl.MBAccountNo);
            //            }
            //            else
            //            {
            //                item.SubItems.Add("Cash");
            //            }

            //            item.SubItems.Add(oCashColl.Amount.ToString());

            //            if (oCashColl.TransactionType == (int)EnumTranType.FromCustomer)
            //            {
            //                item.SubItems.Add("Cash Collection");
            //            }
            //            else if (oCashColl.TransactionType == (int)EnumTranType.ToCompany)
            //            {
            //                item.SubItems.Add("Cash Delivery");
            //            }
            //            else
            //            {
            //                item.SubItems.Add("Bank Deposite");
            //            }

            //            item.Tag = oCashColl;
            //            lsvCashCollection.Items.Add(item);
            //        }

            //        lblTotal.Text = "Total :" + _CashCollectoins.Count().ToString();
            //    }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fCashCollection frm = new fCashCollection();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new CashCollection(),false);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdCashCollections.MainView).GetSelectedRows();
                DataRowView oCashCollectionID = (DataRowView)(((GridView)grdCashCollections.MainView).GetRow(selRows[0]));
                DataRowView oCollDate = (DataRowView)(((GridView)grdCashCollections.MainView).GetRow(selRows[0]));

                int nCashCollectionID = Convert.ToInt32(oCashCollectionID["CashCollectionID"]);
                DateTime CollDate = Convert.ToDateTime(oCollDate["EntryDate"]);

                CashCollection oCashCollection = db.CashCollections.FirstOrDefault(p => p.CashCollectionID == nCashCollectionID);

                if (oCashCollection == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if(Global.CurrentUser.ISEditable==1)
                {
                    if (CollDate < DateTime.Today)
                    {
                        MessageBox.Show("This Item can't be editable, Please contact BD Team", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                fCashCollection frm = new fCashCollection();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oCashCollection, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int[] selRows = ((GridView)grdCashCollections.MainView).GetSelectedRows();
                DataRowView oCashCollectionID = (DataRowView)(((GridView)grdCashCollections.MainView).GetRow(selRows[0]));

                int nCashCollectionID = Convert.ToInt32(oCashCollectionID["CashCollectionID"]);
                CashCollection oCashCollection = db.CashCollections.FirstOrDefault(p => p.CashCollectionID == nCashCollectionID);

                if (oCashCollection == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.CashCollections.Attach(oCashCollection);
                    db.CashCollections.Remove(oCashCollection);
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

        private void btnMoneyReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdCashCollections.MainView).GetSelectedRows();
                DataRowView oCashCollectionID = (DataRowView)(((GridView)grdCashCollections.MainView).GetRow(selRows[0]));
                DataRowView oCollDate = (DataRowView)(((GridView)grdCashCollections.MainView).GetRow(selRows[0]));

                int nCashCollectionID = Convert.ToInt32(oCashCollectionID["CashCollectionID"]);
                DateTime CollDate = Convert.ToDateTime(oCollDate["EntryDate"]);

                CashCollection oCashCollection = db.CashCollections.FirstOrDefault(p => p.CashCollectionID == nCashCollectionID);

                if (oCashCollection == null)
                {
                    MessageBox.Show("select an item ", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                fCashCollection obj = new fCashCollection();
                obj.MoneyReceipt(oCashCollection);

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Cannot generate Money Receipt due to " + Ex.Message);
            }
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int count = lsvCashCollection.Items.Count;
        //        if (txtSearch.Text != "")
        //        {
        //            foreach (ListViewItem item in lsvCashCollection.Items)
        //            {
        //                if (item.SubItems[1].Text.ToLower().Contains(txtSearch.Text.ToLower()))
        //                {
        //                    item.Selected = true;
        //                }
        //                else
        //                {
        //                    lsvCashCollection.Items.Remove(item);
        //                }
        //                item.Selected = false;
        //            }
        //            if (lsvCashCollection.SelectedItems.Count == 1)
        //            {
        //                lsvCashCollection.Focus();
        //            }
        //        }
        //        else
        //        {
        //            RefreshList();
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void txtContactNo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int count = lsvCashCollection.Items.Count;
        //        if (txtContactNo.Text != "")
        //        {
        //            foreach (ListViewItem item in lsvCashCollection.Items)
        //            {
        //                if (item.SubItems[2].Text.ToLower().Contains(txtContactNo.Text.ToLower()))
        //                {
        //                    item.Selected = true;
        //                }
        //                else
        //                {
        //                    lsvCashCollection.Items.Remove(item);
        //                }
        //                item.Selected = false;
        //            }
        //            if (lsvCashCollection.SelectedItems.Count == 1)
        //            {
        //                lsvCashCollection.Focus();
        //            }
        //        }
        //        else
        //        {
        //            RefreshList();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
