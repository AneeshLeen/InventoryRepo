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
    public partial class frmmultipayment : Form
    {
        public DataTable DtPaymentTable { get; set; }
        public decimal CashAmount { get; set; }
        public decimal BillAmount { get; set; }
        public frmmultipayment()
        {
            InitializeComponent();
            this.Load += Frmmultipayment_Load;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Frmmultipayment_Load(object sender, EventArgs e)
        {
            dgProducts.AllowUserToDeleteRows = false;

            lblbillamt.Text = this.BillAmount.ToString();
            lblpaidamt.Text = this.CashAmount.ToString();
            txtclear.Text= lbldueamt.Text = Convert.ToString(this.BillAmount - this.CashAmount);
          
            CreateDataTable();
        }

        private void CreateDataTable()
        {
            DtPaymentTable = new DataTable();
            DtPaymentTable.Columns.Add("Type");
            DtPaymentTable.Columns.Add("Amt");
            DtPaymentTable.Columns.Add("TypeID");

            if (CashAmount>0)
            {
                DtPaymentTable.Rows.Add("CASH", CashAmount, 0);
            }

            dgProducts.DataSource = DtPaymentTable;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if(DtPaymentTable.AsEnumerable().Sum(p => Convert.ToDecimal(p["Amt"]))!=this.BillAmount)
            {
                MessageBox.Show("Amount should be equal to bill amount");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtclear.Text += btn.Text;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtclear.Clear();
        }

        private void btncash_Click(object sender, EventArgs e)
        {
            AddAmountToGrid(0, "CASH");
        }

        private void btncard_Click(object sender, EventArgs e)
        {
            AddAmountToGrid(1, "CARD");
        }

      
        private void btnchque_Click(object sender, EventArgs e)
        {
            AddAmountToGrid(2, "CHEQUE");
        }

        private void btnvoucher_Click(object sender, EventArgs e)
        {
            AddAmountToGrid(3, "VOUCHER");
        }

        private void btnaccount_Click(object sender, EventArgs e)
        {
            AddAmountToGrid(4, "ACCOUNT");
        }

        private bool CheckAmountReached()
        {
            if (DtPaymentTable.Rows.Count > 0)
            {
                decimal sum = DtPaymentTable.AsEnumerable().Sum(p => Convert.ToDecimal(p["Amt"]));
                sum = sum + Convert.ToDecimal(txtclear.Text);

                if (sum > BillAmount)
                {
                    MessageBox.Show("Amount should be equal to bill amount");
                    return true;
                }
            }
            else
            {
                if (Convert.ToDecimal(txtclear.Text) > BillAmount)
                {

                    MessageBox.Show("Amount should be equal to bill amount");
                    return true;
                }
            }
            return false;
        }
        private void AddAmountToGrid(int TypeID, string TypeName)
        {
            if (txtclear.Text.Trim() != string.Empty)
            {
                if (!CheckAmountReached())
                {
                    if (DtPaymentTable.AsEnumerable().Any(p => Convert.ToInt32(p["TypeID"]) == TypeID))
                    {
                        DataRow drrow = DtPaymentTable.AsEnumerable().FirstOrDefault(p => Convert.ToInt32(p["TypeID"]) == TypeID);
                        drrow["Amt"] = Convert.ToDecimal(drrow["Amt"]) + Convert.ToDecimal(txtclear.Text);
                    }
                    else
                    {
                        DtPaymentTable.Rows.Add(TypeName, txtclear.Text, 1);
                    }
                }
                if (DtPaymentTable.AsEnumerable().Sum(p => Convert.ToDecimal(p["Amt"])) >= this.BillAmount)
                {
                    this.DialogResult = DialogResult.OK;
                }
                }
            txtclear.Text = string.Empty;
        }

        private void btndoll1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtclear.Text = btn.Text.Replace("$ ", "");
        }
    }
}
