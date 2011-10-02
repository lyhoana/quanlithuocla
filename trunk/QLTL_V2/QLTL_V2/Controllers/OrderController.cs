using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V2.Models;

namespace QLTL_V2.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FirstCreate(int id)
        {
            Order order = new Order();
            order.CustomerId = id;
            order.Customer = db.Customers.Find(id);
            db.Orders.Add(order);
            db.SaveChanges();
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
            ViewBag.ProductId= new SelectList(db.Products, "ProductId", "Name");
            ViewBag.OrderId = order.OrderId;
            return RedirectToAction("Create", new { OrderId = order.OrderId});
        }


        public ActionResult Create(int OrderId)
        {
            Order order = db.Orders.Single(o => o.OrderId == OrderId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.OrderId = order.OrderId;
            return View(order);
        }


        public PartialViewResult AddItem(int ProductId, int ProductUnitId, int Amount, int OrderRefId)
        {
            
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderId = OrderRefId;
            orderDetail.ProductId = ProductId;
            orderDetail.ProductUnitId = ProductUnitId;
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();
            var l = db.OrderDetails.Where(o => o.OrderId == OrderRefId);
            return PartialView("_OrderDetailPartial",l.ToList());

        }

       
       

    }
}
