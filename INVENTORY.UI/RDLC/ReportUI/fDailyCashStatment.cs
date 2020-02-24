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
    public partial class fDailyCashStatment : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;
        public fDailyCashStatment()
        {
            InitializeComponent();
        }

        private void fDailyCollection_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    fReportViewer fRptViewer = new fReportViewer();
                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpFromDate.Text + " 11:59:59 PM";
                    dFFdate = Convert.ToDateTime(dFromDate);
                    dTTdate = Convert.ToDateTime(sToDate);

                    rptDataSet.dtDailyCashStatementDataTable dt = new rptDataSet.dtDailyCashStatementDataTable();
                    DataSet ds = new DataSet();
                    DataRow dr = null;

                    dr = dt.NewRow();
                    PrevBalance opening = db.PrevBalances.FirstOrDefault(x => x.Date == dFFdate);
                    dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), "Opening Balance", opening!=null?opening.Amount:0, 0, "Cash In Hand", "", "");
                    var oCaSales = (from cs in db.SOrders
                                    where (cs.InvoiceDate >= dFFdate && cs.InvoiceDate <= dTTdate && cs.Status==1)
                                    select new
                                    {
                                        cs.InvoiceDate,
                                        cs.GrandTotal,
                                        PaidAmount=cs.RecAmount-cs.BackAmount,
                                        cs.TDAmount,
                                        cs.TotalDue
                                    }
                                 );

                     var oPurchase = (from cs in db.POrders
                                      where (cs.OrderDate >= dFFdate && cs.OrderDate <= dTTdate && cs.Status==1)
                                     select new
                                     {
                                         cs.OrderDate,
                                         cs.GrandTotal,
                                         cs.RecAmt,
                                         cs.NetDiscount,
                                         cs.TotalDue
                                     }
                                );

                    var oExpense = (from exp in db.Expenditures
                                    from expi in db.ExpenseItems  
                                    where (expi.ExpenseItemID == exp.ExpenseItemID  && exp.EntryDate >= dFFdate && exp.EntryDate <= dTTdate)
                                    select new
                                    {
                                        exp.EntryDate,
                                        expi.Description,
                                        exp.Amount,
                                        exp.Purpose,
                                        expi.Status,
                                        exp.VoucherName,
                                        exp.Remarks
                                   }
                                ).ToList();
                    
                    var oExpItems = oExpense.Where(x => x.Status == (int)EnumExpenseType.Expense).ToList();
                    foreach (var item in oExpItems)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), item.Description, 0, item.Amount, item.Purpose, item.VoucherName, item.Remarks);   
                    }
                    var oIncomeItems = oExpense.Where(x => x.Status == (int)EnumExpenseType.Income).ToList();
                    foreach (var item in oIncomeItems)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), item.Description, item.Amount,0 , item.Purpose,  item.VoucherName, "");
                    }
                    

                    var oCashCollections = (from csd in db.CashCollections
                                            where (csd.EntryDate >= dFFdate && csd.EntryDate <= dTTdate && csd.TransactionType == (int)EnumTranType.FromCustomer)
                                    select new
                                    {
                                        csd.EntryDate,
                                        csd.Amount,
                                        csd.PaymentType,
                                        csd.CheckNo
                                    }
                               ).ToList();
                    foreach (var item in oCashCollections)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), "Cash Collection", item.Amount, 0, ((EnumTranType)item.PaymentType).ToString(), item.CheckNo, "");
                    }

                    var oCashPayments = (from csd in db.CashCollections
                                            where (csd.EntryDate >= dFFdate && csd.EntryDate <= dTTdate && csd.TransactionType == (int)EnumTranType.ToCompany)
                                            select new
                                            {
                                                csd.EntryDate,
                                                csd.Amount,
                                                csd.PaymentType,
                                                csd.CheckNo
                                                
                                            }
                              ).ToList();

                    foreach (var item in oCashPayments)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), "Cash Payment", 0, item.Amount, ((EnumTranType)item.PaymentType).ToString(), item.CheckNo, "");
                    }
                    var oCaSs = oCaSales.ToList();
                   
                    var oCaSsSum = oCaSs.GroupBy(x => 1).Select(x => new
                    {
                        TCaSales = x.Sum(k => k.GrandTotal),
                        TCaDis = x.Sum(k => k.TDAmount),
                        TCaDue = x.Sum(k => k.TotalDue),
                        TCaRec = x.Sum(k => k.PaidAmount)
                    }).ToList();
                    
                    var oPurchaseSum = oPurchase.GroupBy(x => 1).Select(x => new
                    {
                        TCaSales = x.Sum(k => k.GrandTotal),
                        TCaDis = x.Sum(k => k.NetDiscount),
                        TCaDue = x.Sum(k => k.TotalDue),
                        TCaRec = x.Sum(k => k.RecAmt)
                    }).ToList();
                    

                    if (oCaSsSum.Count > 0)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), "Showroom", oCaSsSum[0].TCaRec, 0, "Cash", "", "");
                    }
                    if (oPurchaseSum.Count > 0)
                    {
                        dr = dt.NewRow();
                        dt.Rows.Add(dFFdate.ToString("dd MMM yyyy"), "Total Purchase", 0, oPurchaseSum[0].TCaRec, "Cash", "", "");
                    }
                   

                    dt.TableName = "rptDataSet_dtDailyCashStatement";
                    ds.Tables.Add(dt);
                    string embededResource = "ESRP.UI.RDLC.rptDailyCashStatment.rdlc";

                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();

                    rParam = new ReportParameter("Month", dFFdate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);

                    //rParam = new ReportParameter("ToDate", dTTdate.ToString("dd MMM yyyy"));
                    //parameters.Add(rParam);

                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);
                    //if (oCaSsSum.Count > 0)
                    //{
                    //    rParam = new ReportParameter("Sales", oCaSsSum[0].TCaRec.ToString());
                    //    parameters.Add(rParam);
                    //}
                    //else
                    //{
                    //    rParam = new ReportParameter("Sales", "0");
                    //    parameters.Add(rParam);
                    //}

                    //if (oCashCollectionsSum.Count > 0)
                    //{
                    //    rParam = new ReportParameter("DueCollection", oCashCollectionsSum[0].TCashAmount.ToString());
                    //    parameters.Add(rParam);
                    //}
                    //else
                    //{
                    //    rParam = new ReportParameter("DueCollection", "0");
                    //    parameters.Add(rParam);
                    //}

                    ////if (oPReturnSum.Count > 0)
                    ////{
                    ////    rParam = new ReportParameter("PurchReturn", oPReturnSum[0].TCaRec.ToString());
                    ////    parameters.Add(rParam);
                    ////}
                    ////else
                    ////{
                    //    rParam = new ReportParameter("PurchReturn", "0");
                    //    parameters.Add(rParam);
                    ////}

                    //    rParam = new ReportParameter("ComCommision","0");
                    //    parameters.Add(rParam);
                    
                    //if (oPurchaseSum.Count > 0)
                    //{
                    //    rParam = new ReportParameter("Purchase", oPurchaseSum[0].TCaRec.ToString());
                    //    parameters.Add(rParam);
                    //}
                    //else
                    //{
                    //    rParam = new ReportParameter("Purchase", "0");
                    //    parameters.Add(rParam);
                    //}

                    //if (oDuePaymentSum.Count > 0)
                    //{
                    //    rParam = new ReportParameter("DuePayment", oDuePaymentSum[0].TCashAmount.ToString());
                    //    parameters.Add(rParam);
                    //}
                    //else
                    //{
                    //    rParam = new ReportParameter("DuePayment", "0");
                    //    parameters.Add(rParam);
                    //}

                    //if (oExpSum.Count > 0)
                    //{
                    //    rParam = new ReportParameter("Expense", oExpSum[0].TAmount.ToString());
                    //    parameters.Add(rParam);
                    //}
                    //else
                    //{
                    //    rParam = new ReportParameter("Expense", "0");
                    //    parameters.Add(rParam);
                    //}

                    //if (oIncomeSum.Count > 0)
                    //{
                    //    rParam = new ReportParameter("income", oIncomeSum[0].TAmount.ToString());
                    //    parameters.Add(rParam);
                    //}
                    //else
                    //{
                    //    rParam = new ReportParameter("income", "0");
                    //    parameters.Add(rParam);
                    //}
                    
                    ////if (oCaSsSum.Count > 0)
                    ////{
                    ////    rParam = new ReportParameter("[@SlesReturn", oCaSsSum[0].TCaRec.ToString());
                    ////    parameters.Add(rParam);
                    ////}
                    ////else
                    ////{
                    //    rParam = new ReportParameter("SlesReturn", "0");
                    //    parameters.Add(rParam);
                    ////}

                   

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
            catch (Exception ex)
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
