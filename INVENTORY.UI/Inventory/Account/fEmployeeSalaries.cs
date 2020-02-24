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
    public partial class fEmployeeSalaries : Form
    {
        public fEmployeeSalaries()
        {
            InitializeComponent();
        }

        private void fEmployeeSalaries_Load(object sender, EventArgs e)
        {
            RefreshList();
        }


        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _EmployeeSalaries = db.EmpSalaries;

                    ListViewItem item = null;
                    lsvEmpSalary.Items.Clear();

                    if (_EmployeeSalaries != null)
                    {
                        foreach (INVENTORY.DA.EmpSalary grd in _EmployeeSalaries)
                        {
                            item = new ListViewItem();
                            item.Text = Convert.ToDateTime(grd.SalaryMonth).ToString("dd MMM yyyy");
                            item.SubItems.Add(grd.Employee.Name);
                            item.SubItems.Add(grd.Employee.GrossSalary.ToString());
                            item.SubItems.Add(grd.RecAmt.ToString());
                            item.SubItems.Add(grd.RemainingAmt.ToString());
                            item.Tag = grd;
                            lsvEmpSalary.Items.Add(item);
                        }

                        lblTotal.Text = "Total :" + _EmployeeSalaries.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //int count = lsvEmpSalary.Items.Count;

                if (txtSearch.Text != "")
                {
                    foreach (ListViewItem item in lsvEmpSalary.Items)
                    {
                        if (item.SubItems[1].Text.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            lsvEmpSalary.Items.Remove(item);
                        }
                        item.Selected = false;
                    }
                    if (lsvEmpSalary.SelectedItems.Count == 1)
                    {
                        lsvEmpSalary.Focus();
                    }
                }
                else
                {
                    RefreshList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fEmployeeSalary frm = new fEmployeeSalary();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new EmpSalary());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvEmpSalary.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                EmpSalary oEmpSalary = null;
                fEmployeeSalary frm = new fEmployeeSalary();

                if (lsvEmpSalary.SelectedItems != null && lsvEmpSalary.SelectedItems.Count > 0)
                {
                    oEmpSalary = (EmpSalary)lsvEmpSalary.SelectedItems[0].Tag;
                }
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oEmpSalary);

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
                EmpSalary oEmpSalary = new EmpSalary();
                if (lsvEmpSalary.SelectedItems != null && lsvEmpSalary.SelectedItems.Count > 0)
                {
                    oEmpSalary = (EmpSalary)lsvEmpSalary.SelectedItems[0].Tag;
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DEWSRMEntities db = new DEWSRMEntities())
                        {
                            db.EmpSalaries.Attach(oEmpSalary);
                            db.EmpSalaries.Remove(oEmpSalary);
                            db.SaveChanges();
                        }
                        RefreshList();
                    }
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
    }
}
