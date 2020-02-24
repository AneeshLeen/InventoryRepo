using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRP.DA;
using Microsoft.Reporting.WinForms;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace ESRP.UI
{
    public partial class fDailySaleReport : Form
    {
        public fDailySaleReport()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                string sToDate = dtpToDate.Text + " 11:59:59 PM";

                DateTime fromDate = Convert.ToDateTime(dFromDate);//dtpFromDate.Value;
                DateTime toDate = Convert.ToDateTime(sToDate);

                string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                DateTime dFFDate = Convert.ToDateTime(sFFdate);
                DateTime dTTDate = Convert.ToDateTime(sTTdate);

                #region Summary
                if (chkSummary.Checked)
                {

                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {
                        double SalesTotal = 0;
                        double ReturnTotal = 0;

                        rptDataSet.dtDailySalesOrderDataTable dt = new rptDataSet.dtDailySalesOrderDataTable();
                        rptDataSet.dtDailyReturnDataTable dtreturn = new rptDataSet.dtDailyReturnDataTable();

                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = "EXEC Daily_Sales_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailySalesReport>(reader).ToList();
                            reader.Close();

                            command.CommandText = "EXEC Daily_Return_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            reader = command.ExecuteReader();
                            var ReturnData = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailyReturnReport>(reader).ToList();

                            if (rdoAll.Checked)
                            {
                                foreach (var item in Data)
                                {
                                    dt.Rows.Add(item.SalesType, item.InvoiceDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.TDAmount, item.HirePrice, item.NetSales, item.Adjustment, item.PayableAmt, item.RecAmount, item.Due);
                                    SalesTotal = SalesTotal + (double)item.NetSales;
                                }

                                foreach (var item in ReturnData)
                                {
                                    dtreturn.Rows.Add(item.SalesType, item.ReturnDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.RecAmount, item.Due);
                                    ReturnTotal = ReturnTotal + (double)item.GrandTotal;
                                }

                            }
                            else if (rdoCredit.Checked)
                            {
                                foreach (var item in Data)
                                {
                                    if (item.SalesType == "CS")
                                        dt.Rows.Add(item.SalesType, item.InvoiceDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.TDAmount, item.HirePrice, item.NetSales, item.Adjustment, item.PayableAmt, item.RecAmount, item.Due);
                                    SalesTotal = SalesTotal + (double)item.NetSales;
                                }

                                //foreach (var item in ReturnData)
                                //{
                                //    dtreturn.Rows.Add(item.SalesType, item.ReturnDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal,  item.RecAmount, item.Due);
                                //    ReturnTotal = ReturnTotal + (double)item.GrandTotal;
                                //}

                            }
                            else if (rdoRetail.Checked)
                            {
                                foreach (var item in Data)
                                {
                                    if (item.CustomerType == (int)EnumCustomerType.Retail)
                                        dt.Rows.Add(item.SalesType, item.InvoiceDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.TDAmount, item.HirePrice, item.NetSales, item.Adjustment, item.PayableAmt, item.RecAmount, item.Due);
                                    SalesTotal = SalesTotal + (double)item.NetSales;
                                }

                                foreach (var item in ReturnData)
                                {
                                    if (item.CusType == (int)EnumCustomerType.Retail)
                                        dtreturn.Rows.Add(item.SalesType, item.ReturnDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.RecAmount, item.Due);
                                    ReturnTotal = ReturnTotal + (double)item.GrandTotal;
                                }
                            }
                            else if (rdoDealer.Checked)
                            {
                                foreach (var item in Data)
                                {
                                    if (item.CustomerType == (int)EnumCustomerType.Dealer)
                                        dt.Rows.Add(item.SalesType, item.InvoiceDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.TDAmount, item.HirePrice, item.NetSales, item.Adjustment, item.PayableAmt, item.RecAmount, item.Due);
                                    SalesTotal = SalesTotal + (double)item.NetSales;

                                }

                                foreach (var item in ReturnData)
                                {
                                    if (item.CusType == (int)EnumCustomerType.Dealer)
                                        dt.Rows.Add(item.SalesType, item.ReturnDate, item.InvoiceNo, "", item.CustomerName, item.ContactNo, item.GrandTotal, item.RecAmount, item.Due);
                                    ReturnTotal = ReturnTotal + (double)item.GrandTotal;
                                }
                            }
                            DataSet ds = new DataSet();
                            dt.TableName = "rptDataSet_dtDailySalesOrder";
                            ds.Tables.Add(dt);
                            dtreturn.TableName = "rptDataSet_dtDailyReturn";
                            ds.Tables.Add(dtreturn);
                            string embededResource = "ESRP.UI.RDLC.rptDailySalesReportSummary.rdlc";
                            ReportParameter rParam = new ReportParameter();
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            rParam = new ReportParameter("Month", "Salse Report From " + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
                            parameters.Add(rParam);

                            rParam = new ReportParameter("NetSales", (SalesTotal - ReturnTotal).ToString());
                            parameters.Add(rParam);


                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);
                            fReportViewer frm = new fReportViewer();

                            if (dt.Rows.Count > 0 || dtreturn.Rows.Count > 0)
                            {
                                frm.CommonReportViewer(embededResource, ds, parameters, true);
                            }
                            else
                            {
                                MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                #endregion

                #region OldCode
                //else if (rbChasis.Checked)
                //{

                //    using (DEWSRMEntities db = new DEWSRMEntities())
                //    {
                //        List<StockDetail> oSTDList = db.StockDetails.ToList();
                //        //List<Model> oModelList = db.Models.ToList();
                //        List<Customer> oCusList = db.Customers.ToList();

                //        DateTime fromDate1 = dtpFromDate.Value;
                //        DateTime toDate1 = dtpToDate.Value;


                //        var Sales = (from SOD in db.SOrderDetails
                //                     from SO in db.SOrders
                //                     from P in db.Products
                //                     where (SOD.SOrderID == SO.SOrderID && P.ProductID == SOD.ProductID && SO.InvoiceDate >= dFFDate && SO.InvoiceDate <= dTTDate && SO.Status == 1)
                //                     select new { SOD.StockDetailID, SO.InvoiceNo, SO.CustomerID, SO.InvoiceDate, SO.GrandTotal, SO.TDAmount, SO.TotalAmount, SO.RecAmount, SO.PaymentDue, P.ProductID, P.ProductName, SOD.UnitPrice, SOD.UTAmount, SOD.PPDAmount, SOD.Quantity }).OrderByDescending(x => x.InvoiceDate);


                //        if (Sales != null)
                //        {
                //            rptDataSet.dtChasisDataTable dt = new rptDataSet.dtChasisDataTable();

                //            DataSet ds = new DataSet();


                //            string SInvoiceNo = "";

                //            foreach (var grd in Sales.ToList())
                //            {
                //                StockDetail std = oSTDList.FirstOrDefault(x => x.SDetailID == grd.StockDetailID);
                //                Customer oCus = oCusList.FirstOrDefault(x => x.CustomerID == grd.CustomerID);
                //                SInvoiceNo = grd.InvoiceNo;
                //                dt.Rows.Add(grd.InvoiceNo, oCus.Code, oCus.Name, grd.ProductName, std.EngineNo, std.ChasisNo, std.KeyNo, grd.Quantity);

                //            }

                //            dt.TableName = "rptDataSet_dtChasis";
                //            ds.Tables.Add(dt);

                //            string embededResource = "ESRP.UI.RDLC.rptChasis.rdlc";

                //            ReportParameter rParam = new ReportParameter();
                //            List<ReportParameter> parameters = new List<ReportParameter>();

                //            rParam = new ReportParameter("Date", "Sals details for the date of : " + fromDate1.ToString("dd MMM yyyy") + " to " + toDate1.ToString("dd MMM yyyy"));
                //            parameters.Add(rParam);

                //            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                //            parameters.Add(rParam);


                //            fReportViewer frm = new fReportViewer();

                //            if (dt.Rows.Count > 0)
                //            {
                //                frm.CommonReportViewer(embededResource, ds, parameters, true);
                //            }
                //            else
                //            {
                //                MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            }
                //        }
                //    }
                //}
                #endregion

                #region Details
                else
                {
                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {
                        rptDataSet.dtDailySalesOrderDetailsDataTable dt = new rptDataSet.dtDailySalesOrderDetailsDataTable();
                        rptDataSet.dtDailyReturnDetailsDataTable dtreturn = new rptDataSet.dtDailyReturnDetailsDataTable();
                        double SalesTotal = 0;
                        double ReturnTotal = 0;
                        List<DailySalesReportDetails> SalesOrderData = new List<DailySalesReportDetails>();
                        List<DailySalesReportDetails> ReturnSOrderData = new List<DailySalesReportDetails>();
                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = "EXEC Daily_Sales_Report_Details  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailySalesReportDetails>(reader).ToList();
                            reader.Close();

                            command.CommandText = "EXEC Daily_Return_Report_Details  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            reader = command.ExecuteReader();
                            var ReturnData = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailySalesReportDetails>(reader).ToList();

                            if (rdoAll.Checked)
                            {
                                SalesOrderData = Data;
                                ReturnSOrderData = ReturnData;
                            }
                            else if (rdoCredit.Checked)
                            {
                                SalesOrderData = Data.Where(i => i.SalesType.Equals("CS")).ToList();
                            }
                            else if (rdoRetail.Checked)
                            {
                                SalesOrderData = Data.Where(i => i.CusType == (int)EnumCustomerType.Retail).ToList();
                                ReturnSOrderData = ReturnData.Where(i => i.CusType == (int)EnumCustomerType.Retail).ToList();
                            }
                            else if (rdoDealer.Checked)
                            {
                                SalesOrderData = Data.Where(i => i.CusType == (int)EnumCustomerType.Dealer).ToList();
                                ReturnSOrderData = ReturnData.Where(i => i.CusType == (int)EnumCustomerType.Dealer).ToList();
                            }
                            var NobarcodeSOrders = from so in SalesOrderData.Where(i => i.ProductType == (int)EnumProductType.NoBarCode).ToList()
                                                   group so by new { so.SalesType, so.SOrderID, so.InvoiceDate, so.InvoiceNo, so.CustomerID, so.CustomerName, so.ProductID, so.ProductName, so.Color, so.ColorID } into g
                                                   select new DailySalesReportDetails
                                                   {
                                                       SalesType = g.Key.SalesType,
                                                       SOrderID = g.Key.SOrderID,
                                                       InvoiceDate = g.Key.InvoiceDate,
                                                       InvoiceNo = g.Key.InvoiceNo,
                                                       CustomerID = g.Key.CustomerID,
                                                       CustomerName = g.Key.CustomerName,
                                                       ProductID = g.Key.ProductID,
                                                       ProductName = g.Key.ProductName,
                                                       Color = g.Key.Color,
                                                       ColorID = g.Key.ColorID,
                                                       Quantity = g.Sum(i => i.Quantity),
                                                       UnitPrice = g.Select(i => i.UnitPrice).FirstOrDefault(),
                                                       PPDAmount = g.Select(i => i.PPDAmount).FirstOrDefault(),
                                                       UTAmount = g.Sum(i => i.UTAmount),
                                                       HirePrice = g.Sum(i => i.HirePrice),
                                                       NetPrice = g.Sum(i => i.NetPrice),
                                                   };
                            SalesOrderData = SalesOrderData.Where(i => i.ProductType != (int)EnumProductType.NoBarCode).ToList();
                            SalesOrderData.AddRange(NobarcodeSOrders);
                         
                            var NobarcodeReturns = from so in ReturnSOrderData.Where(i => i.ProductType == (int)EnumProductType.NoBarCode).ToList()
                                                   group so by new { so.SalesType, so.SOrderID, so.InvoiceDate, so.InvoiceNo, so.CustomerID, so.CustomerName, so.ProductID, so.ProductName, so.Color, so.ColorID } into g
                                                   select new DailySalesReportDetails
                                                   {
                                                       SalesType = g.Key.SalesType,
                                                       SOrderID = g.Key.SOrderID,
                                                       InvoiceDate = g.Key.InvoiceDate,
                                                       InvoiceNo = g.Key.InvoiceNo,
                                                       CustomerID = g.Key.CustomerID,
                                                       CustomerName = g.Key.CustomerName,
                                                       ProductID = g.Key.ProductID,
                                                       ProductName = g.Key.ProductName,
                                                       Color = g.Key.Color,
                                                       ColorID = g.Key.ColorID,
                                                       Quantity = g.Sum(i => i.Quantity),
                                                       UnitPrice = g.Select(i => i.UnitPrice).FirstOrDefault(),
                                                       PPDAmount = g.Select(i => i.PPDAmount).FirstOrDefault(),
                                                       UTAmount = g.Sum(i => i.UTAmount),
                                                       HirePrice = g.Sum(i => i.HirePrice),
                                                       NetPrice = g.Sum(i => i.NetPrice),
                                                   };
                            ReturnSOrderData = ReturnSOrderData.Where(i => i.ProductType != (int)EnumProductType.NoBarCode).ToList();
                            ReturnSOrderData.AddRange(NobarcodeReturns);

                            foreach (var item in SalesOrderData)
                            {
                                //item.Company,item.Model,item.Color,      
                                dt.Rows.Add(item.SalesType, item.InvoiceDate, item.InvoiceNo, "", item.CustomerName, item.ProductName, item.CategoryName, item.Quantity, item.UnitPrice, item.UTAmount, item.PPDAmount, item.HirePrice, item.NetPrice, item.Color);
                                SalesTotal = SalesTotal + (double)item.NetPrice;
                            }
                            foreach (var item in ReturnSOrderData)
                            {
                                dtreturn.Rows.Add(item.SalesType, item.InvoiceDate, item.InvoiceNo, "", item.CustomerName, item.ProductName, item.CategoryName, item.Quantity, item.UnitPrice, item.UTAmount, item.Color);
                                ReturnTotal = ReturnTotal + (double)item.UTAmount;
                            }
                            DataSet ds = new DataSet();
                            dt.TableName = "rptDataSet_dtDailySalesOrderDetails";
                            ds.Tables.Add(dt);

                            dtreturn.TableName = "rptDataSet_dtDailyReturnDetails";
                            ds.Tables.Add(dtreturn);

                            string embededResource = "ESRP.UI.RDLC.rptDailySalesReport.rdlc";
                            ReportParameter rParam = new ReportParameter();
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            rParam = new ReportParameter("Month", "Salse Report From " + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
                            parameters.Add(rParam);

                            rParam = new ReportParameter("NetSales", (SalesTotal - ReturnTotal).ToString());
                            parameters.Add(rParam);

                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);

                            fReportViewer frm = new fReportViewer();

                            if (dt.Rows.Count > 0 || dtreturn.Rows.Count > 0)
                            {
                                frm.CommonReportViewer(embededResource, ds, parameters, true);
                            }
                            else
                            {
                                MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                #endregion
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

