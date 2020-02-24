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
    public partial class fEmployee : Form
    {
        private Employee _Employee = null;
        public Action ItemChanged;
        private INVENTORY.DA.SystemInformation _SystemInformation = null;
        bool _IsNew = false;

        public fEmployee()
        {
            InitializeComponent();
        }

        public void ShowDlg(Employee oEmployee,bool IsNew)
        {
            _IsNew = IsNew;
            DEWSRMEntities db = new DEWSRMEntities();
            var _SysInfos = db.SystemInformations;

            _SystemInformation = (from c in db.SystemInformations
                                  where c.SystemInfoID == 1
                                  select c).FirstOrDefault();

            _Employee = oEmployee;
            PopulateDesignationCbo();
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            txtEmpCode.Text = _Employee.Code;
            txtEmpName.Text = _Employee.Name;
            txtFName.Text = _Employee.FName;
            txtMName.Text = _Employee.MName;
            txtContactNo.Text = _Employee.ContactNo;
            txtEmailID.Text = _Employee.EmailID;
            txtNID.Text = _Employee.NID;
            txtBloodGroup.Text = _Employee.BloodGroup;
            dtpJoiningDate.Value = _Employee.JoiningDate != null ?(DateTime) _Employee.JoiningDate : DateTime.Now;

            if ((Designation)cboDesignation.SelectedItem!=null)
                cboDesignation.SelectedValue = ((Designation)cboDesignation.SelectedItem).DesignationID; 

            txtPreAddress.Text = _Employee.PresentAdd;
            txtPerAddress.Text = _Employee.PermanentAdd;
            numGrossSalary.Value = _Employee.GrossSalary;

            if (_Employee.PhotoPath != null)
            {
                string path = _SystemInformation.EmployeePhotoPath + "\\" + _Employee.PhotoPath;
                if (File.Exists(path))
                {

                    pbxEmpPic.ImageLocation = _SystemInformation.EmployeePhotoPath + "//" + _Employee.PhotoPath;
                }
                else
                {
                    MessageBox.Show("Error Loading Employee Picture" + Environment.NewLine + "Picture Not Found");
                }
            }
        }

        private void RefreshObject()
        {
            _Employee.Code=txtEmpCode.Text;
            _Employee.Name=txtEmpName.Text;
            _Employee.FName=txtFName.Text;
            _Employee.MName=txtMName.Text;
            _Employee.ContactNo=txtContactNo.Text;
            _Employee.EmailID=txtEmailID.Text;
            _Employee.NID=txtNID.Text;
            _Employee.BloodGroup=txtBloodGroup.Text;
            _Employee.JoiningDate=dtpJoiningDate.Value;
            _Employee.DesignationID = ((Designation)cboDesignation.SelectedItem).DesignationID;
            _Employee.PresentAdd=txtPreAddress.Text;
            _Employee.PermanentAdd=txtPerAddress.Text;
            _Employee.GrossSalary = numGrossSalary.Value;

            #region Employee Picture

            if ((pbxEmpPic.ImageLocation != string.Empty) && (pbxEmpPic.ImageLocation != null))
            {
                if (_Employee.PhotoPath == null)
                {
                    _Employee.PhotoPath = _SystemInformation.EmployeePhotoPath;
                }

                if ((_Employee.PhotoPath.Trim()).ToUpper() != new FileInfo(pbxEmpPic.ImageLocation).Name.Trim().ToUpper())
                {
                    FileInfo fInfo = new FileInfo(pbxEmpPic.ImageLocation.Trim());
                    string photoName = txtEmpCode.Text + fInfo.Extension;
                    _Employee.PhotoPath = _SystemInformation.EmployeePhotoPath;

                    if (fInfo.Exists == false)
                    {
                        MessageBox.Show("Picture does not exist", "Employee Picture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_Employee.PhotoPath == "")
                    {
                        MessageBox.Show("Employee's Picture will not be saved. because it's path is not defined.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(_SystemInformation.EmployeePhotoPath))
                            Directory.CreateDirectory(_SystemInformation.EmployeePhotoPath);

                        if (new FileInfo(_SystemInformation.EmployeePhotoPath + photoName).Exists)
                        {
                            if (MessageBox.Show("A picture named " + photoName + " already exists. Do you want to replace it?", "Employee Picture", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                FileInfo info = new FileInfo(_SystemInformation.EmployeePhotoPath + photoName);
                                if (info.IsReadOnly)
                                    info.IsReadOnly = false;
                                File.Copy(pbxEmpPic.ImageLocation.Trim(), _SystemInformation.EmployeePhotoPath + "\\" + photoName, true);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            File.Copy(pbxEmpPic.ImageLocation.Trim(), _SystemInformation.EmployeePhotoPath + photoName, true);
                        }

                        new FileInfo(_SystemInformation.EmployeePhotoPath + photoName).IsReadOnly = true;
                        _Employee.PhotoPath = photoName;
                    }
                }
            }
            else
            {
                _Employee.PhotoPath = string.Empty;
            }
            #endregion            
        }

        private bool IsValid()
        {
            if (txtEmpName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Employee Name.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) return;
                if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_Employee.EmployeeID <= 0)
                        {
                            RefreshObject();
                            _Employee.EmployeeID = db.Employees.Count() > 0 ? db.Employees.Max(obj => obj.EmployeeID) + 1 : 1;
                            db.Employees.Add(_Employee);
                        }
                        else
                        {
                            _Employee = db.Employees.FirstOrDefault(obj => obj.EmployeeID == _Employee.EmployeeID);
                            RefreshObject();
                        }

                        db.SaveChanges();

                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Do you want to create another Employee?", "Create Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                            _Employee = new Employee();
                            RefreshValue();
                            txtEmpCode.Text = GenerateEmpCode();
                        }
                    }
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateDesignationCbo()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                cboDesignation.DisplayMember = "Description";
                cboDesignation.ValueMember = "DesignationID";
                cboDesignation.DataSource = db.Designations.OrderBy(x => x.Description).ToList();
            }
        }

        private string GenerateEmpCode()
        {
            int i = 0;
            string sCode = "";

            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                i = db.Employees.Count();

                if (i.ToString().Length == 1)
                {
                    sCode = "0000" + Convert.ToString(db.Employees.Count() + 1);
                }
                else if (i.ToString().Length == 2)
                {
                    sCode = "000" + Convert.ToString(db.Employees.Count() + 1);
                }
                else if (i.ToString().Length == 3)
                {
                    sCode = "00" + Convert.ToString(db.Employees.Count() + 1);
                }
                else if (i.ToString().Length == 4)
                {
                    sCode = "0" + Convert.ToString(db.Employees.Count() + 1);
                }
                else
                {
                    sCode = "0" + Convert.ToString(db.Employees.Count() + 1);
                }
            }
            return sCode;
        }
        private void fEmployee_Load(object sender, EventArgs e)
        {
            PopulateDesignationCbo();
            if(_IsNew)
                txtEmpCode.Text = GenerateEmpCode();
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

        private void numGrossSalary_Enter(object sender, EventArgs e)
        {
            numGrossSalary.Select(0, numGrossSalary.Text.Length);
        }
    }
}
