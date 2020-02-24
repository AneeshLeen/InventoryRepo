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
using DevExpress.XtraGrid.Views.Grid;

namespace INVENTORY.UI
{
    public partial class fCustomers : Form
    {

        DEWSRMEntities db = null;
        List<Customer> _CustomerList = null;
        public fCustomers()
        {
            InitializeComponent();
            db = new DEWSRMEntities();
        }
        private void fCustomers_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void RefreshList1111()
        {
            try
            {
                {
                    if (db != null)
                        db.Dispose();
                    db = new DEWSRMEntities();
                    List<Customer> _Customers = db.Customers.OrderBy(o => o.Code).ToList();
                    if (_Customers != null)
                    {
                        grdCustomer.DataSource = _Customers;

                        lblTotal.Text = "Total :" + _Customers.Count().ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshList()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("ID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");
            dt.Columns.Add("ContactNo");
            dt.Columns.Add("TotalDue");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Customers = db.Customers.OrderBy(c => c.Code);
                    if (_Customers != null)
                    {
                        foreach (Customer grd in _Customers)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.CustomerID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Name;
                            dr["Address"] = grd.Address;
                            dr["ContactNo"] = grd.ContactNo;
                            dr["TotalDue"] = grd.TotalDue + grd.CreditDue;

                            dt.Rows.Add(dr);

                        }
                        grdCustomer.DataSource = dt;
                        lblTotal.Text = "Total :" + _Customers.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fCustomer frm = new fCustomer();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new Customer(),true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdCustomer.MainView).GetSelectedRows();
                DataRowView oCusID = (DataRowView)(((GridView)grdCustomer.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oCusID["ID"]);
                Customer oCustomer = db.Customers.FirstOrDefault(p => p.CustomerID == nID);


                if (oCustomer == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fCustomer frm = new fCustomer();

                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oCustomer, false);
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
                int[] selRows = ((GridView)grdCustomer.MainView).GetSelectedRows();
                DataRowView oCusID = (DataRowView)(((GridView)grdCustomer.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oCusID["ID"]);
                Customer oCustomer = db.Customers.FirstOrDefault(p => p.CustomerID == nID);

                if (oCustomer == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    db.Customers.Attach(oCustomer);
                    db.Customers.Remove(oCustomer);
                    //Save to database
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
        #endregion       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdCustomer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
