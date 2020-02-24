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
    public partial class fBenefitRpt : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;

        public fBenefitRpt()
        {
            InitializeComponent();
        }

        private void fBenefitRpt_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {          
            try
            {
                using (DEWSRMEntities db1 = new DEWSRMEntities())
                {
                    string sFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";

                    using (var connection = db1.Database.Connection)
                    {
                     //var BenefitByProduct=   db1.Database.SqlQuery<BenefitByProduct>("EXEC ProductWiseBenefitReport " + "'" + sFromDate + "'" + "," + "'" + sToDate + "'");
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_ProductWiseBenefitReport " + "'" + sFromDate + "'" + "," + "'" + sToDate + "'";
                        var reader = command.ExecuteReader();
                        var BenefitByProduct = ((IObjectContextAdapter)db1).ObjectContext.Translate<ProductWiseBenefitReport>(reader).ToList();
                                       
                                                                                                                                                                                          

                            //DateTime dFromDate = dtpFromDate.Value;
                            //DateTime dToDate = dtpToDate.Value;
                        
                            dFFdate = Convert.ToDateTime(sFromDate);
                            dTTdate = Convert.ToDateTime(sToDate);



                            rptDataSet.dtBenefitRptDataTable dt = new rptDataSet.dtBenefitRptDataTable();
                            DataRow dr = null;

                        if(ctlPreOrProduct.SelectedID==0)
                        {
                            foreach (var item in BenefitByProduct)
                            {

                                dt.Rows.Add(item.Code, item.ProductName, item.CategoryName, item.IMENO, item.SalesTotal, item.Discount, item.NetSales, item.PurchaseTotal, item.CommisionProfit, item.HireProfit, item.HireCollection, item.TotalProfit);
                            }
                        }
                          
                        else
                        {
                            foreach (var item in BenefitByProduct)
                            {
                                if(ctlPreOrProduct.SelectedID==item.ProductID)
                                    dt.Rows.Add(item.Code, item.ProductName, item.CategoryName, item.IMENO, item.SalesTotal,item.Discount,item.NetSales,   item.PurchaseTotal, item.CommisionProfit, item.HireProfit, item.HireCollection, item.TotalProfit);
                            }
                        }



                            Product oProduct = null;
                            DataSet ds = new DataSet();
                   

                            dt.TableName = "rptDataSet_dtBenefitRpt";
                            ds.Tables.Add(dt);

                            string embededResource = "INVENTORY.UI.RDLC.BenefitRpt.rdlc";
                            ReportParameter rParam = new ReportParameter();
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            rParam = new ReportParameter("Month", "Comapny Benefit Report From " + dFFdate.ToString("dd MMM yyyy") + " To " + dTTdate.ToString("dd MMM yyyy"));
                            parameters.Add(rParam);

                            rParam = new ReportParameter("TotalBenefit", "");
                            parameters.Add(rParam);

                            rParam = new ReportParameter("TotalExpense", "");
                            parameters.Add(rParam);

                            rParam = new ReportParameter("NetPay", "");
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
                                MessageBox.Show("No Recors Found.","Report",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }


                            ctlPreOrProduct.SelectedID = 0;
                   }
                }
            }
    
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlPreOrProduct_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
