using INVENTORY.DA;
using OnBarcode.Barcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.UI.BL
{
    public class PrintBO
    {

        private SalesPrintBO SetPrintData(SOrder objSOrder, List<SOrderDetail> objSOrderDetail, List<Product> objProductList, List<Category> objCatagoryList)
        {
            SalesPrintBO objSalesPrintBO = new SalesPrintBO();
            if (objSOrder.Adjustment > 0)
            {
                objSalesPrintBO.BillTotal = objSOrderDetail.Sum(p => (p.SRate * p.Quantity)) - objSOrder.Adjustment;
                objSalesPrintBO.TotalSavings = objSOrder.Adjustment;
            }
            else
            {
                objSalesPrintBO.BillTotal = objSOrderDetail.Sum(p => ((p.SRate * p.Quantity) + p.CGSTAmt) - p.PPDAmount);
                objSalesPrintBO.TotalSavings = objSOrderDetail.Sum(p => p.PPDAmount);
            }
            objSalesPrintBO.OrderNo = objSOrder.SOrderID.ToString();
            objSalesPrintBO.NetAmount = objSOrder.TotalAmount;
            objSalesPrintBO.Card = objSOrder.CardPaidAmount;
            objSalesPrintBO.Date = objSOrder.CreateDate.Value;
            objSalesPrintBO.HST = objSOrder.VATAmount;
            if (objSalesPrintBO.Card == 0)
            {
                objSalesPrintBO.Cash = objSOrder.GivenCash;

                objSalesPrintBO.Change = objSOrder.GivenCash - objSOrder.CashPaidAmount < 0 ? 0 : Convert.ToDecimal(objSOrder.GivenCash - objSOrder.CashPaidAmount);
            }
            objSalesPrintBO.NoOfItems = objSOrderDetail.Sum(p => p.Quantity);

            string Itemname = "";
            foreach (var objitem in objSOrderDetail)
            {
                if (objitem.TypeID == (int)EnumSalesItemType.Product)
                {
                    Itemname = (objProductList.FirstOrDefault(o => o.ProductID == objitem.ProductID)).ProductName;

                    objSalesPrintBO.objSalesPrintItems.Add(new SalesPrintItems()
                    {
                        ItemName = Itemname,
                        Amount = objitem.UTAmount,
                        IndividualPrice = objitem.SRate - objitem.CGSTAmt,
                        Quantity = objitem.Quantity,
                    }
                    );
                }
                else
                {
                    Itemname = (objCatagoryList.FirstOrDefault(o => o.CategoryID == objitem.ProductID)).Description;

                    objSalesPrintBO.objSalesPrintItems.Add(new SalesPrintItems()
                    {
                        ItemName = Itemname,
                        Amount = objitem.UTAmount,
                        IndividualPrice = objitem.SRate,
                        Quantity = objitem.Quantity,
                    }
                    );
                }
                objSalesPrintBO.objHSTSummary.Add(new HSTSummary()
                {
                    HST = objitem.CGSTPerc,
                    Rate = objitem.CGSTAmt,
                    Net = objitem.UTAmount,
                    Total = objitem.UTAmount + objitem.CGSTAmt
                });
            }
            return objSalesPrintBO;

        }
        public void SalesReceiptPrint(PrintPageEventArgs e, SOrder objSOrder, List<SOrderDetail> objSOrderDetail, List<Product> objProductList, List<Category> objCatagoryList)
        {
            SalesPrintBO objSalesPrintBO = SetPrintData(objSOrder, objSOrderDetail, objProductList, objCatagoryList);

            float x, y, lineOffset;

            // Instantiate font objects used in printing.
            Font printFont = new Font("Microsoft Sans Serif", (float)10, FontStyle.Regular, GraphicsUnit.Point); // Substituted to FontA Font

            e.Graphics.PageUnit = GraphicsUnit.Point;

            // Draw the bitmap
            x = 79;
            y = 0;
            // e.Graphics.DrawImage(pbImage.Image, x, y, pbImage.Image.Width - 13, pbImage.Image.Height - 10);

            // Print the receipt text
            lineOffset = printFont.GetHeight(e.Graphics) - (float)0.5;
            x = 0;
            //y = 24 + lineOffset;


            //Header
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            //format1.LineAlignment = StringAlignment.Near;
            format1.Alignment = StringAlignment.Center;

            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("SPRINGFORD VARIETY & FOOD STORE", printFont, Brushes.Black, x, y, format1);
            y += lineOffset;
            e.Graphics.DrawString("3 West Street North", printFont, Brushes.Black, x, y, format1);
            y += lineOffset;
            e.Graphics.DrawString("Springford,ON", printFont, Brushes.Black, x, y, format1);
            y += lineOffset;
            e.Graphics.DrawString("HST#781501283RT0001", printFont, Brushes.Black, x, y, format1);
            //

            //Details                                      
            y = y + (lineOffset * (float)1.5);

            e.Graphics.DrawString("Decription                                        Amt($)", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)0.5);
            lineOffset = printFont.GetHeight(e.Graphics) - 3;

            e.Graphics.DrawString("___________________________________", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            printFont = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point);
            // for (int i = 0; i <= SetPrintData().objSalesPrintItems.Count()-1; i++)
            //=======
            for (int i = 0; i <= objSalesPrintBO.objSalesPrintItems.Count() - 1; i++)
            {
                e.Graphics.DrawString(objSalesPrintBO.objSalesPrintItems[i].ItemName.PadRight(27) + string.Format("{0:}", Convert.ToString(objSalesPrintBO.objSalesPrintItems[i].Amount)).PadLeft(12), printFont, Brushes.Black, x, y);
                y += (lineOffset * (float)1.1);
            }
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, x, y);
            //y += (lineOffset * (float)1.5);
            y += lineOffset;
            //

            //e.Graphics.DrawString("Net Total :               " + objSalesPrintBO.NetAmount, printFont, Brushes.Black, x, y);
            e.Graphics.DrawString("Net Total :".PadRight(50) + string.Format("{0:}", objSalesPrintBO.NetAmount), printFont, Brushes.Black, x, y);
            //graphics.DrawString("Total To Pay".PadRight(15) + "Rs " + string.Format("{0:}", total), f, new SolidBrush(Color.Black), startX, startY + offset);
            y += (lineOffset * (float)1.5); ;

            e.Graphics.DrawString("Bill Total :".PadRight(50) + string.Format("{0:}", objSalesPrintBO.BillTotal), printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            e.Graphics.DrawString("HST :".PadRight(50) + string.Format("{0:}", objSalesPrintBO.HST), printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            e.Graphics.DrawString("CARD :".PadRight(50) + string.Format("{0:}", objSalesPrintBO.Card), printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            e.Graphics.DrawString("Change :               " + objSalesPrintBO.Change, printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            e.Graphics.DrawString("Total Savings :               " + objSalesPrintBO.TotalSavings, printFont, Brushes.Black, x, y);
            //y += (lineOffset * (float)1.5); 
            y += lineOffset;
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);

            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);

            e.Graphics.DrawString("HST Summary  ", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            e.Graphics.DrawString("Rate         Net          HST       Total", printFont, Brushes.Black, x, y);
            //y += (lineOffset * (float)1.5); ;
            y += lineOffset;
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            for (int i = 0; i <= objSalesPrintBO.objHSTSummary.Count() - 1; i++)
            {
                e.Graphics.DrawString(objSalesPrintBO.objHSTSummary[i].Rate + "       " + objSalesPrintBO.objHSTSummary[i].Net + "      " + objSalesPrintBO.objHSTSummary[i].HST + "       " + objSalesPrintBO.objHSTSummary[i].Total, printFont, Brushes.Black, x, y);
                y += (lineOffset * (float)1.5);
            }
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

            lineOffset = printFont.GetHeight(e.Graphics) - 3;
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            //y += lineOffset;
            e.Graphics.DrawString("Till                        " + objSalesPrintBO.Date, printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5); ;
            e.Graphics.DrawString("No of Items  :" + objSalesPrintBO.NoOfItems, printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("Thanks for Shopping with us", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            e.Graphics.DrawString("Please Visit Again", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            e.Graphics.DrawString("Opening hours ", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)1.5);
            e.Graphics.DrawString("7 Days week 7 AM TO 9 PM", printFont, Brushes.Black, x, y);

            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

            y += (lineOffset * (float)2.0);
            // Indicate that no more data to print, and the Print Document can now send the print data to the spooler.         

            //float imagewidth = CreateBarcode(SetPrintData().OrderNo).drawBarcode().Width;

            e.Graphics.DrawImage(CreateBarcode(objSalesPrintBO.OrderNo).drawBarcode(), CreateBarcode(objSalesPrintBO.OrderNo).drawBarcode().Width / 2, y);
            //=======
            //e.Graphics.DrawImage(CreateBarcode(objSalesPrintBO.OrderNo).drawBarcode(), x, y);

            e.HasMorePages = false;
        }
        private static Linear CreateBarcode(string orderNo)
        {
            Linear barcode = new Linear();// create a barcode
            barcode.Type = BarcodeType.CODE128;// select barcode type
            barcode.Data = orderNo;// set barcode data
            barcode.X = 2.5F;// set x
            barcode.Y = 30.0F;// set y
            barcode.Resolution = 96;// set resolution
            barcode.Rotate = Rotate.Rotate0;// set rotation
            barcode.BarcodeWidth = 150;
            barcode.BarcodeHeight = 50;
            //barcode.AutoResize = true;
            return barcode;
        }
    }

}
