using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSystem.EntityClass
{
    public class clsProductInfo
    {
        public int  productId;
        public int typeId;
        public String  name;
        public int  unitId;
        public Double price;
        public String companyName;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        
        }

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }

        }

        public String Name
        {
            get { return name; }
            set { name = value; }

        }

        public int UnitId
        {
            get { return unitId; }
            set { unitId = value; }

        }

        public double Price
        {
            get { return price; }
            set { price = value; }

        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }

        }

          

    }
}
