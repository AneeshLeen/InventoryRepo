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
    
    public partial class EmpSalary
    {
        public int EmpSalaryID { get; set; }
        public Nullable<System.DateTime> SalaryMonth { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal RecAmt { get; set; }
        public decimal RemainingAmt { get; set; }
        public int EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
