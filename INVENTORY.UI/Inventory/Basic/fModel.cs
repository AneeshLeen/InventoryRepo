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
    public partial class fModel : Form
    {
        private Model _Model = null;
        public Action ItemChanged;
        bool _IsNew = false;

        public fModel()
        {
            InitializeComponent();
        }

        public void ShowDlg(Model oModel, bool IsNew)
        {
            _IsNew = IsNew;
            _Model = oModel;
            RefreshValue();
            this.ShowDialog();
        }


        private void RefreshValue()
        {
            txtCode.Text = _Model.Code;
            txtName.Text = _Model.Description;
        }

        private void RefreshObject()
        {
            _Model.Code = txtCode.Text;
            _Model.Description = txtName.Text;
        }


        private string GenerateModelCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Models.ToList().Count > 0)
                {
                    maxValue = db.Models.Max(x => x.ModelID);
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

        private void fModel_Load(object sender, EventArgs e)
        {
            
            if (_IsNew)
                txtCode.Text = GenerateModelCode();

        }


        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Model Name.", "Model", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool IsNew = false;

                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    if (_Model.ModelID <= 0)
                    {
                        if (txtName.Text.Length > 0)
                        {
                            Model oModel = (Model)(db.Models.FirstOrDefault(o => o.Description.Trim().ToUpper() == txtName.Text.Trim().ToUpper())); ;
                            if (oModel != null)
                            {
                                MessageBox.Show("This Model already Exists.", "Duplicate Model", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtName.Focus();
                                return;
                            }
                        }

                        RefreshObject();
                        _Model.ModelID = db.Models.Count() > 0 ? db.Models.Max(obj => obj.ModelID) + 1 : 1;
                        db.Models.Add(_Model);

                        IsNew = true;
                    }
                    else
                    {
                        _Model = db.Models.FirstOrDefault(obj => obj.ModelID == _Model.ModelID);
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
                        _Model = new Model();
                        RefreshValue();
                        txtCode.Text = GenerateModelCode();
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

        private void chkIsBangla_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
