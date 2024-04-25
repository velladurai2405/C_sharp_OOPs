using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp
{
    public class CustomerDetails
    {
        private static int s_customerId=1000;
        public string CustomerId { get; }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public long Mobile { get; set; }
        public int Balance { get; set; }
        public string MailId { get; set; }
        public CustomerDetails(string customerName,string customerCity,long mobile,int balance,string mailId)
        {
            s_customerId++;
            CustomerId="CID"+s_customerId;
            CustomerName=customerName;
            CustomerCity=customerCity;
            Mobile=mobile;
            Balance=balance;
            MailId=mailId;

        }
        public int WalletRecharge(int amount)
        {           
            Balance=Balance+amount;
            return Balance;
        }
    }
    
}