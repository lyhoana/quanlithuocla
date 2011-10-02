﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLTL_V2.Models
{
    public class ProductUnit
    {
        [Key]
        public int ProductUnitId { get; set; }
        [Display(Name = "Đơn Vị")]
        [Required]
        public string Name { get; set; }
    
      
        public DateTime CreatedTime { get; set; }
        public ProductUnit()
        {
            CreatedTime = DateTime.Now;
        } 
        public virtual ICollection<BuyPrice> BuyPrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}