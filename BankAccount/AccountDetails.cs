using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount
{
    public enum Gender{select,Male,Female,Transgender}
    
    public class AccountDetails
    {
        private static int s_customerId=1000;
        public string CustomerId { get; }
        public string CustomerName { get; set; }
        
        public Gender Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        public DateTime Dob { get; set; }



        public AccountDetails(string customerName,Gender gender,long phoneNumber,string mailId,DateTime dob)
    {
        s_customerId++;
        CustomerId="HDFC"+s_customerId;
        CustomerName=customerName;
        Gender=gender;
        PhoneNumber=phoneNumber;
        MailId=mailId;
        Dob=dob;
    }



        
    public static double Deposit(double balance,double deposit)
    {
        
        balance=balance+deposit;
        return balance;
    }
    public static double Withdraw(double balance,double withdraw)
    {
        
        balance=balance-withdraw;
        return balance;
    }

        
    
    }
}
    

