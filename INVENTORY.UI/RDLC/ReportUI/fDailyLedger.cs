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
    public partial class fDailyLedger : Form
    {
        DEWSRMEntities db = null;

        
        public fDailyLedger()
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
                DateTime dFFDate = DateTime.Now;
                DateTime dTTDate = DateTime.Now;
                string sFFdate = string.Empty;
                string sTTdate = string.Empty;

                TransactionalDataSet.dtDailyCashbookLedgerDataTable dt = new TransactionalDataSet.dtDailyCashbookLedgerDataTable();

                double PCashInHandAmt = 0;
                double TotalIncomeAmt = 0;
              
                double CCashInHandAmt = 0;
                double TotalPayable = 0;
                double TotalRecivable = 0;

                double OpeningCashInhand = 0;
                double CurrentCashInhand = 0;
                double ClosingCashInhand = 0;

                if(rbDay.Checked)
                {
                    sFFdate = dtpDay.Value.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    sTTdate = dtpDay.Value.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    dFFDate = Convert.ToDateTime(sFFdate);
                    dTTDate = Convert.ToDateTime(sTTdate);
                }
                else if(rbMonth.Checked)
                {
                    fromDate = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, 1);
                    toDate = (new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.AddMonths(1).Month, 1)).AddDays(-1);
                

          

                    sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                   dFFDate = Convert.ToDateTime(sFFdate);
                   dTTDate = Convert.ToDateTime(sTTdate);
                }
                else
                {
                    fromDate = new DateTime(dtYear.Value.Year, 1, 1);
                    toDate = (new DateTime(dtYear.Value.AddYears(1).Year, 1, 1)).AddDays(-1);
                  

                    DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);

                    sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    dFFDate = Convert.ToDateTime(sFFdate);
                    dTTDate = Convert.ToDateTime(sTTdate);
                }

                if (rbMonth.Checked || rbDay.Checked || rbYear.Checked)
                {
                    try
                    {
                        PCashInHandAmt = 0;
                        TotalIncomeAmt = 0;
                        TotalPayable = 0;
                        CCashInHandAmt = 0;
                        TotalRecivable = 0;
                        List<DailyCashBookLedgerModel> DataForTable =null;
                        List<DailyCashBookLedgerModel> DataForTotal =null;
                        List<DailyCashBookLedgerModel> DataForOpening = null;
                        List<DailyCashBookLedgerModel> DataForCurrent = null;
                        List<DailyCashBookLedgerModel> DataForClosing = null;
                       

                        using (DEWSRMEntities db1 = new DEWSRMEntities())
                        {
                            using (var connection = db1.Database.Connection)
                            {
                                connection.Open();
                                var command = connection.CreateCommand();
                                if(rbDay.Checked)
                                {
                                    command.CommandText = "EXEC sp_DailyCashInHand  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                                }
                                else if (rbMonth.Checked)
                                {
                                    command.CommandText = "EXEC sp_DailyCashBookLedger4  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                                }
                                 else
                                {
                                    command.CommandText = "EXEC sp_DailyCashBookLedger5  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                                }
                                
                                var reader = command.ExecuteReader();
                                var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailyCashBookLedgerModel>(reader).ToList();

                               DataForTable = Data.Where(o => o.Expense != "Total Payable" && o.Income != "Total Receivable" && o.Expense != "Current Cash In Hand" && o.Income != "Closing Cash In Hand" && o.Income != "Opening Cash In Hand").ToList();
                               DataForTotal = Data.Where(o => o.Expense == "Total Payable" && o.Income == "Total Receivable").ToList();
                               DataForOpening = Data.Where(o => o.Income == "Opening Cash In Hand").ToList();
                               DataForCurrent = Data.Where(o => o.Expense == "Current Cash In Hand").ToList();
                               DataForClosing = Data.Where(o => o.Expense == "Closing Cash In Hand").ToList();
                                //var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" || o.Category == "Cash Delivery");

                                //double CashIn = (double)DataForCashIn.Sum(o => o.IncomeAmt);

                               TotalPayable = (double)DataForTotal.Sum(o=>o.ExpenseAmt);
                               TotalRecivable = (double)DataForTotal.Sum(o => o.IncomeAmt);
                               OpeningCashInhand = (double)DataForOpening.Sum(o => o.IncomeAmt);

                               CurrentCashInhand = (double)DataForCurrent.Sum(o => o.ExpenseAmt);
                               ClosingCashInhand = OpeningCashInhand + CurrentCashInhand;


                            
                               foreach (var item in DataForTable)
                                {
                                


                                        dt.Rows.Add(item.TransDate, item.id, item.Expense, item.ExpenseAmt, item.Income, item.IncomeAmt);
                                    
                                    
                                }





                               
                            }
                        }

                        DataSet ds = new DataSet();

                        string embededResource = string.Empty;
                        dt.TableName = "TransactionalDataset_dtDailyCashBookLedger";
                        ds.Tables.Add(dt);

                        embededResource = "ESRP.UI.RDLC.rptDailyCashStatement.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("DateRange", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);
                        rParam = new ReportParameter("TotalPayable", TotalPayable.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalRecivable", TotalRecivable.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("OpeningCashInhand", OpeningCashInhand.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("CurrentCashInhand", CurrentCashInhand.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("ClosingCashInHand", ClosingCashInhand.ToString());
                        parameters.Add(rParam);
            


                        

                        fReportViewer frm = new fReportViewer();
                        //if (dt.Rows.Count > 0)
                        //{
                            frm.CommonReportViewer(embededResource, ds, parameters, true);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else if(rbYear.Checked)
                {

                    PCashInHandAmt = 0;
                    TotalIncomeAmt = 0;
                    TotalPayable = 0;
                    CCashInHandAmt = 0;
                    TotalRecivable = 0;
                    List<DailyCashBookLedgerModel> DataForTable = null;
                    List<DailyCashBookLedgerModel> DataForTotal = null;
                    List<DailyCashBookLedgerModel> DataForOpening = null;
                    List<DailyCashBookLedgerModel> DataForCurrent = null;
                    List<DailyCashBookLedgerModel> DataForClosing = null;

                    fromDate = new DateTime(dtYear.Value.Year, 1, 1);
                    toDate = (new DateTime(dtYear.Value.AddYears(1).Year, 1, 1)).AddDays(-1);
                   
                    DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                    String RDate = Date.ToString("dd MMM yyyy");
                    DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                    sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                    dFFDate = Convert.ToDateTime(sFFdate);
                    dTTDate = Convert.ToDateTime(sTTdate);

                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {
                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = "EXEC sp_DailyCashBookLedger5  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailyCashBookLedgerModel>(reader).ToList();

                            DataForTable = Data.Where(o => o.Expense != "Total Payable" && o.Income != "Total Receivable" && o.Expense != "Current Cash In Hand" && o.Income != "Closing Cash In Hand" && o.Income != "Opening Cash In Hand").ToList();
                            DataForTotal = Data.Where(o => o.Expense == "Total Payable" && o.Income == "Total Receivable").ToList();
                            DataForOpening = Data.Where(o => o.Income == "Opening Cash In Hand").ToList();
                            DataForCurrent = Data.Where(o => o.Expense == "Current Cash In Hand").ToList();
                            DataForClosing = Data.Where(o => o.Expense == "Closing Cash In Hand").ToList();
                            //var DataForCashOut2 = DataWithinDateForTable.Where(o => o.Category == "Expense" || o.Category == "Cash Delivery");

                            //double CashIn = (double)DataForCashIn.Sum(o => o.IncomeAmt);

                            TotalPayable = (double)DataForTotal.Sum(o => o.ExpenseAmt);
                            TotalRecivable = (double)DataForTotal.Sum(o => o.IncomeAmt);
                            OpeningCashInhand = (double)DataForOpening.Sum(o => o.IncomeAmt);

                            CurrentCashInhand = (double)DataForCurrent.Sum(o => o.ExpenseAmt);
                            ClosingCashInhand = (double)DataForClosing.Sum(o => o.ExpenseAmt);

                            foreach (var item in Data)
                            {
                                if (item.Income == "Opening Cash In Hand")
                                    PCashInHandAmt = (double)item.IncomeAmt;

                                if (item.Expense == "Total Payable")
                                    TotalPayable = (double)item.ExpenseAmt;

                                if (item.Income == "Total Receivable")
                                    TotalRecivable = (double)item.IncomeAmt;

                                if (item.Income == "Total Receivable" || item.Income == "Opening Cash In Hand" || item.Income == "Total Amount" || item.Expense == "Current Cash In Hand")
                                {

                                }
                                else
                                {
                                    dt.Rows.Add(item.TransDate, item.id, item.Expense, item.ExpenseAmt, item.Income, item.IncomeAmt);
                                    TotalIncomeAmt = TotalIncomeAmt + (double)item.IncomeAmt;
                                }
                            }

                            if (PCashInHandAmt < 0)
                            {
                                TotalPayable = TotalPayable - PCashInHandAmt;
                                CCashInHandAmt = TotalIncomeAmt - TotalPayable;
                            }
                            else
                            {
                                TotalIncomeAmt = TotalIncomeAmt + PCashInHandAmt;
                                CCashInHandAmt = TotalIncomeAmt - TotalPayable;
                            }
                        }
                    }
                    DataSet ds = new DataSet();

                    string embededResource = string.Empty;
                    dt.TableName = "TransactionalDataset_dtDailyCashBookLedger";
                    ds.Tables.Add(dt);
                    embededResource = "ESRP.UI.RDLC.rptDailyCashStatement.rdlc";

                    embededResource = "ESRP.UI.RDLC.rptDailyCashStatement.rdlc";
                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("DateRange", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);
                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);
                    rParam = new ReportParameter("TotalPayable", TotalPayable.ToString());
                    parameters.Add(rParam);

                    rParam = new ReportParameter("TotalRecivable", TotalRecivable.ToString());
                    parameters.Add(rParam);

                    rParam = new ReportParameter("OpeningCashInhand", OpeningCashInhand.ToString());
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CurrentCashInhand", CurrentCashInhand.ToString());
                    parameters.Add(rParam);

                    rParam = new ReportParameter("ClosingCashInHand", ClosingCashInhand.ToString());
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
