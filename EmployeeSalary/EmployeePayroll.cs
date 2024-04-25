using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
public enum Location{select,annanagar,chetpat}
public enum Gender{select,Male,Female}

namespace EmployeeSalary
{
    public class EmployeePayroll
    {
        private static int s_employeeId=1000;
        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
        public Location Location { get; set; }
        public string TeamName { get; set; }
        public DateTime Doj { get; set; }
        public int WorkDays { get; set; }
        public int LeaveDays { get; set; }
        public Gender Gender { get; set; }

   
   public EmployeePayroll(string employeeName,string employeeRole,Location location,string teamName,DateTime doj,int workDays,int leaveDays,Gender gender)
   {
    s_employeeId++;
    EmployeeId="SF"+s_employeeId;
    EmployeeName=employeeName;
    EmployeeRole=employeeRole;
    Location=location;
    TeamName=teamName;
    Doj=doj;
    WorkDays=workDays;
    LeaveDays=leaveDays;
    Gender=gender;

   }
    public static int Salary(int workDays,int leaveDays)
    {
        int salary=(workDays-leaveDays)*500;
        return salary;

    }
    
    }

    
}