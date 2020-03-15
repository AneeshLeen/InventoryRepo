using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.UI.BL
{
    public class DiscountOptions
    {
        public decimal LineDiscountPerc { get; set; }
        public decimal LineDiscountAmt { get; set; }
        public decimal NewPrice { get; set; }
        public decimal LineAmt { get; set; }
        public decimal BillPerc { get; set; }
        public decimal BillAmt { get; set; }
    }
}
