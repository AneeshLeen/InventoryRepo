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
    public partial class fBankControl : Form
    {
        public Action ItemChanged;
        private string _ObjectName = String.Empty;
        public List<Bank> _BankInfos = null;
      //  public List<Branch> _BranchInfos = null;
        ctlCustomControl _ctl;
        DEWSRMEntities db = null;

        public fBankControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
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
                    dt.Columns.Add("Branch");
                    dt.Columns.Add("Amount");

                    if(_ObjectName=="Category")
                    {
                        this.Text = "Category Control";
                        var _Categories = db.Categorys;

                        if (_Categories != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Category grd in _Categories)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.CategoryID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _Categories.Count().ToString();
                        }
                    }
                    else if (_ObjectName == "BCompany")
                    {
                        this.Text = "Company Control";
                        var _Companies = db.Companies;

                        if (_Companies != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();
                            foreach (Company grd in _Companies)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.CompanyID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _Companies.Count().ToString();
                        }

                    }
                    else if (_ObjectName == "IncomeOnly")
                    {
                        this.Text = "Expense and Income Item";
                        var _ExpenseItems = db.ExpenseItems.Where(s => s.Status == 2);

                        if (_ExpenseItems != null)
                        {
                            foreach (ExpenseItem grd in _ExpenseItems)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.ExpenseItemID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _ExpenseItems.Count().ToString();
                        }

                    }
                    else if (_ObjectName == "ExpenseOnly")
                    {
                        this.Text = "Expense and Income Item";
                        var _ExpenseItems = db.ExpenseItems.Where(s => s.Status == 1);

                        if (_ExpenseItems != null)
                        {
                            foreach (ExpenseItem grd in _ExpenseItems)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.ExpenseItemID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _ExpenseItems.Count().ToString();
                        }

                    }
                    else if (_ObjectName == "Model")
                    {
                        this.Text = "Size/Color Control";
                        var _Models = db.Models;

                        if (_Models != null)
                        {
                            foreach (Model grd in _Models)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.ModelID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;
                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _Models.Count().ToString();

                        }
                    }
                    else if(_ObjectName=="Color")
                    {
                        this.Text = "Color Control";
                        var _Colors = db.Colors;

                        if (_Colors != null)
                        {
                            List<ListViewItem> lItems = new List<ListViewItem>();

                            foreach (INVENTORY.DA.Color grd in _Colors)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.ColorID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _Colors.Count().ToString();
                        }
                    }
                    else if(_ObjectName=="Expense")
                    {
                        this.Text = "Expense and Income Item";
                        var _ExpenseItems = db.ExpenseItems;

                        if (_ExpenseItems != null)
                        {
                            foreach (ExpenseItem grd in _ExpenseItems)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.ExpenseItemID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Description;

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _ExpenseItems.Count().ToString();
                        }

                    }
                    else if(_ObjectName=="Bank")
                    {
                        this.Text = "Bank Control";
                        _BankInfos = db.Banks.ToList();


                        if (_BankInfos != null)
                        {
                            foreach (Bank grd in _BankInfos)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.BankID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.BankName;
                                dr["Branch"] = grd.AccountName+","+grd.AccountNo;
                                dr["Amount"] = grd.TotalAmount;
                                dt.Rows.Add(dr);

                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _BankInfos.Count().ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fItemControl_Load(object sender, EventArgs e)
        {
            RefreshList();
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

        private void grdItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Category oCategory = null;
                Company oCompany = null;
                INVENTORY.DA.Color oColor = null;
                ExpenseItem oExpenseItem = null;
                Model oModel = null;

                int[] selRows = ((GridView)grdItems.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdItems.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oID["ID"]);
                Bank oBank = null;

                if (nID > 0)
                {
                    if (_ObjectName == "Category")
                    {
                        this.Text = "Part Control";
                        oCategory = db.Categorys.FirstOrDefault(p => p.CategoryID == nID);
                        _ctl.SelectedID = oCategory.CategoryID;
                        _ctl.Code = oCategory.Code;
                        _ctl.Name = oCategory.Description;
                    }
                    else if (_ObjectName == "BCompany")
                    {
                        this.Text = "Company Control";
                        oCompany = db.Companies.FirstOrDefault(p => p.CompanyID == nID);
                        _ctl.SelectedID = oCompany.CompanyID;
                        _ctl.Code = oCompany.Code;
                        _ctl.Name = oCompany.Description;
                    }
                    else if (_ObjectName == "Color")
                    {
                        this.Text = "Color Control";
                        oColor = db.Colors.FirstOrDefault(p => p.ColorID == nID);
                        _ctl.SelectedID = oColor.ColorID;
                        _ctl.Code = oColor.Code;
                        _ctl.Name = oColor.Description;
                    }
                    else if (_ObjectName == "Model")
                    {
                        this.Text = "Employee Control";

                        oModel = db.Models.FirstOrDefault(p => p.ModelID == nID);
                        _ctl.SelectedID = oModel.ModelID;
                        _ctl.Code = oModel.Code;
                        _ctl.Name = oModel.Description;

                    }
                    else if (_ObjectName == "Expense")
                    {
                        this.Text = "Expense Control";
                        oExpenseItem = db.ExpenseItems.FirstOrDefault(p => p.ExpenseItemID == nID);
                        _ctl.SelectedID = oExpenseItem.ExpenseItemID;
                        _ctl.Code = oExpenseItem.Code;
                        _ctl.Name = oExpenseItem.Description;
                    }
                    else if (_ObjectName == "IncomeOnly")
                    {
                        this.Text = "Expense Control";
                        oExpenseItem = db.ExpenseItems.FirstOrDefault(p => p.ExpenseItemID == nID);
                        _ctl.SelectedID = oExpenseItem.ExpenseItemID;
                        _ctl.Code = oExpenseItem.Code;
                        _ctl.Name = oExpenseItem.Description;
                    }
                    else if (_ObjectName == "ExpenseOnly")
                    {
                        this.Text = "Expense Control";
                        oExpenseItem = db.ExpenseItems.FirstOrDefault(p => p.ExpenseItemID == nID);
                        _ctl.SelectedID = oExpenseItem.ExpenseItemID;
                        _ctl.Code = oExpenseItem.Code;
                        _ctl.Name = oExpenseItem.Description;
                    }
                    else if(_ObjectName=="Bank")
                    {
                        this.Text = "Bank Control";
                        oBank = db.Banks.FirstOrDefault(p => p.BankID == nID);
                        _ctl.SelectedID = oBank.BankID;
                        _ctl.Code = oBank.Code;
                        _ctl.Name = oBank.BankName;
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
