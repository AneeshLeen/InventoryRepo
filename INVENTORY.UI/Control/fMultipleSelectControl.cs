using DevExpress.XtraGrid.Views.Grid;
using INVENTORY.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using DevExpress.XtraGrid.Views.Grid;
//using INVENTORY.DA;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;


namespace INVENTORY.UI
{
    public partial class fMultipleSelectControl : Form
    {
        public Action ItemChanged;
        private string _ObjectName = String.Empty;
        //public List<Bank> _BankInfos = null;
        //public List<Branch> _BranchInfos = null;
        ctlCustomControl _ctl;
        DEWSRMEntities db = null;
        public fMultipleSelectControl()
        {
            InitializeComponent();
        }

        private void grdCustomers_Click(object sender, EventArgs e)
        {

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

                    if (_ObjectName == "MSEmployee")
                    {
                        this.Text = "Employee Control";
                        var _Employees = db.Employees;
                        gridView1.Columns[1].Caption = "Name";
                        gridView1.Columns[2].Caption = "Designation";
                        gridView1.Columns[3].Caption = "Contact";
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

                                dt.Rows.Add(dr);

                            }

                            grdMultipleSelect.DataSource = dt;
                            lblTotal.Text = "Total :" + _Employees.Count().ToString();
                        }
                    }
                    else if (_ObjectName == "MSCustomer")
                    {
                        this.Text = "Customer Control";
                        var _Employees = db.Customers;
                        gridView1.Columns[1].Caption = "Name";
                        gridView1.Columns[2].Caption = "Contact";
                        gridView1.Columns[3].Caption = "Address";
                        if (_Employees != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (var grd in _Employees)
                            {

                                dr = dt.NewRow();
                                dr["ID"] = grd.CustomerID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["ContactNo"] = "";
                                dr["CName"] = grd.ContactNo;

                                dt.Rows.Add(dr);

                            }

                            grdMultipleSelect.DataSource = dt;
                            lblTotal.Text = "Total :" + _Employees.Count().ToString();
                        }
                    }

                    #region
                    else if (_ObjectName == "Company")
                    {
                        this.Text = "Supplier Control";
                        var _Suppliers = db.Suppliers;

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

                                dt.Rows.Add(dr);
                            }

                            grdMultipleSelect.DataSource = dt;
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
                                dr["CName"] = grd.CompanyName;
                                dr["ContactNo"] = grd.ContactNo;

                                dt.Rows.Add(dr);

                            }

                            grdMultipleSelect.DataSource = dt;
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

                                dt.Rows.Add(dr);

                            }

                            grdMultipleSelect.DataSource = dt;
                            lblTotal.Text = "Total :" + _Employees.Count().ToString();
                        }
                    }

                    else if (_ObjectName == "CCompany")
                    {
                        int nCount = 0;
                        this.Text = "Supplier Due List";
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

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdMultipleSelect.DataSource = dt;
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
                                dr["CName"] = grd.CompanyName;
                                dr["ContactNo"] = grd.ContactNo;

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdMultipleSelect.DataSource = dt;
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
                                dr["CName"] = grd.CompanyName;
                                dr["ContactNo"] = grd.ContactNo;

                                dt.Rows.Add(dr);
                                nCount++;
                                //}
                            }
                            grdMultipleSelect.DataSource = dt;
                            lblTotal.Text = "Total :" + nCount.ToString();
                        }
                    }
                    #endregion


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int> GetGridSelectedRows()
        {
            List<int> IDList = new List<int>();
            foreach (int i in ((GridView)grdMultipleSelect.MainView).GetSelectedRows())
            {
                DataRowView row = (DataRowView)((GridView)grdMultipleSelect.MainView).GetRow(i);
                IDList.Add(Convert.ToInt32(row.Row.ItemArray[0]));
            }
            return IDList;
        }

        private void fMultipleSelectControl_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<int> IDList = GetGridSelectedRows();
            if (IDList.Count() > 0)
            {
                _ctl.IDList = IDList;
                if (ItemChanged != null)
                {
                    ItemChanged();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
