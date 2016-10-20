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
    public partial class frmsupplierinfo : Form
    {
        public frmsupplierinfo()
        {
            InitializeComponent();
        }
        public static int GSuppilerId;

        private void frmsupplierinfo_Load(object sender, EventArgs e)
        {
            GetAllSupplierInfo();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            String strqu = "";
            clsSupplierInfo data = new clsSupplierInfo();
            data = CreateData(data);
            strqu = "Insert into tbl_SupplierInfo(SupplierName,Phone,Address,ContactPerson,ContactNumber) values('" + data.SupplierName + "','" + data.Phone + "','" + data.Address + "','" + data.ContactPerson + "','" + data.ContactNumber + "')";
            SqlHelper.ExecuteNonQuery(clsUtil.ConnectionString, CommandType.Text, strqu);
            MessageBox.Show("Save Data Sucessfully .");
            GetAllSupplierInfo();
            ClearAllData();
        }
        public clsSupplierInfo CreateData(clsSupplierInfo data)
        {

            data.SupplierName = txtSupplierName.Text.ToString().Trim();
            data.Phone = Convert.ToInt32(txtPhone.Text.ToString().Trim());
            data.Address = txtAddress.Text.ToString().Trim();
            data.ContactPerson = txtContactPerson.Text.ToString().Trim();
            data.ContactNumber = Convert.ToInt32(txtContactNo.Text.ToString().Trim());
            return data;
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
                    //listvalue.SubItems.Add(dr.GetValue(6).ToString().Trim());
                   // listvalue.SubItems.Add(dr.GetValue(7).ToString().Trim());
                    //listvalue.SubItems.Add(dr.GetValue(0).ToString().Trim());

                    lvSupplierInfo.Items.Add(listvalue);
                }

            }


            catch (Exception ex)

            { MessageBox.Show(ex.Message); }


        }
        public void ClearAllData()
        {
            txtSupplierName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtContactPerson.Text = String.Empty;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtPhone.Text.ToString().Trim());
            }

            catch (Exception ex)
            { txtPhone.Text = ""; }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtContactNo.Text.ToString().Trim());
            }

            catch (Exception ex)
            { txtContactNo.Text = ""; }
        }

        private void lvSupplierInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GSuppilerId = Convert.ToInt32(lvSupplierInfo.SelectedItems[0].SubItems[0].Text.ToString().Trim());
            txtSupplierName.Text = lvSupplierInfo.SelectedItems[0].SubItems[1].Text.ToString().Trim();
            txtPhone.Text = lvSupplierInfo.SelectedItems[0].SubItems[2].Text.ToString().Trim();
            txtAddress.Text = lvSupplierInfo.SelectedItems[0].SubItems[3].Text.ToString().Trim();
            txtContactPerson.Text = lvSupplierInfo.SelectedItems[0].SubItems[4].Text.ToString().Trim();
            txtContactNo.Text = lvSupplierInfo.SelectedItems[0].SubItems[5].Text.ToString().Trim();

        }
        public clsSupplierInfo UpdateData(clsSupplierInfo data)
        {
            data.SupplierId = GSuppilerId;
            data.SupplierName = txtSupplierName.Text.ToString().Trim();
            data.Phone = Convert.ToInt32(txtPhone.Text.ToString().Trim());
            data.Address = txtAddress.Text.ToString().Trim();
            data.ContactPerson = txtContactPerson.Text.ToString().Trim();
            data.ContactNumber = Convert.ToInt32(txtContactNo.Text.ToString().Trim());
            return data;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            String strQuery = "";
            clsSupplierInfo data1 = new clsSupplierInfo();
            data1 = UpdateData(data1);
            strQuery = " UPDATE [tbl_SupplierInfo] " +
                                    "SET [SupplierName] ='" + data1.SupplierName + "'" +
                                   ",[Phone]=' " + data1.Phone + "' " +
                                   ",[Address]= '" + data1.Address + "' " +
                                   ",[ContactPerson]= '" + data1.ContactPerson + "' " +
                                   ",[ContactNumber]= '" + data1.ContactNumber + "' " +
                                   "WHERE [SupplierId]=" + data1.SupplierId + " ";
            SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, strQuery);
            MessageBox.Show("Update Data Sucessfully .");
            ClearAllData();
        }
        
    }
}
