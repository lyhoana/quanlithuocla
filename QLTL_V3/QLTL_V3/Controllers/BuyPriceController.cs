using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V3.Models;
using QLTL_V3.ViewModel;

namespace QLTL_V3.Controllers
{
    public class BuyPriceController : Controller
    {
        //
        // GET: /BuyPrice/
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPrice(int ProductId, int ProductUnitId, int CustomerTypeId)
        {
            var p = db.BuyPrices.Where(c => c.ProductId == ProductId).Where(c => c.ProductUnitId == ProductUnitId).Where(c => c.CustomerTypeId==CustomerTypeId);
            decimal result = -1;
            if (p != null)
            {
                result = p.First().Price;
            }

            BuyPriceModelView s = new BuyPriceModelView { Price = result };
            return Json(s);
        }

    }
}
