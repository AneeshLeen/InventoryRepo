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
    public partial class fUsers : Form
    {

        public fUsers()
        {
            InitializeComponent();
        }

        private void fUsers_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Users = db.Users.Where(x=>x.UserType==(int)EnumUserType.Normal).ToList();

                    ListViewItem item = null;
                    lsvUsers.Items.Clear();
                    List<UserRole> oUserRoles = db.UserRoles.ToList();
                     List<Role> oRoles = db.Roles.ToList();
                    List<UserRole> oUserRolestemp = null;
                    if (_Users != null)
                    {
                        foreach (User oUItem in _Users)
                        {
                            oUserRolestemp = oUserRoles.Where(x => x.UserID == oUItem.UserID).ToList();
                            string rols = "";
                            if (oUserRolestemp.Count>0)
                            {
                                foreach (var r in oUserRolestemp)
                                {
                                   rols=rols+oRoles.FirstOrDefault(x => x.RoleID == r.RoleID).RoleName+","; 
                                }

                            }
                            item = new ListViewItem();
                            item.Text = oUItem.UserName;
                            item.SubItems.Add(oUItem.ContactNo);
                            item.SubItems.Add(rols.Trim(','));

                            if (oUItem.Status == (int)EnumUserStatus.Active)
                            {
                                item.SubItems.Add("Active");
                            }
                            else
                            {
                                item.SubItems.Add("InActive");
                            }
                            
                            item.Tag = oUItem;
                            lsvUsers.Items.Add(item);
                        }
                    }
                    lblTotal.Text = "Total :" + _Users.Count().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                fUser frm = new fUser();
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(new User());

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvUsers.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                User oUser = null;
                fUser frm = new fUser();

                if (lsvUsers.SelectedItems != null && lsvUsers.SelectedItems.Count > 0)
                {
                    oUser = (User)lsvUsers.SelectedItems[0].Tag;
                }
                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                User oUser = new User();
                if (lsvUsers.SelectedItems != null && lsvUsers.SelectedItems.Count > 0)
                {
                    oUser = (User)lsvUsers.SelectedItems[0].Tag;
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DEWSRMEntities db = new DEWSRMEntities())
                        {
                            db.Users.Attach(oUser);
                            db.Users.Remove(oUser);
                            db.SaveChanges();
                            RefreshList();
                        }
                    }
                }

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

        private void btnActive_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvUsers.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                User oUser = null;
                fUser frm = new fUser();

                if (lsvUsers.SelectedItems != null && lsvUsers.SelectedItems.Count > 0)
                {
                    oUser = (User)lsvUsers.SelectedItems[0].Tag;
                }

                //if(btnActive.Text=="Active")
                //{
                
                //}

                frm.ItemChanged = RefreshList;
                frm.ShowDlg(oUser);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lsvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            fUserRole frm = new fUserRole();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg();
        }
    }
}
