using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLTL_V2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Mã Sản Phẩm")]
        public string Code { get; set; }    

        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }


        [Display(Name = "Hình Ảnh")]
        public string ImageUrl { get; set; }

        [Display(Name = "Mô Tả")]
        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }
        public Product()
        {
            CreatedTime = DateTime.Now;
        } 

        public virtual ICollection<BuyPrice> BuyPrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }



    }
}