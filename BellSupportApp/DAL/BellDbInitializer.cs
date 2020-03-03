using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BellSupportApp.Models;

namespace BellSupportApp.DAL
{
    //initializing database with some data samples.
    public class BellDbInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<BellDbContext>
    {
        protected override void Seed(BellDbContext context) 
        {
            var employees = new List<Employee> 
            { 
                new Employee{Name="Roma Marcell",DepartmentID=1006},
                new Employee{Name="Hugo Wess",DepartmentID=1007},
                new Employee{Name="Kelvin Lahr",DepartmentID=1001},
                new Employee{Name="Janelle Newberg",DepartmentID=1006},
                new Employee{Name="Mellie Lombard",DepartmentID=1002},
                new Employee{Name="Reita Abshire",DepartmentID=1015},
                new Employee{Name="Dalila Vickrey",DepartmentID=1004},
                new Employee{Name="Idella Dallman",DepartmentID=1001},
                new Employee{Name="Farah Eldridge",DepartmentID=1008},
                new Employee{Name="Lana Montes",DepartmentID=1008},
                new Employee{Name="Leola Thornburg",DepartmentID=1007},
                new Employee{Name="Marcelo Paris",DepartmentID=1004},
                new Employee{Name="Ione Tomlin",DepartmentID=1010},
                new Employee{Name="Hilario Masterson",DepartmentID=1010},
                new Employee{Name="Janice Skipper",DepartmentID=1015},
                new Employee{Name="Keren Gillespi",DepartmentID=1012},
                new Employee{Name="Linh Leitzel",DepartmentID=1006},
                new Employee{Name="Rosalia Ayoub",DepartmentID=1005},
                new Employee{Name="Shawna Hood",DepartmentID=1002},
                new Employee{Name="Wilfredo Stumpf",DepartmentID=1011},
                new Employee{Name="Alexandra Brendle",DepartmentID=1012},
                new Employee{Name="Luciano Riddell",DepartmentID=1009},
                new Employee{Name="Boyce Perales",DepartmentID=1011},
                new Employee{Name="Alissa Perlman",DepartmentID=1006},
                new Employee{Name="Latoyia Kremer",DepartmentID=1011},
                new Employee{Name="Tawna Blackmore",DepartmentID=1015},
                new Employee{Name="Claudine Valderrama",DepartmentID=1008},
                new Employee{Name="Katheryn Lepak",DepartmentID=1011},
                new Employee{Name="Sage Bow",DepartmentID=1010},
                new Employee{Name="Altha Rudisill",DepartmentID=1008},
                new Employee{Name="Olympia Vien",DepartmentID=1005},
                new Employee{Name="Olene Pyron",DepartmentID=1013},
                new Employee{Name="Delorse Searle",DepartmentID=1007},
                new Employee{Name="Greta Quigg",DepartmentID=1003},
                new Employee{Name="Kenneth Bowie",DepartmentID=1002},
                new Employee{Name="Colton Kranz",DepartmentID=1008},
                new Employee{Name="Kasie Barclay",DepartmentID=1010},
                new Employee{Name="Thresa Levins",DepartmentID=1007},
                new Employee{Name="Diego Hasbrouck",DepartmentID=1014},
                new Employee{Name="Tomoko Gale",DepartmentID=1004}
              
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department{DepartmentID=1001,DepartmentName="Branch of Extranet Implementation"},
                new Department{DepartmentID=1002,DepartmentName="Branch of Intranet Computer Maintenance and E-Commerce PC Programming"},
                new Department{DepartmentID=1003,DepartmentName="Bureau of Business-Oriented PC Backup and Wireless Telecommunications Control"},
                new Department{DepartmentID=1004,DepartmentName="Database Programming Branch"},
                new Department{DepartmentID=1005,DepartmentName="Division of Application Security"},
                new Department{DepartmentID=1006,DepartmentName="Division of Telecommunications Extranet Development"},
                new Department{DepartmentID=1007,DepartmentName="Extranet Multimedia Connectivity and Security Division"},
                new Department{DepartmentID=1008,DepartmentName="Hardware Backup Department"},
                new Department{DepartmentID=1009,DepartmentName="Mainframe PC Development and Practical Source Code Acquisition Team"},
                new Department{DepartmentID=1010,DepartmentName="Multimedia Troubleshooting and Maintenance Team"},
                new Department{DepartmentID=1011,DepartmentName="Network Maintenance and Multimedia Implementation Committee"},
                new Department{DepartmentID=1012,DepartmentName="Office of Statistical Data Connectivity"},
                new Department{DepartmentID=1013,DepartmentName="PC Maintenance Department"},
                new Department{DepartmentID=1014,DepartmentName="Software Technology and Networking Department"},
                new Department{DepartmentID=1015,DepartmentName="Wireless Extranet Backup Team"}
               
            };

            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
                new Ticket{ProjectName="PC Upgrade",DepartmentName="PC Maintenance Department",Requestor="Olene Pyron",Description="Need my laptop upgraded",RequestDate=DateTime.Parse("2020-01-03 8:27:16 AM")},
                new Ticket{ProjectName="Device Replacement",DepartmentName="Division of Application Security",Requestor="Olympia Vien",Description="Laptop will not power on",RequestDate=DateTime.Parse("2020-01-10 10:30:29 AM")},
                new Ticket{ProjectName="Password Reset",DepartmentName="Database Programming Branch",Requestor="Tomoko Gale",Description="My account has been locked",RequestDate=DateTime.Parse("2020-01-17 12:17:41 AM")},
                new Ticket{ProjectName="Ever Green",DepartmentName="Hardware Backup Department",Requestor="Claudine Valderrama",Description="Received an email to replace device",RequestDate=DateTime.Parse("2020-01-28 9:03:56 AM")},
                new Ticket{ProjectName="O365 Upgrade",DepartmentName="Wireless Extranet Backup Team",Requestor="Tawna Blackmore",Description="Install office application",RequestDate=DateTime.Parse("2020-02-05 2:31:04 PM")},
                new Ticket{ProjectName="Password Reset",DepartmentName="Branch of Extranet Implementation",Requestor="Kevin Lahr",Description="Locked out of account",RequestDate=DateTime.Parse("2020-02-11 4:25:37 PM")},
                new Ticket{ProjectName="Device Replacement",DepartmentName="Extranet Multimedia Connectivity and Security Division",Requestor="Hugo Wess",Description="Battery Issues",RequestDate=DateTime.Parse("2020-02-19 1:12:01 PM")},
                new Ticket{ProjectName="PC Upgrade",DepartmentName="Software Technology and Networking Department",Requestor="Diego Hasbrouck",Description="Need my laptop upgraded",RequestDate=DateTime.Parse("2020-02-23 11:07:46 AM")},
                new Ticket{ProjectName="Ever Green",DepartmentName="Hardware Backup Department",Requestor="Lana Montes",Description="Received an email to replace device",RequestDate=DateTime.Parse("2020-02-25 3:00:22 PM")},
                new Ticket{ProjectName="O365 Upgrade",DepartmentName="Network Maintenance and Multimedia Implementation Committee",Requestor="Katheryn Lepak",Description="Need help upgrading office application",RequestDate=DateTime.Parse("2020-02-29 5:31:02 PM")},

                
            };
            tickets.ForEach(t => context.Tickets.Add(t));
            context.SaveChanges();
        }
        
    }
}