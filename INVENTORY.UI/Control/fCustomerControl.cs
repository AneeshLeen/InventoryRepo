using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using INVENTORY.DA;

namespace INVENTORY.UI
{
    public partial class fCustomerControl : Form
    {
        public List<Supplier> _Suppliers = null;
        public List<Customer> _Customers = null;
        public List<Product> _Products = null;
        public List<Employee> _Employees = null;
        public Action ItemChanged;
        private string _ObjectName = String.Empty;
        ctlCustomControl _ctl;
        DEWSRMEntities db = null;


        public fCustomerControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void fCustomerControl_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        public void ShowDlg(string sObjectName, ctlCustomControl ctlCustomControl)
        {
            _ObjectName = sObjectName;
            _ctl = ctlCustomControl;
            this.ShowDialog();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("CName");
                    dt.Columns.Add("ContactNo");
                    dt.Columns.Add("Address");
                    
                    if (_ObjectName == "Company")
                    {
                        this.Text = "Supplier Control";
                        var _Suppliers = db.Suppliers;

                        gridView1.Columns[2].Caption = "Contact Person";
                        if (_Suppliers != null)
                        {
                            foreach (Supplier grd in _Suppliers)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SupplierID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.OwnerName;
                                dr["CName"] = grd.Name;
                                dr["ContactNo"] = grd.ContactNo;
                                dr["Address"] = grd.Address;

                                dt.Rows.Add(dr);
                            }

                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + _Suppliers.Count().ToString();
                        }
                    }
                    else if (_ObjectName == "Customer")
                    {
                        this.Text = "Retail and Dealer Customer Control";
                     
                        //var _Customers = db.Customers.Where(i => i.CustomerType != (int)EnumCustomerType.Credit);
                        var _Customers = db.Customers.ToList();
                        if (_Customers != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Customer grd in _Customers)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.CustomerID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["CName"] = grd.FName;//grd.CompanyName;
                                dr["ContactNo"] = grd.ContactNo;
                                dr["Address"] = grd.Address;

                                dt.Rows.Add(dr);

                            }

                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + _Customers.Count().ToString();

                        }

                    }
                    else if (_ObjectName == "Employee")
                    {
                        this.Text = "Employee Control";
                        var _Employees = db.Employees;
                        if (_Employees != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Employee grd in _Employees)
                            {

                                dr = dt.NewRow();
                                dr["ID"] = grd.EmployeeID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["CName"] = grd.Designation.Description;
                                dr["ContactNo"] = grd.ContactNo;
                                dr["Address"] = grd.PermanentAdd;

                                dt.Rows.Add(dr);

                            }

                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + _Employees.Count().ToString();
                        }
                    }
                    else if (_ObjectName == "CCompany")
                    {
                        int nCount = 0;
                        this.Text = "Supplier Due List";
                        gridView1.Columns[2].Caption = "Contact Person";
                        var _Suppliers = db.Suppliers;
                        if (_Suppliers != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Supplier grd in _Suppliers)
                            {
                                //if (grd.TotalDue > 0)
                                //{
                                dr = dt.NewRow();
                                dr["ID"] = grd.SupplierID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.OwnerName;
                                dr["CName"] = grd.Name;
                                dr["ContactNo"] = grd.ContactNo;
                                dr["Address"] = grd.Address;

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();

                        }

                    }
                    else if (_ObjectName == "CCustomer")
                    {
                        int nCount = 0;
                        this.Text = "Customer Due List";
                        var _Customers = db.Customers;
                        if (_Customers != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Customer grd in _Customers)
                            {
                                //if (grd.TotalDue > 0)
                                //{
                                dr = dt.NewRow();
                                dr["ID"] = grd.CustomerID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["CName"] = grd.FName;//grd.CompanyName;
                                dr["ContactNo"] = grd.ContactNo;
                                dr["Address"] = grd.Address;

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();
                        }
                    }
                    else if (_ObjectName == "CreditCustomer")
                    {
                        int nCount = 0;
                        this.Text = "Credit Customers";
                        var _Customers = db.Customers.Where(i => i.CustomerType == (int)EnumCustomerType.Retail);
                        if (_Customers != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Customer grd in _Customers)
                            {
                                //if (grd.TotalDue > 0)
                                //{
                                dr = dt.NewRow();
                                dr["ID"] = grd.CustomerID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["CName"] = grd.FName;//grd.CompanyName;
                                dr["ContactNo"] = grd.ContactNo;
                                dr["Address"] = grd.Address;

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();
                        }
                    }
                    else if (_ObjectName == "SMSFormat")
                    {
                        int nCount = 0;
                        this.Text = "SMSFormat";
                        var smsFormates = db.SMSFormates;
                        if (smsFormates != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (var grd in smsFormates)
                            {
                                //if (grd.TotalDue > 0)
                                //{
                                dr = dt.NewRow();
                                dr["ID"] = grd.SMSFormateID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.SMSDescription;
                                dr["CName"] = "";
                                dr["ContactNo"] = "";

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdCustomers.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void grdCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Customer oCustomer = null;
                Supplier oSupplier = null;
                Employee oEmployee = null;
                SMSFormate oSMSFormat = null;

                int[] selRows = ((GridView)grdCustomers.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdCustomers.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oID["ID"]);


                if (nID > 0)
                {
                    if (_ObjectName == "Company")
                    {
                        this.Text = "Supplier Control";
                        oSupplier = db.Suppliers.FirstOrDefault(p => p.SupplierID == nID);
                        _ctl.SelectedID = oSupplier.SupplierID;
                        _ctl.Code = oSupplier.Code;
                        _ctl.Name = oSupplier.Name;

                    }
                    else if (_ObjectName == "Customer")
                    {
                        this.Text = "Customer Control";
                        oCustomer = db.Customers.FirstOrDefault(p => p.CustomerID == nID);
                        _ctl.SelectedID = oCustomer.CustomerID;
                        _ctl.Code = oCustomer.Code;
                        _ctl.Name = oCustomer.Name;
                    }
                    else if (_ObjectName == "Employee")
                    {
                        this.Text = "Employee Control";

                        oEmployee = db.Employees.FirstOrDefault(p => p.EmployeeID == nID);
                        _ctl.SelectedID = oEmployee.EmployeeID;
                        _ctl.Code = oEmployee.Code;
                        _ctl.Name = oEmployee.Name;

                    }
                    else if (_ObjectName == "CCompany")
                    {
                        this.Text = "Supplier Due List";
                        oSupplier = db.Suppliers.FirstOrDefault(p => p.SupplierID == nID);
                        _ctl.SelectedID = oSupplier.SupplierID;
                        _ctl.Code = oSupplier.Code;
                        _ctl.Name = oSupplier.Name;

                    }
                    else if (_ObjectName == "CCustomer")
                    {
                        this.Text = "Customer Due List";
                        oCustomer = db.Customers.FirstOrDefault(p => p.CustomerID == nID);
                        _ctl.SelectedID = oCustomer.CustomerID;
                        _ctl.Code = oCustomer.Code;
                        _ctl.Name = oCustomer.Name;
                    }
                    else if (_ObjectName == "CreditCustomer")
                    {
                        this.Text = "CreditCustomer";
                        oCustomer = db.Customers.FirstOrDefault(p => p.CustomerID == nID);
                        _ctl.SelectedID = oCustomer.CustomerID;
                        _ctl.Code = oCustomer.Code;
                        _ctl.Name = oCustomer.Name;
                    }
                    else if (_ObjectName == "SMSFormat")
                    {
                        this.Text = "SMSFormat";
                        oSMSFormat = db.SMSFormates.FirstOrDefault(p => p.SMSFormateID == nID);
                        _ctl.SelectedID = oSMSFormat.SMSFormateID;
                        _ctl.Code = oSMSFormat.Code;
                        _ctl.Name = oSMSFormat.SMSDescription;
                    }
                }
                if (ItemChanged != null)
                {
                    ItemChanged();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
