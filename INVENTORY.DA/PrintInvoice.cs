using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using GenCode128;
using INVENTORY.DA;

namespace INVENTORY.DA
{

    /// <summary>
    /// First Commit - 26th Feb 2020
    /// </summary>
    public class PrintInvoice
    {
        #region Print Invoice
        
        SOrder _SOrder = null;
        PrintDocument pdoc = null;
        DataTable _SalesDT = null;

        string _CashierName = "";
        string _InvoiceNo;
        DateTime _InvoiceDate;
        decimal _TotalDis = 0;
        decimal _Adjust = 0;
        decimal _TotalAmt = 0;
        decimal _PrvDue = 0;
        decimal _GrandTotal = 0;
        decimal _Payable = 0;
        decimal _DueAmt = 0;
        int nNumberOfCopies = 1;

        #endregion

        #region Barcode Purpose
        string sBarcode = string.Empty;
        string sUnitPrice = string.Empty;
        string sBookName = string.Empty;
        int nBarCodeWeight = 1;
        PrintDocument pdocBarCode = null;
        #endregion

        public PrintInvoice()
        {

        }
        public void print(SOrder oSOrder)
        { 
          

            _CashierName = Global.CurrentUser.UserName;
            _SOrder = oSOrder;
            _InvoiceNo = oSOrder.InvoiceNo;
            _InvoiceDate = (DateTime)oSOrder.InvoiceDate;
            _TotalDis = (decimal)oSOrder.NetDiscount;
            _Adjust = (decimal)oSOrder.Adjustment;
            _TotalAmt = (decimal)oSOrder.TotalAmount;
            _PrvDue = (decimal)(oSOrder.Customer.TotalDue - oSOrder.TotalDue);
            _GrandTotal = (decimal)(oSOrder.GrandTotal + (oSOrder.Customer.TotalDue - oSOrder.TotalDue));
            _Payable = (decimal)oSOrder.GrandTotal - (decimal)oSOrder.NetDiscount-oSOrder.Adjustment;
            _DueAmt = oSOrder.Customer.TotalDue;

            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 8);


            PaperSize psize = new PaperSize("Custom", 100, 200);
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 1200; //620; /
            pdoc.DefaultPageSettings.PaperSize.Width = 295;//450;
            //pd.PrinterSettings.Copies = 3;

            //pd.AllowSelection = true;
            //pd.AllowSomePages = true;

            #region For Auto Print

            //for (int i = 1; i <= nNumberOfCopies; i++)
            //{
            //    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            //    pdoc.Print();
            //}

            #endregion

            #region Using by Command
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                result = pp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }

            #endregion

        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            DEWSRMEntities db=new DEWSRMEntities();
            SystemInformation oSys = db.SystemInformations.FirstOrDefault();

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 8);
            float fontHeight = font.GetHeight();
            int startX = 7;
            int startY = 20;
            int Offset = 30;
            graphics.DrawString("        "+oSys.Name, new Font("Courier New", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(oSys.Address, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString("      "+oSys.TelephoneNo, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            String underLine1 = "-------------------------------------------------";
            graphics.DrawString(underLine1, new Font("Courier New", 7), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Cashier Name:" + _CashierName, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Invoice No:" + _InvoiceNo, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Date & Time:" + _InvoiceDate, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 15;
            String underLine = "-------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 7), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 15;                     //-------
            graphics.DrawString("Product " + "     " + "" + " " + " Qty" + "     " + "S.Rate" + "   " + "Total", new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            underLine = "-------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 7), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);


            foreach (SOrderDetail oItem in _SOrder.SOrderDetails)
            {
                Offset = Offset + 15;
                graphics.DrawString(oItem.Product.ProductName + "", new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
                Offset = Offset + 15;             //---------------------
                graphics.DrawString("          " + "" + "       " + Math.Round((decimal)oItem.Quantity, 0) + "     " + Math.Round((decimal)oItem.UnitPrice, 2) + "    " + Math.Round((decimal)oItem.UTAmount, 2), new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            }

            Offset = Offset + 15;
            underLine = "-------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            graphics.DrawString("Total Dis.                           " + Math.Round(_TotalDis, 2), new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);


            Offset = Offset + 15;
            graphics.DrawString("Net Amount.                          " + Math.Round(_TotalAmt, 2), new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

           // Offset = Offset + 15;
           //// graphics.DrawString("Prv. Due" + "                            " + Math.Round(_PrvDue,2), new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);

           // Offset = Offset + 15;
           // graphics.DrawString("Grand Total :" + "                       " + Math.Round(_GrandTotal,2), new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            underLine = "-------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);


            Offset = Offset + 15;
            graphics.DrawString("AdjustAmt. :                         " + Math.Round(_Adjust, 2), new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            underLine = "-------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            graphics.DrawString("Payable Amt :                        " + Math.Ceiling(_Payable), new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 15;
            underLine = "-------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);


          

        }

        public void PrintBarcode(POrder oPOrder)
        {
            #region Barcode Purpose

            PrintDialog pd = new PrintDialog();
            pdocBarCode = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 8);

            PaperSize psize = new PaperSize("Custom", 250, 130);
            pd.Document = pdocBarCode;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdocBarCode.DefaultPageSettings.PaperSize.Height = 130;
            pdocBarCode.DefaultPageSettings.PaperSize.Width = 250;

            foreach (POrderDetail oPODetail in oPOrder.POrderDetails)
            {
                //foreach (POProductDetail oPOPItem in oPODetail.POProductDetails)
                //{
                //    sBarcode = oPOPItem.PBarcode;
                //    sBookName = oPOPItem.Product.ProductName;
                //    sUnitPrice = oPOPItem.SalesRate.ToString();

                //    #region For Auto Print
                //    //pdocBarCode.PrintPage += new PrintPageEventHandler(pdoc_PrintPageBarcode);
                //    //pdocBarCode.Print();
                //    #endregion

                //    #region Using by Command
                //    pdocBarCode.PrintPage += new PrintPageEventHandler(pdoc_PrintPageBarcode);
                //    DialogResult result = pd.ShowDialog();
                //    if (result == DialogResult.OK)
                //    {
                //        PrintPreviewDialog pp = new PrintPreviewDialog();
                //        pp.Document = pdocBarCode;
                //        result = pp.ShowDialog();
                //        if (result == DialogResult.OK)
                //        {
                //            pdoc.Print();
                //        }
                //    }

                //    #endregion
                //}
            }

            #endregion
        }

        private void pdoc_PrintPageBarcode(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Courier New", 8);

            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 2;
            int Offset = 5;


            string sBSN = string.Format("{0}", "Sree Krisna Pharmacy");
            g.DrawString(sBSN, new Font("Arial", 10, FontStyle.Bold), System.Drawing.Brushes.Black, startX + 33, startY);
            Offset = Offset + 15;

            Image myimg = Code128Rendering.MakeBarcodeImage(sBarcode, nBarCodeWeight, true);
            g.DrawImage(myimg, startX + 3, startY + Offset);
            Offset = Offset + 25;

            //pictBarcode.Image = myimg;

            string sBarcodeCaption = string.Format("   {0}", sBarcode + "");
            g.DrawString(sBarcodeCaption, new Font("Arial", 10, FontStyle.Bold), System.Drawing.Brushes.Black, startX + 15, startY + Offset);
            Offset = Offset + myimg.Height + 5;

            string caption = string.Format("  Tk:   {0}", Convert.ToString(sUnitPrice));
            g.DrawString(caption, new Font("Arial", 10, FontStyle.Bold), System.Drawing.Brushes.Black, startX + 10, startY + Offset);
            //Offset = Offset + 20;

        }

    }
}
