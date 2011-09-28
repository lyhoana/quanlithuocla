using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNo { get; set; }
        public string OrderDetailId { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }

        public Order()
        {
            Date = DateTime.Now;
        }
       
    }
}