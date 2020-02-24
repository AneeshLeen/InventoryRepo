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
using Microsoft.Reporting.WinForms;

namespace INVENTORY.UI
{
    public partial class fPReturns : Form
    {

        List<Return> _ReturnList = null;
        Return _Return = null;
        DEWSRMEntities db = null;
        public fPReturns()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fPReturn frm = new fPReturn();
            frm.ItemChanged = RefReshList;
            frm.ShowDlg(new Return());
        }

        void RefReshList()
        {
            try
            {
                using (DEWSRMEntities db = new DEWSRMEntities())
                {
                    var _Returns = db.Returns.Where(pr => pr.SupplierID > 0).OrderByDescending(so => so.ReturnDate).ThenBy(i => i.InvoiceNo);
                    _ReturnList = _Returns.ToList();

                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ReturnDate");
                    dt.Columns.Add("InvoiceNo");
                    dt.Columns.Add("Supplier");
                    dt.Columns.Add("ContactNo");
                    dt.Columns.Add("PaidAmount");
                    dt.Columns.Add("DueAmount");


                    if (_ReturnList != null)
                    {
                        List<Supplier> oSuppliers = db.Suppliers.ToList();
                        foreach (Return oReturn in _ReturnList)
                        {
                            dr = dt.NewRow();
                            dr["ID"] = oReturn.ReturnID;
                            dr["ReturnDate"] = Convert.ToDateTime(oReturn.ReturnDate).ToString("dd MMM yyy");
                            dr["InvoiceNo"] = oReturn.InvoiceNo;

                            if (oSuppliers != null)
                            {
                                Supplier oSupplier = oSuppliers.FirstOrDefault(o => o.SupplierID == oReturn.SupplierID);
                                dr["Supplier"] = oSupplier != null ? oSupplier.Name : "";
                                dr["ContactNo"] = oSupplier != null ? oSupplier.ContactNo : "";
                                dr["DueAmount"] = oSupplier != null ? oSupplier.TotalDue : 0;

                            }
                            dr["PaidAmount"] = oReturn.PaidAmount.ToString();
                            dt.Rows.Add(dr);
                        }

                        lblTotal.Text = "Total :" + _Returns.Count().ToString();
                        grdPReturns.DataSource = dt;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fPReturns_Load(object sender, EventArgs e)
        {
            RefReshList();
            ControlPermission();
        }

        public void ControlPermission()
        {
            User oUser = Global.CurrentUser;
            if (oUser != null && oUser.UserType == 2)
            {
                btnEdit.Enabled = false;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (DEWSRMEntities db = new DEWSRMEntities())
            {
                int[] selRows = ((GridView)grdPReturns.MainView).GetSelectedRows();
                DataRowView oReturnD = (DataRowView)(((GridView)grdPReturns.MainView).GetRow(selRows[0]));
                DataRowView oReturnDate = (DataRowView)(((GridView)grdPReturns.MainView).GetRow(selRows[0]));

                int nReturnID = Convert.ToInt32(oReturnD["ID"]);
                DateTime dReturnDate = Convert.ToDateTime(oReturnDate["ReturnDate"]);
                Return oReturn = db.Returns.FirstOrDefault(p => p.ReturnID == nReturnID);

                if (oReturn == null)
                {
                    MessageBox.Show("select an item to edit", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Global.CurrentUser.ISEditable == 1)
                {
                    if (dReturnDate < DateTime.Today)
                    {
                        MessageBox.Show("This order can't be return, Please contact BD Team", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                fPReturn frm = new fPReturn();
                frm.ItemChanged = RefReshList;
                frm.ShowDlg(oReturn);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                db = new DEWSRMEntities();
                int[] selRows = ((GridView)grdPReturns.MainView).GetSelectedRows();
                DataRowView oReturnD = (DataRowView)(((GridView)grdPReturns.MainView).GetRow(selRows[0]));

                int nReturnID = Convert.ToInt32(oReturnD["ID"]);
                _Return = db.Returns.FirstOrDefault(p => p.ReturnID == nReturnID);

                if (_Return == null)
                {
                    MessageBox.Show("select an item to generate invoice", "Item not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                fPReturn objfSOrder = new fPReturn();
                objfSOrder.GenerateReturnInvoice(_Return);
                //GenerateInvoice();
                //MoneyReceipt();                
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Cannot generate invoice due to " + Ex.Message);
            }

        }
        public void GenerateInvoice()
        {

            if (_Return != null)
            {
                DataTable orderdDT = new DataTable();
                rptDataSet.dtInvoice1DataTable dt = new rptDataSet.dtInvoice1DataTable();
                Customer customer = _Return.Customer;
                List<Product> products = db.Products.ToList();
                Product product = null;
                DataSet ds = new DataSet();

                foreach (ReturnDetail item in _Return.ReturnDetails)
                {
                    product = products.FirstOrDefault(o => o.ProductID == item.ProductID);
                    dt.Rows.Add(product.ProductName, product.Company.Description, product.Category.Description, "", item.Quantity, "Pcs", item.UnitPrice, " 0 %", item.UTAmount, 0, 0);
                }
                orderdDT = dt.AsEnumerable().OrderBy(o => (String)o["ProductName"]).CopyToDataTable();

                dt.TableName = "rptDataSet_dtInvoice";
                ds.Tables.Add(dt);

                string embededResource = "INVENTORY.UI.RDLC.AMReturnInvoice.rdlc";

                ReportParameter rParam = new ReportParameter();
                List<ReportParameter> parameters = new List<ReportParameter>();
                string sInwodTk = Global.TakaFormat(Convert.ToDouble(_Return.GrandTotal));


                rParam = new ReportParameter("GTotal", _Return.GrandTotal.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Paid", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("CurrDue", _Return.Customer.TotalDue.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("TDiscount", _Return.PaidAmount.ToString());//oOrder.TDAmount.ToString()
                parameters.Add(rParam);

                rParam = new ReportParameter("Total", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("PreDue", _Return.PaidAmount.ToString());
                parameters.Add(rParam);


                rParam = new ReportParameter("TotalDue", _Return.Customer.TotalDue.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("InvoiceNo", _Return.InvoiceNo);
                parameters.Add(rParam);

                rParam = new ReportParameter("InvoiceDate", _Return.ReturnDate.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("Company", _Return.Customer.CompanyName);
                parameters.Add(rParam);

                rParam = new ReportParameter("CAddress", _Return.Customer.Address);
                parameters.Add(rParam);

                rParam = new ReportParameter("Name", _Return.Customer.Name);
                parameters.Add(rParam);

                rParam = new ReportParameter("MobileNo", _Return.Customer.ContactNo);
                parameters.Add(rParam);

                rParam = new ReportParameter("PrintedBy", Global.CurrentUser.UserName);
                parameters.Add(rParam);

                rParam = new ReportParameter("LaborCost", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                rParam = new ReportParameter("JobNumber", "");
                parameters.Add(rParam);

                rParam = new ReportParameter("LessAmt", _Return.PaidAmount.ToString());
                parameters.Add(rParam);

                //rParam = new ReportParameter("Logo1", Application.StartupPath + @"\Logo1.bmp");
                //parameters.Add(rParam);


                rParam = new ReportParameter("InWordTK", sInwodTk);
                parameters.Add(rParam);

                fReportViewer frm = new fReportViewer();
                frm.CommonReportViewer(embededResource, ds, parameters, true);
            }


        }

        private void grdReturns_Click(object sender, EventArgs e)
        {

        }
    }
}
