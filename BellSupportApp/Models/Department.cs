using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BellSupportApp.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentID { get; set; }
        
        public string DepartmentName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}