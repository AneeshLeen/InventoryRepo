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
    
    public partial class ReturnDetail
    {
        public int ReturnDetailsID { get; set; }
        public int ReturnID { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UTAmount { get; set; }
        public int SDetailID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Return Return { get; set; }
    }
}
