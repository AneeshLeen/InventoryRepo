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
    public partial class fYearlySaleReport : Form
    {
        public fYearlySaleReport()
        {
            InitializeComponent();
            cboYear.Text = DateTime.Today.Year.ToString();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            DateTime fromDate = new DateTime(Convert.ToInt32(cboYear.Text), 1, 1);
            DateTime toDate = new DateTime(Convert.ToInt32(cboYear.Text), 12, 31);
            DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
            String RDate = Date.ToString("dd MMM yyyy");
            DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);
            string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
            string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
            DateTime dFFDate = Convert.ToDateTime(sFFdate);
            DateTime dTTDate = Convert.ToDateTime(sTTdate);
            rptDataSet.dtYearlySalesOrderDataTable dt = new rptDataSet.dtYearlySalesOrderDataTable();


            if(chkSummary.Checked)
            {
                using (DEWSRMEntities db1 = new DEWSRMEntities())
                {
                    using (var connection = db1.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        string Query = "EXEC Yearly_Sales_Report_Summary  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                        command.CommandText = Query;
                        var reader = command.ExecuteReader();
                        var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<YearlySalesReport>(reader).ToList();

                        foreach (var item in Data)
                        {
                            dt.Rows.Add(item.Date, item.GrandTotal, item.TDiscount, item.HirPrice, item.NetPrice, item.AdjustAmt, item.PayableAmt,item.ReceiveAmt, item.Due);
                        }

                        dt.TableName = "rptDataSet_dtYearlySalesOrder";
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);

                        string embededResource = "ESRP.UI.RDLC.rptYearlySalesOrderSummary.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Month", "Salse For the Year: " + cboYear.Text);
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);
                        fReportViewer frm = new fReportViewer();

                        if (dt.Rows.Count > 0)
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
            else
            {
                using (DEWSRMEntities db1 = new DEWSRMEntities())
                {
                    using (var connection = db1.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        string SQLQuery = "EXEC Yearly_Sales_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                        command.CommandText = SQLQuery;
                        var reader = command.ExecuteReader();
                        var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<YearlySalesReport>(reader).ToList();

                        foreach (var item in Data)
                        {
                            dt.Rows.Add(item.Date, item.GrandTotal, item.TDiscount, item.HirPrice, item.NetPrice, item.AdjustAmt,item.PayableAmt,
                                item.ReceiveAmt, item.Due);
                        }

                        dt.TableName = "rptDataSet_dtYearlySalesOrder";
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);

                        string embededResource = "ESRP.UI.RDLC.rptYearlySalesOrder.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Month", "Salse For the Year: " + cboYear.Text);
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);
                        fReportViewer frm = new fReportViewer();

                        if (dt.Rows.Count > 0)
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
           


            //using (DEWSRMEntities db = new DEWSRMEntities())
            //{
            // //  DateTime fromDate=new DateTime(Convert.ToInt32(cboYear.Text),1,1);
            // //   DateTime toDate=new DateTime(Convert.ToInt32(cboYear.Text),12,31);
            //    List<SOrder> oOrders = db.SOrders.Where(o => o.InvoiceDate >= fromDate && o.InvoiceDate <= toDate && o.Status == 1).ToList();
            //    List<Customer> oCustomers = db.Customers.ToList();

            //    if (oOrders != null)
            //    {
                  



            //       Customer customer=null;
            //        DataSet ds = new DataSet();
            //        foreach (SOrder grd in oOrders)
            //        {
            //            customer = oCustomers.FirstOrDefault(o => o.CustomerID == grd.CustomerID);
            //            dt.Rows.Add(customer.Code, customer.Name, grd.InvoiceNo, ((DateTime)grd.InvoiceDate).ToString("dd MMM yyyy"), grd.GrandTotal, grd.TDAmount, grd.TotalAmount, grd.RecAmount, grd.PaymentDue);
            //        }
            //        dt.TableName = "rptDataSet_dtOrder";
            //        ds.Tables.Add(dt);
            //        string embededResource = "ESRP.UI.RDLC.rptMonthlyOrder.rdlc";
            //        ReportParameter rParam = new ReportParameter();
            //        List<ReportParameter> parameters = new List<ReportParameter>();
            //        rParam = new ReportParameter("Month", "Salse For the Year: " + cboYear.Text);
            //        parameters.Add(rParam);
            //        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
            //        parameters.Add(rParam);
            //        fReportViewer frm = new fReportViewer();

            //        if (dt.Rows.Count > 0)
            //        {
            //            frm.CommonReportViewer(embededResource, ds, parameters, true);
            //        }
            //        else
            //        {
            //            MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }

            //    }
            //}
        }
    }
}
