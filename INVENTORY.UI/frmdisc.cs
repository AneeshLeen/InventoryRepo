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
