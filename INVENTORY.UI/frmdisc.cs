using INVENTORY.UI.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class frmdisc : Form
    {

        public DiscountOptions ObjDiscountOptions { get; set; }
        public frmdisc()
        {
            InitializeComponent();
            this.ObjDiscountOptions = new DiscountOptions();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            decimal result;
            if (Decimal.TryParse(txtdiscount.Text, out result) == true && Convert.ToDecimal(txtdiscount.Text) > 0)
            {
                
                if (this.rdbLineDisPerc.Checked)
                {
                    ObjDiscountOptions.LineDiscountPerc = Convert.ToDecimal(txtdiscount.Text);
                }
                else if (this.rdbLineDisAmt.Checked)
                {
                    ObjDiscountOptions.LineDiscountAmt = Convert.ToDecimal(txtdiscount.Text);
                }
                else if (this.rdbBillDiscPerc.Checked)
                {
                    ObjDiscountOptions.BillPerc = Convert.ToDecimal(txtdiscount.Text);
                }
                else if (this.rdbBillDiscAmt.Checked)
                {
                    ObjDiscountOptions.BillAmt = Convert.ToDecimal(txtdiscount.Text);
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtdiscount.Text += btn.Text;
        }


        private void btnclear_Click(object sender, EventArgs e)
        {
            txtdiscount.Text = string.Empty;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(txtdiscount.Text.Length>0)
            txtdiscount.Text = txtdiscount.Text.Substring(0, txtdiscount.Text.Length - 1);
        }

        private void btnenter_Click(object sender, EventArgs e)
        {

        }

        private void btnapply_Click(object sender, EventArgs e)
        {

        }
    }
}
