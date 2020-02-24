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
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace INVENTORY.UI
{
    public partial class fDailyPurchaseRpt : Form
    {
        public fDailyPurchaseRpt()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    DateTime fromDate = dtpFromDate.Value;
                    DateTime toDate = dtpToDate.Value;
                    string sFFdate = dtpFromDate.Text + " 12:00:00 AM";
                    string sTTdate = dtpToDate.Text + " 11:59:59 PM";
                    fromDate = Convert.ToDateTime(sFFdate);
                    toDate = Convert.ToDateTime(sTTdate);
                    double GrandTotal = 0;
                    double TDiscount = 0;
                    double TotalAmount = 0;
                    double PaidAmount = 0;
                    double DueAmount = 0;
                    rptDataSet.dtDailyPurchaseOrderDataTable dt = new rptDataSet.dtDailyPurchaseOrderDataTable();
                    rptDataSet.dtReturnDetailsDataTable dtReturn = new rptDataSet.dtReturnDetailsDataTable();
                    rptDataSet.dtDailyPurchaseOrderDetailsDataTable dtDetails = new rptDataSet.dtDailyPurchaseOrderDetailsDataTable();

                    var PurchaseQuery = (from POD in db.POrderDetails
                                         join PO in db.POrders on POD.POrderID equals PO.POrderID
                                         join SUP in db.Suppliers on PO.SupplierID equals SUP.SupplierID
                                         join P in db.Products on POD.ProductID equals P.ProductID
                                         join CLR in db.Colors on POD.ColorID equals CLR.ColorID
                                         where PO.OrderDate >= fromDate && PO.OrderDate <= toDate && PO.Status == 1
                                         select new
                                         {
                                             OrderDate = PO.OrderDate,
                                             ChallanNo = PO.ChallanNo,
                                             POrderID = PO.POrderID,
                                             Code = SUP.Code,
                                             SupplierName = SUP.Name,
                                             Address = SUP.Address,
                                             P.ProductID,
                                             P.ProductName,
                                             CompanyName = P.Company.Description,
                                             categoryName = P.Category.Description,
                                             size = "",
                                             color = CLR.Description,

                                             UnitPrice = POD.MRPRate,

                                             TAmount = POD.MRPRate * POD.Quantity,
                                             PPDISAmt = (POD.PPDISAmt + ((PO.TDiscount) / (PO.GrandTotal - (PO.NetDiscount - PO.TDiscount))) * POD.UnitPrice) * POD.Quantity, //Total PP DisAmt
                                             NetPrice = (POD.MRPRate * POD.Quantity) - ((POD.PPDISAmt + ((PO.TDiscount) / (PO.GrandTotal - (PO.NetDiscount - PO.TDiscount))) * POD.UnitPrice) * POD.Quantity),
                                             Quantity = POD.Quantity,

                                             GrandTotal = PO.GrandTotal,
                                             NetDiscount = PO.NetDiscount,
                                             NetPurchase = PO.GrandTotal - PO.NetDiscount,
                                             AdjustAmt = 0m,
                                             ReceiveAmt = PO.RecAmt,
                                             Due = PO.GrandTotal - PO.NetDiscount - PO.RecAmt
                                         }).OrderBy(x => x.OrderDate);

                    var PurchaseQueryData = PurchaseQuery.ToList();

                    var PurchaseQueryGroupBy = (from pod in PurchaseQuery
                                                group pod by new { pod.POrderID, pod.ChallanNo, pod.OrderDate, } into g
                                                select new
                                                {
                                                    g.Key.ChallanNo,
                                                    g.Key.OrderDate,
                                                    g.FirstOrDefault().Code,
                                                    g.FirstOrDefault().SupplierName,
                                                    g.FirstOrDefault().Address,
                                                    g.FirstOrDefault().CompanyName,
                                                    g.FirstOrDefault().categoryName,
                                                    g.FirstOrDefault().size,
                                                    g.FirstOrDefault().color,
                                                    GrandTotal = g.FirstOrDefault().GrandTotal,
                                                    NetDiscount = g.FirstOrDefault().NetDiscount,
                                                    NetPurchase = g.FirstOrDefault().NetPurchase,
                                                    PaidAmount = g.FirstOrDefault().ReceiveAmt,
                                                    Due = g.FirstOrDefault().Due
                                                });

                    var PurchaseQueryGroupByData = PurchaseQueryGroupBy.ToList();
                    GrandTotal = (double)PurchaseQueryGroupByData.Sum(o => o.NetPurchase);
                    TDiscount = (double)PurchaseQueryGroupByData.Sum(o => o.NetDiscount);
                    PaidAmount = (double)PurchaseQueryGroupByData.Sum(o => o.PaidAmount);
                    DueAmount = GrandTotal - PaidAmount;

                    var ReturnDataQuery = (from ROD in db.ReturnDetails
                                           join RT in db.Returns on ROD.ReturnID equals RT.ReturnID
                                           join SUP in db.Suppliers on RT.SupplierID equals SUP.SupplierID
                                           join P in db.Products on ROD.ProductID equals P.ProductID
                                           join STD in db.StockDetails on ROD.SDetailID equals STD.SDetailID
                                           join CLR in db.Colors on STD.ColorID equals CLR.ColorID
                                           where RT.ReturnDate >= fromDate && RT.ReturnDate <= toDate
                                           select new
                                           {
                                               OrderDate = RT.ReturnDate,
                                               ChallanNoOrInvoice = RT.InvoiceNo,
                                               ReturnID = RT.ReturnID,
                                               Code = SUP.Code,
                                               Name = SUP.Name,
                                               Address = SUP.Address,
                                               P.ProductID,
                                               P.ProductName,
                                               CompanyName = P.Company.Description,
                                               categoryName = P.Category.Description,
                                               size = "",
                                               color = CLR.Description,
                                               Quantity = ROD.Quantity,
                                               UnitPrice = ROD.UnitPrice,
                                               GrandTotal = RT.GrandTotal,
                                               PaidAmount = RT.PaidAmount
                                           }).OrderBy(x => x.OrderDate);


                    var ReturnDataQueryGroupBY = (from pod in ReturnDataQuery
                                                  group pod by new { pod.ReturnID, pod.ChallanNoOrInvoice, pod.OrderDate } into g
                                                  select new
                                                  {
                                                      g.Key.ChallanNoOrInvoice,
                                                      g.Key.OrderDate,
                                                      g.FirstOrDefault().Code,
                                                      g.FirstOrDefault().Name,
                                                      g.FirstOrDefault().Address,
                                                      g.FirstOrDefault().CompanyName,
                                                      g.FirstOrDefault().categoryName,
                                                      g.FirstOrDefault().size,
                                                      g.FirstOrDefault().color,
                                                      Quantity = g.Sum(o => o.Quantity),
                                                      GrandTotal = g.FirstOrDefault().GrandTotal,
                                                      NetDiscount = 0m,
                                                      PaidAmount = g.FirstOrDefault().PaidAmount
                                                  });

                    var ReturnData = ReturnDataQuery.ToList();
                    var ReturnDataQueryGroupBYData = ReturnDataQueryGroupBY.ToList();
                    GrandTotal = GrandTotal - (double)ReturnDataQueryGroupBYData.Sum(o => o.GrandTotal);
                    TDiscount = TDiscount - (double)ReturnDataQueryGroupBYData.Sum(o => o.NetDiscount);
                    PaidAmount = PaidAmount - (double)ReturnDataQueryGroupBYData.Sum(o => o.PaidAmount);
                    DueAmount = DueAmount - ((double)ReturnDataQueryGroupBYData.Sum(o => o.GrandTotal) - (double)ReturnDataQueryGroupBYData.Sum(o => o.PaidAmount));

                    #region Summary
                    if (rbPurSummary.Checked)
                    {


                        foreach (var item in PurchaseQueryGroupBy)
                        {
                            dt.Rows.Add(item.OrderDate, item.ChallanNo, item.SupplierName, item.Address, item.GrandTotal, item.NetDiscount, item.NetPurchase, 0, item.PaidAmount, item.Due);
                        }


                        foreach (var item in ReturnDataQueryGroupBY)
                        {
                            dtReturn.Rows.Add(
                                "Return",
                                item.OrderDate,
                                item.ChallanNoOrInvoice,
                                "",
                                 item.Name,
                                 "",
                                 item.categoryName,
                                 item.CompanyName,
                                 item.size,
                                 item.color,
                                 item.Quantity,
                                 0,
                                 item.GrandTotal,
                                 item.PaidAmount,
                                 ((double)item.GrandTotal - (double)item.PaidAmount)
                               );

                        }

                        dt.TableName = "rptDataSet_dtDailyPurchaseOrder";
                        dtReturn.TableName = "rptDataSet_dtReturnDetails";
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        ds.Tables.Add(dtReturn);
                        string embededResource = "INVENTORY.UI.RDLC.rptDailyPurchaseOrder.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Month", "Purchase Report From " + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);
                        rParam = new ReportParameter("GrandTotal", GrandTotal.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("TDiscount", TDiscount.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("TotalAmount", TotalAmount.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PaidAmount", PaidAmount.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("DueAmount", DueAmount.ToString("0.00"));
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
                    #endregion

                    else //Details
                    {

                        foreach (var item in PurchaseQueryData)
                        {
                            dtDetails.Rows.Add(item.OrderDate, item.ChallanNo, item.SupplierName, item.ProductName, item.categoryName, item.Quantity, item.UnitPrice, item.TAmount, item.PPDISAmt, item.NetPrice,item.color);
                        }


                        foreach (var item in ReturnData)
                        {
                            dtReturn.Rows.Add(
                                "Return",
                                item.OrderDate,
                                item.ChallanNoOrInvoice,
                                "",
                                 item.Name,
                                 item.ProductName,
                                 item.categoryName,
                                 item.CompanyName,
                                 item.size,
                                 item.color,
                                 item.Quantity,
                                 item.UnitPrice,
                                 item.Quantity * item.UnitPrice,
                                 item.PaidAmount,
                                 ((double)item.GrandTotal - (double)item.PaidAmount)
                               );

                        }


                        dtDetails.TableName = "rptDataSet_dtDailyPurchaseOrderDetails";
                        dtReturn.TableName = "rptDataSet_dtReturnDetails";
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dtDetails);
                        ds.Tables.Add(dtReturn);

                        string embededResource = "INVENTORY.UI.RDLC.rptDailyPurchaseOrderDetails.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Month", "Purchase Report From " + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);

                        rParam = new ReportParameter("GrandTotal", GrandTotal.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("TDiscount", TDiscount.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("TotalAmount", TotalAmount.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PaidAmount", PaidAmount.ToString("0.00"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("DueAmount", DueAmount.ToString("0.00"));
                        parameters.Add(rParam);
                        fReportViewer frm = new fReportViewer();

                        if (dtDetails.Rows.Count > 0)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDailyPurchaseRpt_Load(object sender, EventArgs e)
        {

        }
    }
}
