using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExamples.Models;

namespace MvcExamples.Controllers
{ 
    public class OrderDetailController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /OrderDetail/

        public ViewResult Index(int? id)
        {
            var orderdetails = db.OrderDetails.Include(o => o.Product).Include(o => o.ProductUnit).Include(o => o.Order).Where(o => o.OrderId==id);
            return View(orderdetails.ToList());
        }

        //
        // GET: /OrderDetail/Details/5

        public ViewResult Details(int id)
        {
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            return View(orderdetail);
        }

        //
        // GET: /OrderDetail/Create

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code");
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name");
            return View();
        } 

        //
        // POST: /OrderDetail/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, int? ProductId, int? ProductUnitId, int? Amount, int? OrderId, int ?CustomerId)
        {

            int CustomerTypeId = 1;
            if (CustomerId != null)
            {
                CustomerTypeId = db.Customers.Find(CustomerId).CustomerTypeId;
            }

            var p1 = (from p in db.BuyPrices
                      where p.ProductUnitId == ProductUnitId && p.ProductId == ProductId && p.CustomerTypeId == CustomerTypeId
                      select p);

            
            if (p1.Count() > 0)
            {
                OrderDetail detail = new OrderDetail
                {
                    OrderId = (int)OrderId,
                    ProductId = (int)ProductId,
                    ProductUnitId = (int)ProductUnitId,
                    Product = db.Products.Find(ProductId),
                    ProductUnit = db.ProductUnits.Find(ProductUnitId),
                    Amount = (int)Amount,
                    Price = p1.First().Price

                };
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                Order order = db.Orders.Include(p => p.OrderDetails).Single(p => p.OrderId == OrderId);
                
                ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name");
                ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
                ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
                return View("../Order/Create", order);
            }
            else
            {
                ViewBag.Message = "Chưa khai báo giá cho sản phẩm này";
                Order order = db.Orders.Find(OrderId);
                ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name");
                ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
                ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
                return View("../Order/Create", order);
            }            

          
            
        }
        
        //
        // GET: /OrderDetail/Edit/5
 
        public ActionResult Edit(int id)
        {
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", orderdetail.ProductId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", orderdetail.ProductUnitId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name", orderdetail.OrderId);
            return View(orderdetail);
        }

        //
        // POST: /OrderDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderDetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetail).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
                ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
                Order order = db.Orders.Find(orderdetail.OrderId);
                ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
                return View("../Order/Create", order);
            }
          
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name", orderdetail.OrderId);
            return View(orderdetail);
        }

        //
        // GET: /OrderDetail/Delete/5
 
        public ActionResult Delete(int id)
        {
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            return View(orderdetail);
        }

        //
        // POST: /OrderDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            int orderId = orderdetail.OrderId;
            db.OrderDetails.Remove(orderdetail);
            db.SaveChanges();
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");

            
            return View("../Order/Create",db.Orders.Find(orderId));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}