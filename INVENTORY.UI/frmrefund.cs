using INVENTORY.DA;
using INVENTORY.UI.BL;
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
    public partial class frmrefund : Form
    {
        List<SalesReturnBO> objSalesReturnList = null;
        public frmrefund()
        {
            InitializeComponent();
            objSalesReturnList = new List<SalesReturnBO>();
            dgProducts.AutoGenerateColumns = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtorderrefno_Enter(object sender, EventArgs e)
        {
            if (txtorderrefno.Text.Trim() != string.Empty)
            {
                try
                {
                    using (DEWSRMEntities db = new DEWSRMEntities())
                    {
                        if (db.SOrders.Any(p => p.InvoiceNo == txtorderrefno.Text))
                        {
                            SOrder oOrder = db.SOrders.FirstOrDefault(p => p.InvoiceNo == txtorderrefno.Text);
                            string itemName = "";
                            foreach (SOrderDetail oSOrderDetail in oOrder.SOrderDetails)
                            {
                                dgProducts.Rows.Add();
                                if (oSOrderDetail.TypeID == (int)EnumSalesItemType.Product)
                                {
                                    Product oProduct = db.Products.FirstOrDefault(o => o.ProductID == oSOrderDetail.ProductID);
                                    if (oProduct != null)
                                    {
                                        itemName = oProduct.ProductName;
                                    }
                                }
                                else
                                {
                                    Category oCategory = db.Categorys.FirstOrDefault(c => c.CategoryID == oSOrderDetail.ProductID);
                                    itemName = oCategory.Description;
                                }
                                objSalesReturnList.Add(
                                    new SalesReturnBO()
                                    {
                                        ItemName = itemName,
                                        Quantity = oSOrderDetail.Quantity,
                                        Amount = oSOrderDetail.UTAmount,
                                        SOrderDetailID = oSOrderDetail.SOrderDetailID,
                                        UnitPrice = oSOrderDetail.SRate
                                    }
                                    );
                            }
                            dgProducts.DataSource = objSalesReturnList;
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}
