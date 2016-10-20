using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSystem.EntityClass
{
  public  class clsSupplierInfo
    {
        public int supplierid;
        public String suppliernames;
        public int phone;
        public String address;
        public String contactperson;
        public int contactnumber;

        public int SupplierId {
            get { return supplierid; }
            set { supplierid = value; }
        }
        public String SupplierName {
            get { return suppliernames; }
            set { suppliernames = value; }
        }
        public int Phone {
            get { return phone; }
            set { phone = value; }
        }
        public String Address {
            get { return address; }
            set { address = value; }
        }
        public String ContactPerson {
            get { return contactperson; }
            set { contactperson = value; }
        }
        public int ContactNumber {
            get { return contactnumber; }
            set { contactnumber = value; }
        }


    }
}
