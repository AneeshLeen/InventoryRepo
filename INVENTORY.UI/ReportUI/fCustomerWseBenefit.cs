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
    public partial class fCustomerWseBenefit : Form
    {
        DEWSRMEntities db = null;

        public fCustomerWseBenefit()
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
               
                //TransactionalDataSet.dtCCashDataTable dt = new TransactionalDataSet.dtDailyCashbookLedgerDataTable();
              
                if(rbSummary.Checked)
                {
                    rptDataSet.dtCustomerWiseBenefitSummaryDataTable dt = new rptDataSet.dtCustomerWiseBenefitSummaryDataTable();
                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {
                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();


                            command.CommandText = "EXEC Customer_Wise_Benefit_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'" + "," + "'" + 1 + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<CustomerWiseBenefitSummary>(reader).ToList();

                            var DataGroupBy = (from sod in Data.ToList()
                                               group sod by new { sod.CustomerID, sod.InvoiceNo, sod.InvoiceDate, sod.Name, sod.Code, sod.Address, sod.ContactNo } into g
                                               select new
                                               {
                                                   g.Key.CustomerID,
                                                   g.Key.Code,
                                                   g.Key.Address,
                                                   g.Key.ContactNo,
                                                   g.Key.Name,
                                                   g.Key.InvoiceNo,
                                                   g.Key.InvoiceDate,
                                                   SalesAmt = g.Sum(o => o.SalesAmt),
                                                   PurchaseAmt = g.Sum(o => o.PurchaseAmt),
                                                   Profit=g.Sum(o=>o.Profit)
                                               });


                            if(ctlCustomer.SelectedID!=0)
                            {


                                foreach (var item in DataGroupBy)
                                {
                                    if(item.CustomerID==ctlCustomer.SelectedID)
                                    dt.Rows.Add(item.Code, item.Name, item.Address + " " + item.ContactNo, item.ContactNo, item.InvoiceDate, item.InvoiceNo, item.SalesAmt, item.PurchaseAmt, item.Profit);
                                    // dt.Rows.Add(item.ConcernID, item.Date, item.OpeningBalance, item.CashSales, item.DueCollection, item.DownPayment, item.InstallAmt, item.Loan, item.BankWithdrwal, item.OthersIncome, item.TotalIncome, item.PaidAmt, item.Delivery, item.EmployeeSalary, item.Conveyance, item.BankDeposit, item.LoanPaid, item.Vat, item.OthersExpense, item.SRET, item.TotalExpense, item.ClosingBalance);                                                  
                                }
                            }
                            else
                            {

                                foreach (var item in Data)
                                {
                                    dt.Rows.Add(item.Code, item.Name, item.Address + " " + item.ContactNo, item.ContactNo, item.InvoiceDate, item.InvoiceNo, item.SalesAmt, item.PurchaseAmt, item.Profit);
                                    // dt.Rows.Add(item.ConcernID, item.Date, item.OpeningBalance, item.CashSales, item.DueCollection, item.DownPayment, item.InstallAmt, item.Loan, item.BankWithdrwal, item.OthersIncome, item.TotalIncome, item.PaidAmt, item.Delivery, item.EmployeeSalary, item.Conveyance, item.BankDeposit, item.LoanPaid, item.Vat, item.OthersExpense, item.SRET, item.TotalExpense, item.ClosingBalance);                                                  
                                }
                            }



                        }

                    }

                    DataSet ds = new DataSet();

                    dt.TableName = "rptDataSet_dtCustomerWiseSalesSummarry";
                    ds.Tables.Add(dt);
                    string embededResource = "INVENTORY.UI.RDLC.rptCustomerWiseSalesSummary.rdlc";
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
                else
                {
                    rptDataSet.dtCustomerWiseBenefitDataTable dt = new rptDataSet.dtCustomerWiseBenefitDataTable();
                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {
                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();


                            command.CommandText = "EXEC Customer_Wise_Benefit_Report  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'" + "," + "'" + 1 + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<CustomerWiseBenefitDetails>(reader).ToList();

                         

                            if (ctlCustomer.SelectedID != 0)
                            {

                                foreach (var item in Data)
                                {
                                    if (ctlCustomer.SelectedID==item.CustomerID)
                                    dt.Rows.Add(item.Code, item.Name, item.Address + " " + item.ContactNo, item.ContactNo, item.InvoiceDate, item.InvoiceNo, item.ProductName, item.SalesAmt, item.PurchaseAmt, item.Profit);
                                    // dt.Rows.Add(item.ConcernID, item.Date, item.OpeningBalance, item.CashSales, item.DueCollection, item.DownPayment, item.InstallAmt, item.Loan, item.BankWithdrwal, item.OthersIncome, item.TotalIncome, item.PaidAmt, item.Delivery, item.EmployeeSalary, item.Conveyance, item.BankDeposit, item.LoanPaid, item.Vat, item.OthersExpense, item.SRET, item.TotalExpense, item.ClosingBalance);

                                }

                            }
                            else
                            {
                                foreach (var item in Data)
                                {
                                    dt.Rows.Add(item.Code, item.Name, item.Address + " " + item.ContactNo, item.ContactNo, item.InvoiceDate, item.InvoiceNo, item.ProductName, item.SalesAmt, item.PurchaseAmt, item.Profit);
                                    // dt.Rows.Add(item.ConcernID, item.Date, item.OpeningBalance, item.CashSales, item.DueCollection, item.DownPayment, item.InstallAmt, item.Loan, item.BankWithdrwal, item.OthersIncome, item.TotalIncome, item.PaidAmt, item.Delivery, item.EmployeeSalary, item.Conveyance, item.BankDeposit, item.LoanPaid, item.Vat, item.OthersExpense, item.SRET, item.TotalExpense, item.ClosingBalance);

                                }
                            }

                          

                        }

                    }

                    DataSet ds = new DataSet();



                    dt.TableName = "rptDataSet_dtCustomerWiseSalesDetials";
                    ds.Tables.Add(dt);
                    string embededResource = "INVENTORY.UI.RDLC.rptCustomerWiseSalesDetails.rdlc";
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

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
