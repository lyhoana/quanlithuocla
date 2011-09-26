using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExamples.Models;
using MvcExamples.ViewModel;
namespace MvcExamples.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private DBEntities db = new DBEntities();

        public ActionResult Index()
        {
            var customers = db.Orders;
            return View(customers.ToList());
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers,"CustomerId", "Name");
            return View();
        } 

        //
        // POST: /Order/Create

       

        [HttpPost]
        public ActionResult Create(FormCollection collection, Order order , int? ProductId, int? ProductUnitId, int? Amount, int? OrderId)
        {
            if (!OrderId.HasValue)
            {

                if (ModelState.IsValid)
                {
                    Customer cus = db.Customers.Find(order.CustomerId);
                    if (cus != null)
                    {
                        order.Name = cus.Name;
                        order.Address = cus.Address;
                        order.Customer = cus;
                        
                    }
                    db.Orders.Add(order);
                    db.SaveChanges();
                    ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
                    ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
                    ViewBag.Orderid = order.OrderId;

                    return View(order);
                }
                else
                {
                    ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
                    return View(order);
                }
            }
            else
            {
                OrderDetail detail = new OrderDetail();
                detail.ProductId = (int)ProductId;
                int CustomerTypeId = 1;
                Customer cus = db.Customers.Find(ProductId);
                if (cus != null)
                {
                    CustomerTypeId = cus.CustomerTypeId;
                }
                detail.Product = db.Products.Find(detail.ProductId);               
                detail.ProductUnitId = (int)ProductUnitId;
                detail.ProductUnit = db.ProductUnits.Find(detail.ProductUnitId);
                //var price = db.BuyPrices.Single((g => g.CustomerTypeId == CustomerTypeId);
                var p1 = (from p in db.BuyPrices where p.ProductUnitId == ProductUnitId && p.ProductId == ProductId && p.CustomerTypeId ==CustomerTypeId
                                   select p);

                detail.OrderId = (int)OrderId;
                detail.Amount = (int)Amount;
                if (p1.Count() > 0)
                {

                    detail.Price = detail.Amount * p1.First().Price;
                }
               

                db.OrderDetails.Add(detail);
                db.SaveChanges();
              
                ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
                ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
                ViewBag.Orderid = order.OrderId;
                order = db.Orders.Find(OrderId);
                return View(order);
            }
           
            

        }

        [HttpPost]
        public ActionResult Govalidate(FormCollection collection,Order order)
        {
           try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Order/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
