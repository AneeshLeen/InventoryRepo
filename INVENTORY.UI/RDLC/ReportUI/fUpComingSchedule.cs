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
    public partial class fUpComingSchedule : Form
    {
        DateTime dFFdate = DateTime.Now;
        DateTime dTTdate = DateTime.Now;

        public fUpComingSchedule()
        {
            InitializeComponent();
        }

        private void fUpComingSchedule_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //#region Summary
            //if (chkSummary.Checked)
            //{
            //    try
            //    {
            //        using (DEWSRMEntities db = new DEWSRMEntities())
            //        {

            //            fReportViewer fRptViewer = new fReportViewer();
            //            CreditSale oCreditSales = new CreditSale();

            //            //DateTime fromDate = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, 1);
            //            //DateTime toDate = fromDate.AddMonths(1);
            //            //toDate = toDate.AddDays(-1);

            //            DateTime fromDate = dtpFromDate.Value;
            //            DateTime toDate = dtpToDate.Value;

            //            string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
            //            string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
            //            dFFdate = Convert.ToDateTime(sFFdate);
            //            dTTdate = Convert.ToDateTime(sTTdate);

            //            var oCSalesDetails = (
            //                           from cs in db.CreditSales
            //                           join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
            //                           join cus in db.Customers on cs.CustomerID equals cus.CustomerID
            //                           //join pro in db.Products on cs.ProductID equals pro.ProductID
            //                           where (csd.PaymentDate >= dFFdate && csd.PaymentDate <= dTTdate)
            //                           select new
            //                           {


            //                               cs.InvoiceNo,
            //                               cs.CreditSalesID,
            //                               cus.Name,
            //                               cus.RefName,
            //                               cus.ContactNo,
            //                               // pro.ProductName,
            //                               cs.SalesDate,
            //                               csd.PaymentDate,
            //                               cs.TSalesAmt,
            //                               cs.NetAmount,
            //                               cs.FixedAmt,
            //                               cs.NoOfInstallment,
            //                               Remaining = cs.TSalesAmt - cs.DownPayment,

            //                               csd.InstallmentAmt,
            //                               csd.Remarks,
            //                               cs.DownPayment,
            //                               InsRec = cs.TSalesAmt - cs.DownPayment - cs.Remaining,
            //                               TotalRec = cs.TSalesAmt - cs.Remaining,
            //                               closing = cs.Remaining
            //                           }
            //                          );

            //            var oCSalesDetailsPaid = (
            //                           from cs in db.CreditSales
            //                           join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
            //                           join cus in db.Customers on cs.CustomerID equals cus.CustomerID
            //                           //join pro in db.Products on cs.ProductID equals pro.ProductID
            //                           where (csd.PaymentDate >= dFFdate && csd.PaymentDate <= dTTdate) && csd.PaymentStatus == "Paid"
            //                           select new
            //                           {
            //                               cs.InvoiceNo,
            //                               cs.CreditSalesID,
            //                               cus.Name,
            //                               cus.ContactNo,
            //                               // pro.ProductName,
            //                               cs.SalesDate,
            //                               csd.PaymentDate,
            //                               cs.TSalesAmt,
            //                               cs.NetAmount,
            //                               cs.FixedAmt,
            //                               cs.NoOfInstallment,
            //                               Remaining = cs.TSalesAmt - cs.DownPayment,

            //                               csd.InstallmentAmt,
            //                               csd.Remarks,
            //                               cs.DownPayment,
            //                               InsRec = cs.TSalesAmt - cs.DownPayment - cs.Remaining,
            //                               TotalRec = cs.TSalesAmt - cs.Remaining,
            //                               closing = cs.Remaining
            //                           }
            //                          );

            //            var oCSalesDetailsDue = (
            //                           from cs in db.CreditSales
            //                           join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
            //                           join cus in db.Customers on cs.CustomerID equals cus.CustomerID
            //                           //join pro in db.Products on cs.ProductID equals pro.ProductID
            //                           where (csd.PaymentDate >= dFFdate && csd.PaymentDate <= dTTdate) && csd.PaymentStatus == "Due"
            //                           select new
            //                           {
            //                               cs.InvoiceNo,
            //                               cs.CreditSalesID,
            //                               cus.Name,
            //                               cus.ContactNo,
            //                               // pro.ProductName,
            //                               cs.SalesDate,
            //                               csd.PaymentDate,
            //                               cs.TSalesAmt,
            //                               cs.NetAmount,
            //                               cs.FixedAmt,
            //                               cs.NoOfInstallment,
            //                               Remaining = cs.TSalesAmt - cs.DownPayment,
            //                               csd.InstallmentAmt,
            //                               csd.Remarks,
            //                               cs.DownPayment,

            //                               InsRec = cs.TSalesAmt - cs.DownPayment - cs.Remaining,
            //                               TotalRec = cs.TSalesAmt - cs.Remaining,
            //                               closing = cs.Remaining
            //                           }
            //                          );
            //            var oCSDs = oCSalesDetails.ToList();
            //            var oCSDsPaid = oCSalesDetailsPaid.ToList();
            //            var oCSDsDue = oCSalesDetailsDue.ToList();

            //            double TotalInstallment = 0;
            //            double PaidInstallment = 0;
            //            double UnPaidInstallment = 0;

            //            foreach (var oCSDItem in oCSDs)
            //            {

            //                TotalInstallment = TotalInstallment + (double)oCSDItem.InstallmentAmt;
            //                //dt.Rows.Add(oCSDItem.InvoiceNo, oCSDItem.Name, oCSDItem.ContactNo, joinedString, oCSDItem.SalesDate, oCSDItem.PaymentDate, oCSDItem.TSalesAmt, oCSDItem.NetAmount, oCSDItem.FixedAmt, oCSDItem.NoOfInstallment, oCSDItem.Remaining, oCSDItem.InstallmentAmt, oCSDItem.Remarks, oCSDItem.DownPayment, oCSDItem.InsRec, oCSDItem.TotalRec, oCSDItem.closing);
            //            }

            //            foreach (var oCSDItem in oCSDsPaid)
            //            {

            //                PaidInstallment = PaidInstallment + (double)oCSDItem.InstallmentAmt;


            //                //dt.Rows.Add(oCSDItem.InvoiceNo, oCSDItem.Name, oCSDItem.ContactNo, joinedString, oCSDItem.SalesDate, oCSDItem.PaymentDate, oCSDItem.TSalesAmt, oCSDItem.NetAmount, oCSDItem.FixedAmt, oCSDItem.NoOfInstallment, oCSDItem.Remaining, oCSDItem.InstallmentAmt, oCSDItem.Remarks, oCSDItem.DownPayment, oCSDItem.InsRec, oCSDItem.TotalRec, oCSDItem.closing);
            //            }

            //            foreach (var oCSDItem in oCSDsDue)
            //            {

            //                UnPaidInstallment = UnPaidInstallment + (double)oCSDItem.InstallmentAmt;


            //                //dt.Rows.Add(oCSDItem.InvoiceNo, oCSDItem.Name, oCSDItem.ContactNo, joinedString, oCSDItem.SalesDate, oCSDItem.PaymentDate, oCSDItem.TSalesAmt, oCSDItem.NetAmount, oCSDItem.FixedAmt, oCSDItem.NoOfInstallment, oCSDItem.Remaining, oCSDItem.InstallmentAmt, oCSDItem.Remarks, oCSDItem.DownPayment, oCSDItem.InsRec, oCSDItem.TotalRec, oCSDItem.closing);
            //            }
            //            rptDataSet.dtScheduleDataTable dt = new rptDataSet.dtScheduleDataTable();
            //            DataSet ds = new DataSet();
            //            dt.Rows.Add(toDate, TotalInstallment, PaidInstallment, UnPaidInstallment, 0);

            //            dt.TableName = "rptDataSet_dtSchedule";
            //            ds.Tables.Add(dt);
            //            string embededResource = "ESRP.UI.RDLC.Schedule.rdlc";

            //            ReportParameter rParam = new ReportParameter();
            //            List<ReportParameter> parameters = new List<ReportParameter>();

            //            rParam = new ReportParameter("PaymentDate", dFFdate.ToString("dd MMM yyyy"));
            //            parameters.Add(rParam);



            //            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
            //            parameters.Add(rParam);

            //            fReportViewer frm = new fReportViewer();

            //            if (dt.Rows.Count > 0)
            //            {
            //                frm.CommonReportViewer(embededResource, ds, parameters, true);
            //            }
            //            else
            //            {
            //                MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }


            //}
            //#endregion

            #region Details
            //else
            //{
                try
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        fReportViewer fRptViewer = new fReportViewer();
                        CreditSale oCreditSales = new CreditSale();
                        //DateTime fromDate = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, 1);
                        //DateTime toDate = fromDate.AddMonths(1);
                        //toDate = toDate.AddDays(-1);

                        //DateTime fromDate = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, 1);
                        //DateTime toDate = fromDate.AddMonths(1);
                        //toDate = toDate.AddDays(-1);

                        DateTime fromDate = dtpFromDate.Value;
                        DateTime toDate = dtpToDate.Value;

                        string sFFdate = fromDate.ToString("dd MMM yyyy") + " 12:00:00 AM";
                        string sTTdate = toDate.ToString("dd MMM yyyy") + " 11:59:59 PM";
                        dFFdate = Convert.ToDateTime(sFFdate);
                        dTTdate = Convert.ToDateTime(sTTdate);

                    

                        #region Credit Sales

                        var oCSalesDetails = (
                                       from cs in db.CreditSales
                                       join csd in db.CreditSalesDetails on cs.CreditSalesID equals csd.CreditSalesID
                                       join cus in db.Customers on cs.CustomerID equals cus.CustomerID                                     
                                       where (csd.PaymentDate <= dTTdate && csd.PaymentStatus == "Due" && csd.RemindDateForInstallment==null)
                                       select new
                                       {
                                           EmployeeID = 1,
                                           Name=cus.Code+","+cus.Name+","+cus.Address+","+cus.ContactNo,
                                           cs.InvoiceNo,
                                           cs.CreditSalesID,
                                           cus.Code,
                                           cus.CustomerID,
                                           EMPName = "",
                                           RefName = cus.RefName + "," + cus.RefContact,
                                           cus.ContactNo,
                                           cus.Address,
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
                                      where (csd.RemindDateForInstallment <= dTTdate && csd.PaymentStatus == "Due" && csd.RemindDateForInstallment != null)
                                      select new
                                      {
                                          EmployeeID = 1,
                                          Name = cus.Code + "," + cus.Name + "," + cus.Address + "," + cus.ContactNo,
                                          cs.InvoiceNo,
                                          cs.CreditSalesID,
                                          cus.Code,
                                          cus.CustomerID,
                                          EMPName = "",
                                          cus.RefName,
                                          cus.ContactNo,
                                          cus.Address,
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
                                                       csd.TotalRec,



                                                   } into g
                                                   select new
                                                   {
                                                       g.Key.EMPName,
                                                       g.Key.EmployeeID,
                                                       g.Key.Code,
                                                       g.Key.Name,
                                                       g.Key.CustomerID,
                                                       g.Key.DownPayment,
                                                       g.Key.InvoiceNo,
                                                       g.Key.RefName,
                                                       g.Key.ContactNo,
                                                       g.Key.Address,
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
                                                    
                                                       PaymentDate = g.Select(o => o.PaymentDate).FirstOrDefault()
                                                      
                                                   }
                                                  );


                        var oCSDs = oCSalesDetailsGroup.ToList();
                        rptDataSet.dtUpcomingScheduleDataTable dt = new rptDataSet.dtUpcomingScheduleDataTable();
                        DataSet ds = new DataSet();

                       

                        if(ctlEmployee.SelectedID!=0)
                            oCSDs = oCSDs.Where(o => o.EmployeeID == ctlEmployee.SelectedID).ToList();

                            foreach (var oCSDItem in oCSDs)
                            {

                                decimal defaultInstallment = 0m;
                                

                                var deafult = oCSalesDetails.Where(o => o.PaymentDate < dFFdate && o.RemindDateForInstallment == null && o.CustomerID == oCSDItem.CustomerID);

                                if (deafult.ToList().Count!= 0)
                                    defaultInstallment =deafult.Sum(o => o.InstallmentAmt);

                                var deafultForRemind = oCSalesDetails.Where(o => o.RemindDateForInstallment < dFFdate && o.RemindDateForInstallment != null && o.CustomerID == oCSDItem.CustomerID);
                                if (deafultForRemind.ToList().Count !=0)
                                    defaultInstallment = defaultInstallment+deafultForRemind.Sum(o => o.InstallmentAmt);
                               
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
                                     Math.Round((decimal)defaultInstallment, 0)
                                     );
                              
                             }
                        #endregion

                        #region Get Sales By Remind Date. Date: 11-12-18

                            var tempCashCollection = (from so in db.CashCollections                                                                     
                                             join c in db.Customers on so.CustomerID equals c.CustomerID
                                             where (c.TotalDue > 0 && so.CompanyID ==null && (so.RemindDate >= dFFdate && so.RemindDate <= dTTdate && so.RemindPeriod != 0))
                                             select new
                                             {
                                                 c.CustomerID,
                                                 Code = c.Code,
                                                 Name = c.Code + "," + c.Name + "," + c.Address + "," + c.ContactNo,
                                                 RefName = c.RefName + "," + c.RefContact,
                                                 ContactNo = c.ContactNo,
                                                 Address = c.Address,
                                                 TotalDue = c.TotalDue,
                                                 SOrderID=so.CashCollectionID,
                                                 InvoiceNo=so.ReceiptNo,
                                                 OrderInovice = so.ReceiptNo.Substring(4),
                                                 InvoiceDate=so.EntryDate,
                                                 so.RemindDate,
                                                 TotalAmount=0m,
                                                 ProductName="",
                                                 SType="Cash"
                                             }).OrderByDescending(i => i.InvoiceDate).ThenByDescending(i => i.OrderInovice).ToList();


                        var tempSales = (from so in db.SOrders
                                         join sod in db.SOrderDetails on so.SOrderID equals sod.SOrderID
                                         join p in db.Products on sod.ProductID equals p.ProductID
                                         join c in db.Customers on so.CustomerID equals c.CustomerID
                                         where (c.TotalDue > 0 && so.Status == (int)EnumSalesType.Sales && (so.RemindDate >= dFFdate && so.RemindDate <= dTTdate && so.RemindPeriod!=0))
                                         select new
                                         {
                                             c.CustomerID,
                                             Code = c.Code,
                                             Name = c.Code + "," + c.Name + "," + c.Address + "," + c.ContactNo,
                                             RefName = c.RefName + "," + c.RefContact,
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
                                          group so by new { so.CustomerID, so.Code, so.Name, so.ContactNo, so.Address, so.TotalDue, so.InvoiceDate,  so.TotalAmount,so.RefName } into g
                                          select new
                                          {
                                              g.Key.CustomerID,
                                              g.Key.Code,
                                              g.Key.ContactNo,
                                              g.Key.Name,
                                              g.Key.RefName,
                                              g.Key.Address,
                                              g.Key.TotalDue,
                                              SOrderID =g.Select(o=>o.SOrderID).FirstOrDefault(),
                                              InvoiceNo = g.Select(o=>o.InvoiceNo).FirstOrDefault(),
                                              InvoiceDate = g.Key.InvoiceDate,
                                              RemindDate = g.Select(o=>o.RemindDate).FirstOrDefault(),
                                              TotalAmount = g.Key.TotalAmount,
                                              ProductName = g.Select(i => i.ProductName).ToList(),
                                              SType = g.Select(o => o.SType).FirstOrDefault(),
                                          });

                        var Sales = (from so in temp2Sales
                                     group so by new { so.CustomerID, so.Code, so.Name, so.ContactNo, so.Address, so.TotalDue } into g
                                     select new
                                     {
                                         g.Key.CustomerID,
                                         g.Key.Code,
                                         g.Key.ContactNo,
                                         g.Key.Name,
                                         g.Key.Address,
                                         g.Key.TotalDue,
                                         SOrderID = g.Select(i => i.SOrderID).FirstOrDefault(),
                                         InvoiceNo = g.Select(i => i.InvoiceNo).FirstOrDefault(),
                                         InvoiceDate = g.Select(i => i.InvoiceDate).FirstOrDefault(),
                                         RemindDate = g.Select(i => i.RemindDate).FirstOrDefault(),
                                         TotalAmount = g.Select(i => i.TotalAmount).FirstOrDefault(),
                                         ProductNameList = g.Select(i => i.ProductName).FirstOrDefault()
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
                            row["Installment"] = 0m;
                            row["CurrentPaid"] = 0m;
                            row["Remarks"] = "";
                            row["DownPayment"] = 0m;
                            row["InsRec"] = 0m;
                            row["TotalRec"] = 0m;
                            row["Closing"] = item.TotalDue;
                            row["RemindDate"] = item.RemindDate;
                            row["DefaultInstallment"] = 0m;                                                          
                            dt.Rows.Add(row);
                            Counter = 0;
                            ProductName = string.Empty;
                        }
                        #endregion

                        dt.TableName = "rptDataSet_dtUpcomingSchedule";
                        ds.Tables.Add(dt);
                        string embededResource = "ESRP.UI.RDLC.UpComingSchedule.rdlc";

                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();

                        //rParam = new ReportParameter("PaymentDate", dFFdate.ToString("dd MMM yyyy"));
                        //parameters.Add(rParam);

                        rParam = new ReportParameter("DateRange", "Installment From : " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
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

            //}
            #endregion


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlEmployee_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
