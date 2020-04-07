using INVENTORY.DA;
using INVENTORY.UI.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class frmshiftend : Form
    {
        List<ShiftEndDetailsBO> objShiftEndList = new List<ShiftEndDetailsBO>();
        ShiftEndPrintBO objShiftEndPrintBO = new ShiftEndPrintBO();
        List<SOrder> _Orders = null;
        List<SVoid> objVoidOrders = null;
        List<Product> objProductList = null;
        List<Category> objCatagoryList = null;
        Shift objShift = null;
        public frmshiftend()
        {
            InitializeComponent();
            SetGridDataSource();

        }
        private void SetGridDataSource()
        {
            decimal CashAmount = 0;
            decimal CardAmount = 0;
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                _Orders = db.SOrders.Where(so => so.CreatedBy == Global.CurrentUser.UserID && so.ShiftEndStatus == false).ToList<SOrder>();

                objVoidOrders = db.SVoids.Where(so => so.CreatedBy == Global.CurrentUser.UserID && so.ShiftEndStatus == false).ToList<SVoid>();
                objProductList = db.Products.ToList<Product>();
                objCatagoryList = db.Categorys.ToList<Category>();
                if (_Orders != null)
                {
                    CashAmount = _Orders.Sum(p => p.CashPaidAmount);
                    CardAmount = _Orders.Sum(p => p.CardPaidAmount);

                }
                objShift = db.Shifts.FirstOrDefault(p => p.ShiftId == Global.ShiftId);
            }
            objShiftEndList.Add(new ShiftEndDetailsBO() { TypeID = 1, TypeName = "CASH", SysBal = "****.**" });
            objShiftEndList.Add(new ShiftEndDetailsBO() { TypeID = 2, TypeName = "CARD", SysBal = CardAmount.ToString() });
            objShiftEndList.Add(new ShiftEndDetailsBO() { TypeID = 3, TypeName = "CHEQUE", SysBal = "0" });
            objShiftEndList.Add(new ShiftEndDetailsBO() { TypeID = 4, TypeName = "ACCOUNTS", SysBal = "0" });
            objShiftEndList.Add(new ShiftEndDetailsBO() { TypeID = 4, TypeName = "VOUCHER", SysBal = "0" });

            dgProducts.DataSource = objShiftEndList;

            lblShiftStart.Text = Convert.ToString(objShift.StartDate);
        }
        private void SetPrintDetails()
        {
            if(_Orders!=null)
            {
                objShiftEndPrintBO.BillNO = "0";
                objShiftEndPrintBO.FromDate = objShift.StartDate;
                objShiftEndPrintBO.ToDate = DateTime.Now;
                objShiftEndPrintBO.PrintBy = Global.CurrentUser.UserID.ToString();
                Category objcategory = null;
                foreach (SOrder objsorder in _Orders)
                {
                    foreach (SOrderDetail objSOrderDetail in objsorder.SOrderDetails.Where(p=>p.TypeID== (int)EnumSalesItemType.Category))
                    {
                        objcategory = objCatagoryList.FirstOrDefault(p => p.CategoryID == objSOrderDetail.ProductID);
                        if (objcategory.CategoryID == Global.CashbackId)
                        {
                            objShiftEndPrintBO.CashBackItems.Add(new ShiftEndCashBackPrintBO() { Qty = objSOrderDetail.Quantity, ProductName = objcategory.Description, Total = objSOrderDetail.UTAmount + objSOrderDetail.CGSTAmt });

                        }
                        else if (objcategory.IsPayOut)
                        {
                            objShiftEndPrintBO.PayOutItems.Add(new ShiftEndPayOutPrintBO() { Qty = objSOrderDetail.Quantity, ProductName = objcategory.Description, Total = objSOrderDetail.UTAmount + objSOrderDetail.CGSTAmt });

                        }
                        else
                        {
                            objShiftEndPrintBO.DeparmentItems.Add(new ShiftEndDepartmentPrintBO() { Qty = objSOrderDetail.Quantity, ProductName = objcategory.Description, Total = objSOrderDetail.UTAmount + objSOrderDetail.CGSTAmt });
                        }
                    }
                    
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void dgProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProducts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

