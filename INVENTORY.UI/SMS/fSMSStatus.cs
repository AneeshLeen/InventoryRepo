using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVENTORY.DA;
using DevExpress.XtraGrid.Views.Grid;

namespace INVENTORY.UI
{
    public partial class fSMSStatus : Form
    {
        DEWSRMEntities db = null;
        List<SMSFormate> _SMSFormatList = null;
        List<Customer> _CustomerList = null;

        public fSMSStatus()
        {

            InitializeComponent();
        }
        private void fSMSStatus_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("ID");
            dt.Columns.Add("Code");
            dt.Columns.Add("SDate");
            dt.Columns.Add("SMS");
            dt.Columns.Add("STO");
            dt.Columns.Add("Status");

            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    _SMSFormatList = db.SMSFormates.ToList();
                    _CustomerList = db.Customers.ToList();
                    var _SMSStatus = db.SMSStatuses;
                    Customer oCustomer = null;
                    SMSFormate oSMSFormate = null;
                    foreach (SMSStatus oSMSStatus in _SMSStatus)
                    {
                        oCustomer = _CustomerList.FirstOrDefault(p => p.CustomerID == oSMSStatus.CustomerID);
                        oSMSFormate = _SMSFormatList.FirstOrDefault(p => p.SMSFormateID == oSMSStatus.SMSFormateID);

                        dr = dt.NewRow();
                        dr["ID"] = oSMSStatus.SMSStatusID;
                        dr["Code"] = oSMSStatus.Code;
                        dr["SDate"] = oSMSStatus.EntryDate.ToString("dd MMM yyyy");
                        if (oSMSFormate != null)
                            dr["SMS"] = oSMSFormate.SMSDescription;
                        if (oCustomer != null)
                            dr["STO"] = oCustomer.Name;

                        if (oSMSStatus.SendingStatus == (int)EnumSMSSendStatus.Success)
                            dr["Status"] = "Success";
                        else
                            dr["Status"] = "Fail";

                        dt.Rows.Add(dr);
                    }
                    grdSMS.DataSource = dt;
                    label2.Text = "Total :" + _SMSStatus.Count().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
