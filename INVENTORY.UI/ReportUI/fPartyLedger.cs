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
using System.Configuration;
using System.Data.SqlClient;
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
    public partial class fPartyLedger : Form
    {
        DEWSRMEntities db = null;
        public fPartyLedger()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                DateTime Date = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                String RDate = Date.ToString("dd MMM yyyy");
                DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                DateTime dFFDate = Convert.ToDateTime(sFFdate);
                DateTime dTTDate = Convert.ToDateTime(sTTdate);

                rptDataSet.dtPartyLedgerDataTable dt = new rptDataSet.dtPartyLedgerDataTable();
                using (DEWSRMEntities db1 = new DEWSRMEntities())
                 {
                    using (var connection = db1.Database.Connection)
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "EXEC sp_CustomerLedger  " + "'" + sFFdate + "'" + "," + "'" + sTTdate + "'";
                        var reader = command.ExecuteReader();
                        var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<CustomerLedger>(reader).ToList();
                        
                        
                        foreach (var item in Data)
                        {

                            if(ctlCustomer.SelectedID==0)
                                 dt.Rows.Add(item.CustomerID, item.Name, item.Code,
                                item.InvoiceDate, item.InvoiceNo, item.SOrderID, item.Opening, item.CashSales,item.DueSales,
                                item.NetInstallment,item.HireInstallment,item.HirePerInstallment,item.NetPerInstallment,item.TotalPerInsAmt ,item.GrandSales,item.TotalDiscount,item.TotalSalesAmt,
                                item.TotalDue, item.CollectionAmt, item.TotalRecAmt, item.AdjustAmt, item.Closing);
                           
                            else
                            {
                                if(item.CustomerID==ctlCustomer.SelectedID)
                                {
                                    dt.Rows.Add(item.CustomerID, item.Name, item.Code,
                                 item.InvoiceDate, item.InvoiceNo, item.SOrderID, item.Opening, item.CashSales, item.DueSales,
                                 item.NetInstallment, item.HireInstallment, item.HirePerInstallment, item.NetPerInstallment, item.TotalPerInsAmt, item.GrandSales, item.TotalDiscount, item.TotalSalesAmt,
                                 item.TotalDue, item.CollectionAmt,item.TotalRecAmt,    item.AdjustAmt, item.Closing);                                                    
                                }

                            }
                        }
                    }
                }



                DataSet ds = new DataSet();

                dt.TableName = "rptDataSet_dtPartyLedger";
                ds.Tables.Add(dt);
                string embededResource = "INVENTORY.UI.RDLC.rptPartyLedger.rdlc";
                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                rParam = new ReportParameter("Date", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                parameters.Add(rParam);
                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);

                rParam = new ReportParameter("CName","");
                parameters.Add(rParam);
                
                //rParam = new ReportParameter("CName", "adf");
                //parameters.Add(rParam);
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
            catch (Exception ex)
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
