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

        [Display(Name = "Mã Khác Hàng")]
        public int? CustomerId { get; set; }
        [Display(Name = "Tên Khác Hàng")]
        public string Name { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        
        public string OrderDetailId { get; set; }

        [Display(Name = "Ngày Giờ")]
        public DateTime Date { get; set; }

       
        

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }

        public Order()
        {
            Date = DateTime.Now;
        }
       
    }
}