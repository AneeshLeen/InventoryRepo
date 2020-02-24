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
    public partial class fDailyCollection : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;
        public fDailyCollection()
        {
            InitializeComponent();
        }

        private void fDailyCollection_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    fReportViewer fRptViewer = new fReportViewer();
                    CreditSale oCreditSales = new CreditSale();

                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";
                    dFFdate = Convert.ToDateTime(dFromDate);
                    dTTdate = Convert.ToDateTime(sToDate);

                    var oCSalesDetails = (from cs in db.CreditSales
                                          join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
                                          join cus in db.Customers on cs.CustomerID equals cus.CustomerID
                                          //join pro in db.Products on cs.ProductID equals pro.ProductID
                                          where (csd.PaymentDate >= dFFdate && csd.PaymentDate <= dTTdate) && csd.PaymentStatus == "Paid"
                                          select new
                                          {
                                              cs.InvoiceNo,
                                              cus.Code,
                                              Name = cus.Name + "," + cus.Address + "," + cus.ContactNo,
                                              cus.ContactNo,
                                              cus.Address,
                                              //pro.ProductName,
                                              cs.SalesDate,
                                              csd.PaymentDate,
                                              cs.TSalesAmt,
                                              cs.NetAmount,
                                              cs.FixedAmt,
                                              cs.Remaining,
                                              csd.InstallmentAmt,
                                              csd.Remarks,
                                              cs.DownPayment,
                                            
                                          }
                                  );

                    var oCSDs = oCSalesDetails.ToList();

                    rptDataSet.dtInstallmentCollectionDataTable dt = new rptDataSet.dtInstallmentCollectionDataTable();
                    DataSet ds = new DataSet();

                    foreach (var oCSDItem in oCSDs)
                    {
                        dt.Rows.Add(
                            oCSDItem.InvoiceNo,
                            oCSDItem.Code,  
                            oCSDItem.Name,
                            oCSDItem.ContactNo,
                           oCSDItem.Address, 
                            oCSDItem.SalesDate,
                            oCSDItem.PaymentDate,
                            oCSDItem.TSalesAmt,
                            oCSDItem.NetAmount,
                            oCSDItem.FixedAmt, 
                            oCSDItem.Remaining, 
                            oCSDItem.InstallmentAmt, 
                            oCSDItem.Remarks,
                            oCSDItem.DownPayment
                   );
                    }

                    dt.TableName = "rptDataSet_dtInstallmentCollection";
                    ds.Tables.Add(dt);
                    string embededResource = "ESRP.UI.RDLC.InstallmentCollection.rdlc";

                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();

                    //rParam = new ReportParameter("PaymentDate", dFFdate.ToString("dd MMM yyyy"));
                    //parameters.Add(rParam);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
