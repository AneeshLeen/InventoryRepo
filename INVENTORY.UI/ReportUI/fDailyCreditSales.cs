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
    public partial class fDailyCreditSales : Form
    {
        public fDailyCreditSales()
        {
            InitializeComponent();
        }

        private void fMonthlyCreditSales_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    DateTime fromDate = dtpFromDate.Value;
                    DateTime toDate =dtpToDate.Value;

                   
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                    DateTime dFFDate = fromDate;
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);
                    

                    List<CreditSale> oCreditSales = db.CreditSales.Where(o => o.SalesDate >= dFFDate && o.SalesDate <= dTTDate).ToList();

                    if (oCreditSales != null)
                    {
                        rptDataSet.dtMonthlyCreditDataTable dt = new rptDataSet.dtMonthlyCreditDataTable();
                        DataSet ds = new DataSet();
                        foreach (CreditSale grd in oCreditSales)
                        {
                            dt.Rows.Add(grd.SalesDate,grd.InvoiceNo,grd.Customer.Name,"",grd.TSalesAmt,grd.Discount,grd.FixedAmt,grd.NetAmount,grd.DownPayment,grd.Remaining);
                        }

                        dt.TableName = "rptDataSet_dtMonthlyCredit";
                        ds.Tables.Add(dt);
                        string embededResource = "INVENTORY.UI.RDLC.rptMonthlyCreditSales.rdlc";

                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("Month", "Salse From : " + dFFDate.ToString("dd MMM yyyy") + " To " + dTTDate.ToString("dd MMM yyyy"));
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
    }
}
