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
    public partial class fYearlyBenefitShow : Form
    {
       
        rptDataSet.dtMonthlyBenefitDataTable dt = new rptDataSet.dtMonthlyBenefitDataTable();
        public fYearlyBenefitShow()
        {
            InitializeComponent();
        }

        private void fMonthlyBenefitShow_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            //try
            //{
            //    using (DEWSRMEntities db = new DEWSRMEntities())
            //    {
            //        dt = new rptDataSet.dtMonthlyBenefitDataTable();
            //        var sOrdeDetails = (from so in db.SOrders.Where(s => s.Status == 1)
            //                            join sod in db.SOrderDetails
            //                                on so.SOrderID equals sod.SOrderID
            //                            //group sod by ((DateTime)so.InvoiceDate.Value).Month into g
            //                            group sod by new { so.InvoiceDate.Year, so.InvoiceDate.Month } into g
            //                            select new
            //                            {
            //                                Month = g.Key,
            //                                SalesYear = g.Min(i => i.SOrder.InvoiceDate.Year),
            //                                SalesMonth = g.Min(i => i.SOrder.InvoiceDate.Month),
            //                                MinMonth = g.Min(i => i.SOrder.InvoiceDate),
            //                                UTAmount = g.Sum(i => i.UTAmount),
            //                                MPRateTotal = g.Sum(i => i.MPRateTotal)
            //                            }).OrderByDescending(s => s.MinMonth);

            //        var oSO = sOrdeDetails.ToList();

            //        var expenditure = (from ex in db.Expenditures.Where(ex=>ex.Status==1)
            //                           //group ex by ((DateTime)ex.EntryDate.Value).Month into e
            //                           group ex by new { ex.EntryDate.Year, ex.EntryDate.Month } into e
            //                           select new
            //                           {
            //                               Month = e.Key,
            //                               ExpYear = e.Min(i => i.EntryDate.Year),
            //                               ExpMonth = e.Min(i => i.EntryDate.Month),
            //                               MinMonth = e.Min(i => i.EntryDate),
            //                               TAmount = e.Sum(i => i.Amount)
            //                           }).OrderByDescending(s => s.MinMonth);

            //        var Income = (from ex in db.Expenditures.Where(ex => ex.Status == 2)
            //                           //group ex by ((DateTime)ex.EntryDate.Value).Month into e
            //                           group ex by new { ex.EntryDate.Year, ex.EntryDate.Month } into e
            //                           select new
            //                           {
            //                               Month = e.Key,
            //                               ExpYear = e.Min(i => i.EntryDate.Year),
            //                               ExpMonth = e.Min(i => i.EntryDate.Month),
            //                               MinMonth = e.Min(i => i.EntryDate),
            //                               TAmount = e.Sum(i => i.Amount)
            //                           }).OrderByDescending(s => s.MinMonth);

            //        var oExpenseList = expenditure.ToList();
            //        var oIcomeList = Income.ToList();

            //        ListViewItem item = null;
            //        lsvBenefit.Items.Clear();

            //        dt.Rows.Clear();

            //        if (sOrdeDetails != null)
            //        {
            //            foreach (var oItem in sOrdeDetails)
            //            {
            //                string sMonthCheck = oItem.Month.ToString();
            //                var oExpItem = expenditure.ToList().FirstOrDefault(e => e.ExpMonth == oItem.SalesMonth);
            //                var oIncomeItem = oIcomeList.ToList().FirstOrDefault(e => e.ExpMonth == oItem.SalesMonth);

            //                item = new ListViewItem();
            //                item.Text = ((DateTime)oItem.MinMonth).ToString("MMM yyyy");

            //                item.SubItems.Add(oItem.UTAmount.ToString());
            //                item.SubItems.Add(oItem.MPRateTotal.ToString());
            //                item.SubItems.Add((oItem.UTAmount - oItem.MPRateTotal).ToString());
            //                item.SubItems.Add((oIncomeItem != null ? oIncomeItem.TAmount : 0).ToString());
            //                item.SubItems.Add((oExpItem != null ? oExpItem.TAmount : 0).ToString());
            //                item.SubItems.Add((((oItem.UTAmount - oItem.MPRateTotal) + (oIncomeItem != null ? oIncomeItem.TAmount : 0))- (oExpItem != null ? oExpItem.TAmount : 0)).ToString());
            //                lsvBenefit.Items.Add(item);

            //                dt.Rows.Add(oItem.MinMonth, oItem.UTAmount, oItem.MPRateTotal, (oItem.UTAmount - oItem.MPRateTotal), (oIncomeItem != null ? oIncomeItem.TAmount : 0), (oExpItem != null ? oExpItem.TAmount : 0), (((oItem.UTAmount - oItem.MPRateTotal) + (oIncomeItem != null ? oIncomeItem.TAmount : 0)) - (oExpItem != null ? oExpItem.TAmount : 0)));

            //            }

            //            lblTotal.Text = "Total :" + sOrdeDetails.Count().ToString();
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void RefreshList111()
        {
            //try
            //{
            //    //let month = ((DateTime)so.InvoiceDate.Value).Month
            //    using (DEWSRMEntities db = new DEWSRMEntities())
            //    {
            //        var sOrdeDetails = (from so in db.SOrders
            //                             join sod in db.SOrderDetails
            //                                 on so.SOrderID equals sod.SOrderID
            //                             group sod by (so.InvoiceDate).Month into g
            //                             select new
            //                             {
            //                                 Month = g.Key,
            //                                 MinMonth=g.Min(i=>i.SOrder.InvoiceDate),
            //                                 UTAmount = g.Sum(i => i.UTAmount),
            //                                 MPRateTotal = g.Sum(i => i.MPRateTotal)
            //                             });

            //        var expenditure = from ex in db.Expenditures.Where(ex=>ex.Status==1)
            //                          group ex by ((DateTime)ex.EntryDate).Month into e
            //                          select new 
            //                          { 
            //                             Month= e.Key,
            //                             TAmount=e.Sum(i=>i.Amount)
            //                          };

                    
            //        ListViewItem item = null;
            //        lsvBenefit.Items.Clear();
                    
            //        if (sOrdeDetails != null)
            //        {
            //            foreach (var oItem in sOrdeDetails)
            //            {
            //                if (expenditure.Count()>0)
            //                {
            //                    foreach (var oEItem in expenditure)
            //                    {
            //                        if (oItem.Month == oEItem.Month)
            //                        {
            //                            item = new ListViewItem();
            //                            item.Text = ((DateTime)oItem.MinMonth).ToString("MMM yyyy");//oItem.Month.ToString();
            //                            item.SubItems.Add(oItem.UTAmount.ToString());
            //                            item.SubItems.Add(oItem.MPRateTotal.ToString());
            //                            item.SubItems.Add((oItem.UTAmount - oItem.MPRateTotal).ToString());
            //                            item.SubItems.Add(oEItem.TAmount.ToString());
            //                            item.SubItems.Add(((oItem.UTAmount - oItem.MPRateTotal) - oEItem.TAmount).ToString());
            //                            lsvBenefit.Items.Add(item);
            //                            //oItem.Month
            //                            dt.Rows.Add(oItem.MinMonth, oItem.UTAmount, oItem.MPRateTotal, (oItem.UTAmount - oItem.MPRateTotal), oEItem.TAmount, ((oItem.UTAmount - oItem.MPRateTotal) - oEItem.TAmount));
            //                        }
            //                        else
            //                        {
            //                            item = new ListViewItem();
            //                            item.Text = ((DateTime)oItem.MinMonth).ToString("MMM yyyy");//oItem.Month.ToString();
            //                            item.SubItems.Add(oItem.UTAmount.ToString());
            //                            item.SubItems.Add(oItem.MPRateTotal.ToString());
            //                            item.SubItems.Add((oItem.UTAmount - oItem.MPRateTotal).ToString());
            //                            item.SubItems.Add("0.00");
            //                            item.SubItems.Add(((oItem.UTAmount - oItem.MPRateTotal) - oEItem.TAmount).ToString());
            //                            lsvBenefit.Items.Add(item);
            //                            //oItem.Month
            //                            dt.Rows.Add(oItem.MinMonth, oItem.UTAmount, oItem.MPRateTotal, (oItem.UTAmount - oItem.MPRateTotal), 0, ((oItem.UTAmount - oItem.MPRateTotal) - 0));
            //                        }
            //                    }

            //                }
            //                else
            //                {
            //                    item = new ListViewItem();
            //                    item.Text = ((DateTime)oItem.MinMonth).ToString("MMM yyyy");//oItem.Month.ToString();
            //                    item.SubItems.Add(oItem.UTAmount.ToString());
            //                    item.SubItems.Add(oItem.MPRateTotal.ToString());
            //                    item.SubItems.Add((oItem.UTAmount - oItem.MPRateTotal).ToString());
            //                    item.SubItems.Add("0.00");
            //                    item.SubItems.Add(((oItem.UTAmount - oItem.MPRateTotal)).ToString());
            //                    lsvBenefit.Items.Add(item);
            //                    dt.Rows.Add(oItem.MinMonth, oItem.UTAmount, oItem.MPRateTotal, (oItem.UTAmount - oItem.MPRateTotal), 0, ((oItem.UTAmount - oItem.MPRateTotal) - 0));

            //                }

            //            }

            //            lblTotal.Text = "Total :" + sOrdeDetails.Count().ToString();
            //        }

            //    }

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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
              
                   try
                   {


                       DateTime fromDate = dtpFromDate.Value;
                       DateTime toDate = dtpToDate.Value;

                       var firstDayOfMonth = new DateTime(fromDate.Year,1, 1);
                       var last = new DateTime(toDate.Year, 1, 1);
                       var lastDayOfMonth = last.AddYears(1).AddDays(-1);

                       //DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                       //String RDate = Date.ToString("dd MMM yyyy");
                       //DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);



                       string sFFdate = firstDayOfMonth.ToString("dd MMM yyyy") + " 12:00:00 AM";
                       string sTTdate = lastDayOfMonth.ToString("dd MMM yyyy") + " 11:59:59 PM";
                       DateTime dFFDate = Convert.ToDateTime(sFFdate);
                       DateTime dTTDate = Convert.ToDateTime(sTTdate);

                       using (DEWSRMEntities db1 = new DEWSRMEntities())
                       {
                           using (var connection = db1.Database.Connection)
                           {
                               connection.Open();
                               var command = connection.CreateCommand();
                               command.CommandText = "EXEC YearlyBenefitReport " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
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

                       string embededResource = "INVENTORY.UI.RDLC.YearlyBenefitRpt.rdlc";
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
