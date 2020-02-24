using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ESRP.DA;


namespace ESRP.UI
{
    public partial class fSupplierDueRpt : Form
    {
        public fSupplierDueRpt()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    List<Supplier> oSuppliers = null;

                    if(ctlSupplier.SelectedID>0)
                    {
                        oSuppliers=db.Suppliers.Where(s=>s.SupplierID==ctlSupplier.SelectedID).ToList();
                    }
                    else
                    {
                        oSuppliers = db.Suppliers.ToList();
                    }

                    if (oSuppliers != null)
                    {
                        rptDataSet.dtSupplierDataTable dt = new rptDataSet.dtSupplierDataTable();
                        DataSet ds = new DataSet();

                        foreach (Supplier grd in oSuppliers)
                        {
                            if (grd.TotalDue > 0)
                            {
                                dt.Rows.Add(grd.Code, grd.Name, grd.OwnerName, grd.ContactNo, grd.Address, grd.TotalDue);
                            }
                        }

                        dt.TableName = "rptDataSet_dtSupplier";
                        ds.Tables.Add(dt);
                        string embededResource = "ESRP.UI.RDLC.rptSupplier.rdlc";
                        ReportParameter rParam = new ReportParameter();
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                        parameters.Add(rParam);
                        fReportViewer frm = new fReportViewer();

                        if (dt.Rows.Count > 0)
                        {
                            frm.CommonReportViewer(embededResource, ds, parameters, true);
                        }
                        else
                        {
                            MessageBox.Show("No Recors Found.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        ctlSupplier.SelectedID = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ctlSupplier_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void fSupplierDueRpt_Load(object sender, EventArgs e)
        {

        }
    }
}
