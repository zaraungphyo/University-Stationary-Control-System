using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Thett Oo Eain
namespace RestAPI.Models
{
    public class CategoryItemViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int ItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemDescription { get; set; }

        public int QuantityOnHand { get; set; }
       
        public int AdjustmentQuantity { get; set; }


        public DateTime? ItemAdjustmentDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(300)]
        public string Reason { get; set; }

        public string EmployeeId { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemAdjustment ItemAdjustment { get;set;}
        public virtual EmployeeViewModel Employee { get; set; }
    }
}