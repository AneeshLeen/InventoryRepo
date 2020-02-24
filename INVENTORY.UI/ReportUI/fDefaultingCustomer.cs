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
    public partial class fDefaultingCustomer : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;
        public fDefaultingCustomer()
        {
            InitializeComponent();
        }

        private void fDefaultingCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    //DateTime dFFDate = DateTime.Today;
                    string dFromDate = dtpFromDate.Text + " 12:00:00 AM";
                    string sToDate = dtpToDate.Text + " 11:59:59 PM";
                    dFFdate = Convert.ToDateTime(dFromDate);
                    dTTdate = Convert.ToDateTime(sToDate);

                    var sOders = (from c in db.Customers
                                  join o in db.CreditSales on c.CustomerID equals o.CustomerID
                                  join od in db.CreditSalesDetails on o.CreditSalesID equals od.CreditSalesID
                                  where (od.MonthDate >= dFFdate && od.MonthDate <= dTTdate)
                                  //where (od.MonthDate < dFFDate && od.PaymentStatus == "Due")
                                  group od by new { o.CustomerID, c.Code, c.Name, c.ContactNo,c.Address } into g //c.CompanyName
                                  select new
                                  {
                                      code = g.Key.Code,
                                      name = g.Key.Name, //g.Key.CompanyName
                                      contact = g.Key.ContactNo,
                                      Address=g.Key.Address,
                                      count = g.Count(),
                                      amount = g.Sum(od => od.InstallmentAmt)
                                  }).ToList();


                
                    rptDataSet.dtDefaultingCustomerDataTable dt = new rptDataSet.dtDefaultingCustomerDataTable();


                    DataSet ds = new DataSet();

                    foreach (var item in sOders)
                    {


                        dt.Rows.Add(item.code, item.name + "," + item.Address + "," + item.contact, item.contact, item.count, item.amount);

                    }
                    dt.TableName = "rptDataSet_dtDefaultingCustomer";
                    ds.Tables.Add(dt);
                    string embededResource = "INVENTORY.UI.RDLC.rptDefaultingCustomer.rdlc";
                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    rParam = new ReportParameter("Date", " Till " + dFFdate.ToString("dd MMM yyyy") + " To " + dTTdate.ToString("dd MMM yyyy"));
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
