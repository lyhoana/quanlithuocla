using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcExamples.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        [Display(Name = "Mã Số Thuế")]
        public string TaxNo { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNo { get; set; }

        [Display(Name = "Số FAX")]
        public string FaxNo { get; set; }

        public int CustomerTypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; }
        public ICollection<Order> Orders { get; set; }
       
    }
}