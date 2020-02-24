using INVENTORY.DA;
using Microsoft.Reporting.WinForms;
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


namespace INVENTORY.UI
{
    public partial class fSOrders : Form
    {
        List<SOrder> _OrderList = null;
        List<Stock> _StockList = null;
        SOrder _Order = null;
        Customer _Customer = null;
        DEWSRMEntities db = null;
        Stock _Stock = null;

        List<Company> _CompanyList = null;
        List<Category> _CategoryList = null;
        List<INVENTORY.DA.Color> _ColorList = null;
        List<Product> _ProductList = null;

        private void fOrders_Load(object sender, EventArgs e)
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
                btnReturn.Enabled = false;
            }

        }

        public fSOrders()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void RefreshList()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add("OrderID");
                dt.Columns.Add("OrderDate");
                dt.Columns.Add("InvoiceNo");
                dt.Columns.Add("Customer");
                dt.Columns.Add("ContactNo");
                dt.Columns.Add("Address");
                dt.Columns.Add("TotalAmt");
                dt.Columns.Add("RecAmt");
                dt.Columns.Add("DueAmt");
                dt.Columns.Add("Status");

                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Orders = db.SOrders.OrderByDescending(so => so.InvoiceDate).Where(o => o.Status == 1);

                    if (_Orders != null)
                    {
                        List<Customer> oCustomers = db.Customers.ToList();

                        foreach (SOrder order in _Orders)
                        {
                            dr = dt.NewRow();

                            dr["OrderID"] = order.SOrderID;
                            dr["OrderDate"] = Convert.ToDateTime(order.InvoiceDate).ToString("dd MMM yyyy");
                            dr["InvoiceNo"] = order.InvoiceNo;
                            dr["RecAmt"] = order.RecAmount;

                            if (oCustomers != null)
                            {
                                Customer oCustomer = oCustomers.FirstOrDefault(o => o.CustomerID == order.CustomerID);
                                if (oCustomer != null)
                                {
                                    dr["customer"] = order.Customer.Name;
                                    dr["ContactNo"] = oCustomer.ContactNo;
                                    dr["Address"] = oCustomer.Address;
                                }
                                else
                                {
                                    dr["customer"] = " ";
                                    dr["ContactNo"] = " ";
                                    dr["Address"] = " ";
                                }

                            }
                            dr["TotalAmt"] = order.GrandTotal;
                            dr["DueAmt"] = order.PaymentDue;

                            if (order.Status == (int)EnumSalesType.Sales)
                            {
                                dr["Status"] = "Sales";
                            }
                            else
                            {
                                dr["Status"] = "Return";
                            }
                            dt.Rows.Add(dr);
                        }
                        grdOrders.DataSource = dt;
                        lblTotal.Text = "Total :" + _Orders.Count().ToString();
                    }
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
                    var _Colors = db.Colors;
                    var _Products = db.Products;
                    var _Categorys = db.Categorys;


                    _StockList = _Stocks.ToList();
                    _CompanyList = _Companies.ToList();
                    _ProductList = _Products.ToList();
                    _CategoryList = _Categorys.ToList();
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


                                oDR["StockID"] = oStock.StockID;
                                oDR["StockCode"] = oStock.StockCode;
                                oDR["ProductName"] = oPro.ProductName;
                                oDR["Category"] = oCat.Description;
                                oDR["Company"] = oCom.Description;
                                oDR["Color"] = oColor.Description;
                                oDR["Qty"] = Math.Round((decimal)oStock.Quantity, 0);
                                oDR["PurRate"] = oStock.PMPrice;
                                oDR["TotalPrice"] = Math.Round((decimal)(oStock.Quantity * oStock.PMPrice), 2).ToString();
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

        #region Events

        #region Order Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            fSOrder oFPOrder = new fSOrder();
            oFPOrder.ItemChanged = RefreshList;
            oFPOrder.ShowDlg(new SOrder());
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdOrders.MainView).GetSelectedRows();
                    DataRowView oOrderD = (DataRowView)(((GridView)grdOrders.MainView).GetRow(selRows[0]));
                    DataRowView InvoiceDate = (DataRowView)(((GridView)grdOrders.MainView).GetRow(selRows[0]));
                    DateTime dInvoiceDate = Convert.ToDateTime(InvoiceDate["OrderDate"]);

                    int nOrderID = Convert.ToInt32(oOrderD["OrderID"]);
                    SOrder oOrder = db.SOrders.FirstOrDefault(p => p.SOrderID == nOrderID);

                    if (oOrder == null)
                    {
                        MessageBox.Show("select an item to Edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (Global.CurrentUser.ISEditable == 1)
                    {
                        if (dInvoiceDate < DateTime.Today)
                        {
                            MessageBox.Show("This order can't be editable, Please contact BD Team.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                    }

                    fSOrder frm = new fSOrder();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oOrder);


                }
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
                int[] selRows = ((GridView)grdOrders.MainView).GetSelectedRows();
                DataRowView oOrderID = (DataRowView)((GridView)grdOrders.MainView).GetRow(selRows[0]);
                DataRowView InvoiceDate = (DataRowView)(((GridView)grdOrders.MainView).GetRow(selRows[0]));

                int nOrdersID = Convert.ToInt32(oOrderID["OrderID"]);
                DateTime dInvoiceDate = Convert.ToDateTime(InvoiceDate["OrderDate"]);

            
                if (nOrdersID <= 0)
                {
                    MessageBox.Show("Select an item to Delete order.", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

               

                if (MessageBox.Show("Do you want to Delete this order sure?", "Delete Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nOrdersID > 0)
                    {
                          using (DEWSRMEntities db1 = new DEWSRMEntities())
                        {
                          using (var connection = db1.Database.Connection)
                             {
                                connection.Open();
                                var command = connection.CreateCommand();
                                
                                    command.CommandText = "EXEC DeleteSales  " + "'" + nOrdersID + "'" ;
                                    var reader = command.ExecuteReader();
                          }
                        RefreshList();
                    }
                       

                    
                      //  db.SaveChanges();
                        MessageBox.Show("Order Deleted successfully.", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshList();

                    }

                }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdOrders.MainView).GetSelectedRows();
                DataRowView oOrderID = (DataRowView)((GridView)grdOrders.MainView).GetRow(selRows[0]);
                int nOrdersID = Convert.ToInt32(oOrderID["OrderID"]);

                if (nOrdersID <= 0)
                {
                    MessageBox.Show("Select an item to generate invoice ", "item yet not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (nOrdersID > 0)
                {
                    _Order = db.SOrders.FirstOrDefault(s => s.SOrderID == nOrdersID);
                }
                fSOrder objfSOrder = new fSOrder();
                objfSOrder.GenerateSOInvoice(_Order);
                objfSOrder.MoneyReceipt(_Order);
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Cannot generate invoice due to " + Ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                RefreshList();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                RefreshStock();
            }

        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdOrders.MainView).GetSelectedRows();
                DataRowView oOrderID = (DataRowView)((GridView)grdOrders.MainView).GetRow(selRows[0]);
                DataRowView InvoiceDate = (DataRowView)(((GridView)grdOrders.MainView).GetRow(selRows[0]));

                int nOrdersID = Convert.ToInt32(oOrderID["OrderID"]);
                DateTime dInvoiceDate = Convert.ToDateTime(InvoiceDate["OrderDate"]);

                List<Stock> oStockList = db.Stocks.ToList();
                List<StockDetail> oStockDList = db.StockDetails.ToList();

                if (nOrdersID <= 0)
                {
                    MessageBox.Show("Select an item to cancel order.", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if(Global.CurrentUser.ISEditable==1)
                {
                    if (dInvoiceDate < DateTime.Today)
                    {
                        MessageBox.Show("This order can't be return, Please contact BD Team", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (MessageBox.Show("Do you want to return this order sure?", "Return Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nOrdersID > 0)
                    {
                        _Order = db.SOrders.FirstOrDefault(s => s.SOrderID == nOrdersID);

                        if (_Order.Status == (int)EnumSalesType.Return)
                        {
                            MessageBox.Show("This item already return please select correct item.", "Return Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        #region Update SOrder Data
                        _Order.Status = (int)EnumSalesType.Return;
                        #endregion

                        #region Stock Data
                        Stock oStock = null;
                        StockDetail oStockDetail = null;
                        Product oProduct = null;
                        foreach (SOrderDetail sODetail in _Order.SOrderDetails)
                        {
                            oProduct = db.Products.FirstOrDefault(i => i.ProductID == sODetail.ProductID);
                            oStockDetail = oStockDList.FirstOrDefault(sd => sd.SDetailID == sODetail.StockDetailID);
                            
                            if (oStockDetail != null)
                                oStock = oStockList.FirstOrDefault(o => o.ProductID == sODetail.ProductID && o.StockID==oStockDetail.StockID);

                            oStock.Quantity = oStock.Quantity + sODetail.Quantity;
                            oStockDetail.Status = (int)EnumStockDetailStatus.Stock;
                            if (oProduct.ProductType == (int)EnumProductType.NoBarCode)
                                oStockDetail.Quantity += sODetail.Quantity; 
                        }
                        #endregion

                        #region Update Customer Due Amount

                        Customer oCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == _Order.CustomerID);
                        if (oCustomer != null)
                        {
                            oCustomer.TotalDue = (decimal)(oCustomer.TotalDue - _Order.PaymentDue);
                        }
                        #endregion

                        #region Bank Transactions and Bank Update
                        if (_Order.BankTranID != 0)
                        {
                            FCreditSales bankdepo = new FCreditSales();
                            bankdepo.ReturnBankDepositTransaction(_Order.BankTranID);
                        }
                        #endregion 

                        db.SaveChanges();
                        MessageBox.Show("Order return successfully.", "Return Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshList();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdOrders.MainView).GetSelectedRows();
                DataRowView oOrderID = (DataRowView)((GridView)grdOrders.MainView).GetRow(selRows[0]);
                int nOrdersID = Convert.ToInt32(oOrderID["OrderID"]);

                if (nOrdersID <= 0)
                {
                    MessageBox.Show("Select an item to generate invoice ", "item yet not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (nOrdersID > 0)
                {
                    _Order = db.SOrders.FirstOrDefault(s => s.SOrderID == nOrdersID);
                }

                if (_Order == null)
                {
                    MessageBox.Show("select an item to generate invoice", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PrintInvoice oPriInvoice = new PrintInvoice();
                oPriInvoice.print(_Order);
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Cannot generate invoice due to " + Ex.Message);
            }
        }
    }
}
