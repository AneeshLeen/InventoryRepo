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
    public partial class fCustomerWiseReturnDetails : Form
    {
        public fCustomerWiseReturnDetails()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctlCustomer.SelectedID <= 0)
                {
                    MessageBox.Show("Please select customer.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    IQueryable<Customer> c = db.Customers;
                    Customer oCustomer = c.FirstOrDefault(o => o.CustomerID == ctlCustomer.SelectedID);

                    List<Company> oComList = db.Companies.ToList();
                    DateTime fromDate = dtpFromDate.Value;
                    DateTime toDate = dtpToDate.Value;

                    string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                    string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                    DateTime dFFDate = Convert.ToDateTime(sFFdate);
                    DateTime dTTDate = Convert.ToDateTime(sTTdate);
                    rptDataSet.dtReturnProductWRptDataTable dt = new rptDataSet.dtReturnProductWRptDataTable();
                    DataSet ds = new DataSet();
                    DataRow row = null;
                    var AllReturns = db.Returns.Where(r => r.CustomerID == ctlCustomer.SelectedID && r.ReturnDate >= dFFDate && r.ReturnDate <= dTTDate).ToList();
                    var RetrunData = (from RTD in db.ReturnDetails
                                      join RT in db.Returns on RTD.ReturnID equals RT.ReturnID
                                      join P in db.Products on RTD.ProductID equals P.ProductID
                                      join COM in db.Companies on P.CompanyID equals COM.CompanyID
                                      join CAT in db.Categorys on P.CategoryID equals CAT.CategoryID
                                      join MOD in db.Models on P.ModelID equals MOD.ModelID
                                      join STD in db.StockDetails on RTD.SDetailID equals STD.SDetailID
                                      join CLR in db.Colors on STD.ColorID equals CLR.ColorID
                                      where RT.CustomerID == ctlCustomer.SelectedID
                                      select new
                                      {
                                          RT.ReturnDate,
                                          ProductName = P.ProductName,
                                          ComapnyName = COM.Description,
                                          CategoryName = CAT.Description,
                                          ModelName = MOD.Description,
                                          ColorName = CLR.Description,
                                          RTD.Quantity,
                                          RTD.UnitPrice,
                                          RTD.UTAmount
                                      }).ToList();

                    foreach (var item in RetrunData)
                    {
                        row = dt.NewRow();
                        row["RDate"] = item.ReturnDate;
                        row["ItemName"] = item.ProductName;
                        row["Brand"] = item.ComapnyName;
                        row["Model"] = item.CategoryName;
                        row["Size"] = item.ColorName;
                        row["Qty"] = item.Quantity;
                        row["UPrice"] = item.UnitPrice;
                        row["Amount"] = item.UTAmount;
                        dt.Rows.Add(row);
                    }

                    dt.TableName = "rptDataSet_dtReturnProductWRpt";
                    ds.Tables.Add(dt);
                    string embededResource = "ESRP.UI.RDLC.rptProductWReturns.rdlc";
                    ReportParameter rParam = new ReportParameter();
                    List<ReportParameter> parameters = new List<ReportParameter>();

                    rParam = new ReportParameter("Date", "Return report for the date From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                    parameters.Add(rParam);

                    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                    parameters.Add(rParam);

                    rParam = new ReportParameter("CustomerCode", "Code: " + oCustomer.Code);
                    parameters.Add(rParam);
                    rParam = new ReportParameter("CustomerName", oCustomer.Name);
                    parameters.Add(rParam);
                    rParam = new ReportParameter("CustomerContactNo", "Contact No.: " + oCustomer.ContactNo);
                    parameters.Add(rParam);
                    rParam = new ReportParameter("CustomerAddress", "Address: " + oCustomer.Address);
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

        private void ctlCustomer_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCustomer_Load(object sender, EventArgs e)
        {

        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
