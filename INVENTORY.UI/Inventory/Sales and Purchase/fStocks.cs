using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Reporting.WinForms;
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
    public partial class fStocks: Form
    {
        List<POrder> _PrePOrderList = null;
        List<Stock> _StockList = null;
        DEWSRMEntities db = null;

        List<Company> _CompanyList = null;
        List<Category> _CategoryList = null;

        List<INVENTORY.DA.Color> _ColorList = null;
        List<Product> _ProductList = null;
        List<StockDetail> _StockDetailList = null;
         int StockID = 0;
        Stock oSTUpdate = null;

        public fStocks()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshPreOrderList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _PrePOrders = db.POrders.OrderByDescending(po => po.OrderDate).Where(po => po.Status == 1);
                    _PrePOrderList = _PrePOrders.OrderByDescending(po => po.OrderDate).ToList();
                    List<Supplier> oSuppliers = db.Suppliers.ToList();

                    DataTable dtPOrders = new DataTable();
                    DataRow oDRow = null;
                    dtPOrders.Columns.Add("POrderID");
                    dtPOrders.Columns.Add("OrderDate");
                    dtPOrders.Columns.Add("ChallanNo");
                    dtPOrders.Columns.Add("SupplierName");
                    dtPOrders.Columns.Add("CompanyName");
                    dtPOrders.Columns.Add("ContactNo");
                    dtPOrders.Columns.Add("Address");
                    dtPOrders.Columns.Add("NetAmt");
                    dtPOrders.Columns.Add("PaidAmt");
                    dtPOrders.Columns.Add("PaymentDue");
                    dtPOrders.Columns.Add("status");

                    foreach (POrder oPOredr in _PrePOrderList)
                    {
                        oDRow = dtPOrders.NewRow();
                        oDRow["POrderID"] = oPOredr.POrderID;
                        oDRow["OrderDate"] = Convert.ToDateTime(oPOredr.OrderDate).ToString("dd MMM yyyy");
                        oDRow["ChallanNo"] = oPOredr.ChallanNo;

                        oDRow["NetAmt"] = oPOredr.TotalAmt;
                        oDRow["PaidAmt"] = oPOredr.RecAmt;
                        oDRow["PaymentDue"] = oPOredr.PaymentDue;

                        oDRow["Status"] = oPOredr.POrderID;

                        if (oSuppliers != null)
                        {
                            Supplier oSupplier = oSuppliers.FirstOrDefault(o => o.SupplierID == oPOredr.SupplierID);
                            oDRow["SupplierName"] = oSupplier.OwnerName;
                            oDRow["CompanyName"] = oSupplier.Name;
                            oDRow["ContactNo"] = oSupplier.ContactNo;
                            oDRow["Address"] = oSupplier.Address;
                        }

                        if (oPOredr.Status == (int)EnumPurchaseType.Purchase)
                        {
                            oDRow["Status"] = (EnumPurchaseType)oPOredr.Status;
                        }
                        dtPOrders.Rows.Add(oDRow);
                    }
                    grdPOrders.DataSource = dtPOrders;
                    lblTotal.Text = "Total :" + _PrePOrderList.Count().ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshStock()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Stocks = db.Stocks;

                    var _Companies = db.Companies;
                    var _Categories = db.Categorys;
                    var _Colors = db.Colors;
                    var _Products = db.Products;

                    var _StockDetails = db.StockDetails;


                    _StockList = _Stocks.ToList();
                    _CompanyList = _Companies.ToList();
                    _CategoryList = _Categories.ToList();
                    _ProductList = _Products.ToList();
                    _StockDetailList = _StockDetails.ToList();
                    _ColorList = _Colors.ToList();

                    DataTable dt = new DataTable();
                    DataRow oDR = null;

                    dt.Columns.Add("StockID");
                    dt.Columns.Add("StockCode");
                    dt.Columns.Add("ProductName");
                    dt.Columns.Add("Category");
                    dt.Columns.Add("Company");
                    dt.Columns.Add("Color");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("PurRate");
                    dt.Columns.Add("TotalPrice");
                    dt.Columns.Add("MRP");

                    if (_StockList != null)
                    {
                        foreach (Stock oStock in _StockList)
                        {
                            if (oStock.Quantity > 0)
                            {
                                oDR = dt.NewRow();

                                Product oPro = _ProductList.FirstOrDefault(o => o.ProductID == oStock.ProductID);
                                Company oCom = _CompanyList.FirstOrDefault(o => o.CompanyID == oPro.CompanyID);
                                Category oCat = _CategoryList.FirstOrDefault(o => o.CategoryID == oPro.CategoryID);
                                INVENTORY.DA.Color oColor = _ColorList.FirstOrDefault(o => o.ColorID == oStock.ColorID);
                                StockDetail oStockDetail = _StockDetailList.OrderByDescending(o => o.SDetailID).FirstOrDefault(o => o.StockID == oStock.StockID);

                                if(oPro ==null ||oCom==null||oCat==null||oColor==null||oStockDetail==null)
                                {

                                }

                                oDR["StockID"] = oStock.StockID;
                                oDR["StockCode"] = oStock.StockCode;
                                oDR["ProductName"] = oPro.ProductName;
                                oDR["Category"] = oCat.Description;
                                oDR["Company"] = oCom.Description;
                                oDR["Color"] = oColor.Description;

                                oDR["Qty"] = Math.Round((decimal)oStock.Quantity, 0);
                                oDR["PurRate"] = oStock.PMPrice;
                                oDR["TotalPrice"] = Math.Round((decimal)(oStock.Quantity * oStock.PMPrice), 2).ToString();
                                oDR["MRP"] = oStockDetail.SalesRate;
                                dt.Rows.Add(oDR);

                            }
                        }
                        grdStocks.DataSource = dt;
                        lblStockTotal.Text = "Total :" + _StockList.Count.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void fPurchaseOrders_Load(object sender, EventArgs e)
        {
            //RefreshPreOrderList();
            RefreshStock();
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

        private void btnPOrderNew_Click(object sender, EventArgs e)
        {
            fPurchaseOrder frm = new fPurchaseOrder();
            frm.ItemChanged = RefreshPreOrderList;
            frm.ShowDlg(0);

        }

        private void btnPOrderDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //POrder oPrePOrder = new POrder();
                //if (lsvPreOrder.SelectedItems != null && lsvPreOrder.SelectedItems.Count > 0)
                //{
                //    oPrePOrder = (POrder)lsvPreOrder.SelectedItems[0].Tag;
                //    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                //        MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        using (DEWSRMEntities db = new DEWSRMEntities())
                //        {
                //            db.POrders.Remove(oPrePOrder);
                //            db.POrders.Attach(oPrePOrder);
                //            //Save to database
                //            db.SaveChanges();
                //        }
                //        RefreshPreOrderList();
                //    }
                //}

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }

        }

        private void btnPOrderClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tbcPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcPurchaseOrder.SelectedIndex == 0)
            {
                RefreshPreOrderList();
            }
            else if (tbcPurchaseOrder.SelectedIndex == 1)
            {
                RefreshStock();
            }

        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                //if (lsvPreOrder.SelectedItems.Count <= 0)
                //{
                //    MessageBox.Show("Select an item to cancel order.", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //if (MessageBox.Show("Do you want to return this order sure?", "Return Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    using (DEWSRMEntities db = new DEWSRMEntities())
                //    {
                //        POrder oOrder = null;
                //        POrder oPOr =null;

                //        if (lsvPreOrder.SelectedItems != null && lsvPreOrder.SelectedItems.Count > 0)
                //        {
                //            oOrder = (POrder)lsvPreOrder.SelectedItems[0].Tag;
                //            if(oOrder!=null)
                //                oPOr = db.POrders.FirstOrDefault(po=>po.POrderID==oOrder.POrderID);

                //            if (oPOr.Status == (int)EnumPurchaseType.Return)
                //            {
                //                MessageBox.Show("This item already return please select correct item.", "Return Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                return;
                //            }

                //            #region Update SOrder Data
                //            oPOr.Status = (int)EnumPurchaseType.Return;
                //            #endregion

                //            #region Stock Data

                             
                //            foreach (POrderDetail PODetail in oPOr.POrderDetails)
                //            {
                //                decimal PMPrice = 0;
                //                decimal TQty=0;
                //                decimal ReturnQty = 0;
                //                decimal RemainingQty = 0;

                //                Stock oStock  = db.Stocks.FirstOrDefault(o => o.ProductID == PODetail.ProductID);
                //                TQty=(decimal)oStock.Quantity;
                //                oStock.Quantity = oStock.Quantity - PODetail.Quantity;
                //                RemainingQty = (decimal)oStock.Quantity;
                //                ReturnQty = (decimal)PODetail.Quantity;

                //                if(RemainingQty>0)
                //                    PMPrice = (decimal)((TQty * oStock.PMPrice) - (ReturnQty * PODetail.UnitPrice)) / RemainingQty;

                //                oStock.PMPrice = PMPrice;
                //                if (oStock.Quantity==0)
                //                {
                //                    oStock.PMPrice = 0;
                //                    oStock.LPPrice = 0;
                //                }
                //            }
                //            #endregion

                //            #region Update Customer Due Amount

                //            Supplier oSupplier = db.Suppliers.FirstOrDefault(s => s.SupplierID == oPOr.SupplierID);

                //            if (oSupplier != null)
                //            {
                //                oSupplier.TotalDue = (decimal)(oSupplier.TotalDue - oPOr.PaymentDue);
                //            }
                //            #endregion

                //            db.SaveChanges();
                //            MessageBox.Show("Purchase Order return successfully.", "Return Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            RefreshPreOrderList();

                //        }

                //    }

                //}

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
                int[] selRows = ((GridView)grdPOrders.MainView).GetSelectedRows();
                DataRowView oPOrder = (DataRowView)(((GridView)grdPOrders.MainView).GetRow(selRows[0]));
                DataRowView OrderDate = (DataRowView)(((GridView)grdPOrders.MainView).GetRow(selRows[0]));
                DateTime dChallanDate = Convert.ToDateTime(OrderDate["OrderDate"]);

                if (oPOrder == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Global.CurrentUser.ISEditable == 1)
                {
                    if (dChallanDate < DateTime.Today)
                    {
                        MessageBox.Show("This order can't be editable, Please contact BD Team", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                fPurchaseOrder frm = new fPurchaseOrder();
                frm.ItemChanged = RefreshPreOrderList;
                frm.ShowDlg(Convert.ToInt32(oPOrder["POrderID"]));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lsvPreOrder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnStockEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (StockID > 0)
                {
                    if (numCurrPrice.Value > 0)
                    {
                        oSTUpdate.PMPrice = numChangePrice.Value;
                        db.SaveChanges();
                        RefreshStock();
                        MessageBox.Show("Successfully Price Update.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select stock entry for update Purchase Rate.", "Stock Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numCurrPrice_Enter(object sender, EventArgs e)
        {
            numCurrPrice.Select(0, numCurrPrice.Text.Length);

        }

        private void numChangePrice_Enter(object sender, EventArgs e)
        {
            numChangePrice.Select(0, numChangePrice.Text.Length);

        }

        private void grdStocks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdStocks.MainView).GetSelectedRows();
                DataRowView oStockID = (DataRowView)(((GridView)grdStocks.MainView).GetRow(selRows[0]));
                StockID = Convert.ToInt32(oStockID["StockID"]);

                if (StockID > 0)
                {
                    oSTUpdate = db.Stocks.FirstOrDefault(st => st.StockID == StockID);
                    numCurrPrice.Value = (decimal)oSTUpdate.PMPrice;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdPOrders_Click(object sender, EventArgs e)
        {

        }

        private void btnBGen_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdPOrders.MainView).GetSelectedRows();
                DataRowView oPOrderID = (DataRowView)(((GridView)grdPOrders.MainView).GetRow(selRows[0]));
                int nPOrderID = Convert.ToInt32(oPOrderID["POrderID"]);


                if (nPOrderID <= 0)
                {
                    MessageBox.Show("select an item for BC Generate", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                POrder oPOr = null;
                if (nPOrderID > 0)
                {
                    oPOr = db.POrders.FirstOrDefault(po => po.POrderID == nPOrderID);
                }

                PrintInvoice oPInovice = new PrintInvoice();
                if (oPOr != null)
                {
                    oPInovice.PrintBarcode(oPOr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPOInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdPOrders.MainView).GetSelectedRows();
                DataRowView oPOrderID = (DataRowView)(((GridView)grdPOrders.MainView).GetRow(selRows[0]));
                int nPOrderID = Convert.ToInt32(oPOrderID["POrderID"]);


                if (nPOrderID <= 0)
                {
                    MessageBox.Show("select an item for BC Generate", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                POrder oPOr = null;
                if (nPOrderID > 0)
                {
                    oPOr = db.POrders.FirstOrDefault(po => po.POrderID == nPOrderID);
                }

                if (oPOr != null)
                {
                    fPurchaseOrder fPO = new fPurchaseOrder();
                    fPO.PrintPOInvoice(oPOr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }
}
