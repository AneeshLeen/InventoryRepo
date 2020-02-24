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
    public partial class fMISRpt : Form
    {
        public fMISRpt()
        {
            InitializeComponent();
        }

        private void fMISRpt_Load(object sender, EventArgs e)
        {

        }

        private void btnDailySalesRpt_Click(object sender, EventArgs e)
        {
            fDailySaleReport oFDSales = new fDailySaleReport();
            oFDSales.ShowDialog();
        }


        private void btnMonthlySales_Click(object sender, EventArgs e)
        {
            fOrderMonthlyReport oFPOrders = new fOrderMonthlyReport();
            oFPOrders.ShowDialog();

        }

        private void btnYearlySales_Click(object sender, EventArgs e)
        {
            fYearlySaleReport oFPOrders = new fYearlySaleReport();
            oFPOrders.ShowDialog();

        }

        private void btnDailyPurchase_Click(object sender, EventArgs e)
        {
            fDailyPurchaseRpt oFDPurchaseRpt = new fDailyPurchaseRpt();
            oFDPurchaseRpt.ShowDialog();

        }

        private void btnMPurchaseRpt_Click(object sender, EventArgs e)
        {
            fPurchaseMonthly oFPMonthly = new fPurchaseMonthly();
            oFPMonthly.ShowDialog();

        }

        private void btnYearlyPurchase_Click(object sender, EventArgs e)
        {
            fPurchaseYearly oFPYearly = new fPurchaseYearly();
            oFPYearly.ShowDialog();

        }

        private void btnMonthlyExpense_Click(object sender, EventArgs e)
        {
            fExpenditureReport oFPOrders = new fExpenditureReport();
            oFPOrders.ShowDialog();
        }

        private void btnCompanyBenefit_Click(object sender, EventArgs e)
        {
            fBenefitRpt oFBenefit = new fBenefitRpt();
            oFBenefit.ShowDialog();
        }
        private void btnStockRpt_Click(object sender, EventArgs e)
        {
            fStockRpt oFSRpt = new fStockRpt();
            oFSRpt.ShowDialog();
        }

        private void btnBenefitRpt_Click(object sender, EventArgs e)
        {
            fMonthlyBenefitShow oFMBShow = new fMonthlyBenefitShow();
            oFMBShow.ShowDialog();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnProductInfo_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<Product> oProducts = db.Products.ToList();

                    if (oProducts != null)
                    {
                        rptDataSet.dtProductsDataTable dt = new rptDataSet.dtProductsDataTable();
                        DataSet ds = new DataSet();
                        foreach (Product grd in oProducts)
                        {
                            dt.Rows.Add(grd.Code, grd.Category.Description, grd.ProductName);
                        }
                        dt.TableName = "rptDataSet_dtProducts";
                        ds.Tables.Add(dt);
                        string embededResource = "INVENTORY.UI.RDLC.rptProducts.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
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

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<Employee> oEmployees = db.Employees.ToList();

                    if (oEmployees != null)
                    {
                        rptDataSet.dtEmployeesDataTable dt = new rptDataSet.dtEmployeesDataTable();
                        DataSet ds = new DataSet();

                        foreach (Employee grd in oEmployees)
                        {
                            dt.Rows.Add(grd.Code,grd.Name,grd.Designation.Description,grd.ContactNo,grd.NID,grd.JoiningDate,grd.PresentAdd);
                        }

                        dt.TableName = "rptDataSet_dtEmployees";
                        ds.Tables.Add(dt);
                        string embededResource = "INVENTORY.UI.RDLC.rptEmployee.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
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

        private void btnSupplierRpt_Click(object sender, EventArgs e)
        {
            try
            {
                #region Garbage Code
                //using (DEWSRMEntities db = new DEWSRMEntities())
                //{
                //    List<Supplier> oSuppliers = db.Suppliers.ToList();

                //    if (oSuppliers != null)
                //    {
                //        rptDataSet.dtSupplierDataTable dt = new rptDataSet.dtSupplierDataTable();
                //        DataSet ds = new DataSet();

                //        foreach (Supplier grd in oSuppliers)
                //        {
                //            if(grd.TotalDue>0)
                //            {
                //                dt.Rows.Add(grd.Code, grd.Name, grd.OwnerName, grd.ContactNo, grd.Address, grd.TotalDue);
                //            }                            
                //        }

                //        dt.TableName = "rptDataSet_dtSupplier";
                //        ds.Tables.Add(dt);
                //        string embededResource = "INVENTORY.UI.RDLC.rptSupplier.rdlc";
                //        ReportParameter rParam = new ReportParameter();
                //        List<ReportParameter> parameters = new List<ReportParameter>();
                //        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                //        parameters.Add(rParam);
                //        fReportViewer frm = new fReportViewer();

                //        if (dt.Rows.Count > 0)
                //        {
                //            frm.CommonReportViewer(embededResource, ds, parameters, true);
                //        }
                //        else
                //        {
                //            MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }

                //    }
                //}
                #endregion

                fSupplierDueRpt oFSDRpt = new fSupplierDueRpt();
                oFSDRpt.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomerRpt_Click(object sender, EventArgs e)
        {
            try
            {
                #region Garbage Code
                //using (DEWSRMEntities db = new DEWSRMEntities())
                //{
                //    List<Customer> oCustomers = db.Customers.ToList();

                //    if (oCustomers != null)
                //    {
                //        rptDataSet.dtCustomerDataTable dt = new rptDataSet.dtCustomerDataTable();
                //        DataSet ds = new DataSet();

                //        foreach (Customer grd in oCustomers)
                //        {
                //            if(grd.TotalDue>0)
                //            {
                //                dt.Rows.Add(grd.Code, grd.Name, grd.CompanyName, grd.ContactNo, grd.NID, grd.Address, grd.TotalDue);
                //            }                            
                //        }

                //        dt.TableName = "rptDataSet_dtCustomer";
                //        ds.Tables.Add(dt);
                //        string embededResource = "INVENTORY.UI.RDLC.rptCustomer.rdlc";
                //        ReportParameter rParam = new ReportParameter();
                //        List<ReportParameter> parameters = new List<ReportParameter>();
                //        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                //        parameters.Add(rParam);
                //        fReportViewer frm = new fReportViewer();

                //        if (dt.Rows.Count > 0)
                //        {
                //            frm.CommonReportViewer(embededResource, ds, parameters, true);
                //        }
                //        else
                //        {
                //            MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }

                //    }
                //}
                #endregion
              

                fCustomerDueRpt oFCDRpt = new fCustomerDueRpt();
                oFCDRpt.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpcomingPayment_Click(object sender, EventArgs e)
        {
            fUpComingSchedule oFUpComSch = new fUpComingSchedule();
            oFUpComSch.ShowDialog();
        }

        private void btnDailyCashColl_Click(object sender, EventArgs e)
        {
            fDailyCollection oFDCashColl = new fDailyCollection();
            oFDCashColl.ShowDialog();
        }

        private void btnCreditSalesRpt_Click(object sender, EventArgs e)
        {
            fMonthlyCreditSales oFMCSRpt = new fMonthlyCreditSales();
            oFMCSRpt.ShowDialog();
        }

        private void btnCashRecDeliv_Click(object sender, EventArgs e)
        {
            fCollectionRpt oFCollRpt = new fCollectionRpt();
            oFCollRpt.ShowDialog();

        }

        private void btnCusWiseSalesDetails_Click(object sender, EventArgs e)
        {
            fCustomerWiseSales oFCusWiseSales = new fCustomerWiseSales();
            oFCusWiseSales.ShowDialog();
        }

        private void btnSuppWisePurchase_Click(object sender, EventArgs e)
        {
            fSupplierWisePurchase oFSuppWisePurchase = new fSupplierWisePurchase();
            oFSuppWisePurchase.ShowDialog();
        }

        private void btnDailyCreditSales_Click(object sender, EventArgs e)
        {
            fDailyCreditSales oFMCSRpt = new fDailyCreditSales();
            oFMCSRpt.ShowDialog();
        }

        private void btnPartyLedger_Click(object sender, EventArgs e)
        {
            fPartyLedger oFPLedger = new fPartyLedger();
            oFPLedger.ShowDialog();
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            fBalanceSheet oFBSheet = new fBalanceSheet();
            oFBSheet.ShowDialog();
        }

        private void btnPWSDetails_Click(object sender, EventArgs e)
        {
            fPWSalesRpt oFPSRpt = new fPWSalesRpt();
            oFPSRpt.ShowDialog();
        }

        private void btnPSDetails_Click(object sender, EventArgs e)
        {
            fPSalesDetails oFPSDetails = new fPSalesDetails();
            oFPSDetails.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fPPurchaseDetails oFPPDetails = new fPPurchaseDetails();
            oFPPDetails.ShowDialog();
        }

        private void btnDCStatement_Click(object sender, EventArgs e)
        {
            fDailyCashStatment oFDCStatement = new fDailyCashStatment();
            oFDCStatement.ShowDialog();
        }

        private void btnDamageReport_Click(object sender, EventArgs e)
        {
            fDamageRpt oFDRpt = new fDamageRpt();
            oFDRpt.ShowDialog();
        }

        private void btnSupplierLedger_Click(object sender, EventArgs e)
        {
            fSupplierLedger oFPLedger = new fSupplierLedger();
            oFPLedger.ShowDialog();
        }

        private void btnDefaultCus_Click(object sender, EventArgs e)
        {
            fDefaultingCustomer oFDCustomer = new fDefaultingCustomer();
            oFDCustomer.ShowDialog();
        }

        private void btnCustomerDueReport_Click(object sender, EventArgs e)
        {
            fCustomerDueReport frm = new fCustomerDueReport();
            frm.ShowDialog();
        }

        private void btnStockVSSalesSummary_Click(object sender, EventArgs e)
        {
            fStockVSSalesSummary frm = new fStockVSSalesSummary();
            frm.ShowDialog();
            
        }

        private void btnTrialBalance_Click(object sender, EventArgs e)
        {


            fTrialBalance frm = new fTrialBalance();
            frm.ShowDialog();

        }

        private void btnDailyLedger_Click(object sender, EventArgs e)
        {
            fDailyLedger frm = new fDailyLedger();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fBenefitRpt oFBenefit = new fBenefitRpt();
            oFBenefit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fCustomerWseBenefit frm = new fCustomerWseBenefit();
            frm.ShowDialog();
        }

        private void btnYearlyBenefit_Click(object sender, EventArgs e)
        {
            fYearlyBenefitShow frm = new fYearlyBenefitShow();
            frm.ShowDialog();
        }

        private void btnCusWiseReturn_Click(object sender, EventArgs e)
        {
            fCustomerWiseReturnDetails oFCWReturnDetails = new fCustomerWiseReturnDetails();
            oFCWReturnDetails.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fProfitAndLoss frm = new fProfitAndLoss();
            frm.ShowDialog();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
        //    fBalanceSheet frm = new fBalanceSheet();
        //    frm.ShowDialog();

            fDailySummary frm = new fDailySummary();
            frm.ShowDialog();
        }

        private void btnBankLedger_Click(object sender, EventArgs e)
        {
            fBankLedger frm = new fBankLedger();
            frm.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
