using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace INVENTORY.UI
{
    public partial class fBackUpDB : Form
    {
        string sCommand = string.Empty;
        string DataBase = string.Empty;
        string ConnString = string.Empty;
        string sFileName = string.Empty;
        public fBackUpDB()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DataBase = ConfigurationManager.AppSettings["DB"];
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    return;
                }
                sFileName = txtFilePath.Text + @"\" +DataBase+ "-" + Convert.ToDateTime(dtpSysteDate.Value).ToString("dd MMMM yyyy") + ".Bak";
                sCommand = @"backup database " + DataBase + " to disk ='" + sFileName + "' with init,stats=10";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackUpDB_Click(object sender, EventArgs e)
        {
            try
            {
                #region DB Back Up                
                SqlConnection ob = new SqlConnection(ConnString);
                ob.Open();
                SqlCommand cmd = new SqlCommand(sCommand, ob);
                cmd.ExecuteNonQuery();
                ob.Close();
                MessageBox.Show("Successfully Data Base Back Up.", "Back Up DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBackUpDB.Enabled = false;

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void fBackUpDB_Load(object sender, EventArgs e)
        {
            ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["backupDB"].ConnectionString;
        }
    }
}
