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


namespace INVENTORY.UI
{
    public partial class fCollectionRpt : Form
    {
        public fCollectionRpt()
        {
            InitializeComponent();
        }
        private void fCollectionRpt_Load(object sender, EventArgs e)
        {

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";

                    DateTime fromDate = Convert.ToDateTime(dFromDate);
                    DateTime toDate = Convert.ToDateTime(sToDate);
                    List<CashCollection> oCashCollection = null;
                    List<Customer> oCustomers = null;
                    List<Supplier> oSuppList = null;

                    if (rbCashCollection.Checked || ctlCustomer.SelectedID>0)
                    {
                        if (ctlCustomer.SelectedID > 0)
                        {
                            oCashCollection = db.CashCollections.Where(o => o.EntryDate >= fromDate && o.EntryDate <= toDate && o.TransactionType == 2 && o.CustomerID == ctlCustomer.SelectedID).ToList();
                            oCustomers = db.Customers.ToList();
                        }
                        else
                        {
                            oCashCollection = db.CashCollections.Where(o => o.EntryDate >= fromDate && o.EntryDate <= toDate && o.TransactionType == 2).ToList();
                            oCustomers = db.Customers.ToList();
                        }

                    }
                    else if (rbCashDelivery.Checked || ctlSupplier.SelectedID>0)
                    {
                        if (ctlSupplier.SelectedID > 0)
                        {
                            oCashCollection = db.CashCollections.Where(o => o.EntryDate >= fromDate && o.EntryDate <= toDate && o.TransactionType == 1 && o.CompanyID == ctlSupplier.SelectedID).ToList();
                            oSuppList = db.Suppliers.ToList();
                        }
                        else
                        {
                            oCashCollection = db.CashCollections.Where(o => o.EntryDate >= fromDate && o.EntryDate <= toDate && o.TransactionType == 1).ToList();
                            oSuppList = db.Suppliers.ToList();
                        }

                    }

                    if (oCashCollection != null)
                    {
                        rptDataSet.dtCollectionRptDataTable dt = new rptDataSet.dtCollectionRptDataTable();
                        Customer customer = null;
                        Supplier oSupplier = null;
                        DataSet ds = new DataSet();

                        if (rbCashCollection.Checked || ctlCustomer.SelectedID>0)
                        {
                            foreach (CashCollection grd in oCashCollection)
                            {
                                customer = oCustomers.FirstOrDefault(o => o.CustomerID == grd.CustomerID);
                                string AccountNo = grd.AccountNo + grd.BKashNo + grd.MBAccountNo;
                                dt.Rows.Add(((DateTime)grd.EntryDate).ToString("dd MMM yyyy"), customer.Name, customer.Address, customer.ContactNo, customer.TotalDue, grd.Amount, (customer.TotalDue - grd.Amount), grd.AdjustAmt, (EnumPayType)grd.PaymentType, grd.BankName, AccountNo, grd.BranchName, grd.CheckNo, grd.MBAccountNo, grd.BKashNo, grd.ReceiptNo);
                            }

                            dt.TableName = "rptDataSet_dtCollectionRpt";
                            ds.Tables.Add(dt);
                            string embededResource = "INVENTORY.UI.RDLC.rptCollectionRpt.rdlc";
                            ReportParameter rParam = new ReportParameter();
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            rParam = new ReportParameter("Month", "Cash Collection From " + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
                            parameters.Add(rParam);
                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);

                            fReportViewer frm = new fReportViewer();
                            frm.CommonReportViewer(embededResource, ds, parameters, true);
                            rbCashCollection.Checked = false;
                            ctlCustomer.SelectedID = 0;

                        }
                        else if (rbCashDelivery.Checked || ctlSupplier.SelectedID>0)
                        {
                            foreach (CashCollection grd in oCashCollection)
                            {
                                oSupplier = oSuppList.FirstOrDefault(o => o.SupplierID == grd.CompanyID);
                                string AccountNo = grd.AccountNo + grd.BKashNo + grd.MBAccountNo;
                                dt.Rows.Add(((DateTime)grd.EntryDate).ToString("dd MMM yyyy"), oSupplier.Name, oSupplier.Address, oSupplier.ContactNo, oSupplier.TotalDue, grd.Amount, (oSupplier.TotalDue - grd.Amount), grd.AdjustAmt, (EnumPayType)grd.PaymentType, grd.BankName, AccountNo, grd.BranchName, grd.CheckNo, grd.MBAccountNo, grd.BKashNo, grd.ReceiptNo);
                            }

                            dt.TableName = "rptDataSet_dtCollectionRpt";
                            ds.Tables.Add(dt);
                            string embededResource = "INVENTORY.UI.RDLC.rptDeliveryRpt.rdlc";
                            ReportParameter rParam = new ReportParameter();
                            List<ReportParameter> parameters = new List<ReportParameter>();
                            rParam = new ReportParameter("Month", "Cash Delivery From " + fromDate.ToString("dd MMM yyyy") + " To " + toDate.ToString("dd MMM yyyy"));
                            parameters.Add(rParam);
                            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                            parameters.Add(rParam);

                            fReportViewer frm = new fReportViewer();
                            frm.CommonReportViewer(embededResource, ds, parameters, true);
                            rbCashDelivery.Checked = false;
                            ctlSupplier.SelectedID = 0;
                        }
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

        private void rbCashCollection_CheckedChanged(object sender, EventArgs e)
        {
            ctlCustomer.Enabled = true;
            ctlSupplier.SelectedID = 0;
            ctlSupplier.Enabled = false;
        }

        private void rbCashDelivery_CheckedChanged(object sender, EventArgs e)
        {
            ctlSupplier.Enabled = true;
            ctlCustomer.SelectedID = 0;
            ctlCustomer.Enabled = false;
        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlSupplier_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
