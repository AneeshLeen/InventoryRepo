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
    public partial class fCustomerDueRpt : Form
    {
        public fCustomerDueRpt()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<Customer> oCustomers = null;
                    List<Employee> oEmpsList=db.Employees.ToList();
                    //Employee oEmp=null;

                    if(ctlCustomer.SelectedID>0)
                    {
                        oCustomers=db.Customers.Where(c => c.CustomerID == ctlCustomer.SelectedID).ToList();
                        ctlCustomer.SelectedID = 0;
                    }
                    else if(chkRetail.Checked)
                    {
                        oCustomers = db.Customers.Where(c => c.CustomerType == (int)EnumCustomerType.Retail).ToList();
                        chkRetail.Checked = false;
                    }
                    else if(chkDealer.Checked)
                    {
                        oCustomers = db.Customers.Where(c => c.CustomerType == (int)EnumCustomerType.Dealer).ToList();
                        chkDealer.Checked = false;
                    }
                    else if(chkAll.Checked)
                    {
                        oCustomers=db.Customers.ToList();
                        chkAll.Checked = false;
                    }
                    else
                    {
                        oCustomers = db.Customers.ToList();
                        //chkCredit.Checked = false;
                    }

                    #region MO Wise Report
                    //if(chkMO.Checked)
                    //{
                    //    if(ctlEmployee.SelectedID>0)
                    //    {
                    //        oCustomers = db.Customers.Where(c => c.EmployeeID == ctlEmployee.SelectedID).ToList();
                    //        oEmp=oEmpsList.FirstOrDefault(emp=>emp.EmployeeID==ctlEmployee.SelectedID);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Please select Marketing Officer", "MO Wise Rpt.", MessageBoxButtons.OK);
                    //        return;
                    //    }
                    //}
                    #endregion

                    if (oCustomers != null)
                    {
                        rptDataSet.dtCustomerDataTable dt = new rptDataSet.dtCustomerDataTable();
                        //rptDataSet.dtDueStatementDataTable dtMO = new rptDataSet.dtDueStatementDataTable();

                        DataSet ds = new DataSet();
                        DataSet dsMO = new DataSet();

                        string embededResource = string.Empty;
                        ReportParameter rParam = null;
                        List<ReportParameter> parameters = null;
                        string LastTD = "";

                        #region For MO Wise Report
                        //if (chkMO.Checked)
                        //{
                        //    foreach (Customer grd in oCustomers)
                        //    {
                        //        if (grd.TotalDue > 0)
                        //        {
                        //            SOrder so = db.SOrders.Where(t => t.CustomerID == grd.CustomerID)
                        //                       .OrderByDescending(t => t.InvoiceDate)
                        //                       .FirstOrDefault();

                        //            CashCollection cc = db.CashCollections.Where(t => t.CustomerID == grd.CustomerID)
                        //                         .OrderByDescending(t => t.EntryDate)
                        //                         .FirstOrDefault();

                        //            if (so != null && cc != null)
                        //            {
                        //                if (so.InvoiceDate > cc.EntryDate)
                        //                {
                        //                    LastTD = so.InvoiceDate.ToString("dd MMM yyyy") + System.Environment.NewLine + "Good Delivery";
                        //                }
                        //                else
                        //                {
                        //                    LastTD = cc.EntryDate.Value.ToString("dd MMM yyyy") + System.Environment.NewLine + "Cash Collection";
                        //                }
                        //            }
                        //            else if (so == null && cc == null)
                        //            {
                        //                LastTD = "";
                        //            }
                        //            else if (so != null && cc == null)
                        //            {
                        //                LastTD = so.InvoiceDate.ToString("dd MMM yyyy") + System.Environment.NewLine + "Good Delivery";
                        //            }
                        //            else if (so == null && cc != null)
                        //            {
                        //                LastTD = cc.EntryDate.Value.ToString("dd MMM yyyy") + System.Environment.NewLine + "Cash Collection";
                        //            }

                        //            if (chkMO.Checked)
                        //            {
                        //                dtMO.Rows.Add("Name: "+grd.Name + System.Environment.NewLine + "Company:"+grd.CompanyName + System.Environment.NewLine + "Address:"+grd.Address + System.Environment.NewLine + "Contact:"+grd.ContactNo, LastTD, grd.TotalDue);
                        //            }
                        //        }
                        //    }

                        //}
                        //else
                        // #endregion

                       if(chkCredit.Checked!=true)
                       {
                           foreach (Customer grd in oCustomers)
                           {
                               if (grd.TotalDue + grd.CreditDue > 0)
                               {
                                   dt.Rows.Add(grd.Code, grd.Name, grd.CompanyName, (EnumCustomerType)grd.CustomerType, grd.ContactNo, grd.NID, grd.Address, grd.TotalDue + grd.CreditDue);
                               }
                           }

                       }
                       else
                       {
                           foreach (Customer grd in oCustomers)
                           {
                               if (grd.CreditDue > 0)
                               {
                                   dt.Rows.Add(grd.Code, grd.Name, grd.CompanyName, (EnumCustomerType)grd.CustomerType, grd.ContactNo, grd.NID, grd.Address, grd.CreditDue);
                               }
                           }

                       }
                          

                       

                       //  #region MO Wise Report
                        //if (chkMO.Checked)
                        //{
                        //    fReportViewer frm = new fReportViewer();
                        //    dtMO.TableName = "rptDataSet_dtDueStatement";
                        //    dsMO.Tables.Add(dtMO);

                        //    embededResource = "ESRP.UI.RDLC.rptNewCustomerDue.rdlc";
                        //    rParam = new ReportParameter();
                        //    parameters = new List<ReportParameter>();

                        //    rParam = new ReportParameter("MOName", oEmp.Name);
                        //    parameters.Add(rParam);

                        //    rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        //    parameters.Add(rParam);

                        //    if (dtMO.Rows.Count > 0)
                        //    {
                        //        frm.CommonReportViewer(embededResource, dsMO, parameters, true);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    ctlEmployee.SelectedID=0;
                        //}
                        //else
                        #endregion

                        {
                            dt.TableName = "rptDataSet_dtCustomer";
                            ds.Tables.Add(dt);
                            embededResource = "ESRP.UI.RDLC.rptCustomer.rdlc";
                            rParam = new ReportParameter();
                            parameters = new List<ReportParameter>();

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

                            ctlCustomer.SelectedID = 0;

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void chkRetail_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRetail.Checked)
            {
                ctlCustomer.SelectedID = 0;
                chkDealer.Checked = false;
                chkAll.Checked = false;
            }
        }

        private void chkDealer_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDealer.Checked)
            {
                ctlCustomer.SelectedID = 0;
                chkRetail.Checked = false;
                chkAll.Checked = false;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                ctlCustomer.SelectedID = 0;
                chkRetail.Checked = false;
                chkDealer.Checked = false;
            }
        }

        private void chkMO_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkMO.Checked)
            //{
            //    ctlEmployee.Enabled = true;
            //    ctlCustomer.Enabled = false;
            //    chkAll.Checked = false;
            //    chkRetail.Checked = false;
            //    chkDealer.Checked = false;
            //    chkProduction.Checked = false;
            //}
            //else
            {
                //ctlEmployee.Enabled = false;
                ctlCustomer.Enabled = true;

            }

        }

        private void ctlEmployee_SelectedItemChanged(object sender, EventArgs e)
        {

        }

    }
}
