using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InventoryManagementSystem.UI;

namespace InventoryManagementSystem
{
 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSellesInfo());
        }
    }
}
