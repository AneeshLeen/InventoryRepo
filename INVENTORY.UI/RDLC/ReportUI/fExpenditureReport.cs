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

namespace ESRP.UI
{
    public partial class fExpenditureReport : Form
    {
        public fExpenditureReport()
        {
            InitializeComponent();
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";

                    DateTime fromDate = Convert.ToDateTime(dFromDate);//dtpFromDate.Value;
                    DateTime toDate = Convert.ToDateTime(sToDate);//dtpToDate.Value;


                    List<Expenditure> oExpenditures = null;
                    var oExpenseData = (dynamic)null;
                    //var oExpensColl = (dynamic)null;

                    if(rbAllExpense.Checked)
                    {
                        oExpenseData = (from exps in db.Expenditures
                                        join exi in db.ExpenseItems on exps.ExpenseItemID equals exi.ExpenseItemID
                                        where (exps.EntryDate >= fromDate && exps.EntryDate <= toDate && exps.Status==(int)EnumExpenseType.Expense)
                                        group exps by new
                                        {
                                            exps.EntryDate,
                                            exi.Description,
                                            exps.Purpose
                                        } into g
                                        select new
                                        {

                                            EntryDate = g.Key.EntryDate,
                                            ItemName = g.Key.Description,
                                            Purpose = g.Key.Purpose,
                                            Amount = g.Sum(i3 => i3.Amount)
                                        });
                        rbAllExpense.Checked = false;
                    }
                    else if(rbAllIncome.Checked)
                    {
                        oExpenseData = (from exps in db.Expenditures
                                        join exi in db.ExpenseItems on exps.ExpenseItemID equals exi.ExpenseItemID
                                        where (exps.EntryDate >= fromDate && exps.EntryDate <= toDate && exps.Status == (int)EnumExpenseType.Income)
                                        group exps by new
                                        {
                                            exps.EntryDate,
                                            exi.Description,
                                            exps.Purpose
                                        } into g
                                        select new
                                        {

                                            EntryDate = g.Key.EntryDate,
                                            ItemName = g.Key.Description,
                                            Purpose = g.Key.Purpose,
                                            Amount = g.Sum(i3 => i3.Amount)
                                        });
                        rbAllIncome.Checked = false;
                    }
                    else if(ctlExpense.SelectedID>0)
                    {
                        oExpenditures=db.Expenditures.Where(o => o.EntryDate >= fromDate && o.EntryDate <= toDate && o.ExpenseItemID == ctlExpense.SelectedID).ToList();                      
                        ctlExpense.SelectedID = 0;
                    }

                    if (oExpenseData != null || oExpenditures!=null)
                    {
                        rptDataSet.dtExpenditureDataTable dt = new rptDataSet.dtExpenditureDataTable();
                        DataSet ds = new DataSet();
                        //oExpensColl = oExpenseData.ToList();

                        if(oExpenditures!=null)
                        {
                            foreach (Expenditure grd in oExpenditures)
                            {
                                dt.Rows.Add(grd.EntryDate, grd.Purpose, grd.Amount, grd.ExpenseItem.Description);
                            }
                        }
                        else
                        {
                            foreach (var grd in oExpenseData)
                            {
                                dt.Rows.Add(grd.EntryDate, grd.Purpose, grd.Amount, grd.ItemName);
                            }
                        }


                        dt.TableName = "rptDataSet_dtExpenditure";
                        ds.Tables.Add(dt);
                        string embededResource = "ESRP.UI.RDLC.rptExpenditure.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        string sStatus = string.Empty;

                        if(rbAllExpense.Checked)
                        {
                            sStatus = "Expenditure Report From ";
                        }
                        else
                        {
                            sStatus = "Income Report From ";
                        }

                        rParam = new ReportParameter("Month",  sStatus + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }

        }

        private void fExpenditureReport_Load(object sender, EventArgs e)
        {
            rbAllExpense.Checked = false;
            rbAllIncome.Checked = false;
            ctlExpense.SelectedID = 0;
        }

        private void ctlExpense_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
