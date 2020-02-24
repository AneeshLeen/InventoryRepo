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
    public partial class fSupplierLedger : Form
    {
        DEWSRMEntities db = null;
        public fSupplierLedger()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctlSupplier.SelectedID == 0)
                {
                    MessageBox.Show("Please at first select specific Supplier.", "Party Ledger.");
                    return;
                }
                DateTime preDate = new DateTime(2000, 3, 9, 16, 5, 7, 123);
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                DateTime dFFDate = Convert.ToDateTime(sFFdate);
                DateTime dTTDate = Convert.ToDateTime(sTTdate);
                rptDataSet.dtSupplierLederDataTable dt = new rptDataSet.dtSupplierLederDataTable();
                DataSet ds = new DataSet();
                Supplier oSupplier = db.Suppliers.FirstOrDefault(c => c.SupplierID == ctlSupplier.SelectedID);
               
                var PurchasesItem = db.POrders.Where(p => p.SupplierID == ctlSupplier.SelectedID && p.OrderDate >= preDate && p.OrderDate <= dTTDate).Where(p=>p.Status==1);
                if (PurchasesItem.ToList().Count > 0)
                {
                    foreach (var oItem in PurchasesItem)
                    {
                        dt.Rows.Add(oItem.OrderDate, oItem.ChallanNo, 0,oItem.GrandTotal,oItem.NetDiscount,    oItem.GrandTotal - oItem.NetDiscount, oItem.RecAmt,0, oItem.GrandTotal - oItem.NetDiscount - oItem.RecAmt, 0, 0, 0, "Purchase");                                          
                    }
                }


                var ReturnItem = db.Returns.Where(p => p.SupplierID == ctlSupplier.SelectedID && p.ReturnDate >= preDate && p.ReturnDate <= dTTDate);
                if (ReturnItem.ToList().Count > 0)
                {
                    foreach (var oItem in ReturnItem)
                    {
                        dt.Rows.Add(oItem.ReturnDate, oItem.InvoiceNo, 0, (-1) * oItem.GrandTotal, 0, (-1) * (oItem.GrandTotal - 0), (-1) * oItem.PaidAmount, 0, (-1) * (oItem.GrandTotal - 0 - oItem.PaidAmount), 0, 0, 0, "Purchase");
                    }
                }
                
                var CCashColl = db.CashCollections.Where(cc => cc.EntryDate >= preDate && cc.EntryDate <= dTTDate &&  cc.CompanyID== ctlSupplier.SelectedID).OrderByDescending(cc => cc.EntryDate);              
                int i = 1;
                if(CCashColl.ToList().Count>0)
                {
                    foreach (var oItem in CCashColl)
                    {
                        dt.Rows.Add(oItem.EntryDate, "Recp-000" + i, 0,0,0, 
                            0, 0, oItem.AdjustAmt, 0, 0,
                            oItem.Amount, 0, "CashCollection");                    
                        i++;
                    }
                }

                var BankCashColl = db.BankTransactions.Where(cc => cc.TranDate >= preDate && cc.TranDate <= dTTDate && cc.SupplierID == ctlSupplier.SelectedID).OrderByDescending(cc => cc.TranDate);
                i = 1;
                if (BankCashColl.ToList().Count > 0)
                {
                    foreach (var oItem in BankCashColl)
                    {
                        dt.Rows.Add(oItem.TranDate, oItem.TransactionNo, 0, 0, 0,
                            0, 0,0,0, 0, 
                            oItem.Amount, 0, "Bank Collection");
                        i++;
                    }
                }
                DataTable dtemp = dt.AsEnumerable().OrderBy(x => x.Field<DateTime>("RDate")).CopyToDataTable();
                dt = new rptDataSet.dtSupplierLederDataTable();
                decimal balance = 0;
                int index = 0;
                decimal CashAmt = 0;
                decimal OpeningDue = oSupplier.OpeningDue;
                decimal TotalDue = 0;
                decimal ClosingDue = 0;
                var oCashCollection= (dynamic)null;
             
                foreach (DataRow item in dtemp.Rows)
                {
                    if (index == 0)
                    {                  
                        OpeningDue = oSupplier.OpeningDue;                       
                    }
                    TotalDue = OpeningDue + Convert.ToDecimal(item["TotalAmount"].ToString()) - Convert.ToDecimal(item["RecAmount"].ToString()) - Convert.ToDecimal(item["AdjustAmt"].ToString());
                    ClosingDue = TotalDue - Convert.ToDecimal(item["CashCollection"].ToString());

                    item["TotalDue"] = TotalDue;
                    item["OpeningDue"] = OpeningDue;
                    item["ClosingDue"] = ClosingDue;
                    OpeningDue = ClosingDue;                 
                    index++;
                }
                foreach (DataRow item in dtemp.Rows)
                {
                    if ((DateTime)item["RDate"] >= dFFDate)
                        dt.ImportRow(item);
                }

                dt.TableName = "rptDataSet_dtSupllierLedger";
                ds.Tables.Add(dt);

                string embededResource = "ESRP.UI.RDLC.rptSupplierLedger.rdlc";

                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                rParam = new ReportParameter("Date", "From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                parameters.Add(rParam);

                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);

                rParam = new ReportParameter("CName", oSupplier.OwnerName);
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

                ctlSupplier.SelectedID = 0;

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
