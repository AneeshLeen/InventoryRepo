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
    public partial class fGodowns : Form
    {
        public fGodowns()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fGodown frm = new fGodown();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new Godown(), true);

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
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdGodowns.MainView).GetSelectedRows();
                    DataRowView oCategoryD = (DataRowView)(((GridView)grdGodowns.MainView).GetRow(selRows[0]));

                    int nID = Convert.ToInt32(oCategoryD["ID"]);
                    Godown oGodown = db.Godowns.FirstOrDefault(p => p.GodownID == nID);


                    if (oGodown == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fGodown frm = new fGodown();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oGodown, false);
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
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdGodowns.MainView).GetSelectedRows();
                    DataRowView oCategoryD = (DataRowView)(((GridView)grdGodowns.MainView).GetRow(selRows[0]));

                    int nID = Convert.ToInt32(oCategoryD["ID"]);
                    Godown oGodown = db.Godowns.FirstOrDefault(p => p.GodownID == nID);

                    if (oGodown == null)
                    {
                        MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.Godowns.Attach(oGodown);
                        db.Godowns.Remove(oGodown);
                        db.SaveChanges();
                        MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshList();
                    };
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshList()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("ID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Godowns = db.Godowns.OrderBy(c => c.GodownCode);
                    if (_Godowns != null)
                    {
                        foreach (Godown grd in _Godowns)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.GodownID;
                            dr["Code"] = grd.GodownCode;
                            dr["Name"] = grd.GodownName;
                            dt.Rows.Add(dr);

                        }
                        grdGodowns.DataSource = dt;
                        lblTotal.Text = "Total :" + _Godowns.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fGodowns_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
