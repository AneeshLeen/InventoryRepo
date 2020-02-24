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
    public partial class fSMSFormates : Form
    {
        public fSMSFormates()
        {
            InitializeComponent();
        }
        private void fSMSFormates_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("ID");
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Type");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _SMSFormats = db.SMSFormates.OrderBy(c => c.Code);

                    if (_SMSFormats != null)
                    {
                        foreach (SMSFormate grd in _SMSFormats)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.SMSFormateID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.SMSDescription;

                            //if (grd.SMSType == (int)EnumSMSType.SalesTime)
                            //{
                            //    dr["Type"] = "Sales Time";
                            //}
                            //else
                            //{
                            //    dr["Type"] = "Purchase Time";
                            //}
                            dr["Type"] = (EnumSMSType)grd.SMSType;

                            dt.Rows.Add(dr);

                        }
                        grdSMSFormate.DataSource = dt;
                        lblTotal.Text = "Total :" + _SMSFormats.Count().ToString();
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
            fSMSFormate frm = new fSMSFormate();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new SMSFormate(), true);

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {

                    int[] selRows = ((GridView)grdSMSFormate.MainView).GetSelectedRows();
                    DataRowView oID = (DataRowView)(((GridView)grdSMSFormate.MainView).GetRow(selRows[0]));

                    int nID = Convert.ToInt32(oID["ID"]);
                    SMSFormate oSMSFormate = db.SMSFormates.FirstOrDefault(p => p.SMSFormateID == nID);


                    if (oSMSFormate == null)
                    {
                        MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fSMSFormate frm = new fSMSFormate();
                    frm.ItemChanged = RefreshList;
                    frm.ShowDlg(oSMSFormate, false);
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

                    int[] selRows = ((GridView)grdSMSFormate.MainView).GetSelectedRows();
                    DataRowView oID = (DataRowView)(((GridView)grdSMSFormate.MainView).GetRow(selRows[0]));

                    int nID = Convert.ToInt32(oID["ID"]);
                    SMSFormate oSMSFormate = db.SMSFormates.FirstOrDefault(p => p.SMSFormateID == nID);

                    if (oSMSFormate == null)
                    {
                        MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.SMSFormates.Attach(oSMSFormate);
                        db.SMSFormates.Remove(oSMSFormate);
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

    }
}
