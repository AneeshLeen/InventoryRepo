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
    public partial class fProducts : Form
    {
        DEWSRMEntities db = null;
        public fProducts()
        {

            InitializeComponent();
        }
        private void fProducts_Load(object sender, EventArgs e)
        {

            db = new DEWSRMEntities();
            RefreshList();
        }
        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Products = db.Products;
                    var _Categories = db.Categorys;
                    var _Companies = db.Companies;
                    var _Model=db.Models;

                    List<Product> oProList = _Products.OrderBy(m => m.Code).ToList();
                    List<Category> oCateList = _Categories.OrderBy(m => m.Code).ToList();
                    List<Company> oComList = _Companies.OrderBy(m => m.Code).ToList();
                    List<Model> oModelList=_Model.OrderBy(m=>m.Code).ToList();


                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ProductID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Company");
                    dt.Columns.Add("Category");
                    dt.Columns.Add("Size");
                    if (_Products != null)
                    {
                        foreach (Product grd in oProList.ToList())
                        {
                            Category oCat = oCateList.FirstOrDefault(o => o.CategoryID == grd.CategoryID);
                            Company oCom = oComList.FirstOrDefault(o => o.CompanyID == grd.CompanyID);
                            Model oModel = oModelList.FirstOrDefault(o => o.ModelID == grd.ModelID);

                            dr = dt.NewRow();
                            dr["ProductID"] = grd.ProductID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.ProductName;

                            if (oCat != null)
                                dr["Category"] = oCat.Description;
                            if (oCom != null)
                                dr["Company"] = oCom.Description;
                            if (oModel != null)
                                dr["Size"] = oModel.Description;

                            dt.Rows.Add(dr);

                        }

                        grdProducts.DataSource = dt;
                        lblTotal.Text = "Total :" + _Products.Count().ToString();
                    }

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
            fProduct frm = new fProduct();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Product(),true);

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdProducts.MainView).GetSelectedRows();
                DataRowView oProductID = (DataRowView)(((GridView)grdProducts.MainView).GetRow(selRows[0]));

                int nProductID = Convert.ToInt32(oProductID["ProductID"]);
                Product oProduct = db.Products.FirstOrDefault(p => p.ProductID == nProductID);

                if (oProduct == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fProduct frm = new fProduct();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oProduct, false);
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
                int[] selRows = ((GridView)grdProducts.MainView).GetSelectedRows();
                DataRowView oProductID = (DataRowView)(((GridView)grdProducts.MainView).GetRow(selRows[0]));

                int nProductID = Convert.ToInt32(oProductID["ProductID"]);
                Product oProduct = db.Products.FirstOrDefault(p => p.ProductID == nProductID);

                if (oProduct == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Products.Attach(oProduct);
                    db.Products.Remove(oProduct);
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
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Check whether the GridControl can be previewed.
            if (!grdProducts.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grdProducts.ShowPrintPreview();
        }

        private void grdProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void chkIsBangla_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
