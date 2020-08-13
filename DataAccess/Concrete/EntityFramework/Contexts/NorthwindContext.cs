using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
   public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //RUKIYE\SQLEXPRESS01
            //(optionsBuilder).UseSqlServer(connectionString:@"Server=(localdb)\mssqllocaldb;Database = Northwind; Trusted_Connection=true");
            (optionsBuilder).UseSqlServer(connectionString: @"Server=RUKIYE\SQLEXPRESS01;Database = Northwind; Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
