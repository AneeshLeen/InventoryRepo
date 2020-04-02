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
    public partial class frmlabelprint : Form
    {
        public frmlabelprint()
        {
            InitializeComponent();
            txtBarcode.Focus();
            txtBarcode.Select();
            // dgupdatproducts.DataSource = ReadAllpayouts();
            loadpending();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            frmplu frplu = new frmplu();

            if (frplu.ShowDialog() == DialogResult.OK)
            {

                txtproductcode.Text = frplu.selectedRow.Cells[1].Value.ToString();
                txtproductname.Text = frplu.selectedRow.Cells[2].Value.ToString();
                txtBarcode.Text= frplu.selectedRow.Cells[0].Value.ToString();
                txtsalesprice.Text = frplu.selectedRow.Cells[8].Value.ToString();
                txtnooflabels.Text = "1";
                txtnooflabels.Focus();
            }
        }

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            string sql = "SELECT code,ProductName, RetailPrice  FROM products WHERE barcode = '" + txtBarcode.Text.TrimEnd() + "'";
            Load_DTGPricechk(sql, txtBarcode);
        }

        public void Load_DTGPricechk(string sql, TextBox txtuser)
        {
            try
            {
                DataTable dt = new DataTable();
                string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
                SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRMTEST;Persist Security Info=True;Integrated Security=true");
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adp = new SqlDataAdapter(command);
                adp.Fill(dt); ;

                if (dt.Rows.Count == 1)
                {
                    txtproductcode.Text = dt.Rows[0][0].ToString();
                    txtproductname.Text = dt.Rows[0][1].ToString();
                    txtsalesprice.Text = dt.Rows[0][2].ToString();
                    txtnooflabels.Text = "1";
                    txtnooflabels.Focus();
                }
                //else
                //{
                //    MessageBox.Show("Item Not Found");
                //    //txtBarcode.Focus();
                //}

            }
            finally
            {

            }

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dgProducts.Rows.Add("" + txtproductcode.Text + "", "" + txtBarcode.Text + "", "" + txtproductname.Text + "", "" + txtsalesprice.Text + "", "" + txtnooflabels.Text + "");

            txtBarcode.Text = "";
            txtproductcode.Text = "";
            txtproductname.Text = "";
            txtsalesprice.Text = "";
            txtnooflabels.Text = "";
            txtBarcode.Select();
        }

        internal DataTable ReadAllpayouts()
        {
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
            DataTable dtpayouts = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRMTEST;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("SELECT convert(bit, 1) as [Select], code ProductCode,barcode BarCode,ProductName Description, RetailPrice Price  FROM products WHERE labelprint=0", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtpayouts);
            return dtpayouts;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
           
            loadpending();

        }

        void loadpending()
        {

            dgupdatproducts.DataSource = ReadAllpayouts();

        }

        private void btnaddselect_Click(object sender, EventArgs e)
        {
            //ReadAllpayouts().AcceptChanges();
            DataTable DataTabletemp = dgupdatproducts.DataSource as DataTable;
            for (int i = 0; i <= DataTabletemp.Rows.Count - 1; i++)
            {
                if (DataTabletemp.Rows[i][0].ToString() == "True")
                {
                    this.dgProducts.Rows.Add(DataTabletemp.Rows[i][1].ToString(), DataTabletemp.Rows[i][2].ToString(), DataTabletemp.Rows[i][3].ToString(), DataTabletemp.Rows[i][4].ToString(),"1");
                }
            }
        }
    }
}
