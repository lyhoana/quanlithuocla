using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models
{
    public class BuyPrice
    {
        [Key]      
        public int BuyPriceId { get; set; }        
 
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public int ProductUnitId { get; set; }
        public virtual ProductUnit ProductUnit{ get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Đơn giá")]
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public BuyPrice()
        {
            CreatedTime = DateTime.Now;
        } 
    
    }
}