using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V2.Models;
using System.Data;
using QLTL_V2.ViewModel;

namespace QLTL_V2.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {


            var orders = db.Orders.Include("Customer").ToList();
            return View(orders);
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
            Order order = db.Orders.Find(OrderRefId);
            int customerTypeId = order.Customer.CustomerTypeId;
            var p1 = (from p in db.BuyPrices
                      where p.ProductUnitId == ProductUnitId && p.ProductId == ProductId && p.CustomerTypeId == customerTypeId
                      select p).Single();
            if (p1 == null)
            {
                ViewBag.ErrMsg = "Chưa khai báo giá cho mặt hàng này";
                return PartialView("_OrderDetailPartial", order.OrderDetails.ToList());
            }

            var store = db.Stores.Single(o => o.ProductUnitId == ProductUnitId && o.ProductId == ProductId);

            if (store == null || store.Amount < Amount)
            {
                ViewBag.ErrMsg = "Số lượng bán lớn hơn số lượng tồn tại trong kho, vui lòng nhập hàng !!!!";
                return PartialView("_OrderDetailPartial", order.OrderDetails.ToList());

            }
            else
            {
                store.Amount = store.Amount - Amount;
                db.Entry(store).State = EntityState.Modified;
            }


            var p2 = (from p in db.OrderDetails
                     where p.OrderId == OrderRefId && p.ProductId == ProductId && p.ProductUnitId == ProductUnitId
                     select p);

            if( p2.Count() <= 0){

            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderId = OrderRefId;
            orderDetail.ProductId = ProductId;
            orderDetail.ProductUnitId = ProductUnitId;
            orderDetail.Price = p1.Price;
            orderDetail.Amount = Amount;
            db.OrderDetails.Add(orderDetail);
            }else{
                p2.First().Amount = p2.First().Amount + Amount;
                db.Entry(p2.First()).State = EntityState.Modified;
            }
            db.SaveChanges();
            var l = db.OrderDetails.Include("Product").Include("ProductUnit").Where(o => o.OrderId == OrderRefId);
            return PartialView("_OrderDetailPartial",l.ToList());

        }

        public PartialViewResult RemoveItem(int id)

        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            int OrderRefId = orderDetail.OrderId;
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            var l = db.OrderDetails.Where(o => o.OrderId == OrderRefId);
            return PartialView("_OrderDetailPartial", l.ToList());

        }

        public PartialViewResult Search(string CusName, DateTime? OrderDate)
        {
            List<Order> result = db.Orders.ToList();
            if (OrderDate != null)
            {
                DateTime tmp = (DateTime)OrderDate;
                result = result.Where(o => o.CreatedTime.Date == tmp.Date).ToList() ;
            }
            if (CusName != "")
            {
                result = result.Where(o => o.Customer.Name.ToUpper().Contains(CusName.ToString().ToUpper())).ToList();
            }

            return PartialView("_OrderPartial", result);

        }

        public ActionResult Delete(int OrderId)
        {
            Order order = db.Orders.Find(OrderId);
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int OrderId)
        {
            Order order = db.Orders.Find(OrderId);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
       
       

    }
}
