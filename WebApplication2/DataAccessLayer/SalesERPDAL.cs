using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2.Models;

namespace WebApplication2.DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Employee>().ToTable("T_Employee");
            base.OnModelCreating(modelBuilder);
        }
        public SalesERPDAL()
            : base("NewName") 
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}