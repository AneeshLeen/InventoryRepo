
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class frmpricechk : Form
    {
        public frmpricechk()
        {
            InitializeComponent();
        }
      // SQLConfig config = new SQLConfig();
        private void textBox1_Validated(object sender, EventArgs e)
        {
            //if (txtsearch.Text.Length > 0)
            //{
            //    //String s = txtsearch.Text.TrimStart(new Char[] { '0' });
            //    //text = txtsearch.Text.Substring(1, txtsearch.Text.Length - 1);
            //    string sql = "SELECT ITEMID,NAME,Type ,PRICE  FROM tblitems WHERE barcode = '" + txtsearch.Text.TrimStart(new Char[] { '0' }) + "'";
            //    Load_DTGPricechk(sql, txtsearch);
            //    txtsearch.Text = "";

            //}
        }
        decimal taxper = 0;
        public void Load_DTGPricechk(string sql, TextBox txtuser)
        {
            //try
            //{
            //    config.con.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    cmd.Connection = config.con;
            //    cmd.CommandText = sql;
            //    da.SelectCommand = cmd;
            //    da.Fill(dt);
            //    if (dt.Rows.Count == 1)
            //    {
            //        lblname1.Text = dt.Rows[0][1].ToString();
            //       // lblprice1.Text = dt.Rows[0][2].ToString();

            //        if (dt.Rows[0][2].ToString() =="1")
            //        {
            //            taxper =Convert.ToDecimal( dt.Rows[0][3]) *100 / 113;
            //            lblprice1.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(taxper), 2, MidpointRounding.AwayFromZero));
            //            lbltax1.Text = "13 %";
            //            lblrate.Text = dt.Rows[0][3].ToString();
            //        }
            //        else
            //        {
            //            lblprice1.Text = dt.Rows[0][3].ToString();
            //            lbltax1.Text = "0 %";
            //            lblrate.Text = dt.Rows[0][3].ToString();
            //        }
            //        //lbltax1.Text = dt.Rows[0][3].ToString();
            //    }
            //}
            //finally 
            //{
            //    config.con.Close();
            //}

        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        

        private void button1_Enter(object sender, EventArgs e)
        {
            txtsearch.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
