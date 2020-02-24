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
    public partial class fPPurchaseDetails : Form
    {
        public fPPurchaseDetails()
        {
            InitializeComponent();
        }

        private void fPPurchaseDetails_Load(object sender, EventArgs e)
        {

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

                    rptDataSet.PWPDetailsDataTable pwp = new rptDataSet.PWPDetailsDataTable();
                    DataSet ds = new DataSet();
                    //IQueryable<dynamic> pquery = null;

                   var  pquery = (from POD in db.POrderDetails
                              join PO in db.POrders on POD.POrderID equals PO.POrderID
                              join P in db.Products on POD.ProductID equals P.ProductID
                              join CAT in db.Categorys on P.CategoryID equals CAT.CategoryID
                              join COM in db.Companies on P.CompanyID equals COM.CompanyID
                              join MOD in db.Models on P.ModelID equals MOD.ModelID
                              join CLR in db.Colors on POD.ColorID equals CLR.ColorID
                              where
                                
                              PO.OrderDate >= fromDate && PO.OrderDate <= toDate && PO.Status == 1
                              select new
                              {
                                  P.ProductID,
                                  P.CategoryID,
                                  P.CompanyID,
                                  PO.ChallanNo,
                                  PO.OrderDate,
                                  P.ProductName,
                                  CompanyName = P.Company.Description,
                                  categoryName = P.Category.Description,
                                  size = "",
                                  color = CLR.Description,
                                  POD.Quantity,
                                  UnitPrice = (POD.UnitPrice - ((PO.TDiscount - PO.LaborCost) / (PO.GrandTotal - PO.NetDiscount + PO.TDiscount)) * POD.UnitPrice),
                              }).OrderBy(x => x.OrderDate).ToList();

                   var Purchase_return = ((from POD in db.ReturnDetails
                                                           from PO in db.Returns
                                                           from P in db.Products
                                                           from STD in db.StockDetails
                                                           from CLR in db.Colors

                                                           where POD.ReturnID == PO.ReturnID && P.ProductID == POD.ProductID
                                                           
                                                           && STD.SDetailID == POD.SDetailID
                                                           && CLR.ColorID == STD.ColorID
                                                           && PO.SupplierID != null
                                                           && PO.ReturnDate >= fromDate && PO.ReturnDate <= toDate
                                                           select new
                                                           {
                                                               P.ProductID,
                                                               P.CategoryID,
                                                               P.CompanyID,
                                                               ChallanNo = PO.InvoiceNo,
                                                               OrderDate = PO.ReturnDate,
                                                               P.ProductName,
                                                               CompanyName = P.Company.Description,
                                                               categoryName = P.Category.Description,
                                                               size = "",
                                                               color = CLR.Description,
                                                               Quantity = (-1) * POD.Quantity,
                                                               UnitPrice = (-1) * POD.UnitPrice
                                                           }).OrderBy(x => x.OrderDate));




                   var purchase = pquery.ToList();
                   purchase.AddRange(Purchase_return.ToList());



                    if (rbAllProduct.Checked || ctlProduct.SelectedID > 0)
                    {
                        if(rbAllProduct.Checked)
                        {
                          
                            rbAllProduct.Checked = false;
                        }
                        else
                        {

                            purchase = purchase.Where(o => o.ProductID == (int)ctlProduct.SelectedID).ToList();
                        }


                    

                        foreach (var grd in purchase)
                        {
                            pwp.Rows.Add(grd.OrderDate, grd.ChallanNo, grd.ProductName, grd.CompanyName, grd.categoryName,grd. size,grd.color, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                        }

                        pwp.TableName = "rptDataSet_PWPDetails";
                        ds.Tables.Add(pwp);

                        string embededResource = "ESRP.UI.RDLC.rptProductWPDetails.rdlc";
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
                    else if (rbCategory.Checked || ctlCategory.SelectedID > 0)
                    {
                        if (rbCategory.Checked)
                        {
                            

                            rbCategory.Checked = false;
                        }
                        else
                        {
                            purchase = purchase.Where(o => o.CategoryID == (int)ctlCategory.SelectedID).ToList();

                        }

                       
                        foreach (var grd in purchase)
                        {
                            pwp.Rows.Add(grd.OrderDate, grd.ChallanNo, grd.ProductName, grd.CompanyName, grd.categoryName,grd. size,grd.color, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                        }

                        pwp.TableName = "rptDataSet_PWPDetails";
                        ds.Tables.Add(pwp);

                        string embededResource = "ESRP.UI.RDLC.rptCategoryWPDetails.rdlc";
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
                    else if (rbCompany.Checked || ctlCompany.SelectedID > 0)
                    {
                        if (rbCompany.Checked)
                        {
                           
                            rbCompany.Checked = false;

                        }
                        else
                        {
                            purchase = purchase.Where(o => o.CompanyID == (int)ctlCompany.SelectedID).ToList();
                        }

                       

                        foreach (var grd in purchase)
                        {
                            pwp.Rows.Add(grd.OrderDate, grd.ChallanNo, grd.ProductName, grd.CompanyName, grd.categoryName,grd. size,grd.color, grd.Quantity, grd.UnitPrice, grd.Quantity * grd.UnitPrice);
                        }

                        pwp.TableName = "rptDataSet_PWPDetails";
                        ds.Tables.Add(pwp);

                        string embededResource = "ESRP.UI.RDLC.rptCompanyWPDetails.rdlc";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            catch (Exception ex)
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

        private void rbAllProduct_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                //ctlProduct.Enabled = false;
                //rbCategory.Checked = false;
                //rbCompany.Checked = false;
                //ctlProduct.SelectedID = 0;
                //ctlCategory.SelectedID = 0;
                //ctlCompany.SelectedID = 0;
            }
            catch (Exception ex)
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
