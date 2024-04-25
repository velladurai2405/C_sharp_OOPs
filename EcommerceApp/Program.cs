using System;
using System.Collections.Generic;
using System.Dynamic;
namespace EcommerceApp;
class Program{
    public static void Main(string[] args)
    {
        List<CustomerDetails> customerDetailsList=new List<CustomerDetails>();
        List<ProductDetails> productDetailsList=new List<ProductDetails>();
        List<OrderDetails> orderDetailsList=new List<OrderDetails>();
                
        CustomerDetails customer1=new CustomerDetails("Ravi","chennai",9885858588,50000,"ravi@mail.com");
        customerDetailsList.Add(customer1);
        CustomerDetails customer2=new CustomerDetails("Baskaran","chennai",9888475757,60000,"baskaran@mail.com");
        customerDetailsList.Add(customer2);

        ProductDetails product1=new ProductDetails("Mobile(samsung)",10,10000,3);
        productDetailsList.Add(product1);
        ProductDetails product2=new ProductDetails("Tablet (Lenovo)",5,15000,2);
        productDetailsList.Add(product2);
        ProductDetails product3=new ProductDetails("Camara (Sony)",3,20000,4);
        productDetailsList.Add(product3);
        ProductDetails product4=new ProductDetails("iPhone ",5,50000,6);
        productDetailsList.Add(product4);
        ProductDetails product5=new ProductDetails("Laptop (Lenovo I3)",3,40000,3);
        productDetailsList.Add(product5);
        ProductDetails product6=new ProductDetails("HeadPhone (Boat)",5,1000,2);
        productDetailsList.Add(product6);
        ProductDetails product7=new ProductDetails("Laptop (Lenovo I3)",4,500,2);
        productDetailsList.Add(product7);

        OrderDetails order1=new OrderDetails("CID1001","PID101",20000,DateTime.Now,2,Status.ordered);
        orderDetailsList.Add(order1);
        OrderDetails order2=new OrderDetails("CID1002","PID102",40000,DateTime.Now,2,Status.ordered);
        orderDetailsList.Add(order1);

        int option;
        do{
            Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit");
            option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Console.WriteLine("Enter your name");
                    string customerName=Console.ReadLine();
                    Console.WriteLine("Enter your city");
                    string customerCity=Console.ReadLine();
                    Console.WriteLine("Enter your mobile number");
                    long mobile=long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your balance");
                    int balance=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your mail Id");
                    string mailId=Console.ReadLine();
                    CustomerDetails customer=new CustomerDetails(customerName,customerCity,mobile,balance,mailId);
                    customerDetailsList.Add(customer);
                    Console.WriteLine("You are registered sucessfully and your customer ID is: "+customer.CustomerId);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter your customer Id: ");
                    string login=Console.ReadLine();
                    bool flag1=false;
                    char option2;
                    foreach(CustomerDetails customerDetail in customerDetailsList)
                    {
                        if(customerDetail.CustomerId==login)
                        {
                            flag1=true;
                            do{
                                Console.WriteLine("a.Purchase\nb.Order History\nc.Cancel Order\nd.Wallet Balance\ne.WalletRecharge\nf.Exit");
                                option2=char.Parse(Console.ReadLine());
                                switch(option2)
                                {
                                    case 'a':
                                    {
                                        foreach(ProductDetails pro in productDetailsList)
                                        {
                                            Console.WriteLine($"productId: {pro.ProductId} Product name: {pro.ProductName} Availability: {pro.Availability} Price: {pro.Price} Shipping Duration: {pro.ShippingDuration} days");
                                        }
                                        bool flag2=false;
                                        Console.WriteLine("Select product Id which you want");
                                        string proId=Console.ReadLine();
                                        foreach(ProductDetails pro in productDetailsList)
                                        {                                                                                       
                                            flag2=true;
                                            if(pro.ProductId==proId)
                                            {                                       
                                                Console.WriteLine("Enter no of products you want: ");
                                               int noOfProduct=int.Parse(Console.ReadLine());
                                               if(pro.Availability>noOfProduct)
                                               {
                                                    int totalAmount=(noOfProduct*pro.Price)+50;
                                                    if(customerDetail.Balance>totalAmount)
                                                    {
                                                        customerDetail.Balance=customerDetail.Balance-totalAmount;
                                                        pro.Availability=pro.Availability-noOfProduct;
                                                        OrderDetails orderDetail=new OrderDetails(customerDetail.CustomerId,pro.ProductId,totalAmount,DateTime.Now,noOfProduct,Status.ordered);
                                                        orderDetailsList.Add(orderDetail);
                                                        Console.WriteLine($"You are sucessfully Ordered and your order ID is {orderDetail.OrderId} and your order will delivered{orderDetail.PurchaseDate.AddDays(pro.ShippingDuration)}");
                                                        break;
                                                    } 
                                               }
                                               else{
                                                Console.WriteLine($"Required count not available. Current availability is {pro.Availability}");
                                                break;
                                               }

                                            }
                                            
                                        }
                                        if(flag2==false)
                                        {
                                            Console.WriteLine("Invalid Product ID");
                                        }
                                        break;
                                    }
                                    case 'b':
                                    {
                                        foreach(OrderDetails order in orderDetailsList)
                                        {
                                            if(customerDetail.CustomerId==order.CustomerId)
                                            {
                                                Console.WriteLine($"{order.CustomerId} {order.OrderId} {order.PurchaseDate} {order.Status}");
                                            }
                                        }
                                        break;
                                    }
                                    case 'c':
                                    {
                                        foreach(OrderDetails order in orderDetailsList)
                                        {
                                            if(customerDetail.CustomerId==order.CustomerId)
                                            {
                                                Console.WriteLine($"{order.OrderId}");
                                            }
                                        }
                                        Console.WriteLine("Choose order id which order you want to cancel.");
                                        string orderid=Console.ReadLine();
                                        foreach(OrderDetails order in orderDetailsList)
                                        {
                                            if(order.OrderId==orderid&&order.Status==Status.ordered)
                                            {
                                                foreach(ProductDetails pro in productDetailsList)
                                                {
                                                    if(pro.ProductId==order.ProductId)
                                                    {
                                                        pro.Availability+=order.PurchasedQuantity;
                                                        order.Status=Status.canceled;
                                                        Console.WriteLine($"Your order with order id:{order.OrderId}cancelled sucessfully");
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    case 'd':
                                    {
                                        Console.WriteLine(customerDetail.Balance);
                                        break;
                                    }
                                    case 'e':
                                    {
                                        Console.WriteLine("enter the amount you want to recharge");
                                        int amount=int.Parse(Console.ReadLine());
                                        Console.WriteLine($"Your wallet balance is: {customerDetail.WalletRecharge(amount)}");
                                        break;
                                    }
                                    case 'f':
                                    {
                                        break;
                                    }
                                }

                            }while(option2!='f');
                        }
                    }
                    if(flag1==false)
                    {
                        Console.WriteLine("Invalid Customer details.");
                    }
                    break;
                }
            }


        }while(option!=3);


    }
}
