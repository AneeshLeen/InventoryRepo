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
    public partial class fInvestmentHead : Form
    {
        private ShareInvestmentHead _ShareInvestmentHead = null;
        public Action ItemChanged;
        bool _IsNew = false;
        int _ParentId;
        public fInvestmentHead()
        {
            InitializeComponent();
        }

        public void ShowDlg(ShareInvestmentHead oShareInvestmentHead, bool IsNew,int nParaentID)
        {
            _IsNew = IsNew;
            _ShareInvestmentHead = oShareInvestmentHead;
            //PopulateInvTypeCbo();
            _ParentId = nParaentID;
            RefreshValue();
            this.ShowDialog();
        }

        //private void PopulateInvTypeCbo()
        //{
        //    cboInvestType.DisplayMember = "Name";
        //    cboInvestType.ValueMember = "ID";
        //    cboInvestType.DataSource = Enum.GetValues(typeof(EnumInvestmentType)).Cast<EnumInvestmentType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        //}

        private void RefreshValue()
        {
            txtCode.Text = _ShareInvestmentHead.Code;
            txtName.Text = _ShareInvestmentHead.Name;
            //cboInvestType.SelectedValue = _ShareInvestmentHead.Type;


        }

        private void RefreshObject()
        {
            _ShareInvestmentHead.Code = txtCode.Text;
            _ShareInvestmentHead.Name = txtName.Text;
            //_ShareInvestmentHead.Type = (int)cboInvestType.SelectedValue;    
            _ShareInvestmentHead.ParentId = _ParentId;
        }
        private string GenerateInvestCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;

                if (db.ShareInvestmentHeads.Where(inv=>inv.ParentId==_ParentId).ToList().Count> 0)
                {
                    maxValue = db.ShareInvestmentHeads.Where(inv => inv.ParentId == _ParentId).Count();
                    if (maxValue != null)
                        i = (int)maxValue;
                }
                else
                {
                    i = 0;
                }

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(i + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(i + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(i + 1);
                }
            }
            return sCode;
        }
        private void fInvestmentHead_Load(object sender, EventArgs e)
        {
            if (_IsNew)
                txtCode.Text = GenerateInvestCode();
        }

        private bool IsValid()
        {

            //if (cboInvestType.SelectedItem == null)
            //{
            //    MessageBox.Show("Please select Investment Type.", "Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cboInvestType.Focus();
            //    return false;
            //}

            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Investment Item.", "Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                bool isNew = false;
                if (!IsValid()) return;
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    if (_ShareInvestmentHead.SIHID <= 0)
                    {
                        #region Validation Check
                        if (txtName.Text.Length > 0)
                        {
                            ShareInvestmentHead oShareInvestmentHead = (ShareInvestmentHead)(db.ShareInvestmentHeads.FirstOrDefault(o => o.Name.Trim().ToUpper() == txtName.Text.Trim().ToUpper()));
                            if (oShareInvestmentHead != null)
                            {
                                MessageBox.Show("Investment name already Exists.", "Duplicate Invest Item.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtName.Focus();
                                return;
                            }
                        }

                        #endregion

                        RefreshObject();
                        _ShareInvestmentHead.SIHID = db.ShareInvestmentHeads.Count() > 0 ? db.ShareInvestmentHeads.Max(obj => obj.SIHID) + 1 : 1;
                        db.ShareInvestmentHeads.Add(_ShareInvestmentHead);
                        isNew = true;
                    }
                    else
                    {
                        _ShareInvestmentHead = db.ShareInvestmentHeads.FirstOrDefault(obj => obj.SIHID== _ShareInvestmentHead.SIHID);
                        RefreshObject();
                    }

                    db.SaveChanges();
                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!isNew)
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
                        _ShareInvestmentHead = new ShareInvestmentHead();
                        RefreshValue();
                        txtCode.Text = GenerateInvestCode();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboInvestType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
