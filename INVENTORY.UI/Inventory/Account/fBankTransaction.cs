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

namespace INVENTORY.UI
{
    public partial class fBankTransaction : Form
    {

        private BankTransaction _BankTransaction = null;
        public Action ItemChanged;
        DEWSRMEntities db = null;
        bool _IsEdit = false;
        decimal PrvTotalAmt = 0;
        int nBankID = 0;
        decimal start = 0;

        Bank _Bank = null;
        Customer _Customer = null;
        Supplier _Supplier = null;
        Bank _AnotherBank = null;
       
        public fBankTransaction()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }


        public void ShowDlg(BankTransaction oBankTransaction, bool IsEdit)
        {
            //var MaxTran1 = db.BankTransactions
            //.Where(a => a.TranDate == db.BankTransactions.Max(x => x.TranDate)).SingleOrDefault();

            //if (MaxTran1 != null)
            //    PrvTotalAmt = MaxTran1.TotalAmt;
            //else
            //    PrvTotalAmt = 0;

            _IsEdit = IsEdit;
            if(IsEdit)
            {
                ctlBank.Enabled = false;
                ctlAnotherBank.Enabled = false;
                ctlCustomer.Enabled = false;
                ctlSupplier.Enabled = false;
            }

            _BankTransaction = oBankTransaction;
            PopulateTranTypeCbo();
            RefreshValue();
            RefreshControl();
            this.ShowDialog();
        }

        private void RefreshControl()
        {
            if ((int)cboTranType.SelectedValue == 1)
            {
                ctlBank.Enabled = true;
                ctlCustomer.Enabled = false;
                ctlSupplier.Enabled = false;
                ctlAnotherBank.Enabled = false;

            }
            else if ((int)cboTranType.SelectedValue == 2)
            {
                ctlBank.Enabled = true;
                ctlCustomer.Enabled = false;
                ctlSupplier.Enabled = false;
                ctlAnotherBank.Enabled = false;

            }
            else if ((int)cboTranType.SelectedValue == 3)
            {
                ctlBank.Enabled = true;
                ctlCustomer.Enabled = true;
                ctlSupplier.Enabled = false;
                ctlAnotherBank.Enabled = false;

            }
            else if ((int)cboTranType.SelectedValue == 4)
            {
                ctlBank.Enabled = true;
                ctlCustomer.Enabled = false;
                ctlSupplier.Enabled = true;
                ctlAnotherBank.Enabled = false;
            }

            else if ((int)cboTranType.SelectedValue == 5)
            {
                ctlBank.Enabled = true;
                ctlCustomer.Enabled = false;
                ctlSupplier.Enabled = false;
                ctlAnotherBank.Enabled = true;

            }
            else
            {


                ctlBank.Enabled = true;
                ctlCustomer.Enabled = false;
                ctlSupplier.Enabled = false;
                ctlAnotherBank.Enabled = false;

            }

        }


        private void RefreshValue()
        {
            try
            {

                numRPAmount.Value = _BankTransaction.Amount != null ? _BankTransaction.Amount : 0;
                ctlBank.SelectedID = _BankTransaction.BankID;
                _Bank = db.Banks.FirstOrDefault(b => b.BankID == ctlBank.SelectedID);

                if (_Bank != null)
                {
                    numTotalAmt.Value = _Bank.TotalAmount;
                  
                }                   
                else
                {
                    numTotalAmt.Value = 0;
           
                                    
                }
                
                dtpDate.Value = _BankTransaction.TranDate != DateTime.MinValue ? _BankTransaction.TranDate : DateTime.Now;
                cboTranType.SelectedValue = _BankTransaction.TransactionType !=0?_BankTransaction.TransactionType:1;

                ctlCustomer.SelectedID = _BankTransaction.CustomerID!=null? (int) _BankTransaction.CustomerID:0;
                ctlSupplier.SelectedID = _BankTransaction.SupplierID!=null?  (int)_BankTransaction.SupplierID:0;
                ctlAnotherBank.SelectedID = _BankTransaction.AnotherBankID!=null? (int) _BankTransaction.AnotherBankID:0;
               
                

                txtCheckNo.Text = _BankTransaction.ChecqueNo;
                numTotalAmt.Value = 0;
                numRPAmount.Value = _BankTransaction.Amount;
                numEditAmt.Value = _BankTransaction.Amount;
               // ctlBranch.SelectedID= _BankTransaction.BranchID ;

               // Bank obnk = db.Banks.FirstOrDefault(b => b.BankID == _BankTransaction.BranchID);

                //if (obnk != null)
                //    ctlBank.SelectedID = obnk.BankID;
                //else
                //    ctlBank.SelectedID = 0;


               txtTransactionNumber.Text = GenerateTransNo();                                         
               txtDescription.Text=_BankTransaction.Remarks!=null?_BankTransaction.Remarks:"";


               if (_IsEdit == true)
               {
                   cboTranType.Enabled = false;

               }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {   
            if(ctlBank.SelectedID==0)
            {

                MessageBox.Show("Please Enter Bank Name.", "Bank Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlBank.Focus();
                return false;
            }
           
            if (numRPAmount.Value == 0)
            {
                MessageBox.Show("Please Enter Amount.", "Cash Transaction.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numRPAmount.Focus();
                return false;
            }
            return true;
        }


        private void RefreshObject()
        {
            _BankTransaction.TranDate =dtpDate.Value;//
            _BankTransaction.TransactionType= (int)cboTranType.SelectedValue;
         //   _BankTransaction.BranchID = ctlBranch.SelectedID;
            _BankTransaction.TransactionNo = txtTransactionNumber.Text;
            _BankTransaction.Amount = numRPAmount.Value;
           // _Branch.TotalAmount = numTotalAmt.Value;
            _BankTransaction.Remarks = txtDescription.Text;
            _BankTransaction.BankID =(int) ctlBank.SelectedID;
            _BankTransaction.CustomerID = (int)ctlCustomer.SelectedID;
            _BankTransaction.SupplierID = (int)ctlSupplier.SelectedID;
            _BankTransaction.AnotherBankID = (int)ctlAnotherBank.SelectedID;
            _BankTransaction.ChecqueNo = txtCheckNo.Text;

            

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsNew = false;
                if (!IsValid()) return;
                
                    if (_BankTransaction.BankTranID <= 0)
                    {
                        RefreshObject();
                       
                     


                       if( _BankTransaction.TransactionType==1)
                       {
                           Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                           double Previous = (double)oBank.TotalAmount;

                          

                           Previous = Previous + (double)_BankTransaction.Amount;
                           oBank.TotalAmount = (decimal)Previous;
                         
                       }
                       else if (_BankTransaction.TransactionType == 2)
                       {
                           Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                           double Previous = (double)oBank.TotalAmount;

                           if (Previous < (double)_BankTransaction.Amount)
                           {
                               MessageBox.Show("Amount is not availabe", "Bank Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               numRPAmount.Focus();
                               return;
                           }
                         
                           Previous = Previous - (double)_BankTransaction.Amount;
                           oBank.TotalAmount = (decimal)Previous;
                          
                       }
                       else if (_BankTransaction.TransactionType == 3)
                       {
                           Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                           double Previous = (double)oBank.TotalAmount;
                           Previous = Previous + (double)_BankTransaction.Amount;
                           oBank.TotalAmount = (decimal)Previous;

                    
                            Previous = (double) _Customer.TotalDue;

                          
                           Previous=Previous-(double)_BankTransaction.Amount;
                           _Customer.TotalDue = (decimal)Previous;

                          


                         
                            

                       }
                       else if (_BankTransaction.TransactionType == 4)
                       {
                           Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                           double Previous = (double)oBank.TotalAmount;

                           if (Previous < (double)_BankTransaction.Amount)
                           {
                               MessageBox.Show("Amount is not availabe", "Bank Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               numRPAmount.Focus();
                               return;
                           }

                           Previous = Previous - (double)_BankTransaction.Amount;
                           oBank.TotalAmount = (decimal)Previous;

                           
                           Previous = (double)_Supplier.TotalDue;
                           Previous = Previous -(double)_BankTransaction.Amount;
                           _Supplier.TotalDue = (decimal)Previous;
                       }
                       else if (_BankTransaction.TransactionType == 5)
                       {
                           Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                           double Previous = (double)oBank.TotalAmount;
                           Previous = Previous -(double)_BankTransaction.Amount;
                           if (Previous < (double)_BankTransaction.Amount)
                           {
                               MessageBox.Show("Amount is not availabe", "Bank Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               numRPAmount.Focus();
                               return;
                           }
                           if(ctlBank.SelectedID==ctlAnotherBank.SelectedID)
                           {
                               MessageBox.Show("Fund Transfer to same bank is not possible", "Fund Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               ctlAnotherBank.Focus();
                               return;
                           }
                           oBank.TotalAmount = (decimal)Previous;
                         

                            
                           Previous = (double)_AnotherBank.TotalAmount;
                            Previous = Previous + (double)_BankTransaction.Amount;
                            _AnotherBank.TotalAmount = (decimal)Previous;
                       }

                       _BankTransaction.BankTranID = db.BankTransactions.Count() > 0 ? db.BankTransactions.Max(obj => obj.BankTranID) + 1 : 1;
                       db.BankTransactions.Add(_BankTransaction);

                        IsNew = true;
                    }
                    else
                    {



                        if (_BankTransaction.TransactionType == 1)
                        {
                            Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                            double Previous = (double)oBank.TotalAmount;

                            double changeAmt = (double)numRPAmount.Value - (double)numEditAmt.Value;

                            Previous = Previous + changeAmt - (double)numEditAmt.Value;
                            oBank.TotalAmount = (decimal)Previous;

                        }
                        else if (_BankTransaction.TransactionType == 2)
                        {
                            Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                            double Previous = (double)oBank.TotalAmount;

                            if (Previous < (double)_BankTransaction.Amount)
                            {
                                MessageBox.Show("Amount is not availabe", "Bank Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                numRPAmount.Focus();
                                return;
                            }
                            double changeAmt = (double)numRPAmount.Value - (double)numEditAmt.Value;

                            Previous = Previous - changeAmt-(double)numEditAmt.Value;
                            oBank.TotalAmount = (decimal)Previous;

                        }
                        else if (_BankTransaction.TransactionType == 3)
                        {
                            Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                            double Previous = (double)oBank.TotalAmount;
                            Previous = Previous + (double)_BankTransaction.Amount;
                            oBank.TotalAmount = (decimal)Previous;


                            Previous = (double)_Customer.TotalDue;
                            double changeAmt = (double)numRPAmount.Value - (double)numEditAmt.Value;

                            Previous = Previous - changeAmt-(double)numEditAmt.Value;
                            _Customer.TotalDue = (decimal)Previous;


                          
                            



                        }
                        else if (_BankTransaction.TransactionType == 4)
                        {
                            Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                            double Previous = (double)oBank.TotalAmount;
                            Previous = Previous - (double)_BankTransaction.Amount;
                            oBank.TotalAmount = (decimal)Previous;


                            Previous = (double)_Supplier.TotalDue;
                            double changeAmt = (double)numRPAmount.Value - (double)numEditAmt.Value;
                            Previous = Previous -changeAmt - (double)numEditAmt.Value;
                            _Supplier.TotalDue = (decimal)Previous;
                        }
                        else if (_BankTransaction.TransactionType == 5)
                        {
                            Bank oBank = db.Banks.FirstOrDefault(o => o.BankID == _BankTransaction.BankID);
                            double Previous = (double)oBank.TotalAmount;
                            Previous = Previous - (double)_BankTransaction.Amount;
                            if (Previous < (double)_BankTransaction.Amount)
                            {
                                MessageBox.Show("Amount is not availabe", "Bank Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                numRPAmount.Focus();
                                return;
                            }
                            if (ctlBank.SelectedID == ctlAnotherBank.SelectedID)
                            {
                                MessageBox.Show("Fund Transfer to same bank is not possible", "Fund Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ctlAnotherBank.Focus();
                                return;
                            }
                            oBank.TotalAmount = (decimal)Previous;



                            Previous = (double)_AnotherBank.TotalAmount;
                            double changeAmt = (double)numRPAmount.Value - (double)numEditAmt.Value;
                            Previous = Previous + changeAmt;
                            _AnotherBank.TotalAmount = (decimal)Previous;
                        }


                        _BankTransaction = db.BankTransactions.FirstOrDefault(obj => obj.BankTranID == _BankTransaction.BankTranID);
                        RefreshObject();
                    }




                 
                   

                    db.SaveChanges();
                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!IsNew)
                    {
                        if (ItemChanged != null)
                        {
                            ItemChanged();
                        }
                        this.Close();
                    }
                    else
                    {
                        if (ItemChanged != null)
                        {
                            ItemChanged();
                        }
                        _BankTransaction = new BankTransaction();
                        RefreshValue();
                    }
                //}
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.InnerException.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fCashTransaction_Load(object sender, EventArgs e)
        {
           // PopulateTranTypeCbo();
        }

        private void cboTranType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControl();
        }

        private void PopulateTranTypeCbo()
        {
            cboTranType.DisplayMember = "Name";
            cboTranType.ValueMember = "ID";
            cboTranType.DataSource = Enum.GetValues(typeof(EnumBankTransType)).Cast<EnumBankTransType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        }

        private void numAmount_Enter(object sender, EventArgs e)
        {
            numRPAmount.Select(0, numRPAmount.Text.Length);
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            //if(cboTranType.SelectedValue==null )
            //{
            //      numTotalAmt.Value = 0;
            //}
            //else if ((int)cboTranType.SelectedValue == 1)
            //{
            //    if (_Bank != null)
            //    numTotalAmt.Value = (_Bank.TotalAmount + numRPAmount.Value);
            //}            
            //else if ((int)cboTranType.SelectedValue == 2)
            //{
            //    if (_Bank != null)
            //       numTotalAmt.Value = (_Bank.TotalAmount - numRPAmount.Value);
            //}
            //else
            //{
            //    numTotalAmt.Value = 0;
            //}
        }

        private void ctlBank_SelectedItemChanged(object sender, EventArgs e)
        {
             _Bank = db.Banks.FirstOrDefault(b => b.BankID == ctlBank.SelectedID);

              
        }

        private string GenerateTransNo()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.BankTransactions.ToList().Count > 0)
                {
                    maxValue = db.BankTransactions.Max(x => x.BankTranID);
                    if (maxValue != null)
                        i = (int)maxValue;
                }
                else
                {
                    i = 0;
                }

                if (i.ToString().Length == 1)
                {
                    sCode = "T-0000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "T-000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "T-00" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "T-0" + Convert.ToString(i + 1);
                }
                else
                {
                    sCode = "T-0" + Convert.ToString(i + 1);
                }
            }
            return sCode;
        }
        private void ctlBranch_SelectedItemChanged(object sender, EventArgs e)
        {
            //if (ctlBank.SelectedID == 0)
            //{
                
            //    {

            //        MessageBox.Show("Please Enter Bank Name.", "Bank Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ctlBank.Focus();
            //        return;
            //    }
            //}
          
                //_Branch = db.Branches.FirstOrDefault(o => o.BranchID == ctlBranch.SelectedID);
                //if (_Branch != null)
                //    numTotalAmt.Value = _Branch.TotalAmount;
                //else
                //    numTotalAmt.Value = 0;
            
            
            //}
            //nBankID = ctlBank.SelectedID;
            //fCategoryControl oCatCon = new fCategoryControl();
            //oCatCon.nBankID = nBankID;


        }

        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {
            if(ctlCustomer.SelectedID!=0)
            _Customer = db.Customers.FirstOrDefault(o => o.CustomerID == ctlCustomer.SelectedID);
            numTotalAmt.Value = _Customer.TotalDue;
            lblTransacto.Text = "Cust.Pre. Due";

        }

        private void ctlSupplier_SelectedItemChanged(object sender, EventArgs e)
        {
            if(ctlSupplier.SelectedID!=0)
            {
                _Supplier = db.Suppliers.FirstOrDefault(o => o.SupplierID == ctlSupplier.SelectedID);
                numTotalAmt.Value = _Supplier.TotalDue;
                lblTransacto.Text = "Supp. Pre. Due";
            }
           
        }

        private void ctlAnotherBank_SelectedItemChanged(object sender, EventArgs e)
        {
            if(ctlAnotherBank.SelectedID!=0)
            {
                _AnotherBank = db.Banks.FirstOrDefault(o => o.BankID == ctlAnotherBank.SelectedID);
                numTotalAmt.Value = _AnotherBank.TotalAmount;
                lblTransacto.Text = "A.Bank Amt.";
            }
          


        }

    }
}
