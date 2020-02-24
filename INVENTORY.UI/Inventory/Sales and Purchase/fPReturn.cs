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

namespace INVENTORY.UI
{

    public partial class fPReturn : Form
    {
        public Action ItemChanged;
        Return _Return = null;
        ReturnDetail _ReturnDetail = null;
        Stock _StockControl = null;
        StockDetail _StockDetailControl = null;

        List<ReturnDetail> _ReturnDetails = null;
        List<ReturnDetail> _RemoveReturnDetail = null;
        DEWSRMEntities db = null;
        Stock _TranStock = null;
        StockDetail _TranStockDetail = null;
        Supplier _oSupplier = null;

        decimal _currentCredit = 0;
        public int _SupplierID;

        List<INVENTORY.DA.Color> _ColorList = null;
        List<Product> _oProList = null;
        List<StockDetail> _oStockDetailList = null;

        public fPReturn()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void fPReturn_Load(object sender, EventArgs e)
        {
            _ColorList = db.Colors.ToList();
            _oProList = db.Products.ToList();
            _oStockDetailList = db.StockDetails.ToList();

            txtInvoice.Text = GenerateInvoiceNo();
        }
        private void PopulateGodownCbo()
        {
        }

        bool IsAddToOrderValid()
        {

            if (numQTY.Value > numSalesQty.Value)
            {
                MessageBox.Show("Return quantity can not be greater than purchase quantity !", "Product Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numQTY.Focus();
                return false;
            }
            if (_ReturnDetails.Any(o => o.ProductID == _StockControl.ProductID && o.SDetailID == _StockDetailControl.SDetailID))
            {
                MessageBox.Show("You have already selected this item", "Product Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlProduct.Focus();
                return false;
            }

            if (ctlSupplier.SelectedID == 0)
            {
                MessageBox.Show("Select Supplier Name.", "Supplier Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlSupplier.Focus();
                return false;
            }

            if (ctlProduct.SelectedID == 0)
            {
                MessageBox.Show("Select Product Name.", "Product Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlProduct.Focus();
                return false;
            }

            if (numQTY.Value <= 0)
            {
                MessageBox.Show("Please enter product quantity.", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numQTY.Focus();
                return false;
            }

            if (numUnitPrice.Value <= 0)
            {
                MessageBox.Show("Please enter Unit Price.", "Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numUnitPrice.Focus();
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (!IsAddToOrderValid()) return;

                var oProduct = db.Products.FirstOrDefault(i => i.ProductID == _StockControl.ProductID);

                if (oProduct.ProductType == (int)EnumProductType.BarCode || oProduct.ProductType == (int)EnumProductType.SerialNo)
                {
                    _Return.GrandTotal = (decimal)(numGrundTotal.Value + numUTotal.Value);
                    numGrundTotal.Value = (decimal)_Return.GrandTotal;
                    numTotal.Value = (decimal)_Return.GrandTotal;
                    numTotalDueAmt.Value = numTotal.Value - numPaid.Value;
                    #region Return Details
                    _ReturnDetail = new ReturnDetail();
                    _ReturnDetail.ProductID = _StockControl.ProductID;//Item
                    _ReturnDetail.UnitPrice = (decimal)numUnitPrice.Value;
                    _ReturnDetail.Quantity = (decimal)numQTY.Value;
                    _ReturnDetail.UTAmount = (decimal)numUTotal.Value;
                    _ReturnDetail.SDetailID = _StockDetailControl.SDetailID;
                    _ReturnDetails.Add(_ReturnDetail);
                    #endregion
                }
                else
                {
                    var SuppProductsales = (from so in db.POrders
                                            join sod in db.POrderDetails on so.POrderID equals sod.POrderID
                                            join std in db.StockDetails on sod.POrderDetailID equals std.POrderDetailID
                                            where so.SupplierID == ctlSupplier.SelectedID && so.Status == (int)EnumSalesType.Sales
                                            && std.StockID == _StockControl.StockID
                                            select new
                                            {

                                                std.SDetailID,
                                                so.POrderID,
                                                so.OrderDate,
                                                SalesPrice = sod.UnitPrice - sod.PPDISAmt,
                                                std.Quantity,
                                                sod.ProductID,
                                                sod.POrderDetailID
                                            }).OrderBy(o => o.SDetailID).ToList();

                    decimal returnQty = numQTY.Value, UTotalAmt = 0;

                    foreach (var item in SuppProductsales)
                    {
                        _ReturnDetail = new ReturnDetail();
                        _ReturnDetail.ProductID = _StockControl.ProductID;//Item

                        if (item.Quantity == returnQty)
                        {
                            _ReturnDetail.Quantity = returnQty;
                            _ReturnDetail.UTAmount = numUnitPrice.Value * returnQty;//item.SalesPrice * returnQty;
                            _ReturnDetail.UnitPrice = numUnitPrice.Value;//item.SalesPrice;
                            _ReturnDetail.SDetailID = item.SDetailID;   // _StockControl.StockDetails.FirstOrDefault(i => i.POrderDetailID == item.POrderDetailID).SDetailID;//item.StockDetailID;
                            _ReturnDetails.Add(_ReturnDetail);
                            UTotalAmt += (decimal)_ReturnDetail.UTAmount;
                            break;
                        }
                        else if (item.Quantity > returnQty)
                        {
                            _ReturnDetail.Quantity = returnQty;

                            _ReturnDetail.Quantity = returnQty;
                            _ReturnDetail.UTAmount = numUnitPrice.Value * returnQty;//item.SalesPrice * returnQty;
                            _ReturnDetail.UnitPrice = numUnitPrice.Value;//item.SalesPrice;
                            _ReturnDetail.SDetailID = item.SDetailID;   //  _StockControl.StockDetails.FirstOrDefault(i => i.POrderDetailID == item.POrderDetailID).SDetailID;//item.StockDetailID;

                            _ReturnDetails.Add(_ReturnDetail);
                            UTotalAmt += (decimal)_ReturnDetail.UTAmount;

                            break;
                        }
                        else if (item.Quantity < returnQty)
                        {

                            _ReturnDetail.Quantity = item.Quantity;
                            _ReturnDetail.UTAmount = numUnitPrice.Value * item.Quantity;//item.SalesPrice * item.Quantity;
                            _ReturnDetail.UnitPrice = numUnitPrice.Value;//item.SalesPrice;
                            _ReturnDetail.SDetailID = item.SDetailID;   // _StockControl.StockDetails.FirstOrDefault(i => i.POrderDetailID == item.POrderDetailID).SDetailID;//item.StockDetailID;
                            returnQty = returnQty - item.Quantity;
                            _ReturnDetails.Add(_ReturnDetail);

                            UTotalAmt += (decimal)_ReturnDetail.UTAmount;
                        }
                    }

                    _Return.GrandTotal = (decimal)(numGrundTotal.Value + UTotalAmt);
                    numGrundTotal.Value = (decimal)_Return.GrandTotal;
                    numTotal.Value = (decimal)_Return.GrandTotal;
                    //numPaid.Value = (decimal)_Return.GrandTotal;
                    numTotalDueAmt.Value = numTotal.Value - numPaid.Value;
                }

                RefreshGrid();
                RefreshControl();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void RefreshGrid()
        {
            try
            {

                int count = 0;
                int nSLNo = 1;
                dgProducts.Rows.Clear();
                if (_ReturnDetails.Count != 0)
                {
                    var RDData = (from rd in _ReturnDetails
                                  join std in _oStockDetailList on rd.SDetailID equals std.SDetailID
                                  group rd by new { rd.ProductID, std.ColorID } into g
                                  select new VMReturnDetail
                                  {
                                      ProductID = g.Key.ProductID,
                                      ColorID = g.Key.ColorID,
                                      Quantity = g.Sum(o => o.Quantity),
                                      UnitPrice = g.Select(o => o.UnitPrice).FirstOrDefault(),
                                      UTAmount = g.Sum(o => o.UTAmount)
                                  });

                    if (RDData.Count() > 0)
                    {
                        foreach (var oPODItem in RDData)
                        {
                            dgProducts.Rows.Add();
                            Product oProduct = _oProList.FirstOrDefault(o => o.ProductID == oPODItem.ProductID);
                            // StockDetail oSDetail = _oStockDetailList.FirstOrDefault(sd => sd.SDetailID == oPODItem.SDetailID);
                            INVENTORY.DA.Color oColor = _ColorList.FirstOrDefault(c => c.ColorID == oPODItem.ColorID);
                            dgProducts.Rows[count].Cells[0].Value = nSLNo.ToString();
                            dgProducts.Rows[count].Cells[1].Value = oProduct.ProductName;
                            dgProducts.Rows[count].Cells[2].Value = oProduct.Company.Description;
                            dgProducts.Rows[count].Cells[3].Value = oProduct.Category.Description;
                            dgProducts.Rows[count].Cells[4].Value = oColor.Description;
                            dgProducts.Rows[count].Cells[5].Value = oPODItem.Quantity.ToString();
                            dgProducts.Rows[count].Cells[6].Value = oPODItem.UnitPrice.ToString();
                            dgProducts.Rows[count].Cells[7].Value = oPODItem.UTAmount.ToString();
                            dgProducts.Rows[count].Tag = oPODItem;
                            count++;
                            nSLNo++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshControl()
        {
            numQTY.Value = 0;
            numUTotal.Value = 0;
            numUnitPrice.Value = 0;
            numStock.Value = 0;
            ctlProduct.SelectedID = 0;
            numSalesQty.Value = 0;
            txtIMEI.TextChanged -= txtIMEI_TextChanged;
            txtIMEI.Text = string.Empty;
            txtIMEI.TextChanged += txtIMEI_TextChanged;
        }
        private void RefreshValue()
        {
            txtInvoice.Text = _Return.InvoiceNo != null ? _Return.InvoiceNo : "";
            dtpDate.Value = _Return.ReturnDate != DateTime.MinValue ? _Return.ReturnDate : DateTime.Now;
            numGrundTotal.Value = _Return.GrandTotal != null ? Convert.ToDecimal(_Return.GrandTotal) : 0;
            ctlSupplier.SelectedID = _Return.SupplierID != null ? (int)_Return.SupplierID : 0;//_Return.CustomerID >0  ? (int)_Return.CustomerID : 0;
            numTotal.Value = _Return.GrandTotal != null ? Convert.ToDecimal(_Return.GrandTotal) : 0;
            numPaid.Value = _Return.PaidAmount != null ? Convert.ToDecimal(_Return.PaidAmount) : 0;
            // numTotalDueAmt.Value = numTotal.Value - numPaid.Value;

        }

        private void RefreshObject()
        {
            _Return.InvoiceNo = txtInvoice.Text;
            _Return.ReturnDate = dtpDate.Value;
            _Return.GrandTotal = numGrundTotal.Value;
            //_Return.CustomerID = 0;
            _Return.PaidAmount = numPaid.Value;

            _Return.SupplierID = ctlSupplier.SelectedID;

        }

        private void ctlProduct_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //List<Godown> oGodownList = db.Godowns.ToList();
                //Godown oGD = oGodownList.FirstOrDefault(o => o.GodownName == ctlProduct.GodownName);

                _StockDetailControl = (StockDetail)(db.StockDetails.FirstOrDefault(o => o.SDetailID == ctlProduct.SelectedID));
                if (_StockDetailControl != null)
                {
                    var oProduct = db.Products.FirstOrDefault(i => i.ProductID == _StockDetailControl.ProductID);
                    _StockControl = db.Stocks.FirstOrDefault(o => o.StockID == _StockDetailControl.StockID);

                    if (oProduct.ProductType == (int)EnumProductType.NoBarCode)
                    {
                        var Totalrturns = (from so in db.Returns
                                           join sod in db.ReturnDetails on so.ReturnID equals sod.ReturnID
                                           join sd in db.StockDetails on sod.SDetailID equals sd.SDetailID
                                           where (so.SupplierID == ctlSupplier.SelectedID && sod.ProductID == _StockControl.ProductID && sd.ColorID == _StockControl.ColorID)
                                           select new
                                           {
                                               so.ReturnDate,
                                               sod.Quantity,
                                               sod.UnitPrice
                                           }).OrderByDescending(x => x.ReturnDate).ToList();

                        var TotalPurchases = (from po in db.POrders
                                              join pod in db.POrderDetails on po.POrderID equals pod.POrderID
                                              where (po.SupplierID == ctlSupplier.SelectedID && pod.ProductID == _StockControl.ProductID && po.Status == (int)EnumPurchaseType.Purchase && pod.ColorID == _StockDetailControl.ColorID)
                                              select new
                                              {
                                                  po.OrderDate,
                                                  pod.Quantity,
                                                  UnitPrice = (pod.UnitPrice + ((po.LaborCost - po.TDiscount) / (po.GrandTotal - po.NetDiscount + po.TDiscount)) * pod.UnitPrice)
                                              }).OrderByDescending(x => x.OrderDate).ToList();

                        var lastsale = TotalPurchases.FirstOrDefault();

                        decimal uPrice = lastsale != null ? Convert.ToDecimal(lastsale.UnitPrice) : 0m;

                        if (_StockControl != null)
                        {
                            numSalesQty.Value = 0;
                            numStock.Value = 0;
                            numQTY.Value = 0;

                            numStock.Value = _StockControl.Quantity;//_StockDetailControl.Quantity != null ? (decimal)_StockDetailControl.Quantity : 0m;
                            numUnitPrice.Value = uPrice;//_StockControl.PMPrice != null ? (decimal)_StockControl.PMPrice : 0;
                            INVENTORY.DA.Color oColor = _ColorList.FirstOrDefault(o => o.ColorID == _StockDetailControl.ColorID);

                            decimal saleqty = 0;
                            decimal returnqty = 0;
                            if (TotalPurchases.Count > 0)
                            {
                                saleqty = (decimal)TotalPurchases.Sum(x => x.Quantity);
                            }
                            if (Totalrturns.Count > 0)
                            {
                                returnqty = (decimal)Totalrturns.Sum(x => x.Quantity);
                            }
                            numSalesQty.Value = saleqty - returnqty;
                            numQTY.Focus();
                            numUnitPrice.Enabled = true;
                            numQTY.Enabled = true;

                        }
                    }
                    else
                    {
                        if (_StockControl != null)
                        {
                            var TotalPOrders = (from po in db.POrders
                                                join pod in db.POrderDetails on po.POrderID equals pod.POrderID
                                                where (po.SupplierID == ctlSupplier.SelectedID && pod.ProductID == _StockControl.ProductID && po.Status == (int)EnumSalesType.Sales && pod.ColorID == _StockDetailControl.ColorID)
                                                select new
                                                {
                                                    po.OrderDate,
                                                    pod.Quantity,
                                                    SalesPrice = (pod.UnitPrice + ((po.LaborCost - po.TDiscount) / (po.GrandTotal - po.NetDiscount + po.TDiscount)) * pod.UnitPrice)
                                                }).OrderByDescending(x => x.OrderDate).ToList();
                            var lastSOD = TotalPOrders.FirstOrDefault();
                            numSalesQty.Value = lastSOD.Quantity;
                            numStock.Value = 0;
                            numQTY.Value = 1;
                            numStock.Value = _StockControl.Quantity != null ? (decimal)_StockControl.Quantity : 0m;

                            numUnitPrice.Value = lastSOD != null ? lastSOD.SalesPrice : 0m;
                            numUnitPrice.Enabled = false;
                            numQTY.Enabled = false;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Save Return
                if (_Return.ReturnID <= 0)
                {
                    RefreshObject();
                    #region Return Orders

                    _Return.ReturnID = db.Returns.Count() > 0 ? db.Returns.Max(obj => obj.ReturnID) + 1 : 1;
                    _Return.CreatedBy = Global.CurrentUser.UserID;
                    _Return.CreatedDate = DateTime.Now;
                    int detailid = db.ReturnDetails.Count() > 0 ? db.ReturnDetails.Max(obj => obj.ReturnDetailsID) + 1 : 1;
                    var ProductList = db.Products.ToList();

                    foreach (ReturnDetail item in _ReturnDetails)
                    {
                        item.ReturnDetailsID = detailid;
                        item.ReturnID = _Return.ReturnID;
                        db.ReturnDetails.Add(item);
                        detailid++;
                    }
                    db.Returns.Add(_Return);

                    #endregion

                    #region Stock Updates
                    foreach (ReturnDetail item in _ReturnDetails)
                    {
                        _TranStock = null;
                        _TranStockDetail = null;
                        _TranStockDetail = db.StockDetails.FirstOrDefault(o => o.SDetailID == item.SDetailID);
                        _TranStock = db.Stocks.FirstOrDefault(o => o.ProductID == item.ProductID && o.ColorID == _TranStockDetail.ColorID);

                        var oProduct = ProductList.FirstOrDefault(i => i.ProductID == item.ProductID);
                        if (oProduct.ProductType == (int)EnumProductType.NoBarCode)
                        {
                            _TranStockDetail.Quantity -= (decimal)item.Quantity;
                            if (_TranStockDetail.Quantity == 0)
                                _TranStockDetail.Status = (int)EnumStockDetailStatus.Sold;
                        }
                        else
                        {
                            _TranStockDetail.Status = (int)EnumStockDetailStatus.Sold;
                        }

                        _TranStock.Quantity = _TranStock.Quantity - (decimal)item.Quantity;
                        _TranStock.EntryDate = DateTime.Today;
                    #endregion

                        #region Update Supplier Due Amount

                        _oSupplier = (Supplier)(db.Suppliers.FirstOrDefault(o => o.SupplierID == _Return.SupplierID));
                        _oSupplier.TotalDue = numPrevDue.Value - numTotalDueAmt.Value;

                        #endregion

                        //_oCustomer = (Customer)(db.Customers.FirstOrDefault(o => o.CustomerID == _Return.CustomerID));
                        //_oCustomer.TotalDue = numPrevDue.Value - (numTotalDueAmt.Value);
                    }
                }
                else //Update
                {
                    int detailid = db.ReturnDetails.Count() > 0 ? db.ReturnDetails.Max(obj => obj.ReturnDetailsID) + 1 : 1;
                    RefreshObject();

                    _Return.ModifiedBy = (int)Global.CurrentUser.UserID;
                    _Return.ModifiedDate = (DateTime)DateTime.Today;

                    if (_RemoveReturnDetail != null)
                    {
                        foreach (ReturnDetail item in _RemoveReturnDetail)
                        {
                            //_TranStock = db.Stocks.FirstOrDefault(o => o.ProductID == item.ProductID && o.GodownID == item.GodownID);
                            _TranStockDetail = db.StockDetails.FirstOrDefault(o => o.ProductID == item.ProductID && o.SDetailID == item.SDetailID);
                            _TranStock = db.Stocks.FirstOrDefault(o => o.ProductID == item.ProductID && o.ColorID == _TranStockDetail.ColorID);
                            _TranStock.Quantity = _TranStock.Quantity + (decimal)item.Quantity;
                            _TranStock.EntryDate = DateTime.Today;
                            _TranStockDetail.Quantity = _TranStockDetail.Quantity + item.Quantity;
                            #region Update Supplier Due Amount

                            _oSupplier = (Supplier)(db.Suppliers.FirstOrDefault(o => o.SupplierID == _Return.SupplierID));
                            _oSupplier.TotalDue = numPrevDue.Value + _currentCredit - numTotalDueAmt.Value;

                            #endregion

                            //_oCustomer = (Customer)(db.Customers.FirstOrDefault(o => o.CustomerID == _Return.CustomerID));
                            //_oCustomer.TotalDue = numPrevDue.Value + _currentCredit - numTotalDueAmt.Value;

                            db.SaveChanges();
                            db.ReturnDetails.Remove(item);
                        }
                    }

                    foreach (ReturnDetail item in _ReturnDetails)
                    {
                        if (item.ReturnDetailsID <= 0)
                        {
                            item.ReturnDetailsID = detailid;
                            item.ReturnID = _Return.ReturnID;
                            db.ReturnDetails.Add(item);
                            detailid++;
                        }
                    }

                }

                RefreshObject();
                db.SaveChanges();
                MessageBox.Show("Returned successfully.", "Return Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion
                GenerateReturnInvoice(_Return);
                ItemChanged();
                numPrevDue.Value = 0;
                numTotalDueAmt.Value = 0;

                _Return = new Return();
                _ReturnDetails = new List<ReturnDetail>();
                RefreshValue();
                RefreshControl();
                RefreshGrid();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            //RefreshStock();
            //RefreshCustomerDue();
            //RefreshSupplierDue();

        }
        private void RefreshStock()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    using (var connection = db.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_StockCorrection";
                        command.ExecuteReader();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshCustomerDue()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    using (var connection = db.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_CustomerDueCorrection";
                        command.ExecuteReader();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshSupplierDue()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    using (var connection = db.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_SupplierDueCorrection";
                        command.ExecuteReader();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GenerateReturnInvoice(Return _Return)
        {
            if (_Return != null)
            {
                DataTable orderdDT = new DataTable();
                rptDataSet.dtInvoice1DataTable dt = new rptDataSet.dtInvoice1DataTable();
                Supplier oSupplier = _Return.Supplier;
                DataSet ds = new DataSet();
                db = new DEWSRMEntities();
                if (_Return.ReturnDetails.Count != 0)
                {
                    var RDData = (from rd in _Return.ReturnDetails
                                  join std in db.StockDetails on rd.SDetailID equals std.SDetailID
                                  join p in db.Products on std.ProductID equals p.ProductID
                                  join com in db.Companies on p.CompanyID equals com.CompanyID
                                  join cat in db.Categorys on p.CategoryID equals cat.CategoryID
                                  join col in db.Colors on std.ColorID equals col.ColorID
                                  group rd by new { rd.ProductID, p.ProductName, std.ColorID, col.Description, com.CompanyID, Comapny = com.Description, cat.CategoryID, category = cat.Description } into g
                                  select new
                                  {
                                      g.Key.ProductID,
                                      ProductName = g.Key.ProductName,
                                      ColorName = g.Key.Description,
                                      CompanyName = g.Key.Comapny,
                                      CategoryName = g.Key.category,
                                      g.Key.ColorID,
                                      Quantity = g.Sum(o => o.Quantity),
                                      UnitPrice = g.Select(o => o.UnitPrice).FirstOrDefault(),
                                      UTAmount = g.Sum(o => o.UTAmount)
                                  });



                    foreach (var item in RDData)
                    {
                        dt.Rows.Add(item.ProductName, item.CompanyName, item.CategoryName, item.ColorName, item.Quantity, "Pcs", item.UnitPrice, " 0 %", item.UTAmount, 0, 0);
                    }
                }
                orderdDT = dt.AsEnumerable().OrderBy(o => (String)o["ProductName"]).CopyToDataTable();

                dt.TableName = "rptDataSet_dtInvoice";
                ds.Tables.Add(dt);
                string embededResource = "INVENTORY.UI.RDLC.AMReturnInvoice.rdlc";
                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                string sInwodTk = Global.TakaFormat(Convert.ToDouble(_Return.GrandTotal));


                rParam = new ReportParameter("GTotal", _Return.GrandTotal.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Paid", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("CurrDue", oSupplier.TotalDue.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("TDiscount", _Return.PaidAmount.ToString());//oOrder.TDAmount.ToString()
                parameters.Add(rParam);

                rParam = new ReportParameter("Total", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("PreDue", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("TotalDue", oSupplier.TotalDue.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("InvoiceNo", _Return.InvoiceNo);
                parameters.Add(rParam);

                rParam = new ReportParameter("InvoiceDate", _Return.ReturnDate.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Company", oSupplier.OwnerName);
                parameters.Add(rParam);

                rParam = new ReportParameter("CAddress", oSupplier.Address);
                parameters.Add(rParam);

                rParam = new ReportParameter("Name", oSupplier.Name);
                parameters.Add(rParam);

                rParam = new ReportParameter("MobileNo", oSupplier.ContactNo);
                parameters.Add(rParam);

                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);

                rParam = new ReportParameter("LaborCost", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("JobNumber", "");
                parameters.Add(rParam);

                rParam = new ReportParameter("LessAmt", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                //rParam = new ReportParameter("Logo1", Application.StartupPath + @"\Logo1.bmp");
                //parameters.Add(rParam);

                rParam = new ReportParameter("InWordTK", sInwodTk);
                parameters.Add(rParam);

                fReportViewer frm = new fReportViewer();
                frm.CommonReportViewer(embededResource, ds, parameters, true);
            }
        }
        private string GenerateInvoiceNo()
        {
            int i = 0;
            i = db.Returns.Count();
            if (_Return.ReturnID <= 0)
            {
                return "RTN-000" + (i + 1);
            }
            else
            {
                return _Return.InvoiceNo;
            }

        }

        public void ShowDlg(Return oRetrun)
        {
            _Return = db.Returns.FirstOrDefault(o => o.ReturnID == oRetrun.ReturnID);
            if (_Return == null)
            {
                _Return = new Return();
                _ReturnDetails = new List<ReturnDetail>();
            }
            else
            {
                _currentCredit = (decimal)_Return.GrandTotal - (decimal)_Return.PaidAmount;
                _ReturnDetails = _Return.ReturnDetails.ToList();
            }
            RefreshValue();
            RefreshGrid();
            PopulateGodownCbo();
            this.ShowDialog();
        }
        int GetSupplierID()
        {
            return _SupplierID;
        }

        private void numUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            numUTotal.Value = numQTY.Value * numUnitPrice.Value;

        }
        private void numQTY_ValueChanged(object sender, EventArgs e)
        {
            if (numQTY.Value != 0)
            {
                numUTotal.Value = numQTY.Value * numUnitPrice.Value;
                numStock.Value = (_StockControl != null ? (decimal)_StockControl.Quantity : 0) - numQTY.Value;
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProducts.SelectedRows.Count > 0)
                {
                    var oReturnD = dgProducts.SelectedRows[0].Tag as VMReturnDetail;
                    //numGrundTotal.Value = numGrundTotal.Value + (decimal)oReturnDetail.UTAmount;

                    var Row = dgProducts.SelectedRows[0];
                    var oReturnDetails = (from rd in _ReturnDetails
                                          join sd in db.StockDetails on rd.SDetailID equals sd.SDetailID
                                          where rd.ProductID == oReturnD.ProductID && sd.ColorID == oReturnD.ColorID
                                          select rd).ToList();
                    if (oReturnD.ReturnDetailsID > 0)
                    {
                        if (_RemoveReturnDetail == null)
                            _RemoveReturnDetail = new List<ReturnDetail>();
                        foreach (var item in oReturnDetails)
                        {
                            _RemoveReturnDetail.Add(item);
                            _ReturnDetails.Remove(item);
                        }

                    }
                    else
                    {
                        foreach (var item in oReturnDetails)
                        {
                            _ReturnDetails.Remove(item);
                        }
                    }
                    _Return.GrandTotal = (decimal)(numGrundTotal.Value - oReturnDetails.Sum(i => i.UTAmount));
                    numGrundTotal.Value = (decimal)_Return.GrandTotal;
                    numTotal.Value = (decimal)_Return.GrandTotal;
                    // RefreshValue();
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("select an item to remove", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private int Remove_after_Edit()
        {
            return 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void numPaid_ValueChanged(object sender, EventArgs e)
        {
            numTotalDueAmt.Value = numTotal.Value - numPaid.Value;
        }

        private void numQTY_Enter(object sender, EventArgs e)
        {
            numQTY.Select(0, numQTY.Text.Length);
        }

        private void numUnitPrice_Enter(object sender, EventArgs e)
        {
            numUnitPrice.Select(0, numUnitPrice.Text.Length);
        }

        private void numPaid_Enter(object sender, EventArgs e)
        {
            numPaid.Select(0, numPaid.Text.Length);
        }

        private void numTotal_ValueChanged(object sender, EventArgs e)
        {
            numTotalDueAmt.Value = numTotal.Value - numPaid.Value;
        }

        private void txtIMEI_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIMEI.Text))
            {
                if (ctlSupplier.SelectedID != 0)
                {
                    var SalesStockDetail = db.StockDetails.FirstOrDefault(i => i.IMENO.Trim().Equals(txtIMEI.Text.Trim()) && i.Status == (int)EnumStockDetailStatus.Sold);

                    if (SalesStockDetail != null)
                    {

                        var customersalesIMEI = (from so in db.SOrders
                                                 join sod in db.SOrderDetails on so.SOrderID equals sod.SOrderID
                                                 where so.CustomerID == ctlSupplier.SelectedID && so.Status == (int)EnumSalesType.Sales && sod.StockDetailID == SalesStockDetail.SDetailID
                                                 select sod).ToList();
                        if (customersalesIMEI.Count() != 0)
                        {
                            ctlProduct.SelectedID = SalesStockDetail.SDetailID;
                        }
                        else
                        {
                            MessageBox.Show(txtIMEI.Text + " is not sold to this customer.", "IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIMEI.Text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show(txtIMEI.Text + " is not found.", "IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIMEI.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Please select customer", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIMEI.Text = string.Empty;
                }
            }

        }

        private void ctlSupplier_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (ctlSupplier.SelectedID != 0)
                {
                    _oSupplier = (Supplier)(db.Suppliers.FirstOrDefault(o => o.SupplierID == ctlSupplier.SelectedID));
                    _SupplierID = ctlSupplier.SelectedID;

                    if (_oSupplier != null)
                    {
                        numPrevDue.Value = _oSupplier.TotalDue;
                        if (_Return.InvoiceNo != null)
                        {
                            if (_Return.InvoiceNo.Length < 4)
                            {
                                txtInvoice.Text = GenerateInvoiceNo();
                            }
                        }
                        else
                        {
                            txtInvoice.Text = GenerateInvoiceNo();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

