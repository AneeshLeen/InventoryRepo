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

namespace INVENTORY.UI
{
    public partial class fSendSMS : Form
    {

        public Action ItemChanged;
        DEWSRMEntities db = null;
        public fSendSMS()
        {
            InitializeComponent();
            db = new DEWSRMEntities();
        }
        public void ShowDlg(SMSFormate oSMSFormate, bool IsNew)
        {
            this.ShowDialog();
        }

        #region Events
        private void PopulatCustomerTypeCbo()
        {
            cboCustomerType.DisplayMember = "Name";
            cboCustomerType.ValueMember = "ID";
            cboCustomerType.DataSource = Enum.GetValues(typeof(EnumCustomerType)).Cast<EnumCustomerType>().Select(x => new { ID = (int)x, Name = x.ToString() }).ToList();
        }

        bool IsValid()
        {
            if (txtSMS.TextLength == 0)
            {
                MessageBox.Show("Please enter an SMS", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            if (MessageBox.Show("Do you want to send SMS?", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    IQueryable<Customer> CustomerList = null;

                    if (chkSendToAllCustomer.Checked)
                        CustomerList = db.Customers;
                    else if (ctlCustomer._IDList != null)
                        CustomerList = db.Customers.Where(i => ctlCustomer.IDList.Contains(i.CustomerID));
                    else
                        CustomerList = db.Customers.Where(i => i.CustomerType == (int)cboCustomerType.SelectedValue);

                    List<SMSRequest> smsList = new List<SMSRequest>();
                    SMSRequest sms = null;
                    foreach (var item in CustomerList)
                    {
                        sms = new SMSRequest();
                        sms.CustomerID = item.CustomerID;
                        sms.MobileNo = item.ContactNo;
                        sms.SMS = txtSMS.Text;
                        sms.SMSType = EnumSMSType.Offer;
                        smsList.Add(sms);
                    }

                    var response = await Task.Run(() => SMSHTTPService.SendSMSAsync(EnumtestbdType.NumberSms, smsList, Global.SystemInfo));
                    if (response.Count > 0)
                    {
                        db.SMSStatuses.AddRange(response);
                        db.SaveChanges();
                        MessageBox.Show("Successfully sent SMS: " + response.Where(i => i.SendingStatus == (int)EnumSMSSendStatus.Success).Count() + " ,Failed: " + response.Where(i => i.SendingStatus == (int)EnumSMSSendStatus.Fail).Count(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message, "Failed to send", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ctlCustomer_Load(object sender, EventArgs e)
        {

        }

        private void ctlSMSFormat_SelectedItemChanged(object sender, EventArgs e)
        {
            var SMSFormat = db.SMSFormates.FirstOrDefault(i => i.SMSFormateID == ctlSMSFormat.SelectedID);
            if (SMSFormat != null)
            {
                txtSMS.Text = SMSFormat.SMSDescription;
            }
        }

        private void txtSMS_TextChanged(object sender, EventArgs e)
        {
            lblTotalChar.Text = "Total Char: " + txtSMS.TextLength;
        }

        private void fSendSMS_Load(object sender, EventArgs e)
        {
            PopulatCustomerTypeCbo();
        }

    }
}
