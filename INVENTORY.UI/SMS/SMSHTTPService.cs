using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.DA;
using System.Net.Http;
using Jil;
using System.IO;
namespace INVENTORY.UI
{
    public static class SMSHTTPService
    {

        public static async Task<List<SMSStatus>> SendSMSAsync(EnumtestbdType smsType, List<SMSRequest> smsList, SystemInformation sysInfo)
        {
            return await Task.Run(() => SendSMS(smsType, smsList, sysInfo));
        }
        private static List<SMSStatus> SendSMS(EnumtestbdType smsType, List<SMSRequest> smsList, SystemInformation sysInfo)
        {
            List<SMSStatus> smsResponses = new List<SMSStatus>();
            if (sysInfo.SMSServiceEnable == 0)
                return smsResponses;

            StringBuilder SMS = new StringBuilder();
            string result = string.Empty;
            string MobileNo = string.Empty;
            string BASE_URL = string.Empty;

            int Counter = 0, Length = 0; ;

            HttpResponseMessage response;
            try
            {
                switch (smsType)
                {
                    #region One To One username and password
                    case EnumtestbdType.OneToOne:
                        #region URL
                        //https://api2.testbd.com/HttpSendSms.ashx?op=OneToOne&type=TEXT&mobile=01738474602
                        //&smsText=Your Text&username=username&password=password&maskName=&campaignName=
                        #endregion
                        var SMSInfo = smsList.FirstOrDefault();

                        if (SMSInfo != null)
                        {
                            MobileNo = SMSInfo.MobileNo;
                            //SMS.Append(sysInfo.Name + Environment.NewLine);
                            if (SMSInfo.SMSType == EnumSMSType.CashCollection)
                            {
                                SMS.Append("Date: " + Global.DateddMMMYYYY(SMSInfo.Date) + Environment.NewLine);
                                SMS.Append("A/C No: " + SMSInfo.CustomerCode + Environment.NewLine);
                                SMS.Append("Pre. Due: " + SMSInfo.PreviousDue + Environment.NewLine);
                                SMS.Append("Receive Amt: " + SMSInfo.ReceiveAmount + Environment.NewLine);
                                SMS.Append("Present Due: " + SMSInfo.PresentDue + Environment.NewLine);
                            }
                            else if (SMSInfo.SMSType == EnumSMSType.SalesTime)
                            {
                                string ProductName = string.Join(",", SMSInfo.ProductNameList);
                                SMS.Append("Dear Sir," + Environment.NewLine + "you are welcome to buy a Honda Motorcycle," + Environment.NewLine);
                                SMS.Append("Date: " + Global.DateddMMMYYYY(SMSInfo.Date) + Environment.NewLine);
                                SMS.Append("A/C No: " + SMSInfo.CustomerCode + Environment.NewLine);
                                SMS.Append("Model: " + ProductName + Environment.NewLine);
                                SMS.Append("Price: " + SMSInfo.SalesAmount + Environment.NewLine);
                                //SMS.Append("Pre. Due: " + SMSInfo.PreviousDue + Environment.NewLine);
                                SMS.Append("Today Payment: " + SMSInfo.ReceiveAmount + Environment.NewLine);
                                SMS.Append("Present Due: " + SMSInfo.PresentDue + Environment.NewLine);
                                //SMS.Append("Paid Date: " + SMSInfo.PresentDue + Environment.NewLine);
                            }
                            else if (SMSInfo.SMSType == EnumSMSType.InstallmentCollection)
                            {
                                SMS.Append("Date: " + Global.DateddMMMYYYY(SMSInfo.Date) + Environment.NewLine);
                                SMS.Append("A/C No: " + SMSInfo.CustomerCode + Environment.NewLine);
                                SMS.Append("Installment: " + SMSInfo.ReceiveAmount + Environment.NewLine);
                                SMS.Append("Cash to Date: " + SMSInfo.TotalReceiveAmount + Environment.NewLine);
                                SMS.Append("Remaining: " + SMSInfo.PresentDue + Environment.NewLine);
                            }
                            else if (SMSInfo.SMSType == EnumSMSType.Registration)
                            {
                                MobileNo = sysInfo.InsuranceContactNo;
                                SMS.Append(SMSInfo.CustomerName + ", S/O ");
                                SMS.Append(SMSInfo.CustomerFatherName + ", ");
                                SMS.Append(SMSInfo.CustomerAddress + "." + Environment.NewLine);
                                string EngineNo = string.Empty;
                                string ChasisNo = string.Empty;
                                foreach (var item in SMSInfo.ProductDetailList)
                                {
                                    EngineNo = item.EngineNo.Length >= 7 ? item.EngineNo.Substring(item.EngineNo.Length - 7) : item.EngineNo; //Take Last 7 Digits
                                    ChasisNo = item.ChasisNo.Length >= 6 ? item.ChasisNo.Substring(item.ChasisNo.Length - 6) : item.ChasisNo;//Take Last 6 Digits
                                    SMS.Append(item.ProductName + ", " + item.ColorName + ", EN-" + EngineNo + ", CH-" + ChasisNo + Environment.NewLine);
                                }
                            }
                            SMS.Append("Thank you." + Environment.NewLine + sysInfo.Name);
                        }


                        BASE_URL = new Uri(Global.TESTBD_BASE_URL + "op=" + smsType + "&type=TEXT").ToString();

                        response = new HttpClient().GetAsync(BASE_URL + "&mobile=" + MobileNo + "&smsText=" + SMS + "&username=" + Global.TESTBD_UserName + "&password=" + Global.TESTBD_Password + "&maskName=&campaignName=").Result;
                        result = response.Content.ReadAsStringAsync().Result;
                        //var obj = JObject.Parse(result);
                        #region response
                        //Success response: 1900||01762125041||100782732/
                        #endregion

                        if (result != null)
                        {
                            var smsResponse = new SMSStatus();
                            smsResponse.Code = result.Substring(0, result.IndexOf("||"));
                            smsResponse.SMSFormateID = (int)SMSInfo.SMSType;
                            smsResponse.NoOfSMS = SMSCounter(SMS.ToString());
                            smsResponse.ResponseMsg = result;
                            smsResponse.SMS = SMS.ToString();
                            smsResponse.CreatedDate = DateTime.Now;
                            smsResponse.EntryDate = DateTime.Today;
                            smsResponse.CreatedBy = Global.CurrentUser.UserID;
                            smsResponse.CustomerID = SMSInfo.CustomerID;
                            smsResponse.ContactNo = MobileNo;
                            if (smsResponse.Code.Equals("1900"))
                                smsResponse.SendingStatus = (int)EnumSMSSendStatus.Success;
                            else
                                smsResponse.SendingStatus = (int)EnumSMSSendStatus.Fail;
                            smsResponses.Add(smsResponse);
                        }
                        break;
                    #endregion

                    #region One to Many API
                    case EnumtestbdType.NumberSms: //One to Many API
                        #region URL
                        // https://api2.testbd.com/HttpSendSms.ashx?op=NumberSms&apiKey=ApiKey&type=TEXT
                        //&mobile=01738474602, 01738474602&smsText=YourText&maskName=&campaignName= 
                        #endregion
                        if (smsList.Count() == 0)
                            return smsResponses;

                        foreach (var item in smsList)
                        {
                            Counter++;
                            if (smsList.Count != Counter)
                                MobileNo = MobileNo + item.MobileNo + ",";
                            else
                                MobileNo = MobileNo + item.MobileNo;
                        }
                        SMSInfo = smsList.FirstOrDefault();
                        SMS.Append(SMSInfo.SMS);
                        SMS.Append("Thank you." + Environment.NewLine + sysInfo.Name);

                        BASE_URL = new Uri(Global.TESTBD_BASE_URL + "op=" + smsType + "&apiKey=" + Global.TESTBD_APIKEY + "&type=TEXT").ToString();

                        response = new HttpClient().PostAsync(BASE_URL + "&mobile=" + MobileNo + "&smsText=" + SMS + "&maskName=&campaignName=", null).Result;
                        result = response.Content.ReadAsStringAsync().Result;
                        //var obj = JObject.Parse(result);
                        //Response: 1900||01714||39.../1900||017...||39.../
                        if (result != null)
                        {
                            string[] IndividulsResponse = result.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < IndividulsResponse.Length; i++)
                            {
                                var smsResponse = new SMSStatus();

                                smsResponse.Code = IndividulsResponse[i].Substring(0, IndividulsResponse[i].IndexOf("||"));
                                Length = (IndividulsResponse[i].LastIndexOf("||") - IndividulsResponse[i].IndexOf("||")) - 2;
                                MobileNo = IndividulsResponse[i].Substring(IndividulsResponse[i].IndexOf("||") + 2, Length);
                                SMSInfo = smsList.FirstOrDefault(c => c.MobileNo.Contains(MobileNo.Trim()));

                                smsResponse.SMSFormateID = (int)SMSInfo.SMSType;
                                smsResponse.NoOfSMS = SMSCounter(SMS.ToString());
                                smsResponse.ResponseMsg = IndividulsResponse[i];
                                smsResponse.SMS = SMS.ToString();
                                smsResponse.CreatedDate = DateTime.Now;
                                smsResponse.EntryDate = DateTime.Today;
                                smsResponse.CreatedBy = Global.CurrentUser.UserID;
                                smsResponse.CustomerID = SMSInfo.CustomerID;
                                smsResponse.ContactNo = MobileNo;
                                if (smsResponse.Code.Equals("1900"))
                                    smsResponse.SendingStatus = (int)EnumSMSSendStatus.Success;
                                else
                                    smsResponse.SendingStatus = (int)EnumSMSSendStatus.Fail;
                                smsResponses.Add(smsResponse);
                            }

                        }
                        break;
                    #endregion

                    #region Many to Many API
                    case EnumtestbdType.ListSms: //Many to Many API
                        #region URL
                        //https://api2.testbd.com/HttpSendSms.ashx?op=ListSms&apiKey=ApiKey&type=TEXT
                        //&smsListJson=[{"MobileNumber":"01738474602","SmsText":"Individual List SMS is ok","Type":"TEXT"},{"MobileNumber":"0180000000","SmsText":"Individual List SMS2 is ok","Type":"TEXT"}]&maskName=&campaignName=
                        #endregion

                        if (smsList.Count == 0)
                            return smsResponses;

                        var jsonList = from sms in smsList
                                       select new
                                       {
                                           MobileNumber = sms.MobileNo,
                                           SmsText = "Dear Mr./Mrs. " + sms.CustomerName + "," + Environment.NewLine + "your due payment Date is " + Global.DateddMMMYYYY(sms.Date) + " and due amout is " + sms.PresentDue + ". Thank you." + Environment.NewLine + sysInfo.Name,
                                           Type = "TEXT"
                                       };

                        using (var output = new StringWriter())
                        {
                            JSON.SerializeDynamic(jsonList, output);
                            SMS.Append(output.ToString());
                        }

                        BASE_URL = new Uri(Global.TESTBD_BASE_URL + "op=" + smsType + "&apiKey=" + Global.TESTBD_APIKEY + "&type=TEXT").ToString();

                        response = new HttpClient().PostAsync(BASE_URL + "&smsListJson=" + SMS + "&maskName=&campaignName=", null).Result;
                        result = response.Content.ReadAsStringAsync().Result;
                        Length = 0;
                        if (result != null)
                        {
                            string[] IndividulsResponse = result.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < IndividulsResponse.Length; i++)
                            {
                                var smsResponse = new SMSStatus();

                                smsResponse.Code = IndividulsResponse[i].Substring(0, IndividulsResponse[i].IndexOf("||"));

                                Length = (IndividulsResponse[i].LastIndexOf("||") - IndividulsResponse[i].IndexOf("||")) - 2;
                                MobileNo = IndividulsResponse[i].Substring(IndividulsResponse[i].IndexOf("||") + 2, Length);

                                SMSInfo = smsList.FirstOrDefault(c => c.MobileNo.Contains(MobileNo.Trim()));
                                smsResponse.SMS = jsonList.FirstOrDefault(c => c.MobileNumber.Contains(MobileNo.Trim())).SmsText;
                                smsResponse.SMSFormateID = (int)SMSInfo.SMSType;
                                smsResponse.NoOfSMS = SMSCounter(smsResponse.SMS);
                                smsResponse.ResponseMsg = IndividulsResponse[i];
                                smsResponse.CreatedDate = DateTime.Now;
                                smsResponse.EntryDate = DateTime.Today;
                                smsResponse.CreatedBy = Global.CurrentUser.UserID;
                                smsResponse.CustomerID = SMSInfo.CustomerID;
                                smsResponse.ContactNo = MobileNo;
                                if (smsResponse.Code.Equals("1900"))
                                    smsResponse.SendingStatus = (int)EnumSMSSendStatus.Success;
                                else
                                    smsResponse.SendingStatus = (int)EnumSMSSendStatus.Fail;
                                smsResponses.Add(smsResponse);
                            }

                        }
                        break;
                    #endregion

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                var smsResponse = new SMSStatus();
                smsResponse.Code = "0000";
                smsResponse.ResponseMsg = ex.Message;
                smsResponse.SMSFormateID = (int)EnumSMSType.Error;
                smsResponse.NoOfSMS = 0;
                smsResponse.SMS = SMS.ToString();
                smsResponse.CreatedDate = DateTime.Now;
                smsResponse.EntryDate = DateTime.Today;
                smsResponse.CreatedBy = Global.CurrentUser.UserID;
                smsResponse.ContactNo = MobileNo;
                smsResponse.CustomerID = 0;
                smsResponse.SendingStatus = (int)EnumSMSSendStatus.Fail;
                smsResponses.Add(smsResponse);
                return smsResponses;
            }

            return smsResponses;
        }


        static int SMSCounter(string SMS)
        {
            int Counter = 0;
            decimal temp = (decimal)SMS.Length / 160;  //2.377
            string strTemp = temp.ToString();
            int Interger_digit = 0, Fractional_digit = 0;
            Interger_digit = Convert.ToInt32(strTemp.Substring(0, strTemp.IndexOf(".")));
            Fractional_digit = Convert.ToInt32(strTemp.Substring(strTemp.IndexOf(".") + 1));
            Counter = Interger_digit + (Fractional_digit == 0 ? 0 : 1);
            return Counter;
        }
    }
}
