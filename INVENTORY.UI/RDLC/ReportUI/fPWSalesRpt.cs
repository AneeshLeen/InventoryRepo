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
    public partial class fPWSalesRpt : Form
    {
        public fPWSalesRpt()
        {
            InitializeComponent();
        }

        private void ctlProduct_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                if (ctlProduct.SelectedID > 0)
                {
                    DateTime fromDate = dtpFromDate.Value;
                    DateTime toDate = dtpToDate.Value;

                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";

                    fromDate = Convert.ToDateTime(dFromDate);
                    toDate = Convert.ToDateTime(sToDate);

                    rptDataSet.PWPDetailsDataTable pwp = new rptDataSet.PWPDetailsDataTable();
                    rptDataSet.PWSDetailsDataTable pws = new rptDataSet.PWSDetailsDataTable();

                    DataSet ds = new DataSet();

                    IQueryable<dynamic> pquery = (from POD in db.POrderDetails
                                                  from PO in db.POrders
                                                  from P in db.Products                                               
                                                  from CLR in db.Colors
                                                  where POD.POrderID == PO.POrderID && P.ProductID == POD.ProductID && 
                                                  POD.ProductID == ctlProduct.SelectedID                                            
                                                  && CLR.ColorID == POD.ColorID
                                                  && PO.OrderDate >= fromDate && PO.OrderDate <= toDate && PO.Status==1
                                                  select new
                                                  {
                                                      PO.ChallanNo,
                                                      PO.OrderDate,
                                                      P.ProductName,
                                                      CompanyName = P.Company.Description,
                                                      categoryName = P.Category.Description,
                                                      size ="",
                                                      color = CLR.Description,
                                                      POD.Quantity,
                                                      //POD.UnitPrice
                                                      UnitPrice = (POD.UnitPrice - ((PO.TDiscount - PO.LaborCost) / (PO.GrandTotal - PO.NetDiscount + PO.TDiscount)) * POD.UnitPrice), 
                                                  }).OrderBy(x => x.OrderDate);

                    IQueryable<dynamic> Purchase_return = ((from POD in db.ReturnDetails
                                                            from PO in db.Returns
                                                            from P in db.Products
                                                            from STD in db.StockDetails
                                                            from CLR in db.Colors

                                                            where POD.ReturnID == PO.ReturnID && P.ProductID == POD.ProductID
                                                            && POD.ProductID == ctlProduct.SelectedID
                                                            && STD.SDetailID == POD.SDetailID
                                                            && CLR.ColorID == STD.ColorID
                                                            && PO.SupplierID!=null
                                                            && PO.ReturnDate >= fromDate && PO.ReturnDate <= toDate
                                                            select new
                                                            {
                                                                ChallanNo= PO.InvoiceNo,
                                                                OrderDate=PO.ReturnDate,
                                                                P.ProductName,
                                                                CompanyName = P.Company.Description,
                                                                categoryName = P.Category.Description,
                                                                size = "",
                                                                color = CLR.Description,
                                                                Quantity = (-1) * POD.Quantity,
                                                               UnitPrice=(-1)* POD.UnitPrice
                                                            }).OrderBy(x => x.OrderDate));
                           



                    var purchase = pquery.ToList();
                    purchase.AddRange(Purchase_return.ToList());



                    IQueryable<dynamic> squery = ((from SOD in db.SOrderDetails
                                                   from SO in db.SOrders
                                                   from P in db.Products
                                                   from STD in db.StockDetails
                                                   from CLR in db.Colors

                                                   where SOD.SOrderID == SO.SOrderID && P.ProductID == SOD.ProductID
                                                   && SOD.ProductID == ctlProduct.SelectedID
                                                   && STD.SDetailID == SOD.StockDetailID
                                                   && CLR.ColorID == STD.ColorID
                                                   && SO.InvoiceDate >= fromDate && SO.InvoiceDate <= toDate && SO.Status==1
                                                   select new
                                                   {
                                                       SO.InvoiceNo,
                                                       SalesDate = SO.InvoiceDate,
                                                       P.ProductName,
                                                       CompanyName = P.Company.Description,
                                                       categoryName = P.Category.Description,
                                                       size ="",
                                                       color = CLR.Description,
                                                       SOD.Quantity,
                                                       //SOD.UnitPrice
                                                       UnitPrice = ((SOD.UnitPrice - SOD.PPDAmount) - ((SO.TDAmount + SO.Adjustment) / (SO.GrandTotal - SO.NetDiscount + SO.TDAmount)) * (SOD.UnitPrice - SOD.PPDAmount)),
                                                   }).OrderBy(x => x.SalesDate));



                    IQueryable<dynamic> squery_credit = ((from SOD in db.CreditSaleProducts
                                                   from SO in db.CreditSales
                                                   from P in db.Products
                                                   from STD in db.StockDetails
                                                   from CLR in db.Colors

                                                   where SOD.CreditSalesID == SO.CreditSalesID && P.ProductID == SOD.ProductID
                                                   && SOD.ProductID == ctlProduct.SelectedID
                                                   && STD.SDetailID == SOD.StockDetailID
                                                   && CLR.ColorID == STD.ColorID
                                                   && SO.SalesDate >= fromDate && SO.SalesDate <= toDate && SO.Status == 1
                                                   select new
                                                   {
                                                       SO.InvoiceNo,
                                                       SalesDate = SO.SalesDate,
                                                       P.ProductName,
                                                       CompanyName = P.Company.Description,
                                                       categoryName = P.Category.Description,
                                                       size = "",
                                                       color = CLR.Description,
                                                       SOD.Quantity,
                                                      // SOD.UnitPrice
                                                       UnitPrice = SOD.UnitPrice - (((SO.Discount) / (SO.TSalesAmt - SO.FirstTotalInterest)) * (SOD.UnitPrice * SOD.Quantity) - SOD.TotalInterest),   
                                                   }).OrderBy(x => x.SalesDate));


                    IQueryable<dynamic> Sales_return = ((from SOD in db.ReturnDetails
                                                         from SO in db.Returns
                                                         from P in db.Products
                                                         from STD in db.StockDetails
                                                         from CLR in db.Colors

                                                         where SOD.ReturnID == SO.ReturnID && P.ProductID == SOD.ProductID
                                                         && SOD.ProductID == ctlProduct.SelectedID
                                                         && STD.SDetailID == SOD.SDetailID
                                                         && CLR.ColorID == STD.ColorID
                                                         && SO.CustomerID!=null
                                                         && SO.ReturnDate >= fromDate && SO.ReturnDate<= toDate 
                                                         select new
                                                         {
                                                             SO.InvoiceNo,
                                                             SalesDate = SO.ReturnDate,
                                                             P.ProductName,
                                                             CompanyName = P.Company.Description,
                                                             categoryName = P.Category.Description,
                                                             size = "",
                                                             color = CLR.Description,
                                                             Quantity=(-1)* SOD.Quantity,
                                                             UnitPrice = (-1) * SOD.UnitPrice
                                                         }).OrderBy(x => x.SalesDate));
                           




                    var salse = squery.ToList();
                    var salse_credit = squery_credit.ToList();
                    salse.AddRange(salse_credit);
                    salse.AddRange(Sales_return.ToList());


                    decimal TotalPurchase = 0;
                    decimal TotalSales = 0;
                    decimal StockIn = 0;

                    foreach (var grd in purchase)
                    {
                        TotalPurchase = TotalPurchase + grd.Quantity;
                        pwp.Rows.Add(grd.OrderDate, grd.ChallanNo, grd.ProductName, grd.CompanyName, grd.categoryName, grd.size, grd.color, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                    }
                    foreach (var grd in salse)
                    {
                        TotalSales = TotalSales + grd.Quantity;
                        pws.Rows.Add(grd.SalesDate, grd.InvoiceNo, grd.CompanyName, grd.categoryName, grd.size, grd.color, grd.ProductName, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                    }



                    StockIn = TotalPurchase - TotalSales;
                    pwp.TableName = "rptDataSet_PWPDetails";
                    ds.Tables.Add(pws);
                    pws.TableName = "rptDataSet_PWSDetails";
                    ds.Tables.Add(pwp);
                    string embededResource = "ESRP.UI.RDLC.rptProductWPandS.rdlc";
                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("DateRange", "Date from: " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);
                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("OutStandingStock", Math.Round(StockIn,0).ToString());
                    parameters.Add(rParam);
                    fReportViewer frm = new fReportViewer();
                    frm.CommonReportViewer(embededResource, ds, parameters, true);
                }
                else
                {
                    MessageBox.Show("Please select product", "Select", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fPWSalesRpt_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
