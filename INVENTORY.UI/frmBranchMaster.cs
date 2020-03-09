using INVENTORY.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace INVENTORY.UI
{
    public partial class frmBranchMaster : Form
    {
        public DataTable Branchlist = new DataTable();
        //private blBranch objBranch = new blBranch();
        public long BranchId;
        public string BranchName;
        public frmBranchMaster()
        {
            InitializeComponent();
            LoadDatatable();
        }

        internal DataTable ReadAllbranches()
        {
            string SQLServer = ConfigurationManager.AppSettings["SqlServer"];

            DataTable dtbranches = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data Source=" + SQLServer + ";Initial Catalog=INVENTORY;Persist Security Info=True;Integrated Security=true");
            SqlCommand command = new SqlCommand("select * from branchmaster", connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(dtbranches);
            return dtbranches;
        }

        private void LoadDatatable()
        {
            Branchlist = ReadAllbranches();
        }

        private void frmBranchMaster_Load(object sender, EventArgs e)
        {
            LoadTree();
           
        }

        private void LoadTree()
        {
          
            foreach (DataRow row in Branchlist.Rows)
            {
                if (Convert.ToInt64( row["parentid"]) == 0)
                {
                    TreeNode tnParent = new TreeNode();
                    tnParent.Text = row["branchname"].ToString();
                    tnParent.Tag = row["Id"].ToString();
                    long value = (long)row["Id"];
                    tnParent.Expand();
                    tvBranches.Nodes.Add(tnParent);
                    FillChild(tnParent, value);
                }
                
            }
        }

        private void FillChild(TreeNode tnParent, long value)
        {
            foreach (DataRow row in Branchlist.Rows)
            {
                if (Convert.ToInt64(row["parentid"]) == value)
                {
                    TreeNode child = new TreeNode();
                    child.Text = row["branchname"].ToString();
                    
                    long temp = (long)row["Id"];
                    child.Tag = temp;
                    child.Collapse();
                    tnParent.Nodes.Add(child);
                    FillChild(child, temp);
                }
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        FNewMainForm oFMainForm = null;
        //string value4 = (string)value2;
        private void btnapply_Click(object sender, EventArgs e)
        {
           
            FormCollection fc = Application.OpenForms;
            bool bFormNameOpen = false;
            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "FNewMainForm")
                {
                    bFormNameOpen = true;
                    oFMainForm = (FNewMainForm)frm;
                }
            }

          
                if (tvBranches.SelectedNode != null)
                {
                    if (!bFormNameOpen)
                    {
                     
                        oFMainForm = new FNewMainForm();
                        this.BranchName = tvBranches.SelectedNode.Text;
                        this.BranchId = Convert.ToInt64(tvBranches.SelectedNode.Tag);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();


                        //FMainForm oFMainForm = new FMainForm();    
                        oFMainForm.lblUser.Text = Global.CurrentUser.UserName.ToString();
                        oFMainForm.ToolStripStatusLabel3.Text = tvBranches.SelectedNode.Text;

                        this.Close();
                        this.Hide();
                        DialogResult = DialogResult.OK;
                        this.Close();
                        oFMainForm.ShowDialog();
                        //this.Close();
                        //this.Hide();
                    

                    }
                    else
                    {
                        oFMainForm.ToolStripStatusLabel3.Text = tvBranches.SelectedNode.Text;
                        this.Close();
                        this.Hide();
                    }

                    DialogResult = DialogResult.OK;
            }

        }
    }
}
