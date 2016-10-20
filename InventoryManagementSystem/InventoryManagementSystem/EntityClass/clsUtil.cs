using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace InventoryManagementSystem.EntityClass
{
   public  class clsUtil
    {
        public static string ConnectionString
        {
            get { return ConfigurationSettings.AppSettings["ConnectionString"].ToString(); }


        }
    }
}
