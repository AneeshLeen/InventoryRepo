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
    public partial class frmoptions : Form
    {
        public frmoptions()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnrefundall_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmrefund frmrefun = new frmrefund();
            frmrefun.ShowDialog();
        }

        private void btnshiftend_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmshiftend frmshiftE = new frmshiftend();
            frmshiftE.ShowDialog();
        }

        private void btnsptchk_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmshiftend frmshiftE = new frmshiftend();
            frmshiftE.ShowDialog();
        }

        private void btndiscount_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdisc fmdisc = new frmdisc();
            fmdisc.ShowDialog();
        }
    }
}
