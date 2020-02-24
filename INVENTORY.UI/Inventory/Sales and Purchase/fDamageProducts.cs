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
    public partial class fDamageProducts : Form
    {
        public fDamageProducts()
        {
            InitializeComponent();
        }

        private void fDamageProducts_Load(object sender, EventArgs e)
        {
            RefreshList();
            ControlPermission();
        }

        public void ControlPermission()
        {
            User oUser = Global.CurrentUser;
            if (oUser != null && oUser.UserType == 2)
            {
                btnEdit.Enabled = false;
            }

        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _DamageProducts = db.DamageProducts;

                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("EDate");
                    dt.Columns.Add("Product");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("PRate");
                    dt.Columns.Add("TPrice");


                    if (_DamageProducts != null)
                    {
                        foreach (DamageProduct dp in _DamageProducts)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = dp.DamageProID;
                            dr["EDate"] = Convert.ToDateTime(dp.EntryDate).ToString("dd MMM yyyy");
                            dr["Product"] = dp.Product.ProductName;
                            dr["Qty"] = dp.Qty;// Math.Round(dp.Qty, 2).ToString();
                            dr["PRate"] = dp.UnitPrice;// Math.Round(dp.UnitPrice, 2).ToString();//dp.UnitPrice.ToString();
                            dr["TPrice"] = dp.TotalPrice;//Math.Round(dp.TotalPrice, 2).ToString();
                            dt.Rows.Add(dr);

                        }
                        grdDProducts.DataSource = dt;
                        lblTotal.Text = "Total :" + _DamageProducts.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fDamageProduct frm = new fDamageProduct();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new DamageProduct());
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
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdDProducts.MainView).GetSelectedRows();
                DataRowView oDID = (DataRowView)(((GridView)grdDProducts.MainView).GetRow(selRows[0]));
                DataRowView oEDate = (DataRowView)(((GridView)grdDProducts.MainView).GetRow(selRows[0]));

                int nDPID = Convert.ToInt32(oDID["ID"]);
                DateTime dEDate = Convert.ToDateTime(oEDate["EDate"]);

                DamageProduct oDProduct = db.DamageProducts.FirstOrDefault(p => p.DamageProID == nDPID);

                if (oDProduct == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Global.CurrentUser.ISEditable == 1)
                {
                    if (dEDate < DateTime.Today)
                    {
                        MessageBox.Show("This damage order can't be editable, Please contact BD Team", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                fDamageProduct frm = new fDamageProduct();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oDProduct);
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
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdDProducts.MainView).GetSelectedRows();
                DataRowView oDesignationID = (DataRowView)(((GridView)grdDProducts.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oDesignationID["ID"]);
                DamageProduct oDP = db.DamageProducts.FirstOrDefault(p => p.DamageProID == nID);

                if (oDP == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DamageProducts.Attach(oDP);
                    db.DamageProducts.Remove(oDP);
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
    }
}
