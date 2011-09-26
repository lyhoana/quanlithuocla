using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcExamples.Models;

namespace MvcExamples.ViewModel
{
    public class OrderDataIndex
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}