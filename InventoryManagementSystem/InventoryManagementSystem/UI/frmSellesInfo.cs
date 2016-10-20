using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using InventoryManagementSystem.EntityClass;
using InventoryManagementSystem.UI;


namespace InventoryManagementSystem.UI
{
    public partial class frmSellesInfo : Form
    {
        public frmSellesInfo()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void frmsellesinfo_Load(object sender, EventArgs e)
        {
            GetAllProductInfo();
            GetAllSupplierInfo();
        }
        public void GetAllProductInfo()
        {
            lvlProductInfo.Items.Clear();

            try
            {
                String strQuery = "";
                IDataReader dr = null;
                strQuery = "Select a.ProductId,a.Name,b.TypeId,b.TypeName,a.CompanyName,c.UnitId,c.UnitName,a.Price from dbo.tbl_ProductInFo a inner join dbo.tbl_ProductType b on a.TypeId=b.TypeId inner join dbo.tbl_UnitInfo c on a.UnitId=c.UnitId";
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);

                ListViewItem listvalue;
                while (dr.Read())
                {
                    listvalue = new ListViewItem();

                    listvalue.Text = dr.GetValue(0).ToString().Trim();
                    listvalue.SubItems.Add(dr.GetValue(1).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(2).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(3).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(4).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(5).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(6).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(7).ToString().Trim());
                    //listvalue.SubItems.Add(dr.GetValue(0).ToString().Trim());

                    lvlProductInfo.Items.Add(listvalue);
                }

            }


            catch (Exception ex)

            { MessageBox.Show(ex.Message); }


        }
        public void GetAllProductInfoByName()
        {
            lvlProductInfo.Items.Clear();

            try
            {
                String strQuery = "";
                IDataReader dr = null;
                strQuery = "Select a.ProductId,a.Name,b.TypeId,b.TypeName,a.CompanyName,c.UnitId,c.UnitName,a.Price from dbo.tbl_ProductInFo a inner join dbo.tbl_ProductType b on a.TypeId=b.TypeId inner join dbo.tbl_UnitInfo c on a.UnitId=c.UnitId  where a.Name like '%" + txtProductNameSearch.Text.ToString().Trim() + "%'";
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);

                ListViewItem listvalue;
                while (dr.Read())
                {
                    listvalue = new ListViewItem();

                    listvalue.Text = dr.GetValue(0).ToString().Trim();
                    listvalue.SubItems.Add(dr.GetValue(1).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(2).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(3).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(4).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(5).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(6).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(7).ToString().Trim());
                    //listvalue.SubItems.Add(dr.GetValue(0).ToString().Trim());

                    lvlProductInfo.Items.Add(listvalue);
                }

            }


            catch (Exception ex)

            { MessageBox.Show(ex.Message); }


        }
        public void GetAllSupplierInfo()
        {
            lvSupplierInfo.Items.Clear();

            try
            {
                String strquery = "";
                IDataReader dr = null;
                strquery = "select * from tbl_SupplierInfo";
                ;
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strquery);

                ListViewItem listvalue;
                while (dr.Read())
                {
                    listvalue = new ListViewItem();

                    listvalue.Text = dr.GetValue(0).ToString().Trim();
                    listvalue.SubItems.Add(dr.GetValue(1).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(2).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(3).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(4).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(5).ToString().Trim());                    

                    lvSupplierInfo.Items.Add(listvalue);
                }

            }


            catch (Exception ex)

            { MessageBox.Show(ex.Message); }


        }

        public void GetAllSupplierInfobyName()
        {
            lvSupplierInfo.Items.Clear();
           
            try
            {
                String strquery = "";
                IDataReader dr = null;
                strquery = "select * from tbl_SupplierInfo where SupplierName  like '%" + txtSuplierByName.Text.ToString().Trim() + "%' ";
                
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strquery);

                ListViewItem listvalue;
                while (dr.Read())
                {
                    listvalue = new ListViewItem();

                    listvalue.Text = dr.GetValue(0).ToString().Trim();
                    listvalue.SubItems.Add(dr.GetValue(1).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(2).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(3).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(4).ToString().Trim());
                    listvalue.SubItems.Add(dr.GetValue(5).ToString().Trim());

                    lvSupplierInfo.Items.Add(listvalue);
                }

            }


            catch (Exception ex)

            { MessageBox.Show(ex.Message); }


        }

        private void txtSuplierByName_TextChanged(object sender, EventArgs e)
        {
            GetAllSupplierInfobyName();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lvSupplierInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCustomerId.Text =lvSupplierInfo.SelectedItems[0].SubItems[0].Text.ToString().Trim();
            txtCustomerName.Text = lvSupplierInfo.SelectedItems[0].SubItems[1].Text.ToString().Trim();
           
        }

        private void lvlProductInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtProductID.Text = lvlProductInfo.SelectedItems[0].SubItems[0].Text.ToString().Trim();
            txtProductName.Text = lvlProductInfo.SelectedItems[0].SubItems[1].Text.ToString().Trim();
            txtRate.Text = lvlProductInfo.SelectedItems[0].SubItems[7].Text.ToString().Trim();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtInvoiceNo.Text = GenerateVoucherNo("Inv-");
        }

        private string GenerateVoucherNo(string sufix)
        {
            string voucher;
            System.Random random = new Random();
            int rnd = random.Next(999);
            DateTime time = DateTime.Now;

            voucher = Convert.ToString(sufix + String.Format("{0}-{1}", time.ToString("HHssMMddmm"), Convert.ToString(rnd).PadLeft(3, '0')));
            return voucher;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtQuantity.Text.ToString().Trim());
                if (txtQuantity.Text != String.Empty && txtRate.Text != String.Empty)
                {
                    txtAmount.Text = Convert.ToString(Convert.ToDouble(txtRate.Text.ToString().Trim()) * Convert.ToDouble(txtQuantity.Text.ToString().Trim()));

                }

            }
          catch {
              txtQuantity.Text = "";
                

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            ListViewItem lv_items = new ListViewItem();
            lv_items.SubItems.Add(txtInvoiceNo.Text.ToString().Trim());            
            lv_items.SubItems.Add(txtCustomerId.Text.ToString().Trim());
            lv_items.SubItems.Add(txtCustomerName.Text.ToString().Trim());
            lv_items.SubItems.Add(txtProductID.Text.ToString().Trim());
            lv_items.SubItems.Add(txtProductName.Text.ToString().Trim());
            lv_items.SubItems.Add(txtRate.Text.ToString().Trim());
            lv_items.SubItems.Add(txtQuantity.Text.ToString().Trim());
            lv_items.SubItems.Add(txtAmount.Text.ToString().Trim());

            lvlInvoiceDetailce.Items.Add(lv_items);

            double DrAmount = 0;
            for (int i = 0; i < lvlInvoiceDetailce.Items.Count; i++)
            {

                if (lvlInvoiceDetailce.Items[i].SubItems[8].Text.ToString().Trim() != "")
                {
                    DrAmount += Convert.ToDouble(lvlInvoiceDetailce.Items[i].SubItems[8].Text.ToString().Trim());
                }
            }
            txtTotalAmount.Text = Convert.ToString(DrAmount);
            lvSupplierInfo.Enabled = false;
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtPayAmount.Text.ToString().Trim());
                if (txtPayAmount.Text != String.Empty && txtTotalAmount.Text != String.Empty)
                {
                    txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmount.Text.ToString().Trim()) - Convert.ToDouble(txtPayAmount.Text.ToString().Trim()));

                }

            }
            catch
            {
                txtPayAmount.Text = "";


            }
        }

        private void txtProductNameSearch_TextChanged(object sender, EventArgs e)
        {
            GetAllProductInfoByName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertAllData();
        }

        private void InsertAllData()
        {
          
            String strQuery = "";
            try
            {
                if (lvlInvoiceDetailce.Items.Count != 0)
                {
                    for (int i = 0; i < lvlInvoiceDetailce.Items.Count; i++)
                    {

                        clsSellsInfo sales = new clsSellsInfo();
                        sales = CreateSales(sales, i);
                        strQuery = "";

                        strQuery = "INSERT INTO tbl_SellesInfo([CustomerId],[InvoiceNo],[ProductId]," +
                                "[Rate],[Quantity],[Amount],[TotalAmount],[PayAmount],[DueAmount],[GreatTotalAmount],[UserId],[EntryDate])VALUES('" + sales.CustomerId + "','" + sales.InvoiceNo + "','" + sales.ProductId + "','" + sales.Rate + "','" + sales.Quantity + "'" +
                                 "," + sales.Amount + "," + sales.TotalAmount + "," + sales.PayAmount + "," + sales.DueAmount + ",'" + sales.GreatTotalAmount + "'," + sales.UserId + "" +
                            ",'" + sales.EntryDate + "')";

                            SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);

                           
                        
                    }
                    MessageBox.Show("Save Data Sucessfully .");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public clsSellsInfo CreateSales(clsSellsInfo sales, int i)
        {
            //if (btnItemClear.Text == "Item Delete")
            //{ TemporarySalesID = Convert.ToInt32(lvSalesInfo.Items[i].SubItems[0].Text.ToString().Trim()); }
            //else if (btnFinalSave.Text == "Update")
            //{ TemporarySalesID = Convert.ToInt32(lvSalesInfo.Items[i].SubItems[0].Text.ToString().Trim()); }

            sales.customerId = Convert.ToInt32(lvlInvoiceDetailce.Items[i].SubItems[2].Text.ToString().Trim());
            sales.invoiceNo = Convert.ToString(lvlInvoiceDetailce.Items[i].SubItems[1].Text.ToString().Trim());
            sales.productId = Convert.ToInt32(lvlInvoiceDetailce.Items[i].SubItems[4].Text.ToString().Trim());
            sales.rate = Convert.ToInt32(lvlInvoiceDetailce.Items[i].SubItems[6].Text.ToString().Trim());
            sales.quantity = Convert.ToInt32(lvlInvoiceDetailce.Items[i].SubItems[7].Text.ToString().Trim());
            sales.amount = Convert.ToInt32(lvlInvoiceDetailce.Items[i].SubItems[8].Text.ToString().Trim());
            sales.totalAmount = Convert.ToInt32(txtTotalAmount.Text.ToString().Trim());
            sales.payAmount = Convert.ToInt32(txtPayAmount.Text.ToString().Trim());
            sales.dueAmount = Convert.ToInt32(txtDueAmount.Text.ToString().Trim());
                      

            sales.UserId = Convert.ToInt32(1);
            
            sales.EntryDate = System.DateTime.Now.Date;
            sales.UpdateDate = System.DateTime.Now.Date;



            return sales;
        }

        private void lvSupplierInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSellesInfo_Load_1(object sender, EventArgs e)
        {
            GetAllProductInfo();
            GetAllSupplierInfo();
        }

    }
}
