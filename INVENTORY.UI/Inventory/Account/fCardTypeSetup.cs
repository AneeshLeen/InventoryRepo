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
    public partial class fCardTypeSetup : Form
    {

        private CardTypeSetup _CardTypeSetup = null;
        public Action ItemChanged;
        DEWSRMEntities db = null;
        bool _IsEdit = false;
        int nBankID = 0;
        Bank _Bank = null;

        public fCardTypeSetup()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }


        public void ShowDlg(CardTypeSetup oCardTypeSetup, bool IsEdit)
        {
            _IsEdit = IsEdit;
            if(IsEdit)
            {
                ctlBank.Enabled = false;
            }

            _CardTypeSetup = oCardTypeSetup;
            PopulateCardTypeCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            try
            {
                ctlBank.SelectedID = _CardTypeSetup.BankID;

                //_Bank = db.Banks.FirstOrDefault(b => b.BankID == ctlBank.SelectedID);
                //if ((CardType)cboTranType.SelectedItem != null)
                //    cboTranType.SelectedValue = ((CardType)cboTranType.SelectedItem).CardTypeID; 

                cboTranType.SelectedValue = _CardTypeSetup.CardTypeID != 0 ? _CardTypeSetup.CardTypeID : 1;
                numPercentage.Value = _CardTypeSetup.Percentage;
                txtCode.Text = GenerateCode();                                         
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
           
            if (numPercentage.Value == 0)
            {
                MessageBox.Show("Please Enter Percentage.", "Card Type Setup.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numPercentage.Focus();
                return false;
            }
            return true;
        }


        private void RefreshObject()
        {
            _CardTypeSetup.CardTypeID = ((CardType)cboTranType.SelectedItem).CardTypeID;
            _CardTypeSetup.Code = txtCode.Text;
            _CardTypeSetup.Percentage = numPercentage.Value;
            _CardTypeSetup.BankID = (int)ctlBank.SelectedID;
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsNew = false;
                if (!IsValid()) return;

                if (_CardTypeSetup.CardTypeSetupID <= 0)
                    {
                        RefreshObject();
                        _CardTypeSetup.CardTypeSetupID = db.CardTypeSetups.Count() > 0 ? db.CardTypeSetups.Max(obj => obj.CardTypeSetupID) + 1 : 1;
                        db.CardTypeSetups.Add(_CardTypeSetup);
                        IsNew = true;
                    }
                    else
                    {
                        _CardTypeSetup = db.CardTypeSetups.FirstOrDefault(obj => obj.CardTypeSetupID == _CardTypeSetup.CardTypeSetupID);
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
                        _CardTypeSetup = new CardTypeSetup();
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

        private void fCardTypeSetup_Load(object sender, EventArgs e)
        {
           // PopulateTranTypeCbo();
        }

        private void cboTranType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PopulateCardTypeCbo()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                cboTranType.DisplayMember = "Description";
                cboTranType.ValueMember = "CardTypeID";
                cboTranType.DataSource = db.CardTypes.OrderBy(x => x.Sequence).ToList();
            }
        }

        private void numAmount_Enter(object sender, EventArgs e)
        {
            numPercentage.Select(0, numPercentage.Text.Length);
        }


        private void ctlBank_SelectedItemChanged(object sender, EventArgs e)
        {
             _Bank = db.Banks.FirstOrDefault(b => b.BankID == ctlBank.SelectedID);              
        }

        private string GenerateCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.CardTypeSetups.ToList().Count > 0)
                {
                    maxValue = db.CardTypeSetups.Max(x => x.CardTypeSetupID);
                    if (maxValue != null)
                        i = (int)maxValue;
                }
                else
                {
                    i = 0;
                }

                if (i.ToString().Length == 1)
                {
                    sCode = "CT-0000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "CT-000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "CT-00" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "CT-0" + Convert.ToString(i + 1);
                }
                else
                {
                    sCode = "CT-0" + Convert.ToString(i + 1);
                }
            }
            return sCode;
        }
    }
}
