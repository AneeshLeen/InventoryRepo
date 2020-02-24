using INVENTORY.DA;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class fCustomerWiseSales : Form
    {
        public fCustomerWiseSales()
        {
            InitializeComponent();
        }

        private void fEmployeeWiseSales_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (ctlCustomer.SelectedID == 0)
            {
                try
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {

                        decimal TotalDueSales = 0;

                        decimal GrandTotal = 0;
                        decimal TotalDis = 0;
                        decimal NetTotal = 0;
                        decimal RecAmt = 0;
                        decimal CurrDue = 0;
                        decimal GrandHire = 0;

                        int SorderID = 0;
                        string SInvoiceNo = "";

                        Customer oCustomer = db.Customers.FirstOrDefault(o => o.CustomerID == ctlCustomer.SelectedID);
                        DateTime fromDate = dtpFromDate.Value;
                        DateTime toDate = dtpToDate.Value;

                        string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                        string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                        DateTime dFFDate = Convert.ToDateTime(sFFdate);
                        DateTime dTTDate = Convert.ToDateTime(sTTdate);

                        var Sales = (
                                     from SOD in db.SOrderDetails
                                     join SO in db.SOrders on SOD.SOrderID equals SO.SOrderID
                                     join P in db.Products on SOD.ProductID equals P.ProductID
                                     join CAT in db.Categorys on P.CategoryID equals CAT.CategoryID
                                     join COM in db.Companies on P.CompanyID equals COM.CompanyID
                                     join MOD in db.Models on P.ModelID equals MOD.ModelID
                                     join STD in db.StockDetails on SOD.StockDetailID equals STD.SDetailID
                                     join CLR in db.Colors on STD.ColorID equals CLR.ColorID
                                     where (SO.InvoiceDate >= dFFDate && SO.InvoiceDate <= dTTDate && SO.Status == 1)
                                     select new
                                     {
                                         SO.SOrderID,
                                         SO.Customer.Code,
                                         SO.Customer.Name,
                                         SO.InvoiceNo,
                                         SO.InvoiceDate,
                                         SO.Adjustment,
                                         SO.GrandTotal,
                                         SO.NetDiscount,
                                         SO.TotalAmount,
                                         SO.RecAmount,
                                         SO.PaymentDue,
                                         P.ProductName,
                                         category = CAT.Description,
                                         company = COM.Description,
                                         model = MOD.Description,
                                         color = CLR.Description,
                                         SOD.UnitPrice,
                                         UTAmount = SOD.UnitPrice * SOD.Quantity,// SOD.UTAmount, 
                                         PPDAmount = SOD.Quantity * (SOD.PPDAmount + ((SO.TDAmount + SO.Adjustment) / (SO.GrandTotal - SO.NetDiscount + SO.TDAmount)) * (SOD.UnitPrice - SOD.PPDAmount)),
                                         HirePrice = 0m,
                                         NetPrice = SOD.Quantity * (SOD.UnitPrice - (SOD.PPDAmount + ((SO.TDAmount + SO.Adjustment) / (SO.GrandTotal - SO.NetDiscount + SO.TDAmount)) * (SOD.UnitPrice - SOD.PPDAmount))),
                                         SOD.Quantity
                                     }).OrderByDescending(x => x.InvoiceDate);


                        var Credit_Sales = (from SOD in db.CreditSaleProducts
                                            join SO in db.CreditSales on SOD.CreditSalesID equals SO.CreditSalesID
                                            join P in db.Products on SOD.ProductID equals P.ProductID
                                            join CAT in db.Categorys on P.CategoryID equals CAT.CategoryID
                                            join COM in db.Companies on P.CompanyID equals COM.CompanyID
                                            join MOD in db.Models on P.ModelID equals MOD.ModelID
                                            join STD in db.StockDetails on SOD.StockDetailID equals STD.SDetailID
                                            join CLR in db.Colors on STD.ColorID equals CLR.ColorID
                                            where (SO.SalesDate >= dFFDate && SO.SalesDate <= dTTDate && SO.Status == 1)
                                            select new
                                            {
                                                SO.FirstTotalInterest,
                                                SO.CreditSalesID,
                                                SO.Customer.Code,
                                                SO.Customer.Name,
                                                SO.InvoiceNo,
                                                SO.SalesDate,
                                                TSalesAmt = SO.TSalesAmt,
                                                Discount = SO.Discount,
                                                SO.DownPayment,
                                                P.ProductName,
                                                category = CAT.Description,
                                                company = COM.Description,
                                                model = MOD.Description,
                                                color = CLR.Description,
                                                SOD.UnitPrice,
                                                UTAmount = SOD.Quantity * SOD.UnitPrice,
                                                PPDAmount = (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * SOD.UnitPrice) * SOD.Quantity - SOD.TotalInterest,
                                                HirePrice = SOD.TotalInterest - (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * SOD.UnitPrice) * SOD.Quantity,
                                                NetPrice = SOD.Quantity * SOD.UnitPrice + SOD.TotalInterest - (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * SOD.UnitPrice) * SOD.Quantity,
                                                SOD.Quantity
                                            }).OrderByDescending(x => x.SalesDate);

                        rptDataSet.dtAllCustomerWiseSalesDataTable dt = new rptDataSet.dtAllCustomerWiseSalesDataTable();
                        DataSet ds = new DataSet();

                        if (Sales != null)
                        {
                            foreach (var grd in Sales.ToList())
                            {
                                if (SorderID != grd.SOrderID)
                                {
                                    TotalDueSales = TotalDueSales + (decimal)grd.PaymentDue;
                                    GrandTotal = GrandTotal + (decimal)grd.GrandTotal;
                                    TotalDis = TotalDis + (decimal)grd.NetDiscount + (decimal)grd.Adjustment;
                                    NetTotal = NetTotal + (decimal)grd.GrandTotal - (decimal)grd.NetDiscount - (decimal)grd.Adjustment;
                                    RecAmt = RecAmt + (decimal)grd.RecAmount;
                                    CurrDue = CurrDue + (decimal)(grd.GrandTotal - grd.NetDiscount - grd.Adjustment - grd.RecAmount);
                                }
                                SorderID = grd.SOrderID;
                                dt.Rows.Add(grd.Code,
                                    grd.Name,
                                    grd.InvoiceDate,
                                    grd.InvoiceNo,
                                    grd.GrandTotal,
                                         0,  //  Grand Hire Price
                                    grd.NetDiscount + grd.Adjustment,

                                    (grd.GrandTotal - grd.NetDiscount - grd.Adjustment),
                                    grd.RecAmount,
                                    (grd.GrandTotal - grd.NetDiscount - grd.Adjustment - grd.RecAmount),
                                    grd.ProductName,
                                    grd.category,
                                    grd.company,
                                    grd.model,
                                    grd.color,
                                    grd.Quantity,
                                    grd.UnitPrice,
                                    grd.UTAmount,
                                    grd.PPDAmount,
                                    grd.HirePrice,
                                    grd.NetPrice
                                   );

                            }
                        }

                        if (Credit_Sales != null)
                        {
                            foreach (var grd in Credit_Sales.ToList())
                            {

                                decimal PPDisAmt = 0m;
                                decimal NetDisAmt = grd.Discount - grd.FirstTotalInterest;


                                if (grd.PPDAmount > 0)
                                {
                                    PPDisAmt = (decimal)grd.PPDAmount;

                                }
                                else
                                {
                                    PPDisAmt = 0m;
                                }


                                if (NetDisAmt < 0)
                                {
                                    NetDisAmt = 0;
                                }



                                if (SorderID != grd.CreditSalesID)
                                {
                                    TotalDueSales = TotalDueSales + ((decimal)grd.TSalesAmt - (decimal)grd.Discount - (decimal)grd.DownPayment);
                                    GrandTotal = GrandTotal + (decimal)grd.TSalesAmt - (decimal)grd.FirstTotalInterest;
                                    TotalDis = TotalDis + NetDisAmt;
                                    GrandHire = GrandHire + grd.FirstTotalInterest - grd.Discount;
                                    NetTotal = NetTotal + (decimal)grd.TSalesAmt - (decimal)grd.Discount;
                                    RecAmt = RecAmt + (decimal)grd.DownPayment;
                                    CurrDue = CurrDue + (decimal)((decimal)grd.TSalesAmt - (decimal)grd.Discount - (decimal)grd.DownPayment);
                                }
                                SorderID = grd.CreditSalesID;





                                dt.Rows.Add(
                                    grd.Code,
                                    grd.Name,
                                    grd.SalesDate,
                                    grd.InvoiceNo,
                                    grd.TSalesAmt - grd.FirstTotalInterest,
                                    grd.FirstTotalInterest - grd.Discount,  // Grand Hire
                                    NetDisAmt,

                                    ((grd.TSalesAmt) - grd.Discount),
                                    grd.DownPayment,
                                    ((grd.TSalesAmt) - grd.Discount - grd.DownPayment),

                                    grd.ProductName,
                                    grd.category,
                                    grd.company,
                                    grd.model,
                                    grd.color,
                                    grd.Quantity,
                                    grd.UnitPrice,
                                    grd.UTAmount,
                                    PPDisAmt,
                                    grd.HirePrice,
                                    grd.NetPrice
                                    );

                            }
                        }
                        dt.TableName = "rptDataSet_dtAllCustomerWiseSales";
                        ds.Tables.Add(dt);



                        string embededResource = "INVENTORY.UI.RDLC.rptAllCustomerWiseSales.rdlc";

                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Date", "Sales report for the date of : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);

                        fReportViewer frm = new fReportViewer();

                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDue", "");
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDueUpTo", "");
                        parameters.Add(rParam);

                        rParam = new ReportParameter("GrandTotal", GrandTotal.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("GrandHire", GrandHire.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDis", TotalDis.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("NetTotal", NetTotal.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("RecAmt", RecAmt.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("CurrDue", CurrDue.ToString());
                        parameters.Add(rParam);


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
            else
            {
                try
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        decimal TotalUPTDue = 0;
                        decimal TotalDueSales = 0;
                        decimal GrandTotal = 0;
                        decimal TotalDis = 0;
                        decimal NetTotal = 0;
                        decimal RecAmt = 0;
                        decimal CurrDue = 0;
                        decimal TotalCashColl = 0;
                        decimal GrandHire = 0;

                        string SInvoiceNo = "";
                        int SOrderID = 0;

                        Customer oCustomer = db.Customers.FirstOrDefault(o => o.CustomerID == ctlCustomer.SelectedID);
                        DateTime fromDate = dtpFromDate.Value;
                        DateTime toDate = dtpToDate.Value;

                        string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                        string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                        DateTime dFFDate = Convert.ToDateTime(sFFdate);
                        DateTime dTTDate = Convert.ToDateTime(sTTdate);





                        int SorderID = 0;



                        var Sales = (
                                     from SOD in db.SOrderDetails
                                     join SO in db.SOrders on SOD.SOrderID equals SO.SOrderID
                                     join P in db.Products on SOD.ProductID equals P.ProductID
                                     join CAT in db.Categorys on P.CategoryID equals CAT.CategoryID
                                     join COM in db.Companies on P.CompanyID equals COM.CompanyID
                                     join MOD in db.Models on P.ModelID equals MOD.ModelID
                                     join STD in db.StockDetails on SOD.StockDetailID equals STD.SDetailID
                                     join CLR in db.Colors on STD.ColorID equals CLR.ColorID
                                     where (SO.InvoiceDate >= dFFDate && SO.InvoiceDate <= dTTDate && SO.Status == 1 && SO.CustomerID == ctlCustomer.SelectedID)
                                     select new
                                     {
                                         SO.SOrderID,
                                         SO.Customer.Code,
                                         SO.Customer.Name,
                                         SO.InvoiceNo,
                                         SO.InvoiceDate,
                                         SO.Adjustment,
                                         SO.GrandTotal,
                                         SO.NetDiscount,
                                         SO.TotalAmount,
                                         SO.RecAmount,
                                         SO.PaymentDue,
                                         P.ProductName,
                                         category = CAT.Description,
                                         company = COM.Description,
                                         model = MOD.Description,
                                         color = CLR.Description,
                                         SOD.UnitPrice,
                                         UTAmount = SOD.UnitPrice * SOD.Quantity,// SOD.UTAmount, 
                                         PPDAmount = SOD.Quantity * (SOD.PPDAmount + ((SO.TDAmount + SO.Adjustment) / (SO.GrandTotal - SO.NetDiscount + SO.TDAmount)) * (SOD.UnitPrice - SOD.PPDAmount)),
                                         HirePrice = 0m,
                                         NetPrice = SOD.Quantity * (SOD.UnitPrice - (SOD.PPDAmount + ((SO.TDAmount + SO.Adjustment) / (SO.GrandTotal - SO.NetDiscount + SO.TDAmount)) * (SOD.UnitPrice - SOD.PPDAmount))),
                                         SOD.Quantity
                                     }).OrderByDescending(x => x.InvoiceDate);


                        var Credit_Sales = (from SOD in db.CreditSaleProducts
                                            join SO in db.CreditSales on SOD.CreditSalesID equals SO.CreditSalesID
                                            join P in db.Products on SOD.ProductID equals P.ProductID
                                            join CAT in db.Categorys on P.CategoryID equals CAT.CategoryID
                                            join COM in db.Companies on P.CompanyID equals COM.CompanyID
                                            join MOD in db.Models on P.ModelID equals MOD.ModelID
                                            join STD in db.StockDetails on SOD.StockDetailID equals STD.SDetailID
                                            join CLR in db.Colors on STD.ColorID equals CLR.ColorID
                                            where (SO.SalesDate >= dFFDate && SO.SalesDate <= dTTDate && SO.Status == 1 && SO.CustomerID == ctlCustomer.SelectedID)
                                            select new
                                            {
                                                SO.FirstTotalInterest,
                                                SO.CreditSalesID,
                                                SO.Customer.Code,
                                                SO.Customer.Name,
                                                SO.InvoiceNo,
                                                SO.SalesDate,
                                                TSalesAmt = SO.TSalesAmt,
                                                Discount = SO.Discount,
                                                SO.DownPayment,
                                                P.ProductName,
                                                category = CAT.Description,
                                                company = COM.Description,
                                                model = MOD.Description,
                                                color = CLR.Description,
                                                SOD.UnitPrice,
                                                UTAmount = SOD.Quantity * SOD.UnitPrice,
                                                PPDAmount = (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * SOD.UnitPrice) * SOD.Quantity - SOD.TotalInterest,
                                                HirePrice = SOD.TotalInterest - (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * SOD.UnitPrice) * SOD.Quantity,
                                                NetPrice = SOD.Quantity * SOD.UnitPrice + SOD.TotalInterest - (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * SOD.UnitPrice) * SOD.Quantity,
                                                SOD.Quantity
                                            }).OrderByDescending(x => x.SalesDate);

                        rptDataSet.dtAllCustomerWiseSalesDataTable dt = new rptDataSet.dtAllCustomerWiseSalesDataTable();
                        DataSet ds = new DataSet();

                        if (Sales != null)
                        {
                            foreach (var grd in Sales.ToList())
                            {
                                if (SorderID != grd.SOrderID)
                                {
                                    TotalDueSales = TotalDueSales + (decimal)grd.PaymentDue;
                                    GrandTotal = GrandTotal + (decimal)grd.GrandTotal;
                                    TotalDis = TotalDis + (decimal)grd.NetDiscount + (decimal)grd.Adjustment;
                                    NetTotal = NetTotal + (decimal)grd.GrandTotal - (decimal)grd.NetDiscount - (decimal)grd.Adjustment;
                                    RecAmt = RecAmt + (decimal)grd.RecAmount;
                                    CurrDue = CurrDue + (decimal)(grd.GrandTotal - grd.NetDiscount - grd.Adjustment - grd.RecAmount);
                                }
                                SorderID = grd.SOrderID;
                                dt.Rows.Add(grd.Code,
                                    grd.Name,
                                    grd.InvoiceDate,
                                    grd.InvoiceNo,
                                    grd.GrandTotal,
                                    0,  //  Grand Hire Price
                                    grd.NetDiscount + grd.Adjustment,

                                    (grd.GrandTotal - grd.NetDiscount - grd.Adjustment),
                                    grd.RecAmount,
                                    (grd.GrandTotal - grd.NetDiscount - grd.Adjustment - grd.RecAmount),
                                    grd.ProductName,
                                    grd.category,
                                    grd.company,
                                    grd.model,
                                    grd.color,
                                    grd.Quantity,
                                    grd.UnitPrice,
                                    grd.UTAmount,
                                    grd.PPDAmount,
                                    grd.HirePrice,
                                    grd.NetPrice
                                   );

                            }
                        }

                        if (Credit_Sales != null)
                        {
                            foreach (var grd in Credit_Sales.ToList())
                            {

                                decimal PPDisAmt = 0m;
                                decimal NetDisAmt = grd.Discount - grd.FirstTotalInterest;


                                if (grd.PPDAmount > 0)
                                {
                                    PPDisAmt = (decimal)grd.PPDAmount;

                                }
                                else
                                {
                                    PPDisAmt = 0m;
                                }


                                if (NetDisAmt < 0)
                                {
                                    NetDisAmt = 0;
                                }



                                if (SorderID != grd.CreditSalesID)
                                {
                                    TotalDueSales = TotalDueSales + ((decimal)grd.TSalesAmt - (decimal)grd.Discount - (decimal)grd.DownPayment);
                                    GrandTotal = GrandTotal + (decimal)grd.TSalesAmt - (decimal)grd.FirstTotalInterest;
                                    TotalDis = TotalDis + NetDisAmt;
                                    GrandHire = GrandHire + grd.FirstTotalInterest - grd.Discount;
                                    NetTotal = NetTotal + (decimal)grd.TSalesAmt - (decimal)grd.Discount;
                                    RecAmt = RecAmt + (decimal)grd.DownPayment;
                                    CurrDue = CurrDue + (decimal)((decimal)grd.TSalesAmt - (decimal)grd.Discount - (decimal)grd.DownPayment);
                                }
                                SorderID = grd.CreditSalesID;





                                dt.Rows.Add(
                                    grd.Code,
                                    grd.Name,
                                    grd.SalesDate,
                                    grd.InvoiceNo,
                                    grd.TSalesAmt - grd.FirstTotalInterest,
                                    grd.FirstTotalInterest - grd.Discount,  // Grand Hire
                                    NetDisAmt,

                                    ((grd.TSalesAmt) - grd.Discount),
                                    grd.DownPayment,
                                    ((grd.TSalesAmt) - grd.Discount - grd.DownPayment),

                                    grd.ProductName,
                                    grd.category,
                                    grd.company,
                                    grd.model,
                                    grd.color,
                                    grd.Quantity,
                                    grd.UnitPrice,
                                    grd.UTAmount,
                                    PPDisAmt,
                                    grd.HirePrice,
                                    grd.NetPrice
                                    );

                            }
                        }
                        dt.TableName = "rptDataSet_dtAllCustomerWiseSales";
                        ds.Tables.Add(dt);

                        rptDataSet.dtCustomerDataTable cdt = new rptDataSet.dtCustomerDataTable();

                        cdt.Rows.Add(oCustomer.Code,
                            oCustomer.Name,
                            oCustomer.CompanyName,
                            oCustomer.CustomerType,
                            oCustomer.ContactNo,
                            oCustomer.NID,
                            oCustomer.Address,
                            oCustomer.TotalDue);
                        cdt.TableName = "rptDataSet_dtCustomer";
                        ds.Tables.Add(cdt);




                        string embededResource = "INVENTORY.UI.RDLC.rptCustomerWiseSales.rdlc";

                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Date", "Sales report for the date of : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);

                        fReportViewer frm = new fReportViewer();

                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDue", oCustomer.TotalDue.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDueUpTo", oCustomer.TotalDue.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("GrandTotal", GrandTotal.ToString());
                        parameters.Add(rParam);


                        rParam = new ReportParameter("GrandHire", GrandHire.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("TotalDis", TotalDis.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("NetTotal", NetTotal.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("RecAmt", RecAmt.ToString());
                        parameters.Add(rParam);

                        rParam = new ReportParameter("CurrDue", CurrDue.ToString());
                        parameters.Add(rParam);


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
        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
