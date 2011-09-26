using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
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