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

namespace INVENTORY.UI
{
    public partial class fDamageProduct : Form
    {
        Product _oProduct = new Product();
        DamageProduct _DamageProduct = null;
        public Action ItemChanged;
        DEWSRMEntities db = null;
        Stock _stock = null;
        StockDetail _StockDetail = null;

        public fDamageProduct()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(DamageProduct oDamageProduct)
        {
            _DamageProduct = oDamageProduct;
            if(_DamageProduct.DamageProID==0)
            {
                _DamageProduct = new DamageProduct();
                _DamageProduct.CreatedBy = Global.CurrentUser.UserID;
                _DamageProduct.CreateDate = DateTime.Now;

            }
            else
            {
                _DamageProduct.ModifiedDate = (DateTime)DateTime.Today;
                _DamageProduct.ModifiedBy = (int)Global.CurrentUser.UserID;

            }
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            ctlProduct.SelectedID = _DamageProduct.SDetailID!=null? (int)_DamageProduct.SDetailID:0;
            numUP.Value = _DamageProduct.UnitPrice!=null? (decimal)_DamageProduct.UnitPrice:0;
            dtpDate.Value = _DamageProduct.EntryDate!=DateTime.MinValue? (DateTime)_DamageProduct.EntryDate:DateTime.Now;
            numQTY.Value = _DamageProduct.Qty != null ? (decimal)_DamageProduct.Qty : 0;
            numTPrice.Value=_DamageProduct.TotalPrice!=null?(decimal)_DamageProduct.TotalPrice:0;

        }

        private void RefreshObject()
        {
            _DamageProduct.ProductID = _oProduct.ProductID;//ctlProduct.SelectedID;
            _DamageProduct.EntryDate = dtpDate.Value;
            _DamageProduct.UnitPrice = numUP.Value;
            _DamageProduct.Qty = numQTY.Value;
            _DamageProduct.TotalPrice = numTPrice.Value;
            _DamageProduct.SDetailID = ctlProduct.SelectedID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool isNew = false;

                    #region Stock
                    if (_stock != null)
                    {
                        _stock.Quantity = _stock.Quantity - numQTY.Value;
                    }

                    if (_StockDetail != null)
                        _StockDetail.Status = (int)EnumStockDetailStatus.Damage;

                    //if (_oProduct.IsBarCode == 3)
                    //{
                    //    if (numStock.Value == 0)
                    //    {
                    //        _StockDetail.Status = (int)EnumStockDetailStatus.Sold;
                    //    }
                    //}
                    //else
                    //{
                    //    _StockDetail.Status = (int)EnumStockDetailStatus.Sold;
                    //}

                    #endregion

                    if (_DamageProduct.DamageProID <= 0)
                    {
                        RefreshObject();
                        _DamageProduct.CreatedBy = Global.CurrentUser.UserID;
                        _DamageProduct.CreateDate = DateTime.Now;
                        _DamageProduct.SDetailID = _StockDetail.SDetailID;
                        //_DamageProduct.DamageProID = db.DamageProducts.Count() > 0 ? db.DamageProducts.Max(obj => obj.DamageProID) + 1 : 1;
                        db.DamageProducts.Add(_DamageProduct);
                        isNew = true;
                    }
                    else
                    {
                        _DamageProduct = db.DamageProducts.FirstOrDefault(obj => obj.DamageProID == _DamageProduct.DamageProID);
                        RefreshObject();
                        _DamageProduct.SDetailID = ctlProduct.SelectedID;
                        _DamageProduct.ModifiedDate = (DateTime)DateTime.Today;
                        _DamageProduct.ModifiedBy = (int)Global.CurrentUser.UserID;

                    }

                    db.SaveChanges();
                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!isNew)
                    {
                        if (ItemChanged != null)
                        {
                            ItemChanged();
                        }
                        this.Close();
                    }
                    else
                    {
                        if (ItemChanged != null)
                        {
                            ItemChanged();
                        }
                        _DamageProduct = new DamageProduct();
                        RefreshValue();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException == null)
                        MessageBox.Show(ex.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.InnerException.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void ctlProduct_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (ctlProduct.SelectedID > 0)
                {
                    _StockDetail = (StockDetail)(db.StockDetails.FirstOrDefault(o => o.SDetailID == ctlProduct.SelectedID));

                    if (_StockDetail != null)
                    {
                        _stock = db.Stocks.FirstOrDefault(st => st.StockID == _StockDetail.StockID);
                        numUP.Value = (decimal)_stock.PMPrice;
                        numStock.Value = (decimal)_stock.Quantity;
                    }

                    if (_StockDetail != null)
                    {
                        _oProduct = _StockDetail.Product;
                        if (_oProduct != null)
                        {
                            if (_oProduct.ProductType == (int)EnumProductType.BarCode)
                            {
                                numQTY.Value = 1;
                                numQTY.Enabled = false;
                            }
                            else if (_oProduct.ProductType == (int)EnumProductType.SerialNo)
                            {
                                numQTY.Value = 1;
                                numQTY.Enabled = false;
                            }
                            else
                            {
                                numQTY.Enabled = true;
                                numQTY.Value = 0;
                            }                        
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void fDamageProduct_Load(object sender, EventArgs e)
        {

        }

        private void numQTY_ValueChanged(object sender, EventArgs e)
        {
            numTPrice.Value = (numQTY.Value * numUP.Value);
        }

        private void numUP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numQTY_Enter(object sender, EventArgs e)
        {
            numQTY.Select(0, numQTY.Text.Length);

        }
    }
}
