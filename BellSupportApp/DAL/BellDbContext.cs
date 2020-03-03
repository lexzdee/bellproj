using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BellSupportApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BellSupportApp.DAL
{
    public class BellDbContext : DbContext
    {
        public BellDbContext() : base("BellDbContext") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}