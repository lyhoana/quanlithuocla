using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcExamples.Models
{
    public class SampleData :DropCreateDatabaseIfModelChanges<DBEntities>
    {
        protected override void Seed(DBEntities context)
        {
            var cusType = new List<CustomerType>
            {
               new CustomerType { Name = "Vãng lang"},
              new CustomerType { Name = "Dai Ly"}
            
            };

            cusType.ForEach(a => context.CustomerTypes.Add(a));

            context.SaveChanges();

            var listProduct = new List<Product>
            {
               new Product { Name = "Thuoc Meo"},
              new Product { Name = "YET"},
               new Product { Name = "555"},
               new Product { Name = "333"}
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
            
            var listPrice = new List<BuyPrice>
           {
               new BuyPrice {ProductId = 1,ProductUnitId  = 3 ,CustomerTypeId=1, Price = 120000},
               new BuyPrice {ProductId = 1,ProductUnitId  = 2 ,CustomerTypeId=1,  Price = 50000},
               new BuyPrice {ProductId = 1,ProductUnitId  = 1 ,CustomerTypeId=1,  Price = 5500},
               new BuyPrice {ProductId = 2,ProductUnitId  = 3 ,CustomerTypeId=1, Price = 120000},
               new BuyPrice {ProductId = 2,ProductUnitId  = 2 ,CustomerTypeId=1,  Price = 50000},
               new BuyPrice {ProductId = 2,ProductUnitId  = 1 ,CustomerTypeId=1,  Price = 5500},
               new BuyPrice {ProductId = 2,ProductUnitId  = 1 ,CustomerTypeId=2,  Price = 5500},
              

           };
            listPrice.ForEach(a => context.BuyPrices.Add(a));
           context.SaveChanges();

            var listCustomer = new List<Customer>
            {
               new Customer { Name = "Customer 1",Address = "Adress",CustomerTypeId = 1,PhoneNo="000000"},
               new Customer { Name = "Customer 2",Address = "Adress",CustomerTypeId = 2,PhoneNo="000000"},
               new Customer { Name = "Cusomter 3",Address = "Adress",CustomerTypeId = 2,PhoneNo="000000"},
              
            };
            

            listCustomer.ForEach(a => context.Customers.Add(a));
            context.SaveChanges();


            var listMenu = new List<Menu>
            {
               new Menu { Text="Bán Hàng",Url="Order"},
               new Menu { Text="Mua Hàng",Url="Order"},
               new Menu { Text="Báo Cáo",Url="Order"}
              
            };

            listMenu.ForEach(a => context.Menus.Add(a));
            context.SaveChanges();


        }
     
    }
}