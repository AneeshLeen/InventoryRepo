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
    public partial class fColorInfos : Form
    {
        public fColorInfos()
        {
            InitializeComponent();
        }

        private void fCompanies_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add("ColorInfosID");
                dt.Columns.Add("SLNo");
                dt.Columns.Add("Code");

                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _ColorInfos = db.Colors.OrderBy(c => c.ColorID);

                    if (_ColorInfos != null)
                    {
                        foreach (INVENTORY.DA.Color grd in _ColorInfos)
                        {
                            {
                                dr = dt.NewRow();
                                dr["ColorInfosID"] = grd.ColorID;
                                dr["SLNo"] = grd.ColorID.ToString();
                                dr["Code"] = grd.Description;
                            }
                            dt.Rows.Add(dr);
                        }

                        grdColorInfos.DataSource = dt;
                        lblTotal.Text = "Total :" + _ColorInfos.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fColorInfo frm = new fColorInfo();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new INVENTORY.DA.Color(), true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdColorInfos.MainView).GetSelectedRows();
                    DataRowView oColorInfosD = (DataRowView)(((GridView)grdColorInfos.MainView).GetRow(selRows[0]));

                    int nColorInfosID = Convert.ToInt32(oColorInfosD["ColorInfosID"]);
                    INVENTORY.DA.Color oColorInfo = db.Colors.FirstOrDefault(p => p.ColorID == nColorInfosID);


                    if (oColorInfo == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    fColorInfo frm = new fColorInfo();

                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oColorInfo, false);
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
                int[] selRows = ((GridView)grdColorInfos.MainView).GetSelectedRows();
                DataRowView oColorInfosID = (DataRowView)(((GridView)grdColorInfos.MainView).GetRow(selRows[0]));
                int nColorInfosID = Convert.ToInt32(oColorInfosID["ColorInfosID"]);
                INVENTORY.DA.Color oColorInfo = db.Colors.FirstOrDefault(p => p.ColorID == nColorInfosID);

                if (oColorInfo == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {



                    db.Colors.Attach(oColorInfo);
                    db.Colors.Remove(oColorInfo);

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
        private void grdColorInfos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

    }
}
