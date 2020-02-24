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

namespace ESRP.UI
{
    public partial class fSupplierWisePurchase : Form
    {
        public fSupplierWisePurchase()
        {
            InitializeComponent();
        }

        private void fSupplierWisePurchase_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    decimal TotalDuePurchase = 0;
                    decimal TotalCashColl = 0;
                    decimal TotalUPTDue = 0;
                


                    double GrandTotal = 0;
                    double TDiscount = 0;
                    double TotalAmount = 0;
                    double PaidAmount = 0;
                    double DueAmount = 0;

                    string SChallanNo = "";

                    Supplier oSupplier = db.Suppliers.FirstOrDefault(o => o.SupplierID == ctlSupplier.SelectedID);
                    DateTime fromDate = dtpFromDate.Value;
                    DateTime toDate = dtpToDate.Value;

                    string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);



                    var PurchaseQuery = (from POD in db.POrderDetails
                                         join PO in db.POrders on POD.POrderID equals PO.POrderID
                                         join SUP in db.Suppliers on PO.SupplierID equals SUP.SupplierID
                                         join P in db.Products on POD.ProductID equals P.ProductID
                                         join CLR in db.Colors on POD.ColorID equals CLR.ColorID
                                         where PO.OrderDate >= dFFDate && PO.OrderDate <= dTTDate && PO.SupplierID == ctlSupplier.SelectedID &&PO.Status==1
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
                                                group pod by new
                                                {
                                                    pod.POrderID,
                                                    pod.ChallanNo,
                                                    pod.OrderDate,
                                                } into g
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
                                                }
            );

                    var PurchaseQueryGroupByData = PurchaseQueryGroupBy.ToList();
                    GrandTotal = (double)PurchaseQueryGroupByData.Sum(o => o.NetPurchase);
                    TDiscount = (double)PurchaseQueryGroupByData.Sum(o => o.NetDiscount);
                    PaidAmount = (double)PurchaseQueryGroupByData.Sum(o => o.PaidAmount);
                    DueAmount = GrandTotal - PaidAmount;


                    var SDeliColl = db.CashCollections.Where(cc => cc.EntryDate >= dFFDate && cc.EntryDate <= dTTDate && cc.CompanyID == ctlSupplier.SelectedID);

                    //List<SOrder> oCreditSales = db.SOrders.Where(o => o.InvoiceDate >= dFFDate && o.InvoiceDate <= dTTDate && o.CustomerID==ctlCustomer.SelectedID).ToList();

                    if (PurchaseQueryData != null)
                    {
                        rptDataSet.dtSuppWiseDataDataTable dt = new rptDataSet.dtSuppWiseDataDataTable();
                        rptDataSet.dtSupplierDataTable sdt = new rptDataSet.dtSupplierDataTable();
                        rptDataSet.dtCCashDataTable SCDT = new rptDataSet.dtCCashDataTable();
                       
                        DataSet ds = new DataSet();
                        sdt.Rows.Add(oSupplier.Code, oSupplier.OwnerName, oSupplier.OwnerName, oSupplier.ContactNo,oSupplier.Address, oSupplier.TotalDue);
                        sdt.TableName = "rptDataSet_dtSupplier";
                        ds.Tables.Add(sdt);

                        foreach (var grd in PurchaseQueryData.ToList())
                        {
                            dt.Rows.Add(grd.OrderDate, grd.ChallanNo, grd.ProductName, grd.categoryName, grd.CompanyName, grd.size, grd.color, grd.UnitPrice, grd.PPDISAmt, grd.NetPrice, grd.TAmount, grd.NetDiscount, grd.NetPurchase, grd.ReceiveAmt, grd.Due, grd.Quantity);
                           
                        }
                        dt.TableName = "rptDataSet_dtSuppWiseData";
                        ds.Tables.Add(dt);


                        if (SDeliColl != null)
                        {
                            foreach (var scd in SDeliColl.ToList())
                            {
                                TotalCashColl = TotalCashColl + (decimal)scd.Amount;
                                SCDT.Rows.Add(scd.EntryDate, scd.Amount);
                            }
                        }

                        TotalUPTDue = TotalDuePurchase - TotalCashColl;

                        SCDT.TableName = "rptDataSet_dtCCash";
                        ds.Tables.Add(SCDT);

                        string embededResource = "ESRP.UI.RDLC.rptSupplierWiseDetails.rdlc";

                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Date", "Purchase report for the date of : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);

                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);

                        //rParam = new ReportParameter("TotalDue", "Total Due Upto Date: " + TotalUPTDue.ToString());
                        //parameters.Add(rParam);

                        //rParam = new ReportParameter("TotalDueUpTDate", "Total Due Upto Date: " + TotalUPTDue.ToString());
                        //parameters.Add(rParam);

                        rParam = new ReportParameter("GrandTotal", GrandTotal.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDis", TDiscount.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("NetTotal", GrandTotal.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("RecAmt", PaidAmount.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("CurrDue", DueAmount.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("ContactPerson", oSupplier.Name);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlSupplier_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
