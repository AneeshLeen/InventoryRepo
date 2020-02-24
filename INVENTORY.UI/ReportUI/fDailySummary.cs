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
    public partial class fDailySummary : Form
    {
        DEWSRMEntities db = null;
        public fDailySummary()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }


        public decimal CashInHand(string sFFdate, string sTTdate,string Type)
        {

            using (DEWSRMEntities db2 = new DEWSRMEntities())
            {
                using (var connection = db2.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();


                    if (Type == "Daily")
                    {
                        command.CommandText = "EXEC sp_DailyCashInHand  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                    }
                    else if (Type == "Monthly")
                    {
                        command.CommandText = "EXEC sp_DailyCashBookLedger4  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                    }
                    else
                    {
                        command.CommandText = "EXEC sp_DailyCashBookLedger5  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                    }

                    var reader = command.ExecuteReader();
                    var Data = ((IObjectContextAdapter)db2).ObjectContext.Translate<DailyCashBookLedgerModel>(reader).ToList();

                    var DataForTable = Data.Where(o => o.Expense != "Total Payable" && o.Income != "Total Receivable" && o.Expense != "Current Cash In Hand" && o.Income != "Closing Cash In Hand" && o.Income != "Opening Cash In Hand").ToList();
                    var DataForTotal = Data.Where(o => o.Expense == "Total Payable" && o.Income == "Total Receivable").ToList();
                    var DataForOpening = Data.Where(o => o.Income == "Opening Cash In Hand").ToList();
                    var DataForCurrent = Data.Where(o => o.Expense == "Current Cash In Hand").ToList();
                    var DataForClosing = Data.Where(o => o.Expense == "Closing Cash In Hand").ToList();
                    //var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" || o.Category == "Cash Delivery");

                    //double CashIn = (double)DataForCashIn.Sum(o => o.IncomeAmt);

                    //TotalPayable = (double)DataForTotal.Sum(o => o.ExpenseAmt);
                    //TotalRecivable = (double)DataForTotal.Sum(o => o.IncomeAmt);
                    decimal  OpeningCashInhand =DataForOpening.Sum(o => o.IncomeAmt);
                    return OpeningCashInhand;
                    //CurrentCashInhand = (double)DataForCurrent.Sum(o => o.ExpenseAmt);
                    //ClosingCashInhand = OpeningCashInhand + CurrentCashInhand;
                }
             

            }
           
        }




        public decimal CurrentCashInHand(string sFFdate, string sTTdate, string Type)
        {

            using (DEWSRMEntities db2 = new DEWSRMEntities())
            {
                using (var connection = db2.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();


                    if (Type == "Daily")
                    {
                        command.CommandText = "EXEC sp_DailyCashInHand  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                    }
                    else if (Type == "Monthly")
                    {
                        command.CommandText = "EXEC sp_DailyCashBookLedger4  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                    }
                    else
                    {
                        command.CommandText = "EXEC sp_DailyCashBookLedger5  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                    }

                    var reader = command.ExecuteReader();
                    var Data = ((IObjectContextAdapter)db2).ObjectContext.Translate<DailyCashBookLedgerModel>(reader).ToList();

                    var DataForTable = Data.Where(o => o.Expense != "Total Payable" && o.Income != "Total Receivable" && o.Expense != "Current Cash In Hand" && o.Income != "Closing Cash In Hand" && o.Income != "Opening Cash In Hand").ToList();
                    var DataForTotal = Data.Where(o => o.Expense == "Total Payable" && o.Income == "Total Receivable").ToList();
                    var DataForOpening = Data.Where(o => o.Income == "Opening Cash In Hand").ToList();
                    var DataForCurrent = Data.Where(o => o.Expense == "Current Cash In Hand").ToList();
                    var DataForClosing = Data.Where(o => o.Expense == "Closing Cash In Hand").ToList();
                    //var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" || o.Category == "Cash Delivery");

                    //double CashIn = (double)DataForCashIn.Sum(o => o.IncomeAmt);

                    //TotalPayable = (double)DataForTotal.Sum(o => o.ExpenseAmt);
                    //TotalRecivable = (double)DataForTotal.Sum(o => o.IncomeAmt);
                    //decimal OpeningCashInhand = DataForOpening.Sum(o => o.IncomeAmt);
                    decimal CurrentCashInhand = DataForCurrent.Sum(o => o.ExpenseAmt);
                    return CurrentCashInhand;
                   
                    //ClosingCashInhand = OpeningCashInhand + CurrentCashInhand;
                }


            }

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                if (rbDaily.Checked)
                {
                    DateTime fromDate = dtpDaily.Value;
                    DateTime toDate = dtpDaily.Value;

                    string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);

                    rptDataSet.dtSummaryDataTable dt = new rptDataSet.dtSummaryDataTable();
                    DataSet ds = new DataSet();


                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {

                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = "EXEC Daily_Summary  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailySummary>(reader).ToList();

                            var DataWithinDate = Data.Where(o => o.TransDate >= dFFDate && o.TransDate <= dTTDate);

                            var DataWithinDateForTable = DataWithinDate.Where(o => o.Category != "Opening Cash In Hand" && o.Category != "Closing Cash In Hand");

                             var DataForCashIn = DataWithinDateForTable.Where(o => o.Category == "Income" || o.Category == "Sales" || o.Category == "Cash Collection");

                            var DataForCashOut= DataWithinDateForTable.Where(o=> o.Category == "Purchase" );
                            var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" ||  o.Category == "Cash Delivery");

                            double CashIn =  (double) DataForCashIn.Sum(o => o.IncomeAmt);
                            double CashOut = (double)DataForCashOut.Sum(o => o.IncomeAmt)+(double)DataForCashOut2.Sum(o => o.ExpenseAmt) ;

                            double OpeningCashInHand = (double)CashInHand(sFFdate, sTTdate, "Daily");// (double)DataWithinDate.Where(s => s.Category == "Opening Cash In Hand").Select(o => o.ExpenseAmt).First();
                            double PCashInHand = (double)CurrentCashInHand(sFFdate, sTTdate, "Daily");// (double)DataWithinDate.Where(s => s.Category == "Opening Cash In Hand").Select(o => o.ExpenseAmt).First();
                            


                            double ClosingCashInHand = (double)DataWithinDate.Where(s=>s.Category=="Closing Cash In Hand").Select(o => o.ExpenseAmt).First();
                            
                            foreach (var obj in DataWithinDateForTable)
                            {

                                double TotalAsset = OpeningCashInHand + CashIn - CashOut + (double)obj.BankBalance + (double)obj.CustomerDue + (double)obj.CurrentStockValue + (double)obj.FixedAssetValue + (double)obj.CurrentAssetValue;
                                double Liabilities = (double)(obj.SupplierDue + obj.Loan + obj.ReturnProductValue + obj.DamageProductValue + obj.TotalLiabilities);
                                int id = 1;
                                if(obj.Category=="Purchase")
                                {
                                    id = 1;
                                }
                                else if(obj.Category=="Sales")
                                {
                                    id = 2;
                                }
                                else if (obj.Category == "Cash Collection")
                                {
                                    id = 3;
                                }
                                else if (obj.Category == "Cash Delivery")
                                {
                                    id = 4;
                                }
                                else if (obj.Category == "Income")
                                {
                                    id = 5;
                                }
                                else if (obj.Category == "Expense")
                                {
                                    id = 6;
                                }
                                else
                                {
                                    id = 7;
                                }







                                dt.Rows.Add(obj.TransDate,
                                    id,
                                    obj.Category, 
                                    
                                    obj.Name, 
                                    obj.Quantity, 
                                    obj.TotalAmount,
                                    obj.IncomeAmt,
                                    obj.ExpenseAmt, 
                                    CashIn,
                                    CashOut,
                                    OpeningCashInHand,
                                   CashIn - CashOut,
                                    obj.BankBalance,
                                    obj.CustomerDue,
                                    obj.CurrentStockValue,
                                    obj.FixedAssetValue,
                                    obj.CurrentAssetValue,
                                     TotalAsset,
                                    obj.SupplierDue,
                                    obj.Loan, 
                                    obj.DamageProductValue,
                                    obj.ReturnProductValue, 
                                    Liabilities,
                                    TotalAsset-Liabilities
                                    );
                            }



                        }
                    }

                    dt.TableName = "rptDataSet_dtSummary";
                    ds.Tables.Add(dt);

                    string embededResource = "INVENTORY.UI.RDLC.rptSummary.rdlc";

                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("Date", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);

                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CName","");
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
               else if (rbMonthly.Checked)
                {



                    DateTime fromDate = new DateTime(dtpMonthly.Value.Year, dtpMonthly.Value.Month, 1);
                    DateTime toDate = (new DateTime(dtpMonthly.Value.Year, dtpMonthly.Value.AddMonths(1).Month, 1)).AddDays(-1);

                    string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);

                    rptDataSet.dtSummaryDataTable dt = new rptDataSet.dtSummaryDataTable();
                    DataSet ds = new DataSet();


                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {

                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = "EXEC Monthly_Summary  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailySummary>(reader).ToList();

                            var DataWithinDate = Data.Where(o => o.TransDate >= dFFDate && o.TransDate <= dTTDate);

                            var DataWithinDateForTable = DataWithinDate.Where(o => o.Category != "Opening Cash In Hand" && o.Category != "Closing Cash In Hand");

                            var DataForCashIn = DataWithinDateForTable.Where(o => o.Category == "Income" || o.Category == "Sales" || o.Category == "Cash Collection");


                            var DataForCashOut = DataWithinDateForTable.Where(o => o.Category == "Purchase");
                            var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" || o.Category == "Cash Delivery");

                            double CashIn = (double)DataForCashIn.Sum(o => o.IncomeAmt);
                            double CashOut = (double)DataForCashOut.Sum(o => o.IncomeAmt) + (double)DataForCashOut2.Sum(o => o.ExpenseAmt);
                          
                            double OpeningCashInHand = (double)DataWithinDate.Where(s => s.Category == "Opening Cash In Hand").Select(o => o.ExpenseAmt).First();
                            double ClosingCashInHand = (double)DataWithinDate.Where(s => s.Category == "Closing Cash In Hand").Select(o => o.ExpenseAmt).First();

                            foreach (var obj in DataWithinDateForTable)
                            {

                                double TotalAsset = OpeningCashInHand + CashIn - CashOut + (double)obj.BankBalance + (double)obj.CustomerDue + (double)obj.CurrentStockValue + (double)obj.FixedAssetValue + (double)obj.CurrentAssetValue;
                                double Liabilities = (double)(obj.SupplierDue + obj.Loan + obj.ReturnProductValue + obj.DamageProductValue + obj.TotalLiabilities);
                                int id = 1;
                                if (obj.Category == "Purchase")
                                {
                                    id = 1;
                                }
                                else if (obj.Category == "Sales")
                                {
                                    id = 2;
                                }
                                else if (obj.Category == "Cash Collection")
                                {
                                    id = 3;
                                }
                                else if (obj.Category == "Cash Delivery")
                                {
                                    id = 4;
                                }
                                else if (obj.Category == "Income")
                                {
                                    id = 5;
                                }
                                else if (obj.Category == "Expense")
                                {
                                    id = 6;
                                }
                                else
                                {
                                    id = 7;
                                }

                                dt.Rows.Add(obj.TransDate,
                                     id,
                                     obj.Category,

                                     obj.Name,
                                     obj.Quantity,
                                     obj.TotalAmount,
                                     obj.IncomeAmt,
                                     obj.ExpenseAmt,
                                     CashIn,
                                     CashOut,
                                     OpeningCashInHand,
                                     CashIn - CashOut,

                                     obj.BankBalance,
                                     obj.CustomerDue,
                                     obj.CurrentStockValue,
                                     obj.FixedAssetValue,
                                     obj.CurrentAssetValue,
                                      TotalAsset,
                                     obj.SupplierDue,
                                     obj.Loan,
                                     obj.DamageProductValue,
                                     obj.ReturnProductValue,
                                     Liabilities,
                                     TotalAsset - Liabilities
                                     );
                            }



                        }
                    }

                    dt.TableName = "rptDataSet_dtSummary";
                    ds.Tables.Add(dt);

                    string embededResource = "INVENTORY.UI.RDLC.rptSummary.rdlc";

                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("Date", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);

                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CName", "");
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

                if (rbYearly.Checked)
                {


                    DateTime fromDate = new DateTime(dtpYearly.Value.Year, 1, 1);
                    DateTime toDate = (new DateTime(dtpYearly.Value.AddYears(1).Year, 1, 1)).AddDays(-1);

                    string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);

                    rptDataSet.dtSummaryDataTable dt = new rptDataSet.dtSummaryDataTable();
                    DataSet ds = new DataSet();


                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {

                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = "EXEC Yearly_Summary  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailySummary>(reader).ToList();

                            var DataWithinDate = Data.Where(o => o.TransDate >= dFFDate && o.TransDate <= dTTDate);

                            var DataWithinDateForTable = DataWithinDate.Where(o => o.Category != "Opening Cash In Hand" && o.Category != "Closing Cash In Hand");

                            var DataForCashIn = DataWithinDateForTable.Where(o => o.Category == "Income" || o.Category == "Sales" || o.Category == "Cash Collection");

                            var DataForCashOut = DataWithinDateForTable.Where(o => o.Category == "Purchase");
                            var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" || o.Category == "Cash Delivery");

                            double CashIn = (double)DataForCashIn.Sum(o => o.IncomeAmt);
                            double CashOut = (double)DataForCashOut.Sum(o => o.IncomeAmt) + (double)DataForCashOut2.Sum(o => o.ExpenseAmt);
                          
                            double OpeningCashInHand = (double)DataWithinDate.Where(s => s.Category == "Opening Cash In Hand").Select(o => o.ExpenseAmt).First();
                            double ClosingCashInHand = (double)DataWithinDate.Where(s => s.Category == "Closing Cash In Hand").Select(o => o.ExpenseAmt).First();

                            foreach (var obj in DataWithinDateForTable)
                            {

                                double TotalAsset = OpeningCashInHand + CashIn - CashOut + (double)obj.BankBalance + (double)obj.CustomerDue + (double)obj.CurrentStockValue + (double)obj.FixedAssetValue + (double)obj.CurrentAssetValue;
                                double Liabilities = (double)(obj.SupplierDue + obj.Loan + obj.ReturnProductValue + obj.DamageProductValue + obj.TotalLiabilities);
                                int id = 1;
                                if (obj.Category == "Purchase")
                                {
                                    id = 1;
                                }
                                else if (obj.Category == "Sales")
                                {
                                    id = 2;
                                }
                                else if (obj.Category == "Cash Collection")
                                {
                                    id = 3;
                                }
                                else if (obj.Category == "Cash Delivery")
                                {
                                    id = 4;
                                }
                                else if (obj.Category == "Income")
                                {
                                    id = 5;
                                }
                                else if (obj.Category == "Expense")
                                {
                                    id = 6;
                                }
                                else
                                {
                                    id = 7;
                                }


                                dt.Rows.Add(obj.TransDate,
                                    id,
                                    obj.Category,

                                    obj.Name,
                                    obj.Quantity,
                                    obj.TotalAmount,
                                    obj.IncomeAmt,
                                    obj.ExpenseAmt,
                                    CashIn,
                                    CashOut,
                                    OpeningCashInHand,
                                    CashIn - CashOut,
                                    obj.BankBalance,
                                    obj.CustomerDue,
                                    obj.CurrentStockValue,
                                    obj.FixedAssetValue,
                                    obj.CurrentAssetValue,
                                     TotalAsset,
                                    obj.SupplierDue,
                                    obj.Loan,
                                    obj.DamageProductValue,
                                    obj.ReturnProductValue,
                                    Liabilities,
                                    TotalAsset - Liabilities
                                    );
                            }



                        }
                    }

                    dt.TableName = "rptDataSet_dtSummary";
                    ds.Tables.Add(dt);

                    string embededResource = "INVENTORY.UI.RDLC.rptSummary.rdlc";

                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("Date", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);

                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CName", "");
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
