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
    
    public partial class ExpenseItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseItem()
        {
            this.Expenditures = new HashSet<Expenditure>();
        }
    
        public int ExpenseItemID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expenditure> Expenditures { get; set; }
    }
}
