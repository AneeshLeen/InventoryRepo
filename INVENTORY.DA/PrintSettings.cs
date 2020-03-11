using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepAutomation.Barcode.Bean;

namespace INVENTORY.DA
{
    public class PrintSettings
    {
        // Printing commands are depends on the Dotmatrix printer that we are using

        System.IO.StreamWriter rdr;
        private string Bold_On = "";
        private string Bold_Off = "";
        private string Width_On = ""; //Chr(27) + Chr(87) + Chr(49) 'W1
        private string Width_Off = "";
        public string BillType;
        public string BillNo;
        public string BillDt;
        public string tran_type;
        public string Discount;
        public string bill_amt;
        public string NetAmount;
        public string reciept_amount;
        public decimal MRPTotal = 0, SavedTotal = 0;
        public decimal count;
        public System.Data.DataTable dt_print;

        public PrintSettings()
        {
            rdr = new System.IO.StreamWriter("bill.txt");
        }
        public void Close()
        {
            rdr.Close();
        }
        public void PrintHeader()
        {
            rdr.WriteLine(Bold_On + "SPRINGFORD VARIETY & FOOD STORE" + Bold_Off);
            rdr.WriteLine(Bold_On + "3 West Street North" + Bold_Off);
            rdr.WriteLine(Bold_On + "Springford,ON" + Bold_Off);
            rdr.WriteLine(Bold_On + "HST#781501283RT0001" + Bold_Off);

            PrintLine();

            //rdr.WriteLine("Bill NO   : " + BillNo);
            //rdr.WriteLine("Bill Date : " + BillDt);
            //PrintLine();
            //rdr.WriteLine(Bold_On + Width_On + BillType + Width_Off + Bold_Off);
            //PrintLine();
        }

        public void PrintDetails()
        {
            rdr.WriteLine("Decription                                      Amt($)");
            //rdr.WriteLine(Bold_On + Width_On + BillType + Width_Off + Bold_Off);
            //int i;
            PrintLine();
            //for (i = 0; i < count - 1; i++)
            //{
            //    rdr.Write("{0,10}", GetFormatedText(dt_print.Rows[i][0].ToString(), 10) + "|");
            //    rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][1].ToString(), 10) + "|");
            //    rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][2].ToString(), 10) + "|");
            //    rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][3].ToString(), 10) + "|");
            //    rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][4].ToString(), 10) + "|");
            //    rdr.WriteLine("");
            //}
        }

        private string GetFormatedText(string Cont, int Length)
        {
            int rLoc = Length - Cont.Length;
            if (rLoc < 0)
            {
                Cont = Cont.Substring(0, Length);
            }
            else
            {
                int nos;
                for (nos = 0; nos < 3; nos++)
                    Cont = Cont + " ";
            }
            return (Cont);
        }

        public void PrintFooter()
        {
            //PrintLine();
            //rdr.WriteLine();
            rdr.WriteLine("Net Total          : " + bill_amt);
            rdr.WriteLine("Bill Total       : " + Discount);
            rdr.WriteLine("HST     : " + NetAmount);
            rdr.WriteLine("CARD : " + reciept_amount);
            rdr.WriteLine("Cahnge : " + reciept_amount);
            //rdr.WriteLine();
            PrintLine();
            rdr.WriteLine("Total Saving : " + tran_type);
            PrintLine();
            rdr.WriteLine("HST Summary");
            rdr.WriteLine("Rate                                                              HST ");
            PrintLine();
            rdr.WriteLine(" ");
            PrintLine();
            rdr.WriteLine("Till                                            DateAndTime");
            rdr.WriteLine("No of Items :");

            rdr.WriteLine("Thanks for shopping with us");
            rdr.WriteLine("Please Visit Again");
            rdr.WriteLine("Opening hours");
            rdr.WriteLine("7 Days week 7 AM TO 9 PM");

           
           
        }

        public void PrintLine()
        {
            int i;
            string Lstr = "";
            for (i = 1; i <= 75; i++)
            {
                Lstr = Lstr + "-";
            }
            rdr.WriteLine(Lstr);
        }

        public void SkipLine(int LineNos)
        {
            int i;
            for (i = 1; i <= 5; i++)
            {
                rdr.WriteLine("");
            }
        }
       
    }



}
