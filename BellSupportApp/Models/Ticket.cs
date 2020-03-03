using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BellSupportApp.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
     
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        
        [Required]
        [Display(Name = "Employee")]
        public string Requestor { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }
        public virtual ICollection<Department> Departments { get; set; }        
        public virtual ICollection<Employee> Employees { get; set; }
        
    }
}