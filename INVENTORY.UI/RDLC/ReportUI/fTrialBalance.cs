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
using ESRP.DA;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace ESRP.UI
{
    public partial class fTrialBalance : Form
    {
        DEWSRMEntities db = null;

        public fTrialBalance()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                String RDate = Date.ToString("dd MMM yyyy");
                DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                DateTime dFFDate = Convert.ToDateTime(sFFdate);
                DateTime dTTDate = Convert.ToDateTime(sTTdate);
                TransactionalDataSet.dtDailyWorkSheetDataTable dt = new TransactionalDataSet.dtDailyWorkSheetDataTable();
              
                using (DEWSRMEntities db1 = new DEWSRMEntities())
                {
                    using (var connection = db1.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_DailyWorkSheet  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                        var reader = command.ExecuteReader();
                        var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailyWorkSheetReportModel>(reader).ToList();

                       
                       
                     
                        foreach (var item in Data)
                        {
                            dt.Rows.Add(0, item.Date, item.OpeningBalance, item.CashSales, item.CashSales+item.DueSales, item.DueCollection, item.DownPayment, item.InstallAmt, item.Loan, item.BankWithdrwal, item.Commision, item.OthersIncome, item.TotalIncome, item.DueSales,   item.PaidAmt,item.DuePurchase,item.PaidAmt+item.DuePurchase  , item.Delivery, item.EmployeeSalary, item.Conveyance, item.BankDeposit, item.LoanPaid, item.Vat, item.OthersExpense, item.SRET, item.TotalExpense, item.ClosingBalance);
                        }

                    
                    }

                }
               
                DataSet ds = new DataSet();



                dt.TableName = "TransactionalDataSet_dtDailyWorkSheet";
                ds.Tables.Add(dt);
                string embededResource = "ESRP.UI.RDLC.rptDailyWorkSheet.rdlc";
                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                rParam = new ReportParameter("DateRange", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                parameters.Add(rParam);
                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);
                //rParam = new ReportParameter("CName", "adf");
                //parameters.Add(rParam);
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
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void fPartyLedger_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    fPartyLedger oFPLedger = new fPartyLedger();
            //    oFPLedger.ShowDialog();

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
