using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QLTL_V3.Models
{
    public class SampleData :DropCreateDatabaseIfModelChanges<DBEntities>
    {
        protected override void Seed(DBEntities context)
        {
            base.Seed(context);
            var cusType = new List<CustomerType>
            {
               new CustomerType { Name = "Vãng lang"},
               new CustomerType { Name = "Đại Lý"}
            
            };

            cusType.ForEach(a => context.CustomerTypes.Add(a));

            context.SaveChanges();

            var listProduct = new List<Product>
            {
               new Product {Code = "Mèo", Name = "Mèo"},
              new Product { Code = "YET",Name = "YET"},
               new Product { Code = "555", Name = "555"},
               new Product { Code = "333",Name = "333"}
            };
            listProduct.ForEach(a => context.Products.Add(a));
            context.SaveChanges();


            var listProductUnit = new List<ProductUnit>
            {
               new ProductUnit { Name = "Thùng"},
              new ProductUnit { Name = "Cây"},
               new ProductUnit { Name = "Gói"}
             
            };
            
            listProductUnit.ForEach(a => context.ProductUnits.Add(a));
            context.SaveChanges();

            foreach (var pro in listProduct)
            {
                foreach (var unit in listProductUnit)
                {
                    foreach (var type in cusType)
                    {
                        BuyPrice p = new BuyPrice { ProductId = pro.ProductId, ProductUnitId = unit.ProductUnitId, CustomerTypeId = type.CustomerTypeId, Price  = new Random().Next(4,10) };
                        context.BuyPrices.Add(p);
                        
                    }
                }
            }            
            
           context.SaveChanges();

           foreach (var pro in listProduct)
           {
               foreach (var unit in listProductUnit)
               {
                   Store s = new Store { ProductId = pro.ProductId , ProductUnitId = unit.ProductUnitId, Amount = new Random().Next(50,100)};
                   context.Stores.Add(s);
               }
           }

           context.SaveChanges();

            var listCustomer = new List<Customer>
            {
               new Customer { Name = "NGUYỄN VĂN A",Address = "112 QUẬN GÒ VẤP",CustomerTypeId = 1,PhoneNo="0605456879"},
               new Customer { Name = "NGUYỄN VĂN B",Address = "113 QUÂN 1",CustomerTypeId = 2,PhoneNo="0605456879"},
               new Customer { Name = "TRẦN VĂN C",Address = "114 QUẬN 7",CustomerTypeId = 2,PhoneNo="0605456879"},
              
            };
            

            listCustomer.ForEach(a => context.Customers.Add(a));
            context.SaveChanges();


            

        }
     
    }
}