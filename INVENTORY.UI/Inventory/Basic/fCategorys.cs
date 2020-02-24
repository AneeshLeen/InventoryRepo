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
    public partial class fCategorys : Form
    {
        public fCategorys()
        {
            InitializeComponent();
        }
        private void fCategorys_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            RefreshList();
        }

        private void RefreshList()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("CategoryID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");

            dt.Columns.Add("TaxPercentage");
            dt.Columns.Add("CategoryType");
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Categorys = db.Categorys.OrderBy(c => c.Code);

                    if (_Categorys != null)
                    {
                        foreach (Category grd in _Categorys)
                        {
                            dr = dt.NewRow();
                            dr["CategoryID"] = grd.CategoryID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Description;

                            dr["TaxPercentage"] = grd.VAT;
                            dr["CategoryType"] = grd.CategoryType;
                            dt.Rows.Add(dr);

                        }
                        grdCategorys.DataSource = dt;
                        lblTotal.Text = "Total :" + _Categorys.Count().ToString();
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
            fCategory frm = new fCategory();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Category(),true);
           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdCategorys.MainView).GetSelectedRows();
                    DataRowView oCategoryD = (DataRowView)(((GridView)grdCategorys.MainView).GetRow(selRows[0]));

                    int nCategoryID = Convert.ToInt32(oCategoryD["CategoryID"]);
                    Category oCategory = db.Categorys.FirstOrDefault(p => p.CategoryID == nCategoryID);


                    if (oCategory == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fCategory frm = new fCategory();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oCategory, false);
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

                    int[] selRows = ((GridView)grdCategorys.MainView).GetSelectedRows();
                    DataRowView oCategoryD = (DataRowView)(((GridView)grdCategorys.MainView).GetRow(selRows[0]));

                    int nCategoryID = Convert.ToInt32(oCategoryD["CategoryID"]);
                    Category oCategory = db.Categorys.FirstOrDefault(p => p.CategoryID == nCategoryID);

                    if (oCategory == null)
                    {
                        MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.Categorys.Attach(oCategory);
                        db.Categorys.Remove(oCategory);
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
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdCategorys_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
       
    }
}
