using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryManagementSystem.EntityClass;
using Microsoft.ApplicationBlocks.Data;

namespace InventoryManagementSystem.UI
{
    public partial class frmemployeinfo : Form
    {
        public frmemployeinfo()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String quere = "";
            clsEmployeinfo data = new clsEmployeinfo();
            data = CreateData(data);
            quere="Insert into tbl_EmployeInfo(Name,FatherName,MotherName,Phone,Nid,Address) values('" + data.name + "','" + data.fathername + "','" + data.mothername + "','" + data.phone + "','" + data.nid + "','" + data.address + "')";
            SqlHelper.ExecuteNonQuery(clsUtil.ConnectionString, CommandType.Text, quere);
            MessageBox.Show("Save Data Sucessfully .");
           //ClearData();
            InsertDATA();
        }

        public void InsertDATA() {
            lvemployeinfo.Items.Clear();
            try
            {

                string query = "";
                IDataReader id = null;
                clsEmployeinfo data = new clsEmployeinfo();
                data = CreateData(data);
                query = "select Name,FatherName FROM tbl_EmployeInfo";// a INNER JOIN tbl_BloodGrop b on a.BloodId=b.BloodId";

                SqlHelper.ExecuteNonQuery(clsUtil.ConnectionString, CommandType.Text, query);
                id = SqlHelper.ExecuteReader(clsUtil.ConnectionString, CommandType.Text, query);
               
                ListViewItem listvlue;
                while (id.Read())
                {

                    listvlue = new ListViewItem();
                    listvlue.Text = id.GetValue(0).ToString().Trim();
                    //listvlue.SubItems.Add(id.GetValue(1).ToString().Trim());
                    //listvlue.SubItems.Add(id.GetValue(2).ToString().Trim());
                    //listvlue.SubItems.Add(id.GetValue(3).ToString().Trim());
                    //listvlue.SubItems.Add(id.GetValue(4).ToString().Trim());
                    //listvlue.SubItems.Add(id.GetValue(5).ToString().Trim());
                   // listvlue.SubItems.Add(id.GetValue(6).ToString().Trim());
                    lvemployeinfo.Items.Add(listvlue);
                }
            }

            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        
        
        }

        public clsEmployeinfo CreateData(clsEmployeinfo data)
        {//unknow

            data.Name = txtName.Text.ToString().Trim();
            data.Phone=Convert.ToInt32(txtPhone.Text.ToString().Trim());
            data.FatherName = txtFathername.Text.ToString().Trim();
            data.MotherName = txtMothername.Text.ToString().Trim();
            data.Nid = txtNid.Text.ToString().Trim();
            //data.bloodId = Convert.ToInt32(cmbBloodnumber.Text.ToString().Trim());
            data.Address = txtAddress.Text.ToString().Trim();

            return data;
        }
        public void ClearData() {

            txtAddress.Text = string.Empty;
            txtFathername.Text = string.Empty;
            txtMothername.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNid.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cmbBloodName.Text = string.Empty;
            cmbBloodnumber.Text = string.Empty;
           // InsertDATA();
            //GetBloodGroup();
        
        }


        public void GetBloodGroup() {

            cmbBloodnumber.Items.Clear();
            cmbBloodName.Items.Clear();

            try
            {
                string query = "";
                IDataReader dr=null;
                query = "select * from tbl_BloodGrop";
                dr = SqlHelper.ExecuteReader(clsUtil.ConnectionString,CommandType.Text,query);
                while(dr.Read()){
                    cmbBloodnumber.Items.Add(dr.GetValue(0).ToString().Trim());
                    cmbBloodName.Items.Add(dr.GetValue(1).ToString().Trim());
                
                
                }


            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        
        
        
        }


        private void frmemployeinfo_Load(object sender, EventArgs e)
        {
            GetBloodGroup();
            InsertDATA();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text=string.Empty;
        }

        private void cmbBloodnumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
