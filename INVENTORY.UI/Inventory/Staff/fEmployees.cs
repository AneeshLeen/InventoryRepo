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
    public partial class fEmployees : Form
    {
        public fEmployees()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("EmployeeID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Designation");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("ContactNo");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Employees = db.Employees;
                    foreach (Employee oEmployee in _Employees)
                    {
                        dr = dt.NewRow();

                        dr["EmployeeID"] = oEmployee.EmployeeID;
                        dr["Code"] = oEmployee.Code;
                        dr["EmployeeName"] = oEmployee.Name;
                        dr["Designation"] = oEmployee.Designation.Description;
                        dr["ContactNo"] = oEmployee.ContactNo;

                        dt.Rows.Add(dr);
                    }
                    grdEmployees.DataSource = dt;
                    lblTotal.Text = "Total :" + _Employees.Count().ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fEmployees_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fEmployee frm = new fEmployee();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Employee(),true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdEmployees.MainView).GetSelectedRows();
                    DataRowView oEmployeeD = (DataRowView)(((GridView)grdEmployees.MainView).GetRow(selRows[0]));

                    int nEmployeeID = Convert.ToInt32(oEmployeeD["EmployeeID"]);
                    Employee oEmployee = db.Employees.FirstOrDefault(p => p.EmployeeID == nEmployeeID);


                    if (oEmployee == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fEmployee frm = new fEmployee();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oEmployee, false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdEmployees.MainView).GetSelectedRows();
                DataRowView oEmployeesID = (DataRowView)(((GridView)grdEmployees.MainView).GetRow(selRows[0]));
                int nEmployeesID = Convert.ToInt32(oEmployeesID["EmployeeID"]);
                Employee oEmployee = db.Employees.FirstOrDefault(p => p.EmployeeID == nEmployeesID);

                if (oEmployee == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {



                    db.Employees.Attach(oEmployee);
                    db.Employees.Remove(oEmployee);

                    db.SaveChanges();

                    MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshList();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        
    }
}
