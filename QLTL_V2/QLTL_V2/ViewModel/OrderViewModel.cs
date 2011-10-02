using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLTL_V2.Models;

namespace QLTL_V2.ViewModel
{
    public class OrderViewModel : Order
    {
        public string CustomerType
        {
            get
            {
                return "abc";
            }
        }
    }
}