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
        public string Name { get; set; }

        public DateTime DateTime { get; set; }      

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<BuyPrice> BuyPrices { get; set; } // quan he nhieu nhieu nhieu
      
        
        public CustomerType()
        {
            DateTime = DateTime.Now;
        }
        

    }
}