using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ElectricityBill;
class Program{
    public static void Main(string[] args)
    {
        int option1;
        List<EbBill> ebList=new List<EbBill>();
        do{
            Console.WriteLine("1.Registern\n2.Login\n3.Exit");
            option1=int.Parse(Console.ReadLine());
            switch(option1)
            {
                case 1:
                {
                    Console.WriteLine("Enter user name:");
                    string userName=Console.ReadLine();
                    Console.WriteLine("Enter your phone number");
                    long phoneNumber=long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your Email Id");
                    string emailId=Console.ReadLine();
                    EbBill eb=new EbBill(userName,phoneNumber,emailId);
                    ebList.Add(eb);
                    Console.WriteLine("Your meter id is succefully created and your id is:"+eb.MeterId);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter yout Meter ID:");
                    string loginId=Console.ReadLine();
                    bool flag=false;
                    foreach(EbBill ebElement in ebList)
                    {
                        flag=false;
                        if(loginId==ebElement.MeterId)
                        {
                            int option2;
                            flag=true;
                            do
                            {
                                Console.WriteLine("1.Calculate Amount\n2.Display Details\n3.Exit");
                                option2=int.Parse(Console.ReadLine());
                                switch(option2)
                                {
                                    case 1:
                                    {
                                        Console.WriteLine("Enter the number of units used");
                                        double units=double.Parse(Console.ReadLine());
                                        double amount=EbBill.EbAmount(units);
                                        Console.WriteLine("Your bill Id is:"+ebElement.BillId);
                                        Console.WriteLine("User name:"+ebElement.UserName);
                                        Console.WriteLine($"Your EB bill amount is{amount} for {units}units");
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("Meter Id: "+ebElement.MeterId);
                                        Console.WriteLine("User name: "+ebElement.UserName);
                                        Console.WriteLine("Phone number: "+ebElement.PhoneNumber);
                                        Console.WriteLine("Email ID: "+ebElement.EmailId);
                                        break; 
                                    }

                                }
                            }while(option2!=3);
                        }
                        
                    }
                    if(flag==false)
                    {
                        Console.WriteLine("Invalid meter Id.Please reenter.");
                    }
                    break;
                }
            }

        } while (option1 != 3);
    }
}
