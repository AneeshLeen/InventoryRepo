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
    public partial class fInvestmentHeads : Form
    {
        public fInvestmentHeads()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestmentHead frm = new fInvestmentHead();
                frm.ItemChanged = RefreshFixedList;
                frm.ShowDlg(new ShareInvestmentHead(), true,2);
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
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdInvFixed.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdInvFixed.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oExpenseID["ID"]);
                ShareInvestmentHead oSIHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);

                if (oSIHead == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestmentHead frm = new fInvestmentHead();
                frm.ItemChanged = RefreshFixedList;
                frm.ShowDlg(oSIHead, false,2);

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
                int[] selRows = ((GridView)grdInvFixed.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdInvFixed.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oExpenseID["ID"]);
                ShareInvestmentHead oShareInvestmentHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);

                if (oShareInvestmentHead == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ShareInvestmentHeads.Attach(oShareInvestmentHead);
                    db.ShareInvestmentHeads.Remove(oShareInvestmentHead);
                    db.SaveChanges();

                    MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshFixedList();
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

        private void RefreshFixedList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<ShareInvestmentHead> oShareInvestmentHeads = db.ShareInvestmentHeads.OrderBy(ex => ex.Code).Where(InvF=>InvF.ParentId==2).ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    //dt.Columns.Add("Type");

                    if (oShareInvestmentHeads != null)
                    {
                        foreach (ShareInvestmentHead grd in oShareInvestmentHeads)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.SIHID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Name;
                           // dr["Type"] = ((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.Type.ToString())).ToString();
                            dt.Rows.Add(dr);
                        }

                        grdInvFixed.DataSource = dt;
                        lblTotal.Text = "Total :" + oShareInvestmentHeads.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RefreshCurrentList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<ShareInvestmentHead> oShareInvestmentHeads = db.ShareInvestmentHeads.OrderBy(ex => ex.Code).Where(InvF => InvF.ParentId == 3).ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    //dt.Columns.Add("Type");

                    if (oShareInvestmentHeads != null)
                    {
                        foreach (ShareInvestmentHead grd in oShareInvestmentHeads)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.SIHID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Name;
                            //dr["Type"] = ((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.Type.ToString())).ToString();
                            dt.Rows.Add(dr);
                        }

                        grdInvCurrent.DataSource = dt;
                        label1.Text = "Total :" + oShareInvestmentHeads.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RefreshLiabilityList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<ShareInvestmentHead> oShareInvestmentHeads = db.ShareInvestmentHeads.OrderBy(ex => ex.Code).Where(InvF => InvF.ParentId == 4).ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    //dt.Columns.Add("Type");

                    if (oShareInvestmentHeads != null)
                    {
                        foreach (ShareInvestmentHead grd in oShareInvestmentHeads)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.SIHID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Name;
                            //dr["Type"] = ((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.Type.ToString())).ToString();
                            dt.Rows.Add(dr);
                        }

                        grdLiability.DataSource = dt;
                        label2.Text = "Total :" + oShareInvestmentHeads.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fInvestmentHeads_Load(object sender, EventArgs e)
        {
            RefreshFixedList();
        }

        private void tbInvestment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbInvestment.SelectedIndex == 0)
            {
                RefreshFixedList();
            }
            else if (tbInvestment.SelectedIndex == 1)
            {
                RefreshCurrentList();
            }
            else if(tbInvestment.SelectedIndex==2)
            {
                RefreshLiabilityList();
            }
        }

        private void btnNewInvCurr_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestmentHead frm = new fInvestmentHead();
                frm.ItemChanged = RefreshCurrentList;
                frm.ShowDlg(new ShareInvestmentHead(), true, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditInvCurr_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdInvCurrent.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdInvCurrent.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oExpenseID["ID"]);
                ShareInvestmentHead oSIHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);

                if (oSIHead == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestmentHead frm = new fInvestmentHead();
                frm.ItemChanged = RefreshCurrentList;
                frm.ShowDlg(oSIHead, false, 3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelInvCurr_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdInvCurrent.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdInvCurrent.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oExpenseID["ID"]);
                ShareInvestmentHead oShareInvestmentHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);

                if (oShareInvestmentHead == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ShareInvestmentHeads.Attach(oShareInvestmentHead);
                    db.ShareInvestmentHeads.Remove(oShareInvestmentHead);
                    db.SaveChanges();

                    MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCurrentList();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }

        }

        private void btnCloseInvCurr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewLiability_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestmentHead frm = new fInvestmentHead();
                frm.ItemChanged = RefreshLiabilityList;
                frm.ShowDlg(new ShareInvestmentHead(), true, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditLiability_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdLiability.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdLiability.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oExpenseID["ID"]);
                ShareInvestmentHead oSIHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);

                if (oSIHead == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestmentHead frm = new fInvestmentHead();
                frm.ItemChanged = RefreshLiabilityList;
                frm.ShowDlg(oSIHead, false, 4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelLiability_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdLiability.MainView).GetSelectedRows();
                DataRowView oExpenseID = (DataRowView)(((GridView)grdLiability.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oExpenseID["ID"]);
                ShareInvestmentHead oShareInvestmentHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);

                if (oShareInvestmentHead == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ShareInvestmentHeads.Attach(oShareInvestmentHead);
                    db.ShareInvestmentHeads.Remove(oShareInvestmentHead);
                    db.SaveChanges();

                    MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshLiabilityList();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }

        }

        private void btnCloseLiability_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
