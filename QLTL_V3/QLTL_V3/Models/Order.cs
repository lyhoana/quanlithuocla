using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLTL_V3.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }    

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }
       
        public DateTime CreatedTime { get; set; }
        public Order()
        {
            CreatedTime = DateTime.Now;
        }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Tổng Tiền")]
        public virtual decimal TotalAmount
        {            
            get
            {
                decimal result = 0;
                foreach (var item in OrderDetails)
                {
                    result = result + item.TotalDetailAmount;
                }
                return result;
            }
        }
       
    }
}