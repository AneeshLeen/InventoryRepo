using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using INVENTORY.DA;

namespace INVENTORY.UI
{
    public partial class fSupplier : Form
    {
        private Supplier _Supplier = null;
        public Action ItemChanged;
        private INVENTORY.DA.SystemInformation _SystemInformation = null;
        DEWSRMEntities db = null;
        bool _IsNew = false;
        public fSupplier()
        {
            InitializeComponent();
        }

        public void ShowDlg(Supplier oSupplier,bool IsNew)
        {
            _IsNew = IsNew;
             db = new DEWSRMEntities();
            var _SysInfos = db.SystemInformations;

            _SystemInformation = (from c in db.SystemInformations
                                  where c.SystemInfoID == 1
                                  select c).FirstOrDefault();

            _Supplier = oSupplier;
            RefreshValue();
            if (!_IsNew)
            {
                numOpeningDue.Enabled = false;
                numPrvDue.Enabled = false;
            }
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtSupplierCode.Text = _Supplier.Code;
            txtSuppName.Text=_Supplier.Name;
            txtOwnerName.Text=_Supplier.OwnerName;
            txtContactNo.Text=_Supplier.ContactNo;
            txtEngAddress.Text=_Supplier.Address;
            numPrvDue.Value = _Supplier.TotalDue;
            numOpeningDue.Value = _Supplier.OpeningDue;

            if (_Supplier.PhotoPath != null)
            {
                string path = _SystemInformation.SupplierPhotoPath + "\\" + _Supplier.PhotoPath;
                if (File.Exists(path))
                {
                    pbxProPic.ImageLocation = _SystemInformation.SupplierPhotoPath + "//" + _Supplier.PhotoPath;
                }
                else
                {
                    MessageBox.Show("Error Loading Supplier Picture" + Environment.NewLine + "Picture Not Found");
                }
            }           
        }

        private string GenerateSupCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                i = db.Suppliers.Count();

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(db.Suppliers.Count() + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(db.Suppliers.Count() + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(db.Suppliers.Count() + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(db.Suppliers.Count() + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(db.Suppliers.Count() + 1);
                }
            }
            return sCode;
        }

        private void fSupplier_Load(object sender, EventArgs e)
        {
            if(_IsNew)
              txtSupplierCode.Text = GenerateSupCode();
        }

        private void RefreshObject()
        {
            _Supplier.Code = txtSupplierCode.Text;
            _Supplier.OwnerName = txtOwnerName.Text;

            if (txtSuppName.Text == "")
                _Supplier.Name = txtOwnerName.Text;
            else
                _Supplier.Name = txtSuppName.Text; //Company Name for Specific Supplier


            _Supplier.Address = txtEngAddress.Text;
            _Supplier.ContactNo = txtContactNo.Text;
            _Supplier.TotalDue = numPrvDue.Value;
            _Supplier.OpeningDue = numOpeningDue.Value;

            #region Supplier Picture

            if ((pbxProPic.ImageLocation != string.Empty) && (pbxProPic.ImageLocation != null))
            {
                if (_Supplier.PhotoPath == null)
                {
                    _Supplier.PhotoPath = _SystemInformation.SupplierPhotoPath;
                }

                if ((_Supplier.PhotoPath.Trim()).ToUpper() != new FileInfo(pbxProPic.ImageLocation).Name.Trim().ToUpper())
                {
                    FileInfo fInfo = new FileInfo(pbxProPic.ImageLocation.Trim());
                    string photoName = txtSupplierCode.Text + fInfo.Extension;
                    _Supplier.PhotoPath = _SystemInformation.SupplierPhotoPath;


                    if (fInfo.Exists == false)
                    {
                        MessageBox.Show("Picture does not exist", "Supplier Picture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_Supplier.PhotoPath == "")
                    {
                        MessageBox.Show("Supplier's Picture will not be saved. because it's path is not defined.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(_SystemInformation.SupplierPhotoPath))
                            Directory.CreateDirectory(_SystemInformation.SupplierPhotoPath);

                        if (new FileInfo(_SystemInformation.SupplierPhotoPath + photoName).Exists)
                        {
                            if (MessageBox.Show("A picture named " + photoName + " already exists. Do you want to replace it?", "Supplier Picture", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                FileInfo info = new FileInfo(_SystemInformation.SupplierPhotoPath + photoName);
                                if (info.IsReadOnly)
                                    info.IsReadOnly = false;
                                File.Copy(pbxProPic.ImageLocation.Trim(), _SystemInformation.SupplierPhotoPath + "\\" + photoName, true);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            File.Copy(pbxProPic.ImageLocation.Trim(), _SystemInformation.SupplierPhotoPath + photoName, true);
                        }

                        new FileInfo(_SystemInformation.SupplierPhotoPath + photoName).IsReadOnly = true;
                        _Supplier.PhotoPath = photoName;
                    }
                }
            }
            else
            {
                _Supplier.PhotoPath = string.Empty;
            }
            #endregion
            
        }

        private bool IsValid()
        {
            if (txtOwnerName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Supplier Name.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOwnerName.Focus();
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
                if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_Supplier.SupplierID <= 0)
                        {
                            RefreshObject();
                            _Supplier.SupplierID = db.Suppliers.Count() > 0 ? db.Suppliers.Max(obj => obj.SupplierID) + 1 : 1;
                            db.Suppliers.Add(_Supplier);
                            IsNew = true;
                        }
                        else
                        {
                            _Supplier = db.Suppliers.FirstOrDefault(obj => obj.SupplierID == _Supplier.SupplierID);
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
                            if (MessageBox.Show("Do you want to create another Supplier?", "Create Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                                _Supplier = new Supplier();
                                RefreshValue();
                                txtSupplierCode.Text = GenerateSupCode();
                            }
                        }
                        
                    }
                }

            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                odPicture.FileName = "";
                odPicture.ShowDialog();
                if (odPicture.FileName != "")
                {
                    pbxProPic.ImageLocation = odPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numPrvDue_Enter(object sender, EventArgs e)
        {
            numPrvDue.Select(0, numPrvDue.Text.Length);
        }

        private void numOpeningDue_Enter(object sender, EventArgs e)
        {
            numOpeningDue.Select(0, numOpeningDue.Text.Length);
        }

        private void numOpeningDue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_IsNew)
                numPrvDue.Value = numOpeningDue.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
