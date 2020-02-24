using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVENTORY.DA;

namespace INVENTORY.UI
{
    public delegate void SelectionChangedEvent(Object sender, EventArgs e);
    public partial class ctlCustomControl : UserControl
    {
        public event SelectionChangedEvent SelectedItemChanged;
        public static int BankID = 0;
        Bank _BankInfo = null;
        Customer _Customer = null;
        Supplier _Supplier = null;
        Product _Product = null;
        Employee _Employee = null;
        Model _Model = null;
        Category _Category = null;
        Company _Company = null;
        INVENTORY.DA.Color _Color = null;
        ExpenseItem _ExpenseItem = null;
        Godown _Godown = null;
        static public int _CID = 0;
        ShareInvestmentHead _ShareInvestment = null;
        public List<int> _IDList = null;
        int _ID;
        internal int SelectedID
        {
            get
            {
                return _ID;
            }
            set
            {
                int oldValue = _ID;
                _ID = value;
                if (oldValue != _ID)
                    OnSelectedItemChanged(new EventArgs());
            }
        }
        public List<int> IDList
        {
            get
            {
                return _IDList;
            }
            set
            {
                _IDList = value;
            }
        }
        internal string Code { get; set; }
        internal string Name { get; set; }
        internal string Contact { get; set; }
        public string ObjectName { get; set; }

        public ctlCustomControl()
        {
            InitializeComponent();
        }
        protected virtual void OnSelectedItemChanged(EventArgs e)
        {
            Refresh();
            SelectedItemChanged(this, e);

        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (ObjectName == "Product")
            {
                fProductControl frm = new fProductControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(this, ObjectName);
            }
            else if (ObjectName == "OProduct")
            {
                fProductControl frm = new fProductControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(this, ObjectName);

            }
            else if (ObjectName == "SPReport")
            {
                fProductControl frm = new fProductControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(this, ObjectName);

            }
            else if (ObjectName == "StockDetail")
            {
                fStockDetailControl frm = new fStockDetailControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(this, true);
            }
            else if (ObjectName == "BCompany")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "Category")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "Model")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "PReturn")
            {
                fNewProductControl frm = new fNewProductControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this, _CID);

            }
            else if (ObjectName == "SReturn")
            {
                fNewProductControl frm = new fNewProductControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this, _CID);
            }
            else if (ObjectName == "Color")
            {
                fColorControl frm = new fColorControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(this, false);
            }
            else if (ObjectName == "Expense")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);

            }
            else if (ObjectName == "ExpenseOnly")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);

            }
            else if (ObjectName == "IncomeOnly")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);

            }
            else if (ObjectName == "Bank")
            {
                fBankControl frm = new fBankControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "FAsset")
            {
                fInvestmentControl frm = new fInvestmentControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "CAsset")
            {
                fInvestmentControl frm = new fInvestmentControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);

            }
            else if (ObjectName == "LReceive")
            {
                fInvestmentControl frm = new fInvestmentControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "LPay")
            {
                fInvestmentControl frm = new fInvestmentControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "Liability")
            {
                fInvestmentControl frm = new fInvestmentControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "MSCustomer")//Multiple Select Customer
            {
                fMultipleSelectControl frm = new fMultipleSelectControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else if (ObjectName == "Godown")
            {
                fItemControl frm = new fItemControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);
            }
            else
            {
                fCustomerControl frm = new fCustomerControl();
                frm.ItemChanged = Refresh;
                frm.ShowDlg(ObjectName, this);

                //fCompanyControl frm = new fCompanyControl();
                //frm.ItemChanged = Refresh;
                //frm.ShowDlg(ObjectName, this);
            }
        }

        private void Refresh()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    if (ObjectName == "Company")
                    {
                        _Supplier = db.Suppliers.FirstOrDefault(o => o.SupplierID == SelectedID);
                        if(_Supplier==null)
                            _CID =0;
                        else               
                            _CID = _Supplier.SupplierID;

                        if (_Supplier != null)
                        {
                            txtCode.Text = _Supplier.Code;
                            txtName.Text = _Supplier.OwnerName;//_Supplier.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Customer")
                    {
                        _Customer = db.Customers.FirstOrDefault(o => o.CustomerID == SelectedID);
                        if (_Customer != null)
                        {
                            _CID = _Customer.CustomerID;
                            txtCode.Text = _Customer.Code;
                            txtName.Text = _Customer.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Model")
                    {
                        _Model = db.Models.FirstOrDefault(o => o.ModelID == SelectedID);
                        if (_Model != null)
                        {
                            txtCode.Text = _Model.Code;
                            txtName.Text = _Model.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }

                    }                  
                    else if (ObjectName == "ReturnProduct")
                    {
                        StockDetail oSD = db.StockDetails.FirstOrDefault(o => o.SDetailID == SelectedID);

                        if (oSD != null)
                        {
                            _Product = db.Products.FirstOrDefault(o => o.ProductID == oSD.Stock.ProductID);
                            txtCode.Text = _Product.Code;
                            txtName.Text = _Product.ProductName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Employee")
                    {
                        _Employee = db.Employees.FirstOrDefault(o => o.EmployeeID == SelectedID);
                        if (_Employee != null)
                        {
                            txtCode.Text = _Employee.Code;
                            txtName.Text = _Employee.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }

                    }
                    else if (ObjectName == "Product")
                    {
                        _Product = db.Products.FirstOrDefault(o => o.ProductID == SelectedID);
                        if (_Product != null)
                        {
                            txtCode.Text = _Product.Code;
                            txtName.Text = _Product.ProductName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "OProduct")
                    {
                        _Product = db.Products.FirstOrDefault(o => o.ProductID == SelectedID);
                        if (_Product != null)
                        {
                            txtCode.Text = _Product.Code;
                            txtName.Text = _Product.ProductName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "SPReport")
                    {
                        _Product = db.Products.FirstOrDefault(o => o.ProductID == SelectedID);
                        if (_Product != null)
                        {
                            txtCode.Text = _Product.Code;
                            txtName.Text = _Product.ProductName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "CCompany")
                    {
                        _Supplier = db.Suppliers.FirstOrDefault(o => o.SupplierID == SelectedID);
                        if (_Supplier != null)
                        {
                            txtCode.Text = _Supplier.Code;
                            txtName.Text = _Supplier.OwnerName;//_Supplier.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }

                    }
                    else if (ObjectName == "IncomeOnly")
                    {
                        _ExpenseItem = db.ExpenseItems.FirstOrDefault(o => o.ExpenseItemID == SelectedID);
                        if (_ExpenseItem != null)
                        {
                            txtCode.Text = _ExpenseItem.Code;
                            txtName.Text = _ExpenseItem.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "ExpenseOnly")
                    {
                        _ExpenseItem = db.ExpenseItems.FirstOrDefault(o => o.ExpenseItemID == SelectedID);
                        if (_ExpenseItem != null)
                        {
                            txtCode.Text = _ExpenseItem.Code;
                            txtName.Text = _ExpenseItem.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "CCustomer")
                    {
                        _Customer = db.Customers.FirstOrDefault(o => o.CustomerID == SelectedID);
                        if (_Customer != null)
                        {
                            txtCode.Text = _Customer.Code;
                            txtName.Text = _Customer.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "CreditCustomer")
                    {
                        _Customer = db.Customers.FirstOrDefault(o => o.CustomerID == SelectedID);
                        if (_Customer != null)
                        {
                            txtCode.Text = _Customer.Code;
                            txtName.Text = _Customer.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "SReturn")
                    {

                        StockDetail OSD = db.StockDetails.FirstOrDefault(o => o.SDetailID == SelectedID);

                        if (OSD != null)
                        {
                            _Product = db.Products.FirstOrDefault(o => o.ProductID == OSD.ProductID);
                        }
                        else
                        {
                            _Product = null;
                        }

                       
                        if (_Product != null)
                        {
                            txtCode.Text = _Product.Code;
                            txtName.Text = _Product.ProductName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "PReturn")
                    {

                        StockDetail OSD = db.StockDetails.FirstOrDefault(o => o.SDetailID == SelectedID);

                        if (OSD != null)
                        {
                            _Product = db.Products.FirstOrDefault(o => o.ProductID == OSD.ProductID);
                        }
                        else
                        {
                            _Product = null;
                        }
                    
                        if (_Product != null)
                        {
                            txtCode.Text = _Product.Code;
                            txtName.Text = _Product.ProductName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "StockDetail")
                    {
                        StockDetail stockDetail = db.StockDetails.FirstOrDefault(o => o.SDetailID == SelectedID);
                        if (stockDetail != null)
                        {
                            txtName.Text = stockDetail.Product.ProductName;
                            txtCode.Text = stockDetail.Product.Code;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Category")
                    {
                        _Category = db.Categorys.FirstOrDefault(o => o.CategoryID == SelectedID);
                        if (_Category != null)
                        {
                            txtCode.Text = _Category.Code;
                            txtName.Text = _Category.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }

                    }
                    else if (ObjectName == "BCompany")
                    {
                        _Company = db.Companies.FirstOrDefault(o => o.CompanyID == SelectedID);
                        if (_Company != null)
                        {
                            txtCode.Text = _Company.Code;
                            txtName.Text = _Company.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Color")
                    {
                        _Color = db.Colors.FirstOrDefault(o => o.ColorID == SelectedID);
                        if (_Color != null)
                        {
                            txtCode.Text = _Color.Code;
                            txtName.Text = _Color.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "FAsset")
                    {
                        _ShareInvestment = db.ShareInvestmentHeads.FirstOrDefault(o => o.SIHID == SelectedID);
                        if (_ShareInvestment != null)
                        {
                            txtCode.Text = _ShareInvestment.Code;
                            txtName.Text = _ShareInvestment.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "CAsset")
                    {
                        _ShareInvestment = db.ShareInvestmentHeads.FirstOrDefault(o => o.SIHID == SelectedID);
                        if (_ShareInvestment != null)
                        {
                            txtCode.Text = _ShareInvestment.Code;
                            txtName.Text = _ShareInvestment.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "LReceive")
                    {
                        _ShareInvestment = db.ShareInvestmentHeads.FirstOrDefault(o => o.SIHID == SelectedID);
                        if (_ShareInvestment != null)
                        {
                            txtCode.Text = _ShareInvestment.Code;
                            txtName.Text = _ShareInvestment.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "LPay")
                    {
                        _ShareInvestment = db.ShareInvestmentHeads.FirstOrDefault(o => o.SIHID == SelectedID);
                        if (_ShareInvestment != null)
                        {
                            txtCode.Text = _ShareInvestment.Code;
                            txtName.Text = _ShareInvestment.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Liability")
                    {
                        _ShareInvestment = db.ShareInvestmentHeads.FirstOrDefault(o => o.SIHID == SelectedID);
                        if (_ShareInvestment != null)
                        {
                            txtCode.Text = _ShareInvestment.Code;
                            txtName.Text = _ShareInvestment.Name;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Expense")
                    {
                        _ExpenseItem = db.ExpenseItems.FirstOrDefault(o => o.ExpenseItemID == SelectedID);
                        if (_ExpenseItem != null)
                        {
                            txtCode.Text = _ExpenseItem.Code;
                            txtName.Text = _ExpenseItem.Description;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "Godown")
                    {
                        _Godown = db.Godowns.FirstOrDefault(o => o.GodownID == SelectedID);
                        if (_Godown != null)
                        {
                            txtCode.Text = _Godown.GodownCode;
                            txtName.Text = _Godown.GodownName;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                    else if (ObjectName == "MSCustomer")
                    {
                        if (_IDList == null)
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                        else
                        {
                            txtCode.Text = "00000";
                            txtName.Text = "Selected Total:" + _IDList.Count().ToString();
                        }

                    }
                    else if (ObjectName == "Bank")
                    {
                        _BankInfo = db.Banks.FirstOrDefault(o => o.BankID == SelectedID);
                        if (_BankInfo != null)
                        {
                            BankID = _BankInfo.BankID;
                            txtCode.Text = _BankInfo.Code;
                            txtName.Text = _BankInfo.BankName+","+_BankInfo.AccountNo;
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtName.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
