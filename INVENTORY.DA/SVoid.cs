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
    
    public partial class SVoid
    {
        public int SVoidId { get; set; }
        public int ProductId { get; set; }
        public int TypeId { get; set; }
        public decimal Qty { get; set; }
        public decimal Amount { get; set; }
        public int VoidTypeId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool ShiftEndStatus { get; set; }
        public int branchid { get; set; }
        public Nullable<int> shiftid { get; set; }
    }
}
