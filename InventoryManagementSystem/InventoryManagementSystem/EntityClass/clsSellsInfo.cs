using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSystem.EntityClass
{
   public class clsSellsInfo
    {
       public int sellesInFoId;
       public int customerId;
       public string invoiceNo;
       public int productId;
       public int rate;
       public int quantity;
       public int amount;
       public int totalAmount;
       public int payAmount;
       public int dueAmount;
       public int greatTotalAmount;
       public int userId;
       public DateTime entryDate;
       public DateTime updateDate;

       public int SellesInFoId
        {
            get { return sellesInFoId; }
            set { sellesInFoId = value; }
        }
       public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
       public string InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }
       public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
       public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }
       public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
       public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
       public int TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
       public int PayAmount
        {
            get { return payAmount; }
            set { payAmount = value; }
        }
       public int DueAmount
        {
            get { return dueAmount; }
            set { dueAmount = value; }
        }
       public int GreatTotalAmount
        {
            get { return greatTotalAmount; }
            set { greatTotalAmount = value; }
        }
       public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
       public DateTime EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }
       public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }
    }
}
