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
}
