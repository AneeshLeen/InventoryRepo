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
    public partial class fPSalesDetails : Form
    {
        public fPSalesDetails()
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
                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";
                    fromDate = Convert.ToDateTime(dFromDate);
                    toDate = Convert.ToDateTime(sToDate);

                    rptDataSet.PWSDetailsDataTable pws = new rptDataSet.PWSDetailsDataTable();
                    DataSet ds = new DataSet();
                    //IQueryable<dynamic> squery = null;
                    //IQueryable<dynamic> squery_credit = null;
                    //IQueryable<dynamic> Sales_return = null;

                  var  squery = ((from SOD in db.SOrderDetails
                               from SO in db.SOrders
                               from P in db.Products
                               from STD in db.StockDetails
                               from CLR in db.Colors
                               where SOD.SOrderID == SO.SOrderID && P.ProductID == SOD.ProductID
                                   
                               && STD.SDetailID == SOD.StockDetailID
                               && CLR.ColorID == STD.ColorID
                               && SO.InvoiceDate >= fromDate && SO.InvoiceDate <= toDate && SO.Status == 1
                               select new
                               {  
                                   P.ProductID,
                                   P.CategoryID,
                                   P.CompanyID,
                                   SO.InvoiceNo,
                                   SalesDate = SO.InvoiceDate,
                                   P.ProductName,
                                   CompanyName = P.Company.Description,
                                   categoryName = P.Category.Description,
                                   size = "",
                                   color = CLR.Description,
                                   SOD.Quantity,
                                   UnitPrice = ((SOD.UnitPrice - SOD.PPDAmount) - ((SO.TDAmount + SO.Adjustment) / (SO.GrandTotal - SO.NetDiscount + SO.TDAmount)) * (SOD.UnitPrice - SOD.PPDAmount)),
                               })).OrderBy(x => x.SalesDate);



                      var  squery_credit = ((from SOD in db.CreditSaleProducts
                                            from SO in db.CreditSales
                                            from P in db.Products
                                            from STD in db.StockDetails
                                            from CLR in db.Colors

                                            where SOD.CreditSalesID == SO.CreditSalesID && P.ProductID == SOD.ProductID
                                        
                                            && STD.SDetailID == SOD.StockDetailID
                                            && CLR.ColorID == STD.ColorID
                                            && SO.SalesDate >= fromDate && SO.SalesDate <= toDate && SO.Status == 1
                                            select new
                                            {
                                                P.ProductID,
                                                P.CategoryID,
                                                P.CompanyID,
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


                   var Sales_return = ((from SOD in db.ReturnDetails
                                                         from SO in db.Returns
                                                         from P in db.Products
                                                         from STD in db.StockDetails
                                                         from CLR in db.Colors

                                                         where SOD.ReturnID == SO.ReturnID && P.ProductID == SOD.ProductID
                                                         && STD.SDetailID == SOD.SDetailID
                                                         && CLR.ColorID == STD.ColorID
                                                         && SO.CustomerID != null
                                                         && SO.ReturnDate >= fromDate && SO.ReturnDate <= toDate
                                                         select new
                                                         {
                                                             P.ProductID,
                                                             P.CategoryID,
                                                             P.CompanyID,
                                                             SO.InvoiceNo,
                                                             SalesDate = SO.ReturnDate,
                                                             P.ProductName,
                                                             CompanyName = P.Company.Description,
                                                             categoryName = P.Category.Description,
                                                             size = "",
                                                             color = CLR.Description,
                                                             Quantity = (-1) * SOD.Quantity,
                                                             UnitPrice = (-1) * SOD.UnitPrice
                                                         }).OrderBy(x => x.SalesDate));

                   var salse = squery.ToList();
                   var salse_credit = squery_credit.ToList();
                   salse.AddRange(salse_credit);
                   salse.AddRange(Sales_return.ToList());


                    if (rbAllProduct.Checked || ctlProduct.SelectedID > 0)
                    {
                        if(rbAllProduct.Checked)
                        {
                            

                            rbAllProduct.Checked = false;

                        }
                        else
                        {
                            salse = salse.Where(o => o.ProductID == (int)ctlProduct.SelectedID).ToList();
                        }


                       
                        decimal TotalPurchase = 0;
                        decimal TotalSales = 0;
                        decimal StockIn = 0;

                        foreach (var grd in salse)
                        {
                            TotalSales = TotalSales + grd.Quantity;
                            pws.Rows.Add(grd.SalesDate, grd.InvoiceNo, grd.CompanyName, grd.categoryName,grd.size,grd.color , grd.ProductName, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                        }

                        StockIn = TotalPurchase - TotalSales;
                        pws.TableName = "rptDataSet_PWSDetails";
                        ds.Tables.Add(pws);

                        string embededResource = "INVENTORY.UI.RDLC.rptPWSalesDetails.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("DateRange", "Date from: " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);


                        fReportViewer frm = new fReportViewer();
                        frm.CommonReportViewer(embededResource, ds, parameters, true);
                        ctlProduct.SelectedID = 0;


                    }
                    else if(rbCategory.Checked || ctlCategory.SelectedID>0)
                    {
                        if(rbCategory.Checked)
                        {
                            

                            rbCategory.Checked = false;

                        }
                        else
                        {
                            salse = salse.Where(o => o.CategoryID == (int)ctlCategory.SelectedID).ToList();
                        }


                       
                        decimal TotalPurchase = 0;
                        decimal TotalSales = 0;
                        decimal StockIn = 0;

                        foreach (var grd in salse)
                        {
                            TotalSales = TotalSales + grd.Quantity;
                            pws.Rows.Add(grd.SalesDate, grd.InvoiceNo, grd.CompanyName, grd.categoryName, grd.size, grd.color, grd.ProductName, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                        }

                        StockIn = TotalPurchase - TotalSales;
                        pws.TableName = "rptDataSet_PWSDetails";
                        ds.Tables.Add(pws);

                        string embededResource = "INVENTORY.UI.RDLC.rptCWSalesDetails.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("DateRange", "Date from: " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);


                        fReportViewer frm = new fReportViewer();
                        frm.CommonReportViewer(embededResource, ds, parameters, true);
                        ctlCategory.SelectedID = 0;


                    }
                    else if(rbCompany.Checked || ctlCompany.SelectedID>0)
                    {
                        if(rbCompany.Checked)
                        {
                            
                            rbCompany.Checked = false;

                        }
                        else
                        {
                            salse = salse.Where(o => o.CompanyID == (int)ctlCompany.SelectedID ).ToList();
                        }

                        decimal TotalPurchase = 0;
                        decimal TotalSales = 0;
                        decimal StockIn = 0;

                        foreach (var grd in salse)
                        {
                            TotalSales = TotalSales + grd.Quantity;
                            pws.Rows.Add(grd.SalesDate, grd.InvoiceNo, grd.CompanyName, grd.categoryName, grd.size, grd.color, grd.ProductName, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                        }

                        StockIn = TotalPurchase - TotalSales;
                        pws.TableName = "rptDataSet_PWSDetails";
                        ds.Tables.Add(pws);

                        string embededResource = "INVENTORY.UI.RDLC.rptCWSDetails.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("DateRange", "Date from: " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                        parameters.Add(rParam);
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);

                        fReportViewer frm = new fReportViewer();
                        frm.CommonReportViewer(embededResource, ds, parameters, true);
                        ctlCompany.SelectedID = 0;

                    }
                    else
                    {
                        MessageBox.Show("Please select product", "Select", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fPSalesDetails_Load(object sender, EventArgs e)
        {

        }

        private void ctlProduct_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //rbAllProduct.Checked = false;
                //rbCategory.Checked = false;
                //rbCompany.Checked = false;
                //ctlCategory.SelectedID = 0;
                //ctlCompany.SelectedID = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlCategory_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //rbAllProduct.Checked = false;
                //rbCategory.Checked = false;
                //rbCompany.Checked = false;
                //ctlProduct.SelectedID = 0;
                //ctlCompany.SelectedID = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlCompany_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //rbAllProduct.Checked = false;
                //rbCategory.Checked = false;
                //rbCompany.Checked = false;
                //ctlCategory.SelectedID = 0;
                //ctlProduct.SelectedID = 0;
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

        private void rbAllProduct_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //rbCategory.Checked = false;
               // rbCompany.Checked = false;
                //rbAllProduct.Checked = true;
                //ctlProduct.SelectedID = 0;
                //ctlCategory.SelectedID = 0;
                //ctlCompany.SelectedID = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbCategory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //rbCompany.Checked = false;
                //rbAllProduct.Checked = false;
                //rbCategory.Checked = true;
                //ctlProduct.SelectedID = 0;
                //ctlCategory.SelectedID = 0;
                //ctlCompany.SelectedID = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbCompany_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //rbCategory.Checked = false;
                //rbAllProduct.Checked = false;
                //rbCompany.Checked = true;
                //ctlProduct.SelectedID = 0;
                //ctlCategory.SelectedID = 0;
                //ctlCompany.SelectedID = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
