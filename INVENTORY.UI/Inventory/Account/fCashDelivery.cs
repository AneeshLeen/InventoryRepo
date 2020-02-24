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
    public partial class fCashDelivery : Form
    {
        private CashCollection _CashCollection = null;
        public Action ItemChanged;
        DEWSRMEntities db = null;
        Customer _oCustomer = null;
        Supplier _oSupplier = null;
        SOrder _SOrder = null;
        POrder _POrder = null;
        bool _IsEdit = false;
        decimal PrvCashCollAmt = 0;
        public fCashDelivery()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(CashCollection oCashCollection,bool IsEdit)
        {
            _IsEdit = IsEdit;
            _CashCollection = oCashCollection;
            if (IsEdit)
            {
                PrvCashCollAmt = (decimal)_CashCollection.Amount + _CashCollection.AdjustAmt;
                ctlCompany.Enabled = false;
            }

            PopulateTranTypeCbo();
            PopulatePayTypeCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            if (_CashCollection == null)
                _CashCollection = new CashCollection();

            dtpDate.Value = _CashCollection.EntryDate!=  DateTime.MinValue ?(DateTime) _CashCollection.EntryDate : DateTime.Now;
            cboTranType.SelectedValue = _CashCollection.TransactionType != null ? _CashCollection.TransactionType : 1;
            cboPayType.SelectedValue = _CashCollection.PaymentType != null ? _CashCollection.PaymentType : 1;
            ctlCompany.SelectedID = _CashCollection.CompanyID!=null?(int)_CashCollection.CompanyID:0;
            //ctlCustomer.SelectedID = _CashCollection.CustomerID!=null?(int)_CashCollection.CustomerID:0;
            txtBankName.Text = _CashCollection.BankName;
            txtBranchName.Text = _CashCollection.BranchName;
            txtAccountNo.Text = _CashCollection.AccountNo;
            txtMBAccount.Text = _CashCollection.MBAccountNo;
            txtbKashNo.Text = _CashCollection.BKashNo;
            numAmount.Value = _CashCollection.Amount != null ? (decimal)_CashCollection.Amount : 0;
          //  numTotalDue.Value = _CashCollection.Supplier.TotalDue;
            txtCheckNo.Text = _CashCollection.CheckNo;
            dtpIssueDate.Value = _CashCollection.IssueDate != null ? (DateTime)_CashCollection.IssueDate : DateTime.Now;
            numAdjustment.Value = _CashCollection.AdjustAmt;


            if (_CashCollection.Supplier == null)
            {
                numTotalDue.Value = 0;
                numDueAmt.Value = 0;
            }
            else
            {
                if (_IsEdit)
                {
                    //numTotalDue.Value = _CashCollection.Customer.TotalDue + PrvCashCollAmt;
                    //numDueAmt.Value = ((_CashCollection.Customer.TotalDue + PrvCashCollAmt)- (decimal)_CashCollection.Amount); 

                    numTotalDue.Value = _CashCollection.Customer.TotalDue + PrvCashCollAmt;
                    numDueAmt.Value = ((_CashCollection.Customer.TotalDue + PrvCashCollAmt) - ((decimal)_CashCollection.Amount + _CashCollection.AdjustAmt));                

                }
                else
                {
                    numTotalDue.Value = _CashCollection.Supplier.TotalDue;
                    numDueAmt.Value = (_CashCollection.Supplier.TotalDue - (decimal)_CashCollection.Amount);                
                }
            }
        }

        private void PopulateTranTypeCbo()
        {
            cboTranType.DisplayMember = "Name";
            cboTranType.ValueMember = "ID";
            cboTranType.DataSource = Enum.GetValues(typeof(EnumTranType)).Cast<EnumTranType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        }

        private void PopulatePayTypeCbo()
        {
            cboPayType.DisplayMember = "Name";
            cboPayType.ValueMember = "ID";
            cboPayType.DataSource = Enum.GetValues(typeof(EnumPayType)).Cast<EnumPayType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        }

        private void RefreshObject()
        {
            _CashCollection.EntryDate = dtpDate.Value;
            _CashCollection.TransactionType = (int)cboTranType.SelectedValue;
            
            if (_oSupplier!=null)
            _CashCollection.CompanyID = _oSupplier.SupplierID;
            
            if (_oCustomer != null)
                _CashCollection.CustomerID = _oCustomer.CustomerID;


            _CashCollection.PaymentType = (int)cboPayType.SelectedValue;

            _CashCollection.BankName = txtBankName.Text;
            _CashCollection.BranchName = txtBranchName.Text;
            _CashCollection.AccountNo = txtAccountNo.Text;
            _CashCollection.MBAccountNo = txtMBAccount.Text;
            _CashCollection.BKashNo = txtbKashNo.Text;
            _CashCollection.Amount = numAmount.Value;
            
            _CashCollection.CheckNo = txtCheckNo.Text;
            _CashCollection.IssueDate = dtpIssueDate.Value;
            _CashCollection.AdjustAmt = numAdjustment.Value;
            _CashCollection.ReceiptNo = "";
            _CashCollection.CreateDate = _CashCollection.EntryDate;
            _CashCollection.CreatedBy = (int)Global.CurrentUser.UserID;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_CashCollection.CashCollectionID <= 0)
                    {
                        RefreshObject();
                        _CashCollection.CashCollectionID = db.CashCollections.Count() > 0 ? db.CashCollections.Max(obj => obj.CashCollectionID) + 1 : 1;
                        db.CashCollections.Add(_CashCollection);

                        if (_oSupplier != null)
                        {
                            _oSupplier.TotalDue -= ((decimal)_CashCollection.Amount + _CashCollection.AdjustAmt);
                        }

                    }
                    else
                    {
                        _CashCollection = db.CashCollections.FirstOrDefault(obj => obj.CashCollectionID == _CashCollection.CashCollectionID);
                        RefreshObject();

                        if (_oSupplier != null)
                        {
                            _oSupplier.TotalDue = _oSupplier.TotalDue + PrvCashCollAmt;
                            _oSupplier.TotalDue -= ((decimal)_CashCollection.Amount + _CashCollection.AdjustAmt);

                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Do you want to create another Collection?", "Create Collection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        if (_oCustomer != null)
                        {
                            MoneyReceipt();
                        }
                        if (ItemChanged != null)
                        {
                            ItemChanged();
                        }
                        this.Close();
                    }
                    else
                    {
                        if (_oCustomer != null)
                        {
                            MoneyReceipt();
                        }
                        if (ItemChanged != null)
                        {
                            ItemChanged();
                        }
                        _CashCollection = new CashCollection();
                        RefreshValue();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException == null)
                        MessageBox.Show(ex.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.InnerException.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MoneyReceipt()
        {

            DataSet ds = new DataSet();
            string embededResource = "INVENTORY.UI.RDLC.AMMoneyReceipt.rdlc";
            ReportParameter rParam = new ReportParameter();
            List<ReportParameter> parameters = new List<ReportParameter>();

            if (_SOrder != null)
            {
                rParam = new ReportParameter("ReceiptNo", _SOrder.InvoiceNo);
                parameters.Add(rParam);

                string sInwodTk = Global.TakaFormat(Convert.ToDouble(_CashCollection.Amount.ToString()));
                //_SOrder.RecAmount.ToString()
                rParam = new ReportParameter("ReceiptTK", _CashCollection.Amount.ToString());
                parameters.Add(rParam);
                //_SOrder.InvoiceDate.ToString()
                rParam = new ReportParameter("ReceiptDate", _CashCollection.EntryDate.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Name", _SOrder.Customer.Name);
                parameters.Add(rParam);

                rParam = new ReportParameter("Address", _SOrder.Customer.Address);
                parameters.Add(rParam);

                rParam = new ReportParameter("InWordTK", sInwodTk);
                parameters.Add(rParam);

                rParam = new ReportParameter("Logo", Application.StartupPath + @"\Logo.bmp");
                parameters.Add(rParam);

                fReportViewer frm = new fReportViewer();
                frm.CommonReportViewer(embededResource, ds, parameters, false);

            }
            else
            {
                rParam = new ReportParameter("ReceiptNo", _CashCollection.CashCollectionID.ToString());
                parameters.Add(rParam);

                string sInwodTk = Global.TakaFormat(Convert.ToDouble(_CashCollection.Amount.ToString()));
                //_SOrder.RecAmount.ToString()
                rParam = new ReportParameter("ReceiptTK", _CashCollection.Amount.ToString());
                parameters.Add(rParam);
                //_SOrder.InvoiceDate.ToString()
                rParam = new ReportParameter("ReceiptDate", _CashCollection.EntryDate.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Name", _oCustomer.Name);
                parameters.Add(rParam);

                rParam = new ReportParameter("Address", _oCustomer.Address);
                parameters.Add(rParam);

                rParam = new ReportParameter("InWordTK", sInwodTk);
                parameters.Add(rParam);

                rParam = new ReportParameter("Logo", Application.StartupPath + @"\Logo.bmp");
                parameters.Add(rParam);

                fReportViewer frm = new fReportViewer();
                frm.CommonReportViewer(embededResource, ds, parameters, false);

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCompany_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                _oSupplier = (Supplier)(db.Suppliers.FirstOrDefault(o => o.SupplierID == ctlCompany.SelectedID));

                if (_oSupplier != null)
                {
                    _POrder = db.POrders
                                 .Where(c => c.SupplierID == ctlCompany.SelectedID && c.Status==1)
                                 .OrderByDescending(t => t.OrderDate)
                                 .FirstOrDefault();

                    numTotalDue.Value = _oSupplier.TotalDue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {
            //try
            //{
            //     _oCustomer = (Customer)(db.Customers.FirstOrDefault(o => o.CustomerID == ctlCustomer.SelectedID));

            //    if (_oCustomer != null)
            //    {
            //        _SOrder = db.SOrders
            //                    .Where(c => c.CustomerID == ctlCustomer.SelectedID && c.Status==1)
            //                    .OrderByDescending(t => t.InvoiceDate)
            //                    .FirstOrDefault();

            //        numTotalDue.Value = _oCustomer.TotalDue;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }
        private void cboTranType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(cboTranType.SelectedValue)==(Int16)EnumTranType.FromCustomer)
            {
                //ctlCustomer.Enabled = true;
                ctlCompany.Enabled = false;
                ctlCompany.SelectedID = 0;
                numTotalDue.Value = 0;
            }
            else 
            {
                if (_IsEdit)
                    ctlCompany.Enabled = false;
                else
                    ctlCompany.Enabled = true;

                //ctlCustomer.Enabled = false;
                //ctlCustomer.SelectedID = 0;
                numTotalDue.Value = 0;
            }

        }

        private void cboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboPayType.SelectedValue) == (Int16)EnumPayType.Cash)
            {
                txtBankName.Enabled = false;
                txtBranchName.Enabled = false;
                txtAccountNo.Enabled = false;
                txtMBAccount.Enabled = false;
                txtbKashNo.Enabled = false;
                txtCheckNo.Enabled = false;
                dtpIssueDate.Enabled = false;

            }
            else if (Convert.ToInt16(cboPayType.SelectedValue) == (Int16)EnumPayType.Cheque)
            {
                txtBankName.Enabled = true;
                txtBranchName.Enabled = true;
                txtAccountNo.Enabled = true;
                txtMBAccount.Enabled = false;
                txtbKashNo.Enabled = false;
                txtCheckNo.Enabled = true;
                dtpIssueDate.Enabled = true;

            }
            else if (Convert.ToInt16(cboPayType.SelectedValue) == (Int16)EnumPayType.TT)
            {
                txtBankName.Enabled = true;
                txtBranchName.Enabled = true;
                txtAccountNo.Enabled = true;
                txtMBAccount.Enabled = false;
                txtbKashNo.Enabled = false;
                txtCheckNo.Enabled = true;
                dtpIssueDate.Enabled = true;

            }
            else if (Convert.ToInt16(cboPayType.SelectedValue) == (Int16)EnumPayType.Online)
            {
                txtBankName.Enabled = true;
                txtBranchName.Enabled = true;
                txtAccountNo.Enabled = true;
                txtMBAccount.Enabled = false;
                txtbKashNo.Enabled = false;
                txtCheckNo.Enabled = true;
                dtpIssueDate.Enabled = true;

            }
            else if (Convert.ToInt16(cboPayType.SelectedValue) == (Int16)EnumPayType.MBanking)
            {
                txtBankName.Enabled = true;
                txtBranchName.Enabled = true;
                txtAccountNo.Enabled = false;
                txtMBAccount.Enabled = true;
                txtbKashNo.Enabled = false;

            }
            else
            {
                txtBankName.Enabled = false;
                txtBranchName.Enabled = false;
                txtAccountNo.Enabled = false;
                txtMBAccount.Enabled = false;
                txtbKashNo.Enabled = true;
                txtCheckNo.Enabled = false;
                dtpIssueDate.Enabled = false;
            }
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            { 
                if(numTotalDue.Value>=numAmount.Value )
                {
                    numDueAmt.Value = numTotalDue.Value - numAmount.Value;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fCashCollection_Load(object sender, EventArgs e)
        {

        }

        private void numAmount_Enter(object sender, EventArgs e)
        {
            numAmount.Select(0, numAmount.Text.Length);
        }

        private void numAdjustment_Enter(object sender, EventArgs e)
        {
            numAdjustment.Select(0, numAdjustment.Text.Length);
        }

        private void numAdjustment_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numTotalDue.Value >= numAmount.Value)
                {
                    numDueAmt.Value = (numTotalDue.Value - (numAmount.Value + numAdjustment.Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
