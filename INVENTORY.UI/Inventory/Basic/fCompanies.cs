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
    public partial class fCompanies : Form
    {
        public fCompanies()
        {
            InitializeComponent();
        }

        private void fCompanies_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<Company> _Companys = db.Companies.OrderBy(ex => ex.Code).ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;


                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("CompanyID");

                    if (_Companys != null)
                    {
                        foreach (INVENTORY.DA.Company grd in _Companys)
                        {
                            dr = dt.NewRow();
                            dr["CompanyID"] = grd.CompanyID;
                            dr["Code"] = grd.Code;
                            dr["Name"] = grd.Description;
                            dt.Rows.Add(dr);
                        }

                        grdCompany.DataSource = dt;
                        lblTotal.Text = "Total :" + _Companys.Count().ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fCompany frm = new fCompany();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(new Company(), true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DEWSRMEntities db = new DEWSRMEntities();
            int[] selRows = ((GridView)grdCompany.MainView).GetSelectedRows();
            DataRowView oCompanyID = (DataRowView)(((GridView)grdCompany.MainView).GetRow(selRows[0]));

            int nCompanyID = Convert.ToInt32(oCompanyID["CompanyID"]);
            Company oCompany = db.Companies.FirstOrDefault(p => p.CompanyID == nCompanyID);

            if (oCompany == null)
            {
                MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fCompany frm = new fCompany();
            frm.ItemChanged = RefreshList;
            frm.ShowDlg(oCompany, false);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DEWSRMEntities db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdCompany.MainView).GetSelectedRows();
                DataRowView oCompanyID = (DataRowView)(((GridView)grdCompany.MainView).GetRow(selRows[0]));
                int nCompanyID = Convert.ToInt32(oCompanyID["CompanyID"]);
                Company oCompany = db.Companies.FirstOrDefault(p => p.CompanyID == nCompanyID);

                if (oCompany == null)
                {
                    MessageBox.Show("select an item to delete", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Do you want to delete the selected item?", "Delete Setup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {



                    db.Companies.Attach(oCompany);
                    db.Companies.Remove(oCompany);

                    db.SaveChanges();

                    MessageBox.Show("Data Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshList();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Cannot delete item due to " + Ex.Message);
            }

        }
        private void grdCompany_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }        
    }
}
