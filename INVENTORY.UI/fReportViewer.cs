using INVENTORY.DA;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class fReportViewer : Form
    {
        List<ReportParameter> _ReportParameters = new List<ReportParameter>();
        string _PATH = string.Empty;
        public fReportViewer()
        {
            InitializeComponent();
        }

        private void fReportViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void ShowDlg(DataSet ds, string embeddedResource,List<ReportDataSource> reportData)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = embeddedResource;
            reportViewer1.LocalReport.DataSources.Clear();
            //Microsoft.Reporting.WinForms.ReportDataSource rptData = new Microsoft.Reporting.WinForms.ReportDataSource("rptData", ds.Tables[0]);
            foreach (ReportDataSource item in reportData)
            {
                reportViewer1.LocalReport.DataSources.Add(item);
            }
            
            reportViewer1.RefreshReport();
            this.ShowDialog();
        }
        public void CommonReportViewer(string RDLC, DataSet dSet, List<ReportParameter> parameters, bool isBasicParametersNeeded)
        {
            reportViewer1.Refresh();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.EnableExternalImages = true;
            try
            {
                if (dSet != null && dSet.Tables.Count > 0)
                {
                    foreach (DataTable table in dSet.Tables)
                    {
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(table.TableName, table));
                    }
                }

                reportViewer1.LocalReport.ReportEmbeddedResource = RDLC;
                _ReportParameters = parameters;

                if (isBasicParametersNeeded)
                    GetBasicParameters();


                if (_ReportParameters != null)
                    reportViewer1.LocalReport.SetParameters(_ReportParameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            this.ShowDialog();
        }

        
        private void GetBasicParameters()
        {


            INVENTORY.DA.SystemInformation sysinfo = null;
            ReportParameter rParam = new ReportParameter();
            using (DEWSRMEntities db = new DEWSRMEntities())
            {


                sysinfo = (from c in db.SystemInformations
                           where c.SystemInfoID == 1
                           select c).FirstOrDefault();

                if (sysinfo != null)
                {
                    rParam = new ReportParameter("CompanyName", sysinfo.Name);
                    _ReportParameters.Add(rParam);

                    rParam = new ReportParameter("Address", sysinfo.Address);
                    _ReportParameters.Add(rParam);

                    rParam = new ReportParameter("Phone", sysinfo.TelephoneNo);
                    _ReportParameters.Add(rParam);
                }

                rParam = new ReportParameter("Logo",Application.StartupPath + @"\Logo.bmp");
                _ReportParameters.Add(rParam);
            }
        }
    }
}
