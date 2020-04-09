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

using System.Data.Entity.Infrastructure;
using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraPrinting;

namespace INVENTORY.UI
{
    public partial class FNewMainForm : Form
    {
        string sUser = "";
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;

        #region For DB Backup
        string sCommand = string.Empty;
        string DataBase = string.Empty;
        string ConnString = string.Empty;
        string sFileName = string.Empty;
        string sFilePath = string.Empty;

        #endregion

        public FNewMainForm()
        {
            InitializeComponent();

            SevendaysSale();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCustomers ofCustomers = new fCustomers();
            ofCustomers.ShowDialog();

        }

        private void systemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSystemInformation oFSystemInfo = new fSystemInformation();
            oFSystemInfo.ShowDialog();

        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCompanies oFCom = new fCompanies();
            oFCom.ShowDialog();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fColorInfos oFCInfos = new fColorInfos();
            oFCInfos.ShowDialog();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCategorys oFCategories = new fCategorys();
            oFCategories.ShowDialog();

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProducts ofProducts = new fProducts();
            ofProducts.ShowDialog();

        }

        private void designationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDesignations ofDesignations = new fDesignations();
            ofDesignations.ShowDialog();

        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fEmployees oFEmployees = new fEmployees();
            oFEmployees.ShowDialog();

        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fCustomer frm = new fCustomer();
               // frm.ItemChanged = RefreshList;
                frm.ShowDlg(new Customer(), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         

        }

        private void salesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSOrders ofOrder = new fSOrders();
            ofOrder.ShowDialog();

        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPurchaseOrders oFPOrders = new fPurchaseOrders();
            oFPOrders.ShowDialog();

        }

        private void dailySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDailySaleReport oFPOrders = new fDailySaleReport();
            oFPOrders.ShowDialog();
        }

        private void dailyPurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDailyPurchaseRpt oFDPurchaseRpt = new fDailyPurchaseRpt();
            oFDPurchaseRpt.ShowDialog();
        }

        private void weeklySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void weeklyPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDailyPurchaseRpt oFDPRpt = new fDailyPurchaseRpt();
            oFDPRpt.ShowDialog();
        }

        private void monthlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fOrderMonthlyReport oFPOrders = new fOrderMonthlyReport();
            oFPOrders.ShowDialog();
        }

        private void monthlyPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPurchaseMonthly oFPMonthly = new fPurchaseMonthly();
            oFPMonthly.ShowDialog();
        }

        private void yearlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fYearlySaleReport oFPOrders = new fYearlySaleReport();
            oFPOrders.ShowDialog();
        }

        private void yearlyPurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPurchaseYearly oFPYearly = new fPurchaseYearly();
            oFPYearly.ShowDialog();
        }
        private void expenditureRepotrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fExpenditureReport oFPOrders = new fExpenditureReport();
            oFPOrders.ShowDialog();
        }

        private void FNewMainForm_Load(object sender, EventArgs e)
        {
            RefreshMenu();
            RefreshChart();

            #region For Renew Your System
            //DateTime dTExpireDate = new DateTime(2017, 1, 10);
            //DateTime dTillDate = DateTime.Now;

            //var NoOfDays = dTExpireDate - dTillDate;
            //double Days = NoOfDays.Days;

            //if (Days <= 20)
            //{
            //    lblRenew.Visible = true;
            //    lblRenew.Text = "Please Renew your Software before date of:  " +dTExpireDate;
            //    MessageBox.Show("Your Validity period of your system has expired date of " + dTExpireDate + ". Please contact with BD Technology.", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    lblRenew.Visible = false;
            //}

            #endregion

            LoadCreditScedule();
            DailyBalanceProcess();

        }

        private void LoadCreditScedule()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                DateTime fromday = DateTime.Today;
                DateTime to = DateTime.Today.AddHours(23).AddMinutes(59);




                DateTime fromDate = DateTime.Today;
                DateTime toDate =DateTime.Today.AddHours(23).AddMinutes(59);

                string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                dFFdate = Convert.ToDateTime(sFFdate);
                dTTdate = Convert.ToDateTime(sTTdate);



                #region Credit Sales

                var oCSalesDetails = (
                               from cs in db.CreditSales
                               join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
                               join cus in db.Customers on cs.CustomerID equals cus.CustomerID
                               //join pro in db.Products on cs.ProductID equals pro.ProductID
                               where (csd.PaymentDate <= dTTdate && csd.PaymentStatus == "Due" && csd.RemindDateForInstallment == null)
                               select new
                               {
                                   EmployeeID = 1,
                                   Name = cus.Name,
                                   cs.InvoiceNo,
                                   cs.CreditSalesID,
                                   cus.Code,
                                   cus.CustomerID,
                                   EMPName = "",
                                   RefName = cus.RefName + "," + cus.RefContact,
                                   cus.ContactNo,
                                   cus.Address,
                                   // pro.ProductName,
                                   cs.SalesDate,
                                   csd.PaymentDate,
                                   cs.TSalesAmt,
                                   cs.NetAmount,
                                   cs.FixedAmt,
                                   cs.NoOfInstallment,
                                   Remaining = cs.TSalesAmt - cs.DownPayment,
                                   csd.PaymentStatus,
                                   csd.Remarks,
                                   cs.DownPayment,
                                   InsRec = cs.TSalesAmt - cs.DownPayment - cs.Remaining,
                                   TotalRec = cs.TSalesAmt - cs.Remaining,
                                   closing = cs.Remaining,
                                   InstallmentAmt = csd.InstallmentAmt.Value,
                                   csd.RemindDateForInstallment
                               }
                              ).ToList();

                var oCSalesDetailsForRemindDate = (
                              from cs in db.CreditSales
                              join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
                              join cus in db.Customers on cs.CustomerID equals cus.CustomerID
                              //join pro in db.Products on cs.ProductID equals pro.ProductID
                              where (csd.RemindDateForInstallment <= dTTdate && csd.PaymentStatus == "Due" && csd.RemindDateForInstallment != null)
                              select new
                              {
                                  EmployeeID = 1,
                                  Name = cus.Name,
                                  cs.InvoiceNo,
                                  cs.CreditSalesID,
                                  cus.Code,
                                  cus.CustomerID,
                                  EMPName = "",
                                  cus.RefName,
                                  cus.ContactNo,
                                  cus.Address,
                                  // pro.ProductName,
                                  cs.SalesDate,
                                  csd.PaymentDate,
                                  cs.TSalesAmt,
                                  cs.NetAmount,
                                  cs.FixedAmt,
                                  cs.NoOfInstallment,
                                  Remaining = cs.TSalesAmt - cs.DownPayment,
                                  csd.PaymentStatus,
                                  csd.Remarks,
                                  cs.DownPayment,
                                  InsRec = cs.TSalesAmt - cs.DownPayment - cs.Remaining,
                                  TotalRec = cs.TSalesAmt - cs.Remaining,
                                  closing = cs.Remaining,
                                  InstallmentAmt = csd.InstallmentAmt.Value,
                                  csd.RemindDateForInstallment

                              }
                             ).ToList();




                oCSalesDetails.AddRange(oCSalesDetailsForRemindDate);

                var oCSalesDetailsSorting = oCSalesDetails.OrderByDescending(o => o.PaymentDate);

                var oCSalesDetailsGroup = (from csd in oCSalesDetailsSorting
                                           group csd by new
                                           {

                                               csd.EMPName,
                                               csd.EmployeeID,
                                               csd.Code,
                                               csd.Name,
                                               csd.CustomerID,
                                               csd.RefName,
                                               csd.ContactNo,
                                               csd.Address,

                                               csd.CreditSalesID,
                                               csd.SalesDate,
                                               //  csd.PaymentDate,
                                               csd.InvoiceNo,
                                               csd.TSalesAmt,
                                               csd.DownPayment,
                                               csd.NetAmount,
                                               csd.FixedAmt,
                                               csd.NoOfInstallment,
                                               csd.Remaining, // Remaining after Downpayment
                                               csd.Remarks,
                                               csd.closing,  // remainig field
                                               csd.InsRec,
                                               csd.TotalRec
                                          


                                           } into g
                                           select new
                                           {
                                               g.Key.EMPName,
                                               g.Key.EmployeeID,
                                              
                                             
                                               g.Key.CustomerID,
                                               g.Key.DownPayment,
                                               g.Key.InvoiceNo,
                                               g.Key.RefName,
                                             
                                               g.Key.SalesDate,
                                               //  g.Key.PaymentDate,
                                               g.Key.CreditSalesID,
                                               g.Key.TSalesAmt,
                                               g.Key.Remaining,
                                               g.Key.NetAmount,
                                               g.Key.FixedAmt,
                                               g.Key.NoOfInstallment,
                                               g.Key.Remarks,
                                               g.Key.closing,  // remainig field
                                               g.Key.InsRec,
                                               g.Key.TotalRec,
                                               TotalPaymentDue = g.Sum(o => o.InstallmentAmt),

                                               PaymentDate = g.Select(o => o.PaymentDate).FirstOrDefault(),
                                               Code = g.Key.Code,
                                               Name = g.Key.Name,
                                               ContactNo =g.Key.ContactNo,
                                               Address = g.Key.Address,
                                               InstallmentAmt = g.Sum(o => o.InstallmentAmt),
                                               Type = "Credit"

                                           }
                                          );


                var oCSDs = oCSalesDetailsGroup.ToList();
                rptDataSet.dtUpcomingScheduleDataTable dt = new rptDataSet.dtUpcomingScheduleDataTable();
                DataSet ds = new DataSet();



               

                foreach (var oCSDItem in oCSDs)
                {

                    decimal defaultInstallment = 0m;


                    var deafult = oCSalesDetails.Where(o => o.PaymentDate < dFFdate && o.RemindDateForInstallment == null && o.CustomerID == oCSDItem.CustomerID);

                    if (deafult.ToList().Count != 0)
                        defaultInstallment = deafult.Sum(o => o.InstallmentAmt);

                    var deafultForRemind = oCSalesDetails.Where(o => o.RemindDateForInstallment < dFFdate && o.RemindDateForInstallment != null && o.CustomerID == oCSDItem.CustomerID);
                    if (deafultForRemind.ToList().Count != 0)
                        defaultInstallment = defaultInstallment + deafultForRemind.Sum(o => o.InstallmentAmt);

                    DateTime? RemindDate = oCSalesDetails.Where(o => o.PaymentDate >= dFFdate && o.PaymentDate <= dTTdate && o.CustomerID == oCSDItem.CustomerID).Select(o => o.RemindDateForInstallment).FirstOrDefault();
                    var oCSP = (from CSP in db.CreditSaleProducts
                                join P in db.Products on CSP.ProductID equals P.ProductID
                                where (CSP.CreditSalesID == oCSDItem.CreditSalesID)
                                select new
                                {
                                    P.ProductName
                                });

                    string joinedString = string.Join(",", oCSP.Select(p => p.ProductName));

                    dt.Rows.Add(
                         oCSDItem.EMPName,
                         oCSDItem.InvoiceNo,
                         oCSDItem.Code,
                         oCSDItem.Name,
                         oCSDItem.RefName,
                         oCSDItem.ContactNo,
                         oCSDItem.Address,
                         joinedString,
                         oCSDItem.SalesDate,
                         oCSDItem.PaymentDate,
                         oCSDItem.TSalesAmt,
                         oCSDItem.NetAmount,
                         oCSDItem.FixedAmt,
                         oCSDItem.NoOfInstallment,
                         oCSDItem.Remaining,
                         Math.Round((decimal)oCSDItem.TotalPaymentDue, 0),
                         oCSDItem.InsRec, oCSDItem.Remarks,
                         oCSDItem.DownPayment,
                         oCSDItem.InsRec,
                         oCSDItem.TotalRec,
                         oCSDItem.closing,
                         RemindDate,
                         Math.Round((decimal)defaultInstallment, 0),
                         "Credit"
                         );

                }
                #endregion

                #region Get Sales By Remind Date. Date: 11-12-18

                var tempCashCollection = (from so in db.CashCollections


                                          join c in db.Customers on so.CustomerID equals c.CustomerID
                                          where (c.TotalDue > 0 && so.CompanyID == null && (so.RemindDate >= dFFdate && so.RemindDate <= dTTdate && so.RemindPeriod != 0))
                                          select new
                                          {
                                              c.CustomerID,
                                              Code = c.Code,
                                              Name =  c.Name ,
                                              RefName = c.RefName ,
                                              ContactNo = c.ContactNo,
                                              Address = c.Address,
                                              TotalDue = c.TotalDue,
                                              SOrderID = so.CashCollectionID,
                                              InvoiceNo = so.ReceiptNo,
                                              OrderInovice = so.ReceiptNo.Substring(4),
                                              InvoiceDate = so.EntryDate,
                                              so.RemindDate,
                                              TotalAmount = 0m,
                                              ProductName = "",
                                              SType = "Cash"
                                          }).OrderByDescending(i => i.InvoiceDate).ThenByDescending(i => i.OrderInovice).ToList();


                var tempSales = (from so in db.SOrders
                                 join sod in db.SOrderDetails on so.SOrderID equals sod.SOrderID
                                 join p in db.Products on sod.ProductID equals p.ProductID
                                 join c in db.Customers on so.CustomerID equals c.CustomerID
                                 where (c.TotalDue > 0 && so.Status == (int)EnumSalesType.Sales && (so.RemindDate >= dFFdate && so.RemindDate <= dTTdate && so.RemindPeriod != 0))
                                 select new
                                 {
                                     c.CustomerID,
                                     Code = c.Code,
                                     Name = c.Name ,
                                     RefName = c.RefName,
                                     ContactNo = c.ContactNo,
                                     Address = c.Address,
                                     TotalDue = c.TotalDue,
                                     so.SOrderID,
                                     so.InvoiceNo,
                                     OrderInovice = so.InvoiceNo.Substring(4),
                                     so.InvoiceDate,
                                     so.RemindDate,
                                     so.TotalAmount,

                                     p.ProductName,
                                     SType = "Cash"
                                 }).OrderByDescending(i => i.InvoiceDate).ThenByDescending(i => i.OrderInovice).ToList();

                tempSales.AddRange(tempCashCollection);
                tempSales = tempSales.OrderByDescending(o => o.InvoiceDate).ToList();

                var temp2Sales = (from so in tempSales
                                  group so by new { so.CustomerID, so.Code, so.Name, so.ContactNo, so.Address, so.TotalDue, so.InvoiceDate, so.TotalAmount, so.RefName } into g
                                  select new
                                  {
                                      g.Key.CustomerID,
                                      g.Key.Code,
                                      g.Key.ContactNo,
                                      g.Key.Name,
                                      g.Key.RefName,
                                      g.Key.Address,
                                      g.Key.TotalDue,
                                      SOrderID = g.Select(o => o.SOrderID).FirstOrDefault(),
                                      InvoiceNo = g.Select(o => o.InvoiceNo).FirstOrDefault(),
                                      InvoiceDate = g.Key.InvoiceDate,
                                      RemindDate = g.Select(o => o.RemindDate).FirstOrDefault(),
                                      TotalAmount = g.Key.TotalAmount,
                                      ProductName = g.Select(i => i.ProductName).ToList(),
                                      SType = g.Select(o => o.SType).FirstOrDefault(),
                                  });

                var Sales = (from so in temp2Sales
                             group so by new { so.CustomerID, so.Code, so.Name, so.ContactNo, so.Address, so.TotalDue } into g
                             select new
                             {
                                 g.Key.CustomerID,
                             
                                 g.Key.TotalDue,
                                 SOrderID = g.Select(i => i.SOrderID).FirstOrDefault(),
                                 InvoiceNo = g.Select(i => i.InvoiceNo).FirstOrDefault(),
                                 InvoiceDate = g.Select(i => i.InvoiceDate).FirstOrDefault(),
                                 RemindDate = g.Select(i => i.RemindDate).FirstOrDefault(),
                                 TotalAmount = g.Select(i => i.TotalAmount).FirstOrDefault(),
                                 ProductNameList = g.Select(i => i.ProductName).FirstOrDefault(),
                              
                                 Code = g.Key.Code,
                                 Name = g.Key.Name,
                                 ContactNo=g.Key.ContactNo,
                                 Address= g.Key.Address,
                                 InstallmentAmt = g.Select(i => i.TotalAmount).FirstOrDefault(),
                                 Type = "Credit"

                             });
                DataRow row = null;
                string ProductName = string.Empty;
                int Counter = 0;


                foreach (var item in Sales)
                {
                    row = dt.NewRow();
                    row["Employee"] = "";
                    row["InvoiceNo"] = item.InvoiceNo;
                    row["Code"] = item.Code;
                    row["CustomerName"] = item.Name;
                    row["RefName"] = "";
                    row["ContactNo"] = item.ContactNo;
                    row["CustomerAddress"] = item.Address;
                    foreach (var sitem in item.ProductNameList)
                    {
                        Counter++;
                        if (sitem.Count() == Counter)
                            ProductName = ProductName + sitem;
                        else
                            ProductName = ProductName + sitem + Environment.NewLine;

                    }
                    row["ProductName"] = ProductName;
                    row["SalesDate"] = item.InvoiceDate;
                    // row["PaymentDate"] = item.RemindDate;
                    row["SalesPrice"] = item.TotalAmount;
                    row["NetAmt"] = item.TotalAmount;
                    row["TotalAmt"] = item.TotalAmount;
                    row["NoOfInstallment"] = 0m;
                    row["RemainingAmt"] = item.TotalDue;
                    row["Installment"] = item.TotalDue;
                    row["CurrentPaid"] = 0m;
                    row["Remarks"] = "";
                    row["DownPayment"] = 0m;
                    row["InsRec"] = 0m;
                    row["TotalRec"] = 0m;
                    row["Closing"] = item.TotalDue;
                    row["RemindDate"] = item.RemindDate;
                    row["DefaultInstallment"] = 0m;
                    row["Type"] = "Cash";
                    dt.Rows.Add(row);
                    Counter = 0;
                    ProductName = string.Empty;
                  
                }
                #endregion


































                //var CreditSales = (from CSD in db.CreditSalesDetails
                //                   from CS in db.CreditSales
                //                   from C in db.Customers
                //                   where (CSD.CreditSalesID == CS.CreditSalesID && C.CustomerID == CS.CustomerID && CSD.MonthDate >= fromday && CSD.MonthDate <= to && CSD.PaymentStatus == "Due" &&CSD.RemindDateForInstallment==null)
                //                   select new CustomerWiseBenefitSummary
                //                   {
                //                       Code = C.Code,
                //                       Name = C.Name,
                //                       ContactNo = C.ContactNo,
                //                       Address = C.Address,
                //                       InstallmentAmt = (decimal)CSD.InstallmentAmt,
                //                       Type = "Credit"
                //                   }).ToList();

                //var CreditSalesForRemind = (from CSD in db.CreditSalesDetails
                //                   from CS in db.CreditSales
                //                   from C in db.Customers
                //                   where (CSD.CreditSalesID == CS.CreditSalesID && C.CustomerID == CS.CustomerID && CSD.RemindDateForInstallment >= fromday && CSD.RemindDateForInstallment <= to && CSD.PaymentStatus == "Due" && CSD.RemindDateForInstallment != null)
                //                   select new CustomerWiseBenefitSummary
                //                   {
                //                       Code = C.Code,
                //                       Name = C.Name,
                //                       ContactNo = C.ContactNo,
                //                       Address = C.Address,
                //                       InstallmentAmt = (decimal)CSD.InstallmentAmt,
                //                       Type = "Credit"
                //                   }).ToList();

                //CreditSales.AddRange(CreditSalesForRemind );




                //var Sales = (from so in db.SOrders
                //             join c in db.Customers on so.CustomerID equals c.CustomerID
                //             where (c.TotalDue > 0  && so.RemindPeriod!=0 && so.Status == (int)EnumSalesType.Sales && (so.RemindDate >= fromday && so.RemindDate <= to))
                //             select new CustomerWiseBenefitSummary
                //             {
                //                 Code = c.Code,
                //                 Name = c.Name,
                //                 ContactNo = c.ContactNo,
                //                 Address = c.Address,
                //                 InstallmentAmt = c.TotalDue,
                //                 Type = "Cash"
                //             }).Distinct().ToList();

                //var SalesCashCollections = (from so in db.CashCollections
                //             join c in db.Customers on so.CustomerID equals c.CustomerID
                //             where (c.TotalDue > 0 && so.RemindPeriod != 0 && so.CompanyID== null && (so.RemindDate >= fromday && so.RemindDate <= to))
                //             select new CustomerWiseBenefitSummary
                //             {
                //                 Code = c.Code,
                //                 Name = c.Name,
                //                 ContactNo = c.ContactNo,
                //                 Address = c.Address,
                //                 InstallmentAmt = c.TotalDue,
                //                 Type = "Cash"
                //             }).Distinct().ToList();

                //Sales.AddRange(SalesCashCollections);


             //   CreditSales.AddRange(Sales);

                grdcreditSchedule.DataSource = dt;// CreditSales.OrderBy(i => i.Name).ToList();

            }
        }

        private void DailyBalanceProcess()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DateTime currentdate = DateTime.Today;

                    decimal opening = 0;
                    PrevBalance prevBalance = null;
                    string dFromDate = currentdate.Date.ToString();
                    string sToDate = currentdate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                    dFFdate = Convert.ToDateTime(dFromDate);
                    dTTdate = Convert.ToDateTime(sToDate);
                    PrevBalance oLastDayBalance = db.PrevBalances.FirstOrDefault(x => x.Date >= dFFdate && x.Date <= dTTdate);
                    // if current Date data not found do process
                    if (oLastDayBalance == null)
                    {
                        List<PrevBalance> oLastDayBalances = db.PrevBalances.ToList();
                        if (oLastDayBalances.Count > 0)
                        {
                            oLastDayBalance = oLastDayBalances.OrderByDescending(x => x.Date).First();
                            opening = oLastDayBalance.Amount + CalculatePrevBalance(db, oLastDayBalance.Date, dTTdate);
                        }
                        else
                        {
                            opening = CalculatePrevBalance(db, DateTime.MinValue, dTTdate);
                        }
                        prevBalance = new PrevBalance();
                        prevBalance.Date = DateTime.Today;
                        prevBalance.Amount = opening;
                        db.PrevBalances.Add(prevBalance);
                        db.SaveChanges();

                        // MessageBox.Show("Monthly Stock information Updated !", "Stock Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculatePrevBalance(DEWSRMEntities db, DateTime dFFdate, DateTime dTTdate)
        {


           




            decimal credit = 0;
            decimal debit = 0;
            var oCaSales = (from cs in db.SOrders
                            where (cs.InvoiceDate >= dFFdate && cs.InvoiceDate <= dTTdate && cs.Status == 1)
                            select new
                            {
                                cs.InvoiceDate,
                                cs.GrandTotal,
                                PaidAmount = cs.RecAmount - cs.BackAmount,
                                cs.TDAmount,
                                cs.TotalDue,
                            }
                           );

            var oPurchase = (from cs in db.POrders
                             where (cs.OrderDate >= dFFdate && cs.OrderDate <= dTTdate && cs.Status == 1)
                             select new
                             {
                                 cs.OrderDate,
                                 cs.GrandTotal,
                                 cs.RecAmt,
                                 cs.NetDiscount,
                                 cs.TotalDue,
                             }
                       );

            var oExpense = (from exp in db.Expenditures
                            from expi in db.ExpenseItems
                            where (expi.ExpenseItemID == exp.ExpenseItemID && exp.EntryDate >= dFFdate && exp.EntryDate <= dTTdate)
                            select new
                            {
                                exp.EntryDate,
                                expi.Description,
                                exp.Amount,
                                exp.Purpose,
                                expi.Status,
                                exp.VoucherName
                            }
                        ).ToList();

            var oExpItems = oExpense.Where(x => x.Status == (int)EnumExpenseType.Expense).ToList();
            foreach (var item in oExpItems)
            {
                debit += (decimal)item.Amount;
            }
            var oIncomeItems = oExpense.Where(x => x.Status == (int)EnumExpenseType.Income).ToList();
            foreach (var item in oIncomeItems)
            {
                credit += (decimal)item.Amount;
            }

            var oCashCollections = (from csd in db.CashCollections
                                    where (csd.EntryDate >= dFFdate && csd.EntryDate <= dTTdate && csd.TransactionType == (int)EnumTranType.FromCustomer)
                                    select new
                                    {
                                        csd.EntryDate,
                                        csd.Amount,
                                        csd.PaymentType,
                                        csd.CheckNo
                                    }
                       ).ToList();

            foreach (var item in oCashCollections)
            {
                credit += (decimal)item.Amount;
            }

            var oCashPayments = (from csd in db.CashCollections
                                 where (csd.EntryDate >= dFFdate && csd.EntryDate <= dTTdate && csd.TransactionType == (int)EnumTranType.ToCompany)
                                 select new
                                 {
                                     csd.EntryDate,
                                     csd.Amount,
                                     csd.PaymentType,
                                     csd.CheckNo,

                                 }
                      ).ToList();

            foreach (var item in oCashPayments)
            {
                debit += (decimal)item.Amount;
            }
            var oCaSs = oCaSales.ToList();

            var oCaSsSum = oCaSs.GroupBy(x => 1).Select(x => new
            {
                TCaSales = x.Sum(k => k.GrandTotal),
                TCaDis = x.Sum(k => k.TDAmount),
                TCaDue = x.Sum(k => k.TotalDue),
                TCaRec = x.Sum(k => k.PaidAmount)
            }).ToList();

            var oPurchaseSum = oPurchase.GroupBy(x => 1).Select(x => new
            {
                TCaSales = x.Sum(k => k.GrandTotal),
                TCaDis = x.Sum(k => k.NetDiscount),
                TCaDue = x.Sum(k => k.TotalDue),
                TCaRec = x.Sum(k => k.RecAmt)
            }).ToList();


            if (oCaSsSum.Count > 0)
            {
                credit += (decimal)oCaSsSum[0].TCaRec;
            }
            if (oPurchaseSum.Count > 0)
            {
                debit += (decimal)oPurchaseSum[0].TCaRec;
            }

            return (credit - debit);
        }

        private void RefreshMenu11()
        {
            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString("dd MMM yyyy HH:mm tt");
            sUser = lblUser.Text;
            User oUser = Global.CurrentUser;

            if (oUser.UserType == (int)EnumUserType.Administrator)
            {
                //userManagementToolStripMenuItem.Visible = true;

                userManagementToolStripMenuItem.Visible = true;
                basicToolStripMenuItem.Visible = true;
                toolStripMIProduct.Visible = true;
                toolStripMISysInfo.Visible = true;
                toolStripMICompany.Visible = true;
                logOutToolStripMenuItem.Visible = true;
                exitToolStripMenuItem.Visible = true;
                //toolStripMIInvestment.Visible = true;

                btnProductConfig.Visible = false;
                btnPurchaseOrder.Visible = false;
                btnSalesOrder.Visible = false;
                btnCashCollection.Visible = false;
                btnExpenditure.Visible = false;
                btnMISRpt.Visible = false;

            }
            else
            {
                //userManagementToolStripMenuItem.Visible = false;

                userManagementToolStripMenuItem.Visible = false;
                List<UserRole> oUserRoles = oUser.UserRoles.ToList();
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<MenuPermission> oMenuPermissions = db.MenuPermissions.ToList();
                    List<INVENTORY.DA.Menu> oMenus = db.Menus.ToList();
                    List<MenuPermission> oMenuPermissionTemps = null;
                    INVENTORY.DA.Menu oMenutemp = null;
                    List<ToolStripMenuItem> allMenustr = new List<ToolStripMenuItem>();

                    foreach (ToolStripMenuItem menustr in menuStrip1.Items)
                    {
                        allMenustr.Add(menustr);
                        if (menustr.DropDownItems.Count > 0)
                        {
                            allMenustr.AddRange(ChildNodes(menustr.DropDownItems));
                        }
                    }

                    if (oUserRoles.Count == 0)
                    {
                        toolStripMISysInfo.Visible = false;
                        toolStripMICompany.Visible = false;
                        toolStripMIColor.Visible = false;
                        toolStripMICategory.Visible = false;
                        toolStripMIProduct.Visible = false;
                        //toolStripMIInvestment.Visible = false;
                    }

                    foreach (UserRole item in oUserRoles)
                    {
                        oMenuPermissionTemps = oMenuPermissions.Where(x => x.RoleID == item.RoleID).ToList();

                        if (oMenuPermissionTemps.Count == 0)
                        {
                            btnProductConfig.Visible = false;
                            btnPurchaseOrder.Visible = false;
                            btnSalesOrder.Visible = false;
                            btnCashCollection.Visible = false;
                            btnExpenditure.Visible = false;
                            btnMISRpt.Visible = false;

                            toolStripMISysInfo.Visible = false;
                            toolStripMICompany.Visible = false;
                            toolStripMIColor.Visible = false;
                            toolStripMICategory.Visible = false;
                            toolStripMIProduct.Visible = false;
                            //toolStripMIInvestment.Visible = false;

                        }
                        else
                        {
                            foreach (MenuPermission menuper in oMenuPermissionTemps)
                            {
                                oMenutemp = oMenus.FirstOrDefault(x => x.MenuID == menuper.MenuID);
                                foreach (ToolStripMenuItem menustr in allMenustr)
                                {
                                    if (menustr.Tag != null && menustr.Tag.ToString() == oMenutemp.MenuKey)
                                    {
                                        menustr.Visible = true;
                                    }

                                }
                                switch (oMenutemp.MenuKey)
                                {
                                    case "A":
                                        btnProductConfig.Enabled = true;
                                        break;
                                    case "B":
                                        btnPurchaseOrder.Enabled = true;
                                        break;
                                    case "C":
                                        btnSalesOrder.Enabled = true;
                                        break;
                                    case "D":
                                        btnCashCollection.Enabled = true;
                                        break;
                                    case "E":
                                        btnExpenditure.Enabled = true;
                                        break;
                                    case "F":
                                        btnMISRpt.Enabled = true;
                                        break;
                                    //case "G":
                                    //    btnCS .Enabled = true;
                                    //    break;

                                    default:
                                        break;
                                }
                            }
                        }

                    }
                }
            }

        }


        private void RefreshMenu()
        {
            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString("dd MMM yyyy HH:mm tt");
            sUser = lblUser.Text;
            User oUser = Global.CurrentUser;

            if (oUser.UserType == (int)EnumUserType.Administrator)
            {
                userManagementToolStripMenuItem.Visible = true;
                basicToolStripMenuItem.Visible = true;
                employeeToolStripMenuItem.Visible = true;
                customerExpenseToolStripMenuItem.Visible = true;
                salesAndInvenToolStripMenuItem.Visible = true;
                accountManagementToolStripMenuItem.Visible = true;
                mISReportToolStripMenuItem.Visible = true;

                toolStripMIProduct.Visible = true;
                toolStripMISysInfo.Visible = true;
                toolStripMICompany.Visible = true;
                logOutToolStripMenuItem.Visible = true;
                exitToolStripMenuItem.Visible = true;


                btnProductConfig.Enabled = true;
                btnPurchaseOrder.Enabled = true;
                btnSalesOrder.Enabled = true;
                btnCSales.Enabled = true;
                btnCashCollection.Enabled = true;
                btnCashDeliver.Enabled = true;
                btnIncome.Enabled = true;
                btnExpense.Enabled = true;
                btnMISRpt.Enabled = true;
                btnExit.Enabled = true;
                btnBackup.Enabled = true;
                btnStock.Enabled =true;
                btnCategory.Enabled = true;
                

                DEWSRMEntities db = new DEWSRMEntities();
               // btnProductsNumber.Text = "Tota Products  " + db.Products.Count().ToString();
               // btnSalesNumber.Text = "Tota Sales  " + db.SOrders.Count().ToString();
                btnPurchaseNumber.Text = "Tota Purchases  " + db.POrders.Count().ToString();
               // btnCreditSalesNumber.Text = "Tota Credit Sales  " + db.POrders.Count().ToString();
                btnCustomersNumber.Text = "Tota Customer  " + db.Customers.Count().ToString();
                btnSuppliersNumber.Text = "Tota Suppliers  " + db.Suppliers.Count().ToString();
                btnCashCollection.Text = "Tota Cash Collections  " + db.CashCollections.Where(o => o.TransactionType == 1).Count().ToString();
              //  btnCashDeliverysNumber.Text = "Tota Cash Delivery  " + db.CashCollections.Where(o => o.TransactionType == 2).Count().ToString();

           //     btnProductsNumber.Enabled = true;
                btnSalesNumber.Enabled = true;
                btnPurchaseNumber.Enabled = true;
             // btnCreditSalesNumber.Enabled = true;
              //  btnCreditSalesNumber.Enabled = true;
                btnCashCollection.Enabled = true;
             //   btnCashCollectionsNumber.Enabled = true;
             //   btnCashDeliverysNumber.Enabled = true;
                btnCustomersNumber.Enabled = true;
                btnSuppliersNumber.Enabled = true;
                btnCustomersNumber1.Enabled = true;

                btnSMS.Enabled = true;
                btnCashStatement.Enabled = true;
                btnBalanceSheet.Enabled = true;
                btnPartialReturn.Enabled = true;
                btnWareHouse.Enabled = true;


               // btnCreatePurchase.Enabled = true;
             //   btnCreateCashCollection.Enabled = true; ;
              //  btnCreateCashDelivery.Enabled = true; ;
             //   btnCreateCrediSale.Enabled = true; ;
                //  btnCreateCustomer.Enabled = true; 
                  btnCreateProduct.Enabled = true; ;
                  btnCreateSale.Enabled = true; ;
             //   btnCreateSupplier.Enabled = true; ;


              

            }
            else
            {
                //userManagementToolStripMenuItem.Visible = false;

                userManagementToolStripMenuItem.Visible = false;
                List<UserRole> oUserRoles = oUser.UserRoles.ToList();

                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<MenuPermission> oMenuPermissions = db.MenuPermissions.ToList();
                    List<INVENTORY.DA.Menu> oMenus = db.Menus.ToList();
                    List<MenuPermission> oMenuPermissionTemps = null;
                    INVENTORY.DA.Menu oMenutemp = null;
                    List<ToolStripMenuItem> allMenustr = new List<ToolStripMenuItem>();

                    foreach (ToolStripMenuItem menustr in menuStrip1.Items)
                    {
                        allMenustr.Add(menustr);
                        if (menustr.DropDownItems.Count > 0)
                        {
                            allMenustr.AddRange(ChildNodes(menustr.DropDownItems));
                        }
                    }

                    if (oUserRoles.Count == 0)
                    {
                        toolStripMISysInfo.Visible = false;
                        toolStripMICompany.Visible = false;
                        toolStripMIColor.Visible = false;
                        toolStripMICategory.Visible = false;
                        toolStripMIProduct.Visible = false;
                        //toolStripMIInvestment.Visible = false;
                    }

                    foreach (UserRole item in oUserRoles)
                    {
                        oMenuPermissionTemps = oMenuPermissions.Where(x => x.RoleID == item.RoleID).ToList();

                        if (oMenuPermissionTemps.Count == 0)
                        {
                            btnProductConfig.Visible = false;
                            btnPurchaseOrder.Visible = false;
                            btnSalesOrder.Visible = false;
                            btnCashCollection.Visible = false;
                            btnExpenditure.Visible = false;
                            btnMISRpt.Visible = false;

                            toolStripMISysInfo.Visible = false;
                            toolStripMICompany.Visible = false;
                            toolStripMIColor.Visible = false;
                            toolStripMICategory.Visible = false;
                            toolStripMIProduct.Visible = false;
                            //toolStripMIInvestment.Visible = false;

                        }
                        else
                        {
                            foreach (MenuPermission menuper in oMenuPermissionTemps)
                            {
                                oMenutemp = oMenus.FirstOrDefault(x => x.MenuID == menuper.MenuID);
                                foreach (ToolStripMenuItem menustr in allMenustr)
                                {
                                    if (menustr.Tag != null && menustr.Tag.ToString() == oMenutemp.MenuKey)
                                    {
                                        menustr.Visible = true;
                                    }

                                }
                                switch (oMenutemp.MenuKey)
                                {
                                    case "A":
                                        btnProductConfig.Enabled = true;
                                        break;
                                    case "B":
                                        btnPurchaseOrder.Enabled = true;
                                        break;
                                    case "C":
                                        btnSalesOrder.Enabled = true;
                                        break;
                                    case "D":
                                        btnCashCollection.Enabled = true;
                                        break;
                                    case "E":
                                        btnExpenditure.Enabled = true;
                                        break;
                                    case "F":
                                        btnMISRpt.Enabled = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                    }
                }
            }

        }
        List<ToolStripMenuItem> ChildNodes(ToolStripItemCollection theNodes)
        {
            List<ToolStripMenuItem> aResult = new List<ToolStripMenuItem>();

            if (theNodes != null)
            {
                foreach (ToolStripMenuItem aNode in theNodes)
                {

                    aResult.Add(aNode);
                    if (aNode.DropDownItems.Count > 0)
                    {
                        ChildNodes(aNode.DropDownItems);
                    }

                }
            }

            return aResult;
        }

        private void damageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDamageProducts oDProducts = new fDamageProducts();
            oDProducts.ShowDialog();
        }

        #region For Database Backup
        private void DataBaseBackup()
        {
            try
            {
                DataBase = ConfigurationManager.AppSettings["DB"];
                sFilePath = ConfigurationManager.AppSettings["FP"];

                sFileName = sFilePath + @"\" + DataBase + "-" + Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy") + ".Bak";
                sCommand = @"backup database " + DataBase + " to disk ='" + sFileName + "' with init,stats=10";

                #region DB Back Up
                ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["backupDB"].ConnectionString;
                SqlConnection ob = new SqlConnection(ConnString);
                ob.Open();
                SqlCommand cmd = new SqlCommand(sCommand, ob);
                cmd.ExecuteNonQuery();
                ob.Close();

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseBackup();
            this.Hide();
            fLogIn frm = new fLogIn();
            frm.ShowDialog();
            frm.txtLoginID.Focus();

        }

        private void cashCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCashCollections oFCashColls = new fCashCollections();
            oFCashColls.ShowDialog();
        }


        private void newUserRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUsers oFUsers = new fUsers();
            oFUsers.ShowDialog();
        }

        private void expenditureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fExpenditures ofExpenditures = new fExpenditures();
            ofExpenditures.ShowDialog();
        }

        private void toDoListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void cashCollectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fCashCollections oFCashColls = new fCashCollections();
            oFCashColls.ShowDialog();
        }

        private void expenditureToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fExpenseItems oFExpenseItems = new fExpenseItems();
            oFExpenseItems.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void stockInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStockRpt oFSRpt = new fStockRpt();
            oFSRpt.ShowDialog();
        }

        private void btnProductConfig_Click(object sender, EventArgs e)
        {
            fProducts oFPro = new fProducts();
            oFPro.ShowDialog();
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            fPurchaseOrders oFPOrders = new fPurchaseOrders();
            oFPOrders.ShowDialog();
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            fSOrders ofOrder = new fSOrders();
            ofOrder.ShowDialog();
        }

        private void btnCUstomet_Click(object sender, EventArgs e)
        {
            fCustomers ofCus = new fCustomers();
            ofCus.ShowDialog();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            fSuppliers oFSupp = new fSuppliers();
            oFSupp.ShowDialog();
        }

        private void btnCashCollection_Click(object sender, EventArgs e)
        {
            fCashCollections oFCashColls = new fCashCollections();
            oFCashColls.ShowDialog();
        }

        private void btnExpenditure_Click(object sender, EventArgs e)
        {
            fExpenditures oFExpenditures = new fExpenditures();
            oFExpenditures.ShowDialog();

        }

        private void btnMISRpt_Click(object sender, EventArgs e)
        {
            fMISRpt oFMISRpt = new fMISRpt();
            oFMISRpt.ShowDialog();
        }



        private void upcomingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUpComingSchedule oFUpComingSchedule = new fUpComingSchedule();
            oFUpComingSchedule.ShowDialog();
        }

        private void dailyCashCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDailyCollection oFDCC = new fDailyCollection();
            oFDCC.ShowDialog();
        }

        private void expenditureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fExpenditures oFExpenditures = new fExpenditures();
            oFExpenditures.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseBackup();
            Application.Exit();
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fEmployeeSalaries oFEmpSalaries = new fEmployeeSalaries();
            oFEmpSalaries.ShowDialog();
        }

        private void customerWiseSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCustomerWiseSales oFCustomerWiseSales = new fCustomerWiseSales();
            oFCustomerWiseSales.ShowDialog();

        }

        private void supplierWisePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSupplierWisePurchase oFSuppPurchase = new fSupplierWisePurchase();
            oFSuppPurchase.ShowDialog();
        }

        private void summaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSummaryReport ofSummaryReport = new fSummaryReport();
            ofSummaryReport.ShowDialog();

        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBackUpDB oFBDB = new fBackUpDB();
            oFBDB.Show();
        }

        private void dataUploaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  fDataUpload frm = new fDataUpload();
           // frm.ShowDialog();
        }

        private void encryptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fEncryptor frm = new fEncryptor();
            frm.ShowDialog();
        }

        private void productModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fModels frm = new fModels();
            //frm.ShowDialog();

        }

        private void FNewMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DataBaseBackup();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Close");
            }

        }

        private void toolStripMISysInfo_Click(object sender, EventArgs e)
        {
            fSystemInformation oFSInfo = new fSystemInformation();
            oFSInfo.ShowDialog();
        }

        private void toolStripMICompany_Click(object sender, EventArgs e)
        {
            fCompanies oFComp = new fCompanies();
            oFComp.ShowDialog();
        }

        private void toolStripMIColor_Click(object sender, EventArgs e)
        {
            fColorInfos oFColors = new fColorInfos();
            oFColors.ShowDialog();
            //fModels frm = new fModels();
            //frm.ShowDialog();
        }

        private void toolStripMICategory_Click(object sender, EventArgs e)
        {
            fCategorys oFCategories = new fCategorys();
            oFCategories.ShowDialog();
        }

        private void toolStripMIProduct_Click(object sender, EventArgs e)
        {
            fProducts oFProducts = new fProducts();
            oFProducts.ShowDialog();
        }

        private void roletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            fRoles oFRoles = new fRoles();
            oFRoles.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Check whether the GridControl can be previewed.
                if (!grdProducts.IsPrintingAvailable)
                {
                    MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                    return;
                }

                // Open the Preview window.
                grdProducts.ShowPrintPreview();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void RefreshChart()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {

                //var sp = db.sp_ChartData();
                using (var connection = db.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "EXEC sp_ChartData";

                    using (var reader = command.ExecuteReader())
                    {
                        var shortProduct =
                            ((IObjectContextAdapter)db)
                                .ObjectContext
                                .Translate<INVENTORY.DA.Global.ShortProduct>(reader)
                                .ToList();

                       

                        reader.NextResult();


                        var companyWiseSales =
                            ((IObjectContextAdapter)db)
                                .ObjectContext
                                .Translate<INVENTORY.DA.Global.CompanyWiseSales>(reader)
                                .ToList();

                        reader.NextResult();

                        var topProducts =
                            ((IObjectContextAdapter)db)
                                .ObjectContext
                                .Translate<INVENTORY.DA.Global.TopProsuct>(reader)
                                .ToList();
                        reader.NextResult();

                        var dayWiseSalesAmount =
                            ((IObjectContextAdapter)db)
                                .ObjectContext
                                .Translate<INVENTORY.DA.Global.DayWiseSales>(reader)
                                .ToList();
                        reader.NextResult();

                        var dayWiseNoofSales =
                            ((IObjectContextAdapter)db)
                                .ObjectContext
                                .Translate<INVENTORY.DA.Global.DayWiseNoofSales>(reader)
                                .ToList();
                        reader.NextResult();

                        //var shortProduct =
                        //    ((IObjectContextAdapter)db)
                        //        .ObjectContext
                        //        .Translate<INVENTORY.DA.Global.ShortProduct>(reader)
                        //        .ToList();
                        crtCompanyPercent.DataSource = companyWiseSales;
                        crtTopProduct.DataSource = topProducts;
                        crtDayWiseSales.Series[0].DataSource = dayWiseSalesAmount;
                        crtDayWiseSales.Series[1].DataSource = dayWiseNoofSales;
                        grdProducts.DataSource = shortProduct;







                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check whether the GridControl can be previewed.
            if (!grdcreditSchedule.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grdcreditSchedule.ShowPrintPreview();
        }

        private void btnCSales_Click(object sender, EventArgs e)
        {
            FCreditSales oFCSales = new FCreditSales();
            oFCSales.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check whether the GridControl can be previewed.
            if (!grdProducts.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grdProducts.ShowPrintPreview();
        }

        private void btnCashCollection_Click_1(object sender, EventArgs e)
        {
            fCashCollections oFCashColls = new fCashCollections();
            oFCashColls.ShowDialog();
        }

        private void btnCashDeliver_Click(object sender, EventArgs e)
        {
            fCashDeliverys oFCashColls = new fCashDeliverys();
            oFCashColls.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fExpenditureAndIncomes oFExpenditures = new fExpenditureAndIncomes();
            oFExpenditures.ShowDialog();
            //oFExpenditures.Show();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            fExpenditures oFExpenditures = new fExpenditures();
            oFExpenditures.ShowDialog();
        }

        private void productReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPReturns oFPReturns = new fPReturns();
            oFPReturns.ShowDialog();
        }

        private void toolStripMIInvestment_Click(object sender, EventArgs e)
        {
            fInvestments oFInvestments = new fInvestments();
            oFInvestments.ShowDialog();
        }

        private void bankTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBankTransactions oFBTrans = new fBankTransactions();
            oFBTrans.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fBanks oFBanks = new fBanks();
            oFBanks.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fBranches oFBranchs = new fBranches();
            oFBranchs.ShowDialog();
        }

        private void investmentHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fInvestmentHeads oFInvestHeads = new fInvestmentHeads();
            oFInvestHeads.ShowDialog();
        }

        private void assetAndLiabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fInvestments oFInvest = new fInvestments();
            oFInvest.ShowDialog();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            LoadCreditScedule();
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReturns frm = new fReturns();
            frm.ShowDialog();

        }

        private void toolStripCardTypeSetup_Click(object sender, EventArgs e)
        {
            fCardTpyeSetups oFCTS = new fCardTpyeSetups();
            oFCTS.ShowDialog();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            fExpenditureAndIncomes oFExpenditures = new fExpenditureAndIncomes();
            oFExpenditures.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DataBaseBackup();
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            fPurchaseOrders oFPOrders = new fPurchaseOrders();
            oFPOrders.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fSOrders ofOrder = new fSOrders();
            ofOrder.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fCashCollections oFCashColls = new fCashCollections();
            oFCashColls.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fCashDeliverys oFCashColls = new fCashDeliverys();
            oFCashColls.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fDailyPurchaseRpt oFDPurchaseRpt = new fDailyPurchaseRpt();
            oFDPurchaseRpt.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fDailySaleReport oFDSales = new fDailySaleReport();
            oFDSales.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fSupplierLedger oFPLedger = new fSupplierLedger();
            oFPLedger.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            fPartyLedger oFPLedger = new fPartyLedger();
            oFPLedger.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fStockRpt oFSRpt = new fStockRpt();
            oFSRpt.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                


                fCustomerDueRpt oFCDRpt = new fCustomerDueRpt();
                oFCDRpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            fDailyLedger frm = new fDailyLedger();
            frm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            fProfitAndLoss frm = new fProfitAndLoss();
            frm.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            fExpenditureReport oFPOrders = new fExpenditureReport();
            oFPOrders.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            fCollectionRpt oFCollRpt = new fCollectionRpt();
            oFCollRpt.ShowDialog();
        }

        private void dashboard2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNewMainForm2 frm = new FNewMainForm2();
            frm.ShowDialog();
        }

        private void dashBoard3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNewMainForm3 frm = new FNewMainForm3();
            frm.ShowDialog();
        }

        private void dashBoard1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNewMainForm frm = new FNewMainForm();
            frm.ShowDialog();
        }

        private void btnCustomersNumber_Click(object sender, EventArgs e)
        {
            fCustomers ofCustomers = new fCustomers();
            ofCustomers.ShowDialog();
        }

        private void btnSuppliersNumber_Click(object sender, EventArgs e)
        {
            fSuppliers ofSuppliers = new fSuppliers();
            ofSuppliers.ShowDialog();
        }

        private void allSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSuppliers ofSuppliers = new fSuppliers();
            ofSuppliers.ShowDialog();
        }

        private void createSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSupplier frm = new fSupplier();
           // frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Supplier(), true);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DataBaseBackup();
        }

        private void dashBoard1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNewMainForm frm = new FNewMainForm();

            frm.lblUser.Text = Global.CurrentUser.UserName.ToString();
            frm.tsplbranch.Text = this.tsplbranch.Text;

            frm.ShowDialog();
        }

        private void dashboard2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNewMainForm2 frm = new FNewMainForm2();
            frm.lblUser.Text = Global.CurrentUser.UserName.ToString();
            frm.ToolStripStatusLabel3.Text = this.tsplbranch.Text;
            frm.ShowDialog();
        }

        private void dashBorad3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNewMainForm3 frm = new FNewMainForm3();
            frm.lblUser.Text = Global.CurrentUser.UserName.ToString();
            frm.ToolStripStatusLabel3.Text = this.tsplbranch.Text;
            frm.ShowDialog();
        }

        private void btnCreateSale_Click(object sender, EventArgs e)
        {
            fSOrder oFPOrder = new fSOrder();
           // oFPOrder.ItemChanged = RefreshList;
            oFPOrder.ShowDlg(new SOrder());
        }

        private void btnSalesNumber_Click(object sender, EventArgs e)
        {
            fSOrders ofOrder = new fSOrders();
            ofOrder.ShowDialog();
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            fProduct frm = new fProduct();
          //  frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Product(), true);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            fStocks oFSRpt = new fStocks();
            oFSRpt.ShowDialog();
        }

        private void btnPurchaseNumber_Click(object sender, EventArgs e)
        {
            fPurchaseOrders oFPOrders = new fPurchaseOrders();
            oFPOrders.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {

            fCategorys oFCategories = new fCategorys();
            oFCategories.ShowDialog();
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSendSMS frm = new fSendSMS();
            frm.ShowDialog();
        }

        private void sMSFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSMSFormate frm = new fSMSFormate();
          //  frm.ItemChanged = RefreshList;
            frm.ShowDlg(new SMSFormate(), true);
        }

        private void sendSMSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fSendSMS frm = new fSendSMS();
            frm.ShowDialog();
        }

        private void allSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSMSStatus frm = new fSMSStatus();
            frm.ShowDialog();
        }

        private void aLLSMSFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSMSFormates frm = new fSMSFormates();
            frm.ShowDialog();
        }

        private void btnPartialReturn_Click(object sender, EventArgs e)
        {
            fReturns frm = new fReturns();
            frm.ShowDialog();
        }

        private void btnCashStatement_Click(object sender, EventArgs e)
        {
            fProfitAndLoss frm = new fProfitAndLoss();
            frm.ShowDialog();
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            fDailySummary frm = new fDailySummary();
            frm.ShowDialog();
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {

            fSMSStatus frm = new fSMSStatus();
            frm.ShowDialog();
        }

        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            fGodowns frm = new fGodowns();
            frm.ShowDialog();
        }

        private void branchMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchMaster frmbranchbaster = new frmBranchMaster();       

            frmbranchbaster.ShowDialog();
        }

        private void labelPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlabelprint frmlabelprnt = new frmlabelprint();
            frmlabelprnt.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmlast7dayssale frmlast7daysale = new frmlast7dayssale();
            frmlast7daysale.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmhourlysale frmhourlsale = new frmhourlysale();
            frmhourlsale.ShowDialog();
        }

        void SevendaysSale()
        {
            DataSet ds = new DataSet();
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRMTEST;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("select sum(grandtotal+ VATAmount) as total, datename(WEEKDAY, ( dateadd(DAY,0, datediff(day,0, CreateDate)))) as created from [dbo].[SOrders] where CreateDate BETWEEN GETDATE()-7 AND GETDATE() group by dateadd(DAY,0, datediff(day,0, CreateDate))", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(ds);


            //lblday1.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            //txtday1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //lblday2.Text = ds.Tables[0].Rows[1].ItemArray[1].ToString();
            //txtday2.Text = ds.Tables[0].Rows[1].ItemArray[0].ToString();
            //lblday3.Text = ds.Tables[0].Rows[2].ItemArray[1].ToString();
            //txtday3.Text = ds.Tables[0].Rows[2].ItemArray[0].ToString();
            //lblday4.Text = ds.Tables[0].Rows[3].ItemArray[1].ToString();
            //txtday4.Text = ds.Tables[0].Rows[3].ItemArray[0].ToString();
            //lblday5.Text = ds.Tables[0].Rows[4].ItemArray[1].ToString();
            //txtday5.Text = ds.Tables[0].Rows[4].ItemArray[0].ToString();
            //lblday6.Text = ds.Tables[0].Rows[5].ItemArray[1].ToString();
            //txtday6.Text = ds.Tables[0].Rows[5].ItemArray[0].ToString();
            //lblday7.Text = ds.Tables[0].Rows[6].ItemArray[1].ToString();
            //txtday7.Text = ds.Tables[0].Rows[6].ItemArray[0].ToString();

        }


    }
}