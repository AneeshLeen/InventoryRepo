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
using ESRP.DA;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraPrinting;
using System.Configuration;
using System.Data.SqlClient;

namespace ESRP.UI
{
    public partial class fBankLedger : Form
    {
        DEWSRMEntities db = null;
        public fBankLedger()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
          if(ctlBank.SelectedID!=0)
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
                  TransactionalDataSet.dtBankLedgerDataTable dt = new TransactionalDataSet.dtBankLedgerDataTable();

                  double Opening = 0;
                  double Closing = 0;
                  double GrandClosing = 0;
                  double GrandOpening = 0;
                  int BankIDTemp = 0;


                  using (DEWSRMEntities db1 = new DEWSRMEntities())
                  {
                      using (var connection = db1.Database.Connection)
                      {
                          connection.Open();
                          var command = connection.CreateCommand();
                          command.CommandText = "EXEC sp_BankLedger";
                          var reader = command.ExecuteReader();
                          var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<BankLedgerModel>(reader).ToList();
                          var  Data2 = Data.Where(o => o.BankID == ctlBank.SelectedID);

                          foreach (var item in Data2)
                          {
                              if (BankIDTemp != item.BankID)
                              {
                                  Opening = (double)item.Opening;
                                  Closing = Opening + (double)item.Deposit - (double)item.Widthdraw + (double)item.CashCollection - (double)item.CashDelivery + (double)item.FundIN - (double)item.FundOut;

                              }
                              else
                              {

                                  Opening = Closing;
                                  Closing = Opening + (double)item.Deposit - (double)item.Widthdraw + (double)item.CashCollection - (double)item.CashDelivery + (double)item.FundIN - (double)item.FundOut;

                              }

                              if (item.TransDate >= dFFDate && item.TransDate <= dTTDate)
                                  dt.Rows.Add(item.BankID, item.BankName, item.TransDate, item.TransactionNo, Opening, item.Deposit, item.Widthdraw, item.CashCollection, item.CashDelivery, item.FundIN, item.FundOut, Closing);

                              BankIDTemp = item.BankID;
                          }

                          BankIDTemp = 0;
                          Opening = 0;
                          foreach (var item in Data2)
                          {
                              if (BankIDTemp != item.BankID)
                              {
                                  Opening = (double)item.Opening;
                                  GrandOpening = GrandOpening + (double)item.Opening;
                              }
                              else
                              {
                                  Opening = 0;
                              }

                              GrandClosing = GrandClosing + Opening + (double)item.Deposit - (double)item.Widthdraw + (double)item.CashCollection - (double)item.CashDelivery + (double)item.FundIN - (double)item.FundOut;



                              BankIDTemp = item.BankID;

                          }

                      }
                  }



                  DataSet ds = new DataSet();

                  dt.TableName = "TransactionalDataSet_dtBankLedger";
                  ds.Tables.Add(dt);
                  string embededResource = "ESRP.UI.RDLC.rptBankLedger.rdlc";
                  ReportParameter rParam = new ReportParameter();
                  List<ReportParameter> parameters = new List<ReportParameter>();
                  rParam = new ReportParameter("DateRange", "Date from: " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                  parameters.Add(rParam);
                  rParam = new ReportParameter("GrandClosing", GrandClosing.ToString());
                  parameters.Add(rParam);

                  rParam = new ReportParameter("GrandOpening", GrandOpening.ToString());
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
          else
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
                  TransactionalDataSet.dtBankLedgerDataTable dt = new TransactionalDataSet.dtBankLedgerDataTable();
                  double Opening = 0;
                  double Closing = 0;
                  double GrandClosing = 0;
                  double GrandOpening = 0;
                  int BankIDTemp = 0;
                  using (DEWSRMEntities db1 = new DEWSRMEntities())
                  {
                      using (var connection = db1.Database.Connection)
                      {
                          connection.Open();
                          var command = connection.CreateCommand();
                          command.CommandText = "EXEC sp_BankLedger";
                          var reader = command.ExecuteReader();
                          var Data = ((IObjectContextAdapter)db1).ObjectContext.Translate<BankLedgerModel>(reader).ToList();


                          foreach (var item in Data)
                          {
                              if (BankIDTemp != item.BankID)
                              {
                                  Opening = (double)item.Opening;
                                  Closing = Opening + (double)item.Deposit - (double)item.Widthdraw + (double)item.CashCollection - (double)item.CashDelivery + (double)item.FundIN - (double)item.FundOut;

                              }
                              else
                              {

                                  Opening = Closing;
                                  Closing = Opening + (double)item.Deposit - (double)item.Widthdraw + (double)item.CashCollection - (double)item.CashDelivery + (double)item.FundIN - (double)item.FundOut;

                              }

                              if (item.TransDate >= dFFDate && item.TransDate <= dTTDate)
                                  dt.Rows.Add(item.BankID, item.BankName, item.TransDate, item.TransactionNo, Opening, item.Deposit, item.Widthdraw, item.CashCollection, item.CashDelivery, item.FundIN, item.FundOut, Closing);
                              BankIDTemp = item.BankID;

                          }

                          BankIDTemp = 0;
                          Opening = 0;
                          foreach (var item in Data)
                          {
                              if (BankIDTemp != item.BankID)
                              {
                                  Opening = (double)item.Opening;
                                  GrandOpening = GrandOpening + (double)item.Opening;
                              }
                              else
                              {
                                  Opening = 0;
                              }

                              GrandClosing = GrandClosing + Opening + (double)item.Deposit - (double)item.Widthdraw + (double)item.CashCollection - (double)item.CashDelivery + (double)item.FundIN - (double)item.FundOut;



                              BankIDTemp = item.BankID;

                          }

                      }
                  }



                  DataSet ds = new DataSet();

                  dt.TableName = "TransactionalDataSet_dtBankLedger";
                  ds.Tables.Add(dt);
                  string embededResource = "ESRP.UI.RDLC.rptBankLedger.rdlc";
                  ReportParameter rParam = new ReportParameter();
                  List<ReportParameter> parameters = new List<ReportParameter>();
                  rParam = new ReportParameter("DateRange", "Date from: " + fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy"));
                  parameters.Add(rParam);
                  rParam = new ReportParameter("GrandClosing", GrandClosing.ToString());
                  parameters.Add(rParam);

                  rParam = new ReportParameter("GrandOpening", GrandOpening.ToString());
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
