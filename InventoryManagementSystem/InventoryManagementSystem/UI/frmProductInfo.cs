using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using InventoryManagementSystem.EntityClass;

namespace InventoryManagementSystem.UI
{
    public partial class frmproductinfo : Form
    {
        public frmproductinfo()
        {
            InitializeComponent();
        }

        public static int GProductID;
        private void frmproductinfo_Load(object sender, EventArgs e)
        {
            GetAllProductInfo();
            GetProductType();
            GetUnitType();
        }


        public void GetProductType()
        {

            cmbProductTypeName.Items.Clear();
            cmbProductTypeID.Items.Clear();

            try
            {
                String strQuery = "";
                IDataReader dr = null;
                strQuery = "Select * from dbo.tbl_ProductType";
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);

                while (dr.Read())
                {
                    cmbProductTypeID.Items.Add(dr.GetValue(0).ToString().Trim());
                    cmbProductTypeName.Items.Add(dr.GetValue(1).ToString().Trim());
                
                }
            
            }


            catch(Exception ex)

            { MessageBox.Show(ex.Message); }
        
        
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

        public void GetUnitType()
        {

            cmbUnitID.Items.Clear();
            cmbUnitName.Items.Clear();

            try
            {
                String strQuery = "";
                IDataReader dr = null;
                strQuery = "Select * from dbo.tbl_UnitInfo";
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);

                while (dr.Read())
                {
                    cmbUnitID.Items.Add(dr.GetValue(0).ToString().Trim());
                    cmbUnitName.Items.Add(dr.GetValue(1).ToString().Trim());

                }

            }


            catch (Exception ex)

            { MessageBox.Show(ex.Message); }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String strQuery = "";
            clsProductInfo data = new clsProductInfo();
            data = CreateData(data);

            strQuery = "Insert into tbl_ProductInFo(Name,TypeId,UnitId,Price,CompanyName) values('" + data.Name + "','" + data.TypeId + "','" + data.UnitId + "','" + data.Price + "','" + data.CompanyName + "')";

            SqlHelper.ExecuteNonQuery(clsUtil.ConnectionString, CommandType.Text, strQuery);
            MessageBox.Show("Save Data Sucessfully .");
            ClearAllData();
        }



        public clsProductInfo CreateData(clsProductInfo data)
        {

            data.Name = txtProductName.Text.ToString().Trim();
            data.TypeId=Convert.ToInt32(cmbProductTypeID.Text.ToString().Trim());
            data.UnitId = Convert.ToInt32(cmbUnitID.Text.ToString().Trim());
            data.Price = Convert.ToDouble(txtPrice.Text.ToString().Trim());
            data.companyName = txtCompanyName.Text.ToString().Trim();

            return data;
        }
        public void ClearAllData()
        {
            cmbUnitID.Text = string.Empty;
            cmbUnitName.Text = string.Empty;
            cmbProductTypeID.Text = string.Empty;
            cmbProductTypeName.Text = string.Empty;
           
            cmbProductTypeName.Items.Clear();
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
           txtCompanyName.Text = string.Empty;
           GetProductType();
           GetUnitType();
           GetAllProductInfo();

        }

        private void cmbProductTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProductTypeID.Text = cmbProductTypeID.Items[cmbProductTypeName.SelectedIndex].ToString().Trim();
        }

        private void cmbUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
           cmbUnitID.Text = cmbUnitID.Items[cmbUnitName.SelectedIndex].ToString().Trim();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtPrice.Text.ToString().Trim());
            }

            catch (Exception ex)
            { txtPrice.Text = ""; }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


       

        private void lvlProductInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GProductID =Convert.ToInt32( lvlProductInfo.SelectedItems[0].SubItems[0].Text.ToString().Trim());
            txtProductName.Text = lvlProductInfo.SelectedItems[0].SubItems[1].Text.ToString().Trim();
            cmbProductTypeID.Text = lvlProductInfo.SelectedItems[0].SubItems[2].Text.ToString().Trim();
            cmbProductTypeName.Text = lvlProductInfo.SelectedItems[0].SubItems[3].Text.ToString().Trim();
            txtCompanyName.Text = lvlProductInfo.SelectedItems[0].SubItems[4].Text.ToString().Trim();
            cmbUnitID.Text = lvlProductInfo.SelectedItems[0].SubItems[5].Text.ToString().Trim();
            cmbUnitName.Text = lvlProductInfo.SelectedItems[0].SubItems[6].Text.ToString().Trim();
            txtPrice.Text = lvlProductInfo.SelectedItems[0].SubItems[7].Text.ToString().Trim();
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String strQuery = "";
            clsProductInfo data1 = new clsProductInfo();
            data1 = UpdateData(data1);
            strQuery = " UPDATE [tbl_ProductInFo] " +
                                    "SET [Name] ='" + data1.Name + "'" +
                                   ",[TypeId]=' " + data1.TypeId + "' " +
                                   ",[UnitId]= '" + data1.UnitId + "' " +
                                   ",[CompanyName]= '" + data1.CompanyName + "' " +
                                   ",[Price]= '" + data1.Price + "' " +
                                   "WHERE [ProductId]=" + data1.ProductId + " ";
            SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);
            MessageBox.Show("Update Data Sucessfully .");
            ClearAllData();
        }

        public clsProductInfo UpdateData(clsProductInfo data)
        {
            data.ProductId = GProductID;
            data.Name = txtProductName.Text.ToString().Trim();
            data.TypeId = Convert.ToInt32(cmbProductTypeID.Text.ToString().Trim());
            data.UnitId = Convert.ToInt32(cmbUnitID.Text.ToString().Trim());
            data.Price = Convert.ToDouble(txtPrice.Text.ToString().Trim());
            data.companyName = txtCompanyName.Text.ToString().Trim();

            return data;
        }

        private void lvlProductInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
