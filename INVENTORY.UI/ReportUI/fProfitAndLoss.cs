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
    public partial class fProfitAndLoss : Form
    {
        DEWSRMEntities db = null;

        public fProfitAndLoss()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                double PMProfit = 0;
                double CMProfit = 0;
                double TotalExpense = 0;
                double TotalAmt = 0;
                double TotalIncomeAmt = 0;
                double NetExpense = 0;
                double NetIncome = 0;

                DateTime fromDate = dtpMonthly.Value;
                DateTime toDate = dtpDaily.Value;
                TransactionalDataSet.dtDailyCashbookLedgerDataTable dt = new TransactionalDataSet.dtDailyCashbookLedgerDataTable();

                    PMProfit = 0;
                    CMProfit = 0;
                    TotalExpense = 0;
                    //TotalAmt = 0;
                    TotalIncomeAmt = 0;
                    NetExpense = 0;
                    NetIncome = 0;
                    string SPName = string.Empty;
                    string PMPStatus = string.Empty;
                    string CMLStatus = string.Empty;

                    if(rbDaily.Checked)
                    {
                        fromDate = dtpDaily.Value;
                        toDate = fromDate;
                        SPName = "EXEC sp_ProfitLossReportDaily  ";
                        PMPStatus="Previous Profit";
                        CMLStatus = "Current Day profit";
                    }
                    else if(rbMonth.Checked)
                    {
                        fromDate = new DateTime(dtpMonthly.Value.Year, dtpMonthly.Value.Month, 1);
                        toDate = fromDate.AddMonths(1).AddDays(-1);
                        SPName = "EXEC sp_ProfitLossReport  ";
                        PMPStatus = "Previous Profit";
                        CMLStatus = "Current Month profit";
                    }
                    else
                    {
                        fromDate = new DateTime(dtYear.Value.Year, 1, 1);
                        toDate = (new DateTime(dtYear.Value.AddYears(1).Year, 1, 1)).AddDays(-1);
                        SPName = "EXEC sp_ProfitLossReportYearly  ";
                        PMPStatus = "Previous Profit";
                        CMLStatus = "Current Year profit";
                    }

                    string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);

                    DataSet ds = new DataSet();
                    string embededResource = "";
                    dt.TableName = "TransactionalDataset_dtDailyCashBookLedger";
                    ds.Tables.Add(dt);
                    embededResource = "INVENTORY.UI.RDLC.rptProfit.rdlc";
                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();

                    using (DEWSRMEntities db1 = new DEWSRMEntities())
                    {
                        using (var connection = db1.Database.Connection)
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText = SPName + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                            var reader = command.ExecuteReader();
                            var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<DailyCashBookLedgerModel>(reader).ToList();

                            foreach (var item in Data)
                            {
                                if (item.Income == "Previous Profit")
                                    PMProfit = (double)item.IncomeAmt;

                                if (item.Expense == "Total Expense")
                                    TotalExpense = (double)item.ExpenseAmt;

                                if (item.Income == "Total Income")
                                    TotalIncomeAmt = (double)item.IncomeAmt;

                                if (item.Income == "Total Profit")
                                    TotalAmt = (double)item.IncomeAmt;

                                if (item.Income == "Current Profit")
                                    CMProfit = (double)item.IncomeAmt;

                                if (item.Income == "Previous Profit" || item.Income == "Total Profit" || item.Expense == "Current Profit" || item.Expense == "Total Expense")
                                {

                                }
                                else
                                {
                                    dt.Rows.Add(item.TransDate, item.id, item.Expense, item.ExpenseAmt, item.Income, item.IncomeAmt);
                                    TotalIncomeAmt = TotalIncomeAmt + (double)item.IncomeAmt;
                                }

                            }

                        }

                    }

                
                    rParam = new ReportParameter("DateRange", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);
                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("TotalExpense", TotalExpense.ToString());
                    parameters.Add(rParam);         
                    rParam = new ReportParameter("TotalIncomeAmt", TotalIncomeAmt.ToString());
                    parameters.Add(rParam);
                              
                    rParam = new ReportParameter("PMProfit", PMProfit.ToString());
                    parameters.Add(rParam);
                  

                    rParam = new ReportParameter("PMPStatus", PMPStatus);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CMLStatus", CMLStatus);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CMProfit", CMProfit.ToString());
                    parameters.Add(rParam);

                    rParam = new ReportParameter("TotalAmt", TotalAmt.ToString());
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
