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
    public partial class fInvestment : Form
    {
        private ShareInvestment _ShareInvestment = null;
        public Action ItemChanged;
        EnumTransactionType _TranType;
        EnumParentType _ParentID;
        public fInvestment()
        {
            InitializeComponent();
        }
        public void ShowDlg(ShareInvestment oShareInvestment,EnumParentType nParaentID,EnumTransactionType nTranType)
        {
            _TranType = nTranType;
            _ParentID = nParaentID;
            _ShareInvestment = oShareInvestment;

            //PopulateTranTypeCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void PopulateTranTypeCbo()
        {
            cboTranType.DisplayMember = "Name";
            cboTranType.ValueMember = "ID";
            cboTranType.DataSource = Enum.GetValues(typeof(EnumTransactionType)).Cast<EnumTransactionType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
            //cboTranType.SelectedIndex = 0;
        }
        private void RefreshValue()
        {
            txtPerName.Text = _ShareInvestment.Purpose;          
            numInvAmt.Value = _ShareInvestment.Amount;

            //if (_HeadType == EnumInvestmentType.FixedAsset || _HeadType == EnumInvestmentType.CurrentAsset)
            //{
            //    ctlFAssets.Visible = true;
            //    ctlCAsset.Visible = false;
            //    ctlLiability.Visible = false;
            //}
            //else if(_HeadType==EnumInvestmentType.Loan && _TranType==EnumTransactionType.Receive)
            //{
            //    ctlFAssets.Visible = false;
            //    ctlCAsset.Visible = true;
            //    ctlLiability.Visible = false;

            //}
            //else if (_HeadType == EnumInvestmentType.Loan && _TranType == EnumTransactionType.Pay)
            //{
            //    ctlFAssets.Visible = false;
            //    ctlCAsset.Visible = false;
            //    ctlLiability.Visible = true;

            //}

            if(_ParentID==EnumParentType.FixedAsset)
            {
                ctlFAssets.Visible = true;
                ctlCAsset.Visible = false;
                ctlLiability.Visible = false;
                ctlFAssets.SelectedID = _ShareInvestment.SIHID;

                //cboTranType.Enabled = false;
                
            }
            else if(_ParentID==EnumParentType.CurrentAsset)
            {
                ctlFAssets.Visible = false;
                ctlCAsset.Visible = true;
                ctlLiability.Visible = false;
                //cboTranType.Enabled = false;
                ctlCAsset.SelectedID = _ShareInvestment.SIHID;

            }
            else if(_ParentID==EnumParentType.Liability)
            {
                ctlFAssets.Visible = false;
                ctlCAsset.Visible = false;
                ctlLiability.Visible = true;
                //cboTranType.Enabled = true;
                ctlLiability.SelectedID = _ShareInvestment.SIHID;
            }

            if (_ShareInvestment.EntryDate != DateTime.MinValue)
                dtpDate.Value = _ShareInvestment.EntryDate;
            else
                dtpDate.Value = DateTime.Now;
            //cboTranType.SelectedValue = _ShareInvestment.TransactionType > 0 ? _ShareInvestment.TransactionType : 1;//_ShareInvestment.TransactionType;
        }
        private void RefreshObject()
        {
            if (_ShareInvestment.SIID == 0)
            {
                _ShareInvestment = new ShareInvestment();
                _ShareInvestment.CreatedBy = Global.CurrentUser.UserID;
                _ShareInvestment.CreateDate = DateTime.Now;
            }
            else
            {
                _ShareInvestment.ModifiedDate = (DateTime)DateTime.Today;
                _ShareInvestment.ModifiedBy = (int)Global.CurrentUser.UserID;
            }

            _ShareInvestment.Purpose = txtPerName.Text;           
            _ShareInvestment.Amount= numInvAmt.Value;
            _ShareInvestment.EntryDate = dtpDate.Value;

            //if (_HeadType == EnumInvestmentType.FixedAsset || _HeadType == EnumInvestmentType.CurrentAsset)
            //{
            //    _ShareInvestment.SIHID = (int)ctlFAssets.SelectedID;
            //    _ShareInvestment.TransactionType = (int)EnumTransactionType.Receive;
            //}
            //else if ((_HeadType == EnumInvestmentType.Loan || _HeadType == EnumInvestmentType.FromOwner || _HeadType == EnumInvestmentType.Others) && _TranType == EnumTransactionType.Receive)
            //{
            //    _ShareInvestment.SIHID = (int)ctlCAsset.SelectedID;
            //    _ShareInvestment.TransactionType = (int)EnumTransactionType.Receive;
            //}
            //else if ((_HeadType == EnumInvestmentType.Loan || _HeadType == EnumInvestmentType.FromOwner || _HeadType == EnumInvestmentType.Others) && _TranType == EnumTransactionType.Pay)
            //{
            //    _ShareInvestment.SIHID = (int)ctlLiability.SelectedID;
            //    _ShareInvestment.TransactionType = (int)EnumTransactionType.Pay;
            //}  

            if (_ParentID == EnumParentType.FixedAsset)
            {
                _ShareInvestment.SIHID = (int)ctlFAssets.SelectedID;
                _ShareInvestment.TransactionType = (int)EnumTransactionType.Receive;
            }
            else if (_ParentID == EnumParentType.CurrentAsset)
            {
                _ShareInvestment.SIHID = (int)ctlCAsset.SelectedID;
                _ShareInvestment.TransactionType = (int)EnumTransactionType.Receive;
            }
            else if (_ParentID == EnumParentType.Liability)
            {
                if(_TranType==EnumTransactionType.Pay)
                {
                    _ShareInvestment.SIHID = (int)ctlLiability.SelectedID;
                    _ShareInvestment.TransactionType = (int)EnumTransactionType.Pay;
                }
                else
                {
                    _ShareInvestment.SIHID = (int)ctlLiability.SelectedID;
                    _ShareInvestment.TransactionType = (int)EnumTransactionType.Receive;
                }

            }

            //_ShareInvestment.TransactionType = (int)cboTranType.SelectedValue;       

        }

        private bool IsValid()
        {
            if (_ParentID==EnumParentType.FixedAsset)
            {
                if (ctlFAssets.SelectedID == 0)
                {
                    MessageBox.Show("Please Select Asset Fixed Head.", "Fixed Asset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlFAssets.Focus();
                    return false;
                }
            }
            else if (_ParentID==EnumParentType.CurrentAsset)
            {
                if (ctlCAsset.SelectedID == 0)
                {
                    MessageBox.Show("Please Select Asset Fixed Head.", "Current Asset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlCAsset.Focus();
                    return false;
                }
            }
            //else if (_ParentID==4)
            //{
            //    if (ctlLiability.SelectedID == 0)
            //    {
            //        MessageBox.Show("Please Select Liability Head.", "Liability", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ctlLiability.Focus();
            //        return false;
            //    }
            //}

            return true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (!IsValid()) return;

                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_ShareInvestment.SIID <= 0)
                        {
                            RefreshObject();
                            _ShareInvestment.SIID = db.ShareInvestments.Count() > 0 ? db.ShareInvestments.Max(obj => obj.SIID) + 1 : 1;
                            db.ShareInvestments.Add(_ShareInvestment);
                        }
                        else
                        {
                            _ShareInvestment = db.ShareInvestments.FirstOrDefault(obj => obj.SIID == _ShareInvestment.SIID);
                            RefreshObject();
                        }

                        db.SaveChanges();
                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Do you want to create another Investment?", "Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                            _ShareInvestment = new ShareInvestment();
                            RefreshValue();

                        }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fInvestment_Load(object sender, EventArgs e)
        {
            
        }

        private void numInvAmt_Enter(object sender, EventArgs e)
        {
            numInvAmt.Select(0, numInvAmt.Text.Length);
        }

        private void btnNewLiabilityRec_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestmentHead frm = new fInvestmentHead();
                frm.ShowDlg(new ShareInvestmentHead(), true,2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlCAsset_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlLiability_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlFAssets_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
