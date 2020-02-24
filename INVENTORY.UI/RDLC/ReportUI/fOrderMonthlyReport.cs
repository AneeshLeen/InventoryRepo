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
using Microsoft.Reporting.WinForms;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace ESRP.UI
{
    public partial class fOrderMonthlyReport : Form
    {
        public fOrderMonthlyReport()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {          
               DateTime fromDate=new DateTime(dtpDate.Value.Year,dtpDate.Value.Month,1);
               DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

               string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
               string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

               DateTime dFFDate = Convert.ToDateTime(sFFdate);
               DateTime dTTDate = Convert.ToDateTime(sTTdate);

               rptDataSet.dtMonthlySalesOrderDataTable dt = new rptDataSet.dtMonthlySalesOrderDataTable();
               using (DEWSRMEntities db1 = new DEWSRMEntities())
               {

                   if(chkSummary.Checked)
                   {
                       using (var connection = db1.Database.Connection)
                       {
                           connection.Open();
                           var command = connection.CreateCommand();
                           command.CommandText = "EXEC Monthly_Sales_Report_Summary  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                           var reader = command.ExecuteReader();
                           var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<MonthlySalesReport>(reader).ToList();

                           foreach (var item in Data)
                           {
                               dt.Rows.Add(item.Date, item.GrandTotal, item.TDiscount, item.HirPrice, item.NetPrice, item.AdjustAmt, item.PayableAmt, item.ReceiveAmt, item.Due);
                           }

                           dt.TableName = "rptDataSet_dtMonthlySalesOrder";
                           DataSet ds = new DataSet();
                           ds.Tables.Add(dt);

                           string embededResource = "ESRP.UI.RDLC.rptMonthlySalesOrderSummary.rdlc";
                           ReportParameter rParam = new ReportParameter();
                           List<ReportParameter> parameters = new List<ReportParameter>();
                           rParam = new ReportParameter("Month", "Salse For the month: " + fromDate.ToString("MMM yyyy"));

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
                   else
                   {
                       using (var connection = db1.Database.Connection)
                       {
                           connection.Open();
                           var command = connection.CreateCommand();
                           command.CommandText = "EXEC Monthly_Sales_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                           var reader = command.ExecuteReader();
                           var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<MonthlySalesReport>(reader).ToList();


                           DateTime StartDate = fromDate;
                           DateTime EndDate = toDate;
                           if (toDate > DateTime.Now)
                               EndDate = DateTime.Now;

                           int DayInterval = 1;

                           List<DateTime> dateList = new List<DateTime>();

                           while (StartDate.AddDays(DayInterval) <= EndDate)
                           {
                               dateList.Add(StartDate);

                               StartDate = StartDate.AddDays(DayInterval);

                           }
                           dateList.Add(StartDate);

                           foreach (var item in Data)
                           {
                               dt.Rows.Add(item.Date, item.GrandTotal, item.TDiscount, item.HirPrice, item.NetPrice, item.AdjustAmt, item.PayableAmt, item.ReceiveAmt, item.Due);
                           }
                           foreach (var itemDate in dateList)
                           {
                               int found = 0;
                               foreach (var item in Data)
                               {
                                   if(item.Date==itemDate )
                                   {
                                       found = 1;
                                   }
                               }

                               if(found==0)
                               {
                                   dt.Rows.Add(itemDate, 0, 0, 0, 0, 0, 0, 0, 0);
                               }                              
                           }

                           dt.TableName = "rptDataSet_dtMonthlySalesOrder";
                           DataSet ds = new DataSet();
                           ds.Tables.Add(dt);

                           string embededResource = "ESRP.UI.RDLC.rptMonthlySalesOrder.rdlc";
                           ReportParameter rParam = new ReportParameter();
                           List<ReportParameter> parameters = new List<ReportParameter>();
                           rParam = new ReportParameter("Month", "Salse For the month: " + fromDate.ToString("MMM yyyy"));

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
        }
    }
}
