using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using INVENTORY.DA;
using INVENTORY.UI.BL;

namespace INVENTORY.UI
{
    public partial class frmpromo : Form
    {
        public PromoData objPromoData { get; set; }

        DirectoryInfo di;
        List<FileInfo> images = new List<FileInfo>();
       
        int timeTemp = 0;
        DataGridView dtpromogrid;
        BackgroundWorker backgroundWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };
        public frmpromo( )
        {
            InitializeComponent();
            dgProductspromo.AutoGenerateColumns = false;
            objPromoData = new PromoData();
        }
        internal void UpdatePromoData(List<SalesItemBO> objSaleList)
        {
            dgProductspromo.DataSource = objSaleList;
            lblbilltotal.Text = String.Format("{0:0.00}", objPromoData.BillTotal);

            lblbilldisc.Text = String.Format("{0:0.00}", objPromoData.BillDiscount);
            lblbillqty.Text = objPromoData.NoofItems.ToString();
            lblhst.Text = String.Format("{0:0.00}", objPromoData.HST);

            lblNetTotal.Text = String.Format("{0:0.00}", objPromoData.NetTotal);
            lblrefundqty.Text = String.Format("{0:0.00}", objPromoData.Refund);
            lblsavings.Text = String.Format("{0:0.00}", objPromoData.Savings);

            lblPayment.Text = String.Format("{0:0.00}", objPromoData.Payments);
            lblBalance.Text = String.Format("{0:0.00}", objPromoData.Balance);
            lblcashback.Text = String.Format("{0:0.00}", objPromoData.CashBack);

        }
        public void ChangePicture()//to change pics
        {
            Random d = new Random();
            int index = d.Next(0, images.Count);
            FileInfo item = images.ElementAt(index);
            pctboxpromo.Image = Image.FromFile(item.FullName);
        }
        public void GetImagesOfType(string type)// will read all the images of specified TYPE from the source
        {
            FileInfo[] Img = di.GetFiles(type);
            foreach (FileInfo im in Img)
                images.Add(im);
        }
        private void frmpromo_Load(object sender, EventArgs e)
        {

            di = new DirectoryInfo(Application.StartupPath+ "\\PromoImages");

            GetImagesOfType("*.jpg");//will add .jpg files to list - add other file types below
                                     //GetImagesOfType("*.png"); 

            backgroundWorker.DoWork += BackgroundWorkerOnDoWork;           
            ChangePicture();
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
            //}
        }        

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                Thread.Sleep(1000);
                if (timeTemp < 100) timeTemp += 10;
                else
                {
                    timeTemp = 0;
                    ChangePicture();
                }
                //dgProducts.DataSource = dtpromogrid.DataSource;
                //dgProducts.Refresh();
                worker.ReportProgress(timeTemp);
            }

          
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmpromo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void frmpromo_Shown(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Count() > 1)
            {
                this.Location = Screen.AllScreens[1].Bounds.Location;
            }
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
