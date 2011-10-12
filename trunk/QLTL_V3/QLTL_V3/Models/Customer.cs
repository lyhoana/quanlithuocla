using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLTL_V3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Tên"),Required]
        public string Name { get; set; }
        [Display(Name = "Địa Chỉ"),Required]
        public string Address { get; set; }
        [Display(Name = "Mã Số Thuế")]
        public string TaxNo { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNo { get; set; }

        [Display(Name = "Số FAX")]
        public string FaxNo { get; set; }

        [Display(Name = "Mô Tả")]
        public string Description { get; set; }


        public DateTime CreatedTime { get; set; }
        public Customer()
        {
            CreatedTime = DateTime.Now;
        } 
        [Required]
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public ICollection<Order> Orders { get; set; }
       
    }
}