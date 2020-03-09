using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.DA
{
    public enum EnumStatus
    {
        Live = 1,
        Discontinue = 2
    }
    public enum EnumSalesType
    { 
        Sales=1,
        Return=2
    }
    public enum EnumSMSType
    {
        SalesTime = 1,
        PurchaseTime = 2,
        CashCollection = 3,
        InstallmentCollection = 4,
        InstallmentAlert = 5,
        Offer = 6,
        Error = 7,
        Registration = 8
    }

    public enum EnumSMSSendStatus
    {
        Success = 1,
        Fail = 2
    }

    public enum EnumtestbdType
    {
        #region Using Username and Password
        OneToOne,
        OneToMany,
        DeliveryStatus,
        GetBalance,
        #endregion

        #region Using API key
        NumberSms,
        ListSms,
        GetCurrentBalance
        #endregion

    }

    public enum EnumPurchaseType
    {
        Purchase = 1,
        Return = 2
    }

    public enum EnumSupplierType
    { 
        Company=1
    }
    public enum EnumCategoryType
    {
        Customer = 1,
        Company=2,
        Product = 3
    }
    public enum EnumTranType
    { 
        ToCompany=1,
        FromCustomer=2
        //BankDeposite=3
    }

    public enum EnumPayType
    { 
        Cash=1,
        Cheque = 2,
        bKash=3,
        MBanking=4,
        Online=5,
        TT=6
    }

    public enum EnumCustomerType
    {
        Retail = 1,
        Dealer = 2
        //Credit=3
    }
    public enum EnumOffer
    { 
        Customer=1,
        Company=2
    }
    //  public enum EnumProType
    //{
    //    PCS=1,
    //    DORZEN=2
    //    //Computer=1,
    //    //C_Accessories=2
    //}
    public enum EnumProductType
    {
        ProductType=3,
        SerialNo=1,
        BarCode=2,
        NoBarCode=3
    }
    
    public enum EnumUserType
    {
        Administrator= 1,
        Normal=2
    
    }
    public enum EnumUserStatus
    { 
        Active=1,
        InActive=2
    }
    public enum EnumStockDetailStatus
    {
        Stock = 1,
        Sold = 2,
        Damage=3
    }
    public enum EnumDataUpload
    {
        Product = 1,
        Customer = 2,
        Supplier = 3,
        Sales_Order = 4,
        Cradit_Sales = 5
    }
    public enum EnumExpenseType
    {
        Expense = 1,
        Income = 2
    }
    public enum EnumUnitType
    {
        PCS = 1,       
        BOX = 2
    }
    //public enum EnumInvestmentType
    //{
    //    FixedAsset = 1,
    //    CurrentAsset = 5,

    //    Loan = 2,
    //    FromOwner = 3,
    //    Others = 4,
    //}

    public enum EnumTransactionType
    {
       Receive=1,
       Pay=2
    }

    public enum EnumLiabilityType
    {        
       // Owner = 4,
       // Others=5
        //ShareHolder = 2,
        //Bank = 3,
        //Assets = 4,
        //Liability = 3
    }

    public enum EnumBankTransType
    {
        Deposit = 1,
        Withdraw = 2,
        CashCollection = 3,
        CashDelivery = 4,
        FundTransfer = 5
    }

    public enum EnumWarrantyType
    {
        Year= 0,
        Months = 1, 
    }

    public enum EnumRemindType
    {  
        Days=1,
        Months = 2,
        Years = 3,
    }
    public enum EnumParentType
    {
        FixedAsset = 2,
        CurrentAsset = 3,
        Liability = 4
    }


    public enum EnumTax
    {
        Zero = 0,
        Five = 5,
        Thirteen = 13
    }

    public enum EnumSalesItemType
    {
        Product = 1,
        Category = 2,
    }
}
