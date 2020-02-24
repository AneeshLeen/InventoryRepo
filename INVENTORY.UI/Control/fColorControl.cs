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
    public partial class fColorControl : Form
    {
        public List<INVENTORY.DA.Color> _ColorInfos = null;
        public Action ItemChanged;
        ctlCustomControl _ctl;
        bool _IsStockProduct;
        DEWSRMEntities db = null;

        public fColorControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }


        public void ShowDlg(ctlCustomControl ctlCustomControl, bool IsStockProduct)
        {
            _IsStockProduct = IsStockProduct;
            _ctl = ctlCustomControl;
            this.ShowDialog();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    int nCount=1;
                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("SLNo");
                    dt.Columns.Add("ColorCode");

                    _ColorInfos = db.Colors.ToList();

                    if (_ColorInfos != null)
                    {
                        foreach (INVENTORY.DA.Color grd in _ColorInfos)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = grd.ColorID;
                            dr["SLNo"] = nCount;
                            dr["ColorCode"] = grd.Description;

                            dt.Rows.Add(dr);
                            nCount++;
                        }

                        grdColors.DataSource = dt;
                        lblTotal.Text = "Total :" + _ColorInfos.Count().ToString();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fColorControl_Load(object sender, EventArgs e)
        {

            RefreshList();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void grdColors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)grdColors.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdColors.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oID["ID"]);

                INVENTORY.DA.Color oColorInfo = null;

                if (nID > 0)
                {
                    oColorInfo = db.Colors.FirstOrDefault(p => p.ColorID == nID);
                    _ctl.SelectedID = oColorInfo.ColorID;
                    _ctl.Code = oColorInfo.Description;
                }

                if (ItemChanged != null)
                {
                    ItemChanged();
                }
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
