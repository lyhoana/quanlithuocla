using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLTL_V2.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Số Lượng")]
        public int Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]

        [Display(Name = "Đơn giá")]
        public decimal Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]


        [Display(Name = "Thành Tiền")]
       
        public decimal TotalDetailAmount
        {
            get
            {
                return Amount * Price;
            }
        }


        
       
        public virtual Product Product { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual Order Order { get; set; }
       

        
    }
};