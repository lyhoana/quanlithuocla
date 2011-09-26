using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<BuyPrice> BuyPrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }



    }
}