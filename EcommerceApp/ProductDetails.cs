using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp
{
    public class ProductDetails
    {
        private static int s_productId=100;
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Availability { get; set; }
        public int Price { get; set; }
        public int ShippingDuration { get; set; }
    public ProductDetails(string productName,int availability,int price,int shippingDuration)
    {
        s_productId++;
        ProductId="PID"+s_productId;
        ProductName=productName;
        Availability=availability;
        Price=price;
        ShippingDuration=shippingDuration;  
    }
        
    }
    
}