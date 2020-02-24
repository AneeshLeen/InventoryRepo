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
    public partial class fCustomer : Form
    {
       
        private Customer _Customer = null;
        public Action ItemChanged;
        private INVENTORY.DA.SystemInformation _SystemInformation = null;
        bool _IsNew = false;
        public fCustomer()
        {
            InitializeComponent();
        }
        public void ShowDlg(Customer oCustomer,bool IsNew)
        {
            _IsNew = IsNew;
            _Customer = oCustomer;
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                var _SysInfos = db.SystemInformations;

                _SystemInformation = (from c in db.SystemInformations
                                      where c.SystemInfoID == 1
                                      select c).FirstOrDefault();
                                      
            }
            PopulateCusTypeCbo();
            RefreshValue();
            if (!_IsNew)
            {
                numOpeningDue.Enabled = false;
                numPrevDue.Enabled = false;
            }
            this.ShowDialog();
        }

        private void PopulateCusTypeCbo()
        {
            cboCusType.DisplayMember = "Name";
            cboCusType.ValueMember = "ID";
            cboCusType.DataSource = Enum.GetValues(typeof(EnumCustomerType)).Cast<EnumCustomerType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        }

        private void RefreshValue()
        {
            PopulateCusTypeCbo();
            txtCode.Text = _Customer.Code;
            txtName.Text = _Customer.Name;
            txtFName.Text = _Customer.FName;
            txtCompany.Text = _Customer.CompanyName;
            txtCode.Text= _Customer.Code;
            txtName.Text=_Customer.Name;
            txtEmail.Text=_Customer.EmailID;
            txtMobile.Text=_Customer.ContactNo;
            txtAddress.Text=_Customer.Address;
            txtNIDNo.Text=_Customer.NID;
            numPrevDue.Value = _Customer.TotalDue != null ? (decimal)_Customer.TotalDue : 0;

            txtRefName.Text = _Customer.RefName;
            txtRefContact.Text = _Customer.RefContact;
            txtRefFather.Text = _Customer.RefFName;
            txtRefAddress.Text = _Customer.RefAddress;
            numOpeningDue.Value = _Customer.OpeningDue;
            cboCusType.SelectedValue = _Customer.CustomerType != 0 ? _Customer.CustomerType : 1;


            if(numOpeningDue.Value>0)
            {
                numOpeningDue.Enabled = false;
            }

            //txtDistrict.Text = _Customer.Dist;
            //txtThana.Text = _Customer.Thana;
            //txtPost.Text = _Customer.Post;
            //txtVillage.Text = _Customer.Village;

           if (_Customer.PhotoPath != null)
           {
               string path = _SystemInformation.CustomerPhotoPath + "\\" + _Customer.PhotoPath;
               if (File.Exists(path))
               {
                   pbxProPic.ImageLocation = _SystemInformation.CustomerPhotoPath + "//" + _Customer.PhotoPath;
               }
               else
               {
                   MessageBox.Show("Error Loading Customer Picture" + Environment.NewLine + "Picture Not Found");
               }
           }
        }

        private void RefreshObject()
        {

            _Customer.Code = txtCode.Text;
            _Customer.Name = txtName.Text;
            _Customer.FName = txtFName.Text;
            _Customer.EmailID = txtEmail.Text;
            _Customer.ContactNo = txtMobile.Text;
            _Customer.Name = txtName.Text;

            if (txtCompany.Text == "")
                _Customer.CompanyName = txtName.Text;
            else
                _Customer.CompanyName = txtCompany.Text;


             _Customer.Address = txtAddress.Text;
            _Customer.NID = txtNIDNo.Text;
            _Customer.TotalDue = numPrevDue.Value;

            _Customer.RefName = txtRefName.Text;
            _Customer.RefContact = txtRefContact.Text;
            _Customer.RefFName = txtRefFather.Text;
            _Customer.RefAddress = txtRefAddress.Text;
            _Customer.OpeningDue = numOpeningDue.Value;
            _Customer.CustomerType = (int)cboCusType.SelectedValue;
            _Customer.CreateDate = DateTime.Now;
            _Customer.CreatedBy = Global.CurrentUser.UserID;

            //_Customer.Dist = txtDistrict.Text;
            //_Customer.Thana = txtThana.Text;
            //_Customer.Post = txtPost.Text;
            //_Customer.Village = txtVillage.Text;

            #region Customer Picture

            if ((pbxProPic.ImageLocation != string.Empty) && (pbxProPic.ImageLocation != null))
            {
                if (_Customer.PhotoPath == null)
                {
                    _Customer.PhotoPath = _SystemInformation.CustomerPhotoPath;
                }

                if ((_Customer.PhotoPath.Trim()).ToUpper() != new FileInfo(pbxProPic.ImageLocation).Name.Trim().ToUpper())
                {
                    FileInfo fInfo = new FileInfo(pbxProPic.ImageLocation.Trim());
                    string photoName = txtCode.Text + fInfo.Extension;
                    _Customer.PhotoPath = _SystemInformation.CustomerPhotoPath;


                    if (fInfo.Exists == false)
                    {
                        MessageBox.Show("Picture does not exist", "Customer Picture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_Customer.PhotoPath == "")
                    {
                        MessageBox.Show("Customer's Picture will not be saved. because it's path is not defined.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(_SystemInformation.CustomerPhotoPath))
                            Directory.CreateDirectory(_SystemInformation.CustomerPhotoPath);

                        if (new FileInfo(_SystemInformation.CustomerPhotoPath + photoName).Exists)
                        {
                            if (MessageBox.Show("A picture named " + photoName + " already exists. Do you want to replace it?", "Customer Picture", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                FileInfo info = new FileInfo(_SystemInformation.CustomerPhotoPath + photoName);
                                if (info.IsReadOnly)
                                    info.IsReadOnly = false;
                                File.Copy(pbxProPic.ImageLocation.Trim(), _SystemInformation.CustomerPhotoPath + "\\" + photoName, true);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            File.Copy(pbxProPic.ImageLocation.Trim(), _SystemInformation.CustomerPhotoPath + photoName, true);
                        }

                        new FileInfo(_SystemInformation.CustomerPhotoPath + photoName).IsReadOnly = true;
                        _Customer.PhotoPath = photoName;
                    }
                }
            }
            else
            {
                _Customer.PhotoPath = string.Empty;
            }
            #endregion

        }
        #region Events

        private bool IsValid()
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Customer Name.", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (!IsValid()) return;
                    bool IsNew = false;
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_Customer.CustomerID <= 0)
                        {
                            RefreshObject();
                            _Customer.CustomerID = db.Customers.Count()>0? db.Customers.Max(obj => obj.CustomerID) + 1:1;
                            db.Customers.Add(_Customer);
                            IsNew = true;
                        }
                        else
                        {
                            _Customer = db.Customers.FirstOrDefault(obj => obj.CustomerID == _Customer.CustomerID);
                            RefreshObject();
                        }

                        db.SaveChanges();
                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (MessageBox.Show("Do you want to create another Customer?", "Create Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        
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
                            _Customer = new Customer();
                            RefreshValue();
                            txtCode.Text = GenerateCusCode();
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
        #endregion

        private void fCustomer_Load(object sender, EventArgs e)
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
                    pbxProPic.ImageLocation = odPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GenerateCusCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                i = db.Customers.Count();

                if (i.ToString().Length == 1)
                {
                    sCode = "00000" + Convert.ToString(db.Customers.Count() + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "0000" + Convert.ToString(db.Customers.Count() + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "000" + Convert.ToString(db.Customers.Count() + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "00" + Convert.ToString(db.Customers.Count() + 1);
                }
                else if (i.ToString().Length == 5)
                {
                    sCode = "0" + Convert.ToString(db.Customers.Count() + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(db.Customers.Count() + 1);
                }
            }
            return sCode;
        }

        private void fCustomer_Load_1(object sender, EventArgs e)
        {
            if(_IsNew)
                txtCode.Text = GenerateCusCode();
        }

        private void txtNID_Enter(object sender, EventArgs e)
        {

        }

        private void numPrevDue_Enter(object sender, EventArgs e)
        {
            numPrevDue.Select(0, numPrevDue.Text.Length);
        }

        private void numOpeningDue_Enter(object sender, EventArgs e)
        {
            numOpeningDue.Select(0, numOpeningDue.Text.Length);
        }

        private void numOpeningDue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(_IsNew)
                numPrevDue.Value = numOpeningDue.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
