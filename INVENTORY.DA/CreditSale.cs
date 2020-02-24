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
    
    public partial class CreditSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CreditSale()
        {
            this.CreditSaleProducts = new HashSet<CreditSaleProduct>();
            this.CreditSalesDetails = new HashSet<CreditSalesDetail>();
        }
    
        public int CreditSalesID { get; set; }
        public string InvoiceNo { get; set; }
        public int CustomerID { get; set; }
        public decimal TSalesAmt { get; set; }
        public int NoOfInstallment { get; set; }
        public Nullable<decimal> IntallmentPrinciple { get; set; }
        public System.DateTime IssueDate { get; set; }
        public string UserName { get; set; }
        public decimal Remaining { get; set; }
        public int InterestRate { get; set; }
        public System.DateTime SalesDate { get; set; }
        public decimal DownPayment { get; set; }
        public Nullable<decimal> WInterestAmt { get; set; }
        public decimal FixedAmt { get; set; }
        public Nullable<int> IsStatus { get; set; }
        public int UnExInstallment { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public Nullable<bool> ISUnexpected { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public string SerialNo { get; set; }
        public decimal FirstInterestRate { get; set; }
        public decimal FirstTotalInterest { get; set; }
        public decimal MergeTotalSales { get; set; }
        public int BankTranID { get; set; }
        public decimal CardPaidAmount { get; set; }
        public int CardTypeSetupID { get; set; }
        public decimal DepositChargePercent { get; set; }
        public int ISWeeekly { get; set; }
        public decimal VATPercentage { get; set; }
        public decimal VATAmount { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditSaleProduct> CreditSaleProducts { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditSalesDetail> CreditSalesDetails { get; set; }
    }
}