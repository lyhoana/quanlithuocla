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

        [Display(Name = "Mã Sản Phẩm")]
        public string Code { get; set; }    

        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
    
        public virtual ICollection<BuyPrice> BuyPrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }



    }
}