using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models
{
    public class CustomerType
    {
        [Key]
        public int CustomerTypeId { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Mô Tả")]
        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }
        public CustomerType()
        {
            CreatedTime = DateTime.Now;
        } 
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<BuyPrice> BuyPrices { get; set; } // quan he nhieu nhieu nhieu
      
        
       

    }
}