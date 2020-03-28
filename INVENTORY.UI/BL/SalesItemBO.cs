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
    public class SalesItemCollectionBO : BindingList<SalesItemBO>
    {

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
}