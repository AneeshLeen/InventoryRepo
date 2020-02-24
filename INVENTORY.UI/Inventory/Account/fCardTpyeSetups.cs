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
    public partial class fCardTpyeSetups : Form
    {

        DEWSRMEntities db = null;
        public fCardTpyeSetups()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        private void fCardTpyeSetups_Load(object sender, EventArgs e)
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
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("ID");
            dt.Columns.Add("Code");
            dt.Columns.Add("BankName");
            dt.Columns.Add("CardType");
            dt.Columns.Add("Percentage");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _CardTypeSetups = db.CardTypeSetups.OrderByDescending(ex => ex.Code);
                    if (_CardTypeSetups != null)
                    {

                        foreach (CardTypeSetup grd in _CardTypeSetups)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.CardTypeSetupID;
                            dr["Code"] = grd.Code;
                            dr["BankName"] = grd.Bank.BankName;
                            dr["Percentage"] = grd.Percentage.ToString();
                            dr["CardType"] = grd.CardType.Description;

                            dt.Rows.Add(dr);

                        }
                    }
                    grdExpenditures.DataSource = dt;
                    lblTotal.Text = "Total :" + _CardTypeSetups.Count().ToString();
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
                fCardTypeSetup frm = new fCardTypeSetup();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new CardTypeSetup(),false);

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
                int[] selRows = ((GridView)grdExpenditures.MainView).GetSelectedRows();
                DataRowView oCardTypeSetupID = (DataRowView)(((GridView)grdExpenditures.MainView).GetRow(selRows[0]));
                int nCardTypeSetupID = Convert.ToInt32(oCardTypeSetupID["ID"]);

                CardTypeSetup oCardTypeSetup = db.CardTypeSetups.FirstOrDefault(p => p.CardTypeSetupID == nCardTypeSetupID);

                if (oCardTypeSetup == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                fCardTypeSetup frm = new fCardTypeSetup();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oCardTypeSetup, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvCashTran_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void grdExpenditures_Click(object sender, EventArgs e)
        {

        }
    }
}
