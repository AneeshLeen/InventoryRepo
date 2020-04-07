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
    public partial class frmlast7dayssale : Form
    {
        public frmlast7dayssale()
        {
            InitializeComponent();
        }

        private void frmlast7dayssale_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=DEWSRMTEST;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("select sum(grandtotal+ VATAmount) as total, datename(WEEKDAY, ( dateadd(DAY,0, datediff(day,0, CreateDate)))) as created, dateadd(DAY,0, datediff(day,0, CreateDate)) as[date] from [dbo].[SOrders] where CreateDate BETWEEN GETDATE()-7 AND GETDATE() group by dateadd(DAY,0, datediff(day,0, CreateDate))", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dt);           

            crtlast7days.DataSource = dt;
            crtlast7days.Series.Add("Sale");
            //crtlast7days.Titles.Add("total");
            crtlast7days.Series["Sale"].XValueMember = "date";
            crtlast7days.Series["Sale"].IsValueShownAsLabel =true;
            crtlast7days.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            crtlast7days.Series["Sale"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            crtlast7days.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            crtlast7days.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            crtlast7days.Series["Sale"].YValueMembers = "total";           
           
            crtlast7days.DataBind();
        }
    }
}
