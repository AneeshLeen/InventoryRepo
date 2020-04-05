using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace INVENTORY.DA
{
    public class Global
    {
        public static SystemInformation SystemInfo { get; set; }
        public static User CurrentUser { get; set; }
        public static string BranchName { get; set; }
        public static int BranchId { get; set; }
        public static int ShiftId { get; set; }

        public static int CashbackId = 132;
        
        public static string NumWords(int Num)
        {
            #region Old Code
            //string[] numbersArr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            //string[] tensArr = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
            //string[] suffixesArr = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
            //string words = "";

            //bool tens = false;

            //if (n < 0)
            //{
            //    words += "negative ";
            //    n *= -1;
            //}

            //int power = (suffixesArr.Length + 1) * 3;

            //while (power > 3)
            //{
            //    double pow = Math.Pow(10, power);
            //    if (n > pow)
            //    {
            //        if (n % Math.Pow(10, power) > 0)
            //        {
            //            words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1] + " and ";
            //        }
            //        else if (n % pow > 0)
            //        {
            //            words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1];
            //        }
            //        n %= pow;
            //    }
            //    power -= 3;
            //}
            //if (n >= 1000)
            //{
            //    if (n % 1000 > 0) words += NumWords(Math.Floor(n / 1000)) + " thousand and ";
            //    else words += NumWords(Math.Floor(n / 1000)) + " thousand";
            //    n %= 1000;
            //}
            //if (0 <= n && n <= 999)
            //{
            //    if ((int)n / 100 > 0)
            //    {
            //        words += NumWords(Math.Floor(n / 100)) + " hundred";
            //        n %= 100;
            //    }
            //    if ((int)n / 10 > 1)
            //    {
            //        if (words != "")
            //            words += " ";
            //        words += tensArr[(int)n / 10 - 2];
            //        tens = true;
            //        n %= 10;
            //    }

            //    if (n < 20)
            //    {
            //        if (words != "" && tens == false)
            //            words += " ";
            //        words += (tens ? "-" + numbersArr[(int)n - 1] : numbersArr[(int)n - 1]);
            //        n -= Math.Floor(n);
            //    }
            //}

            //return words;
            #endregion
            string[] Below20 = { "", "One ", "Two ", "Three ", "Four ", 
      "Five ", "Six " , "Seven ", "Eight ", "Nine ", "Ten ", "Eleven ", 
    "Twelve " , "Thirteen ", "Fourteen ","Fifteen ", 
      "Sixteen " , "Seventeen ","Eighteen " , "Nineteen " };
            string[] Below100 = { "", "", "Twenty ", "Thirty ", 
      "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string InWords = "";
            if (Num >= 1 && Num < 20)
                InWords += Below20[Num];
            if (Num >= 20 && Num <= 99)
                InWords += Below100[Num / 10] + Below20[Num % 10];
            if (Num >= 100 && Num <= 999)
                InWords += NumWords(Num / 100) + " Hundred " + NumWords(Num % 100);
            if (Num >= 1000 && Num <= 99999)
                InWords += NumWords(Num / 1000) + " Thousand " + NumWords(Num % 1000);
            if (Num >= 100000 && Num <= 9999999)
                InWords += NumWords(Num / 100000) + " Lac " + NumWords(Num % 100000);
            if (Num >= 10000000)
                InWords += NumWords(Num / 10000000) + " Crore " + NumWords(Num % 10000000);

            return InWords;
        }

        public static string TakaFormat(double TotalAmt)
        {

            string sInWords = string.Empty;

            string sPoisa = string.Empty;
            string[] words = TotalAmt.ToString().Split('.');
            string sTaka = words[0];
            if (words.Length == 1)
            {
                sPoisa = "00";
            }
            else
            {
                sPoisa = words[1];
                if (sPoisa.Length == 1)
                {
                    sPoisa = sPoisa + "0";
                }
            }

            int i = sTaka.Length;
            string sDH1 = string.Empty;

            if (i == 9)
            {
                sDH1 = Spell.SpellAmount.F_Crores(sTaka, sPoisa);
            }
            else if (i == 8)
            {
                sDH1 = Spell.SpellAmount.F_Crore(sTaka, sPoisa);
            }
            else if (i == 7)
            {
                sDH1 = Spell.SpellAmount.F_Lakhs(sTaka, sPoisa);
            }
            else if (i == 6)
            {
                sDH1 = Spell.SpellAmount.F_Lakh(sTaka, sPoisa);
            }
            else if (i == 5)
            {
                sDH1 = Spell.SpellAmount.F_Thousands(sTaka, sPoisa);
            }
            else if (i == 4)
            {
                sDH1 = Spell.SpellAmount.F_Thousand(sTaka, sPoisa);
            }
            else if (i == 3)
            {
                sDH1 = Spell.SpellAmount.F_Hundred(sTaka, sPoisa);
            }
            else if (i == 2)
            {
                sDH1 = Spell.SpellAmount.Tens(sTaka);
            }

            sInWords = " " + sDH1 + ".";

            return sInWords;

        }

        public static string DecryptConnection(string connectionName)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            conn = CryptorEngine.Decrypt(conn, true);
            conn = HttpUtility.HtmlDecode(conn);
            return conn;
        }

        public class ShortProduct
        {
            public decimal Stock { get; set; }
            public decimal Short { get; set; }
            public string Company { get; set; }
            public string Size { get; set; }
            public string ProductName { get; set; }
        }

        public class CompanyWiseSales
        {
            public decimal Amount { get; set; }
            public string Company { get; set; }
        }

        public class TopProsuct
        {
            public decimal Quantity { get; set; }
            public string ProductName { get; set; }
        }
        //public class ShortProduct
        //{
        //    public decimal Stock { get; set; }
        //    public decimal Short { get; set; }
        //    public string Company { get; set; }
        //    public string ProductName { get; set; }
        //}
        public class DayWiseSales
        {
            public decimal Amount { get; set; }
            public DateTime InvoiceDate { get; set; }
        }
        public class DayWiseNoofSales
        {
            public int NoofSales { get; set; }
            public DateTime InvoiceDate { get; set; }
        }


        #region Onnorokom SMS service Credentials
        public static readonly string TESTBD_UserName = "232323232";
        public static readonly string TESTBD_Password = "e4798uhhhh5";
        public static readonly string TESTBD_APIKEY = "b0iiii98-fe9b-4747-b537-b14b38c56611";
        public static readonly string TESTBD_BASE_URL = "https://api2.testbd.com/HttpSendSms.ashx?";
        #endregion

        public static string DateddMMMYYYY(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
        }


    }
    public class DailyStockVSSalesSummaryReportModel
    {
        public DateTime Date { get; set; }
        public int ConcernID { get; set; }
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public decimal OpeningStockQuantity { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal TotalStockQuantity { get; set; }
        public decimal SalesQuantity { get; set; }
        public decimal ClosingStockQuantity { get; set; }
        public decimal OpeningStockValue { get; set; }
        public decimal TotalStockValue { get; set; }
        public decimal ClosingStockValue { get; set; }

    }

    public class DailySummary
    {
        public int id { get; set; }
        public DateTime TransDate { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal IncomeAmt { get; set; }
        public decimal ExpenseAmt { get; set; }

        public decimal CashIn { get; set; }
        public decimal CashOut { get; set; }
        public decimal OpeningCashInHand { get; set; }
        public decimal ClosingCashInHand { get; set; }
        public decimal BankBalance { get; set; }
        public decimal CustomerDue { get; set; }
        public decimal CurrentStockValue { get; set; }

        public decimal FixedAssetValue { get; set; }
        public decimal CurrentAssetValue { get; set; }


        public decimal TotalAssetValue { get; set; }
        public decimal SupplierDue { get; set; }
        public decimal Loan { get; set; }
        public decimal DamageProductValue { get; set; }
        public decimal ReturnProductValue { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal ClosingBalance { get; set; }



    }
    public class CustomerDueReportModel
    {
        public DateTime TransDate { get; set; }
        public int CustomerID { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal DueSales { get; set; }
        public decimal InterestAmt { get; set; }
        public decimal TotalSalesAmt { get; set; }
        public decimal RecAmount { get; set; }
        public decimal CollectionAmt { get; set; }
        public string Status { get; set; }
        public decimal Balance { get; set; }
    }
    public class DailyWorkSheetReportModel
    {

        public DateTime Date { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal CashSales { get; set; }
        public decimal DueCollection { get; set; }
        public decimal DownPayment { get; set; }
        public decimal InstallAmt { get; set; }
        public decimal Loan { get; set; }
        public decimal BankWithdrwal { get; set; }
        public decimal Commision { get; set; }
        public decimal OthersIncome { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal DueSales { get; set; }
        public decimal PaidAmt { get; set; }
        public decimal DuePurchase { get; set; }
        public decimal Delivery { get; set; }
        public decimal EmployeeSalary { get; set; }
        public decimal Conveyance { get; set; }
        public decimal BankDeposit { get; set; }
        public decimal LoanPaid { get; set; }
        public decimal Vat { get; set; }
        public decimal OthersExpense { get; set; }
        public decimal SRET { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal ClosingBalance { get; set; }
    }
    public class DailyCashBookLedgerModel
    {
        public DateTime TransDate { get; set; }
        public int id { get; set; }
        public string Expense { get; set; }
        public decimal ExpenseAmt { get; set; }
        public string Income { get; set; }
        public decimal IncomeAmt { get; set; }
        public decimal Module { get; set; }
    }

    public class ProductWiseBenefitReport
    {
        public string Code { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string IMENO { get; set; }
        public decimal SalesTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal NetSales { get; set; }

        public decimal PurchaseTotal { get; set; }
        public decimal CommisionProfit { get; set; }
        public decimal HireProfit { get; set; }
        public decimal HireCollection { get; set; }
        public decimal TotalProfit { get; set; }

    }
    public class CustomerLedger
    {

        public int CustomerID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public int SOrderID { get; set; }

        public decimal Opening { get; set; }
        public decimal CashSales { get; set; }
        public decimal DueSales { get; set; }
        public decimal NetInstallment { get; set; }
        public decimal HireInstallment { get; set; }

        public decimal HirePerInstallment { get; set; }
        public decimal NetPerInstallment { get; set; }
        public decimal TotalPerInsAmt { get; set; }

        public decimal GrandSales { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalSalesAmt { get; set; }
        public decimal TotalDue { get; set; }
        public decimal CollectionAmt { get; set; }
        public decimal TotalRecAmt { get; set; }
        public decimal AdjustAmt { get; set; }
        public decimal Closing { get; set; }



    }


    public class MonthlyBenefit
    {
        public DateTime InvoiceDate { get; set; }
        public decimal SalesTotal { get; set; }
        public decimal PurchaseTotal { get; set; }
        public decimal TDAmount_Sale { get; set; }
        public decimal TDAmount_CreditSale { get; set; }
        public decimal FirstTotalInterest { get; set; }
        public decimal HireCollection { get; set; }
        public decimal CreditSalesTotal { get; set; }
        public decimal CreditPurchase { get; set; }
        public decimal CommisionProfit { get; set; }
        public decimal HireProfit { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal OthersIncome { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal Adjustment { get; set; }
        public decimal LastPayAdjustment { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Benefit { get; set; }

    }



    public class YearlySalesReport
    {
        public DateTime Date { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TDiscount { get; set; }
        public decimal HirPrice { get; set; }
        public decimal NetPrice { get; set; }
        public decimal AdjustAmt { get; set; }
        public decimal PayableAmt { get; set; }
        public decimal ReceiveAmt { get; set; }
        public decimal Due { get; set; }


    }
    public class MonthlySalesReport
    {
        public DateTime Date { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TDiscount { get; set; }
        public decimal HirPrice { get; set; }
        public decimal NetPrice { get; set; }
        public decimal AdjustAmt { get; set; }
        public decimal PayableAmt { get; set; }
        public decimal ReceiveAmt { get; set; }
        public decimal Due { get; set; }


    }
    public class DailyPurchaseReport
    {
        public DateTime OrderDate { get; set; }
        public string ChallanNo { get; set; }
        public string SupplierName { get; set; }
        public decimal GrandTotal { get; set; }

        public decimal NetDiscount { get; set; }

        public decimal NetPurchase { get; set; }
        public decimal AdjustAmt { get; set; }
        public decimal ReceiveAmt { get; set; }
        public decimal Due { get; set; }


    }

    public class DailySalesReport
    {

        public string SalesType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }

        public int CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public decimal GrandTotal { get; set; }

        public decimal TDAmount { get; set; }

        public decimal HirePrice { get; set; }
        public decimal NetSales { get; set; }


        public decimal Adjustment { get; set; }

        public decimal PayableAmt { get; set; }
        public decimal RecAmount { get; set; }
        public decimal Due { get; set; }





    }
    public class DailyReturnReport
    {

        public string SalesType { get; set; }
        public DateTime ReturnDate { get; set; }
        public string InvoiceNo { get; set; }

        public int CusType { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public decimal GrandTotal { get; set; }

        public decimal TDAmount { get; set; }


        public decimal RecAmount { get; set; }
        public decimal Due { get; set; }


    }
    public class DailyReturnReportDetails
    {
        public string SalesType { get; set; }
        public DateTime ReturnDate { get; set; }
        public string InvoiceNo { get; set; }
        public int CusType { get; set; }

        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal UTAmount { get; set; }



    }
    public class BalanceSheet
    {

        public string Asset { get; set; }
        public decimal AssetAmount { get; set; }
        public string Liability { get; set; }
        public decimal LiabilityAmount { get; set; }

    }
    public class DailyPurchaseReportDetails
    {
        public DateTime OrderDate { get; set; }
        public string ChallanNo { get; set; }
        public string SupplierName { get; set; }
        public string ProductName { get; set; }
        public string Categoryname { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TAmount { get; set; }
        public decimal PPDISAmt { get; set; }
        public decimal NetPrice { get; set; }


    }


    public class DailySalesReportDetails
    {
        public int SOrderID { get; set; }
        public string SalesType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }

        public int CustomerID { get; set; }
        public int CusType { get; set; }
        public string CustomerName { get; set; }

        public int ProductType { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

        public string Company { get; set; }
        public string Model { get; set; }
        public int ColorID { get; set; }
        public string Color { get; set; }
        public string IMENO { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal UTAmount { get; set; }
        public decimal PPDAmount { get; set; }
        public decimal HirePrice { get; set; }
        public decimal NetPrice { get; set; }
    }
    public class MonthlyPurchaseReport
    {

        public DateTime Date { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TDiscount { get; set; }
        public decimal NetPurchase { get; set; }
        public decimal AdjustAmt { get; set; }


        public decimal ReceiveAmt { get; set; }
        public decimal Due { get; set; }


    }
    public class YearlyPurchaseReport
    {
        public DateTime Date { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TDiscount { get; set; }

        public decimal NetPurchase { get; set; }
        public decimal AdjustAmt { get; set; }
        public decimal ReceiveAmt { get; set; }
        public decimal Due { get; set; }


    }


    public class CustomerWiseBenefitDetails
    {
        public int CustomerID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }


        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string ProductName { get; set; }
        public decimal SalesAmt { get; set; }

        public decimal PurchaseAmt { get; set; }
        public decimal Profit { get; set; }



    }

    public class CustomerWiseBenefitSummary
    {
        public int CustomerID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public decimal SalesAmt { get; set; }

        public decimal PurchaseAmt { get; set; }
        public decimal Profit { get; set; }
        public decimal InstallmentAmt { get; set; }
        public string Type { get; set; }

    }


    public class DeleteCrediSalesDetails
    {
        public int CustomerID { get; set; }
        public int CreditSalesID { get; set; }
    }

    public class BankLedgerModel
    {

        public int BankID { get; set; }
        public string BankName { get; set; }

        public DateTime TransDate { get; set; }
        public string TransactionNo { get; set; }

        public decimal Opening { get; set; }
        public decimal Deposit { get; set; }
        public decimal Widthdraw { get; set; }
        public decimal CashCollection { get; set; }
        public decimal CashDelivery { get; set; }
        public decimal FundIN { get; set; }
        public decimal FundOut { get; set; }
        public decimal Closing { get; set; }

    }

    public partial class VMReturnDetail
    {
        public int ReturnDetailsID { get; set; }
        public int ReturnID { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UTAmount { get; set; }
        public int SDetailID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Return Return { get; set; }
    }
}
