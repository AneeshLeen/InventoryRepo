
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
      
        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                lblname1.Text = "";
                lblprice1.Text = "0.00";
                lbltax1.Text = "0 %";
                lblrate.Text = "0.00";
                //string sql = "SELECT code,ProductName, (select case when Tax = 0 then 0 else 1 end from products where barcode='" + txtsearch.Text.TrimStart(new Char[] { '0' })+"')  [Type], RetailPrice  FROM products WHERE barcode = '" + txtsearch.Text.TrimStart(new Char[] { '0' }) + "'";
                string sql = "SELECT code,ProductName, (select case when Tax = 0 then 0 else 1 end from products where barcode='" + txtsearch.Text + "')  [Type], RetailPrice  FROM products WHERE barcode = '" + txtsearch.Text + "'";
                Load_DTGPricechk(sql, txtsearch);
                txtsearch.Text = "";

            }
        }
        decimal taxper = 0;
        public void Load_DTGPricechk(string sql, TextBox txtuser)
        {
            try
            {
                DataTable dt = new DataTable();     
                string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
                SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRM;Persist Security Info=True;Integrated Security=true");
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adp = new SqlDataAdapter(command);
                adp.Fill(dt); ;

                if (dt.Rows.Count == 1)
                {
                    lblname1.Text = dt.Rows[0][1].ToString();
                    if (dt.Rows[0][2].ToString() == "1")
                    {
                        taxper = Convert.ToDecimal(dt.Rows[0][3]) * 100 / 113;
                        lblprice1.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(taxper), 2, MidpointRounding.AwayFromZero));
                        lbltax1.Text = "13 %";
                        lblrate.Text = dt.Rows[0][3].ToString();
                    }
                    else
                    {
                        lblprice1.Text = dt.Rows[0][3].ToString();
                        lbltax1.Text = "0 %";
                        lblrate.Text = dt.Rows[0][3].ToString();
                    }

                }
                else
                {
                    lblname1.Text = "Invalid Item";
                }
            }
            finally
            {
               
            }

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
