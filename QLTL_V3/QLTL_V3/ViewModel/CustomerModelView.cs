using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTL_V3.ViewModel
{
    public class CustomerModelView
    {
        public int CustomerId {get;set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string CustomerTypeName { get; set; }
        public int CustomerTypeId { get; set; }
    }
}