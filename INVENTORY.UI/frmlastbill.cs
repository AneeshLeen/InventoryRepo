using INVENTORY.DA;
using INVENTORY.UI.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class frmlastbill : Form
    {
        List<SalesItemBO> SalesItemList = new List<SalesItemBO>();

        List<Product> objProductList = null;
        List<Category> objCatagoryList = null;
        SOrder objSOrder = null;
        List<SOrderDetail> objSOrderDetail = null;
        public frmlastbill()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dgpayment.AutoGenerateColumns = false;
            dgProducts.AutoGenerateColumns = false;
            LoadGridDataSource();
        }

        private void LoadGridDataSource()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                objSOrder = db.SOrders.OrderByDescending(p => p.SOrderID).FirstOrDefault(so => so.CreatedBy == Global.CurrentUser.UserID && so.ShiftEndStatus == false);

                if (objSOrder != null)
                {
                    objProductList = db.Products.ToList<Product>();
                    objCatagoryList = db.Categorys.ToList<Category>();
                    objSOrderDetail = db.SOrderDetails.Where(so => so.SOrderID == objSOrder.SOrderID).ToList<SOrderDetail>();
                }
            }
            if (objSOrder != null)
            {
                string Itemname = "";
                foreach (var objitem in objSOrderDetail)
                {
                    if (objitem.TypeID == (int)EnumSalesItemType.Product)
                    {
                        Itemname = (objProductList.FirstOrDefault(o => o.ProductID == objitem.ProductID)).ProductName;
                    }
                    else
                    {
                        Itemname = (objCatagoryList.FirstOrDefault(o => o.CategoryID == objitem.ProductID)).Description;
                    }
                    SalesItemList.Add(new SalesItemBO()
                    {
                        ItemName = Itemname,
                        Quantity = objitem.Quantity,
                        SRate = objitem.UnitPrice,//price
                        Amount = objitem.UTAmount,
                    });

                }
                decimal cashAmount = objSOrder.CashPaidAmount;
                decimal cardAmount = objSOrder.CardPaidAmount;

                List<ShiftEndDetailsBO> objPaymentList = new List<ShiftEndDetailsBO>();
                if (cashAmount != 0)
                {
                    objPaymentList.Add(new ShiftEndDetailsBO() { TypeID = 1, TypeName = "CASH", SysBal = cashAmount.ToString() });
                }
                if (cardAmount != 0)
                {
                    objPaymentList.Add(new ShiftEndDetailsBO() { TypeID = 2, TypeName = "CARD", SysBal = cardAmount.ToString() });
                }

                dgProducts.DataSource = SalesItemList;
                dgpayment.DataSource = objPaymentList;
                lblbilltotal.Text = objSOrder.GrandTotal.ToString();
                lbldate.Text = Convert.ToDateTime(objSOrder.CreateDate).ToString("MM/dd/yyyy HH:mm");
                lbltillno.Text = objSOrder.InvoiceNo;
                lblcashier.Text = Global.CurrentUser.UserName;
                lblchange.Text = objSOrder.GivenCash - objSOrder.CashPaidAmount < 0 ? "0.00" : Convert.ToDecimal(objSOrder.GivenCash - objSOrder.CashPaidAmount).ToString("#,0.00");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void PdPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintBO objPrintBO = new PrintBO();
            objPrintBO.SalesReceiptPrint(e, objSOrder, objSOrderDetail, objProductList, objCatagoryList, pdPrint);
        }
        PrintDocument pdPrint;
        private void btnprint_Click(object sender, EventArgs e)
        {
             pdPrint = new PrintDocument();
           // pdPrint.PrintPage += PdPrint_PrintPage;

            pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(PdPrint_PrintPage);

            PrintDialog pd = new PrintDialog();
            pd.Document = pdPrint;
            try
            {

                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdPrint;
                // pp.ShowDialog();

                pdPrint.Print();


            }

            catch
            {
                MessageBox.Show("Failed to open StatusAPI.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
