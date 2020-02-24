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
    public partial class fExpenseItems : Form
    {
        public fExpenseItems()
        {
            InitializeComponent();
        }

        private void fExpenseItems_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<ExpenseItem> _ExpenseItems = db.ExpenseItems.OrderBy(ex => ex.Code).ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ExpenseItemID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Status");

                    if (_ExpenseItems != null)
                    {
                        foreach (INVENTORY.DA.ExpenseItem grd in _ExpenseItems)
                        {
                            dr = dt.NewRow();
                            dr["ExpenseItemID"] = grd.ExpenseItemID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Description;
                            dr["Status"] = ((EnumExpenseType)Enum.Parse(typeof(EnumExpenseType), grd.Status.ToString())).ToString(); ;
                            dt.Rows.Add(dr);
                        }

                        grdExpens.DataSource = dt;
                        lblTotal.Text = "Total :" + _ExpenseItems.Count().ToString();
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
            //        List<ExpenseItem> _ExpenseItems = db.ExpenseItems.OrderBy(ex=>ex.Code).ToList();

            //        ListViewItem item = null;
            //        lsvExpenseItem.Items.Clear();

            //        if (_ExpenseItems != null)
            //        {
            //            foreach (INVENTORY.DA.ExpenseItem grd in _ExpenseItems)
            //            {
            //                item = new ListViewItem();
            //                item.Text = grd.Code;
            //                item.SubItems.Add(grd.Description);
            //                item.Tag = grd;
            //                lsvExpenseItem.Items.Add(item);
            //            }

            //            lblTotal.Text = "Total :" + _ExpenseItems.Count().ToString();
            //        }
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
                fExpenseItem frm = new fExpenseItem();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new ExpenseItem(), true);
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
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdExpens.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdExpens.MainView).GetRow(selRows[0]));

                int nExpenseID = Convert.ToInt32(oExpenseID["ExpenseItemID"]);
                ExpenseItem oExpense = db.ExpenseItems.FirstOrDefault(p => p.ExpenseItemID == nExpenseID);

                if (oExpense == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fExpenseItem frm = new fExpenseItem();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oExpense, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //try
            //{
            //    if (lsvExpenseItem.SelectedItems.Count <= 0)
            //    {
            //        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    ExpenseItem oExpenseItem = null;
            //    fExpenseItem frm = new fExpenseItem();

            //    if (lsvExpenseItem.SelectedItems != null && lsvExpenseItem.SelectedItems.Count > 0)
            //    {
            //        oExpenseItem = (ExpenseItem)lsvExpenseItem.SelectedItems[0].Tag;
            //    }
            //    frm.ItemChanged = RefreshList;
            //    frm.ShowDlg(oExpenseItem,false);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdExpens.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdExpens.MainView).GetRow(selRows[0]));
                int nExpenseID = Convert.ToInt32(oExpenseID["ExpenseItemID"]);
                ExpenseItem oExpense = db.ExpenseItems.FirstOrDefault(p => p.ExpenseItemID == nExpenseID);

                if (oExpense == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExpenseItems.Attach(oExpense);
                    db.ExpenseItems.Remove(oExpense);
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

        private void grdExpens_Click(object sender, EventArgs e)
        {

        }

        


    }
}
