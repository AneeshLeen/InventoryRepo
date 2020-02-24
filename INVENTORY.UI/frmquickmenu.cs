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
    public partial class frmquickmenu : Form
    {
        public frmquickmenu()
        {
            InitializeComponent();
        }

        public DataTable Branchlist = new DataTable();
        public DataTable Branchlistbasedcat = new DataTable();

        internal DataTable ReadAllCategories()
        {
            DataTable dtbranches = new DataTable();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A62FJAE\\SQL;Initial Catalog=DEWSRM;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("SELECT * FROM[dbo].[Categorys]  cat WHERE cat.CategoryID  IN(SELECT CategoryID FROM[dbo].[Products]) and cat.inactive = 'true'", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtbranches);
            return dtbranches;
        }

        internal DataTable Readallbasedcat( string tag)
        {
            DataTable dtbranchesbased = new DataTable();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A62FJAE\\SQL;Initial Catalog=DEWSRM;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand(" select* from[dbo].[Products] where CategoryID = '"+tag+"'", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtbranchesbased);
            return dtbranchesbased;

        }

        private void loadallbasedcat(string tag)
        {

            Branchlistbasedcat = Readallbasedcat(tag );
        }
        private void LoadDatatable()
        {
            Branchlist = ReadAllCategories();
        }

        private void frmquickmenu_Load(object sender, EventArgs e)
        {
            LoadDatatable();

            int top = 5;
            int left = 1;
            int count = 1;

            foreach (DataRow row in Branchlist.Rows)
            {

                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = new Size(80, 63);
                btn.Font = new Font(Font.FontFamily, 9);
                btn.Text = row["Description"].ToString();
                btn.Tag = row["categoryid"].ToString();
                btn.BackColor = System.Drawing.Color.Cyan;
                pnlbtndyan.Controls.Add(btn);
                top += btn.Height + 2;
                btn.Click += new System.EventHandler(this.btn_Click);
                count++;
                if (count == 8)
                {
                    count = 1;
                    top = 5;
                    left += 81;
                }

            }
        }
        private void btn_Click(object sender, EventArgs e)
        {

            pnlbasedcat.Controls.Clear();
            loadallbasedcat(((sender) as Button).Tag.ToString());
            int top = 5;
            int left = 1;
            int count = 1;

            foreach (DataRow row in Branchlistbasedcat.Rows)
            {

                Button btnbased = new Button();
                btnbased.Left = left;
                btnbased.Top = top;
                btnbased.Size = new Size(80, 63);
                btnbased.Font = new Font(Font.FontFamily, 9);
                btnbased.Text = row["Productname"].ToString();
                btnbased.Tag = row["productid"].ToString();
                btnbased.BackColor = System.Drawing.Color.Cyan;
                pnlbasedcat.Controls.Add(btnbased);
                top += btnbased.Height + 2;
                btnbased.Click += new System.EventHandler(this.btnbased_Click);
                count++;
                if (count == 8)
                {
                    count = 1;
                    top = 5;
                    left += 81;
                }

            }
        }

        private void btnbased_Click(object sender, EventArgs e)
        {
            this.Tag = ((sender) as Button).Tag;
            this.DialogResult = DialogResult.OK;
            

        }
    }
}
