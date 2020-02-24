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
    public partial class fStockDetailControl : Form
    {
        public List<Product> _ProductList = null;
        public List<Company> _CompanyList = null;
        public List<Category> _CategoryList = null;
        public List<INVENTORY.DA.Color> _ColorList = null;

        public Action ItemChanged;
        ctlCustomControl _ctl;
        bool _IsStockProduct;
        DEWSRMEntities db = null;
        public Product _oProduct = null;
        public Company _oCompany = null;
        public Category _oCategory = null;
        public INVENTORY.DA.Color _Color = null;

        public fStockDetailControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(ctlCustomControl ctlCustomControl, bool IsStockProduct)
        {
            _IsStockProduct = IsStockProduct;
            _ctl = ctlCustomControl;
            this.ShowDialog();
        }
        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    int nCount = 0;
                    dt.Columns.Add("ID");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Category");
                    dt.Columns.Add("Company");
                    dt.Columns.Add("Color");
                    dt.Columns.Add("IMEI");

                    this.Text = "Product List";

                    var BarcodeStockDetails = (from std in db.StockDetails.Where(i => i.Status == (int)EnumStockDetailStatus.Stock)
                                               join p in db.Products on std.ProductID equals p.ProductID
                                               where p.ProductType != (int)EnumProductType.NoBarCode
                                               select std).ToList();

                    var NobarcodeStockDetails = from std in db.StockDetails.Where(i => i.Status == (int)EnumStockDetailStatus.Stock)
                                                join p in db.Products on std.ProductID equals p.ProductID
                                                where p.ProductType == (int)EnumProductType.NoBarCode
                                                select std;

                    var NobarcodeSD = NobarcodeStockDetails.GroupBy(item => new { item.ProductID, item.ColorID })
                                             .Select(g => g.OrderByDescending(c => c.SDetailID).FirstOrDefault())
                                             .ToList();

                    BarcodeStockDetails.AddRange(NobarcodeSD);

                    var fstockDetails = BarcodeStockDetails.OrderBy(i => i.StockCode);

                    if (fstockDetails != null)
                    {
                        var StockDetails = from sd in fstockDetails
                                           join p in db.Products on sd.ProductID equals p.ProductID
                                           join col in db.Colors on sd.ColorID equals col.ColorID
                                           join cat in db.Categorys on p.CategoryID equals cat.CategoryID
                                           join com in db.Companies on p.CompanyID equals com.CompanyID
                                           select new
                                           {
                                               sd.SDetailID,
                                               sd.IMENO,
                                               p.ProductName,
                                               CategoryName = cat.Description,
                                               CompanyName = com.Description,
                                               ColorName = col.Description,
                                           };

                        foreach (var item in StockDetails)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = item.SDetailID;
                            dr["Name"] = item.ProductName;
                            dr["Category"] = item.CategoryName;
                            dr["Company"] = item.CompanyName;
                            dr["Color"] = item.ColorName;
                            dr["IMEI"] = item.IMENO;
                            dt.Rows.Add(dr);
                            nCount++;
                        }

                        grdItems.DataSource = dt;
                        lblTotal.Text = "Total :" + nCount.ToString();

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
        private void lsvProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private void grdItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdItems.MainView).GetSelectedRows();
                DataRowView oStockID = (DataRowView)(((GridView)grdItems.MainView).GetRow(selRows[0]));

                int nStockID = Convert.ToInt32(oStockID["ID"]);
                StockDetail oStockDetail = db.StockDetails.FirstOrDefault(p => p.SDetailID == nStockID);

                if (oStockDetail != null)
                {
                    _ctl.SelectedID = oStockDetail.SDetailID;
                    _ctl.Code = oStockDetail.Product.ProductName;
                    _ctl.Name = oStockDetail.IMENO;
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
