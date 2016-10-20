using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSystem.EntityClass
{
   public class clsEmployeinfo
    {
       public String name;
       public String fathername;
       public String mothername;
       public int phone;
       public String address;
       public String nid;
       public int bloodId;
       public int Phone
       {
           get { return phone; }
           set { phone = value; }

       }
       public String Name {

           get { return name; }
           set { name = value; }
       }
       public String FatherName
       {

           get { return fathername; }
           set { fathername = value; }
       }
       public String MotherName
       {

           get { return mothername; }
           set { mothername = value; }
       }
       public String Address
       {

           get { return address; }
           set { address = value; }
       }
       public String Nid
       {

           get { return nid; }
           set { nid = value; }
       }
       public int BloodId
       {

           get { return bloodId; }
           set { bloodId = value; }
       }

    }
}
