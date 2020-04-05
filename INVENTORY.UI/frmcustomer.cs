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
    public partial class frmcustomer : Form
    {
        public frmcustomer()
        {
            InitializeComponent();
        }
        internal DataGridViewRow selectedRow;
        internal DataTable ReadAllpayouts()
        {
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
            DataTable dtpayouts = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRMTEST;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("SELECT [CustomerID],[Code],[Name] ,[FName],[CompanyName],[ContactNo],[EmailID],[NID],[Address],[PhotoPath],[TotalDue],[RefName],[RefContact],[RefFName],[RefAddress],[CustomerType],[OpeningDue],[CreateDate],[CreatedBy],[CreditDue] FROM [Customers]", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtpayouts);
            return dtpayouts;
        }

        private void frmcustomer_Load(object sender, EventArgs e)
        {
            dgProducts.DataSource = ReadAllpayouts();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            DataView dv1 = ReadAllpayouts().DefaultView;
            dv1.RowFilter = " " + cmbsearchby.Text + " like '%" + txtsearch.Text.Trim() + "%' ";
            dv1.Sort = " " + cmbsortby.Text + " " + "  asc";
            DataTable dtNew = dv1.ToTable();
            dgProducts.DataSource = dtNew;
            dtNew.AcceptChanges();
            dgProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            dgProducts.DataSource = ReadAllpayouts();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            selectedRow = dgProducts.Rows[dgProducts.CurrentCell.RowIndex];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
