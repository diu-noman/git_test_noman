using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem.UI
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void productInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproductinfo productinf = new frmproductinfo();
            productinf.Show();
        }

        private void supplierInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsupplierinfo sup = new frmsupplierinfo();
            sup.Show();
        }

        private void sellsInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSellesInfo sel = new frmSellesInfo();
            sel.Show();
        }
    }
}
