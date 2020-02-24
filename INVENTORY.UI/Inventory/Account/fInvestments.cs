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
    public partial class fInvestments : Form
    {

        public fInvestments()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshFAssetList;
                frm.ShowDlg(new ShareInvestment(), EnumParentType.FixedAsset,EnumTransactionType.Receive);
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
                int[] selRows = ((GridView)grdInvestment.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdInvestment.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oID["ID"]);
                ShareInvestment oShareInvestment = db.ShareInvestments.FirstOrDefault(p => p.SIID == nID);

                if (oShareInvestment == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshFAssetList;
                frm.ShowDlg(oShareInvestment, EnumParentType.FixedAsset, EnumTransactionType.Receive);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ShareInvestment oShareInvestment = new ShareInvestment();
            //    if (lsvInvestment.SelectedItems != null && lsvInvestment.SelectedItems.Count > 0)
            //    {
            //        oShareInvestment = (ShareInvestment)lsvInvestment.SelectedItems[0].Tag;
            //        if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            using (DEWSRMEntities db = new DEWSRMEntities())
            //            {
            //                db.ShareInvestments.Attach(oShareInvestment);
            //                db.ShareInvestments.Remove(oShareInvestment);
            //                //Save to database
            //                db.SaveChanges();
            //            }
            //            RefreshList();
            //        }
            //    }

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fInvestments_Load(object sender, EventArgs e)
        {
            RefreshFAssetList();
       
        }

        private void RefreshFAssetList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    decimal FixedAssetAmt = 0;
                    //var _ShareInvesntments = db.ShareInvestments.Where(a => a.ShareInvestmentHead.Type == (int)EnumInvestmentType.FixedAsset);
                    //var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.Type == (int)EnumInvestmentType.FixedAsset|| a.Type == (int)EnumInvestmentType.FixedAsset);

                    var _ShareInvesntments = db.ShareInvestments.Where(a => a.ShareInvestmentHead.ParentId == (int)EnumParentType.FixedAsset);
                    var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.ParentId == (int)EnumParentType.FixedAsset);

                    
                    ShareInvestmentHead oSIHead=null;
                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("InvHead");
                    dt.Columns.Add("Purpose");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("EntryDate");

                    if (_ShareInvesntments != null)
                    {
                        foreach (ShareInvestment grd in _ShareInvesntments)
                        {
                            oSIHead=_InvesntmentHeads.FirstOrDefault(s=>s.SIHID==grd.SIHID);

                            dr = dt.NewRow();
                            dr["ID"] = grd.SIID;
                            dr["EntryDate"] = grd.EntryDate.ToString("dd MMM yyyy");
                            dr["InvHead"] = oSIHead.Name;
                            dr["Purpose"] = grd.Purpose;
                            dr["Amount"] = grd.Amount;
                            //dr["Type"] = "Fixed Asset";//((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.ShareInvestmentHead.Type.ToString())).ToString(); ;
                            dt.Rows.Add(dr);
                            FixedAssetAmt = FixedAssetAmt + grd.Amount;

                        }

                        grdInvestment.DataSource = dt;
                        lblTotal.Text = "Total :" + _ShareInvesntments.Count().ToString();
                        lblFA.Text = "T.Amount :" + FixedAssetAmt.ToString();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCAssetList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    decimal CAAmt = 0;
                    var _ShareInvesntments = db.ShareInvestments.Where(a => a.ShareInvestmentHead.ParentId == (int)EnumParentType.CurrentAsset);
                    var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.ParentId == (int)EnumParentType.CurrentAsset);

                    ShareInvestmentHead oSIHead = null;
                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("InvHead");
                    dt.Columns.Add("Purpose");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("EntryDate");

                    if (_ShareInvesntments != null)
                    {
                        foreach (ShareInvestment grd in _ShareInvesntments)
                        {
                            oSIHead = _InvesntmentHeads.FirstOrDefault(s => s.SIHID == grd.SIHID);

                            dr = dt.NewRow();
                            dr["ID"] = grd.SIID;
                            dr["EntryDate"] = grd.EntryDate.ToString("dd MMM yyyy");
                            dr["InvHead"] = oSIHead.Name;
                            dr["Purpose"] = grd.Purpose;
                            dr["Amount"] = grd.Amount;
                            //dr["Type"] = "Current Asset";//((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.ShareInvestmentHead.Type.ToString())).ToString(); ;
                            dt.Rows.Add(dr);
                            CAAmt = CAAmt + grd.Amount;

                        }

                        grdCAssets.DataSource = dt;
                        lblCAsset.Text = "Total :" + _ShareInvesntments.Count().ToString();
                        lblCA.Text = "T.Amount :" + CAAmt.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshListLiability()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    //var _ShareInvesntments = db.ShareInvestments.Where(a => a.TransactionType == (int)EnumTransactionType.Receive);
                    //var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.Type == (int)EnumInvestmentType.Loan || a.Type == (int)EnumInvestmentType.FromOwner || a.Type == (int)EnumInvestmentType.Others);

                    //var _ShareInvesntments = db.ShareInvestments.Where(a => a.ShareInvestmentHead.ParentId == 4);
                    //var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.ParentId == 4);

                    //var liabilities = from si in _ShareInvesntments
                    //                  join sh in _InvesntmentHeads
                    //                  on si.SIHID equals sh.SIHID
                    //                  select new
                    //                  {
                    //                      si.Amount,
                    //                      si.TransactionType,                                        
                    //                      sh.Type
                    //                  };

                    //var liabilitiesSummary = from ls in liabilities
                    //                         group ls by new { ls.Type,  ls.TransactionType } into g
                    //                         select new
                    //                         {
                    //                             g.Key.Type,                                                
                    //                             g.Key.TransactionType,
                    //                             TotalAmt = g.Sum(s => s.Amount)
                    //                         };


                    //DataTable dt = new DataTable();
                    //DataRow dr = null;

                    //dt.Columns.Add("ID");
                    //dt.Columns.Add("InvHead");
                    //dt.Columns.Add("Purpose");
                    //dt.Columns.Add("Amount");
                    //dt.Columns.Add("Type");

                    //if (_ShareInvesntments != null)
                    //{
                    //    foreach (var grd in liabilitiesSummary)
                    //    {

                    //        if (grd.TransactionType == (int)EnumTransactionType.Receive && grd.Type != (int)EnumInvestmentType.FixedAsset)
                    //        {
                    //            dr = dt.NewRow();
                    //            dr["ID"] = 1;
                    //            if (grd.Type == (int)EnumInvestmentType.FromOwner)
                    //                dr["InvHead"] = "FromOwner";
                    //            else if (grd.Type == (int)EnumInvestmentType.Loan)
                    //                dr["InvHead"] = "Loan";
                    //            else if (grd.Type == (int)EnumInvestmentType.Others)
                    //                dr["InvHead"] = "Others";

                    //            dr["Amount"] = grd.TotalAmt;
                    //            dr["Type"] = "";
                    //            dt.Rows.Add(dr);
                    //        }
                    //    }
                    //    grdLiability.DataSource = dt;
                    //    label1.Text = "Total :" + _ShareInvesntments.Count().ToString();
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshListLiabilityRec()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    decimal LRAmt = 0;
                    var _ShareInvesntments = db.ShareInvestments.Where(a => a.TransactionType == (int)EnumTransactionType.Receive 
                        && a.ShareInvestmentHead.ParentId==(int)EnumParentType.Liability);
                    var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.ParentId == (int)EnumParentType.Liability);
                    ShareInvestmentHead oSIHead = null;
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    int Count = 0;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("InvHead");
                    dt.Columns.Add("Purpose");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("EntryDate");


                    if (_ShareInvesntments != null)
                    {
                        Count = 0;
                        foreach (ShareInvestment grd in _ShareInvesntments)
                        {
                            oSIHead = _InvesntmentHeads.FirstOrDefault(s => s.SIHID == grd.SIHID);
                            if (oSIHead != null)//&& oSIHead.Type!=(int)EnumInvestmentType.FixedAsset
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SIID;
                                dr["EntryDate"] = grd.EntryDate.ToString("dd MMM yyyy");
                                dr["InvHead"] = oSIHead.Name;
                                dr["Purpose"] = grd.Purpose;
                                dr["Amount"] = grd.Amount;
                                //dr["Type"] = "";//((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.ShareInvestmentHead.Type.ToString())).ToString(); ;
                                dt.Rows.Add(dr);
                                Count++;
                                LRAmt = LRAmt + grd.Amount;
                            }                         
                        }

                        grdLiabilitiesRec.DataSource = dt;
                        label2.Text = "Total :" + Count.ToString();
                        lblLR.Text = "T.Amount :" + LRAmt.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshListLiabilityPay()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    //var _ShareInvesntments = db.ShareInvestments.Where(a => a.TransactionType == (int)EnumTransactionType.Pay);
                    //var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.Type == (int)EnumInvestmentType.Loan || a.Type == (int)EnumInvestmentType.FromOwner || a.Type == (int)EnumInvestmentType.Others);

                    decimal LPAmt = 0;
                    var _ShareInvesntments = db.ShareInvestments.Where(a => a.TransactionType == (int)EnumTransactionType.Pay 
                        && a.ShareInvestmentHead.ParentId == (int)EnumParentType.Liability);
                    var _InvesntmentHeads = db.ShareInvestmentHeads.Where(a => a.ParentId == (int)EnumParentType.Liability);

                    ShareInvestmentHead oSIHead = null;
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    int Count = 0;

                    dt.Columns.Add("ID");
                    dt.Columns.Add("InvHead");
                    dt.Columns.Add("Purpose");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("EntryDate");

                    if (_ShareInvesntments != null)
                    {
                        Count = 0;
                        foreach (ShareInvestment grd in _ShareInvesntments)
                        {
                            oSIHead = _InvesntmentHeads.FirstOrDefault(s => s.SIHID == grd.SIHID);
                            if (oSIHead != null)//&& oSIHead.Type!=(int)EnumInvestmentType.FixedAsset
                            {
                                dr = dt.NewRow();
                                dr["ID"] = grd.SIID;
                                dr["EntryDate"] = grd.EntryDate.ToString("dd MMM yyyy");
                                dr["InvHead"] = oSIHead.Name;
                                dr["Purpose"] = grd.Purpose;
                                dr["Amount"] = grd.Amount;
                                //dr["Type"] = "";//((EnumInvestmentType)Enum.Parse(typeof(EnumInvestmentType), grd.ShareInvestmentHead.Type.ToString())).ToString(); ;
                                dt.Rows.Add(dr);
                                Count++;
                                LPAmt = LPAmt + grd.Amount;
                            }
                        }

                        grdLiabilitiesPay.DataSource = dt;
                        label3.Text = "Total :" + Count.ToString();
                        lblLP.Text = "T.Amount :" + LPAmt.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsvInvestment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void grdInvestment_Click(object sender, EventArgs e)
        {

        }

        private void btnNewLiability_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    fInvestment frm = new fInvestment();
            //    frm.ItemChanged = RefreshListLiability;
            //    frm.ShowDlg(new ShareInvestment(),4);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnLEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //DEWSRMEntities db = new DEWSRMEntities();
                //int[] selRows = ((GridView)grdLiability.MainView).GetSelectedRows();
                //DataRowView oID = (DataRowView)(((GridView)grdLiability.MainView).GetRow(selRows[0]));

                //int nID = Convert.ToInt32(oID["ID"]);
                //ShareInvestment oShareInvestment = db.ShareInvestments.FirstOrDefault(p => p.SIID == nID);

                //if (oShareInvestment == null)
                //{
                //    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //fInvestment frm = new fInvestment();
                //frm.ItemChanged = RefreshListLiability;
                //frm.ShowDlg(oShareInvestment, 4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbcInvestment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcInvestment.SelectedIndex == 0)
            {
                RefreshFAssetList();
            }
            else if(tbcInvestment.SelectedIndex==1)
            {
                RefreshCAssetList();
            }
            //else if (tbcInvestment.SelectedIndex == 2)
            //{
            //    RefreshListLiability();
            //}
            else if (tbcInvestment.SelectedIndex == 2)
            {
                RefreshListLiabilityRec();             
            }
            else if (tbcInvestment.SelectedIndex == 3)
            {
                RefreshListLiabilityPay();
            }

        }

        private void btnNewLiabilityRec_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshListLiabilityRec;
                frm.ShowDlg(new ShareInvestment(), EnumParentType.Liability, EnumTransactionType.Receive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewLiabilityPay_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshListLiabilityPay;
                frm.ShowDlg(new ShareInvestment(),EnumParentType.Liability,EnumTransactionType.Pay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecLoan_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdLiabilitiesRec.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdLiabilitiesRec.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oID["ID"]);
                ShareInvestment oShareInvestment = db.ShareInvestments.FirstOrDefault(p => p.SIID == nID);

                if (oShareInvestment == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshListLiabilityRec;
                frm.ShowDlg(oShareInvestment, EnumParentType.Liability, EnumTransactionType.Receive);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPayLoan_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdLiabilitiesPay.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdLiabilitiesPay.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oID["ID"]);
                ShareInvestment oShareInvestment = db.ShareInvestments.FirstOrDefault(p => p.SIID == nID);

                if (oShareInvestment == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshListLiabilityPay;
                frm.ShowDlg(oShareInvestment, EnumParentType.Liability,EnumTransactionType.Pay);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNewCAsset_Click(object sender, EventArgs e)
        {
            try
            {
                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshCAssetList;
                frm.ShowDlg(new ShareInvestment(), EnumParentType.CurrentAsset,EnumTransactionType.Receive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLRClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLPClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditCAsset_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdCAssets.MainView).GetSelectedRows();
                DataRowView oID = (DataRowView)(((GridView)grdCAssets.MainView).GetRow(selRows[0]));

                int nID = Convert.ToInt32(oID["ID"]);
                ShareInvestment oShareInvestment = db.ShareInvestments.FirstOrDefault(p => p.SIID == nID);

                if (oShareInvestment == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fInvestment frm = new fInvestment();
                frm.ItemChanged = RefreshCAssetList;
                frm.ShowDlg(oShareInvestment, EnumParentType.CurrentAsset,EnumTransactionType.Receive);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCloseAsset_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
