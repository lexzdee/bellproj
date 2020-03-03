using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BellSupportApp.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}