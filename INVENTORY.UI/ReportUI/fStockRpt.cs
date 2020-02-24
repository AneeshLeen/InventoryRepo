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
    public partial class fStockRpt : Form
    {
        public fStockRpt()
        {
            InitializeComponent();
        }
        private void RefreshControl()
        {
            rbCompany.Checked = false;
            rbCategory.Checked = false;
            rbModel.Checked = false;
            ctlBrand.SelectedID = 0;
            ctlCategory.SelectedID = 0;
            ctlPreOrProduct.SelectedID = 0;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    int nCount = 0;

                    List<Stock> oStocks = null;

                    if(rbCompany.Checked)
                    {
                        oStocks = db.Stocks.Where(s => s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }
                    else if(rbCategory.Checked)
                    {
                        oStocks = db.Stocks.Where(s => s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }
                    else if(rbModel.Checked)
                    {
                        oStocks = db.Stocks.Where(s => s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }
                    else if (rbColorCode.Checked)
                    {
                        oStocks = db.Stocks.Where(s => s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Color.Code).ToList();
                    }

                    if(ctlBrand.SelectedID>0)
                    {
                        oStocks = db.Stocks.Where(s => s.Product.CompanyID == ctlBrand.SelectedID && s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }
                    else if(ctlCategory.SelectedID>0)
                    {
                        oStocks = db.Stocks.Where(s => s.Product.CategoryID == ctlCategory.SelectedID && s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }
                    else if(ctlPreOrProduct.SelectedID>0)
                    {
                        oStocks = db.Stocks.Where(s => s.Product.ProductID == ctlPreOrProduct.SelectedID && s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }
                    else if (ctlColor.SelectedID > 0)
                    {
                        oStocks = db.Stocks.Where(s => s.ColorID == ctlColor.SelectedID && s.Quantity > 0).OrderBy(s => s.Product.Company.Description).ThenBy(s => s.Product.Category.Description).ToList();
                    }

                    List<Category> oCatList = db.Categorys.ToList();
                    List<Company> oComList = db.Companies.ToList();
                    List<INVENTORY.DA.Color> oColList = db.Colors.ToList();
                    List<Product> oProList = db.Products.ToList();

                    if (oStocks != null)
                    {
                       
                        if (rbCategory.Checked || ctlCategory.SelectedID>0)
                        {
                            nCount = 1;
                            rptDataSet.StockInfoDataTable dt = new rptDataSet.StockInfoDataTable();
                            DataSet ds = new DataSet();

                            foreach (Stock oSTItem in oStocks)
                            {
                                Product oPro = oProList.FirstOrDefault(o => o.ProductID == oSTItem.ProductID);
                                Category oCat = oCatList.FirstOrDefault(o => o.CategoryID == oPro.CategoryID);
                                Company oCom = oComList.FirstOrDefault(o => o.CompanyID == oPro.CompanyID);
                                dt.Rows.Add((EnumProductType)oPro.ProductType, ((DateTime)oSTItem.EntryDate).ToString("dd MMM yyyy"), oSTItem.StockCode, oCat.Description, oCom.Description, oSTItem.Product.ProductName, oSTItem.Color.Description, oSTItem.Quantity, oSTItem.PMPrice, (oSTItem.Quantity * oSTItem.PMPrice));
                                nCount++;
                            }

                            dt.TableName = "rptDataSet_StockInfo";
                            ds.Tables.Add(dt);

                            string embededResource = "INVENTORY.UI.RDLC.rptCategoryWiseStock.rdlc";

                            List<ReportParameter> parameters = new List<ReportParameter>();

                            ReportParameter rParam = null;
                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);
                            rParam = new ReportParameter("SLNO", nCount.ToString());
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
                            rbCategory.Checked = false;
                            ctlCategory.SelectedID = 0;
                            RefreshControl();

                        }
                        else if(rbCompany.Checked || ctlBrand.SelectedID>0)
                        {
                            nCount = 1;
                            rptDataSet.StockInfoDataTable dt = new rptDataSet.StockInfoDataTable();
                            DataSet ds = new DataSet();
                            foreach (Stock oSTItem in oStocks)
                            {
                                Product oPro = oProList.FirstOrDefault(o => o.ProductID == oSTItem.ProductID);
                                Category oCat = oCatList.FirstOrDefault(o => o.CategoryID == oPro.CategoryID);
                                Company oCom = oComList.FirstOrDefault(o => o.CompanyID == oPro.CompanyID);
                                dt.Rows.Add((EnumProductType)oPro.ProductType, ((DateTime)oSTItem.EntryDate).ToString("dd MMM yyyy"), oSTItem.StockCode, oCat.Description, oCom.Description, oSTItem.Product.ProductName, oSTItem.Color.Description, oSTItem.Quantity, oSTItem.PMPrice, (oSTItem.Quantity * oSTItem.PMPrice));
                                nCount++;
                            }

                            dt.TableName = "rptDataSet_StockInfo";
                            ds.Tables.Add(dt);

                            string embededResource = "INVENTORY.UI.RDLC.rptCompanyWiseStock.rdlc";
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            ReportParameter rParam = null;

                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);

                            rParam = new ReportParameter("SLNO", nCount.ToString());
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

                            rbCompany.Checked = false;
                            ctlBrand.SelectedID = 0;
                            RefreshControl();
                        }
                        else if(rbModel.Checked || ctlPreOrProduct.SelectedID>0)
                        {
                            nCount = 1;
                            rptDataSet.StockInfoDataTable dt = new rptDataSet.StockInfoDataTable();
                            DataSet ds = new DataSet();
                            foreach (Stock oSTItem in oStocks)
                            {
                                Product oPro = oProList.FirstOrDefault(o => o.ProductID == oSTItem.ProductID);
                                Category oCat = oCatList.FirstOrDefault(o => o.CategoryID == oPro.CategoryID);
                                Company oCom = oComList.FirstOrDefault(o => o.CompanyID == oPro.CompanyID);
                                dt.Rows.Add((EnumProductType)oPro.ProductType, ((DateTime)oSTItem.EntryDate).ToString("dd MMM yyyy"), oSTItem.StockCode, oCat.Description, oCom.Description, oSTItem.Product.ProductName, oSTItem.Color.Description, oSTItem.Quantity, oSTItem.PMPrice, (oSTItem.Quantity * oSTItem.PMPrice));
                                nCount++;
                                
                            }

                            dt.TableName = "rptDataSet_StockInfo";
                            ds.Tables.Add(dt);

                            string embededResource = "INVENTORY.UI.RDLC.StockInfo.rdlc";
                            
                            List<ReportParameter> parameters = new List<ReportParameter>();

                            ReportParameter rParam = null;

                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);

                            rParam = new ReportParameter("SLNO", nCount.ToString());
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

                            rbModel.Checked = false;
                            ctlPreOrProduct.SelectedID = 0;
                            RefreshControl();
                        }
                        else if (rbColorCode.Checked || ctlColor.SelectedID > 0)
                        {
                            nCount = 1;
                            rptDataSet.StockInfoDataTable dt = new rptDataSet.StockInfoDataTable();
                            DataSet ds = new DataSet();
                            foreach (Stock oSTItem in oStocks)
                            {

                                Product oPro = oProList.FirstOrDefault(o => o.ProductID == oSTItem.ProductID);
                                Category oCat = oCatList.FirstOrDefault(o => o.CategoryID == oPro.CategoryID);
                                Company oCom = oComList.FirstOrDefault(o => o.CompanyID == oPro.CompanyID);
                                INVENTORY.DA.Color oColor = oColList.FirstOrDefault(c => c.ColorID == oSTItem.ColorID);
                                dt.Rows.Add((EnumProductType)oPro.ProductType, ((DateTime)oSTItem.EntryDate).ToString("dd MMM yyyy"), oSTItem.StockCode, oCat.Description, oCom.Description, oPro.ProductName, oColor.Description, oSTItem.Quantity, oSTItem.PMPrice, (oSTItem.Quantity * oSTItem.PMPrice));
                                nCount++;
                            }

                            dt.TableName = "rprDataSet_StockInfo";
                            ds.Tables.Add(dt);

                            string embededResource = "INVENTORY.UI.RDLC.rptColorWise.rdlc";

                            
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            ReportParameter rParam = new ReportParameter();

                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);

                            rParam = new ReportParameter("SLNO", nCount.ToString());
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

                        }//


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

        private void ctlBrand_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlCategory_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlPreOrProduct_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void rbCompany_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(rbCompany.Checked)
                {
                    rbCategory.Checked = false;
                    rbModel.Checked = false;
                    ctlCategory.SelectedID = 0;
                    ctlPreOrProduct.SelectedID = 0;
                }
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
                if (rbCategory.Checked)
                {
                    rbCompany.Checked = false;
                    rbModel.Checked = false;
                    ctlBrand.SelectedID = 0;
                    ctlPreOrProduct.SelectedID = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void rbModel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbModel.Checked)
                {
                    rbCompany.Checked = false;
                    rbCategory.Checked = false;
                    ctlBrand.SelectedID = 0;
                    ctlCategory.SelectedID = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ctlColor_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
