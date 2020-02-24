using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using INVENTORY.DA;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace INVENTORY.UI
{
    public partial class fMonthlyBenefitShow : Form
    {
      
        rptDataSet.dtMonthlyBenefitDataTable dt = new rptDataSet.dtMonthlyBenefitDataTable();
        public fMonthlyBenefitShow()
        {
            InitializeComponent();
        }

        private void fMonthlyBenefitShow_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            
        }

        private void RefreshList111()
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                rptDataSet.dtMonthlyBenefitDataTable dt = new rptDataSet.dtMonthlyBenefitDataTable();
               if(chkSummary.Checked)
               {
                   try
                   {


                       //DateTime fromDate = dtpFromDate.Value;
                       //DateTime toDate = dtpToDate.Value;

                       DateTime fromDate = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, 1);
                       DateTime toDate = fromDate.AddMonths(1);
                       toDate = toDate.AddDays(-1);

                       //var firstDayOfMonth = new DateTime(fromDate.Year, fromDate.Month, 1);
                       //var last = new DateTime(toDate.Year, toDate.Month, 1);
                       //var lastDayOfMonth = last.AddMonths(1).AddDays(-1);

                       //DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                       //String RDate = Date.ToString("dd MMM yyyy");
                       //DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);



                       string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                       string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                       DateTime dFFDate = Convert.ToDateTime(sFFdate);
                       DateTime dTTDate = Convert.ToDateTime(sTTdate);

                       using (DEWSRMEntities db1 = new DEWSRMEntities())
                       {
                           using (var connection = db1.Database.Connection)
                           {
                               connection.Open();
                               var command = connection.CreateCommand();
                               command.CommandText = "EXEC MonthlyBenefitReport " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                               var reader = command.ExecuteReader();
                               var MonthlyBenefitByProduct = ((IObjectContextAdapter)db1).ObjectContext.Translate<MonthlyBenefit>(reader).ToList();

                               ListViewItem item = null;


                               dt.Rows.Clear();


                               foreach (var it in MonthlyBenefitByProduct)
                               {
                                   dt.Rows.Add(it.InvoiceDate,
                                       it.SalesTotal + it.CreditSalesTotal - it.TDAmount_Sale - it.TDAmount_CreditSale,
                                       it.PurchaseTotal + it.CreditPurchase,
                                       it.TDAmount_Sale,
                                       it.TDAmount_CreditSale,
                                       it.FirstTotalInterest,
                                       it.HireCollection,
                                       it.CreditSalesTotal,
                                       it.CreditPurchase,
                                       it.CommisionProfit,
                                       it.HireProfit,
                                       it.TotalProfit,
                                       it.OthersIncome,
                                       it.TotalIncome,
                                       it.Adjustment,
                                       it.LastPayAdjustment,
                                       it.TotalExpense,
                                       it.Benefit);


                               }

                           }
                       }


                       DataSet ds = new DataSet();
                       dt.TableName = "rptDataSet_dtMonthlyBenefit";
                       ds.Tables.Add(dt);

                       string embededResource = "INVENTORY.UI.RDLC.MonthlyBenefitRpt.rdlc";
                       ReportParameter rParam = new ReportParameter();
                       List<ReportParameter> parameters = new List<ReportParameter>();
                       //rParam = new ReportParameter("Month", "Comapny Benefit Report From " + dFromDate.ToString("dd MMM yyyy") + " To " + dToDate.ToString("dd MMM yyyy"));
                       //parameters.Add(rParam);

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
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message);
                   }


               }
               else
               {
                   try
                   {


                       DateTime fromDate = dtpFromDate1.Value;
                       DateTime toDate = dtpToDate2.Value;

                  

                       //DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                       //String RDate = Date.ToString("dd MMM yyyy");
                       //DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);



                       string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                       string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                       DateTime dFFDate = Convert.ToDateTime(sFFdate);
                       DateTime dTTDate = Convert.ToDateTime(sTTdate);

                       using (DEWSRMEntities db1 = new DEWSRMEntities())
                       {
                           using (var connection = db1.Database.Connection)
                           {
                               connection.Open();
                               var command = connection.CreateCommand();
                               command.CommandText = "EXEC MonthlyBenefitReport_Details " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                               var reader = command.ExecuteReader();
                               var MonthlyBenefitByProduct = ((IObjectContextAdapter)db1).ObjectContext.Translate<MonthlyBenefit>(reader).ToList();

                               ListViewItem item = null;


                               dt.Rows.Clear();


                               foreach (var it in MonthlyBenefitByProduct)
                               {
                                   dt.Rows.Add(it.InvoiceDate,
                                       it.SalesTotal + it.CreditSalesTotal - it.TDAmount_Sale - it.TDAmount_CreditSale,
                                       it.PurchaseTotal + it.CreditPurchase,
                                       it.TDAmount_Sale,
                                       it.TDAmount_CreditSale,
                                       it.FirstTotalInterest,
                                       it.HireCollection,
                                       it.CreditSalesTotal,
                                       it.CreditPurchase,
                                       it.CommisionProfit,
                                       it.HireProfit,
                                       it.TotalProfit,
                                       it.OthersIncome,
                                       it.TotalIncome,
                                       it.Adjustment,
                                       it.LastPayAdjustment,
                                       it.TotalExpense,
                                       it.Benefit);


                               }

                           }
                       }


                       DataSet ds = new DataSet();
                       dt.TableName = "rptDataSet_dtMonthlyBenefit";
                       ds.Tables.Add(dt);

                       string embededResource = "INVENTORY.UI.RDLC.MonthlyBenefitRptDetails.rdlc";
                       ReportParameter rParam = new ReportParameter();
                       List<ReportParameter> parameters = new List<ReportParameter>();
                       //rParam = new ReportParameter("Month", "Comapny Benefit Report From " + dFromDate.ToString("dd MMM yyyy") + " To " + dToDate.ToString("dd MMM yyyy"));
                       //parameters.Add(rParam);

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
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message);
                   }




               }



               


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkSummary_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
