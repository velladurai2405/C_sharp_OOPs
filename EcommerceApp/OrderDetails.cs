using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp
{
    public enum Status{canceled,ordered}
    public class OrderDetails
    { 
        public static int s_orderId=1000;
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchasedQuantity { get; set; }
        public Status Status { get; set; }
        public OrderDetails(string customerId,string productId,int totalPrice,DateTime purchaseDate,int purchasedQuantity,Status status)
        {
            s_orderId++;
            OrderId="OID"+s_orderId;
            CustomerId=customerId;
            ProductId=productId;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            PurchasedQuantity=purchasedQuantity;
            Status=status;

        }

          
    }
}