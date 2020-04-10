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
            objSalesPrintBO.CounterName = objSOrder.MachineName;
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
        RectangleF rect;
        Int32 height_value;
        //PrintDocument pdPrint;
        public void SalesReceiptPrint(PrintPageEventArgs e, SOrder objSOrder, List<SOrderDetail> objSOrderDetail, List<Product> objProductList, List<Category> objCatagoryList, PrintDocument pdPrint)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;      // Horizontal Alignment 

            StringFormat right = new StringFormat();
            right.Alignment = StringAlignment.Far;

            StringFormat left = new StringFormat();
            left.Alignment = StringAlignment.Near;
            SizeF stringSize = new SizeF();          

            SalesPrintBO objSalesPrintBO = SetPrintData(objSOrder, objSOrderDetail, objProductList, objCatagoryList);
            
            Font printFont = new Font("Microsoft Sans Serif", (float)10, FontStyle.Regular, GraphicsUnit.Point); // Substituted to FontA Font

            e.Graphics.PageUnit = GraphicsUnit.Point;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);

            
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);

            format1.Alignment = StringAlignment.Center;

            printFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point);
            stringSize = e.Graphics.MeasureString("SPRINGFORD VARIETY & FOOD STORE", printFont);
            e.Graphics.DrawString("SPRINGFORD VARIETY & FOOD STORE", printFont, Brushes.Black, rect, format);
           
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("3 West Street North", printFont);
            e.Graphics.DrawString("3 West Street North", printFont, Brushes.Black, rect, format);
           
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("Springford,ON", printFont);
            e.Graphics.DrawString("Springford,ON", printFont, Brushes.Black, rect, format);
          
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("HST#781501283RT0001", printFont);
            e.Graphics.DrawString("HST#781501283RT0001", printFont, Brushes.Black, rect, format);
            //
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
         
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("Decription                                            Amt($)", printFont, Brushes.Black, rect, left);
           
            height_value = Convert.ToInt32(stringSize.Height) + height_value-10;

            stringSize = e.Graphics.MeasureString("___________________________________", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("_____________________________________", printFont, Brushes.Black, rect, left);
            
            //height_value = Convert.ToInt32(stringSize.Height) + height_value;
            
            printFont = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point);
            
            for (int i = 0; i <= objSalesPrintBO.objSalesPrintItems.Count() - 1; i++)      //decimal.Round(yourValue, 2, MidpointRounding.AwayFromZero)
                                                                                           //>>>>>>> f132b99356ebf57b4e09098e73689df77a90e3fb
            {

                height_value = Convert.ToInt32(stringSize.Height) + height_value;
                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 120, pdPrint.DefaultPageSettings.PrintableArea.Height);
                stringSize = e.Graphics.MeasureString(objSalesPrintBO.objSalesPrintItems[i].ItemName + string.Format("{0:}", Convert.ToString(decimal.Round(objSalesPrintBO.objSalesPrintItems[i].Amount, 2, MidpointRounding.AwayFromZero))), printFont);

                e.Graphics.DrawString(objSalesPrintBO.objSalesPrintItems[i].ItemName.PadRight(40), printFont, Brushes.Black, rect, left);

                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                e.Graphics.DrawString(Convert.ToString(decimal.Round(objSalesPrintBO.objSalesPrintItems[i].Amount, 2, MidpointRounding.AwayFromZero)).PadRight(20), printFont, Brushes.Black, rect, right);
                               

                if (objSalesPrintBO.objSalesPrintItems[i].Quantity > 1)
                {
                    height_value = Convert.ToInt32(stringSize.Height) + height_value;
                   
                    stringSize = e.Graphics.MeasureString(Convert.ToString(objSalesPrintBO.objSalesPrintItems[i].Quantity) + " @                     " + Convert.ToString(objSalesPrintBO.objSalesPrintItems[i].IndividualPrice), printFont);
                    rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                    e.Graphics.DrawString(Convert.ToString( objSalesPrintBO.objSalesPrintItems[i].Quantity)+" @                     " + Convert.ToString(objSalesPrintBO.objSalesPrintItems[i].IndividualPrice), printFont, Brushes.Black, rect, format);
                   
                }

                height_value = Convert.ToInt32(stringSize.Height) + height_value-10 ;
             
            }
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

            height_value = Convert.ToInt32(stringSize.Height) + height_value-10;
            stringSize = e.Graphics.MeasureString("___________________________________", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, rect, left);


          
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
           
            stringSize = e.Graphics.MeasureString("Net Total :".PadRight(50), printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("Net Total :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.NetAmount, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);


            
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            stringSize = e.Graphics.MeasureString("Bill Total :".PadRight(50), printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("Bill Total :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.BillTotal, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);


           
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            stringSize = e.Graphics.MeasureString("HST :".PadRight(50), printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("HST :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.HST, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);


           
            //height_value = Convert.ToInt32(stringSize.Height) + height_value;


            if (objSalesPrintBO.Card > 0 && objSalesPrintBO.Cash > 0)
            {
                height_value = Convert.ToInt32(stringSize.Height) + height_value;
                stringSize = e.Graphics.MeasureString("CASH :".PadRight(50), printFont);
                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                e.Graphics.DrawString("CASH :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.Cash, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);
                


                height_value = Convert.ToInt32(stringSize.Height) + height_value;
                stringSize = e.Graphics.MeasureString("CARD :".PadRight(50), printFont);
                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                e.Graphics.DrawString("CARD :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.Card, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);
               

            }
            else if (objSalesPrintBO.Card > 0)
            {
                height_value = Convert.ToInt32(stringSize.Height) + height_value;
                stringSize = e.Graphics.MeasureString("CARD :".PadRight(50), printFont);
                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                e.Graphics.DrawString("CARD :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.Card, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);
              
            }
            else if (objSalesPrintBO.Cash > 0)
            {
                height_value = Convert.ToInt32(stringSize.Height) + height_value;
                stringSize = e.Graphics.MeasureString("CASH :".PadRight(50), printFont);
                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                e.Graphics.DrawString("CASH :".PadRight(50) + string.Format("{0:}", decimal.Round(objSalesPrintBO.Cash, 2, MidpointRounding.AwayFromZero)), printFont, Brushes.Black, rect, left);
                

            }
           

            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            stringSize = e.Graphics.MeasureString("Change :               ", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("Change :               " + decimal.Round(objSalesPrintBO.Change, 2, MidpointRounding.AwayFromZero), printFont, Brushes.Black, rect, left);


           
            height_value = Convert.ToInt32(stringSize.Height) + height_value-6;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("___________________________________", printFont);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, rect, left);


           
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("Total Savings :               ", printFont);
            e.Graphics.DrawString("Total Savings :               " + decimal.Round(objSalesPrintBO.TotalSavings, 2, MidpointRounding.AwayFromZero), printFont, Brushes.Black, rect, left);
          
            stringSize = e.Graphics.MeasureString("___________________________________", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height+5);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, rect, left);


           
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);
            stringSize = e.Graphics.MeasureString("HST Summary  ", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("HST Summary  ", printFont, Brushes.Black, rect, left);



          
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("Rate         Net            HST       Total", printFont);
            e.Graphics.DrawString("Rate         Net            HST       Total", printFont, Brushes.Black, rect, format);
            

            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
            stringSize = e.Graphics.MeasureString("___________________________________", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, rect, left);


          
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            for (int i = 0; i <= objSalesPrintBO.objHSTSummary.Count() - 1; i++)
            {
                stringSize = e.Graphics.MeasureString(decimal.Round(objSalesPrintBO.objHSTSummary[i].Rate, 2, MidpointRounding.AwayFromZero) + "         " + decimal.Round(objSalesPrintBO.objHSTSummary[i].Net, 2, MidpointRounding.AwayFromZero) + "       " + decimal.Round(objSalesPrintBO.objHSTSummary[i].HST, 2, MidpointRounding.AwayFromZero) + "%      " + decimal.Round(objSalesPrintBO.objHSTSummary[i].Total, 2, MidpointRounding.AwayFromZero), printFont);
                rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
                e.Graphics.DrawString(decimal.Round(objSalesPrintBO.objHSTSummary[i].Rate, 2, MidpointRounding.AwayFromZero) + "         " + decimal.Round(objSalesPrintBO.objHSTSummary[i].Net, 2, MidpointRounding.AwayFromZero) + "       " + decimal.Round(objSalesPrintBO.objHSTSummary[i].HST, 2, MidpointRounding.AwayFromZero) + "        " + decimal.Round(objSalesPrintBO.objHSTSummary[i].Total, 2, MidpointRounding.AwayFromZero), printFont, Brushes.Black, rect, format);
               
                height_value = Convert.ToInt32(stringSize.Height) + height_value-2;
            }
            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

           
            stringSize = e.Graphics.MeasureString("___________________________________", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 65, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("______________________________________", printFont, Brushes.Black, rect, left);


          
            height_value = Convert.ToInt32(stringSize.Height) + height_value-2;
            
            stringSize = e.Graphics.MeasureString("Till                        ", printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("Till #  "+ objSalesPrintBO.CounterName + "            "+ objSalesPrintBO.Date, printFont, Brushes.Black, rect, left);
            
          
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            stringSize = e.Graphics.MeasureString("No of Items  :" + objSalesPrintBO.NoOfItems, printFont);
            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 85, pdPrint.DefaultPageSettings.PrintableArea.Height);
            e.Graphics.DrawString("No of Items  :" + objSalesPrintBO.NoOfItems, printFont, Brushes.Black, rect, left);


            
            height_value = Convert.ToInt32(stringSize.Height) + height_value;

            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);

            height_value = Convert.ToInt32(stringSize.Height) + height_value-10 ;

            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("Thanks for Shopping with us", printFont);
            e.Graphics.DrawString("Thanks for Shopping with us", printFont, Brushes.Black, rect, format);
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
         

            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("Please Visit Again", printFont);
            e.Graphics.DrawString("Please Visit Again", printFont, Brushes.Black, rect, format);
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
            


            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("Opening hours", printFont);
            e.Graphics.DrawString("Opening hours ", printFont, Brushes.Black, rect, format);
            height_value = Convert.ToInt32(stringSize.Height) + height_value;
           

            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70, pdPrint.DefaultPageSettings.PrintableArea.Height);
            stringSize = e.Graphics.MeasureString("7 Days week 7 AM TO 9 PM", printFont);
            e.Graphics.DrawString("7 Days week 7 AM TO 9 PM", printFont, Brushes.Black, rect, format);
            height_value = Convert.ToInt32(stringSize.Height) + height_value;


            printFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);

            rect = new RectangleF(0, height_value, pdPrint.DefaultPageSettings.PrintableArea.Width - 70,30);
            //e.Graphics.DrawImage(CreateBarcode(objSalesPrintBO.OrderNo).drawBarcode(), CreateBarcode(objSalesPrintBO.OrderNo).drawBarcode().Width / 3, height_value);
            e.Graphics.DrawImage(CreateBarcode(objSalesPrintBO.OrderNo).drawBarcode(), rect);

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
