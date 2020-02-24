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
    public partial class fInvestmentControl : Form
    {
        public Action ItemChanged;
        private string _ObjectName = String.Empty;
        public List<Bank> _BankInfos = null;
        ctlCustomControl _ctl;
        DEWSRMEntities db = null;

        public fInvestmentControl()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(string sObjectName, ctlCustomControl ctlCustomControl)
        {
            _ObjectName = sObjectName;
            _ctl = ctlCustomControl;
            this.ShowDialog();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Type");

                    if (_ObjectName == "FAsset")
                    {
                        this.Text = "Fixed Asset";
                        var _Companies = db.Companies;

                        List<ShareInvestmentHead> _SInvestHeadList = db.ShareInvestmentHeads.Where(si => si.ParentId ==(int)EnumParentType.FixedAsset).ToList();

                        if (_SInvestHeadList != null)
                        {
                                foreach (ShareInvestmentHead grd in _SInvestHeadList)
                                {
                                    dr = dt.NewRow();
                                    dr["ID"] = grd.SIHID;
                                    dr["Code"] = grd.Code;
                                    dr["Name"] = grd.Name;
                                    dr["Type"] = "Fixed Asset";

                                    dt.Rows.Add(dr);
                                }

                                grdItems.DataSource = dt;
                                lblTotal.Text = "Total :" + _SInvestHeadList.Count;
                        }

                    }
                    else if(_ObjectName=="CAsset")
                    {
                        this.Text = "Current Asset";
                        var _Companies = db.Companies;

                        List<ShareInvestmentHead> _SInvestHeadList = db.ShareInvestmentHeads.Where(si => si.ParentId == (int)EnumParentType.CurrentAsset).ToList();

                        if (_SInvestHeadList != null)
                        {
                            foreach (ShareInvestmentHead grd in _SInvestHeadList)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SIHID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["Type"] = "Current Asset";
                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _SInvestHeadList.Count;
                        }

                    }
                    else if(_ObjectName=="LReceive")
                    {
                        this.Text = "Liability Receive";
                        var _Companies = db.Companies;

                        List<ShareInvestmentHead> _SInvestHeadList = db.ShareInvestmentHeads.Where(si => si.ParentId == (int)EnumParentType.Liability).ToList();
                        if (_SInvestHeadList != null)
                        {
                            foreach (ShareInvestmentHead grd in _SInvestHeadList)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SIHID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["Type"] = "";
                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _SInvestHeadList.Count;
                        }

                    }
                    else if(_ObjectName=="LPay")
                    {
                        this.Text = "Liability Pay";
                        var _Companies = db.Companies;
                        List<ShareInvestmentHead> _SInvestHeadList = db.ShareInvestmentHeads.Where(si => si.ParentId == (int)EnumParentType.Liability).ToList();


                        if (_SInvestHeadList != null)
                        {
                            foreach (ShareInvestmentHead grd in _SInvestHeadList)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SIHID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["Type"] = "Asset";

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _SInvestHeadList.Count;
                        }

                    }
                    else if(_ObjectName=="Liability")
                    {
                        this.Text = "Liability";
                        var _Companies = db.Companies;

                        List<ShareInvestmentHead> _SInvestHeadList = db.ShareInvestmentHeads.Where(si => si.ParentId==4).ToList();

                        if (_SInvestHeadList != null)
                        {
                            foreach (ShareInvestmentHead grd in _SInvestHeadList)
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SIHID;
                                dr["Code"] = grd.Code;
                                dr["Name"] = grd.Name;
                                dr["Type"] = "Liabilit";

                                dt.Rows.Add(dr);
                            }

                            grdItems.DataSource = dt;
                            lblTotal.Text = "Total :" + _SInvestHeadList.Count;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fItemControl_Load(object sender, EventArgs e)
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

        private void grdItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ShareInvestmentHead oShareHead = null;

                int[] selRows = ((GridView)grdItems.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdItems.MainView).GetRow(selRows[0]));
                int nID = Convert.ToInt32(oID["ID"]);

                if (nID > 0)
                {
                    if (_ObjectName == "FAsset")
                    {
                        this.Text = "Fixed Asset";
                         oShareHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);
                        _ctl.SelectedID = oShareHead.SIHID;
                        _ctl.Code = oShareHead.Code;
                        _ctl.Name = oShareHead.Name;
                    }
                    else if(_ObjectName=="CAsset")
                    {
                        this.Text = "Current Asset";
                        oShareHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);
                        _ctl.SelectedID = oShareHead.SIHID;
                        _ctl.Code = oShareHead.Code;
                        _ctl.Name = oShareHead.Name;
                    }
                    else if (_ObjectName == "LReceive")
                    {
                        this.Text = "Liability Receive";
                        oShareHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);
                        _ctl.SelectedID = oShareHead.SIHID;
                        _ctl.Code = oShareHead.Code;
                        _ctl.Name = oShareHead.Name;


                    }
                    else if (_ObjectName == "LPay")
                    {
                        this.Text = "Liability Pay";
                        oShareHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);
                        _ctl.SelectedID = oShareHead.SIHID;
                        _ctl.Code = oShareHead.Code;
                        _ctl.Name = oShareHead.Name;

                    }
                    else if(_ObjectName=="Liability")
                    {
                        this.Text = "Liability";
                        oShareHead = db.ShareInvestmentHeads.FirstOrDefault(p => p.SIHID == nID);
                        _ctl.SelectedID = oShareHead.SIHID;
                        _ctl.Code = oShareHead.Code;
                        _ctl.Name = oShareHead.Name;
                    }
                }
                if (ItemChanged != null)
                {
                    ItemChanged();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
