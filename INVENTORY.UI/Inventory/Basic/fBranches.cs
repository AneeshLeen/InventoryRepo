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
using Microsoft.Reporting.WinForms;

using DevExpress.XtraGrid.Views.Grid;

namespace INVENTORY.UI
{
    public partial class fBranches : Form
    {
        public List<Bank> _BankList = null;
        string SearchItem = string.Empty;
       DEWSRMEntities db = null;

        public fBranches()
        {
        //    db = new DEWSRMEntities();
            InitializeComponent();
        }
        private void fProducts_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
       
        private void RefreshList()            
           {
               try
               {
                   using (DEWSRMEntities db = new DEWSRMEntities())
                   {
                       var _Branches = db.Branches.OrderBy(o=>o.BankID);                  

                       DataTable dt = new DataTable();
                       DataRow dr = null;

                       dt.Columns.Add("BranchID");
                       dt.Columns.Add("Code");
                       dt.Columns.Add("Bank");
                       dt.Columns.Add("Name");
                       dt.Columns.Add("Address");

                       _BankList = db.Banks.ToList();


                       
                     
                           if (_Branches != null)
                           {
                               
                               foreach (Branch grd in _Branches)
                               {

                                   dr = dt.NewRow();

                                   Bank oCat = _BankList.FirstOrDefault(o => o.BankID == grd.BankID);

                                   dr["BranchID"] = grd.BranchID;
                                   dr["Code"] = grd.Code;
                                   dr["Bank"] = oCat.BankName;
                                   dr["Name"] = grd.BranchName;
                                   dr["Address"] = grd.Address;
                                   dt.Rows.Add(dr);

                               }

                               grdBranches.DataSource = dt;
                               lblTotal.Text = "Total :" + _Branches.Count().ToString();
                           }
                       
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               } 
           //Edited by bd

        //    try
        //    {
        //        using (DEWSRMEntities db = new DEWSRMEntities())
        //        {
        //            List<Product> _Products = db.Products.OrderBy(p=>p.Code).ToList();
        //            _CategoryList = db.Categorys.ToList();

        //            ListViewItem item = null;
        //            lsvProduct.Items.Clear();

        //            if (_Products != null)
        //            {
        //                List<ListViewItem> lItems = new List<ListViewItem>();
        //                foreach (Product grd in _Products)
        //                {
        //                    item = new ListViewItem();
        //                    item.Text = grd.Code;
        //                    Category oCat = _CategoryList.FirstOrDefault(o => o.CategoryID == grd.CategoryID);

        //                    item.SubItems.Add(oCat.Description);
        //                    item.SubItems.Add(grd.ProductName);
        //                    item.Tag = grd;
        //                    lItems.Add(item);
        //                }
        //                lsvProduct.Items.AddRange(lItems.ToArray());
        //                lblTotal.Text = "Total :" + _Products.Count().ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }

        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            fBranch frm = new fBranch();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Branch(),true);
           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdBranches.MainView).GetSelectedRows();
                    DataRowView oBranchD = (DataRowView)(((GridView)grdBranches.MainView).GetRow(selRows[0]));

                    int nBranchID = Convert.ToInt32(oBranchD["BranchID"]);
                    Branch oBranch = db.Branches.FirstOrDefault(p => p.BranchID == nBranchID);


                    if (oBranch == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                      fBranch frm = new fBranch();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oBranch, false);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
            //if (lsvProduct.SelectedItems.Count <= 0)
            //{
            //    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //Product Product = null;
            //fProduct frm = new fProduct();

            //if (lsvProduct.SelectedItems != null && lsvProduct.SelectedItems.Count > 0)
            //{
            //    Product = (Product)lsvProduct.SelectedItems[0].Tag;
            //}
            //frm.ItemChanged = RefreshList;
            //frm.ShowDlg(Product,false);

        
        private void btnDelete_Click(object sender, EventArgs e)
        {   
            //try
            //{
            //         db = new DEWSRMEntities();
            //        int[] selRows = ((GridView)grdBranches.MainView).GetSelectedRows();
            //        DataRowView oProductID = (DataRowView)(((GridView)grdBranches.MainView).GetRow(selRows[0]));
            //        int nProductID = Convert.ToInt32(oProductID["ProductID"]);
            //        Product oProduct = db.Products.FirstOrDefault(p => p.ProductID == nProductID);

            //        if (oProduct == null)
            //        {
            //            MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }

            //        if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question) == DialogResult.Yes)
            //        {

                       
                         
            //                db.Products.Attach(oProduct);
            //                db.Products.Remove(oProduct);
                          
            //                db.SaveChanges();
                     
            //            MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            RefreshList();
            //        }
               
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show("Cannot delete item due to " + Ex.Message);
            //}
            
            //try
            //{
            //    Product oProduct = new Product();
            //    if (lsvProduct.SelectedItems != null && lsvProduct.SelectedItems.Count > 0)
            //    {
            //        oProduct = (Product)lsvProduct.SelectedItems[0].Tag;
            //        if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            using (DEWSRMEntities db = new DEWSRMEntities())
            //            {
            //                db.Products.Attach(oProduct);
            //                db.Products.Remove(oProduct);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    SearchItem = txtSearch.Text;
            //    List<Product> ProList = (List<Product>)db.Products.Where(p => p.ProductName.StartsWith(SearchItem)).ToList();
            //    RefreshAfterCheck(ProList);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //if (txtSearch.Text != "")
            //{
            //    foreach (ListViewItem item in lsvProduct.Items)
            //    {
            //        if (item.SubItems[2].Text.ToLower().Contains(txtSearch.Text.ToLower()))
            //        {
            //            item.Selected = true;
            //        }
            //        else
            //        {
            //            lsvProduct.Items.Remove(item);
            //        }
            //        item.Selected = false;   
            //    }
            //    if (lsvProduct.SelectedItems.Count == 1)
            //    {
            //        lsvProduct.Focus();
            //    }
            //}
            //else
            //{
            //    RefreshList();
            //}
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        //private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SearchItem = txtSearchCategory.Text;
        //        List<Product> ProList = (List<Product>)db.Products.Where(p => p.Category.Description.StartsWith(SearchItem)).ToList();
        //        RefreshAfterCheck(ProList);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void lsvProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    btnEdit_Click(sender, e);
        //}

        //private void RefreshAfterCheck(List<Product> oProList)
        //{
        //    try
        //    {
        //        ListViewItem item = null;
        //        lsvProduct.Items.Clear();

        //        if (oProList != null)
        //        {
        //            List<ListViewItem> lItems = new List<ListViewItem>();

        //            foreach (Product grd in oProList)
        //            {
        //                item = new ListViewItem();
        //                item.Text = grd.Code;
        //                Category oCat = _CategoryList.FirstOrDefault(o => o.CategoryID == grd.CategoryID);

        //                item.SubItems.Add(oCat.Description);
        //                item.SubItems.Add(grd.ProductName);
        //                item.Tag = grd;
        //                lItems.Add(item);
        //            }

        //            lsvProduct.Items.AddRange(lItems.ToArray());
        //            lblTotal.Text = "Total :" + oProList.Count().ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void grdProducts_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Check whether the GridControl can be previewed.
            if (!grdBranches.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grdBranches.ShowPrintPreview();

        }

        private void grdBranches_Click(object sender, EventArgs e)
        {

        }
    }
}
