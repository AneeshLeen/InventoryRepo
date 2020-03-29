using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using INVENTORY.DA;


namespace INVENTORY.UI
{
    public partial class fLogIn : Form
    {
        string myServer = string.Empty;
        string appMyServer = string.Empty;

        public fLogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                DateTime dTExpireDate = new DateTime(2017,1,10);
                DateTime dTillDate=DateTime.Now;

                var NoOfDays = dTExpireDate - dTillDate;
                double Days = NoOfDays.Days;

                //if (DateTime.Today > new DateTime(2017, 4, 30))
                //{
                //    MessageBox.Show("Validity period of your system has expired. Please contact with BD Technology.", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //else if((dTExpireDate.Day-dTillDate.Day)<=20)
                //{
                //    MessageBox.Show("Your Validity period of your system has expired date of "+ dTExpireDate+ ". Please contact with BD Technology.", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //return;
                //}

                if (txtLoginID.Text == "" || txtPassword.Text == "")
                {
                    lblError.Text = "Please Enter LoginID and Password...";
                }
                else
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        User oUser = db.Users.FirstOrDefault(o => o.UserName == txtLoginID.Text);
                        //var oUser= UserService.Get(txtLoginID.Text, true);

                        if (oUser == null)
                        {
                            lblError.Text = "Invalid LoginID";
                        }
                        else if (oUser.UserPassword != txtPassword.Text)
                        {
                            lblError.Text = "Invalid Password";
                        }
                        else
                        {
                            #region Check Server

                            myServer = Environment.MachineName;
                            appMyServer =ConfigurationManager.AppSettings["Server"];
                            //appMyServer = CryptorEngine.Decrypt(appMyServer.Trim(),true);
                            #endregion

                            if (myServer.Trim().ToUpper() == appMyServer.Trim().ToUpper())
                            {
                                

                                if (oUser.UserType == (int)EnumUserType.Administrator)
                                {
                                    frmBranchMaster frmbranchbaster = new frmBranchMaster();
                                    //oFMainForm.lblUser.Text = txtLoginID.Text;

                                    Global.CurrentUser = oUser;
                                    //FNewMainForm oFMainForm = new FNewMainForm();
                                    ////FMainForm oFMainForm = new FMainForm();
                                    //oFMainForm.lblUser.Text = txtLoginID.Text;
                                    //Global.CurrentUser = oUser;
                                    //oFMainForm.ShowDialog();


                                    frmbranchbaster.ShowDialog();
                                    frmbranchbaster.Close();
                                }
                                else
                                {
                                    //
                                    
                                    Global.CurrentUser = oUser; 
                                    fSOrder fssale = new fSOrder();
                                    fssale.FormBorderStyle = FormBorderStyle.FixedSingle;
                                    fssale.strsales.Visible = true;
                                    fssale.LoadDefaultData(new SOrder());
                                    fssale.Show();

                                }
                                //
                                this.Close();
                                this.Hide();
                                this.Dispose();
                                DialogResult = DialogResult.OK;
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Please Check Server", "Server Problem", MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
