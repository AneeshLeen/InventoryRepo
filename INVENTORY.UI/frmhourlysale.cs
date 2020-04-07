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
    public partial class frmhourlysale : Form
    {
        public frmhourlysale()
        {
            InitializeComponent();
        }

        private void frmhourlysale_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRMTEST;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("select[Time], sum(total) Total from(select sum(grandtotal + VATAmount) as total, DATEPART(HOUR, CreateDate)[time] from[dbo].[SOrders] where dateadd(DAY, 0, datediff(day, 0, CreateDate)) = dateadd(DAY, 0, datediff(day, 0, GETDATE())) group by CreateDate) tt group by[time]", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dt); ;
            dgProducts.DataSource = dt;
        }
    }
}
