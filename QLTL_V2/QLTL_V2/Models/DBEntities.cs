using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QLTL_V2.Models
{
    public class DBEntities : DbContext
    {
        public DbSet<BuyPrice> BuyPrices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes{ get; set; }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
      
        // remove cac table co ten la so nhieu
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         //   modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
        public DbSet<Store> Stores { get; set; }

       

    }
}