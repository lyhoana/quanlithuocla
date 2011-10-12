using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLTL_V3.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Required(ErrorMessage = "Vui Lòng nhập tên sản phẩm.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Vui Lòng nhập tên đơn vị.")]
        [Display(Name = "Đơn vị")]
        public int ProductUnitId { get; set; }

        [Required(ErrorMessage = "Vui Lòng nhập số lượng.")]
        [Display(Name = "Số lượng tồn kho")]
        public int Amount { get; set; }

        public DateTime CreatedTime { get; set; }
        public Store()
        {
            CreatedTime = DateTime.Now;
        }
        
        public virtual Product Product { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
    }
}