using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.UI.BL
{

    public class SalesItemBO
    {
        public string ItemName { get; set; }
        public int SLNO { get; set; }
        public decimal Quantity { get; set; }
        public decimal SRate { get; set; }
        public decimal Amount { get; set; }
        public decimal HST { get; set; }
    }
    public class PromoData
    {
        public decimal BillTotal { get; set; }
        public decimal BillDiscount { get; set; }
        public int NoofItems { get; set; }
        public decimal HST { get; set; }
        public decimal NetTotal { get; set; }
        public decimal Refund { get; set; }
        public decimal Savings { get; set; }
        public decimal Payments { get; set; }
        public decimal Balance { get; set; }
        public decimal CashBack { get; set; }
    }
    public class SalesPrintBO
    {
        public string OrderNo { get; set; }
        public decimal NetAmount { get; set; }
        public decimal BillTotal { get; set; }
        public decimal HST { get; set; }
        public decimal Card { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public decimal TotalSavings { get; set; }
        public decimal NoOfItems { get; set; }
        public DateTime Date { get; set; }
        public List<SalesPrintItems> objSalesPrintItems { get; set; }
        public List<HSTSummary> objHSTSummary { get; set; }
        public SalesPrintBO()
        {
            objSalesPrintItems = new List<SalesPrintItems>();
            objHSTSummary = new List<HSTSummary>();
        }
    }
    public class SalesPrintItems
    {
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
    }
    public class HSTSummary
    {
        public decimal Rate { get; set; }
        public decimal HST { get; set; }
        public decimal Net { get; set; }
        public decimal Total { get; set; }
    }
    public class SalesReturnBO
    {
        public int SOrderDetailID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal RefundQty { get; set; }
        public decimal RefundAmt { get; set; }
    }
    public class ShiftEndDetailsBO
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string SysBal { get; set; }
        public decimal DrawerBal { get; set; }
    }
    public class ShiftEndPrintBO
    {
        public string BillNO { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PrintBy { get; set; }

        public decimal TotalSales { get; set; }
        public decimal CashBack { get; set; }
        public decimal TotalRefund { get; set; }
        public decimal NetSales { get; set; }
        public decimal TotalPayOut { get; set; }
        public decimal NetCollection { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CardAmount { get; set; }
        public decimal CashSales { get; set; }
        public decimal CashIn { get; set; }
        public decimal CashOut { get; set; }
        public decimal CashBalance { get; set; }

        public decimal TotalSold { get; set; }

        public int NoOfBills { get; set; }
        public int NoOfCashBills { get; set; }
        public int NoOfCardBills { get; set; }
        public int NoOfCoupon { get; set; }
        public decimal CouponTotal { get; set; }
        public decimal AvgBasket { get; set; }
        public List<ShiftEndDepartmentPrintBO> DeparmentItems { get; set; }
        public List<ShiftEndCashBackPrintBO> CashBackItems { get; set; }
        public List<ShiftEndPayOutPrintBO> PayOutItems { get; set; }
        public List<ShiftEndVoidPrintBO> VoidItems { get; set; }
        public List<ShiftEndTaxBreakPrintBO> TaxBreakDown { get; set; }
        public ShiftEndPrintBO()
        {
            DeparmentItems = new List<ShiftEndDepartmentPrintBO>();
            CashBackItems = new List<ShiftEndCashBackPrintBO>();
            PayOutItems = new List<ShiftEndPayOutPrintBO>();
            VoidItems = new List<ShiftEndVoidPrintBO>();
            TaxBreakDown = new List<ShiftEndTaxBreakPrintBO>();
        }

    }
    public class ShiftEndDepartmentPrintBO
    {
        public decimal Qty { get; set; }
        public string ProductName { get; set; }
        public decimal Total { get; set; }
    }
    public class ShiftEndCashBackPrintBO
    {
        public decimal Qty { get; set; }
        public string ProductName { get; set; }
        public decimal Total { get; set; }
    }
    public class ShiftEndPayOutPrintBO
    {
        public decimal Qty { get; set; }
        public string ProductName { get; set; }
        public decimal Total { get; set; }
    }
    public class ShiftEndTaxBreakPrintBO
    {
        public decimal Qty { get; set; }
        public decimal HST { get; set; }
        public decimal NetTotal { get; set; }
        public decimal GrossTotal { get; set; }
    }
    public class ShiftEndVoidPrintBO
    {
        public string ProductName { get; set; }
        public DateTime Time { get; set; }
        public decimal Qty { get; set; }
        public decimal Amt { get; set; }
    }
}