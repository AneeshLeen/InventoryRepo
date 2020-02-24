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
    public partial class fModels : Form
    {
        public fModels()
        {
            InitializeComponent();
        }

        private void fModels_Load(object sender, EventArgs e)
        {


            RefreshList();
        }




        private void RefreshList()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("ModelID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Model");
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Models = db.Models.OrderBy(c => c.Code);

                    if (_Models!= null)
                    {
                        foreach (Model grd in _Models)
                        {
                            dr = dt.NewRow();
                            dr["ModelID"] = grd.ModelID;
                            dr["Code"] = grd.Code;
                            dr["Model"] = grd.Description;
                            dt.Rows.Add(dr);

                        }

                        grdModels.DataSource = dt;
                        lblTotal.Text = "Total :" + _Models.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void RefreshList2()
        {
            //try
            //{
            //    using (DEWSRMEntities db = new DEWSRMEntities())
            //    {
            //        var _Models = db.Models;
            //        List<Model> oModelList = _Models.OrderBy(m => m.Code).ToList();

            //        ListViewItem item = null;
            //        lsvModels.Items.Clear();

            //        if (_Models != null)
            //        {
            //            foreach (Model grd in oModelList)
            //            {
            //                item = new ListViewItem();
            //                item.Text = grd.Code;
            //                item.SubItems.Add(grd.Description);
            //                item.Tag = grd;
            //                lsvModels.Items.Add(item);
            //            }

            //            lblTotal.Text = "Total :" + _Models.Count().ToString();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fModel frm = new fModel();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Model(), true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    
                    int[] selRows = ((GridView)grdModels.MainView).GetSelectedRows();
                    DataRowView oModelID = (DataRowView)(((GridView)grdModels.MainView).GetRow(selRows[0]));

                    int nModelID = Convert.ToInt32(oModelID["ModelID"]);
                    Model oModel = db.Models.FirstOrDefault(p => p.ModelID== nModelID);


                    if (oModel== null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fModel frm = new  fModel();
                       frm.ItemChanged = RefreshList;
                      frm.ShowDlg(oModel, false);
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

                    int[] selRows = ((GridView)grdModels.MainView).GetSelectedRows();
                    DataRowView oModelID = (DataRowView)(((GridView)grdModels.MainView).GetRow(selRows[0]));
                    int nModelID = Convert.ToInt32(oModelID["ModelID"]);
                    Model oModel = db.Models.FirstOrDefault(p => p.ModelID == nModelID);
                    if (nModelID > 0)
                    {
                        if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            db.Models.Attach(oModel);
                            db.Models.Remove(oModel);
                            //Save to database
                            db.SaveChanges();

                            RefreshList();
                        }
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

        private void chkIsBangla_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIsBangla.Checked)
            {
                chkIsBangla.Text = "বাংলা";

                this.Text = "সাইজ/কালার";
                lblSize.Text = "সাইজ/কালার";
                //lblTotal.Text = "টোটাল";

                clnCode.Caption = "কোড";
                clnModel.Caption = "সাইজ/কালার";

                btnNew.Text = "&নিউ";
                btnEdit.Text = "&ইডিট";
                btnDelete.Text = "&ডিলিট";
                btnClose.Text = "&ক্লোজ";
            }
            else
            {
                chkIsBangla.Text = "English";

                this.Text = "All Size";
                lblSize.Text = "Size";
                //lblTotal.Text = "Total :";

                clnCode.Caption = "Code";
                clnModel.Caption = "Size";

                btnNew.Text = "&New";
                btnEdit.Text = "&Edit";
                btnDelete.Text = "&Delete";
                btnClose.Text = "&Close";

            }
        }
    }
}
