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
    public partial class fSystemInformation : Form
    {
        private INVENTORY.DA.SystemInformation _SystemInformation = new DA.SystemInformation();
        public Action ItemChanged;
        ToolTip _toolTip;
        int nWarentyMonth = 3;

        public fSystemInformation()
        {
            InitializeComponent();
            _toolTip = new ToolTip();
        }

        private void fSystemInformation_Load(object sender, EventArgs e)
        {
            try
            {
                btnPhotoClearCus.Enabled = true;
                btnEmpPPClear.Enabled = true;
                //btnNIDClear.Enabled = true;
                btnSuppClear.Enabled = true;
                //btnSuppDocClear.Enabled = true;
                using (DEWSRMEntities db = new DEWSRMEntities())
                {


                   _SystemInformation = (from c in db.SystemInformations
                                         where c.SystemInfoID == 1
                                         select c).FirstOrDefault();

                   if (_SystemInformation != null)
                   {
                       RefreshValue();
                   }
                   else
                   {
                       _SystemInformation = new DA.SystemInformation();
                   }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnPhotoPathCus_Click(object sender, EventArgs e)
        {
            if (_SystemInformation!=null)
            {
                if (_SystemInformation.CustomerPhotoPath != "")
                {
                    dlgOpenFolderCPP.SelectedPath = _SystemInformation.CustomerPhotoPath;
                }
            }

            dlgOpenFolderCPP.ShowNewFolderButton = true;
            if (dlgOpenFolderCPP.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenFolderCPP.SelectedPath != "")
                {
                    btnPhotoClearCus.Enabled = true;
                    txtPhotoPathCus.Text = dlgOpenFolderCPP.SelectedPath + "\\";
                    _toolTip.SetToolTip(txtPhotoPathCus, txtPhotoPathCus.Text);
                }
            }

        }

        private void btnNIDPath_Click(object sender, EventArgs e)
        {
            if (_SystemInformation!=null)
            {
                if (_SystemInformation.CustomerNIDPatht != "")
                {
                    dlgOpenFolderCNP.SelectedPath = _SystemInformation.CustomerNIDPatht;
                }
            }

            dlgOpenFolderCNP.ShowNewFolderButton = true;
            if (dlgOpenFolderCNP.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenFolderCNP.SelectedPath != "")
                {
                    //btnNIDClear.Enabled = true;
                    //txtNIDPath.Text = dlgOpenFolderCNP.SelectedPath + "\\";
                    //_toolTip.SetToolTip(txtNIDPath, txtNIDPath.Text);
                }
            }

        }

        private void btnSuppPhoto_Click(object sender, EventArgs e)
        {
            if (_SystemInformation != null)
            {
                if (_SystemInformation.SupplierPhotoPath != "")
                {
                    dlgOpenFolderSPP.SelectedPath = _SystemInformation.SupplierPhotoPath;
                }
            }

            dlgOpenFolderSPP.ShowNewFolderButton = true;
            if (dlgOpenFolderSPP.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenFolderSPP.SelectedPath != "")
                {
                    btnSuppClear.Enabled = true;
                    txtSuppPhotoPath.Text = dlgOpenFolderSPP.SelectedPath + "\\";
                    _toolTip.SetToolTip(txtSuppPhotoPath, txtSuppPhotoPath.Text);
                }
            }

        }

        private void btnSuppDoc_Click(object sender, EventArgs e)
        {
            if (_SystemInformation != null)
            {
                if (_SystemInformation.SupplierDocPath != "")
                {
                    dlgOpenFolderSDP.SelectedPath = _SystemInformation.SupplierDocPath;
                }
            }
            dlgOpenFolderSDP.ShowNewFolderButton = true;
            if (dlgOpenFolderSDP.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenFolderSDP.SelectedPath != "")
                {
                    //btnSuppDoc.Enabled = true;
                    //txtSuppDocument.Text = dlgOpenFolderSDP.SelectedPath + "\\";
                    //_toolTip.SetToolTip(txtSuppDocument, txtSuppDocument.Text);
                }
            }

        }

        private void btnPhotoClearCus_Click(object sender, EventArgs e)
        {
            txtPhotoPathCus.Text = "";
        }

        private void btnNIDClear_Click(object sender, EventArgs e)
        {
            //txtNIDPath.Text = "";
        }

        private void btnSuppClear_Click(object sender, EventArgs e)
        {
            txtSuppPhotoPath.Text = "";
        }

        private void btnSuppDocClear_Click(object sender, EventArgs e)
        {
            //txtSuppDocument.Text = "";
        }

        private void RefreshObject()
        {
            _SystemInformation.Name = txtName.Text;
            _SystemInformation.Address = rtbCompAdd.Text;
            _SystemInformation.TelephoneNo= txtTelephone.Text;
            _SystemInformation.EmailAddress = txtEmail.Text;
            _SystemInformation.WebAddress = txtWebAdd.Text;
            _SystemInformation.CustomerPhotoPath = txtPhotoPathCus.Text;
            //_SystemInformation.CustomerNIDPatht = txtNIDPath.Text;
            _SystemInformation.SupplierPhotoPath = txtSuppPhotoPath.Text;
            //_SystemInformation.SupplierDocPath = txtSuppDocument.Text;
            _SystemInformation.SystemStartDate = dtpSysStartDate.Value;
            _SystemInformation.ProductPhotoPath = txtProPhotoPath.Text;
            _SystemInformation.EmployeePhotoPath = txtEmpPhoto.Text;

            #region Warenty Period Calculation
            //_SystemInformation.NoOfWarMonth = (int)numWP.Value;
            //_SystemInformation.FInstallmentDate = dtpFInstallment.Value;
            //_SystemInformation.SInstallmentDate = dtpSInstallment.Value;
            //_SystemInformation.TInstallmentDate = dtpTInstallment.Value;

            #endregion

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_SystemInformation.SystemInfoID <= 0)
                        {
                            RefreshObject();
                            _SystemInformation.SystemInfoID = db.SystemInformations.Count() > 0 ? db.SystemInformations.Max(obj => obj.SystemInfoID) + 1 : 1;
                            db.SystemInformations.Add(_SystemInformation);
                        }
                        else
                        {
                            _SystemInformation = db.SystemInformations.FirstOrDefault(obj => obj.SystemInfoID == _SystemInformation.SystemInfoID);
                            RefreshObject();
                        }

                        db.SaveChanges();
                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (MessageBox.Show("Do you want to create another Customer?", "Create Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        //{
                        //    if (ItemChanged != null)
                        //    {
                        //        ItemChanged();
                        //    }
                        //    this.Close();
                        //}
                        //else
                        //{
                        //    if (ItemChanged != null)
                        //    {
                        //        ItemChanged();
                        //    }
                        //    _SystemInformation = new INVENTORY.DA.SystemInformation();
                        //    RefreshValue();

                        //}
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

        private void RefreshValue()
        {
            txtName.Text=_SystemInformation.Name;
            rtbCompAdd.Text=_SystemInformation.Address;
            txtTelephone.Text=_SystemInformation.TelephoneNo;
            txtEmail.Text=_SystemInformation.EmailAddress;
            txtWebAdd.Text=_SystemInformation.WebAddress;
            txtPhotoPathCus.Text=_SystemInformation.CustomerPhotoPath;
            //txtNIDPath.Text=_SystemInformation.CustomerNIDPatht;
            txtSuppPhotoPath.Text=_SystemInformation.SupplierPhotoPath;
            //txtSuppDocument.Text=_SystemInformation.SupplierDocPath;
            dtpSysStartDate.Value=_SystemInformation.SystemStartDate.Value;
            txtProPhotoPath.Text = _SystemInformation.ProductPhotoPath;
            txtEmpPhoto.Text = _SystemInformation.EmployeePhotoPath;
            //dtpFInstallment.Value = _SystemInformation.FInstallmentDate != null ? (DateTime)_SystemInformation.FInstallmentDate : DateTime.Now;
            //dtpSInstallment.Value = _SystemInformation.SInstallmentDate != null ? (DateTime)_SystemInformation.SInstallmentDate : DateTime.Now;
            //dtpTInstallment.Value = _SystemInformation.TInstallmentDate != null ? (DateTime)_SystemInformation.TInstallmentDate : DateTime.Now;
            //numWP.Value = _SystemInformation.NoOfWarMonth;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProductPhoto_Click(object sender, EventArgs e)
        {
            if (_SystemInformation != null)
            {
                if (_SystemInformation.ProductPhotoPath != "")
                {
                    dlgOpenFolderProduct.SelectedPath = _SystemInformation.ProductPhotoPath;
                }
            }

            dlgOpenFolderProduct.ShowNewFolderButton = true;
            if (dlgOpenFolderProduct.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenFolderProduct.SelectedPath != "")
                {
                    btnProPhotoClear.Enabled = true;
                    txtProPhotoPath.Text = dlgOpenFolderProduct.SelectedPath + "\\";
                    _toolTip.SetToolTip(txtProPhotoPath, txtProPhotoPath.Text);
                }
            }

        }

        private void btnProPhotoClear_Click(object sender, EventArgs e)
        {
            txtProPhotoPath.Text = "";
        }

        private void btnEmpPhotoPath_Click(object sender, EventArgs e)
        {
            if (_SystemInformation != null)
            {
                if (_SystemInformation.EmployeePhotoPath != "")
                {
                    dlgOpenFolderEmp.SelectedPath = _SystemInformation.EmployeePhotoPath;
                }
            }

            dlgOpenFolderProduct.ShowNewFolderButton = true;
            if (dlgOpenFolderEmp.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenFolderEmp.SelectedPath != "")
                {
                    btnEmpPPClear.Enabled = true;
                    txtEmpPhoto.Text = dlgOpenFolderEmp.SelectedPath + "\\";
                    _toolTip.SetToolTip(txtEmpPhoto, txtEmpPhoto.Text);
                }
            }

        }

        private void btnEmpPPClear_Click(object sender, EventArgs e)
        {
            txtEmpPhoto.Text = "";
        }

        private void numWP_ValueChanged(object sender, EventArgs e)
        {
            //dtpFInstallment.Value = _SystemInformation.SystemStartDate.Value.AddMonths((int)numWP.Value+1);
            //dtpSInstallment.Value= dtpFInstallment.Value.AddMonths(5);
            //dtpTInstallment.Value = dtpSInstallment.Value.AddMonths(6);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
