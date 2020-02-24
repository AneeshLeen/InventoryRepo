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
    public partial class fBanks: Form
    {
        public fBanks()
        {
            InitializeComponent();
        }
        private void fCategorys_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("BankID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("AccName");
            dt.Columns.Add("AccountNo");
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                var  _Banks = db.Banks.OrderBy(c=>c.Code);
                   
                 

                    if (_Banks != null)
                    {
                        foreach (Bank grd in _Banks)
                        {
                            dr = dt.NewRow();
                            dr["BankID"] = grd.BankID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.BankName;
                            dr["AccName"] = grd.AccountName;
                            dr["AccountNo"] = grd.AccountNo;
                            dt.Rows.Add(dr);
                            
                        }
                        grdBanks.DataSource = dt;
                        lblTotal.Text = "Total :" + _Banks.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // try
        //    {
        //        using (DEWSRMEntities db = new DEWSRMEntities())
        //        {
        //            List<Category> _Categorys = db.Categorys.OrderBy(c=>c.Code).ToList();

        //            ListViewItem item = null;
        //             lsvCategory.Items.Clear();

        //            if (_Categorys != null)
        //            {
        //                foreach (Category grd in _Categorys)
        //                {
        //                    item = new ListViewItem();
        //                    item.Text = grd.Code;
        //                    item.SubItems.Add(grd.Description);
        //                    //item.SubItems.Add(((EnumCategoryType)grd.CategoryType).ToString());
        //                    item.Tag = grd;
        //                    lsvCategory.Items.Add(item);
        //                }

        //                lblTotal.Text = "Total :" + _Categorys.Count().ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        
        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            fBank frm = new fBank();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Bank(),true);
           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdBanks.MainView).GetSelectedRows();
                    DataRowView oBankD = (DataRowView)(((GridView)grdBanks.MainView).GetRow(selRows[0]));

                    int nBankID = Convert.ToInt32(oBankD["BankID"]);
                    Bank oBank = db.Banks.FirstOrDefault(p => p.BankID == nBankID);


                    if (oBank == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fBank frm = new fBank();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oBank, false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //if (lsvCategory.SelectedItems.Count <= 0)
            //{
            //    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //Category Category = null;
            //fCategory frm = new fCategory();

            //if (lsvCategory.SelectedItems != null && lsvCategory.SelectedItems.Count > 0)
            //{
            //    Category = (Category)lsvCategory.SelectedItems[0].Tag;
            //}
            //frm.ItemChanged = RefreshList;
            //frm.ShowDlg(Category,false);
           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdBanks.MainView).GetSelectedRows();
                    DataRowView oBankD = (DataRowView)(((GridView)grdBanks.MainView).GetRow(selRows[0]));

                    int nBankID = Convert.ToInt32(oBankD["BankID"]);
                    Bank oBank = db.Banks.FirstOrDefault(p => p.BankID == nBankID);

                    if (oBank == null)
                    {
                        MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.Banks.Attach(oBank);
                        db.Banks.Remove(oBank);
                        db.SaveChanges();
                        MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshList();
                    };
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //try
            //{
            //    Category oCategory = new Category();
            //    if (lsvCategory.SelectedItems != null && lsvCategory.SelectedItems.Count > 0)
            //    {
            //        oCategory = (Category)lsvCategory.SelectedItems[0].Tag;
            //        if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            using (DEWSRMEntities db = new DEWSRMEntities())
            //            {
            //                db.Categorys.Attach(oCategory);
            //                db.Categorys.Remove(oCategory);
            //                //Save to database
            //                db.SaveChanges();
            //            }
            //            RefreshList();
            //        } 
            //    }

            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show("Cannot delete item due to " + Ex.Message);
            //}
        }
        #endregion

        //private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtSearchCategory.Text != "")
        //        {
        //            foreach (ListViewItem item in lsvCategory.Items)
        //            {
        //                if (item.SubItems[1].Text.ToLower().Contains(txtSearchCategory.Text.ToLower()))
        //                {
        //                    item.Selected = true;
        //                }
        //                else
        //                {
        //                    lsvCategory.Items.Remove(item);
        //                }
        //                item.Selected = false;
        //            }
        //            if (lsvCategory.SelectedItems.Count == 1)
        //            {
        //                lsvCategory.Focus();
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

        private void lsvCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
