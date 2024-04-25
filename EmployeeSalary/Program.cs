using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace EmployeeSalary;
class Program{
    public static void Main(string[] args)
    {
        List<EmployeePayroll> employeeList=new List<EmployeePayroll>(); 
        int option1;
        do{
            Console.WriteLine("1.Register\n2.Login\n3.Exit");
            Console.WriteLine("Enter an option");
            option1=int.Parse(Console.ReadLine());
            
            switch(option1)
            {
                case 1:
                {
                    
                    Console.WriteLine("Enter your name: ");
                    string employeeName=Console.ReadLine();
                    Console.WriteLine("Enter your roll: ");
                    string employeeRole=Console.ReadLine();
                    Console.WriteLine("Enter Location annanagar or chetpat");
                    Location location;
                    bool temp1=Enum.TryParse<Location>(Console.ReadLine(),true,out location);
                    while(!temp1)
                    {
                        Console.WriteLine("Location is invalid. Please Reenter");
                        temp1=Enum.TryParse<Location>(Console.ReadLine(),true,out location);

                    }
                    Console.WriteLine("Enter your team name: ");
                    string teamName=Console.ReadLine();
                    Console.WriteLine("Enter your working days");
                    int workDays=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your leave days:");
                    int leaveDays=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your date of joining");
                    DateTime doj=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.WriteLine("enter your gender.");
                    Gender gender;
                    bool temp2=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                    while(!temp2)
                    {
                        Console.WriteLine("Gender is invalid. Please Reenter");
                        temp2=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                    }
                    EmployeePayroll employee=new EmployeePayroll(employeeName,employeeRole,location,teamName,doj,workDays,leaveDays,gender);
                    employeeList.Add(employee);
                    Console.WriteLine("Succesfully registered. And your employee Id is"+employee.EmployeeId);
                    
                    break;

                }
                case 2:
                {
                    Console.WriteLine("Enter login id");
                    string login=Console.ReadLine();
                    foreach(EmployeePayroll payroll in employeeList)
                    {
                        if(payroll.EmployeeId==login)
                        {
                            int option2;
                            do
                            {
                                Console.WriteLine("1.Calculate Salary\n2.Display Details\n3.Exit");
                                option2=int.Parse(Console.ReadLine());
                                switch(option2)
                                {
                                    case 1:
                                    {
                                        int salaryAmount=EmployeePayroll.Salary(payroll.WorkDays,payroll.LeaveDays);
                                        Console.WriteLine(salaryAmount);
                                        break;
                                    }
                                    case 2:
                                    {
                                        foreach(EmployeePayroll emp in employeeList)
                                        {
                                            Console.WriteLine("Employee Id: "+emp.EmployeeId);
                                            Console.WriteLine("Employee name: "+emp.EmployeeName);
                                            Console.WriteLine("Employee role: "+emp.EmployeeRole);
                                            Console.WriteLine("Employee location: "+emp.Location);
                                            Console.WriteLine("Employee team name: "+emp.TeamName);
                                            Console.WriteLine("No of working days in month: "+emp.WorkDays);
                                            Console.WriteLine("No of leave days: "+emp.LeaveDays);
                                            Console.WriteLine("Date of joining: "+emp.Doj);
                                            Console.WriteLine("Gender: "+emp.Gender);
                                            Console.WriteLine("Employee Id: "+emp.LeaveDays);
                                        }
                                        break;
                                    }
                                }
                            }while(option2!=3);
                        }
                    }
                    break;

                }
            }
        }while(option1!=3);
        
    }
}

