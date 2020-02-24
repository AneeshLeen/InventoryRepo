using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using INVENTORY.DA;


namespace INVENTORY.UI
{
    public partial class fProductControl : Form
    {
        public List<Product> _Products = null;
        public List<Category> _CategoryList = null;
        public List<Company> _CompanyList = null;
        public Action ItemChanged;
        ctlCustomControl _ctl;
        //bool _IsStockProduct;
        DEWSRMEntities db = null;
        string _ObjectName = string.Empty;

        public fProductControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(ctlCustomControl ctlCustomControl, string ObjectName)
        {
            _ObjectName = ObjectName;
            _ctl = ctlCustomControl;
            this.ShowDialog();
        }
        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Products = db.Products;
                    List<Stock> _StockList = null;
                    //if (_IsStockProduct)
                        

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ProductID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Category");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Company");

                    _CategoryList = db.Categorys.ToList();
                    _CompanyList = db.Companies.ToList();

                    if (_ObjectName=="OProduct")
                    {
                        _StockList = db.Stocks.ToList();
                        int nCount = 0;
                        if (_Products != null)
                        {

                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Product grd in _Products)
                            {
                                Stock oStock = _StockList.Where(o=>o.Quantity!=0).FirstOrDefault(o => o.ProductID == grd.ProductID);

                                if (oStock != null)
                                {
                                    if (oStock.Quantity>0)
                                    {
                                        dr = dt.NewRow();

                                        Category oCat = _CategoryList.FirstOrDefault(o => o.CategoryID == grd.CategoryID);
                                        Company oCompany = _CompanyList.FirstOrDefault(o => o.CompanyID == grd.CompanyID);

                                        dr["ProductID"] = grd.ProductID;
                                        dr["Code"] = grd.Code;
                                        dr["Category"] = oCat.Description;
                                        dr["Name"] = grd.ProductName;
                                        dr["Company"] = oCompany.Description;
                                        dt.Rows.Add(dr);
                                        nCount++;
                                    }

                                }
                            }
                            grdProducts.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();

                        }

                    }
                    else if(_ObjectName=="Product")
                    {
                        if (_Products != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Product grd in _Products)
                            {

                                dr = dt.NewRow();

                                Category oCat = _CategoryList.FirstOrDefault(o => o.CategoryID == grd.CategoryID);
                                Company oCompany = _CompanyList.FirstOrDefault(o => o.CompanyID == grd.CompanyID);

                                dr["ProductID"] = grd.ProductID;
                                dr["Code"] = grd.Code;
                                dr["Category"] = oCat.Description;
                                dr["Name"] = grd.ProductName;
                                dr["Company"] = oCompany.Description;

                                dt.Rows.Add(dr);

                            }

                            grdProducts.DataSource = dt;
                            lblTotal.Text = "Total :" + _Products.Count().ToString();
                        }
                    }
                    else if(_ObjectName=="SPReport")
                    {
                        _StockList = db.Stocks.ToList();
                        int nCount = 0;
                        if (_Products != null)
                        {

                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Product grd in _Products)
                            {
                                Stock oStock = _StockList.FirstOrDefault(o => o.ProductID == grd.ProductID);

                                if (oStock != null)
                                {
                                    //if (oStock.Quantity > 0)
                                    //{
                                        dr = dt.NewRow();

                                        Category oCat = _CategoryList.FirstOrDefault(o => o.CategoryID == grd.CategoryID);
                                        Company oCompany = _CompanyList.FirstOrDefault(o => o.CompanyID == grd.CompanyID);

                                        dr["ProductID"] = grd.ProductID;
                                        dr["Code"] = grd.Code;
                                        dr["Category"] = oCat.Description;
                                        dr["Name"] = grd.ProductName;
                                        dr["Company"] = oCompany.Description;
                                        dt.Rows.Add(dr);
                                        nCount++;
                                    //}

                                }
                            }
                            grdProducts.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fProductControl_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void grdProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdProducts.MainView).GetSelectedRows();
                DataRowView oProductID = (DataRowView)(((GridView)grdProducts.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oProductID["ProductID"]);
                Product oProduct = db.Products.FirstOrDefault(p => p.ProductID == nID);

                if (oProduct != null)
                {
                    _ctl.SelectedID = oProduct.ProductID;
                    _ctl.Code = oProduct.Code;
                    _ctl.Name = oProduct.ProductName;
                }

                if (ItemChanged != null)
                {
                    ItemChanged();
                }
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
