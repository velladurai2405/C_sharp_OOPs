using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBill
{
    public class EbBill
    {
        private static int s_meterId=1000;
        private static int s_billId=1000;
        public string BillId { get;  }
        public string MeterId { get;  }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailId { get; set; }

        public EbBill(string userName,long phoneNumber,string emailId)
        {
            s_meterId++;
            MeterId="EB"+s_meterId;
            s_billId++;
            BillId="Bill No"+s_billId;
            UserName=userName;
            PhoneNumber=phoneNumber;
            EmailId=emailId;

        }
        public static double EbAmount(double units)
        {
            return units*5;
        }
    }
}