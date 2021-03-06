//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INVENTORY.DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class CreditSaleProduct
    {
        public int CreditSaleProductsID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal UTAmount { get; set; }
        public int CreditSalesID { get; set; }
        public decimal MPRateTotal { get; set; }
        public decimal MPRate { get; set; }
        public int ColorInfoID { get; set; }
        public int StockDetailID { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal PRate { get; set; }
        public decimal SRate { get; set; }
        public string CompressorWarrenty { get; set; }
        public string PanelWarrenty { get; set; }
        public string MotorWarrenty { get; set; }
        public string SparePartsWarrenty { get; set; }
        public string ServiceWarrenty { get; set; }
        public decimal GSTPerc { get; set; }
        public decimal CGSTPerc { get; set; }
        public decimal SGSTPerc { get; set; }
        public decimal IGSTPerc { get; set; }
        public decimal GSTAmt { get; set; }
        public decimal CGSTAmt { get; set; }
        public decimal SGSTAmt { get; set; }
        public decimal IGSTAmt { get; set; }
        public Nullable<int> GodownID { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual CreditSale CreditSale { get; set; }
        public virtual Product Product { get; set; }
        public virtual StockDetail StockDetail { get; set; }
        public virtual CreditSaleProduct CreditSaleProducts1 { get; set; }
        public virtual CreditSaleProduct CreditSaleProduct1 { get; set; }
        public virtual Godown Godown { get; set; }
    }
}
