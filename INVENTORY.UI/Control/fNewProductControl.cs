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
    public partial class fNewProductControl : Form
    {
        public List<Product> _Products = null;

        public Action ItemChanged;
        ctlCustomControl _ctl;
        //bool _IsStockProduct;
        string SearchItem = string.Empty;
        DEWSRMEntities db = null;

        private string _ObjectName = String.Empty;
        public int _CustID = 0;

        public fNewProductControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }
        public void ShowDlg(string sObjectName, ctlCustomControl ctlCustomControl, int customerID)
        {
            _ctl = ctlCustomControl;
            _ObjectName = sObjectName;
            _CustID = customerID;
            this.ShowDialog();
        }

        private void RefreshList()
        {
            try
            {

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add("ProductID");
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");
                dt.Columns.Add("Company");
                dt.Columns.Add("SDetailID");
                dt.Columns.Add("Category");
                dt.Columns.Add("Size");
                dt.Columns.Add("Color");

                List<Product> ProductList = db.Products.ToList();
                List<Category> CategoryList = db.Categorys.ToList();
                List<Model> ModelList = db.Models.ToList();
                List<Company> CompanyList = db.Companies.ToList();
                List<StockDetail> StockDetailList = db.StockDetails.ToList();
                List<INVENTORY.DA.Color> oColorList = db.Colors.ToList();


                Product oProduct = null;
                Category oCategory = null;
                Company oCompany = null;
                Model oModel = null;
                INVENTORY.DA.Color oColor = null;


                if (_ObjectName == "SReturn")
                {
                    StockDetail oStockDetail = null;
                    var CustomerSOrderDetailList = db.SOrderDetails.Where(o => o.SOrder.CustomerID == _CustID && o.SOrder.Status == (int)EnumSalesType.Sales).ToList();

                    #region Barcode and Serial Product
                    var ALLSOrderDetailsList = (from sod in CustomerSOrderDetailList
                                                join p in ProductList on sod.ProductID equals p.ProductID
                                                where p.ProductType != (int)EnumProductType.NoBarCode
                                                select sod).ToList();


                    var ALLDisSOrderDetailsList = (from d in ALLSOrderDetailsList
                                                   group d by new { d.ProductID, d.StockDetailID } into g
                                                   select new SOrderDetail
                                                   {
                                                       ProductID = g.Key.ProductID,
                                                       StockDetailID = g.Key.StockDetailID
                                                   }).ToList();


                    int nTempProId = 0;
                    this.Text = "All Sales Products";
                    if (ALLDisSOrderDetailsList != null)
                    {

                        foreach (var grd in ALLDisSOrderDetailsList)
                        {

                            oProduct = ProductList.FirstOrDefault(s => s.ProductID == grd.ProductID);


                            oCategory = CategoryList.FirstOrDefault(p => p.CategoryID == oProduct.CategoryID);
                            oCompany = CompanyList.FirstOrDefault(p => p.CompanyID == oProduct.CompanyID);
                            oModel = ModelList.FirstOrDefault(p => p.ModelID == oProduct.ModelID);
                            oStockDetail = new StockDetail();
                            oStockDetail = StockDetailList.FirstOrDefault(p => p.SDetailID == grd.StockDetailID);
                            oColor = oColorList.FirstOrDefault(c => c.ColorID == oStockDetail.ColorID);

                            if (oStockDetail.Status == (int)EnumStockDetailStatus.Sold)
                            {
                                dr = dt.NewRow();
                                dr["ProductID"] = oProduct.ProductID;
                                dr["Code"] = oProduct.Code;
                                dr["Name"] = oProduct.ProductName;
                                dr["Company"] = oCompany.Description;
                                dr["Category"] = oCategory.Description;
                                dr["SDetailID"] = grd.StockDetailID;
                                dr["Color"] = oColor.Description;
                                dr["Size"] = oStockDetail.IMENO;
                                dt.Rows.Add(dr);
                            }
                        }


                    }
                    #endregion

                    #region Nobarcode
                    var ALLnobarcodeSODList = (from sod in CustomerSOrderDetailList
                                               join p in ProductList on sod.ProductID equals p.ProductID
                                               where p.ProductType == (int)EnumProductType.NoBarCode
                                               select sod).ToList();

                    if (ALLnobarcodeSODList.Count() != 0)
                    {
                        var ALLNobarcodeDisSODList = (from d in ALLnobarcodeSODList
                                                      group d by new { d.StockDetailID } into g
                                                      select new SOrderDetail
                                                      {
                                                          StockDetailID = g.Key.StockDetailID,

                                                      }).ToList();

                        foreach (var grd in ALLNobarcodeDisSODList)
                        {
                            oStockDetail = new StockDetail();
                            oStockDetail = StockDetailList.FirstOrDefault(p => p.SDetailID == grd.StockDetailID);
                            oProduct = ProductList.FirstOrDefault(s => s.ProductID == oStockDetail.ProductID);
                            oCategory = CategoryList.FirstOrDefault(p => p.CategoryID == oProduct.CategoryID);
                            oCompany = CompanyList.FirstOrDefault(p => p.CompanyID == oProduct.CompanyID);
                            oModel = ModelList.FirstOrDefault(p => p.ModelID == oProduct.ModelID);

                            oColor = oColorList.FirstOrDefault(c => c.ColorID == oStockDetail.ColorID);

                            dr = dt.NewRow();
                            dr["ProductID"] = oProduct.ProductID;
                            dr["Code"] = oProduct.Code;
                            dr["Name"] = oProduct.ProductName;
                            dr["Category"] = oCategory.Description;
                            dr["Company"] = oCompany.Description;
                            dr["SDetailID"] = grd.StockDetailID;
                            dr["Color"] = oColor.Description;
                            dr["Size"] = oStockDetail.IMENO;

                            dt.Rows.Add(dr);
                        }
                    }
                    #endregion

                    grdProducts.DataSource = dt;
                    lblTotal.Text = "Total :" + ALLSOrderDetailsList.Count().ToString();
                    // + ALLnobarcodeSODList.Sum(i => i.Quantity)
                }
                else if (_ObjectName == "PReturn")
                {
                    StockDetail oStockDetail = null;
                    int nCount = 0;

                    var SuppPOrderDetailList = db.POrderDetails.Where(o => o.POrder.SupplierID == _CustID && o.POrder.Status == (int)EnumPurchaseType.Purchase).ToList();

                    #region Barcode and Serial Product
                    var ALLSOrderDetailsList = (from sod in SuppPOrderDetailList
                                                join p in ProductList on sod.ProductID equals p.ProductID
                                                join std in db.StockDetails on sod.POrderDetailID equals std.POrderDetailID
                                                where p.ProductType != (int)EnumProductType.NoBarCode
                                                select new
                                                {
                                                    sod,
                                                    std
                                                }).ToList();


                    var ALLDisSOrderDetailsList = (from d in ALLSOrderDetailsList
                                                   where d.std.Status == (int)EnumStockDetailStatus.Stock
                                                   group d by new { d.std.SDetailID, d.std.ProductID, d.std.ColorID } into g
                                                   select new
                                                   {
                                                       ProductID = g.Key.ProductID,
                                                       SDetailID = g.Key.SDetailID,
                                                       ColorID = g.Key.ColorID
                                                   }).ToList();


                    //int nTempProId = 0;
                    this.Text = "All Purchase Products";
                    if (ALLDisSOrderDetailsList != null && ALLDisSOrderDetailsList.Count > 0)
                    {

                        foreach (var grd in ALLDisSOrderDetailsList)
                        {

                            oProduct = ProductList.FirstOrDefault(s => s.ProductID == grd.ProductID);
                            oCategory = CategoryList.FirstOrDefault(p => p.CategoryID == oProduct.CategoryID);
                            oCompany = CompanyList.FirstOrDefault(p => p.CompanyID == oProduct.CompanyID);
                            oModel = ModelList.FirstOrDefault(p => p.ModelID == oProduct.ModelID);
                            oStockDetail = new StockDetail();
                            oStockDetail = StockDetailList.FirstOrDefault(p => p.SDetailID == grd.SDetailID);
                            oColor = oColorList.FirstOrDefault(c => c.ColorID == oStockDetail.ColorID);

                            if (oStockDetail.Status == (int)EnumStockDetailStatus.Stock)
                            {
                                dr = dt.NewRow();
                                dr["ProductID"] = oProduct.ProductID;
                                dr["Code"] = oProduct.Code;
                                dr["Name"] = oProduct.ProductName;
                                dr["Company"] = oCompany.Description;
                                dr["Category"] = oCategory.Description;
                                dr["SDetailID"] = grd.SDetailID;
                                dr["Color"] = oColor.Description;
                                dr["Size"] = oStockDetail.IMENO;
                                dt.Rows.Add(dr);
                            }
                        }


                    }
                    #endregion

                    #region Nobarcode
                    var ALLnobarcodeSODList = (from sod in SuppPOrderDetailList
                                               join p in ProductList on sod.ProductID equals p.ProductID
                                               where p.ProductType == (int)EnumProductType.NoBarCode
                                               select sod).ToList();

                    if (ALLnobarcodeSODList.Count() != 0)
                    {
                        var ALLNobarcodeDisSODList = (from d in ALLnobarcodeSODList
                                                      group d by new { d.ProductID, d.ColorID } into g
                                                      select new POrderDetail
                                                      {
                                                          // POrderDetailID=g.Key.POrderDetailID,
                                                          ProductID = g.Key.ProductID,
                                                          ColorID = g.Key.ColorID

                                                      }).ToList();


                        //int nProductId = 0;
                        //int nColorId = 0;

                        foreach (var grd in ALLNobarcodeDisSODList)
                        {

                            oStockDetail = new StockDetail();
                            oStockDetail = StockDetailList.FirstOrDefault(p => p.ProductID == grd.ProductID && p.ColorID == grd.ColorID);
                            oProduct = ProductList.FirstOrDefault(s => s.ProductID == oStockDetail.ProductID);
                            oCategory = CategoryList.FirstOrDefault(p => p.CategoryID == oProduct.CategoryID);
                            oCompany = CompanyList.FirstOrDefault(p => p.CompanyID == oProduct.CompanyID);
                            oModel = ModelList.FirstOrDefault(p => p.ModelID == oProduct.ModelID);

                            oColor = oColorList.FirstOrDefault(c => c.ColorID == oStockDetail.ColorID);

                            dr = dt.NewRow();
                            dr["ProductID"] = oProduct.ProductID;
                            dr["Code"] = oProduct.Code;
                            dr["Name"] = oProduct.ProductName;
                            dr["Category"] = oCategory.Description;
                            dr["Company"] = oCompany.Description;
                            dr["SDetailID"] = oStockDetail.SDetailID;
                            dr["Color"] = oColor.Description;
                            dr["Size"] = oStockDetail.IMENO;

                            dt.Rows.Add(dr);
                            nCount++;

                        }
                    }
                    #endregion

                    grdProducts.DataSource = dt;
                    lblTotal.Text = "Total :" + nCount.ToString();
                    //+",Qty:"+ ALLnobarcodeSODList.Sum(i => i.Quantity)

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

                int nProductID = Convert.ToInt32(oProductID["ProductID"]);
                //int nModelID = Convert.ToInt32(oProductID["Model"]);
                int nStockDetailsID = Convert.ToInt32(oProductID["SDetailID"]);

                Product oProduct = null;

                if (nProductID > 0)
                {
                    oProduct = db.Products.FirstOrDefault(p => p.ProductID == nProductID);
                    _ctl.SelectedID = nStockDetailsID;
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
