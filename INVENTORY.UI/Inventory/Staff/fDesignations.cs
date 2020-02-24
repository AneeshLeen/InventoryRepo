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
    public partial class fDesignations : Form
    {
        public fDesignations()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<Designation> _Designations = db.Designations.OrderBy(ex => ex.Code).ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("DesignationID");

                    if (_Designations != null)
                    {
                        foreach (INVENTORY.DA.Designation grd in _Designations)
                        {
                            dr = dt.NewRow();
                            dr["DesignationID"] = grd.DesignationID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Description;
                            dt.Rows.Add(dr);
                        }

                        grdDesignation.DataSource = dt;
                        lblTotal.Text = "Total :" + _Designations.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fDesignations_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fDesignation frm = new fDesignation();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Designation(),true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DEWSRMEntities db = new DEWSRMEntities();
            int[] selRows = ((GridView)grdDesignation.MainView).GetSelectedRows();
            DataRowView oDesignationID = (DataRowView)(((GridView)grdDesignation.MainView).GetRow(selRows[0]));

            int nDesignationID = Convert.ToInt32(oDesignationID["DesignationID"]);
            Designation oDesignation = db.Designations.FirstOrDefault(p => p.DesignationID == nDesignationID);

            if (oDesignation == null)
            {
                MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fDesignation frm = new fDesignation();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(oDesignation, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdDesignation.MainView).GetSelectedRows();
                DataRowView oDesignationID = (DataRowView)(((GridView)grdDesignation.MainView).GetRow(selRows[0]));
                int nDesignationID = Convert.ToInt32(oDesignationID["DesignationID"]);
                Designation oDesignation = db.Designations.FirstOrDefault(p => p.DesignationID == nDesignationID);

                if (oDesignation == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Designations.Attach(oDesignation);
                    db.Designations.Remove(oDesignation);
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

        private void grdDesignation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
