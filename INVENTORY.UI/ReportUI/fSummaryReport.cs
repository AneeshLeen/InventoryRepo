using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVENTORY.DA;
using Microsoft.Reporting.WinForms;

namespace INVENTORY.UI
{
    public partial class fSummaryReport : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;
        public fSummaryReport()
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
                    CreditSale oCreditSales = new CreditSale();
                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";
                    dFFdate = Convert.ToDateTime(dFromDate);
                    dTTdate = Convert.ToDateTime(sToDate);

                    var oCaSales = (from cs in db.SOrders
                                    where (cs.InvoiceDate >= dFFdate && cs.InvoiceDate <= dTTdate)
                                    select new
                                    {
                                        cs.InvoiceDate,
                                        cs.GrandTotal,
                                        cs.RecAmount,
                                        cs.TDAmount,
                                        cs.PaymentDue,
                                    }
                                 );

                    var oCSales = (from cs in db.CreditSales
                                   where (cs.SalesDate >= dFFdate && cs.SalesDate <= dTTdate)
                                   select new
                                   {
                                       cs.SalesDate,
                                       cs.TSalesAmt,
                                       cs.NetAmount,
                                       cs.Discount,
                                       cs.Remaining,
                                       cs.FixedAmt,
                                       cs.DownPayment
                                   }
                                  );
                    var oCSalesDetails = (from csd in db.CreditSalesDetails
                                          where ((csd.PaymentDate >= dFFdate && csd.PaymentDate <= dTTdate) && csd.PaymentStatus == "Paid")
                                          select new
                                          {
                                              csd.PaymentDate,
                                              csd.InstallmentAmt,

                                          }
                                 );

                    var oExpense = (from csd in db.Expenditures
                                    where (csd.EntryDate >= dFFdate && csd.EntryDate <= dTTdate)
                                    select new
                                    {
                                        csd.EntryDate,
                                        csd.Amount,

                                    }
                                ).ToList();

                    var oCashCollections = (from csd in db.CashCollections
                                            where (csd.EntryDate >= dFFdate && csd.EntryDate <= dTTdate && csd.TransactionType == (int)EnumTranType.FromCustomer)
                                    select new
                                    {
                                        csd.EntryDate,
                                        csd.Amount,

                                    }
                               ).ToList();

                    var oCaSs = oCaSales.ToList();
                    var oCSs = oCSales.ToList();
                    var oCSDs = oCSalesDetails.ToList();
                    var oCaSsSum = oCaSs.GroupBy(x => 1).Select(x => new
                    {
                        TCaSales = x.Sum(k => k.GrandTotal),
                        TCaDis = x.Sum(k => k.TDAmount),
                        TCaDue = x.Sum(k => k.PaymentDue),
                        TCaRec = x.Sum(k => k.RecAmount)
                    }).ToList();
                    var oCSSum = oCSs.GroupBy(x => 1).Select(x => new
                    {
                        TSales = x.Sum(k => k.TSalesAmt),
                        TDis = x.Sum(k => k.Discount),
                        TdownPay = x.Sum(k => k.DownPayment),
                        TRemain = x.Sum(k => k.Remaining),
                        TFixed = x.Sum(k => k.FixedAmt)
                    }).ToList();

                    var oCSDSum = oCSDs.GroupBy(x => 1).Select(x => new
                    {
                        TInstallments = x.Sum(k => k.InstallmentAmt),

                    }).ToList();
                    var oExpSum = oExpense.GroupBy(x => 1).Select(x => new
                    {
                        TAmount = x.Sum(k => k.Amount),

                    }).ToList();
                    var oCashCollectionsSum = oCashCollections.GroupBy(x => 1).Select(x => new
                    {
                        TCashAmount = x.Sum(k => k.Amount),

                    }).ToList();

                    rptDataSet.dtSummaryReportDataTable dt = new rptDataSet.dtSummaryReportDataTable();
                    DataSet ds = new DataSet();
                    DataRow dr = null;

                    dr = dt.NewRow();

                    if (oCaSsSum.Count > 0)
                    {
                        dr["SellingPriceCash"] = oCaSsSum[0].TCaSales;
                        dr["ReceivedAmountCash"] = oCaSsSum[0].TCaRec;
                        dr["DiscountAmountCash"] = oCaSsSum[0].TCaDis;
                        dr["PaymentDueCash"] = oCaSsSum[0].TCaDue;
                    }
                    else
                    {
                        dr["SellingPriceCash"] = 0;
                        dr["ReceivedAmountCash"] = 0;
                        dr["DiscountAmountCash"] = 0;
                        dr["PaymentDueCash"] = 0;
                    }

                    if (oCSSum.Count > 0)
                    {
                        dr["SellingPriceCredit"] = oCSSum[0].TSales;
                        dr["ReceivedAmountDownPay"] = oCSSum[0].TdownPay;
                        dr["DiscountAmountCredit"] = oCSSum[0].TDis;
                        dr["RemainigAmountCredit"] = oCSSum[0].TRemain;
                        dr["ReceivedAmountFixed"] = oCSSum[0].TFixed;
                    }
                    else
                    {
                        dr["SellingPriceCredit"] = 0;
                        dr["ReceivedAmountDownPay"] = 0;
                        dr["DiscountAmountCredit"] = 0;
                        dr["RemainigAmountCredit"] = 0;
                        dr["ReceivedAmountFixed"] = 0;

                    }

                    if (oCSDSum.Count > 0)
                    {
                        dr["ReceivedAmountCredit"] = oCSDSum[0].TInstallments;
                    }
                    else
                    {
                        dr["ReceivedAmountCredit"] = 0;
                    }

                    if (oExpSum.Count > 0)
                    {
                        dr["ExpenseAmount"] = oExpSum[0].TAmount;
                    }
                    else
                    {
                        dr["ExpenseAmount"] = 0;
                    }
                    if (oCashCollectionsSum.Count > 0)
                    {
                        dr["CashCollectionAmount"] = oCashCollectionsSum[0].TCashAmount;
                    }
                    else
                    {
                        dr["CashCollectionAmount"] = 0;
                    }
                    dt.Rows.Add(dr);

                    dt.TableName = "rptDataSet_dtSummaryReport";
                    ds.Tables.Add(dt);
                    string embededResource = "INVENTORY.UI.RDLC.rptSummaryReport.rdlc";

                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();

                    rParam = new ReportParameter("Date", dFFdate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);

                    rParam = new ReportParameter("ToDate", dTTdate.ToString("dd MMM yyyy"));
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
