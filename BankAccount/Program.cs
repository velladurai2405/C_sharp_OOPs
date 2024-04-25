using System;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace BankAccount;
class Program{
    public static void Main(string[] args)
    {
        int n;
        double balance=0;
        double deposit=0;
        List<AccountDetails> customerList =new List<AccountDetails>();
        do{   
            Console.WriteLine("1. Registration \n 2. Login \n 3. Exit");
            Console.WriteLine("Enter a number");
            n=int.Parse(Console.ReadLine());       
            switch(n)
            {
                case 1:
                {
                    Console.WriteLine("Enter customer name:");
                    string customerName=Console.ReadLine();
                    Console.WriteLine("Enter Gender Male or female or Transgender:");
                    Gender gender;
                    bool temp=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                    while(!temp)
                    {
                        Console.WriteLine("Invalid Gender please Reenter");


                        temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

                    }
                    Console.WriteLine("Enter phone number:");
                    long phoneNumber=long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Mail Id");
                    string mailId=Console.ReadLine();
                    Console.WriteLine("Enter Date of birth");
                    DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    AccountDetails customer=new AccountDetails(customerName,gender,phoneNumber,mailId,dob);
                    customerList.Add(customer);
                    Console.WriteLine("You have succesfully registered. and your Id is: "+customer.CustomerId);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter your loginId:");
                    string login=Console.ReadLine().ToUpper();
                    bool flag=false;
                    foreach(AccountDetails detail in customerList)
                    {
                        flag=false;
                        if(detail.CustomerId==login)
                        {
                            flag=true;
                            int m;
                            do
                            {   
                                Console.WriteLine("1. Deposit \n 2. withdraw \n 3.balance check \n 4. exit");
                                m=int.Parse(Console.ReadLine());
                                switch(m){
                                case 1:
                                {
                                    
                                    Console.WriteLine("Enter deposit value");
                                    deposit=double.Parse(Console.ReadLine());
                                    balance=AccountDetails.Deposit(balance,deposit);
                                    Console.WriteLine("Balance added succesfully.");

                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine("Enter withdraw amount");
                                    int withdraw=int.Parse(Console.ReadLine());
                                    balance=AccountDetails.Withdraw(balance,withdraw);
                                    Console.WriteLine("Withdraw succesfully.");
                            
                                    break;
                                }
                                case 3:
                                {
                                    Console.WriteLine("balance "+balance);
                                    break;
                                }
                            }
                            }while(m!=4);

                        }
                    }
                    if(flag==false)
                    {
                        Console.WriteLine("Invalid user");
                    }
                        
                   
                    break;
                }
                
               

            }

            

        }while(n!=3);
    }
}
