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
    public partial class fMenuPermission : Form
    {
        
        private MenuPermission _MenuPermission = null;
        List<MenuPermission> _oMenuPermissions = null;
        private Role _oRole = null;
        public Action ItemChanged;
        bool _IsNew = false;
        public fMenuPermission()
        {
            InitializeComponent();
        }
        public void ShowDlg(Role oRole,bool IsNew)
        {
            _IsNew = IsNew;
            _oRole = oRole;
            lblRoleName.Text = ": " + oRole.RoleName;
            RefreshValue();
            this.ShowDialog();
        }

        private void RefreshValue()
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
               
                _oMenuPermissions = db.MenuPermissions.Where(x=>x.RoleID==_oRole.RoleID).ToList();
                List<INVENTORY.DA.Menu> oMenus = db.Menus.Where(x => x.MenuType == 1).ToList();
                FillNode(oMenus, null,tvwMenu);
                oMenus = db.Menus.Where(x => x.MenuType == 2).ToList();
                FillNode(oMenus, null, tvwButton);
               
            }
            //txtDescription.Text = _MenuPermission.Description;
            //txtName.Text = _MenuPermission.MenuPermissionName;
        }
        private void FillNode(List<INVENTORY.DA.Menu> items, TreeNode node,TreeView tree)
        {
           
            int parentID = node != null
                ? (int)node.Tag
                : 0;
            
            var nodesCollection = node != null
                ? node.Nodes
                : tree.Nodes;

            foreach (var item in items.Where(i => i.ParentID == parentID))
            {
                var newNode = nodesCollection.Add(item.MenuKey, item.Description);
                newNode.Tag = item.MenuID;
                newNode.Checked = (_oMenuPermissions.Any(x => x.MenuID == item.MenuID));
                FillNode(items, newNode, tree);
            }
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
        private void RefreshObject(List<MenuPermission> oNewMenuPermissions,int id)
        {
          
            foreach (TreeNode item in CheckedNodes(tvwMenu.Nodes))
            {
                if (item.Checked)
                {
                    _MenuPermission = new MenuPermission();
                    _MenuPermission.MenuPermissionID = id;
                    _MenuPermission.MenuID = (int)item.Tag;
                    _MenuPermission.RoleID = _oRole.RoleID;
                    oNewMenuPermissions.Add(_MenuPermission);
                    id++;
                }
               
            }
            foreach (TreeNode item in CheckedNodes(tvwButton.Nodes))
            {
                if (item.Checked)
                {
                    _MenuPermission = new MenuPermission();
                    _MenuPermission.MenuPermissionID = id;
                    _MenuPermission.MenuID = (int)item.Tag;
                    _MenuPermission.RoleID = _oRole.RoleID;
                    oNewMenuPermissions.Add(_MenuPermission);
                    id++;
                }

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

                using (DEWSRMEntities db = new DEWSRMEntities())
                {                                         
                    List<MenuPermission> oNewMenuPermissions = new List<MenuPermission>();
                    int id = db.MenuPermissions.Count() > 0 ? db.MenuPermissions.Max(obj => obj.MenuPermissionID) + 1 : 1;    
                    RefreshObject(oNewMenuPermissions,id);
                    db.MenuPermissions.AddRange(oNewMenuPermissions);
                        
                    foreach (MenuPermission item in _oMenuPermissions)
                    {
                        db.MenuPermissions.Attach(item);
                    }
                    db.MenuPermissions.RemoveRange(_oMenuPermissions);
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
                        _MenuPermission = new MenuPermission();
                        RefreshValue();
                        
                    }
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
        
        private void fMenuPermission_Load(object sender, EventArgs e)
        {
            //if (_IsNew)
            //    txtName.Text = GenerateMenuPermissionCode();
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
