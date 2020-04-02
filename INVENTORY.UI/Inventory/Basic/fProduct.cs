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
using System.IO;

namespace INVENTORY.UI
{
    public partial class fProduct : Form
    {
        bool ForNewCompany = false;
        bool ForNewCategory = false;
        bool ForNewModel = false;

        private Product _Product = null;
        public Action ItemChanged;
        private INVENTORY.DA.SystemInformation _SystemInformation = null;
        bool _IsNew = false;
        DEWSRMEntities db = null;

        public fProduct()
        {
            InitializeComponent();
        }
        public void ShowDlg(Product oProduct, bool IsNew)
        {
            _IsNew = IsNew;
            _Product = oProduct;
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var _SysInfos = db.SystemInformations;

                _SystemInformation = (from c in db.SystemInformations
                                      where c.SystemInfoID == 1
                                      select c).FirstOrDefault();

            }


            if (!_IsNew)
                cboProType.Enabled = false;

            PopulateUnitTypeCbo();
            PopulateProTypeCbo();
            PopulateTaxCbo();
            RefreshWarrantyType();
            RefreshValue();
            this.ShowDialog();
        }
        private void RefreshWarrantyType()
        {
            cboCompressor.DisplayMember = "Name";
            cboCompressor.ValueMember = "ID";
            cboCompressor.DataSource = Enum.GetValues(typeof(EnumWarrantyType)).Cast<EnumWarrantyType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

            cboMotor.DisplayMember = "Name";
            cboMotor.ValueMember = "ID";
            cboMotor.DataSource = Enum.GetValues(typeof(EnumWarrantyType)).Cast<EnumWarrantyType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();


            cboPanel.DisplayMember = "Name";
            cboPanel.ValueMember = "ID";
            cboPanel.DataSource = Enum.GetValues(typeof(EnumWarrantyType)).Cast<EnumWarrantyType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

            cboService.DisplayMember = "Name";
            cboService.ValueMember = "ID";
            cboService.DataSource = Enum.GetValues(typeof(EnumWarrantyType)).Cast<EnumWarrantyType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

            cboSpareparts.DisplayMember = "Name";
            cboSpareparts.ValueMember = "ID";
            cboSpareparts.DataSource = Enum.GetValues(typeof(EnumWarrantyType)).Cast<EnumWarrantyType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        }
        private void RefreshValue()
        {
            txtCode.Text = _Product.Code;
            txtName.Text = _Product.ProductName;
            ctlBrand.SelectedID = _Product.CompanyID;
            ctlCategory.SelectedID = _Product.CategoryID;
            ctlModel.SelectedID = 1;
            cboUnitType.SelectedValue = _Product.UnitType > 0 ? _Product.UnitType : 1;
            cboProType.SelectedValue = _Product.ProductType > 0 ? _Product.ProductType : 3;
            numMinQTY.Value = _Product.ShortQty;

            numGSTPerc.Value = _Product.GSTPerc;
            numCGSTPerc.Value = _Product.CGSTPerc;
            numSGSTPerc.Value = _Product.SGSTPerc;
            numIGSTPerc.Value = _Product.IGSTPerc;

            numMaxQty.Value = _Product.MaxQty;
            EnumTax enuumTax = (EnumTax)Convert.ToInt32(_Product.Tax);
            cboTax.SelectedValue = (int)enuumTax;
            txtBarcode.Text = _Product.BarCode;
            numCostPrice.Value = _Product.CostPrice;
            numRetailPrice.Value = _Product.RetailPrice;
            numstock.Value = _Product.BoxQty;
            chkQuickMenu.Checked = _Product.quickmanu == null ? false : _Product.quickmanu.Value;
            chklabelprint.Checked = _Product.labelprint == null ? false : _Product.labelprint.Value;

            //if (!string.IsNullOrEmpty(_Product.CompressorWarrenty))
            //{
            //    numCompressor.Value = Convert.ToDecimal(_Product.CompressorWarrenty.Split(' ')[0]);
            //    cboCompressor.SelectedValue = (int)((EnumWarrantyType)Enum.Parse(typeof(EnumWarrantyType), _Product.CompressorWarrenty.Split(' ')[1]));
            //}

            //if (!string.IsNullOrEmpty(_Product.MotorWarrenty))
            //{
            //    numMotor.Value = Convert.ToDecimal(_Product.MotorWarrenty.Split(' ')[0]);
            //    cboMotor.SelectedValue = (int)((EnumWarrantyType)Enum.Parse(typeof(EnumWarrantyType), _Product.MotorWarrenty.Split(' ')[1]));
            //}

            //if (!string.IsNullOrEmpty(_Product.PanelWarrenty))
            //{
            //    numPanel.Value = Convert.ToDecimal(_Product.PanelWarrenty.Split(' ')[0]);
            //    cboPanel.SelectedValue = (int)((EnumWarrantyType)Enum.Parse(typeof(EnumWarrantyType), _Product.PanelWarrenty.Split(' ')[1]));
            //}

            //if (!string.IsNullOrEmpty(_Product.ServiceWarrenty))
            //{
            //    numService.Value = Convert.ToDecimal(_Product.ServiceWarrenty.Split(' ')[0]);
            //    cboService.SelectedValue = (int)((EnumWarrantyType)Enum.Parse(typeof(EnumWarrantyType), _Product.ServiceWarrenty.Split(' ')[1]));
            //}

            //if (!string.IsNullOrEmpty(_Product.SparePartsWarrenty))
            //{
            //    numSpareparts.Value = Convert.ToDecimal(_Product.SparePartsWarrenty.Split(' ')[0]);
            //    cboSpareparts.SelectedValue = (int)((EnumWarrantyType)Enum.Parse(typeof(EnumWarrantyType), _Product.SparePartsWarrenty.Split(' ')[1]));
            //}
            //if (_Product.BoxQty != default(decimal))
            //    numBQty.Value = (decimal)_Product.BoxQty;
            //else
            //    numBQty.Value = 0;

            if (_Product.PhotoPath != null && _SystemInformation != null)
            {
                string path = _SystemInformation.ProductPhotoPath + "\\" + _Product.PhotoPath;
                if (File.Exists(path))
                {

                    pbxEmpPic.ImageLocation = _SystemInformation.ProductPhotoPath + "//" + _Product.PhotoPath;
                }
                else
                {
                    MessageBox.Show("Error Loading Product Picture" + Environment.NewLine + "Picture Not Found");
                }
            }
        }

        private void PopulateUnitTypeCbo()
        {
            cboUnitType.DisplayMember = "Name";
            cboUnitType.ValueMember = "ID";
            cboUnitType.DataSource = Enum.GetValues(typeof(EnumUnitType)).Cast<EnumUnitType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        }

        private void PopulateProTypeCbo()
        {
            cboProType.DisplayMember = "Name";
            cboProType.ValueMember = "ID";
            cboProType.DataSource = Enum.GetValues(typeof(EnumProductType)).Cast<EnumProductType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        }

        private void PopulateTaxCbo()
        {
            cboTax.DisplayMember = "Name";
            cboTax.ValueMember = "ID";
            cboTax.DataSource = Enum.GetValues(typeof(EnumTax)).Cast<EnumTax>().Select(x => new { ID = (int)x, Name = Convert.ToInt32(x).ToString() }).ToList();
        }

        private void RefreshObject()
        {

            _Product.Code = txtCode.Text;
            _Product.ProductName = txtName.Text.Trim();
            _Product.CompanyID = ctlBrand.SelectedID;
            _Product.CategoryID = ctlCategory.SelectedID;
            _Product.ModelID = ctlModel.SelectedID;
            //  _Product.SalesRate =0; 
            //  _Product.PurchaseRate = 0;
            _Product.UnitType = (int)cboUnitType.SelectedValue;
            _Product.ShortQty = numMinQTY.Value;
            _Product.ProductType = (int)cboProType.SelectedValue;
            _Product.CompressorWarrenty = numCompressor.Value > 0 ? numCompressor.Value + " " + ((EnumWarrantyType)cboCompressor.SelectedValue).ToString() : string.Empty;
            _Product.MotorWarrenty = numMotor.Value > 0 ? numMotor.Value + " " + ((EnumWarrantyType)cboMotor.SelectedValue).ToString() : string.Empty;
            _Product.PanelWarrenty = numPanel.Value > 0 ? numPanel.Value + " " + ((EnumWarrantyType)cboPanel.SelectedValue).ToString() : string.Empty;
            _Product.ServiceWarrenty = numService.Value > 0 ? numService.Value + " " + ((EnumWarrantyType)cboService.SelectedValue).ToString() : string.Empty;
            _Product.SparePartsWarrenty = numSpareparts.Value > 0 ? numSpareparts.Value + " " + ((EnumWarrantyType)cboSpareparts.SelectedValue).ToString() : string.Empty;

            _Product.GSTPerc = numGSTPerc.Value;
            _Product.CGSTPerc = numCGSTPerc.Value;
            _Product.SGSTPerc = numSGSTPerc.Value;
            _Product.IGSTPerc = numIGSTPerc.Value;

            _Product.MaxQty = numMaxQty.Value;
            _Product.Tax = (int)cboTax.SelectedValue;

            _Product.BarCode = txtBarcode.Text;
            _Product.CostPrice = numCostPrice.Value;
            _Product.RetailPrice = numRetailPrice.Value;
            _Product.quickmanu = chkQuickMenu.Checked;
            _Product.BoxQty = numstock.Value;
            _Product.labelprint = chklabelprint.Checked;

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                Product _ProductTemp = db.Products.FirstOrDefault(p => p.ProductID == _Product.ProductID);
                if (_ProductTemp != null && _ProductTemp.RetailPrice != _Product.RetailPrice)
                {
                    _Product.labelprint = false;
                }
            }
            #region Product Picture

            if ((pbxEmpPic.ImageLocation != string.Empty) && (pbxEmpPic.ImageLocation != null))
            {
                if (_Product.PhotoPath == null)
                {
                    _Product.PhotoPath = _SystemInformation.ProductPhotoPath;
                }

                if ((_Product.PhotoPath.Trim()).ToUpper() != new FileInfo(pbxEmpPic.ImageLocation).Name.Trim().ToUpper())
                {
                    FileInfo fInfo = new FileInfo(pbxEmpPic.ImageLocation.Trim());
                    string photoName = txtCode.Text + fInfo.Extension;
                    _Product.PhotoPath = _SystemInformation.ProductPhotoPath;

                    if (fInfo.Exists == false)
                    {
                        MessageBox.Show("Picture does not exist", "Product Picture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_Product.PhotoPath == "")
                    {
                        MessageBox.Show("Product's Picture will not be saved. because it's path is not defined.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(_SystemInformation.ProductPhotoPath))
                            Directory.CreateDirectory(_SystemInformation.ProductPhotoPath);

                        if (new FileInfo(_SystemInformation.ProductPhotoPath + photoName).Exists)
                        {
                            if (MessageBox.Show("A picture named " + photoName + " already exists. Do you want to replace it?", "Product Picture", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                FileInfo info = new FileInfo(_SystemInformation.ProductPhotoPath + photoName);
                                if (info.IsReadOnly)
                                    info.IsReadOnly = false;
                                File.Copy(pbxEmpPic.ImageLocation.Trim(), _SystemInformation.ProductPhotoPath + "\\" + photoName, true);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            File.Copy(pbxEmpPic.ImageLocation.Trim(), _SystemInformation.ProductPhotoPath + photoName, true);
                        }

                        new FileInfo(_SystemInformation.ProductPhotoPath + photoName).IsReadOnly = true;
                        _Product.PhotoPath = photoName;
                    }
                }
            }
            else
            {
                _Product.PhotoPath = string.Empty;
            }
            #endregion



        }

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Product Name.", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            if (ctlBrand.SelectedID == 0)
            {
                MessageBox.Show("Please Enter Company Name.", "Company Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlBrand.Focus();
                return false;
            }
            if (ctlCategory.SelectedID == 0)
            {
                MessageBox.Show("Please Enter Category Name.", "Category Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlBrand.Focus();
                return false;
            }
            if (ctlModel.SelectedID == 0)
            {
                MessageBox.Show("Please Enter Size/Color Name.", "Model Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlModel.Focus();
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
                    if (_Product.ProductID <= 0)
                    {
                        _Product.ProductID = db.Products.Count() > 0 ? db.Products.Max(obj => obj.ProductID) + 1 : 1;
                        RefreshObject();

                        if (txtName.Text.Length > 0)
                        {
                            Product oProductInfo = null;
                            oProductInfo = (Product)db.Products.FirstOrDefault(o => o.ProductName.Trim().ToUpper() == txtName.Text.Trim().ToUpper() && (o.CompanyID == _Product.CompanyID) && (o.CategoryID == _Product.CategoryID) && (o.ModelID == _Product.ModelID) && (o.UnitType == _Product.UnitType));

                            if (oProductInfo != null)
                            {
                                MessageBox.Show("This product already exists", "Duplicate Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtName.Focus();
                                return;
                            }
                        }

                        db.Products.Add(_Product);
                        IsNew = true;
                    }
                    else
                    {
                        _Product = db.Products.FirstOrDefault(obj => obj.ProductID == _Product.ProductID);
                        RefreshObject();
                    }

                    db.SaveChanges();
                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ItemChanged != null)
                    {
                        ItemChanged();
                    }

                    if (!IsNew)
                    {
                        this.Close();
                    }
                    else
                    {
                        _Product = new Product();
                        //RefreshValue();
                        txtCode.Text = GenerateProductCode();
                        //pbxEmpPic.Image = null;
                        txtName.Text = "";
                        numMinQTY.Value = 0;
                        numBQty.Value = 0;

                        RefreshControl();
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

        private void RefreshControl()
        {
            cboMotor.SelectedIndex = 0;
            cboPanel.SelectedIndex = 0;
            cboService.SelectedIndex = 0;
            cboSpareparts.SelectedIndex = 0;
            cboCompressor.SelectedIndex = 0;

            numSpareparts.Value = 0;
            numMotor.Value = 0;
            numPanel.Value = 0;
            numService.Value = 0;
            numCompressor.Value = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GenerateProductCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var maxValue = (dynamic)null;
                if (db.Products.ToList().Count > 0)
                {
                    //maxValue = db.Products.Max(x => x.ProductID);
                    maxValue = db.Products.Count();
                    if (maxValue != null)
                        i = (int)maxValue;
                }
                else
                {
                    i = 0;
                }

                if (i >= 0)
                {
                    if (i.ToString().Length == 1)
                    {
                        sCode = "00000" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 2)
                    {
                        sCode = "0000" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 3)
                    {
                        sCode = "000" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 4)
                    {
                        sCode = "00" + Convert.ToString(i + 1);
                    }
                    else if (i.ToString().Length == 5)
                    {
                        sCode = "0" + Convert.ToString(i + 1);
                    }
                    else
                    {
                        sCode = "0" + Convert.ToString(i + 1);
                    }
                }
            }
            return sCode;
        }
        private void fProduct_Load(object sender, EventArgs e)
        {
            if (_IsNew)
                txtCode.Text = GenerateProductCode();
        }

        private void ctlBrand_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlCategory_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void ctlModel_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            ForNewCompany = true;
            fCompany frm = new fCompany();
            frm.ShowDlg(new Company(), true);

            if (ForNewCompany)
            {
                db = new DEWSRMEntities();
                List<Company> oComList = db.Companies.ToList();
                ctlBrand.SelectedID = oComList[oComList.Count - 1].CompanyID;
                ForNewCompany = false;
            }


        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ForNewCategory = true;
            fCategory frm = new fCategory();
            frm.ShowDlg(new Category(), true);

            if (ForNewCategory)
            {
                db = new DEWSRMEntities();
                List<Category> oCatList = db.Categorys.ToList();
                ctlCategory.SelectedID = oCatList[oCatList.Count - 1].CategoryID;
                ForNewCategory = false;
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            ForNewModel = true;
            fModel frm = new fModel();
            frm.ShowDlg(new Model(), true);

            if (ForNewModel)
            {
                db = new DEWSRMEntities();
                List<Model> oModList = db.Models.ToList();
                ctlModel.SelectedID = oModList[oModList.Count - 1].ModelID;
                ForNewModel = false;
            }


        }

        private void cboUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboUnitType.SelectedValue == 1)
                numBQty.Enabled = false;
            else
                numBQty.Enabled = true;
        }

        private void numShortQTY_Enter(object sender, EventArgs e)
        {
            numMinQTY.Select(0, numMinQTY.Text.Length);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkIsBangla_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                odPicture.FileName = "";
                odPicture.ShowDialog();
                if (odPicture.FileName != "")
                {
                    pbxEmpPic.ImageLocation = odPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
