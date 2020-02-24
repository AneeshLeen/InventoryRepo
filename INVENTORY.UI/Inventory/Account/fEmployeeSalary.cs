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
    public partial class fEmployeeSalary : Form
    {
        Employee _oEmployee = new Employee();
        EmpSalary _EmpSalary = null;
        public Action ItemChanged;
        DEWSRMEntities db = null;
        decimal _Remaining = 0;
        decimal _ReceiveAmt = 0;
        public fEmployeeSalary()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(EmpSalary oEmpSalary)
        {
            _EmpSalary = oEmpSalary;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            ctlEmployee.SelectedID = _EmpSalary.EmployeeID != null ? (int)_EmpSalary.EmployeeID : 0;
            numGross.Value = _EmpSalary.GrossSalary != null ? (decimal)_EmpSalary.GrossSalary : 0;
            dtpDate.Value = _EmpSalary.SalaryMonth != null ? (DateTime)_EmpSalary.SalaryMonth : DateTime.Now;
            numReceive.Value = _EmpSalary.RecAmt != null ? (decimal)_EmpSalary.RecAmt : 0;
            numRemaining.Value = _EmpSalary.RemainingAmt != null ? (decimal)_EmpSalary.RemainingAmt : 0;

        }

        private void RefreshObject()
        {
            _EmpSalary.EmployeeID = ctlEmployee.SelectedID;
            _EmpSalary.SalaryMonth = dtpDate.Value;
            _EmpSalary.GrossSalary = numGross.Value;
            _EmpSalary.RecAmt = numReceive.Value;
            _EmpSalary.RemainingAmt = numRemaining.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (_EmpSalary.EmpSalaryID <= 0)
                        {
                            RefreshObject();
                            _EmpSalary.EmpSalaryID = db.EmpSalaries.Count() > 0 ? db.EmpSalaries.Max(obj => obj.EmpSalaryID) + 1 : 1;
                            db.EmpSalaries.Add(_EmpSalary);
                        }
                        else
                        {
                            _EmpSalary = db.EmpSalaries.FirstOrDefault(obj => obj.EmpSalaryID == _EmpSalary.EmpSalaryID);
                            RefreshObject();
                        }

                        db.SaveChanges();

                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Do you want to paid another employee salary?", "Salary Paid.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                            _EmpSalary = new EmpSalary();
                            RefreshValue();
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

        private void numReceive_ValueChanged(object sender, EventArgs e)
        {
            if (_Remaining<=0)
            {
                MessageBox.Show("No remaining amount for this month.", "Employee Salary.", MessageBoxButtons.OK);
                return;
            }
            else
            {
                numRemaining.Value = _Remaining - numReceive.Value;
            }
            
        }

        private void fEmployeeSalary_Load(object sender, EventArgs e)
        {

        }

        private void ctlEmployee_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {

                _oEmployee = (Employee)(db.Employees.FirstOrDefault(o => o.EmployeeID == ctlEmployee.SelectedID));
                if (_oEmployee != null)
                {
                    numGross.Value = _oEmployee.GrossSalary;
                    _ReceiveAmt = db.EmpSalaries.Where(o => o.EmployeeID == _oEmployee.EmployeeID && ((DateTime)o.SalaryMonth).Month == DateTime.Today.Month).Sum(x => (decimal?)x.RecAmt) ?? 0;
                    _Remaining = (decimal)(_oEmployee.GrossSalary - _ReceiveAmt);
                    numRemaining.Value = _Remaining;

                    if (_Remaining<=0)
                    {
                        MessageBox.Show("No remaining amount for this month [ Employee Name : " + _oEmployee.Name +"]", "Employee Salary.", MessageBoxButtons.OK);
                        ctlEmployee.SelectedID = 0;
                        numGross.Value = 0;
                        return;                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numReceive_Enter(object sender, EventArgs e)
        {
            numReceive.Select(0, numReceive.Text.Length);

        }
    }
}
