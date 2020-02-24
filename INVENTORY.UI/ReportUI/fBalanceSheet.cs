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
using INVENTORY.DA;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace INVENTORY.UI
{
    public partial class fBalanceSheet: Form
    {
        DEWSRMEntities db = null;

        public fBalanceSheet()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
             
                double TotalAssetAmount = 0;
                double TotalLiabilityAmount = 0;
                double TotalBalance = 0;

                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                rptDataSet.dtBalanceDataTable dt = new rptDataSet.dtBalanceDataTable();  
                               
                TotalAssetAmount = 0;
                TotalLiabilityAmount = 0;
                TotalBalance = 0;
                   
                string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";

                DateTime dFFDate = Convert.ToDateTime(sFFdate);
                DateTime dTTDate = Convert.ToDateTime(sTTdate);

                using (DEWSRMEntities db1 = new DEWSRMEntities())
                {
                    using (var connection = db1.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_BalanceSheet  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                        var reader = command.ExecuteReader();
                        var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<BalanceSheet>(reader).ToList();

                        foreach (var item in Data)
                        {                      
                                dt.Rows.Add(item.Asset,item.AssetAmount,item.Liability,item.LiabilityAmount);
                                TotalAssetAmount = TotalAssetAmount + (double)item.AssetAmount;
                                TotalLiabilityAmount = TotalLiabilityAmount +(double) item.LiabilityAmount;
                        }

                    }

                    TotalBalance = TotalAssetAmount - TotalLiabilityAmount;

                DataSet ds = new DataSet();
                string embededResource = "";
                dt.TableName = "rptDataSet_dtBalancsSheet";                    
                ds.Tables.Add(dt);                     
                embededResource = "INVENTORY.UI.RDLC.rptBalanceSheet.rdlc";

                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                rParam = new ReportParameter("DateRange", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                parameters.Add(rParam);
                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);

                rParam = new ReportParameter("TotalAssetAmount", TotalAssetAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("TotalLiabilityAmount", TotalLiabilityAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("TotalBalance", TotalBalance.ToString());
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
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void fPartyLedger_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    fPartyLedger oFPLedger = new fPartyLedger();
            //    oFPLedger.ShowDialog();

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
