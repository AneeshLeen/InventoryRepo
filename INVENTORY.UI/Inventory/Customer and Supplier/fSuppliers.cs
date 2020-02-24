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
using Microsoft.Reporting.WinForms;
using DevExpress.XtraGrid.Views.Grid;


namespace INVENTORY.UI
{
    public partial class fSuppliers : Form
    {

        DEWSRMEntities db = null;
        public fSuppliers()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void fSuppliers_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                if (db != null)
                    db.Dispose();
                db = new DEWSRMEntities();
                List<Supplier> _Suppliers = db.Suppliers.OrderBy(s => s.Code).ToList();

                if (_Suppliers != null)
                {
                    grdCompany.DataSource = _Suppliers;

                    lblTotal.Text = "Total :" + _Suppliers.Count().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event

        private void btnNew_Click(object sender, EventArgs e)
        {
            fSupplier frm = new fSupplier();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Supplier(),true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdCompany.MainView).GetSelectedRows();
                Supplier oSupplier = (Supplier)(((GridView)grdCompany.MainView).GetRow(selRows[0]));

                if (oSupplier == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fSupplier frm = new fSupplier();

                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oSupplier, false);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdCompany.MainView).GetSelectedRows();
                Supplier oSupplier = (Supplier)(((GridView)grdCompany.MainView).GetRow(selRows[0]));

                if (oSupplier == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    db.Suppliers.Attach(oSupplier);
                    db.Suppliers.Remove(oSupplier);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

      
        private void grdCompany_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
