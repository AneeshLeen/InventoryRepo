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
    public partial class fRoles : Form
    {
        public fRoles()
        {
            InitializeComponent();
        }
        private void fRoles_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Roles = db.Roles;
                    List<Role> oRoleList = _Roles.OrderBy(m => m.RoleName).ToList();

                    ListViewItem item = null;
                     lsvRole.Items.Clear();

                    if (_Roles != null)
                    {
                        foreach (Role grd in oRoleList)
                        {
                            item = new ListViewItem();
                            item.Text = grd.RoleName;
                            item.SubItems.Add(grd.Description);
                            item.Tag = grd;
                            lsvRole.Items.Add(item);
                        }

                        lblTotal.Text = "Total :" + _Roles.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            fRole frm = new fRole();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Role(),true);
           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lsvRole.SelectedItems.Count <= 0)
            {
                MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Role Role = null;
            fRole frm = new fRole();

            if (lsvRole.SelectedItems != null && lsvRole.SelectedItems.Count > 0)
            {
                Role = (Role)lsvRole.SelectedItems[0].Tag;
            }
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(Role,false);
           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Role oRole = new Role();
                if (lsvRole.SelectedItems != null && lsvRole.SelectedItems.Count > 0)
                {
                    oRole = (Role)lsvRole.SelectedItems[0].Tag;
                    if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DEWSRMEntities db = new DEWSRMEntities())
                        {
                            db.Roles.Attach(oRole);
                            db.Roles.Remove(oRole);
                            //Save to database
                            db.SaveChanges();
                        }
                        RefreshList();
                    } 
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }
        }
        #endregion

        private void txtSearchRole_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchRole.Text != "")
                {
                    foreach (ListViewItem item in lsvRole.Items)
                    {
                        if (item.SubItems[2].Text.ToLower().Contains(txtSearchRole.Text.ToLower()))
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            lsvRole.Items.Remove(item);
                        }
                        item.Selected = false;
                    }
                    if (lsvRole.SelectedItems.Count == 1)
                    {
                        lsvRole.Focus();
                    }
                }
                else
                {
                    RefreshList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lsvRole_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnMenuPermission_Click(object sender, EventArgs e)
        {
            if (lsvRole.SelectedItems.Count <= 0)
            {
                MessageBox.Show("select an item for Menu Permission", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Role Role = null;
            fMenuPermission frm = new fMenuPermission();

            if (lsvRole.SelectedItems != null && lsvRole.SelectedItems.Count > 0)
            {
                Role = (Role)lsvRole.SelectedItems[0].Tag;
            }
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(Role, false);
        }
       
    }
}
