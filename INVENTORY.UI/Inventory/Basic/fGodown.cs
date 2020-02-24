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
    public partial class fGodown : Form
    {
        private Godown _Godown = null;
        public Action ItemChanged;
        bool _IsNew = false;

        public fGodown()
        {
            InitializeComponent();
        }

        public void ShowDlg(Godown oGodown, bool IsNew)
        {
            _IsNew = IsNew;
            _Godown = oGodown;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtCode.Text = _Godown.GodownCode;
            txtName.Text = _Godown.GodownName;
            txtAddress.Text = _Godown.Address;
        }

        private void RefreshObject()
        {
            _Godown.GodownCode = txtCode.Text;
            _Godown.GodownName = txtName.Text;
            _Godown.Address = txtAddress.Text;
        }

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Godown Name.", "Godown", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) return;
                bool isNew = false;
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    if (_Godown.GodownID <= 0)
                    {
                        #region Validaton Check
                        if (txtName.Text.Length > 0)
                        {
                            Godown oGodown = (Godown)(db.Godowns.FirstOrDefault(o => o.GodownName.Trim().ToUpper() == txtName.Text.Trim().ToUpper()));
                            if (oGodown != null)
                            {
                                MessageBox.Show("This Godown already exists.", "Duplicate Godown.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtName.Focus();
                                return;
                            }
                        }
                        #endregion

                        RefreshObject();
                        _Godown.GodownID = db.Godowns.Count() > 0 ? db.Godowns.Max(obj => obj.GodownID) + 1 : 1;
                        db.Godowns.Add(_Godown);
                        isNew = true;
                    }
                    else
                    {
                        _Godown = db.Godowns.FirstOrDefault(obj => obj.GodownID == _Godown.GodownID);
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
                        _Godown = new Godown();
                        RefreshValue();
                        txtCode.Text = GenerateCode();
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

        private string GenerateCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                i = db.Godowns.Count();

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(db.Godowns.Count() + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(db.Godowns.Count() + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(db.Godowns.Count() + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(db.Godowns.Count() + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(db.Godowns.Count() + 1);
                }
            }
            return sCode;
        }
        private void fGodown_Load(object sender, EventArgs e)
        {
            if (_IsNew)
                txtCode.Text = GenerateCode();

        }
    }
}
