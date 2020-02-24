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
    public partial class fColorInfo : Form
    {

        private INVENTORY.DA.Color _ColorInfo = null;
        public Action ItemChanged;
        bool _IsNew = false;

        public fColorInfo()
        {
            InitializeComponent();
        }

        public void ShowDlg(INVENTORY.DA.Color oColInfo, bool IsNew)
        {
            _IsNew = IsNew;
            _ColorInfo = oColInfo;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtCode.Text = _ColorInfo.Code;
            txtDescription.Text = _ColorInfo.Description;
        }

        private bool IsValid()
        {
            if (txtDescription.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Color Code.", "Color", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return false;
            }
            return true;
        }

        private void RefreshObject()
        {
            _ColorInfo.Code = txtCode.Text;
            _ColorInfo.Description = txtDescription.Text;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (!IsValid()) return;
                bool IsNew = false;
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    if (_ColorInfo.ColorID <= 0)
                    {
                        if (txtDescription.Text.Length > 0)
                        {
                            INVENTORY.DA.Color oColorInfo = null;
                            oColorInfo = (INVENTORY.DA.Color)db.Colors.FirstOrDefault(o => o.Description.Trim().ToUpper() == txtDescription.Text.Trim().ToUpper());

                            if (oColorInfo != null)
                            {
                                MessageBox.Show("This Color already Exists.", "Duplicate Color", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDescription.Focus();
                                return;
                            }
                        }


                        RefreshObject();
                        _ColorInfo.ColorID = db.Colors.Count() > 0 ? db.Colors.Max(obj => obj.ColorID) + 1 : 1;
                        db.Colors.Add(_ColorInfo);
                        IsNew = true;
                    }
                    else
                    {
                        _ColorInfo = db.Colors.FirstOrDefault(obj => obj.ColorID == _ColorInfo.ColorID);
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
                        _ColorInfo = new INVENTORY.DA.Color();
                        RefreshValue();
                        txtCode.Text = GenerateColorCode();
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

        private string GenerateColorCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Colors.ToList().Count > 0)
                {
                    maxValue = db.Colors.Max(x => x.ColorID);
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
        private void fColorInfo_Load(object sender, EventArgs e)
        {

            if (_IsNew)
                txtCode.Text = GenerateColorCode();

        }
    }
}
