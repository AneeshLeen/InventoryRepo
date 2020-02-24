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
    public partial class fPurchaseMonthly : Form
    {
        public fPurchaseMonthly()
        {
            InitializeComponent();
        }

        private void fPurchaseMonthly_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
               
                    DateTime fromDate = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, 1);
                    DateTime toDate = fromDate.AddMonths(1).AddDays(-1);// (new DateTime(dtpDate.Value.Year, dtpDate.Value.AddMonths(1).Month, 1)).AddDays(-1);

                    string sFFdate = fromDate.ToString();
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);
           

                    rptDataSet.dtMonthlyPurchaseOrderDataTable dt = new rptDataSet.dtMonthlyPurchaseOrderDataTable ();


                   if(chkSummary.Checked)
                   {

                       using (DEWSRMEntities db1 = new DEWSRMEntities())
                       {
                           using (var connection = db1.Database.Connection)
                           {
                               connection.Open();
                               var command = connection.CreateCommand();
                               command.CommandText = "EXEC Monthly_Purchase_Report_Summary  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                               var reader = command.ExecuteReader();
                               var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<MonthlyPurchaseReport>(reader).ToList();

                               foreach (var item in Data)
                               {
                                   dt.Rows.Add(item.Date, item.GrandTotal, item.TDiscount,item.NetPurchase, item.AdjustAmt, item.ReceiveAmt, item.Due);
                               }

                               dt.TableName = "rptDataSet_dtMonthlyPurchaseOrder";
                               DataSet ds = new DataSet();
                               ds.Tables.Add(dt);

                               string embededResource = "ESRP.UI.RDLC.rptMonthlyPurchaseOrderSummary.rdlc";
                               ReportParameter rParam = new ReportParameter();
                               List<ReportParameter> parameters = new List<ReportParameter>();
                               rParam = new ReportParameter("Month", "Purchase For the month: " + fromDate.ToString("MMM yyyy"));

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
                               command.CommandText = "EXEC Monthly_Purchase_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                               var reader = command.ExecuteReader();
                               var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<MonthlyPurchaseReport>(reader).ToList();




                               foreach (var item in Data)
                               {
                                   dt.Rows.Add(item.Date, item.GrandTotal, item.TDiscount,item.NetPurchase, item.AdjustAmt, item.ReceiveAmt, item.Due);
                               }

                               dt.TableName = "rptDataSet_dtMonthlyPurchaseOrder";
                               DataSet ds = new DataSet();
                               ds.Tables.Add(dt);

                               string embededResource = "ESRP.UI.RDLC.rptMonthlyPurchaseOrder.rdlc";
                               ReportParameter rParam = new ReportParameter();
                               List<ReportParameter> parameters = new List<ReportParameter>();
                               rParam = new ReportParameter("Month", "Purchase For the month: " + fromDate.ToString("MMM yyyy"));

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
