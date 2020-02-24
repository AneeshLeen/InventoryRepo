using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using INVENTORY.DA;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.XtraGrid.Controls;
using Microsoft.Reporting.WinForms;

namespace INVENTORY.UI
{
    public partial class fUserRole : Form
    {

        private UserRole _UserRole = null;
        List<UserRole> _oUserRoles = null;
        public Action ItemChanged;
        DEWSRMEntities db = null;
        public fUserRole()
        {
            InitializeComponent();
        }
        public void ShowDlg()
        {
           
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            db = new DEWSRMEntities();
            FillRoleCbo();
            LoadUserslist();
        }

        private void LoadUserslist()
        {
            if (cboRole.SelectedValue != null)
            {
                _oUserRoles = db.UserRoles.Where(x => x.RoleID == (int)cboRole.SelectedValue).ToList();
                List<User> oUsers = db.Users.Where(x => x.UserType == (int)EnumUserType.Normal).ToList();
                grdUsers.DataSource = oUsers;
                foreach (UserRole item in _oUserRoles)
                {
                    int rowHandle = grdProd.LocateByValue("UserID", item.UserID);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    grdProd.SelectRow(rowHandle);
                }
            }
        }

        private void FillRoleCbo()
        {
            List<Role> oUsers = db.Roles.ToList();
            cboRole.ValueMember = "RoleID";
            cboRole.DisplayMember = "RoleName";
            cboRole.DataSource = oUsers;
        }
        
        List<TreeNode> CheckedNodes(System.Windows.Forms.TreeNodeCollection theNodes)
        {
            List<TreeNode> aResult = new List<TreeNode>();

            if (theNodes != null)
            {
                foreach (TreeNode aNode in theNodes)
                {
                    if (aNode.Checked)
                    {
                        aResult.Add(aNode);
                    }

                    aResult.AddRange(CheckedNodes(aNode.Nodes));
                }
            }

            return aResult;
        }
        private void RefreshObject(List<UserRole> oNewUserRoles,int id)
        {

            foreach (int i in ((GridView)grdUsers.MainView).GetSelectedRows())
            {
                User row = (User)((GridView)grdUsers.MainView).GetRow(i);
               
                _UserRole = new UserRole();
                _UserRole.UserRoleID = id;
                _UserRole.UserID =row.UserID;
                _UserRole.RoleID = Convert.ToInt32(cboRole.SelectedValue);
                oNewUserRoles.Add(_UserRole);
                id++;
            }
        }

        #region Events
        private bool IsValid()
        {
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (!IsValid()) return;
                bool IsNew = false;

                List<UserRole> oNewUserRoles = new List<UserRole>();
                int id = db.UserRoles.Count() > 0 ? db.UserRoles.Max(obj => obj.UserRoleID) + 1 : 1;    
                RefreshObject(oNewUserRoles,id);
                db.UserRoles.AddRange(oNewUserRoles);
                        
                foreach (UserRole item in _oUserRoles)
                {
                    db.UserRoles.Attach(item);
                }
                db.UserRoles.RemoveRange(_oUserRoles);
                db.SaveChanges();

                MessageBox.Show("Data saved successfully.", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!IsNew)
                {
                    if (ItemChanged != null)
                    {
                        ItemChanged();
                    }
                    this.Close();
                }
                else
                {
                    if (ItemChanged != null)
                    {
                        ItemChanged();
                    }
                    _UserRole = new UserRole();
                    RefreshValue();
                        
                }
            } 
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.InnerException.Message, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

       
        private void fUserRole_Load(object sender, EventArgs e)
        {
            //if (_IsNew)
            //    txtName.Text = GenerateUserRoleCode();
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserslist();
        }

    }
}
