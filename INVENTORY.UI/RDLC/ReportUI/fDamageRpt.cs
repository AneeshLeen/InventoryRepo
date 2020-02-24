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
    public partial class fDamageRpt : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;

        public fDamageRpt()
        {
            InitializeComponent();
        }

        private void fDamageRpt_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    string sFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";

                    dFFdate = Convert.ToDateTime(sFromDate);
                    dTTdate = Convert.ToDateTime(sToDate);


                    List<DamageProduct> oDamageList = db.DamageProducts.Where(d => d.EntryDate >= dFFdate && d.EntryDate <= dTTdate).ToList();

                    rptDataSet.dtDamageProDataTable dt = new rptDataSet.dtDamageProDataTable();
                    Product oProduct = null;
                    DataSet ds = new DataSet();
                    List<Product> oProducts = db.Products.ToList();
                    List<Category> oCatList = db.Categorys.ToList();
                    List<Company> oComList = db.Companies.ToList();
                    //List<ESRP.DA.Color> oColorList=db.Colors.ToList();

                    foreach (DamageProduct oItem in oDamageList)
                    {

                        oProduct = oProducts.FirstOrDefault(o => o.ProductID == oItem.ProductID);
                        Category oCat = oCatList.FirstOrDefault(o => o.CategoryID == oProduct.CategoryID);
                        Company oCom = oComList.FirstOrDefault(o => o.CompanyID == oProduct.CompanyID);
                        //ESRP.DA.Color oColor = oColorList.FirstOrDefault(o => o.ColorID == oItem.);
                        dt.Rows.Add((EnumProductType)oProduct.ProductType, oItem.EntryDate, oProduct.ProductName, oCom.Description, oCat.Description, "", oItem.Qty, oItem.UnitPrice, oItem.Qty * oItem.UnitPrice);
                    }

                    dt.TableName = "rptDataSet_dtDamagePro";
                    ds.Tables.Add(dt);

                    string embededResource = "ESRP.UI.RDLC.rptDamageInfo.rdlc";
                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("Month", "Damage Product Report From : " + dFFdate.ToString("dd MMM yyyy") + " To " + dTTdate.ToString("dd MMM yyyy"));
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
    }
}
