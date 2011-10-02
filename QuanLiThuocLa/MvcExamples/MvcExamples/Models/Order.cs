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
        int CustomerId { get; set; }

       

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime CreatedTime { get; set; }
        public Order()
        {
            CreatedTime = DateTime.Now;
        } 
       
    }
}