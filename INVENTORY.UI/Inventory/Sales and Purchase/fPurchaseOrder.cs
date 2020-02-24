using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using INVENTORY.DA;
using Microsoft.Reporting.WinForms;

namespace INVENTORY.UI
{
    public partial class fPurchaseOrder : Form
    {
        bool ForNewSupplier = false;
        List<POrderDetail> _PrePOrderDetails = new List<POrderDetail>();
        POrderDetail _POrderDetail = null;
        public Action ItemChanged;
        POrder _PrePOrder = null;
        Supplier _oSupplier = null;
        Stock _Stock = null;
        DEWSRMEntities db = null;
        decimal _SuppPaymentDue = 0;
        decimal _SuppPrvDue = 0;
        int nProductID = 0;
        Product _Product = null;
        INVENTORY.DA.Color _Color = null;
        decimal _PreviousFlatDiscount;

        public fPurchaseOrder()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
        }

        public void ShowDlg(int oPrePOrderID)
        {
            _PrePOrder = db.POrders.FirstOrDefault(o => o.POrderID == oPrePOrderID);

            if (_PrePOrder == null)
            {
                _PrePOrder = new POrder();
                _PrePOrder.CreatedBy = Global.CurrentUser.UserID;
                _PrePOrder.CreateDate = DateTime.Now;
            }
            else
            {
                _SuppPaymentDue = (decimal)_PrePOrder.PaymentDue;
                _SuppPrvDue = _PrePOrder.Supplier.TotalDue - _SuppPaymentDue;
                _PrePOrder.ModifiedBy = Global.CurrentUser.UserID;
                _PrePOrder.ModifiedDate = DateTime.Now;
                _PreviousFlatDiscount = _PrePOrder.TDiscount;
                ctlPreOrCompany.Enabled = false;
            }

            if (_PrePOrder.POrderID > 0)
            {
                StockReturn();
                //numTDP.Value = 0;
            }
            ctlColor.SelectedID = 1;
            //PopulateColorCbo();
            RefreshValue();
            RefreshGrid();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            try
            {
                txtPONo.Text = _PrePOrder.ChallanNo != null ? _PrePOrder.ChallanNo : "";

                dtpPreOrDate.Value = _PrePOrder.OrderDate != DateTime.MinValue ? _PrePOrder.OrderDate : DateTime.Now;
                numQTY.Value = 0;

                numGrandTotal.ValueChanged -= numGrandTotal_ValueChanged;
                numGrandTotal.Value = _PrePOrder.GrandTotal != null ? (decimal)_PrePOrder.GrandTotal : 0;
                numGrandTotal.ValueChanged += numGrandTotal_ValueChanged;

                numTotalDis.ValueChanged -= numTotalDis_ValueChanged;
                numTotalDis.Value = _PrePOrder.TDiscount != null ? (decimal)_PrePOrder.TDiscount : 0;
                numTotalDis.ValueChanged -= numTotalDis_ValueChanged;

                numTotal.Value = _PrePOrder.TotalAmt != null ? (decimal)(_PrePOrder.TotalAmt - _PrePOrder.LaborCost) : 0;
                numTempNetTotalAmt.Value = Convert.ToDecimal(_PrePOrder.TotalAmt + _PrePOrder.TDiscount);

                //numTempNetTotalAmt.Value = numTotal.Value;
                numPaidAmt.Value = _PrePOrder.RecAmt != null ? (decimal)_PrePOrder.RecAmt : 0;
                numTotalDueAmt.Value = _PrePOrder.PaymentDue != null ? (decimal)_PrePOrder.PaymentDue : 0;
                numPrvDue.Value = _PrePOrder.TotalDue != null ? (decimal)_PrePOrder.TotalDue : 0;

                numTDP.ValueChanged -= numTDP_ValueChanged;
                numTDP.Value = _PrePOrder.TDPer != null ? (decimal)_PrePOrder.TDPer : 0;
                numTDP.ValueChanged += numTDP_ValueChanged;

                numTotalDis.ValueChanged -= numTotalDis_ValueChanged;
                numTotalDis.Value = _PrePOrder.TDiscount != null ? (decimal)_PrePOrder.TDiscount : 0;
                numTotalDis.ValueChanged += numTotalDis_ValueChanged;

                numNetDiscount.Value = _PrePOrder.NetDiscount != null ? (decimal)_PrePOrder.NetDiscount : 0;
                numLaborAmt.Value = _PrePOrder.LaborCost;
                ctlColor.SelectedID = 1;
                ctlPreOrCompany.SelectedID = _PrePOrder.SupplierID != null ? _PrePOrder.SupplierID : 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numQTY_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numQTY.Value > 0)
                {
                    numUTotalAmt.Value = (numQTY.Value * numPRate.Value);
                    if (_Product.ProductType == (int)EnumProductType.SerialNo)
                        RefreshGridWithBarcode();
                    else if (_Product.ProductType == (int)EnumProductType.BarCode)
                        RefreshGridWithBarcode();

                    //RefreshGrid1();

                    //if (_Product.ProType == (int)EnumProType.Computer)
                    //{
                    //    RefreshGrid1();
                    //}
                    //else
                    //{
                    //    RefreshGridWithBarcode();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Qty");
            }
        }
        private void RefreshGrid1()
        {

            try
            {
                int nLastCount = (int)numQTY.Value;
                int count = 0;
                int nSLNo = 1;

                if (_PrePOrder.POrderID > 0)
                {
                    if (dgvPOPDetails.Rows.Count > 0)
                    {
                        if (dgvPOPDetails.Rows.Count > (int)numQTY.Value)
                        {
                            numQTY.Value = dgvPOPDetails.Rows.Count;
                            return;
                        }
                        count = dgvPOPDetails.Rows.Count;
                        nSLNo = dgvPOPDetails.Rows.Count;
                        nLastCount = (int)numQTY.Value - dgvPOPDetails.Rows.Count;
                    }
                }
                else
                {
                    dgvPOPDetails.Rows.Clear();
                }

                Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID);

                for (int nCount = 0; nCount < nLastCount; nCount++)
                {
                    dgvPOPDetails.Rows.Add();
                    dgvPOPDetails.Rows[count].Cells[0].Value = nSLNo.ToString();
                    dgvPOPDetails.Rows[count].Cells[1].Value = oProduct.ProductName;
                    dgvPOPDetails.Rows[count].Cells[2].Value = "";
                    //dgvPOPDetails.Rows[count].Cells[3].Value = "";
                    //dgvPOPDetails.Rows[count].Cells[4].Value = "";
                    count++;
                    nSLNo++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void RefreshGridWithBarcode()
        {
            try
            {
                int nLastCount = (int)numQTY.Value;
                int count = 0;
                int nSLNo = 1;

                if (_PrePOrder.POrderID > 0)
                {
                    if (dgvPOPDetails.Rows.Count > 0)
                    {
                        if (dgvPOPDetails.Rows.Count > (int)numQTY.Value)
                        {
                            numQTY.Value = dgvPOPDetails.Rows.Count;
                            return;
                        }
                        count = dgvPOPDetails.Rows.Count;
                        nSLNo = dgvPOPDetails.Rows.Count;
                        nLastCount = 0;//(int)numQTY.Value - dgvPOPDetails.Rows.Count;
                    }
                }
                else
                {
                    dgvPOPDetails.Rows.Clear();
                }

                Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID);

                for (int nCount = 0; nCount < nLastCount; nCount++)
                {
                    dgvPOPDetails.Rows.Add();
                    dgvPOPDetails.Rows[count].Cells[0].Value = nSLNo.ToString();
                    dgvPOPDetails.Rows[count].Cells[1].Value = oProduct.ProductName;
                    if (oProduct.ProductType == (int)EnumProductType.SerialNo)
                        dgvPOPDetails.Rows[count].Cells[2].Value = "";
                    else
                        dgvPOPDetails.Rows[count].Cells[2].Value = GetUniqueKey(7);//oProduct.Barcode;
                    //dgvPOPDetails.Rows[count].Cells[3].Value = "No Need";
                    count++;
                    nSLNo++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void ctlPreOrCompany_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                Supplier oSupplier = (Supplier)(db.Suppliers.FirstOrDefault(o => o.SupplierID == ctlPreOrCompany.SelectedID));
                if (oSupplier != null)
                {
                    numPrvDue.Value = oSupplier.TotalDue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ctlPreOrProduct_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                _Product = (Product)(db.Products.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID));

                if (_Product != null)
                {
                    //if (_PrePOrder.POrderDetails.Count > 0)
                    //{
                    //    POrderDetail oPODetail = _PrePOrder.POrderDetails.FirstOrDefault(o => o.ProductID == _Product.ProductID);

                    //    if (oPODetail != null)
                    //    {
                    //        MessageBox.Show("Already this product added to Purchase Order, Please check this PO.", "Add Purchase Order.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        ctlPreOrProduct.SelectedID = 0;
                    //        ctlPreOrProduct.Focus();
                    //        return;
                    //    }
                    //}


                    //if (_Product.ProType == (int)EnumProType.Computer)
                    //{
                    //    numPacket.Enabled = false;
                    //}
                    //else if (_Product.ProType == (int)EnumProType.C_Accessories)
                    //{
                    //    numPacket.Enabled = false;
                    //    ctlColor.SelectedID = 1;
                    //}

                    ctlColor.SelectedID = 1;
                    numPRate.Value = 0;

                    Stock os = db.Stocks.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID && o.ColorID == ctlColor.SelectedID);

                    if (os != null)
                    {
                        numPreStock.Value = os.Quantity;
                    }

                    else
                    {
                        numPreStock.Value = 0;
                    }

                    if (_Product.UnitType == (int)EnumUnitType.PCS)
                    {
                        numDZKGLT.Enabled = false;
                    }
                    else if (_Product.UnitType == (int)EnumUnitType.BOX)
                    {
                        numDZKGLT.Enabled = true;
                    }

                    dgvPOPDetails.Rows.Clear();
                    numDZKGLT.Value = 0;
                    numUnitQty.Value = 0;
                    numQTY.Value = 0;
                    numWDPrice.Value = 0;
                    numDPerc.Value = 0;
                    numPPDisAmt.Value = 0;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        private void btnPreOrderAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation Check

                if (ctlPreOrCompany.SelectedID <= 0)
                {
                    MessageBox.Show("Please select supplier for this PO.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlPreOrCompany.Focus();
                    return;
                }

                if (ctlPreOrProduct.SelectedID <= 0)
                {
                    MessageBox.Show("Please select product for this PO.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlPreOrProduct.Focus();
                    return;
                }


                if (ctlGodown.SelectedID <= 0)
                {
                    MessageBox.Show("Please select Ware house for this PO.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlGodown.Focus();
                    return;
                }
                //if (ctlColor.SelectedID <= 0)
                //{
                //    MessageBox.Show("Please select color for this PO.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    ctlColor.Focus();
                //    return;
                //}

                if (numQTY.Value <= 0)
                {
                    MessageBox.Show("Please enter product quantity.", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numQTY.Focus();
                    return;
                }

                if (numWDPrice.Value <= 0)
                {
                    MessageBox.Show("Please enter MRP Rate.", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numWDPrice.Focus();
                    return;
                }

                if (numSRate.Value <= 0)
                {
                    MessageBox.Show("Please enter Sales Rate.", "Sales Rate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numSRate.Focus();
                    return;
                }

                if (numUTotalAmt.Value <= 0)
                {
                    MessageBox.Show("Please enter MRP Rate.", "MRP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numUTotalAmt.Focus();
                    return;
                }

                foreach (DataGridViewRow item in dgvPOPDetails.Rows)
                {
                    if (item.Cells[2].Value.ToString() == string.Empty)
                    {
                        MessageBox.Show("Please enter Seial number.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (_PrePOrder.POrderDetails.Count > 0)
                {
                    POrderDetail oPODetail = _PrePOrder.POrderDetails.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID && o.ColorID == ctlColor.SelectedID);

                    if (oPODetail != null)
                    {
                        MessageBox.Show("Already same product and same color added to Purchase Order, Please check this PO.", "Add Purchase Order.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshControl();
                        return;
                    }
                }

                if (numTDP.Value > 0)
                {
                    numTDP.Value = 0m;
                }

                #endregion

                if (_PrePOrder == null)
                {
                    _PrePOrder = new POrder();
                    _PrePOrder.POrderDetails = new List<POrderDetail>();

                }

                //numPWTDAmt.Value = numPPDisAmt.Value;
                numNetDiscount.Value += (numPPDisAmt.Value * numQTY.Value);

                numGrandTotal.ValueChanged -= numGrandTotal_ValueChanged;
                numGrandTotal.Value = numGrandTotal.Value + numUTotalAmt.Value;
                numGrandTotal.ValueChanged += numGrandTotal_ValueChanged;


                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;
                numTempNetTotalAmt.Value = numTotal.Value;


                #region Purchase Order Details
                POrderDetail oPrePOrderDetail = new POrderDetail();
                oPrePOrderDetail.ProductID = ctlPreOrProduct.SelectedID;
                oPrePOrderDetail.UnitPrice = numPRate.Value;
                oPrePOrderDetail.MRPRate = numWDPrice.Value;
                oPrePOrderDetail.Quantity = numQTY.Value;
                oPrePOrderDetail.TAmount = numPRate.Value * numQTY.Value;                //numUTotalAmt.Value;
                oPrePOrderDetail.PPDISPer = numDPerc.Value;
                oPrePOrderDetail.PPDISAmt = numPPDisAmt.Value;
                oPrePOrderDetail.SalesRate = numSRate.Value;
                oPrePOrderDetail.ColorID = ctlColor.SelectedID;

                oPrePOrderDetail.GSTPerc = numGSTPerc.Value;
                oPrePOrderDetail.CGSTPerc = numCGSTPerc.Value;
                oPrePOrderDetail.SGSTPerc = numSGSTPerc.Value;
                oPrePOrderDetail.IGSTPerc = numIGSTPerc.Value;
                oPrePOrderDetail.GSTAmt = numGSTAmt.Value;
                oPrePOrderDetail.CGSTAmt = numCGSTAmt.Value;
                oPrePOrderDetail.SGSTAmt = numSGSTAmt.Value;
                oPrePOrderDetail.IGSTAmt = numIGSTAmt.Value;
                oPrePOrderDetail.GodownID = ctlGodown.SelectedID;

                RefreshGridObject(oPrePOrderDetail);
                _PrePOrder.POrderDetails.Add(oPrePOrderDetail);

                #endregion

                nProductID = ctlPreOrProduct.SelectedID;

                RefreshGrid();
                RefreshControl();
                dgvPOPDetails.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshGridObject(POrderDetail pod)
        {
            int colIndex = 0;

            //bd
            Product op = db.Products.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID);
            if (op.ProductType == (int)EnumProductType.SerialNo)
            {
                for (int nindex = 0; nindex < dgvPOPDetails.RowCount; nindex++)
                {
                    POProductDetail oPOPDetail = new POProductDetail();
                    oPOPDetail.ProductID = ctlPreOrProduct.SelectedID;
                    oPOPDetail.ColorID = ctlColor.SelectedID;
                    oPOPDetail.IMENo = Convert.ToString(dgvPOPDetails.Rows[nindex].Cells[colIndex + 2].Value);
                    pod.POProductDetails.Add(oPOPDetail);
                }
            }
            else if (op.ProductType == (int)EnumProductType.BarCode)
            {
                for (int nindex = 0; nindex < dgvPOPDetails.RowCount; nindex++)
                {
                    POProductDetail oPOPDetail = new POProductDetail();
                    oPOPDetail.ProductID = ctlPreOrProduct.SelectedID;
                    oPOPDetail.ColorID = ctlColor.SelectedID;
                    if (Convert.ToString(dgvPOPDetails.Rows[nindex].Cells[colIndex + 2].Value) == string.Empty)
                        oPOPDetail.IMENo = GetUniqueKey(13);// "MCT-" + GetUniqueKey(13);
                    else
                        oPOPDetail.IMENo = Convert.ToString(dgvPOPDetails.Rows[nindex].Cells[colIndex + 2].Value);

                    pod.POProductDetails.Add(oPOPDetail);
                }
            }
            else
            {
                POProductDetail oPOPDetail = new POProductDetail();
                oPOPDetail.ProductID = ctlPreOrProduct.SelectedID;
                oPOPDetail.ColorID = ctlColor.SelectedID;
                oPOPDetail.IMENo = "No Barcode";
                pod.POProductDetails.Add(oPOPDetail);
            }
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void RefresPOPObject(POrderDetail pod)
        {
            POProductDetail oPOPDetail = new POProductDetail();
            oPOPDetail.ProductID = ctlPreOrProduct.SelectedID;

            //oPOPDetail.Barcode = _Product.Barcode;
            pod.POProductDetails.Add(oPOPDetail);
        }

        private void StockReturn()
        {
            foreach (POrderDetail oPOrderDetail in _PrePOrder.POrderDetails)
            {
                _Stock = db.Stocks.FirstOrDefault(o => o.ProductID == oPOrderDetail.ProductID && o.ColorID == oPOrderDetail.ColorID);

                if (_Stock != null)
                {
                    decimal PMPrice = 0;
                    decimal TQty = 0;
                    decimal ReturnQty = 0;
                    decimal RemainingQty = 0;

                    TQty = (decimal)_Stock.Quantity;
                    _Stock.Quantity = _Stock.Quantity - (decimal)oPOrderDetail.Quantity;

                    RemainingQty = (decimal)_Stock.Quantity;
                    ReturnQty = (decimal)oPOrderDetail.Quantity;

                    if (RemainingQty > 0)
                        PMPrice = (decimal)((TQty * _Stock.PMPrice) - (ReturnQty * oPOrderDetail.UnitPrice)) / RemainingQty;
                    _Stock.PMPrice = PMPrice;

                    if (_Stock.Quantity == 0)
                    {
                        _Stock.Quantity = 0;
                        _Stock.PMPrice = 0;
                    }
                }

            }
        }
        private void RefreshGrid()
        {
            try
            {

                int count = 0;
                int nSLNo = 1;
                dgPreOrder.Rows.Clear();
                _PrePOrderDetails = _PrePOrder.POrderDetails.ToList();

                if (_PrePOrderDetails.Count > 0)
                {
                    var POrderDetails = from pod in _PrePOrder.POrderDetails
                                        join p in db.Products on pod.ProductID equals p.ProductID
                                        join com in db.Companies on p.CompanyID equals com.CompanyID
                                        join cat in db.Categorys on p.CategoryID equals cat.CategoryID
                                        join col in db.Colors on pod.ColorID equals col.ColorID
                                        select new
                                        {
                                            ProductName = p.ProductName,
                                            CategoryName = cat.Description,
                                            CompanyName = com.Description,
                                            ColorName = col.Description,
                                            Quantity = pod.Quantity,
                                            MRPRate = pod.MRPRate,
                                            PPDISPer = pod.PPDISPer,
                                            PPDISAmt = pod.PPDISAmt,
                                            UnitPrice = pod.UnitPrice,
                                            TAmount = pod.TAmount,
                                            CGST=pod.CGSTAmt,
                                            SGST=pod.SGSTAmt,
                                            IGST=pod.IGSTAmt,
                                            GST=pod.GSTAmt,
                                            oPODItem=pod
                                        };

                    foreach (var item in POrderDetails)
                    {
                        dgPreOrder.Rows.Add();

                        dgPreOrder.Rows[count].Cells[0].Value = nSLNo.ToString();
                        dgPreOrder.Rows[count].Cells[1].Value = item.ProductName;
                        dgPreOrder.Rows[count].Cells[2].Value = item.CategoryName;
                        dgPreOrder.Rows[count].Cells[3].Value = item.ColorName;
                        dgPreOrder.Rows[count].Cells[4].Value = item.Quantity.ToString();
                        dgPreOrder.Rows[count].Cells[5].Value = Math.Round(item.MRPRate, 2);
                        dgPreOrder.Rows[count].Cells[6].Value = Math.Round(item.PPDISPer, 2);
                        dgPreOrder.Rows[count].Cells[7].Value = Math.Round(item.PPDISAmt, 2);
                        dgPreOrder.Rows[count].Cells[8].Value = Math.Round(item.UnitPrice, 2);
                        dgPreOrder.Rows[count].Cells[9].Value = Math.Round((item.TAmount), 2);
                        dgPreOrder.Rows[count].Cells[10].Value = Math.Round((item.CGST), 2);
                        dgPreOrder.Rows[count].Cells[11].Value = Math.Round((item.SGST), 2);
                        dgPreOrder.Rows[count].Cells[12].Value = Math.Round((item.IGST), 2);
                        dgPreOrder.Rows[count].Cells[13].Value = Math.Round((item.GST), 2);

                        dgPreOrder.Rows[count].Tag = item.oPODItem;

                        count++;
                        nSLNo++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshControl()
        {
            numQTY.Value = 0;
            numPacket.Value = 0;
            numPRate.Value = 0;
            numDPerc.Value = 0;
            numPPDisAmt.Value = 0;
            numWDPrice.Value = 0;
            numUTotalAmt.Value = 0;
            numDZKGLT.Value = 0;
            numUnitQty.Value = 0;
            ctlPreOrProduct.SelectedID = 0;
            ctlColor.SelectedID = 0;
            numSRate.Value = 0;
            numPreStock.Value = 0;
            dgvPOPDetails.Rows.Clear();
            numUnitQty.Focus();
        }

        private void btnPreOrderRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPreOrder.SelectedRows.Count > 0)
                {

                    POrderDetail ordetail = dgPreOrder.SelectedRows[0].Tag as POrderDetail;
                    List<POProductDetail> oPOPDetails = ordetail.POProductDetails.ToList();

                    if (numTDP.Value > 0)
                    {
                        numTDP.Value = 0;
                    }

                    _Stock = db.Stocks.FirstOrDefault(o => o.ProductID == ordetail.ProductID && o.ColorID == ordetail.ColorID);

                    if (_Stock != null)
                    {
                        StockDetail stockdetail = null;
                        foreach (var item in ordetail.POProductDetails)
                        {
                            stockdetail = _Stock.StockDetails.FirstOrDefault(x => x.IMENO == item.IMENo);
                            if (stockdetail != null)
                                db.StockDetails.Remove(stockdetail);
                        }
                    }
                    numGrandTotal.ValueChanged -= numGrandTotal_ValueChanged;
                    numGrandTotal.Value = numGrandTotal.Value - (ordetail.TAmount + (ordetail.Quantity * ordetail.PPDISAmt));
                    numGrandTotal.ValueChanged += numGrandTotal_ValueChanged;

                    numTotal.Value = numTotal.Value - ordetail.TAmount;
                    numTempNetTotalAmt.Value = numTotal.Value;
                    //numPWTDAmt.Value = numPWTDAmt.Value - (decimal)ordetail.PPDISAmt;
                    numNetDiscount.Value -= ordetail.Quantity * ordetail.PPDISAmt;

                    if (_PrePOrder.POrderID > 0)
                    {
                        foreach (POProductDetail oPOPDetailItem in oPOPDetails)
                        {
                            db.POProductDetails.Remove(oPOPDetailItem);
                        }

                        db.POrderDetails.Remove(ordetail);
                    }
                    else
                    {
                        foreach (POProductDetail oPOPDetailItem in oPOPDetails)
                        {
                            ordetail.POProductDetails.Remove(oPOPDetailItem);
                        }

                        _PrePOrder.POrderDetails.Remove(ordetail);
                    }

                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("select an item to remove", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void RefreshObject()
        {
            if (_PrePOrder == null)
            {
                _PrePOrder = new POrder();

            }

            _PrePOrder.ChallanNo = txtPONo.Text;
            _PrePOrder.OrderDate = dtpPreOrDate.Value;
            _PrePOrder.SupplierID = ctlPreOrCompany.SelectedID;
            _PrePOrder.GrandTotal = numGrandTotal.Value;
            _PrePOrder.TDPer = numTDP.Value;
            _PrePOrder.TDiscount = numTotalDis.Value;
            _PrePOrder.NetDiscount = numNetDiscount.Value;
            _PrePOrder.TotalAmt = numTotal.Value;
            _PrePOrder.RecAmt = numPaidAmt.Value;
            _PrePOrder.PaymentDue = numTotalDueAmt.Value;//numPrvDue.Value;
            _PrePOrder.TotalDue = (numTotalDueAmt.Value + _SuppPrvDue);//numPrvDue.Value + (numTotalDueAmt.Value -SuppPrvDue);
            _PrePOrder.Status = (int)EnumPurchaseType.Purchase;
            _PrePOrder.LaborCost = numLaborAmt.Value;
            _PrePOrder.TDPer = numTDP.Value;

        }
        private bool IsValid()
        {
            if (txtPONo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Enter Challan NO. for this Order.", "Save System Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPONo.Focus();
                return false;

            }

            if (_PrePOrder.POrderDetails.Count == 0)
            {
                MessageBox.Show("Please at first add specific item for this Order.", "Save System Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtPONo.Focus();
                return false;

            }

            return true;
        }

        bool IsSaveOrderValid(POrder porder)
        {
            if (_PrePOrder.POrderDetails.Sum(i => (i.UnitPrice + i.PPDISAmt) * i.Quantity) == _PrePOrder.GrandTotal || _PrePOrder.POrderDetails.Sum(i => (i.UnitPrice + i.PPDISAmt) * i.Quantity) == _PrePOrder.POrderDetails.Sum(i => i.TAmount))
            {
                return true;
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) return;
                bool isValid = false;
                if (MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    #region New POrder

                    if (_PrePOrder.POrderID <= 0)
                    {
                        RefreshObject();
                        isValid = IsSaveOrderValid(_PrePOrder);

                        if (isValid)
                        {
                            _PrePOrder.CreatedBy = Global.CurrentUser.UserID;
                            _PrePOrder.CreateDate = DateTime.Now;

                            _PrePOrder.POrderID = db.POrders.Count() > 0 ? db.POrders.Max(obj => obj.POrderID) + 1 : 1;

                            #region For Oredr Product Purpose

                            int detailid = db.POrderDetails.Count() > 0 ? db.POrderDetails.Max(obj => obj.POrderDetailID) + 1 : 1;
                            int popdetailid = db.POProductDetails.Count() > 0 ? db.POProductDetails.Max(obj => obj.POPDID) + 1 : 1;

                            foreach (POrderDetail item in _PrePOrder.POrderDetails)
                            {
                                item.POrderDetailID = detailid;
                                item.POrderID = _PrePOrder.POrderID;
                                List<POProductDetail> POPDetailsList = item.POProductDetails.Where(POP => POP.ProductID == item.ProductID && POP.ColorID == item.ColorID).ToList();

                                foreach (POProductDetail oPOPItem in item.POProductDetails)
                                {
                                    oPOPItem.POPDID = popdetailid;
                                    oPOPItem.POrderDetailID = detailid;
                                    oPOPItem.ColorID = item.ColorID;
                                    popdetailid++;
                                }
                                detailid++;
                            }

                            #endregion

                            db.POrders.Add(_PrePOrder);

                            #region Stock Purpose

                            if (_PrePOrder != null)
                            {
                                int stockid = db.Stocks.Count() > 0 ? db.Stocks.Max(obj => obj.StockID) + 1 : 1;

                                int stockDetailID = db.StockDetails.Count() > 0 ? db.StockDetails.Max(obj => obj.SDetailID) + 1 : 1;

                                foreach (POrderDetail oPrePOrderDetail in _PrePOrder.POrderDetails)
                                {
                                    decimal PMPrice = 0;
                                    _Stock = db.Stocks.FirstOrDefault(o => o.ProductID == oPrePOrderDetail.ProductID && o.ColorID == oPrePOrderDetail.ColorID && o.GodownID==oPrePOrderDetail.GodownID);
                                    Product oPro = db.Products.FirstOrDefault(o => o.ProductID == oPrePOrderDetail.ProductID);

                                    #region Stock
                                    if (_Stock != null)
                                    {
                                        PMPrice = ((decimal)((_Stock.Quantity * _Stock.PMPrice) + (oPrePOrderDetail.Quantity * oPrePOrderDetail.UnitPrice)) / (decimal)(_Stock.Quantity + oPrePOrderDetail.Quantity));
                                        _Stock.PMPrice = PMPrice;
                                        _Stock.Quantity = _Stock.Quantity + (decimal)oPrePOrderDetail.Quantity;
                                        _Stock.LPPrice = (decimal)oPrePOrderDetail.UnitPrice;
                                        _Stock.EntryDate = DateTime.Today;
                                        _Stock.ModifiedBy = Global.CurrentUser.UserID;
                                        _Stock.ModifiedDate = DateTime.Now;

                                    }
                                    else
                                    {
                                        _Stock = new Stock();
                                        _Stock.StockID = stockid;
                                        _Stock.Quantity = (decimal)oPrePOrderDetail.Quantity;
                                        _Stock.StockCode = oPro.Code;
                                        _Stock.EntryDate = DateTime.Today;
                                        _Stock.ProductID = oPrePOrderDetail.ProductID;
                                        _Stock.LPPrice = (decimal)oPrePOrderDetail.UnitPrice;
                                        _Stock.PMPrice = (decimal)oPrePOrderDetail.UnitPrice;
                                        _Stock.ColorID = oPrePOrderDetail.ColorID;

                                        _Stock.CreatedBy = Global.CurrentUser.UserID;
                                        _Stock.CreateDate = DateTime.Now;
                                        _Stock.GodownID = oPrePOrderDetail.GodownID;

                                        db.Stocks.Add(_Stock);
                                        stockid++;
                                    }
                                    #endregion

                                    #region StockDetails
                                    var StockDetailList = db.StockDetails;
                                    var ProductList = db.Products;
                                    Product product = null;
                                    foreach (POProductDetail oPOPDItem in oPrePOrderDetail.POProductDetails)
                                    {

                                        product = ProductList.FirstOrDefault(o => o.ProductID == oPOPDItem.ProductID);

                                        //if Nobarcode product then add quantity in stockDetails 
                                        if (product.ProductType == (int)EnumProductType.NoBarCode)
                                        {
                                            StockDetail oStockDetail = new StockDetail();
                                            oStockDetail.SDetailID = stockDetailID;
                                            oStockDetail.StockCode = oPro.Code;
                                            oStockDetail.ProductID = oPro.ProductID;
                                            oStockDetail.IMENO = oPOPDItem.IMENo;
                                            oStockDetail.StockID = _Stock.StockID;
                                            oStockDetail.ColorID = oPrePOrderDetail.ColorID;
                                            oStockDetail.Status = (int)EnumStockDetailStatus.Stock;
                                            oStockDetail.CreatedBy = Global.CurrentUser.UserID;
                                            oStockDetail.CreateDate = DateTime.Now;

                                            oStockDetail.SalesRate = oPrePOrderDetail.SalesRate;
                                            oStockDetail.PRate = oPrePOrderDetail.UnitPrice;
                                            oStockDetail.POrderDetailID = oPrePOrderDetail.POrderDetailID;
                                            oStockDetail.Quantity = oPrePOrderDetail.Quantity;
                                            oStockDetail.GodownID =(int) oPrePOrderDetail.GodownID;

                                            db.StockDetails.Add(oStockDetail);
                                            stockDetailID++;

                                        }
                                        else
                                        {
                                            StockDetail oStockDetail = new StockDetail();

                                            oStockDetail.SDetailID = stockDetailID;
                                            oStockDetail.StockCode = oPro.Code;
                                            oStockDetail.ProductID = oPro.ProductID;
                                            oStockDetail.IMENO = oPOPDItem.IMENo;
                                            oStockDetail.StockID = _Stock.StockID;
                                            oStockDetail.ColorID = oPrePOrderDetail.ColorID;
                                            oStockDetail.Status = (int)EnumStockDetailStatus.Stock;
                                            oStockDetail.CreatedBy = Global.CurrentUser.UserID;
                                            oStockDetail.CreateDate = DateTime.Now;
                                            oStockDetail.GodownID = (int)oPrePOrderDetail.GodownID;
                                            oStockDetail.SalesRate = oPrePOrderDetail.SalesRate;
                                            oStockDetail.PRate = oPrePOrderDetail.UnitPrice;
                                            oStockDetail.POrderDetailID = oPrePOrderDetail.POrderDetailID;
                                        
                                            db.StockDetails.Add(oStockDetail);
                                            stockDetailID++;
                                        }
                                    }
                                    #endregion

                                }
                            }
                            #endregion
                        }


                    }
                    #endregion

                    #region Edit POrder
                    else
                    {
                        if (_PreviousFlatDiscount > 0 && numTotalDis.Value == 0)
                        {
                            if (MessageBox.Show("Do you want to add flat discount.", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                return;
                            }
                        }

                        _PrePOrder = db.POrders.FirstOrDefault(obj => obj.POrderID == _PrePOrder.POrderID);
                        #region For Oredr Product Purpose
                        int detailid = db.POrderDetails.Count() > 0 ? db.POrderDetails.Max(obj => obj.POrderDetailID) + 1 : 1;
                        int popdetailid = db.POProductDetails.Count() > 0 ? db.POProductDetails.Max(obj => obj.POPDID) + 1 : 1;

                        foreach (POrderDetail item in _PrePOrder.POrderDetails)
                        {
                            if (item.POrderDetailID <= 0)
                            {
                                item.POrderDetailID = detailid;
                                detailid++;
                            }
                            item.POrderID = _PrePOrder.POrderID;
                            List<POProductDetail> POPDetailsList = item.POProductDetails.Where(POP => POP.ProductID == item.ProductID && POP.ColorID == item.ColorID).ToList();
                            foreach (POProductDetail oPOPItem in POPDetailsList)
                            {
                                if (oPOPItem.POPDID <= 0)
                                {
                                    oPOPItem.POPDID = popdetailid;
                                    popdetailid++;
                                }
                                oPOPItem.POrderDetailID = item.POrderDetailID;
                            }

                        }

                        #endregion

                        RefreshObject();

                        isValid = IsSaveOrderValid(_PrePOrder);
                        if (isValid)
                        {
                            _PrePOrder.ModifiedBy = Global.CurrentUser.UserID;
                            _PrePOrder.ModifiedDate = DateTime.Now;

                            #region Stock Purpose

                            int stockid = db.Stocks.Count() > 0 ? db.Stocks.Max(obj => obj.StockID) + 1 : 1;
                            if (_PrePOrder != null)
                            {
                                int stockDetailID = db.StockDetails.Count() > 0 ? db.StockDetails.Max(obj => obj.SDetailID) + 1 : 1;

                                foreach (POrderDetail oPODItem in _PrePOrder.POrderDetails)
                                {
                                    Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == oPODItem.ProductID);
                                    decimal PMPrice = 0;
                                    _Stock = db.Stocks.FirstOrDefault(o => o.ProductID == oPODItem.ProductID && o.ColorID == oPODItem.ColorID &&o.GodownID== oPODItem.GodownID);

                                    if (_Stock != null)
                                    {
                                        PMPrice = ((decimal)((_Stock.Quantity * _Stock.PMPrice) + (oPODItem.Quantity * oPODItem.UnitPrice)) / (decimal)(_Stock.Quantity + oPODItem.Quantity));
                                        _Stock.PMPrice = PMPrice;
                                        _Stock.Quantity = _Stock.Quantity + oPODItem.Quantity;
                                        _Stock.LPPrice = oPODItem.UnitPrice;
                                        _Stock.EntryDate = DateTime.Today;
                                        _Stock.ModifiedBy = Global.CurrentUser.UserID;
                                        _Stock.ModifiedDate = DateTime.Now;
                                    }
                                    else
                                    {
                                        _Stock = new Stock();
                                        _Stock.StockID = stockid;
                                        _Stock.Quantity = oPODItem.Quantity;
                                        _Stock.StockCode = oProduct.Code;
                                        _Stock.EntryDate = DateTime.Today;
                                        _Stock.ProductID = oPODItem.ProductID;
                                        _Stock.LPPrice = oPODItem.UnitPrice;
                                        _Stock.PMPrice = oPODItem.UnitPrice;
                                        _Stock.ColorID = oPODItem.ColorID;
                                        _Stock.CreatedBy = Global.CurrentUser.UserID;
                                        _Stock.CreateDate = DateTime.Now;
                                        _Stock.GodownID = oPODItem.GodownID;

                                        db.Stocks.Add(_Stock);
                                        stockid++;
                                    }
                                    List<StockDetail> stkDetails = _Stock.StockDetails.ToList();
                                    List<POProductDetail> oPOPDItems = oPODItem.POProductDetails.ToList();
                                    foreach (POProductDetail oPOPDItem in oPOPDItems)
                                    {
                                        bool flag = false;
                                        if (oProduct.ProductType == (int)EnumProductType.NoBarCode)
                                        {
                                            StockDetail oStockDetail = db.StockDetails.Local.FirstOrDefault(x => x.IMENO == oPOPDItem.IMENo && x.StockID == _Stock.StockID && x.ColorID == oPODItem.ColorID && x.ProductID == oPOPDItem.ProductID && x.POrderDetailID == oPODItem.POrderDetailID && x.GodownID==oPODItem.GodownID);
                                            if (oStockDetail == null)
                                            {
                                                oStockDetail = new StockDetail();
                                                oStockDetail.SDetailID = stockDetailID;
                                                stockDetailID++;
                                                flag = true;
                                            }

                                            oStockDetail.StockCode = oProduct.Code;
                                            oStockDetail.ProductID = oProduct.ProductID;
                                            oStockDetail.IMENO = oPOPDItem.IMENo;
                                            oStockDetail.StockID = _Stock.StockID;
                                            oStockDetail.ColorID = oPODItem.ColorID;
                                            oStockDetail.Status = (int)EnumStockDetailStatus.Stock;
                                            oStockDetail.CreatedBy = Global.CurrentUser.UserID;
                                            oStockDetail.CreateDate = DateTime.Now;
                                            oStockDetail.SalesRate = oPODItem.SalesRate;
                                            oStockDetail.PRate = oPODItem.UnitPrice;
                                            oStockDetail.POrderDetailID = oPODItem.POrderDetailID;
                                            oStockDetail.Quantity = oPODItem.Quantity;

                                            if (flag)
                                                db.StockDetails.Add(oStockDetail);
                                        }
                                        else
                                        {
                                            StockDetail oStockDetail = db.StockDetails.Local.FirstOrDefault(x => x.IMENO == oPOPDItem.IMENo && x.StockID == _Stock.StockID && x.ColorID == oPODItem.ColorID && x.ProductID == oPOPDItem.ProductID && x.GodownID==oPODItem.GodownID);
                                            if (oStockDetail == null)
                                                oStockDetail = new StockDetail();

                                            if (oStockDetail.SDetailID <= 0)
                                            {
                                                oStockDetail.SDetailID = stockDetailID;
                                                stockDetailID++;
                                                flag = true;
                                            }
                                            oStockDetail.StockCode = oProduct.Code;
                                            oStockDetail.ProductID = oProduct.ProductID;
                                            oStockDetail.IMENO = oPOPDItem.IMENo;
                                            oStockDetail.StockID = _Stock.StockID;
                                            oStockDetail.ColorID = oPODItem.ColorID;
                                            oStockDetail.Status = (int)EnumStockDetailStatus.Stock;
                                            oStockDetail.CreatedBy = Global.CurrentUser.UserID;
                                            oStockDetail.CreateDate = DateTime.Now;
                                            oStockDetail.SalesRate = oPODItem.SalesRate;
                                            oStockDetail.PRate = oPODItem.UnitPrice;
                                            oStockDetail.POrderDetailID = oPODItem.POrderDetailID;

                                            if (flag)
                                                db.StockDetails.Add(oStockDetail);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion Edit POrder

                    if (isValid)
                    {
                        #region Update Supplier Due Amount
                        _oSupplier = (Supplier)(db.Suppliers.FirstOrDefault(o => o.SupplierID == _PrePOrder.SupplierID));
                        _oSupplier.TotalDue = _oSupplier.TotalDue + (numTotalDueAmt.Value - _SuppPaymentDue);
                        #endregion

                        db.Database.Log = x => System.Diagnostics.Debug.WriteLine(x);
                        db.SaveChanges();
                        db.Database.Log = x => System.Diagnostics.Debug.WriteLine(x);

                        MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        #region Barcode Purpose
                        PrintInvoice oPInvoice = new PrintInvoice();
                        oPInvoice.PrintBarcode(_PrePOrder);
                        PrintPOInvoice(_PrePOrder);
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Order Failed. Please try again.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (ItemChanged != null)
                    {
                        ItemChanged();
                    }
                    _PrePOrder = new POrder();
                    RefreshValue();
                    RefreshGrid();
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        public void PrintPOInvoice(POrder POrder)
        {
            if (POrder != null)
            {
                TransactionalDataSet.dtPOInvoiceDataTable dt = new TransactionalDataSet.dtPOInvoiceDataTable();
                DataSet ds = new DataSet();
                var Supplier = db.Suppliers.FirstOrDefault(i => i.SupplierID == POrder.SupplierID);
                var PorderDetals = from pod in POrder.POrderDetails
                                   join p in db.Products on pod.ProductID equals p.ProductID
                                   join cat in db.Categorys on p.CategoryID equals cat.CategoryID
                                   join com in db.Companies on p.CompanyID equals com.CompanyID
                                   join col in db.Colors on pod.ColorID equals col.ColorID
                                   select new
                                   {
                                       ProductName = p.ProductName,
                                       CategoryName = cat.Description,
                                       CompanyName = com.Description,
                                       ColorName = col.Description,
                                       pod.MRPRate,
                                       UnitPrice = (pod.UnitPrice + ((pod.POrder.LaborCost - pod.POrder.TDiscount) / (pod.POrder.GrandTotal - pod.POrder.NetDiscount + pod.POrder.TDiscount)) * pod.UnitPrice),
                                       PPDISAmt = pod.PPDISAmt - ((pod.POrder.LaborCost - pod.POrder.TDiscount) / (pod.POrder.GrandTotal - pod.POrder.NetDiscount + pod.POrder.TDiscount)) * pod.UnitPrice,
                                       PPDISPer = ((pod.PPDISAmt - ((pod.POrder.LaborCost - pod.POrder.TDiscount) / (pod.POrder.GrandTotal - pod.POrder.NetDiscount + pod.POrder.TDiscount)) * pod.UnitPrice) / pod.MRPRate) * 100,
                                       pod.Quantity,
                                       pod.TAmount,
                                       pod.CGSTAmt,
                                       pod.SGSTAmt,
                                       pod.IGSTAmt,
                                       pod.GSTAmt,

                                   };

                decimal FlatDiscount = POrder.TDiscount;
                decimal TotalUnitPrice = POrder.POrderDetails.Sum(o => o.UnitPrice * o.Quantity);
                decimal Ratio = POrder.TDiscount / TotalUnitPrice;
                // item.PPDISAmt + Ratio*item.UnitPrice*item.Quantity
                foreach (var item in PorderDetals)
                {
                    dt.Rows.Add(item.ProductName, item.CategoryName, item.CompanyName, item.ColorName, item.MRPRate, item.PPDISAmt, item.PPDISPer, 0m, 0m, item.Quantity, ((item.MRPRate - item.PPDISAmt) * item.Quantity),item.CGSTAmt,item.SGSTAmt,item.GSTAmt,item.SGSTAmt);
                }

                dt.TableName = "TransactionalDataSet_dtPOInvoice";
                ds.Tables.Add(dt);
                string embededResource = "INVENTORY.UI.RDLC.rptPOInvoice.rdlc";
                ReportParameter reportParameter = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();


                reportParameter = new ReportParameter("SupAddress", Supplier.Address);
                parameters.Add(reportParameter);

                reportParameter = new ReportParameter("SupplierCode", Supplier.Code);
                parameters.Add(reportParameter);

                reportParameter = new ReportParameter("SupplierName", Supplier.OwnerName);
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("ChallanNo", POrder.ChallanNo);
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("OrderDate", POrder.OrderDate.ToString());
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("FlatDis", POrder.NetDiscount.ToString());
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("NetTotal", POrder.TotalAmt.ToString());
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("PaidAmt", POrder.RecAmt.ToString());
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("CurrentDue", POrder.PaymentDue.ToString());
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("PrintDate", "Date: " + DateTime.Now);
                parameters.Add(reportParameter);
                reportParameter = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(reportParameter);
                fReportViewer frm = new fReportViewer();

                if (dt.Rows.Count > 0)
                {
                    frm.CommonReportViewer(embededResource, ds, parameters, true);
                }
                else
                {
                    MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fPrePOrder_Load(object sender, EventArgs e)
        {

        }
        private void numPRate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RefreshGridAfterSelect()
        {
            try
            {
                int count = 0;
                int nSLNo = 1;
                dgvPOPDetails.Rows.Clear();

                if (_PrePOrderDetails.Count > 0)
                {
                    foreach (POProductDetail oPODItem in _POrderDetail.POProductDetails)
                    {
                        dgvPOPDetails.Rows.Add();

                        Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == oPODItem.ProductID);
                        dgvPOPDetails.Rows[count].Cells[0].Value = nSLNo.ToString();

                        if (oProduct != null)
                        {
                            dgvPOPDetails.Rows[count].Cells[1].Value = oProduct.ProductName;
                        }

                        dgvPOPDetails.Rows[count].Cells[2].Value = oPODItem.IMENo.ToString();
                        dgvPOPDetails.Rows[count].Tag = oPODItem;

                        count++;
                        nSLNo++;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                ForNewSupplier = true;
                fSupplier oFSupplier = new fSupplier();
                oFSupplier.ShowDlg(new Supplier(), true);

                if (ForNewSupplier)
                {
                    db = new DEWSRMEntities();
                    List<Supplier> oSuppList = db.Suppliers.ToList();
                    ctlPreOrCompany.SelectedID = oSuppList[oSuppList.Count - 1].SupplierID;
                    ForNewSupplier = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numDPerc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numPRate.Value > 0)
                {
                    //numPPDisAmt.Value = (numQTY.Value * numWDPrice.Value) * (numDPerc.Value / 100);
                    numPPDisAmt.ValueChanged -= numPPDisAmt_ValueChanged;
                    numPPDisAmt.Value = (numWDPrice.Value) * (numDPerc.Value / 100);
                    numPPDisAmt.ValueChanged += numPPDisAmt_ValueChanged;

                    numPRate.Value = ((numUTotalAmt.Value - numPPDisAmt.Value * numQTY.Value) / numQTY.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PW Discount");
            }
        }

        private void numPPDisAmt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numQTY.Value > 0)
                {
                    //if ((numUTotalAmt.Value - numPPDisAmt.Value) > 0)
                    //{
                    //    numPRate.Value = ((numUTotalAmt.Value - numPPDisAmt.Value) / numQTY.Value);
                    //}
                    if ((numUTotalAmt.Value - (numPPDisAmt.Value * numQTY.Value)) > 0)
                    {
                        numPRate.Value = ((numUTotalAmt.Value - (numPPDisAmt.Value * numQTY.Value)) / numQTY.Value);
                        numDPerc.ValueChanged -= numDPerc_ValueChanged;
                        numDPerc.Value = (numPPDisAmt.Value * 100m) / numWDPrice.Value;
                        numDPerc.ValueChanged += numDPerc_ValueChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PPD Amt.");
            }
        }

        private void numTDP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numNetDiscount.Value = (numGrandTotal.Value - numTempNetTotalAmt.Value);
                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;

                numTotalDis.ValueChanged -= numTotalDis_ValueChanged;
                numTotalDis.Value = (numTotal.Value) * (numTDP.Value / 100);
                numTotalDis.ValueChanged += numTotalDis_ValueChanged;

                numNetDiscount.Value = (numGrandTotal.Value - numTempNetTotalAmt.Value) + numTotalDis.Value;
                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;

                //numTotalDis.ValueChanged -= numTotalDis_ValueChanged;
                //numTotalDis.Value = (numTotal.Value) * (numTDP.Value / 100);
                //numTotalDis.ValueChanged += numTotalDis_ValueChanged;

                //if (_PrePOrder.POrderID > 0)
                //{
                //    numNetDiscount.Value = (numGrandTotal.Value - (numTempNetTotalAmt.Value + _PreviousFlatDiscount)) + numTotalDis.Value;
                //    numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;
                //}
                //else
                //{
                //    numNetDiscount.Value = (numGrandTotal.Value - numTempNetTotalAmt.Value) + numTotalDis.Value;
                //    numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numTotalDis_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                numTDP.ValueChanged -= numTDP_ValueChanged;
                numTDP.Value = Math.Round((numTotalDis.Value * 100m) / numTotal.Value, 2);
                numTDP.ValueChanged += numTDP_ValueChanged;
                numNetDiscount.Value = (numGrandTotal.Value - numTempNetTotalAmt.Value) + numTotalDis.Value;
                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;

                //numTDP.ValueChanged -= numTDP_ValueChanged;
                //numTDP.Value = (numTotalDis.Value * 100) / numTotal.Value;
                //numTDP.ValueChanged += numTDP_ValueChanged;

                //numNetDiscount.Value = (numGrandTotal.Value - numTempNetTotalAmt.Value) + numTotalDis.Value;
                //numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Total Dis.");
            }

        }

        private void numPaidAmt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //numTotalDueAmt.Value = (numTotal.Value) - numPaidAmt.Value;
                if (numTotal.Value >= (numPaidAmt.Value))
                    numTotalDueAmt.Value = numTotal.Value - (numPaidAmt.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Paid Amt.");
            }

        }

        private void numPWTDAmt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numNetDiscount.ValueChanged -= numNetDiscount_ValueChanged;
                numNetDiscount.Value = numTotalDis.Value + numPWTDAmt.Value;//Newly Added By Motiur
                numNetDiscount.ValueChanged += numNetDiscount_ValueChanged;
                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numPWTAmt");
            }

            //numNetDiscount.Value = numTotalDis.Value + (numPWTDAmt.Value * numQTY.Value);//Newly Added By Motiur
        }

        private void numNetDiscount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Net Dis.");
            }
        }

        private void numGrandTotal_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numGrandTotal.Value >= 0)
                {
                    numTotalDis.Value = (numTotal.Value) * (numTDP.Value / 100);

                    //if (numGrandTotal.Value >= numNetDiscount.Value)
                    //    numVatAmount.Value = (numGrandTotal.Value - numNetDiscount.Value) * (numVatPercent.Value / 100);

                    if ((numGrandTotal.Value) >= numNetDiscount.Value)
                        numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;

                    numTotalDueAmt.Value = numTotal.Value - numPaidAmt.Value;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numGrandTotal");
            }

            //try
            //{
            //    numTotalDis.Value = (numTotal.Value) * (numTDP.Value / 100);
            //    numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;
            //    numTotalDueAmt.Value = (numTotal.Value) - numPaidAmt.Value;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Grand Total");
            //}

        }

        private void numPRate_Enter(object sender, EventArgs e)
        {
            numPRate.Select(0, numPRate.Text.Length);
        }

        private void numQTY_Enter(object sender, EventArgs e)
        {
            numQTY.Select(0, numQTY.Text.Length);
        }

        private void numDPerc_Enter(object sender, EventArgs e)
        {
            numDPerc.Select(0, numDPerc.Text.Length);
        }

        private void numPPDisAmt_Enter(object sender, EventArgs e)
        {
            numPPDisAmt.Select(0, numPPDisAmt.Text.Length);
        }

        private void numTDP_Enter(object sender, EventArgs e)
        {
            numTDP.Select(0, numTDP.Text.Length);
        }

        private void numTotalDis_Enter(object sender, EventArgs e)
        {
            numTotalDis.Select(0, numTotalDis.Text.Length);
        }

        private void numPaidAmt_Enter(object sender, EventArgs e)
        {
            numPaidAmt.Select(0, numPaidAmt.Text.Length);
        }

        private void numLaborAmt_ValueChanged(object sender, EventArgs e)
        {
            numTotal.Value = numTotal.Value + numLaborAmt.Value;
        }

        private void numLaborAmt_Enter(object sender, EventArgs e)
        {
            numLaborAmt.Select(0, numLaborAmt.Text.Length);
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            fProduct oFProduct = new fProduct();
            oFProduct.ShowDlg(new Product(), true);
        }

        private void numWDPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numSRate.Value = numWDPrice.Value;
                numUTotalAmt.Value = (numQTY.Value * numWDPrice.Value);
                if (numQTY.Value > 0)
                    numPRate.Value = ((numUTotalAmt.Value - numPPDisAmt.Value) / numQTY.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MRP Rate");
            }

        }

        private void numWDPrice_Enter(object sender, EventArgs e)
        {
            numWDPrice.Select(0, numWDPrice.Text.Length);
        }

        private void dgPreOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                POrder oPOrder = _PrePOrder;
                _POrderDetail = dgPreOrder.Rows[e.RowIndex].Tag as POrderDetail;


                _Stock = db.Stocks.FirstOrDefault(o => o.ProductID == _POrderDetail.ProductID && o.ColorID == _POrderDetail.ColorID);

                if (_Stock != null)
                {
                    StockDetail stockdetail = null;
                    foreach (var item in _POrderDetail.POProductDetails)
                    {
                        stockdetail = _Stock.StockDetails.FirstOrDefault(x => x.IMENO == item.IMENo);
                        if (stockdetail != null)
                            db.StockDetails.Remove(stockdetail);
                    }

                }

                numNetDiscount.Value -= (_POrderDetail.PPDISAmt * _POrderDetail.Quantity);
                numGrandTotal.Value = numGrandTotal.Value - (_POrderDetail.TAmount + (_POrderDetail.PPDISAmt * _POrderDetail.Quantity));
                //numPWTDAmt.Value = numPWTDAmt.Value - (decimal)_POrderDetail.PPDISAmt; ;

                RefreshGridAfterSelect();

                if (db.POrderDetails.Any(o => o.POrderDetailID == _POrderDetail.POrderDetailID))
                {
                    db.POProductDetails.RemoveRange(_POrderDetail.POProductDetails);
                    db.POrderDetails.Remove(_POrderDetail);
                }
                else
                {
                    _PrePOrder.POrderDetails.Remove(_POrderDetail);
                }

                ctlPreOrProduct.SelectedID = _POrderDetail.ProductID;
                numQTY.ValueChanged -= numQTY_ValueChanged;
                numQTY.Value = (decimal)(_POrderDetail.Quantity);
                numQTY.ValueChanged += numQTY_ValueChanged;

                numPRate.ValueChanged -= numPRate_ValueChanged;
                numPRate.Value = (decimal)_POrderDetail.UnitPrice;
                numPRate.ValueChanged += numPRate_ValueChanged;

                numDPerc.ValueChanged -= numDPerc_ValueChanged;
                numDPerc.Value = (decimal)_POrderDetail.PPDISPer;
                numDPerc.ValueChanged += numDPerc_ValueChanged;

                numPPDisAmt.ValueChanged -= numPPDisAmt_ValueChanged;
                numPPDisAmt.Value = (decimal)_POrderDetail.PPDISAmt;
                numPPDisAmt.ValueChanged += numPPDisAmt_ValueChanged;

                numWDPrice.ValueChanged -= numWDPrice_ValueChanged;
                numWDPrice.Value = _POrderDetail.MRPRate;
                numWDPrice.ValueChanged += numWDPrice_ValueChanged;

                numSRate.Value = _POrderDetail.SalesRate;
                numUTotalAmt.Value = (decimal)_POrderDetail.TAmount + (_POrderDetail.PPDISAmt * _POrderDetail.Quantity);
                ctlColor.SelectedID = _POrderDetail.ColorID;
                //numNetDiscount.Value = _PrePOrder.NetDiscount - _POrderDetail.PPDISAmt;
                RefreshGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numPackSize_Enter(object sender, EventArgs e)
        {
            numPacket.Select(0, numPacket.Text.Length);
        }

        private void numPackSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numQTY.Value = (numPacket.Value * _Product.PackSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pack Size");
            }
        }

        private void ctlColor_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                _Color = db.Colors.FirstOrDefault(o => o.ColorID == ctlColor.SelectedID);
                Stock os = null;
                if (ctlPreOrProduct.SelectedID > 0 && _Color != null)
                    os = db.Stocks.FirstOrDefault(o => o.ProductID == ctlPreOrProduct.SelectedID && o.ColorID == _Color.ColorID);

                if (os != null)
                {
                    numPreStock.Value = os.Quantity;
                }

                else
                {
                    numPreStock.Value = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPNew_Click(object sender, EventArgs e)
        {
            fProduct frm = new fProduct();
            frm.ShowDlg(new Product(), true);
        }

        private void btnCNew_Click(object sender, EventArgs e)
        {
            fColorInfo frm = new fColorInfo();
            frm.ShowDlg(new INVENTORY.DA.Color(), true);
        }

        private void dgvPOPDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPOPDetails.RowCount > 0)
                {
                    if (e.ColumnIndex == 2)
                    {

                        //  For i As Integer = 0 To Me.DataGridView1.RowCount - 2
                        //  For j As Integer = i + 1 To Me.DataGridView1.RowCount - 2
                        //    If DataGridView1.Rows(i).Cells(0).Value = DataGridView1.Rows(j).Cells(0).Value Then
                        //      MessageBox.Show("duplicate value " & DataGridView1.Rows(i).Cells(0).Value)
                        //    End If
                        //  Next
                        //Next

                        for (int i = 0; i < dgvPOPDetails.RowCount; i++)
                        {
                            for (int j = i + 1; j < dgvPOPDetails.RowCount; j++)
                            {
                                if (dgvPOPDetails[2, i].Value.ToString().Trim() != "")
                                {
                                    if (dgvPOPDetails[2, i].Value.ToString().Trim() == dgvPOPDetails[2, j].Value.ToString().Trim())
                                    {
                                        MessageBox.Show("This IMEI number already exists in PO." + dgvPOPDetails[2, j].Value);
                                    }
                                }
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

        private void numSRate_Enter(object sender, EventArgs e)
        {
            numSRate.Select(0, numSRate.Text.Length);
        }

        private void numDZKGLT_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Product != null)
                {
                    if (_Product.UnitType == (int)EnumUnitType.BOX)
                    {
                        numQTY.Value = numDZKGLT.Value * (decimal)_Product.BoxQty + numUnitQty.Value;
                    }
                    else
                    {
                        numQTY.Value = numUnitQty.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numUnitQty_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Product != null)
                {
                    if (_Product.UnitType == (int)EnumUnitType.BOX)
                    {
                        numQTY.Value = numDZKGLT.Value * (decimal)_Product.BoxQty + numUnitQty.Value;
                    }
                    else
                    {
                        numQTY.Value = numUnitQty.Value;
                    }

                    #region added aminul
                    numSRate.Value = numWDPrice.Value;
                    numUTotalAmt.Value = (numQTY.Value * numWDPrice.Value);
                    if (numQTY.Value > 0)
                    {
                        numPPDisAmt.Value = (numWDPrice.Value) * (numDPerc.Value / 100);
                        numPRate.Value = ((numUTotalAmt.Value - (numPPDisAmt.Value * numQTY.Value)) / numQTY.Value);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numDZKGLT_Enter(object sender, EventArgs e)
        {
            numDZKGLT.Select(0, numDZKGLT.Text.Length);
        }

        private void numUnitQty_Enter(object sender, EventArgs e)
        {
            numUnitQty.Select(0, numUnitQty.Text.Length);
        }

        private void numTempNetTotalAmt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numUTotalAmt_ValueChanged(object sender, EventArgs e)
        {
            numGSTAmt.Value = (numGSTPerc.Value / 100) * numUTotalAmt.Value;
            numCGSTAmt.Value = numGSTAmt.Value * (numCGSTPerc.Value / 100);
            numSGSTAmt.Value = numGSTAmt.Value * (numSGSTPerc.Value / 100);
            numIGSTAmt.Value = numGSTAmt.Value * (numIGSTPerc.Value / 100);
        

        }

        private void ctlGodown_Load(object sender, EventArgs e)
        {

        }

        private void ctlGodown_SelectedItemChanged(object sender, EventArgs e)
        {

        }

    }
}
