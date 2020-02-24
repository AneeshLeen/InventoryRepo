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
    public partial class FCreditSales : Form
    {
        List<CreditSale> _CreditSaleList = null;
        List<Product> _ProductList = null;
        List<Customer> _CustomerList = null;
        FCreditSale _oFCreditSale = null;
        DEWSRMEntities db = null;
        public FCreditSales()
        {
            InitializeComponent();
        }
        private void FCreditSales_Load(object sender, EventArgs e)
        {
            db = new DEWSRMEntities();
            RefreshList();
            ControlPermission();
        }

        public void ControlPermission()
        {
            User oUser = Global.CurrentUser;
            if (oUser != null && oUser.UserType == 2)
            {
                btnDelete.Enabled = false;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                CreditSale oCreditSale = new CreditSale();
                _oFCreditSale = new FCreditSale();

                if (_oFCreditSale.ShowDlg(oCreditSale, true, "New"))
                {
                    RefreshList();
                }
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
                using (DEWSRMEntities db = new DEWSRMEntities())
                {


                    int[] selRows = ((GridView)grdCreditSalesCustomers.MainView).GetSelectedRows();
                    DataRowView oCreditSalesCustomerD = (DataRowView)(((GridView)grdCreditSalesCustomers.MainView).GetRow(selRows[0]));

                    int nCreditSalesCustomerID = Convert.ToInt32(oCreditSalesCustomerD["CreditSalesID"]);
                    CreditSale oCreditSalesCustomer = db.CreditSales.FirstOrDefault(p => p.CreditSalesID == nCreditSalesCustomerID);

                    if (oCreditSalesCustomer == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FCreditSale frm = new FCreditSale();
                    frm.ShowDlg(oCreditSalesCustomer, false, "Edit");
                    RefreshList();
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
                CreditSale oCreditSale = new CreditSale();
                _oFCreditSale = new FCreditSale();

                List<Stock> oStockList = db.Stocks.ToList();
                List<StockDetail> oStockDList = db.StockDetails.ToList();

                int[] selRows = ((GridView)grdCreditSalesCustomers.MainView).GetSelectedRows();
                DataRowView oCreditSalesCustomerD = (DataRowView)(((GridView)grdCreditSalesCustomers.MainView).GetRow(selRows[0]));

                int nCreditSalesCustomerID = Convert.ToInt32(oCreditSalesCustomerD["CreditSalesID"]);

                Product oProduct = null;
                Stock oStock = null;
                StockDetail oStockDetail = null;

                if (nCreditSalesCustomerID > 0)
                {
                    oCreditSale = db.CreditSales.FirstOrDefault(p => p.CreditSalesID == nCreditSalesCustomerID);
                    if (oCreditSale != null)
                    {
                        if (MessageBox.Show("Do you want to return the selected item?", "Return Item", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            List<CreditSaleProduct> CSP = db.CreditSaleProducts.Where(cp => cp.CreditSalesID == oCreditSale.CreditSalesID).ToList();

                            foreach (CreditSaleProduct item in CSP)
                            {
                                oProduct = db.Products.FirstOrDefault(i => i.ProductID == item.ProductID);
                                oStockDetail = oStockDList.FirstOrDefault(sd => sd.SDetailID == item.StockDetailID);

                                if (oStockDetail != null)
                                    oStock = oStockList.FirstOrDefault(o => o.ProductID == item.ProductID && o.StockID == oStockDetail.StockID);

                                oStock.Quantity = (decimal)(oStock.Quantity + item.Quantity);
                                oStockDetail.Status = (int)EnumStockDetailStatus.Stock;
                                if (oProduct.ProductType == (int)EnumProductType.NoBarCode)
                                    oStockDetail.Quantity += (decimal)item.Quantity;

                                //Stock oStock = db.Stocks.FirstOrDefault(o => o.ProductID == item.ProductID && o.ColorID == item.ColorInfoID);

                            }

                            List<CreditSalesDetail> CSD = db.CreditSalesDetails.Where(o => o.CreditSalesID == oCreditSale.CreditSalesID).ToList();
                            foreach (CreditSalesDetail oCSD in CSD)
                            {
                                db.CreditSalesDetails.Attach(oCSD);
                                db.CreditSalesDetails.Remove(oCSD);
                            }

                            foreach (CreditSaleProduct oCSP in CSP)
                            {
                                db.CreditSaleProducts.Attach(oCSP);
                                db.CreditSaleProducts.Remove(oCSP);
                            }

                            #region Customer Due Amount Update

                            Customer oCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == oCreditSale.CustomerID);
                            if (oCustomer != null)
                            {
                                oCustomer.CreditDue = (decimal)(oCustomer.CreditDue - oCreditSale.Remaining);
                            }
                            #endregion

                            db.CreditSales.Attach(oCreditSale);
                            db.CreditSales.Remove(oCreditSale);
                            if (oCreditSale.BankTranID != 0)
                                ReturnBankDepositTransaction(oCreditSale.BankTranID);

                            db.SaveChanges();
                            RefreshList();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReturnBankDepositTransaction(int BankTranID)
        {
            if (BankTranID != 0)
            {
                using (var dbC = new DEWSRMEntities())
                {
                    var BankTrans = dbC.BankTransactions.FirstOrDefault(i => i.BankTranID == BankTranID);
                    if (BankTrans != null)
                    {
                        var bank = dbC.Banks.FirstOrDefault(i => i.BankID == BankTrans.BankID);
                        bank.TotalAmount -= BankTrans.Amount;
                        dbC.BankTransactions.Remove(BankTrans);
                        dbC.SaveChanges();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("CreditSalesID");
            dt.Columns.Add("Code");
            dt.Columns.Add("InvoiceNo");
            dt.Columns.Add("SalesDate");
            dt.Columns.Add("Customer");
            dt.Columns.Add("ContactNo");
            dt.Columns.Add("Address");
            dt.Columns.Add("TotalPrice");
            dt.Columns.Add("DPayment");
            dt.Columns.Add("Remaining");
            dt.Columns.Add("Status");


            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    CreditSale oCSales = new CreditSale();
                    var _CreditSales = db.CreditSales.Where(i => i.Status == (int)EnumSalesType.Sales && i.Remaining != 0).OrderByDescending(cs => cs.SalesDate).ToList();

                    Customer oCustomer = new Customer();
                    _CustomerList = db.Customers.ToList();

                    Product oPConfig = new Product();
                    _ProductList = db.Products.ToList();

                    foreach (CreditSale oCSItem in _CreditSales)
                    {
                        oCustomer = _CustomerList.FirstOrDefault(s => s.CustomerID == oCSItem.CustomerID);
                        dr = dt.NewRow();
                        dr["CreditSalesID"] = oCSItem.CreditSalesID;
                        dr["Code"] = oCustomer.Code;
                        dr["InvoiceNo"] = oCSItem.InvoiceNo;
                        dr["SalesDate"] = ((DateTime)oCSItem.SalesDate).ToString("dd MMM yyyy");


                        dr["Customer"] = oCustomer.Name;
                        dr["ContactNo"] = oCustomer.ContactNo;
                        dr["Address"] = oCustomer.Address;

                        //Product oPro = _ProductList.FirstOrDefault(s => s.ProductID == oCSItem.ProductID);
                        //if (oPro != null)
                        //    oItem.SubItems.Add(oPro.ProductName);
                        //else
                        //    oItem.SubItems.Add("");

                        dr["TotalPrice"] = oCSItem.TSalesAmt.ToString();
                        dr["DPayment"] = oCSItem.DownPayment;
                        dr["remaining"] = oCSItem.Remaining;

                        if ((bool)oCSItem.ISUnexpected)
                        {
                            dr["status"] = "Unexpected";
                        }
                        else
                        {
                            dr["status"] = "Normal";
                        }
                        dt.Rows.Add(dr);
                    }
                    grdCreditSalesCustomers.DataSource = dt;
                    lblTotal.Text = "Total :" + _CreditSales.Count().ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnOnlyPaid_Click(object sender, EventArgs e)
        {
            try
            {
                _oFCreditSale = new FCreditSale();
                int[] selRows = ((GridView)grdCreditSalesCustomers.MainView).GetSelectedRows();
                DataRowView oCreditSalesCustomerD = (DataRowView)(((GridView)grdCreditSalesCustomers.MainView).GetRow(selRows[0]));

                int nCreditSalesCustomerID = Convert.ToInt32(oCreditSalesCustomerD["CreditSalesID"]);


                if (nCreditSalesCustomerID > 0)
                {
                    CreditSale oCreditSalesCustomer = db.CreditSales.FirstOrDefault(p => p.CreditSalesID == nCreditSalesCustomerID);
                    if (oCreditSalesCustomer != null)
                    {
                        _oFCreditSale.ShowDlg(oCreditSalesCustomer, false, "OnlyPaid");
                    }
                }
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private void btnPreview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int[] selRows = ((GridView)grdCreditSalesCustomers.MainView).GetSelectedRows();
        //        DataRowView oSalesID = (DataRowView)(((GridView)grdCreditSalesCustomers.MainView).GetRow(selRows[0]));

        //        int nSalesID = Convert.ToInt32(oSalesID["CreditSalesID"]);


        //        if (nSalesID > 0)
        //        {
        //            //CreditSale oCreditSale = (CreditSale)lsvSales.SelectedItems[0].Tag;

        //            CreditSale oCreditSale = db.CreditSales.FirstOrDefault(cs => cs.CreditSalesID == nSalesID);
        //            List<CreditSalesDetail> CSD = oCreditSale.CreditSalesDetails.OrderBy(o => o.ScheduleNo).ToList();
        //            List<CreditSaleProduct> CSP = oCreditSale.CreditSaleProducts.ToList();

        //            //List<CreditSalesDetail> CSD = oCreditSale.CreditSalesDetails.OrderBy(o => o.ScheduleNo).ToList();

        //            if (oCreditSale != null)
        //            {
        //                rptDataSet.CreditSalesInfoDataTable CreditSalesDT = new rptDataSet.CreditSalesInfoDataTable();
        //                DataRow oSDRow = null;
        //                DataSet ds = new DataSet();

        //                foreach (CreditSalesDetail oSItem in CSD)
        //                {
        //                    oSDRow = CreditSalesDT.NewRow();
        //                    oSDRow["ScheduleNo"] = oSItem.ScheduleNo;
        //                    oSDRow["PaymentDate"] = Convert.ToDateTime(oSItem.PaymentDate).ToString("dd MMM yyyy");
        //                    oSDRow["Balance"] = oSItem.Balance;
        //                    oSDRow["InstallmetAmt"] = oSItem.InstallmentAmt;
        //                    oSDRow["ClosingBalance"] = oSItem.ClosingBalance;
        //                    oSDRow["PaymentStatus"] = oSItem.PaymentStatus;
        //                    CreditSalesDT.Rows.Add(oSDRow);
        //                }

        //                CreditSalesDT.TableName = "rptDataSet_CreditSalesInfo";
        //                ds.Tables.Add(CreditSalesDT);

        //                INVENTORY.UI.rptDataSet.CSalesProductDataTable CSProductDT = new rptDataSet.CSalesProductDataTable();
        //                DataRow oCSPRow = null;
        //                int nCOunt = 1;
        //                foreach (CreditSaleProduct oSItem in CSP)
        //                {
        //                    oCSPRow = CSProductDT.NewRow();
        //                    oCSPRow["SLNo"] = nCOunt.ToString();
        //                    oCSPRow["PName"] = oSItem.Product.ProductName;
        //                    //oCSPRow["ColorCode"] = "";
        //                    oCSPRow["Qty"] = oSItem.Quantity.ToString();
        //                    oCSPRow["UnitPrice"] = oSItem.UnitPrice.ToString();
        //                    oCSPRow["TotalAmt"] = oSItem.UTAmount.ToString();
        //                    CSProductDT.Rows.Add(oCSPRow);
        //                }

        //                CSProductDT.TableName = "rptDataSet_CSalesProduct";
        //                ds.Tables.Add(CSProductDT);


        //                string embededResource = "INVENTORY.UI.RDLC.CreditSalesInfo.rdlc";

        //                ReportParameter rParam = new ReportParameter();
        //                List<ReportParameter> parameters = new List<ReportParameter>();

        //                rParam = new ReportParameter("InvoiceNo", oCreditSale.InvoiceNo);
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("SalesDate", oCreditSale.SalesDate.ToString());
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("ProductName", "");
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("CustomerName", oCreditSale.Customer.Name);
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("CAddress", oCreditSale.Customer.Address);
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("CContactNo", oCreditSale.Customer.ContactNo);
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("SalesPrice", oCreditSale.TSalesAmt.ToString());
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("DownPayment", oCreditSale.DownPayment.ToString());
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("RemainingAmt", oCreditSale.Remaining.ToString());
        //                parameters.Add(rParam);


        //                rParam = new ReportParameter("Remarks", oCreditSale.Remarks);
        //                parameters.Add(rParam);

        //                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
        //                parameters.Add(rParam);

        //                fReportViewer frm = new fReportViewer();
        //                if (CreditSalesDT.Rows.Count > 0)
        //                {
        //                    frm.CommonReportViewer(embededResource, ds, parameters, true);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtSearch.Text != "")
        //        {
        //            foreach (ListViewItem item in lsvSales.Items)
        //            {
        //                if (item.SubItems[2].Text.ToLower().Contains(txtSearch.Text.ToLower()))
        //                {
        //                    item.Selected = true;
        //                }
        //                else
        //                {
        //                    lsvSales.Items.Remove(item);
        //                }
        //                item.Selected = false;
        //            }
        //            if (lsvSales.SelectedItems.Count == 1)
        //            {
        //                lsvSales.Focus();
        //            }
        //        }
        //        else
        //        {
        //            RefreshList();
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void txtInvoiceSearch_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtInvoiceSearch.Text != "")
        //        {
        //            foreach (ListViewItem item in lsvSales.Items)
        //            {
        //                if (item.SubItems[0].Text.ToLower().Contains(txtInvoiceSearch.Text.ToLower()))
        //                {
        //                    item.Selected = true;
        //                }
        //                else
        //                {
        //                    lsvSales.Items.Remove(item);
        //                }
        //                item.Selected = false;
        //            }
        //            if (lsvSales.SelectedItems.Count == 1)
        //            {
        //                lsvSales.Focus();
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

        //private void txtContact_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtContact.Text != "")
        //        {
        //            foreach (ListViewItem item in lsvSales.Items)
        //            {
        //                if (item.SubItems[3].Text.ToLower().Contains(txtContact.Text.ToLower()))
        //                {
        //                    item.Selected = true;
        //                }
        //                else
        //                {
        //                    lsvSales.Items.Remove(item);
        //                }
        //                item.Selected = false;
        //            }
        //            if (lsvSales.SelectedItems.Count == 1)
        //            {
        //                lsvSales.Focus();
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

        private void btnAgreement_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    CreditSale oCreditSale = new CreditSale();
            //    _oFCreditSale = new FCreditSale();

            //    if (lsvSales.SelectedItems != null && lsvSales.SelectedItems.Count > 0)
            //    {
            //        oCreditSale = (CreditSale)lsvSales.SelectedItems[0].Tag;
            //        if (oCreditSale != null)
            //        {
            //            _oFCreditSale.ShowDlg(oCreditSale, false, "Agreement");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdCreditSalesCustomers.MainView).GetSelectedRows();
                DataRowView oSalesID = (DataRowView)(((GridView)grdCreditSalesCustomers.MainView).GetRow(selRows[0]));

                int nSalesID = Convert.ToInt32(oSalesID["CreditSalesID"]);


                if (nSalesID > 0)
                {
                    CreditSale oCreditSale = db.CreditSales.FirstOrDefault(cs => cs.CreditSalesID == nSalesID);
                    FCreditSale oFCreditSale = new FCreditSale();
                    oFCreditSale.DisplayInvoice(oCreditSale, db.Products);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
