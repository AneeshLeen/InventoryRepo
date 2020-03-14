using INVENTORY.DA;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace INVENTORY.UI
{
    public partial class fSOrder : Form, IDisposable
    {
        bool ForNewCustomer = false;
        public Action ItemChanged;
        Product _oProduct = null;
        List<SOrderDetail> _OrderDetails = new List<SOrderDetail>();
        List<INVENTORY.DA.Color> _ColorList = new List<DA.Color>();
        List<Category> _CategoryList = new List<Category>();
        SOrderDetail _OrderDetail = null;
        SOrder _Order = null;
        Customer _oCustomer = null;
        DEWSRMEntities db = null;
        Stock _stock = null;
        StockDetail _StockDetail = null;
        private decimal _prevOrderdue = 0;
        private decimal _PrvCusDue = 0;
        private decimal _PreviousFlatDicount = 0;
        decimal taxper = 0;
        bool AllowNegativestock = true;

        frmpromo frmprmo;

        public fSOrder()
        {
            db = new DEWSRMEntities();
            InitializeComponent();
            frmprmo = new frmpromo();
            User oUser = db.Users.FirstOrDefault(o => o.UserName == Global.CurrentUser.UserName);
            if (oUser.UserType != (int)EnumUserType.Administrator)
            {
                frmprmo.Show();
            }

            RefreshPromo();
        }


        internal void LoadDefaultData(SOrder sOrder)
        {
            _Order = db.SOrders.FirstOrDefault(o => o.SOrderID == sOrder.SOrderID);
            _ColorList = db.Colors.ToList();
            _CategoryList = db.Categorys.ToList();
            ctlGodown.SelectedID = 1;
            if (_Order == null)
            {
                _Order = new SOrder();
                _Order.CreatedBy = Global.CurrentUser.UserID;
                _Order.CreateDate = DateTime.Now;

            }
            else
            {
                _prevOrderdue = (decimal)_Order.PaymentDue;
                _PrvCusDue = _Order.Customer.TotalDue - _prevOrderdue;
                _Order.ModifiedDate = (DateTime)DateTime.Today;
                _Order.ModifiedBy = (int)Global.CurrentUser.UserID;
                _PreviousFlatDicount = _Order.TDAmount;
                ctlCustomer.Enabled = false;
            }
            LoadDefaultCutomer();

            //RefreshWarrantyType();
            RefreshRemindType();

            if (sOrder.SOrderID > 0)
            {
                RefreshValue();
                RefreshGrid();
            }
            PopulateBankCombo();
            txtamt.Select();
            txtamt.Focus();
        }
        public void ShowDlg(SOrder oOrder)
        {
            LoadDefaultData(oOrder);

            this.ShowDialog();

        }

        //private void RefreshWarrantyType()
        //{


        //    cboWarrantyType.DisplayMember = "Name";
        //    cboWarrantyType.ValueMember = "ID";
        //    cboWarrantyType.DataSource = Enum.GetValues(typeof(EnumWarrantyType)).Cast<EnumWarrantyType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        //}
        private void PopulateBankCombo()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("BankID", typeof(int));
                dt.Columns.Add("BankName", typeof(string));
                DataRow row = null;
                var banks = db.Banks.ToList();

                row = dt.NewRow();
                row["BankID"] = 0;
                row["BankName"] = "--Select Bank--";
                dt.Rows.Add(row);

                foreach (var item in banks)
                {
                    row = dt.NewRow();
                    row["BankID"] = item.BankID;
                    row["BankName"] = item.BankName + " (" + item.AccountNo + ")";
                    dt.Rows.Add(row);

                }
                cmbBank.DisplayMember = "BankName";
                cmbBank.ValueMember = "BankID";
                cmbBank.DataSource = dt;
            }
        }
        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCardTypeCombo();
        }

        private void PopulateCardTypeCombo()
        {
            int BankID = Convert.ToInt32(cmbBank.SelectedValue);
            if (BankID > 0)
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CardTypeSetupID", typeof(int));
                    dt.Columns.Add("CardName", typeof(string));
                    DataRow row = null;
                    var cards = (from cts in db.CardTypeSetups.Where(x => x.BankID == (int)cmbBank.SelectedValue)
                                 join ct in db.CardTypes on cts.CardTypeID equals ct.CardTypeID
                                 where cts.BankID == BankID && ct.Status == 1
                                 select new
                                 {
                                     cts.CardTypeSetupID,
                                     ct.Description,
                                     ct.Sequence
                                 }).OrderBy(i => i.Sequence).ToList();
                    foreach (var item in cards)
                    {
                        row = dt.NewRow();
                        row["CardTypeSetupID"] = item.CardTypeSetupID;
                        row["CardName"] = item.Description;
                        dt.Rows.Add(row);
                    }
                    cmbCardType.DisplayMember = "CardName";
                    cmbCardType.ValueMember = "CardTypeSetupID";
                    cmbCardType.DataSource = dt;
                }
            }
        }
        private void RefreshRemindType()
        {
            cboRemindType.DisplayMember = "Name";
            cboRemindType.ValueMember = "ID";
            cboRemindType.DataSource = Enum.GetValues(typeof(EnumRemindType)).Cast<EnumRemindType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();

        }
        private void RefreshValue()
        {
            
            txtInvoice.Text = _Order.InvoiceNo != null ? _Order.InvoiceNo : "";
            dtpDate.Value = _Order.InvoiceDate != DateTime.MinValue ? _Order.InvoiceDate : DateTime.Now;

            numGrandTotal.ValueChanged -= numGrandTotal_ValueChanged;
            numGrandTotal.Value = Convert.ToDecimal(_Order.GrandTotal);
            numGrandTotal.ValueChanged += numGrandTotal_ValueChanged;

            numPaidAmt.ValueChanged -= numPaidAmt_ValueChanged;
            numPaidAmt.Value = Convert.ToDecimal(_Order.RecAmount);
            numPaidAmt.ValueChanged += numPaidAmt_ValueChanged;

            numTotalDueAmt.Value = Convert.ToDecimal(_Order.PaymentDue);
            numTotal.Value = Convert.ToDecimal(_Order.TotalAmount);
            numPrevDue.Value = 0;
            numTempNetTotalAmt.Value = Convert.ToDecimal(_Order.TotalAmount + _Order.TDAmount);

            numTDP.ValueChanged -= numTDP_ValueChanged;
            numTDP.Value = Convert.ToDecimal(_Order.TDPercentage);
            numTDP.ValueChanged += numTDP_ValueChanged;

            numTotalDis.ValueChanged -= numTotalDis_ValueChanged;
            numTotalDis.Value = Convert.ToDecimal(_Order.TDAmount);
            numTotalDis.ValueChanged += numTotalDis_ValueChanged;

            numNetDiscount.Value = Convert.ToDecimal(_Order.NetDiscount);
            //numPWTAmt.Value = Convert.ToDecimal(_Order.PPDiscountAmt);
            numVatAmount.ValueChanged -= numVatAmount_ValueChanged;
            numVatAmount.Value = Convert.ToDecimal(_Order.VATAmount);
            numVatAmount.ValueChanged += numVatAmount_ValueChanged;

            numVatPercent.ValueChanged -= numVatPercent_ValueChanged;
            numVatPercent.Value = Convert.ToDecimal(_Order.VATPercentage);
            numVatPercent.ValueChanged += numVatPercent_ValueChanged;

            numAdjustAmt.Value = _Order.Adjustment != null ? (decimal)_Order.Adjustment : 0;
            ctlCustomer.SelectedID = _Order.CustomerID;



            if (_Order.PaymentDue > 0 && _Order.RemindPeriod > 0 && _Order.RemindDate != null)
            {
                dtpRemindDate.Value = _Order.RemindDate.Value;
                numRemindPeriodTemp.Value = _Order.RemindPeriod;
                cboRemindType.SelectedValue = _Order.RemindStatus;
            }



            //Aneesh
            lblbilldisc.Text = numNetDiscount.Value.ToString();           
            lbltax.Text = numVatPercent.Value.ToString();
            lblbilltotal.Text = numTotal.Value.ToString();

            //


            dgProducts.Rows.Clear();

        }

        private void RefreshObject()
        {

            if (txtInvoice.Text == string.Empty)
            {
                txtInvoice.Text = GenerateInvoiceNo();
            }
            _Order.InvoiceNo = txtInvoice.Text;
            _Order.InvoiceDate = dtpDate.Value;
            _Order.SubTotal = _Order.GrandTotal = _Order.SOrderDetails.Sum(p => p.SRate + p.CGSTAmt);
            _Order.Adjustment = numAdjustAmt.Value;
            _Order.TotalAmount = _Order.SOrderDetails.Sum(p => p.SRate);//numUTotal.Value;
            //_Order.RecAmount = numPaidAmt.Value;
            //_Order.PaymentDue = numTotalDueAmt.Value;
            //_Order.TDPercentage = numTDP.Value;//Discount % of Total Dis. Amt.
            //_Order.TDAmount = numTotalDis.Value;
            //_Order.NetDiscount = numNetDiscount.Value;//Net Discount AMount [TDA+PPDISAmt]

            _Order.VATAmount = _Order.SOrderDetails.Sum(p => p.CGSTAmt);
            _Order.VATPercentage = _Order.SOrderDetails.Sum(p => p.CGSTPerc);

            _Order.Remarks = "";//txtRemarks.Text;
            _Order.CustomerID = ctlCustomer.SelectedID;
            // _Order.TotalDue = (numTotalDueAmt.Value + _PrvCusDue);//numTotalDueAmt.Value + (numPrevDue.Value - _prevOrderdue); //  change from Motiur
            _Order.Status = (int)EnumSalesType.Sales;
            //_Order.CreatedBy = Global.CurrentUser.UserID;
            //_Order.RemindPeriod = Convert.ToInt32(numRemindPeriodTemp.Value);
            //_Order.RemindStatus = (int)cboRemindType.SelectedValue;
            //if (_Order.PaymentDue > 0 && _Order.RemindPeriod > 0)
            //    _Order.RemindDate = dtpRemindDate.Value;


        }

        /// <summary>
        /// Add to Order
        /// </summary>
        private void RefrehSODetailsAndStockObject()
        {
            if (_Order == null)
            {
                _Order = new SOrder();

                _Order.CustomerID = ctlCustomer.SelectedID;
                _Order.SOrderDetails = new List<SOrderDetail>();
            }

            _Order.GrandTotal = (decimal)(numGrandTotal.Value + numUTotal.Value);

            #region Order Details
            if (_oProduct.ProductType == (int)EnumProductType.BarCode || _oProduct.ProductType == (int)EnumProductType.SerialNo)
            {
                _OrderDetail = new SOrderDetail();
                _OrderDetail.ProductID = _oProduct.ProductID;
                _OrderDetail.StockDetailID = ctlProduct.SelectedID;
                _OrderDetail.UnitPrice = (decimal)numUnitPrice.Value;
                _OrderDetail.PPDPercentage = numDPerc.Value;
                _OrderDetail.PPDAmount = (decimal)numPPDISAmt.Value;
                _OrderDetail.Quantity = (decimal)numQTY.Value;
                _OrderDetail.UTAmount = numUTotal.Value;
                _OrderDetail.MPRateTotal = (decimal)(numPRate.Value * numQTY.Value);
                _OrderDetail.MPRate = numPRate.Value; //StockDetails PRate

                _OrderDetail.SRate = numUnitPrice.Value - numPPDISAmt.Value;
                _OrderDetail.PRate = numPRate.Value;

                _OrderDetail.CompressorWarrenty = txtCompressor.Text;
                _OrderDetail.MotorWarrenty = txtMotor.Text;
                _OrderDetail.PanelWarrenty = txtPanel.Text;
                _OrderDetail.ServiceWarrenty = txtService.Text;
                _OrderDetail.SparePartsWarrenty = txtSpareparts.Text;

                _OrderDetail.GSTPerc = numGSTPerc.Value;
                _OrderDetail.CGSTPerc = numCGSTPerc.Value;
                _OrderDetail.SGSTPerc = numSGSTPerc.Value;
                _OrderDetail.IGSTPerc = numIGSTPerc.Value;
                _OrderDetail.GSTAmt = numGSTAmt.Value;
                _OrderDetail.CGSTAmt = numCGSTAmt.Value;
                _OrderDetail.SGSTAmt = numSGSTAmt.Value;
                _OrderDetail.IGSTAmt = numIGSTAmt.Value;
                _OrderDetail.GodownID = ctlGodown.SelectedID;


                if (chKFreeQty.Checked)
                    _OrderDetail.IsFree = 1;
                else
                    _OrderDetail.IsFree = 0;

                _Order.SOrderDetails.Add(_OrderDetail);

                numNetDiscount.Value += _OrderDetail.PPDAmount * _OrderDetail.Quantity;
                numGrandTotal.Value = (decimal)(numGrandTotal.Value + (_OrderDetail.UnitPrice * _OrderDetail.Quantity));
                numTempNetTotalAmt.Value = numTempNetTotalAmt.Value + _OrderDetail.UTAmount;
            }

            #endregion

            #region Stock
            decimal SoldQuanity = numQTY.Value;
            if (_stock != null)
            {
                _stock.Quantity = numStock.Value;
                if (_oProduct.ProductType == (int)EnumProductType.NoBarCode)
                {

                    var StockDetails = db.StockDetails.Where(i => i.ProductID == _oProduct.ProductID && i.ColorID == _StockDetail.ColorID && i.Status == (int)EnumStockDetailStatus.Stock && i.GodownID == ctlGodown.SelectedID);
                    foreach (var item in StockDetails)
                    {
                        _OrderDetail = new SOrderDetail();
                        _OrderDetail.ProductID = _oProduct.ProductID;
                        _OrderDetail.StockDetailID = item.SDetailID;
                        _OrderDetail.Quantity = (decimal)numQTY.Value;
                        _OrderDetail.UnitPrice = (decimal)numUnitPrice.Value;
                        _OrderDetail.PPDPercentage = numDPerc.Value;
                        _OrderDetail.PPDAmount = numPPDISAmt.Value;
                        _OrderDetail.SRate = numUnitPrice.Value - numPPDISAmt.Value;
                        _OrderDetail.MPRate = (decimal)item.PRate; //StockDetails PRate
                        _OrderDetail.PRate = (decimal)item.PRate;

                        _OrderDetail.CompressorWarrenty = txtCompressor.Text;
                        _OrderDetail.MotorWarrenty = txtMotor.Text;
                        _OrderDetail.PanelWarrenty = txtPanel.Text;
                        _OrderDetail.ServiceWarrenty = txtService.Text;
                        _OrderDetail.SparePartsWarrenty = txtSpareparts.Text;
                        _OrderDetail.GodownID = ctlGodown.SelectedID;
                        _OrderDetail.GSTPerc = numGSTPerc.Value;
                        _OrderDetail.CGSTPerc = numCGSTPerc.Value;
                        _OrderDetail.SGSTPerc = numSGSTPerc.Value;
                        _OrderDetail.IGSTPerc = numIGSTPerc.Value;
                        _OrderDetail.GSTAmt = numGSTAmt.Value;
                        _OrderDetail.CGSTAmt = numCGSTAmt.Value;
                        _OrderDetail.SGSTAmt = numSGSTAmt.Value;
                        _OrderDetail.IGSTAmt = numIGSTAmt.Value;


                        if (chKFreeQty.Checked)
                            _OrderDetail.IsFree = 1;
                        else
                            _OrderDetail.IsFree = 0;

                        if (item.Quantity == SoldQuanity)
                        {
                            _OrderDetail.Quantity = SoldQuanity;
                            _OrderDetail.UTAmount = _OrderDetail.SRate * SoldQuanity;
                            _OrderDetail.MPRateTotal = (decimal)item.PRate * SoldQuanity;


                            item.Quantity -= SoldQuanity;
                            item.Status = (int)EnumStockDetailStatus.Sold;
                            _Order.SOrderDetails.Add(_OrderDetail);
                            break;
                        }
                        else if (item.Quantity > SoldQuanity)
                        {
                            _OrderDetail.Quantity = SoldQuanity;

                            _OrderDetail.UTAmount = _OrderDetail.SRate * SoldQuanity;
                            _OrderDetail.MPRateTotal = (decimal)item.PRate * SoldQuanity;

                            item.Quantity -= SoldQuanity;
                            _Order.SOrderDetails.Add(_OrderDetail);
                            break;
                        }
                        else if (item.Quantity < SoldQuanity)
                        {
                            _OrderDetail.Quantity = item.Quantity;
                            _OrderDetail.UTAmount = _OrderDetail.SRate * item.Quantity;
                            _OrderDetail.MPRateTotal = (decimal)item.PRate * item.Quantity;

                            SoldQuanity = SoldQuanity - item.Quantity;
                            item.Quantity = 0m;
                            item.Status = (int)EnumStockDetailStatus.Sold;
                            _Order.SOrderDetails.Add(_OrderDetail);
                        }

                    }
                }
                else
                {
                    _StockDetail.Status = (int)EnumStockDetailStatus.Sold;
                }
            }
            #endregion

            if (_oProduct.ProductType == (int)EnumProductType.NoBarCode)
            {
                numNetDiscount.Value += numPPDISAmt.Value * numQTY.Value;
                numGrandTotal.Value = (decimal)(numGrandTotal.Value + (numUnitPrice.Value * numQTY.Value));
                numTempNetTotalAmt.Value = numTempNetTotalAmt.Value + numUTotal.Value;
            }

            RefreshGrid();
            RefreshControl();

        }


        private void RefrehSODetailsAndStockObjectNew()
        {
            CreateOrderObject();

            if (_Order.SOrderDetails.AsEnumerable().Any(p => p.ProductID == _oProduct.ProductID && p.TypeID == (int)EnumSalesItemType.Product))
            {
                _OrderDetail = _Order.SOrderDetails.FirstOrDefault(p => p.ProductID == _oProduct.ProductID && p.TypeID == (int)EnumSalesItemType.Product);
                multiple = multiple + _OrderDetail.Quantity;

            }
            else
            {
                _OrderDetail = new SOrderDetail();
            }

            _OrderDetail.ProductID = _oProduct.ProductID;
            _OrderDetail.Quantity = multiple;

            if (_StockDetail!=null)
            {
                _OrderDetail.StockDetailID = _StockDetail.SDetailID;
            }
            else
            {
                _OrderDetail.StockDetailID = 0;
            }

            _OrderDetail.UnitPrice = _oProduct.SalesRate;
            _OrderDetail.SRate = _oProduct.SalesRate;
            _OrderDetail.PRate = _oProduct.SalesRate;

            //_OrderDetail.PPDPercentage = numDPerc.Value;
            //_OrderDetail.PPDAmount = numPPDISAmt.Value;
            _OrderDetail.UTAmount = (_OrderDetail.UnitPrice - _OrderDetail.PPDAmount) * multiple;
            if (_OrderDetail.PPDPercentage > 0)
                _OrderDetail.MPRateTotal = ((_OrderDetail.UnitPrice * _OrderDetail.PPDPercentage) / 100) * multiple;
            else
                _OrderDetail.MPRateTotal = _OrderDetail.UnitPrice * multiple;

            _OrderDetail.MPRate = _OrderDetail.UnitPrice - ((_OrderDetail.UnitPrice * _OrderDetail.PPDPercentage) / 100); //StockDetails PRate

            _OrderDetail.PRateTotal = _OrderDetail.PRate * multiple;

            _OrderDetail.CGSTPerc = _oProduct.Tax;
            _OrderDetail.CGSTAmt = Convert.ToDecimal(String.Format("{0:0.00}", _OrderDetail.SRate * _oProduct.Tax / 100));

            //_OrderDetail.CompressorWarrenty = txtCompressor.Text;
            //_OrderDetail.MotorWarrenty = txtMotor.Text;
            //_OrderDetail.PanelWarrenty = txtPanel.Text;
            //_OrderDetail.ServiceWarrenty = txtService.Text;
            _OrderDetail.SparePartsWarrenty = txtSpareparts.Text;
            _OrderDetail.GodownID = ctlGodown.SelectedID;
            //_OrderDetail.GSTPerc = numGSTPerc.Value;
            //_OrderDetail.CGSTPerc = numCGSTPerc.Value;
            //_OrderDetail.SGSTPerc = numSGSTPerc.Value;
            //_OrderDetail.IGSTPerc = numIGSTPerc.Value;
            //_OrderDetail.GSTAmt = numGSTAmt.Value;
            //_OrderDetail.CGSTAmt = numCGSTAmt.Value;
            //_OrderDetail.SGSTAmt = numSGSTAmt.Value;
            //_OrderDetail.IGSTAmt = numIGSTAmt.Value;

            _OrderDetail.TypeID = (int)EnumSalesItemType.Product;

            if (chKFreeQty.Checked)
                _OrderDetail.IsFree = 1;
            else
                _OrderDetail.IsFree = 0;

            if (!_Order.SOrderDetails.AsEnumerable().Any(p => p.ProductID == _oProduct.ProductID && p.TypeID == (int)EnumSalesItemType.Product))
            {
                _Order.SOrderDetails.Add(_OrderDetail);
            }


            RefreshGridNew();
            RefreshControl();
            ClearDefaultTextBox();
            multiple = 1;
        }

        private void RefreshGridNew()
        {
            try
            {
                int count = 0;
                int nSLNo = 1;
                dgProducts.Rows.Clear();
                List<SOrderDetail> nobarcodeSOrderDetailList = new List<SOrderDetail>();
                _OrderDetails = _Order.SOrderDetails.ToList();

                if (_OrderDetails.Count > 0)
                {
                    foreach (SOrderDetail oPODItem in _OrderDetails)
                    {
                        dgProducts.Rows.Add();
                        if (oPODItem.TypeID == (int)EnumSalesItemType.Product)
                        {
                            Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == oPODItem.ProductID);
                            if (oProduct != null)
                            {
                                dgProducts.Rows[count].Cells[1].Value = oProduct.ProductName;
                                //_StockDetail = db.StockDetails.FirstOrDefault(x => x.SDetailID == oPODItem.StockDetailID);
                                //INVENTORY.DA.Color oColor = _ColorList.FirstOrDefault(c => c.ColorID == _StockDetail.ColorID);
                            }
                        }
                        else
                        {
                            Category oCategory = _CategoryList.FirstOrDefault(c => c.CategoryID == oPODItem.ProductID);
                            dgProducts.Rows[count].Cells[1].Value = oCategory.Description;
                        }



                        dgProducts.Rows[count].Cells[0].Value = nSLNo.ToString();

                        //dgProducts.Rows[count].Cells[2].Value = oColor.Description;//_StockDetail.Stock.Color.Description;
                        //dgProducts.Rows[count].Cells[3].Value = oCategory.Description;//_StockDetail.Stock.Color.Description;
                        //dgProducts.Rows[count].Cells[2].Value = _StockDetail.IMENO;
                        dgProducts.Rows[count].Cells[2].Value = oPODItem.Quantity.ToString();
                        dgProducts.Rows[count].Cells[3].Value = oPODItem.SRate.ToString();
                        dgProducts.Rows[count].Cells[4].Value = (oPODItem.SRate * oPODItem.Quantity).ToString();
                        dgProducts.Rows[count].Cells[5].Value = oPODItem.CGSTAmt.ToString();
                        //Aneesh
                        //lblbillqty.Text = oPODItem.Quantity.ToString();
                        //
                        //dgProducts.Rows[count].Cells[5].Value = oPODItem.UnitPrice.ToString();

                        //dgProducts.Rows[count].Cells[6].Value = oPODItem.PPDPercentage.ToString();
                        //dgProducts.Rows[count].Cells[7].Value = oPODItem.PPDAmount.ToString();
                        //dgProducts.Rows[count].Cells[8].Value = oPODItem.CGSTAmt.ToString();
                        //dgProducts.Rows[count].Cells[9].Value = oPODItem.SGSTAmt.ToString();
                        //dgProducts.Rows[count].Cells[10].Value = oPODItem.IGSTAmt.ToString();
                        //dgProducts.Rows[count].Cells[11].Value = oPODItem.CGSTAmt.ToString();
                        //dgProducts.Rows[count].Cells[12].Value = (oPODItem.UTAmount).ToString();

                        dgProducts.Rows[count].Tag = oPODItem;
                        count++;
                        nSLNo++;
                    }
                    calculatesum();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation Check

                if (ctlCustomer.SelectedID <= 0)
                {
                    MessageBox.Show("Please select customer for this Order.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlCustomer.Focus();
                    return;
                }

                if (ctlProduct.SelectedID <= 0)
                {
                    MessageBox.Show("Please select product for this Order.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlProduct.Focus();
                    return;
                }

                if (ctlGodown.SelectedID <= 0)
                {
                    MessageBox.Show("Please select Godown for this Order.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlGodown.Focus();
                    return;
                }

                if (numQTY.Value <= 0)
                {
                    MessageBox.Show("Please enter product quantity.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numQTY.Focus();
                    return;
                }

                if (chKFreeQty.Checked == false)
                {
                    if (numUnitPrice.Value <= 0)
                    {
                        MessageBox.Show("Please enter sales rate.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numUnitPrice.Focus();
                        return;
                    }
                }
                if (numStock.Value < 0)
                {
                    MessageBox.Show("Stock not available.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (_Order.SOrderDetails.Any(i => i.StockDetailID == ctlProduct.SelectedID))
                {
                    MessageBox.Show("This IMEI already added to this Order.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshControl();
                    return;
                }
                if (numTDP.Value > 0)
                {
                    numTDP.Value = 0m;
                }
                #endregion

                RefrehSODetailsAndStockObject();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void RefreshGrid()
        {

            try
            {
                int count = 0;
                int nSLNo = 1;
                dgProducts.Rows.Clear();
                List<SOrderDetail> nobarcodeSOrderDetailList = new List<SOrderDetail>();
                _OrderDetails = _Order.SOrderDetails.ToList();

                if (_OrderDetails.Count > 0)
                {
                    foreach (SOrderDetail oPODItem in _OrderDetails)
                    {
                        Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == oPODItem.ProductID);
                        if (oProduct.ProductType != (int)EnumProductType.NoBarCode)
                        {
                            dgProducts.Rows.Add();
                            _StockDetail = db.StockDetails.FirstOrDefault(x => x.SDetailID == oPODItem.StockDetailID);
                            INVENTORY.DA.Color oColor = _ColorList.FirstOrDefault(c => c.ColorID == _StockDetail.ColorID);

                            Category oCategory = _CategoryList.FirstOrDefault(c => c.CategoryID == oProduct.CategoryID);

                            dgProducts.Rows[count].Cells[0].Value = nSLNo.ToString();
                            if (oProduct != null)
                            {
                                dgProducts.Rows[count].Cells[1].Value = oProduct.ProductName;
                            }
                            dgProducts.Rows[count].Cells[2].Value = oColor.Description;//_StockDetail.Stock.Color.Description;
                            dgProducts.Rows[count].Cells[3].Value = oCategory.Description;//_StockDetail.Stock.Color.Description;
                            //dgProducts.Rows[count].Cells[2].Value = _StockDetail.IMENO;
                            dgProducts.Rows[count].Cells[4].Value = oPODItem.Quantity.ToString();
                            //Aneesh
                            lblbillqty.Text = oPODItem.Quantity.ToString();
                            //
                            dgProducts.Rows[count].Cells[5].Value = oPODItem.UnitPrice.ToString();

                            if (chKFreeQty.Checked)
                            {
                                dgProducts.Rows[count].Cells[6].Value = oPODItem.PPDPercentage.ToString();
                                dgProducts.Rows[count].Cells[7].Value = oPODItem.PPDAmount.ToString();
                                dgProducts.Rows[count].Cells[8].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[9].Value = oPODItem.SGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[10].Value = oPODItem.IGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[11].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[12].Value = (oPODItem.UTAmount).ToString();
                            }
                            else
                            {
                                dgProducts.Rows[count].Cells[6].Value = oPODItem.PPDPercentage.ToString();
                                dgProducts.Rows[count].Cells[7].Value = oPODItem.PPDAmount.ToString();
                                dgProducts.Rows[count].Cells[8].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[9].Value = oPODItem.SGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[10].Value = oPODItem.IGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[11].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[12].Value = (oPODItem.UTAmount).ToString();
                            }

                            dgProducts.Rows[count].Tag = oPODItem;
                            count++;
                            nSLNo++;
                        }
                        else
                        {
                            nobarcodeSOrderDetailList.Add(oPODItem);
                            //Aneesh
                            lblbillqty.Text =Convert.ToString(  Convert.ToDecimal(lblbillqty.Text.TrimEnd()) + Convert.ToDecimal(oPODItem.Quantity));
                            //
                        }

                    }

                    if (nobarcodeSOrderDetailList.Count != 0)
                    {
                        var nobarcodesd = from sod in nobarcodeSOrderDetailList
                                          join std in db.StockDetails on sod.StockDetailID equals std.SDetailID
                                          group sod by new { sod.ProductID, std.ColorID } into g
                                          select new SOrderDetail
                                          {
                                              ProductID = g.Key.ProductID,
                                              CompressorWarrenty = g.FirstOrDefault().CompressorWarrenty,
                                              MotorWarrenty = g.FirstOrDefault().MotorWarrenty,
                                              PanelWarrenty = g.FirstOrDefault().PanelWarrenty,
                                              SparePartsWarrenty = g.FirstOrDefault().SparePartsWarrenty,
                                              ServiceWarrenty = g.FirstOrDefault().ServiceWarrenty,
                                              Quantity = g.Sum(i => i.Quantity),
                                              UnitPrice = g.FirstOrDefault().UnitPrice,
                                              PPDAmount = g.FirstOrDefault().PPDAmount,
                                              PPDPercentage = g.FirstOrDefault().PPDPercentage,
                                              UTAmount = g.Sum(i => i.UTAmount),
                                              StockDetailID = g.FirstOrDefault().StockDetailID,
                                              CGSTAmt=g.FirstOrDefault().CGSTAmt,
                                              SGSTAmt = g.FirstOrDefault().SGSTAmt,
                                              IGSTAmt = g.FirstOrDefault().IGSTAmt,
                                              GSTAmt = g.FirstOrDefault().GSTAmt,
                                          };

                        foreach (var oPODItem in nobarcodesd)
                        {
                            dgProducts.Rows.Add();
                            Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == oPODItem.ProductID);

                            _StockDetail = db.StockDetails.FirstOrDefault(x => x.SDetailID == oPODItem.StockDetailID);
                            INVENTORY.DA.Color oColor = _ColorList.FirstOrDefault(c => c.ColorID == _StockDetail.ColorID);
                            Category oCategory = _CategoryList.FirstOrDefault(c => c.CategoryID == oProduct.CategoryID);

                            dgProducts.Rows[count].Cells[0].Value = nSLNo.ToString();
                            if (oProduct != null)
                            {
                                dgProducts.Rows[count].Cells[1].Value = oProduct.ProductName;
                            }
                            dgProducts.Rows[count].Cells[2].Value = oColor.Description;
                            dgProducts.Rows[count].Cells[3].Value = oCategory.Description;
                            //dgProducts.Rows[count].Cells[2].Value = _StockDetail.IMENO;
                            dgProducts.Rows[count].Cells[4].Value = oPODItem.Quantity.ToString();
                            dgProducts.Rows[count].Cells[5].Value = oPODItem.UnitPrice.ToString();

                            if (chKFreeQty.Checked)
                            {
                                dgProducts.Rows[count].Cells[6].Value = oPODItem.PPDPercentage.ToString();
                                dgProducts.Rows[count].Cells[7].Value = oPODItem.PPDAmount.ToString();
                                dgProducts.Rows[count].Cells[8].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[9].Value = oPODItem.SGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[10].Value = oPODItem.IGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[11].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[12].Value = (oPODItem.UTAmount).ToString();
                            }
                            else
                            {
                                dgProducts.Rows[count].Cells[6].Value = oPODItem.PPDPercentage.ToString();
                                dgProducts.Rows[count].Cells[7].Value = oPODItem.PPDAmount.ToString();
                                dgProducts.Rows[count].Cells[8].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[9].Value = oPODItem.SGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[10].Value = oPODItem.IGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[11].Value = oPODItem.CGSTAmt.ToString();
                                dgProducts.Rows[count].Cells[12].Value = (oPODItem.UTAmount).ToString();

                            }

                            dgProducts.Rows[count].Tag = oPODItem;
                            count++;
                            nSLNo++;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GenerateInvoiceNo()
        {
            int i = 0;
            i = db.SOrders.Count() + db.CreditSales.Count();
            if (_Order.SOrderID <= 0)
            {
                return "INV-000" + (i + 1);
            }
            else
            {
                return _Order.InvoiceNo;
            }
        }
        private void RefreshControl()
        {
            numQTY.Value = 0;
            numUTotal.Value = 0;
            numUnitPrice.Value = 0;
            numStock.Value = 0;
            numPRate.Value = 0;
            numDPerc.Value = 0;
            numPPDISAmt.Value = 0;
            numTDP.Value = 0;
            //numNetDiscount.Value = 0;
            ctlProduct.SelectedID = 0;
            chKFreeQty.Checked = false;

            //numVatPercent.Value = 0;
            txtCompressor.Text = string.Empty;
            txtMotor.Text = string.Empty;
            txtSpareparts.Text = string.Empty;
            txtPanel.Text = string.Empty;
            txtService.Text = string.Empty;
        }

        private void GenerateInvoiceOld()
        {
            try
            {
                SOrder oOrder = null;
                oOrder = _Order;
                DataTable orderdDT = new DataTable();
                rptDataSet.dtSalesInvoiceDataTable dt = new rptDataSet.dtSalesInvoiceDataTable();
                Customer oCustomer = oOrder.Customer;
                List<Product> oProducts = db.Products.ToList();
                Product oProduct = null;
                DataSet ds = new DataSet();
                foreach (SOrderDetail item in oOrder.SOrderDetails)
                {
                    oProduct = oProducts.FirstOrDefault(o => o.ProductID == item.ProductID);

                    dt.Rows.Add(oCustomer.Code, oCustomer.Name, oProduct.ProductName, item.Quantity, "", "", item.UnitPrice, item.UTAmount, oOrder.InvoiceNo, ((DateTime)oOrder.InvoiceDate).ToString("dd MMM yyyy"), oCustomer.Address);
                }
                orderdDT = dt.AsEnumerable().OrderBy(o => (String)o["Brand"]).CopyToDataTable();
                string brandName = "";
                string btandTotal = "";
                decimal sum = 0;
                int count = 0;
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow item in orderdDT.Rows)
                    {
                        if (brandName != item["Brand"].ToString())
                        {
                            if (count != 0)
                            {
                                btandTotal = btandTotal + brandName + "=" + sum + " |";
                            }
                            brandName = item["Brand"].ToString();
                            sum = 0;
                        }
                        sum += Convert.ToDecimal(item["MrpRate"].ToString());
                        count++;
                        if (count == dt.Rows.Count)
                        {
                            btandTotal = btandTotal + item["Brand"].ToString() + "=" + sum;
                        }
                    }
                }
                dt.TableName = "rptDataSet_dtSalesInvoice";
                ds.Tables.Add(dt);
                string embededResource = "INVENTORY.UI.RDLC.rptSalesInvoice.rdlc";
                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);
                rParam = new ReportParameter("BrandTotal", btandTotal);
                parameters.Add(rParam);
                fReportViewer frm = new fReportViewer();
                frm.CommonReportViewer(embededResource, ds, parameters, true);
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Cannot generate invoice due to " + Ex.Message);
            }
        }

        public void GenerateSOInvoice(SOrder oOrder)
        {
            try
            {
                DataTable orderdDT = new DataTable();
                rptDataSet.dtInvoiceDataTable dt = new rptDataSet.dtInvoiceDataTable();
                var Customer = db.Customers.FirstOrDefault(i => i.CustomerID == oOrder.CustomerID);

                List<Product> oProductList = db.Products.ToList();
                List<INVENTORY.DA.Color> oColorList = db.Colors.ToList();
                Product oProduct = null;
                INVENTORY.DA.Color oColor = null;
                DataSet ds = new DataSet();
                //string SChasisBarcode = string.Empty;

                List<StockDetail> oStockDetails = db.StockDetails.ToList();
                List<Stock> oStocks = db.Stocks.ToList();
                List<SOrderDetail> nobarcodeSOrderDetailList = new List<SOrderDetail>();

                string Warrenty = string.Empty;

                foreach (SOrderDetail item in oOrder.SOrderDetails)
                {
                    StockDetail std = oStockDetails.FirstOrDefault(x => x.SDetailID == item.StockDetailID);
                    Stock oSt = oStocks.FirstOrDefault(o => o.StockID == std.StockID);
                    oProduct = oProductList.FirstOrDefault(p => p.ProductID == std.ProductID);
                    oColor = oColorList.FirstOrDefault(o => o.ColorID == oSt.ColorID);


                    if (oProduct.ProductType != (int)EnumProductType.NoBarCode)
                    {

                        Warrenty = string.IsNullOrEmpty(item.CompressorWarrenty) ? "" : "Compressor: " + item.CompressorWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.MotorWarrenty) ? "" : "Motor: " + item.MotorWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.PanelWarrenty) ? "" : "Panel: " + item.PanelWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.SparePartsWarrenty) ? "" : "SpareParts: " + item.SparePartsWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.ServiceWarrenty) ? "" : "Service: " + item.ServiceWarrenty;

                        dt.Rows.Add(
                            oProduct.ProductName,
                              oProduct.Company.Description,
                              oProduct.Category.Description,
                              oColor.Description,
                               item.Quantity,
                               0,
                              item.UnitPrice,// - item.PPDAmount
                              (item.PPDAmount + ((oOrder.TDAmount - oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount) / item.UnitPrice) * 100,
                              ((oOrder.TDAmount - oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount),
                              item.UnitPrice - (item.PPDAmount + ((oOrder.TDAmount + oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount)),
                              item.Quantity * (item.UnitPrice - (item.PPDAmount + ((oOrder.TDAmount + oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount))),
                              std.IMENO,
                              Warrenty,
                              item.CGSTAmt,
                              item.SGSTAmt,
                              item.IGSTAmt,
                              item.GSTAmt
                              );

                        Warrenty = string.Empty;

                    }
                    else
                    {
                        nobarcodeSOrderDetailList.Add(item);
                    }

                }
                Warrenty = string.Empty;
                if (nobarcodeSOrderDetailList.Count() != 0)
                {
                    var nobarcodesd = from sod in nobarcodeSOrderDetailList
                                      join std in db.StockDetails on sod.StockDetailID equals std.SDetailID
                                      group sod by new { sod.ProductID, std.ColorID } into g
                                      select new
                                      {
                                          ProductID = g.Key.ProductID,
                                          StockDetailID = g.FirstOrDefault().StockDetailID,
                                          CompressorWarrenty = g.FirstOrDefault().CompressorWarrenty,
                                          MotorWarrenty = g.FirstOrDefault().MotorWarrenty,
                                          PanelWarrenty = g.FirstOrDefault().PanelWarrenty,
                                          SparePartsWarrenty = g.FirstOrDefault().SparePartsWarrenty,
                                          ServiceWarrenty = g.FirstOrDefault().ServiceWarrenty,
                                          Quantity = g.Sum(i => i.Quantity),
                                          UnitPrice = g.FirstOrDefault().UnitPrice,
                                          PPDAmount = g.FirstOrDefault().PPDAmount,
                                          PPDPercentage = g.FirstOrDefault().PPDPercentage,
                                          UTAmount = g.Sum(i => i.UTAmount),
                                          
                                          CGSTAmt=g.Sum(i=>i.CGSTAmt),
                                          SGSTAmt = g.Sum(i => i.SGSTAmt),
                                          IGSTAmt = g.Sum(i => i.IGSTAmt),
                                          GSTAmt = g.Sum(i => i.GSTAmt),
                                         
                                      };



                    foreach (var item in nobarcodesd)
                    {
                        StockDetail std = oStockDetails.FirstOrDefault(x => x.SDetailID == item.StockDetailID);
                        Stock oSt = oStocks.FirstOrDefault(o => o.StockID == std.StockID);
                        oProduct = oProductList.FirstOrDefault(p => p.ProductID == std.ProductID);
                        oColor = oColorList.FirstOrDefault(o => o.ColorID == oSt.ColorID);

                        Warrenty = string.IsNullOrEmpty(item.CompressorWarrenty) ? "" : "Compressor: " + item.CompressorWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.MotorWarrenty) ? "" : "Motor: " + item.MotorWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.PanelWarrenty) ? "" : "Panel: " + item.PanelWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.SparePartsWarrenty) ? "" : "SpareParts: " + item.SparePartsWarrenty + Environment.NewLine;
                        Warrenty += string.IsNullOrEmpty(item.ServiceWarrenty) ? "" : "Service: " + item.ServiceWarrenty;


                        dt.Rows.Add(
                              oProduct.ProductName,
                              oProduct.Company.Description,
                              oProduct.Category.Description,
                              oColor.Description,
                              item.Quantity,
                               0,
                              item.UnitPrice,// - item.PPDAmount
                             ((item.PPDAmount + ((oOrder.TDAmount + oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount)) / item.UnitPrice) * 100,//Percentage
                              item.PPDAmount + ((oOrder.TDAmount + oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount),
                              item.UnitPrice - (item.PPDAmount + ((oOrder.TDAmount + oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount)),
                              item.Quantity * (item.UnitPrice - (item.PPDAmount + ((oOrder.TDAmount + oOrder.Adjustment) / (oOrder.GrandTotal - oOrder.NetDiscount + oOrder.TDAmount)) * (item.UnitPrice - item.PPDAmount))),
                               "No Barcode",
                               Warrenty,
                              item.CGSTAmt,
                              item.SGSTAmt,
                              item.IGSTAmt,
                              item.GSTAmt
                         );
                        Warrenty = string.Empty;
                    }
                }

                //orderdDT = dt.AsEnumerable().OrderBy(o => (String)o["ProductName"]).CopyToDataTable();

                dt.TableName = "rptDataSet_dtInvoice";
                ds.Tables.Add(dt);

                string embededResource = "";
                embededResource = "INVENTORY.UI.RDLC.AMSalesInvoice.rdlc";

                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();

                //RCommission

                if (oOrder.RemindPeriod > 0)
                {
                    rParam = new ReportParameter("RemindDate", "Remainder Date :" + oOrder.RemindPeriod.ToString() + "  Day, " + Convert.ToDateTime(oOrder.RemindDate).ToString("dd MMM yyyy"));
                    parameters.Add(rParam);
                }

                rParam = new ReportParameter("TDiscount", oOrder.NetDiscount.ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("Total", (oOrder.GrandTotal - oOrder.NetDiscount).ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("NetOutStanding", (Customer.TotalDue - oOrder.PaymentDue + oOrder.GrandTotal + oOrder.VATAmount - oOrder.NetDiscount - oOrder.RecAmount - oOrder.Adjustment).ToString("F"));
                parameters.Add(rParam);


                string sInwodTk = Global.TakaFormat(Convert.ToDouble(oOrder.TotalAmount));
                rParam = new ReportParameter("InWordTK", sInwodTk);
                parameters.Add(rParam);


                rParam = new ReportParameter("VAT", oOrder.VATAmount.ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("PreDue", (Customer.TotalDue - oOrder.PaymentDue).ToString("F"));
                parameters.Add(rParam);

                //rParam = new ReportParameter("GTotal", (oOrder.GrandTotal + (oOrder.Customer.TotalDue - oOrder.PaymentDue)).ToString());

                rParam = new ReportParameter("AdjustAmt", oOrder.Adjustment.ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("GTotal", oOrder.GrandTotal.ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("PPOffer", (oOrder.NetDiscount - oOrder.TDAmount).ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("Paid", oOrder.RecAmount.ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("CurrDue", (oOrder.PaymentDue).ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("InvoiceNo", oOrder.InvoiceNo);
                parameters.Add(rParam);

                rParam = new ReportParameter("TotalDue", oOrder.TotalDue.ToString("F"));
                parameters.Add(rParam);

                rParam = new ReportParameter("InvoiceDate", oOrder.InvoiceDate.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Company", Customer.CompanyName);
                parameters.Add(rParam);

                rParam = new ReportParameter("CAddress", Customer.Address);
                parameters.Add(rParam);

                rParam = new ReportParameter("Name", Customer.Name);
                parameters.Add(rParam);

                rParam = new ReportParameter("MobileNo", Customer.ContactNo);
                parameters.Add(rParam);

                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);





                fReportViewer frm = new fReportViewer();
                frm.CommonReportViewer(embededResource, ds, parameters, true);
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Cannot generate invoice due to " + Ex.Message);
            }
        }
        public void MoneyReceipt(SOrder SOrder)
        {
            var oCustomer = db.Customers.FirstOrDefault(i => i.CustomerID == SOrder.CustomerID);
            DataSet ds = new DataSet();
            string embededResource = "INVENTORY.UI.RDLC.AMMoneyReceipt.rdlc";
            ReportParameter rParam = new ReportParameter();
            List<ReportParameter> parameters = new List<ReportParameter>();

            rParam = new ReportParameter("ReceiptNo", SOrder.InvoiceNo);
            parameters.Add(rParam);

            string sInwodTk = Global.TakaFormat(Convert.ToDouble(SOrder.RecAmount));
            sInwodTk = sInwodTk.Replace("Taka", "");
            sInwodTk = sInwodTk.Replace("Only", "Taka Only");

            rParam = new ReportParameter("ReceiptTK", SOrder.RecAmount.ToString());
            parameters.Add(rParam);

            rParam = new ReportParameter("BalanceDue", oCustomer.TotalDue.ToString());
            parameters.Add(rParam);

            rParam = new ReportParameter("ReceiptDate", SOrder.InvoiceDate.ToString());
            parameters.Add(rParam);

            rParam = new ReportParameter("Name", oCustomer.Name);
            parameters.Add(rParam);

            rParam = new ReportParameter("CusAddress", oCustomer.Address);
            parameters.Add(rParam);

            rParam = new ReportParameter("InWordTK", sInwodTk);
            parameters.Add(rParam);

            fReportViewer frm = new fReportViewer();
            frm.CommonReportViewer(embededResource, ds, parameters, true);
        }

        private void MoneyReceiptOld()
        {
            rptDataSet.dtMoneyReceiptDataTable dt = new rptDataSet.dtMoneyReceiptDataTable();
            DataSet ds = new DataSet();
            dt.Rows.Add(_oCustomer.Code, _oCustomer.Name, _oCustomer.Address, _Order.InvoiceNo, ((DateTime)_Order.InvoiceDate).ToString("dd MMM yyyy"), _oCustomer.TotalDue + _Order.GrandTotal, _Order.RecAmount, _Order.TDAmount, _Order.Remarks, Global.NumWords((int)_Order.RecAmount));
            dt.TableName = "rptDataSet_dtMoneyReceipt";
            ds.Tables.Add(dt);
            string embededResource = "INVENTORY.UI.RDLC.MoneyReceipt.rdlc";
            ReportParameter rParam = new ReportParameter();
            List<ReportParameter> parameters = new List<ReportParameter>();
            rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
            parameters.Add(rParam);
            fReportViewer frm = new fReportViewer();
            frm.CommonReportViewer(embededResource, ds, parameters, true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProducts.SelectedRows.Count > 0)
                {
                    SOrderDetail ordetail = dgProducts.SelectedRows[0].Tag as SOrderDetail;
                    if (numTDP.Value > 0)
                    {
                        numTDP.Value = 0m;
                    }
                    numNetDiscount.Value -= ordetail.PPDAmount * ordetail.Quantity;
                    numGrandTotal.Value = numGrandTotal.Value - (decimal)(ordetail.UnitPrice * ordetail.Quantity);
                    //numTotal.Value -= ordetail.UTAmount;
                    numTempNetTotalAmt.Value = numTotal.Value;
                    //numPWTAmt.Value = numPWTAmt.Value - (decimal)ordetail.PPDAmount;
                    _StockDetail = db.StockDetails.FirstOrDefault(o => o.SDetailID == ordetail.StockDetailID);
                    _stock = _StockDetail.Stock;
                    var product = db.Products.FirstOrDefault(i => i.ProductID == ordetail.ProductID);
                    if (_StockDetail != null)
                    {
                        _stock.Quantity = _stock.Quantity + ordetail.Quantity;
                        _stock.EntryDate = DateTime.Today;
                        if (product.ProductType == (int)EnumProductType.NoBarCode)
                        {
                            var nobarcodestockdetails = _Order.SOrderDetails.Where(i => i.ProductID == product.ProductID).ToList();
                            foreach (var item in nobarcodestockdetails)
                            {
                                var stockdetails = db.StockDetails.FirstOrDefault(i => i.SDetailID == item.StockDetailID);
                                stockdetails.Quantity += item.Quantity;
                                stockdetails.Status = (int)EnumStockDetailStatus.Stock;
                                if (_Order.SOrderID > 0)
                                {
                                    db.SOrderDetails.Remove(item);
                                }
                                else
                                {
                                    _Order.SOrderDetails.Remove(item);
                                }
                            }
                        }
                    }

                    if (product.ProductType != (int)EnumProductType.NoBarCode)
                    {
                        if (_Order.SOrderID > 0)
                        {
                            db.SOrderDetails.Remove(ordetail);
                        }
                        else
                        {
                            _Order.SOrderDetails.Remove(ordetail);
                        }
                    }

                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("select an item to remove", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        bool IsSaveOrderValid(SOrder sorder)
        {
            //if (sorder.GrandTotal == sorder.SOrderDetails.Sum(i => (i.UnitPrice * i.Quantity)) && sorder.SOrderDetails.Sum(i => (i.UnitPrice - i.PPDAmount) * i.Quantity) == sorder.SOrderDetails.Sum(i => i.UTAmount))
            //{
                return true;
            //}

            //return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSales();
        }

        private void SaveSales()
        {
            try
            {
                bool isNew = false, IsValid = false;


                if (_Order.SOrderID <= 0) //New
                {
                    RefreshObject();

                    #region Save Order validation Check

                    if (numAdjustAmt.Value > (numTotal.Value - numPaidAmt.Value))
                    {
                        MessageBox.Show("Adjustment Amount is not greater than Current Due.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    #endregion

                    IsValid = IsSaveOrderValid(_Order);
                    if (IsValid)
                    {
                        _Order.CreatedBy = Global.CurrentUser.UserID;
                        _Order.CreateDate = DateTime.Now;
                        _Order.SOrderID = db.SOrders.Count() > 0 ? db.SOrders.Max(obj => obj.SOrderID) + 1 : 1;

                        int detailid = db.SOrderDetails.Count() > 0 ? db.SOrderDetails.Max(obj => obj.SOrderDetailID) + 1 : 1;
                        foreach (SOrderDetail item in _Order.SOrderDetails)
                        {
                            item.SOrderDetailID = detailid;
                            detailid++;
                        }
                        db.SOrders.Add(_Order);
                        isNew = true;
                    }

                }
                else //Update
                {
                    if (_PreviousFlatDicount > 0 && numTotalDis.Value == 0)
                    {
                        if (MessageBox.Show("Do you want to add flat discount.", "Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    int detailid = db.SOrderDetails.Count() > 0 ? db.SOrderDetails.Max(obj => obj.SOrderDetailID) + 1 : 1;
                    foreach (SOrderDetail item in _Order.SOrderDetails)
                    {

                        if (item.SOrderDetailID <= 0)
                        {
                            item.SOrderDetailID = detailid;
                            detailid++;
                        }
                    }
                    RefreshObject();
                    IsValid = IsSaveOrderValid(_Order);
                    _Order.ModifiedDate = (DateTime)DateTime.Today;
                    _Order.ModifiedBy = (int)Global.CurrentUser.UserID;

                    #region Bank Transactions and Bank Update
                    if (_Order.BankTranID != 0)
                    {
                        FCreditSales bankdepo = new FCreditSales();
                        bankdepo.ReturnBankDepositTransaction(_Order.BankTranID);
                    }
                    #endregion

                }
                if (IsValid)
                {
                    using (var Transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //if (numCardPaidAmt.Value > 0 && (int)cmbBank.SelectedValue == 0)
                            //{
                            //    MessageBox.Show("Please select card.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    return;
                            //}
                            //if (cmbCardType.SelectedValue != null && numCardPaidAmt.Value > 0)
                            //{
                            //    int CardTypeSetupID = (int)cmbCardType.SelectedValue;
                            //    int BankTranID = 0;
                            //    decimal percentage = 0;
                            //    decimal CardPaidAmt = numCardPaidAmt.Value;

                            //    _Order.CardPaidAmount = CardPaidAmt;
                            //    _Order.CardTypeSetupID = CardTypeSetupID;
                            //    FCreditSale bankdepo = new FCreditSale();
                            //    BankTranID = bankdepo.BankDeposit(CardTypeSetupID, CardPaidAmt, _Order.InvoiceNo, dtpDate.Value, out percentage);
                            //    _Order.DepositChargePercent = percentage;
                            //    _Order.BankTranID = BankTranID;
                            //}

                            _oCustomer = (Customer)(db.Customers.FirstOrDefault(o => o.CustomerID == _Order.CustomerID));
                            _oCustomer.TotalDue = (_Order.TotalAmount - (_Order.CashPaidAmount + _Order.CardPaidAmount)) + _prevOrderdue;

                            db.SaveChanges();
                            Transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            MessageBox.Show("Transaction Failed." + Environment.NewLine + ex.Message, "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GenerateSOInvoice(_Order);
                    MoneyReceipt(_Order);


                }
                else
                {
                    MessageBox.Show("Order Failed. Please try again.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (ItemChanged != null)
                {
                    ItemChanged();
                }

                if (!isNew)
                {
                    this.Close();
                }


                _Order = new SOrder();
                RefreshValue();

                LoadDefaultCutomer();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void LoadDefaultCutomer()
        {
            if (db.Customers.Any(o => o.CustomerType == (int)EnumCustomerType.Default))
            {
                ctlCustomer.SelectedID = (db.Customers.FirstOrDefault(o => o.CustomerType == (int)EnumCustomerType.Default).CustomerID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmprmo.Close();

        }
        private void CalculatePaymentAmount()
        {
            numPaidAmt.Value = numCashDownPayment.Value + numCardPaidAmt.Value;
        }
        private void numQTY_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numQTY.Value != 0)
                {
                    numUTotal.Value = numQTY.Value * (numUnitPrice.Value - numPPDISAmt.Value);
                    numStock.Value = (_stock != null ? (decimal)_stock.Quantity : 0) - numQTY.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Qty. Control");
            }

        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            //numTotal.Value = numQTY.Value * numSell.Value - numDiscount.Value;
        }
        private void numTQTY_ValueChanged(object sender, EventArgs e)
        {
            //numStock.Value = (_stock!=null?(decimal)_stock.Quantity:0) - numTQTY.Value;
        }
        private void ctlCustomer_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                _oCustomer = (Customer)(db.Customers.FirstOrDefault(o => o.CustomerID == ctlCustomer.SelectedID));
                if (_oCustomer != null)
                {
                    numPrevDue.Value = _oCustomer.TotalDue;
                    if (_Order.InvoiceNo != null)
                    {
                        if (_Order.InvoiceNo.Length < 4)
                        {
                            txtInvoice.Text = GenerateInvoiceNo();
                        }
                    }
                    else
                    {
                        txtInvoice.Text = GenerateInvoiceNo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlProduct_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                _StockDetail = (StockDetail)(db.StockDetails.FirstOrDefault(o => o.SDetailID == ctlProduct.SelectedID));
                if (_StockDetail != null)
                {
                    _oProduct = _StockDetail.Product;
                    _stock = _StockDetail.Stock;

                    if (_oProduct != null)
                    {
                        if (_oProduct.ProductType == (int)EnumProductType.SerialNo || _oProduct.ProductType == (int)EnumProductType.BarCode)
                        {
                            numQTY.Value = 1;
                            numQTY.Enabled = false;
                        }
                        else //for nobarcode
                        {
                            numQTY.Enabled = true;
                            numQTY.Value = 0;
                            numStock.Value = _stock.Quantity;

                        }
                        numPRate.Value = (decimal)_StockDetail.PRate;
                        numUnitPrice.Value = _StockDetail.SalesRate;
                        txtCompressor.Text = _oProduct.CompressorWarrenty;
                        txtMotor.Text = _oProduct.MotorWarrenty;
                        txtSpareparts.Text = _oProduct.SparePartsWarrenty;
                        txtPanel.Text = _oProduct.PanelWarrenty;
                        txtService.Text = _oProduct.ServiceWarrenty;
                        numUnitPrice.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numPaidAmt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numTotal.Value >= (numPaidAmt.Value + numAdjustAmt.Value))
                    numTotalDueAmt.Value = numTotal.Value - (numPaidAmt.Value + numAdjustAmt.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void fOrder_Load(object sender, EventArgs e)
        {
            pnlbtndyan.Controls.Clear();
            LoadDatatable();
            int top = 5;
            int left = 1;
            int count = 0;
            Decimal line = Convert.ToDecimal(Branchlist.Rows.Count) / 3;

            foreach (DataRow row in Branchlist.Rows)
            {


                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = new Size(80, 63);
                btn.Font = new Font(Font.FontFamily, 9, FontStyle.Bold);
                btn.Text = row["Description"].ToString();
                btn.Tag = row;
                btn.BackColor = System.Drawing.Color.FromName(row["backcolor"].ToString());
                btn.ForeColor = System.Drawing.Color.FromName(row["forecolor"].ToString());
                pnlbtndyan.Controls.Add(btn);
                top += btn.Height + 2;
                btn.Click += new System.EventHandler(this.btn_Click);
                count++;
                if (count == Decimal.Ceiling(line))
                {
                    count = 0;
                    top = 5;
                    left += 81;
                }

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            //bd
            if (keyData == Keys.Enter)
            {

                return true;
            }

            else if (keyData == Keys.C)
            {
                RefreshControl();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void numTotalDis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (numTotalDis.Value > 0)
                //{

                numTDP.ValueChanged -= numTDP_ValueChanged;
                numTDP.Value = Math.Round((numTotalDis.Value * 100m) / numTotal.Value, 2);
                numTDP.ValueChanged += numTDP_ValueChanged;
                numNetDiscount.Value = (numGrandTotal.Value - numTempNetTotalAmt.Value) + numTotalDis.Value;
                numTotal.Value = numGrandTotal.Value - numNetDiscount.Value;

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numTotalDis");
            }
        }
        private void numUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numPPDISAmt.Value = (numDPerc.Value * numUnitPrice.Value) / 100m;
                numUTotal.Value = (numQTY.Value * (numUnitPrice.Value - numPPDISAmt.Value));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numUnitPrice");
            }

        }
        private void numLaborAmt_ValueChanged(object sender, EventArgs e)
        {
            //numTotal.Value = numTotal.Value + numLaborAmt.Value;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ForNewCustomer = true;
                fCustomer ofCustomer = new fCustomer();
                ofCustomer.ShowDlg(new Customer(), true);

                if (ForNewCustomer)
                {
                    db = new DEWSRMEntities();
                    List<Customer> oCusList = db.Customers.ToList();
                    ctlCustomer.SelectedID = oCusList[oCusList.Count - 1].CustomerID;
                    ForNewCustomer = false;
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
                numPPDISAmt.Value = ((numUnitPrice.Value) * (numDPerc.Value / 100));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dis. Per.");
            }
        }

        private void numPWTAmt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numNetDiscount.ValueChanged -= numNetDiscount_ValueChanged;
                numNetDiscount.Value = numTotalDis.Value + numPWTAmt.Value;//Newly Added By Motiur
                numNetDiscount.ValueChanged += numNetDiscount_ValueChanged;
                numTotal.Value = numGrandTotal.Value + numVatAmount.Value - numNetDiscount.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numPWTAmt");
            }

        }
        private void numNetDiscount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numGrandTotal.Value >= numNetDiscount.Value)
                    numTotal.Value = numGrandTotal.Value + numVatAmount.Value - numNetDiscount.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "nmNetDis");
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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numTDP");
            }

        }

        private void numGrandTotal_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numGrandTotal.Value >= 0)
                {
                    numTotalDis.Value = (numTotal.Value) * (numTDP.Value / 100);

                    if (numGrandTotal.Value >= numNetDiscount.Value)
                        numVatAmount.Value = (numGrandTotal.Value - numNetDiscount.Value) * (numVatPercent.Value / 100);

                    if ((numGrandTotal.Value + numVatAmount.Value) >= numNetDiscount.Value)
                        numTotal.Value = numGrandTotal.Value + numVatAmount.Value - numNetDiscount.Value;

                    numTotalDueAmt.Value = numTotal.Value - numPaidAmt.Value;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numGrandTotal");
            }
        }

        private void numUnitPrice_Enter(object sender, EventArgs e)
        {
            numUnitPrice.Select(0, numUnitPrice.Text.Length);
        }

        private void numQTY_Enter(object sender, EventArgs e)
        {
            numQTY.Select(0, numQTY.Text.Length);
        }

        private void numDPerc_Enter(object sender, EventArgs e)
        {
            numDPerc.Select(0, numDPerc.Text.Length);
        }

        private void numDiscount_Enter(object sender, EventArgs e)
        {
            numPPDISAmt.Select(0, numPPDISAmt.Text.Length);
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

        private void numVatPercent_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numVatAmount.ValueChanged -= numVatAmount_ValueChanged;
                numVatAmount.Value = (numGrandTotal.Value - numNetDiscount.Value) * (numVatPercent.Value / 100);
                numVatAmount.ValueChanged += numVatAmount_ValueChanged;

                numTotal.Value = numGrandTotal.Value + numVatAmount.Value - numNetDiscount.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numVatPer");
            }
        }

        private void numVatAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numTotal.Value = numGrandTotal.Value + numVatAmount.Value - numNetDiscount.Value;
                numVatPercent.ValueChanged -= numVatPercent_ValueChanged;
                if (numTotal.Value > 0)
                    numVatPercent.Value = (numVatAmount.Value * 100m) / numTotal.Value;
                numVatPercent.ValueChanged += numVatPercent_ValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "numVatAmt");
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
         //if (ctlProduct.SelectedID == 0)
         //   {
         //       try
         //       {
         //           if (txtBarcode.Text != string.Empty)
         //           {
         //               _StockDetail = (StockDetail)(db.StockDetails.FirstOrDefault(o => o.IMENO == txtBarcode.Text.Trim() && o.Status == (int)EnumStockDetailStatus.Stock));
         //               if (_StockDetail != null)
         //               {
         //                   _oProduct = _StockDetail.Product;
         //                   _stock = _StockDetail.Stock;

         //                   if (_oProduct != null)
         //                   {
         //                       if (_oProduct.ProductType == (int)EnumProductType.SerialNo || _oProduct.ProductType == (int)EnumProductType.BarCode)
         //                       {
         //                           numQTY.Value = 1;
         //                           numQTY.Enabled = false;
         //                       }
         //                       else //for nobarcode
         //                       {
         //                           numQTY.Enabled = true;
         //                           numQTY.Value = 0;
         //                           numStock.Value = _stock.Quantity;

         //                       }
         //                       numPRate.Value = (decimal)_StockDetail.PRate;
         //                       numUnitPrice.Value = _StockDetail.SalesRate;
         //                       txtBarcode.Text = _StockDetail.IMENO;
         //                       numUnitPrice.Focus();
         //                   }
         //               }
         //           }
         //       }
         //       catch (Exception ex)
         //       {
         //           MessageBox.Show(ex.Message, "Barcode");
         //       }
         //   }
        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {

        }

        private void chKFreeQty_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numPPDISAmt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numUnitPrice.Value > 0m)
                {
                    numDPerc.ValueChanged -= numDPerc_ValueChanged;
                    numDPerc.Value = (numPPDISAmt.Value * 100m) / numUnitPrice.Value;
                    numDPerc.ValueChanged += numDPerc_ValueChanged;
                    numUTotal.Value = numQTY.Value * (numUnitPrice.Value - numPPDISAmt.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numRemindPeriod_ValueChanged(object sender, EventArgs e)
        {

            dtpRemindDate.Value = dtpDate.Value.AddDays((int)Math.Round(numRemindPeriod.Value, 0));


            if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Days)
            {
                numRemindPeriodTemp.Value = numRemindPeriod.Value;
            }
            else if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Months)
            {
                numRemindPeriodTemp.Value = (int)Math.Round(numRemindPeriod.Value / 30, 0);
            }
            else if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Years)
            {
                numRemindPeriodTemp.Value = (int)Math.Round(numRemindPeriod.Value / 365, 0);
            }
        }

        private void dtpRemindDate_ValueChanged(object sender, EventArgs e)
        {
            int days = (dtpRemindDate.Value - dtpDate.Value).Days;
            if ((dtpRemindDate.Value - dtpDate.Value).Hours > 12)
            {
                days = days + 1;
            }
            numRemindPeriod.Value = days;
        }

        private void dtpRemindDate_Enter(object sender, EventArgs e)
        {

        }

        private void cboRemindType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Days)
            {
                dtpRemindDate.Value = dtpDate.Value.AddDays((int)Math.Round(numRemindPeriodTemp.Value, 0));
            }
            else if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Months)
            {
                dtpRemindDate.Value = dtpDate.Value.AddMonths((int)numRemindPeriodTemp.Value);
            }
            else if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Years)
            {
                dtpRemindDate.Value = dtpDate.Value.AddYears((int)numRemindPeriodTemp.Value);
            }
        }

        private void numCardPaidAmt_ValueChanged(object sender, EventArgs e)
        {
            CalculatePaymentAmount();
        }

        private void numCashDownPayment_ValueChanged(object sender, EventArgs e)
        {
            CalculatePaymentAmount();
        }

        private void numRemindPeriodTemp_ValueChanged(object sender, EventArgs e)
        {
            if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Days)
            {
                dtpRemindDate.Value = dtpDate.Value.AddDays((int)Math.Round(numRemindPeriodTemp.Value, 0));

            }
            else if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Months)
            {
                dtpRemindDate.Value = dtpDate.Value.AddMonths((int)Math.Round(numRemindPeriodTemp.Value, 0));
            }
            else if ((int)cboRemindType.SelectedValue == (int)EnumRemindType.Years)
            {
                dtpRemindDate.Value = dtpDate.Value.AddYears((int)Math.Round(numRemindPeriodTemp.Value, 0));
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void numUTotal_ValueChanged(object sender, EventArgs e)
        {
            numGSTAmt.Value = (numGSTPerc.Value / 100) * numUTotal.Value ;
            numCGSTAmt.Value = numGSTAmt.Value * (numCGSTPerc.Value / 100);
            numSGSTAmt.Value = numGSTAmt.Value * (numSGSTPerc.Value / 100);
            numIGSTAmt.Value = numGSTAmt.Value * (numIGSTPerc.Value / 100);
        


        }

        private void ctlGodown_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void numSGSTAmt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numGSTPerc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numGSTPerc_Enter(object sender, EventArgs e)
        {
            numGSTPerc.Select(0, numGSTPerc.Text.Length);
        }

        private void numCGSTPerc_Enter(object sender, EventArgs e)
        {
            numCGSTPerc.Select(0, numCGSTPerc.Text.Length);
        }

        private void numSGSTPerc_Enter(object sender, EventArgs e)
        {
            numSGSTPerc.Select(0, numSGSTPerc.Text.Length);
        }

        private void numIGSTPerc_Enter(object sender, EventArgs e)
        {
            numIGSTPerc.Select(0, numIGSTPerc.Text.Length);
        }


        //Aneesh
        public DataTable Branchlist = new DataTable();
        public DataTable payoutlist = new DataTable();
        internal DataTable ReadAllCategories()
        {
            //using (DEWSRMEntities db = new DEWSRMEntities())
            //{
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];

            DataTable dtbranches = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRM;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("SELECT * FROM[dbo].[Categorys]  cat WHERE cat.CategoryID NOT IN(SELECT CategoryID FROM[dbo].[Products]) and cat.inactive = 'false' and ispayout='false'", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtbranches);
            return dtbranches;
            //}
        }

        private void LoadDatatable()
        {
            Branchlist = ReadAllCategories();
        }

        internal DataTable ReadAllpayouts()
        {
            //using (DEWSRMEntities db = new DEWSRMEntities())
            //{
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
            DataTable dtpayouts = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRM;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("SELECT * FROM[dbo].[Categorys]  cat WHERE cat.CategoryID NOT IN(SELECT CategoryID FROM[dbo].[Products]) and cat.inactive = 'false' and ispayout='true'", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtpayouts);
            return dtpayouts;
            // }
        }

        private void LoadpayoutDatatable()
        {
            payoutlist = ReadAllpayouts();
        }

        //

       

        private void btn_Click(object sender, EventArgs e)
        {
            DataRow row = ((Button)sender).Tag as DataRow;
            AddCategoryToGrid(row,false);
        }

        private void AddCategoryToGrid(DataRow row,bool IsPayout)
        {
           
            if (txtamt.Text == String.Empty)
            {
                MessageBox.Show("Invalid Selection");
                return;
            }

            decimal NegativeAmount = 1;
            if (IsPayout)
            {
                NegativeAmount = -1;
            }

            CreateOrderObject();
            decimal amount = Convert.ToDecimal(txtamt.Text);
            if (!IsPayout && _Order.SOrderDetails.AsEnumerable().Any(p => p.ProductID == Convert.ToInt32(row["CategoryID"]) && p.TypeID == (int)EnumSalesItemType.Category))
            {
                _OrderDetail = _Order.SOrderDetails.FirstOrDefault(p => p.ProductID == Convert.ToInt32(row["CategoryID"]) && p.TypeID == (int)EnumSalesItemType.Category);
                multiple = multiple + _OrderDetail.Quantity;
                amount = _OrderDetail.SRate;

            }
            else
            {
                _OrderDetail = new SOrderDetail();
            }

            _OrderDetail.ProductID = Convert.ToInt32(row["CategoryID"]);
            _OrderDetail.StockDetailID = 0;
            _OrderDetail.Quantity = multiple;
            _OrderDetail.UnitPrice = amount * NegativeAmount;
            _OrderDetail.SRate = amount * NegativeAmount;
            //_OrderDetail.PPDPercentage = numDPerc.Value;
            //_OrderDetail.PPDAmount = numPPDISAmt.Value;
            _OrderDetail.UTAmount = _OrderDetail.UnitPrice * multiple;
            if (_OrderDetail.PPDPercentage > 0)
                _OrderDetail.MPRateTotal = ((_OrderDetail.UnitPrice * _OrderDetail.PPDPercentage) / 100) * multiple;
            else
                _OrderDetail.MPRateTotal = _OrderDetail.UnitPrice * multiple;

            _OrderDetail.MPRate = _OrderDetail.UnitPrice - ((_OrderDetail.UnitPrice * _OrderDetail.PPDPercentage) / 100); //StockDetails PRate
            _OrderDetail.PRate = _OrderDetail.SRate;
            _OrderDetail.PRateTotal = _OrderDetail.PRate * multiple ;

            _OrderDetail.CGSTPerc = Convert.ToDecimal(row["VAT"]);
            _OrderDetail.CGSTAmt = _OrderDetail.SRate * Convert.ToDecimal(row["VAT"]) / 100;
            _OrderDetail.TypeID = (int)EnumSalesItemType.Category;

            if (!IsPayout && !_Order.SOrderDetails.AsEnumerable().Any(p => p.ProductID == Convert.ToInt32(row["CategoryID"]) && p.TypeID == (int)EnumSalesItemType.Category))
            {
                _Order.SOrderDetails.Add(_OrderDetail);
            }
            else if(IsPayout)
            {
                _Order.SOrderDetails.Add(_OrderDetail);
            }


            RefreshGridNew();
            RefreshControl();
            ClearDefaultTextBox();
            multiple = 1;
            RefreshPromo();
        }

        private void CreateOrderObject()
        {
            if (_Order == null)
            {
                _Order = new SOrder();

                _Order.CustomerID = ctlCustomer.SelectedID;
                _Order.SOrderDetails = new List<SOrderDetail>();
            }
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn7.Text;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearDefaultTextBox();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn9.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn6.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn3.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn0.Text;
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            txtamt.Text += btndot.Text;
        }

        decimal multiple = 1;
        private void btnx_Click(object sender, EventArgs e)
        {
            decimal result;
            if (Decimal.TryParse(txtamt.Text, out result) == true && Convert.ToDecimal(txtamt.Text) > 0)
            {
                multiple = Convert.ToDecimal(txtamt.Text);
                ClearDefaultTextBox();
            }

            else if (txtamt.Text != string.Empty)
            {
                MessageBox.Show("Invalid selection", "Sales Order");
                return;
            }
        }

        private void btnPayOut_Click(object sender, EventArgs e)
        {
            if (btnPayOut.Text == "PAYOUT")
            {

                pnlbtndyan.Controls.Clear();
                LoadpayoutDatatable();
                int top = 5;
                int left = 1;
                int count = 1;

                foreach (DataRow row in payoutlist.Rows)
                {

                    Button btnpayouts = new Button();
                    btnpayouts.Left = left;
                    btnpayouts.Top = top;
                    btnpayouts.Size = new Size(80, 63);
                    btnpayouts.Font = new Font(Font.FontFamily, 9);
                    btnpayouts.Text = row["Description"].ToString();
                    btnpayouts.Tag = row;
                    btnpayouts.BackColor = System.Drawing.Color.FromName(row["backcolor"].ToString());
                    btnpayouts.ForeColor = System.Drawing.Color.FromName(row["forecolor"].ToString());
                    pnlbtndyan.Controls.Add(btnpayouts);
                    top += btnpayouts.Height + 2;
                    btnpayouts.Click += Btnpayouts_Click;
                    count++;
                    if (count == 8)
                    {
                        count = 1;
                        top = 5;
                        left += 81;
                    }

                }
                btnPayOut.Text = "DEPARTMENT";
            }
            else
            {
                fOrder_Load(sender, e);
                btnPayOut.Text = "PAYOUT";

            }
        }

        private void Btnpayouts_Click(object sender, EventArgs e)
        {
            //if (txtamt.Text != string.Empty)
            //{
            //    this.dgProducts.Rows.Add(dgProducts.Rows.Count + 1, ((sender) as Button).Text, 1, Convert.ToDecimal(txtamt.Text) * -1, Convert.ToDecimal(txtamt.Text) * -1);
            //    frmprmo.dgProductspromo.Rows.Add(((sender) as Button).Text, 1, Convert.ToDecimal(txtamt.Text) * -1, Convert.ToDecimal(txtamt.Text) * -1);

            //    txtamt.Text = "";
            //}
            //RefreshPromo();

            DataRow row = ((Button)sender).Tag as DataRow;
            AddCategoryToGrid(row, true);
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            txtamt.Text += btn00.Text;
        }

        void calculatesum()
        {
            decimal qtysum = 0;
            decimal amtsum = 0;
            decimal taxsum = 0;

            for (int i = 0; i < dgProducts.Rows.Count; ++i)
            {

                qtysum += Convert.ToDecimal(dgProducts.Rows[i].Cells[2].Value);

                amtsum += Convert.ToDecimal(dgProducts.Rows[i].Cells[4].Value);

                taxsum += Convert.ToDecimal(dgProducts.Rows[i].Cells[5].Value);
            }

            lblbillqty.Text = String.Format("{0:0.00}", qtysum);
            lbltax.Text = String.Format("{0:0.00}", Convert.ToDecimal(taxsum));
            lblbilltotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(amtsum));

        }

        private void dgProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //calculatesum();
            //if(dgProducts.CurrentRow !=null)
            //frmprmo.dgProductspromo.Rows[dgProducts.CurrentRow.Index].Cells[0].Selected = true;
        }

        void showpaymentpop(string amt)
        {
            
            frmpaypop frmpop = new frmpaypop();
            frmpop.lblbilltotal.Text = lblbilltotal.Text;
            frmpop.lblpayment.Text = amt;
            frmpop.lblbalance.Text = Convert.ToString(Math.Abs(Convert.ToDecimal(lblbilltotal.Text) - Convert.ToDecimal(amt)));

            if (frmpop.ShowDialog() == DialogResult.OK)
            {
                _Order.CashPaidAmount = Convert.ToDecimal(frmpop.lblbilltotal.Text);
                SaveSales();
            }
            ClearDefaultTextBox();
        }

        void showmultipaymentpop()
        {
           
            frmmultipayment frmmultipay = new frmmultipayment();

            decimal result;
            if (Decimal.TryParse(txtamt.Text, out result) == true && Convert.ToDecimal(txtamt.Text) > 0)
            {
                if (Convert.ToDecimal(lblbilltotal.Text) > 0 && Convert.ToDecimal(txtamt.Text) > 0)
                {
                    frmmultipay.CashAmount = Convert.ToDecimal(txtamt.Text);
                    frmmultipay.BillAmount = Convert.ToDecimal(lblbilltotal.Text);
                }
            }
            if (frmmultipay.ShowDialog() == DialogResult.OK)
            {
                if (frmmultipay.DtPaymentTable.AsEnumerable().Any(p => Convert.ToInt32(p["TypeID"]) != 0))
                {
                    DataRow drrow = frmmultipay.DtPaymentTable.AsEnumerable().FirstOrDefault(p => Convert.ToInt32(p["TypeID"]) != 0);
                    _Order.CardPaidAmount = frmmultipay.DtPaymentTable.AsEnumerable().Where(p => Convert.ToInt32(p["TypeID"]) != 0).Sum(p => Convert.ToDecimal(p["Amt"]));
                    _Order.CardTypeID = Convert.ToInt32(drrow["TypeID"]);
                }
                _Order.CashPaidAmount = frmmultipay.DtPaymentTable.AsEnumerable().Where(p => Convert.ToInt32(p["TypeID"]) == 0).Sum(p => Convert.ToDecimal(p["Amt"]));
                SaveSales();
            }

            ClearDefaultTextBox();
        }

        private void ClearDefaultTextBox()
        {
            txtamt.Text = "";
            txtamt.Focus();
        }

        private void btncash_Click(object sender, EventArgs e)
        {
            if (_Order.SOrderDetails.Count == 0)
            {
                MessageBox.Show("Please add at least one item for this order.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal result;
            if (Decimal.TryParse(txtamt.Text,out result)==false)
            {
                MessageBox.Show("Enter Cash Amount");
                return;
            }

            if (Convert.ToDecimal(lblbilltotal.Text) <= Convert.ToDecimal(txtamt.Text))
            { showpaymentpop(txtamt.Text); }
            else
            {

                showmultipaymentpop();
            }
           

        }

        private void btnvoiditem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow oneCell in dgProducts.SelectedRows)
            {
                SOrderDetail oPODItem = oneCell.Tag as SOrderDetail;

                if (oPODItem.TypeID == (int)EnumSalesItemType.Product)
                {
                    _StockDetail = db.StockDetails.FirstOrDefault(x => x.SDetailID == oPODItem.StockDetailID);
                    if (_StockDetail != null)
                    {
                        _StockDetail.Quantity = _StockDetail.Quantity + oPODItem.Quantity;
                        _StockDetail.Status = (int)EnumStockDetailStatus.Stock;
                    }
                }
                _Order.SOrderDetails.Remove(oPODItem);
                dgProducts.Rows.Remove(oneCell);
                calculatesum();
            }

            RefreshPromo();
            txtamt.Focus();
        }

        void RefreshPromo()
        {
            dgProducts.Refresh();
            if (dgProducts.Rows.Count > 0)
            {
                frmprmo.grppromo.Visible = true;
                frmprmo.pctboxpromo.Location = new Point(703, 27);
                frmprmo.pctboxpromo.Size = new Size(723, 676);
            }
            else
            {
                frmprmo.grppromo.Visible = false;
                frmprmo.pctboxpromo.Location = new Point(30, 27);
                frmprmo.pctboxpromo.Size = new Size(1100, 676);
            }
        }

        private void btnvoidall_Click(object sender, EventArgs e)
        {
            foreach (SOrderDetail oPODItem in _Order.SOrderDetails)
            {
                if (oPODItem.TypeID == (int)EnumSalesItemType.Product)
                {
                    _StockDetail = db.StockDetails.FirstOrDefault(x => x.SDetailID == oPODItem.StockDetailID);
                    if (_StockDetail != null)
                    {
                        _StockDetail.Quantity = _StockDetail.Quantity + oPODItem.Quantity;
                        _StockDetail.Status = (int)EnumStockDetailStatus.Stock;
                    }
                }
            }
            dgProducts.Rows.Clear();
            _Order.SOrderDetails.Clear();
            
            calculatesum();

            RefreshPromo();

            txtamt.Focus();
        }

        private void btnpricechck_Click(object sender, EventArgs e)
        {
            frmpricechk frmpricheck = new frmpricechk();
            frmpricheck.ShowDialog();
        }

        private void btnoptions_Click(object sender, EventArgs e)
        {
            frmoptions frmopt = new frmoptions();
            frmopt.Show();
        }

        private void btnvoidqty_Click(object sender, EventArgs e)
        {
            if (dgProducts.Rows.Count > 0)
                if (Convert.ToInt32(dgProducts.CurrentRow.Cells["clnQTY"].Value) >= 1)
                {
                    dgProducts.CurrentRow.Cells["clnQTY"].Value = Convert.ToInt32(dgProducts.CurrentRow.Cells["clnQTY"].Value) - 1;
                    dgProducts.CurrentRow.Cells["clnTotal"].Value = Convert.ToDecimal(dgProducts.CurrentRow.Cells["clnUnitPrice"].Value) * Convert.ToDecimal(dgProducts.CurrentRow.Cells["clnQTY"].Value);

                    SOrderDetail oPODItem = dgProducts.CurrentRow.Tag as SOrderDetail;

                    if (oPODItem.TypeID == (int)EnumSalesItemType.Product)
                    {
                        _StockDetail = db.StockDetails.FirstOrDefault(x => x.SDetailID == oPODItem.StockDetailID);
                        if (_StockDetail != null)
                        {
                            _StockDetail.Quantity = _StockDetail.Quantity + 1;
                            _StockDetail.Status = (int)EnumStockDetailStatus.Stock;
                        }
                    }

                    calculatesum();
                }
            txtamt.Focus();
        }

        private void btnquickmenu_Click(object sender, EventArgs e)
        {
            taxper = 0;
            frmquickmenu frmqui = new frmquickmenu();
            if (frmqui.ShowDialog() == DialogResult.OK)
            {

                DataRow dr = frmqui.Branchlistbasedcat.AsEnumerable()
               .SingleOrDefault(r => r.Field<int>("productid") == Convert.ToInt32(frmqui.Tag));

                //if (Convert.ToDecimal(dr[25]) > 0)
                //{
                //    taxper += Convert.ToDecimal(dr[29].ToString()) * Convert.ToDecimal(dr[25]) / 100;

                //}

                //this.dgProducts.Rows.Add(dgProducts.Rows.Count + 1, dr[2].ToString(), multiple, dr[29].ToString(), (Convert.ToDecimal(dr[29].ToString()) + taxper) * multiple, taxper* multiple);
                //frmprmo.dgProductspromo.Rows.Add(dr[2].ToString(), multiple, dr[29].ToString(), (Convert.ToDecimal(dr[29].ToString()) + taxper) * multiple, taxper * multiple);

                int productid = Convert.ToInt32(dr["productid"]);

                _oProduct = (Product)(db.Products.FirstOrDefault(o => o.ProductID == productid));
                AddProductToGrid();
                multiple = 1;
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            
            txtamt.Text = "10";

            if (Convert.ToDecimal(lblbilltotal.Text) <= Convert.ToDecimal(txtamt.Text))
            { showpaymentpop(txtamt.Text); }
            else
            {
                showmultipaymentpop();
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            txtamt.Text="20";
            if (Convert.ToDecimal(lblbilltotal.Text) <= Convert.ToDecimal(txtamt.Text))
            { showpaymentpop(txtamt.Text); }
            else
            {
                showmultipaymentpop();
            }
        }

        private void btn50_Click(object sender, EventArgs e)
        {           
            txtamt.Text = "50";
            if (Convert.ToDecimal(lblbilltotal.Text) <= Convert.ToDecimal(txtamt.Text))
            { showpaymentpop(txtamt.Text); }
            else
            {
                showmultipaymentpop();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            showmultipaymentpop();
        }

        private void btnlastreciept_Click(object sender, EventArgs e)
        {
            frmlastbill frmlastbil = new frmlastbill();
            frmlastbil.ShowDialog();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            //DataBaseBackup();
            this.Dispose();
            frmprmo.Close();
            fLogIn frm = new fLogIn();
            frm.ShowDialog();
            frm.txtLoginID.Focus();
        }

        private void dgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmprmo.dgProductspromo.Rows[dgProducts.CurrentRow.Index].Selected = true;
            //frmprmo.dgProductspromo.Rows[dgProducts.CurrentRow.Index].Cells[0].Selected = true;
        }

        private void fSOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmprmo.Close();
        }
        int dynamiclocatonY = 81;
        private void btnmovedwn_Click(object sender, EventArgs e)
        {
            dynamiclocatonY+= - 5;
            pnlbtndyan.Location = new Point(827, dynamiclocatonY );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamiclocatonY += +5;
            pnlbtndyan.Location = new Point(827, dynamiclocatonY );

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (ctlProduct.SelectedID == 0)
            {
                try
                {
                    if (txtamt.Text != string.Empty)
                    {
                        if (db.Products.Any(o => o.BarCode == txtamt.Text.Trim()))
                        {
                            _oProduct = (Product)(db.Products.FirstOrDefault(o => o.BarCode == txtamt.Text.Trim()));
                            if (_oProduct != null)
                            {
                                AddProductToGrid();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Barcode");
                }
            }
        }

        private StockDetail UpdateStockDetails()
        {

            _StockDetail = (StockDetail)(db.StockDetails.FirstOrDefault(o => o.ProductID == _oProduct.ProductID && o.Status == (int)EnumStockDetailStatus.Stock && o.Quantity > 0));

            if (_StockDetail != null)
            {
                _stock = _StockDetail.Stock;

                decimal AvailableQuantity = (db.StockDetails.Where(o => o.ProductID == _oProduct.ProductID && o.Status == (int)EnumStockDetailStatus.Stock).Sum(o => o.Quantity));

                if (AvailableQuantity >= multiple || AllowNegativestock)
                {
                    if (_StockDetail.Quantity == multiple)
                    {
                        _StockDetail.Quantity -= multiple;
                        _StockDetail.Status = (int)EnumStockDetailStatus.Sold;
                    }
                    else if (_StockDetail.Quantity > multiple)
                    {
                        _StockDetail.Quantity -= multiple;
                    }
                    else if (_StockDetail.Quantity < multiple)
                    {
                        _StockDetail.Quantity = 0m;
                        _StockDetail.Status = (int)EnumStockDetailStatus.Sold;
                    }
                    _stock.Quantity -= multiple;
                }

                else if (_StockDetail != null)
                {
                    MessageBox.Show("Stock not available. Available stock", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                else
                {
                    MessageBox.Show("Item not found", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                return _StockDetail;
            }
            else if (!AllowNegativestock)
            {
                MessageBox.Show("Stock not available. Available stock is " + _StockDetail.Quantity, "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return null;
        }

        private void AddProductToGrid()
        {
            UpdateStockDetails();
            RefrehSODetailsAndStockObjectNew();
        }
    }
}
