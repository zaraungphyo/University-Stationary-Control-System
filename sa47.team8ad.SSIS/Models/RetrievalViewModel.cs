using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sa47.team8ad.SSIS.Models
{
    public class RetrievalViewModel
    {
        public int DepartmentId { get; set; }
        public int RequisitionDetailsId { get; set; }
        public int ItemId { get; set; }

        [Display(Name ="Stationery Desc")]
        public string ItemDescription { get; set; }

        [Display(Name ="Department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Actual Quantity")]
        public int ActualQuantity { get; set; }

        [Display(Name = "Needed Quantity")]
        public int NeededQuantity { get; set; }
        [Display(Name = "Quantity On Hand")]
        public int QuantityOnHand { get; set; }

        public ICollection<ItemViewModel> items { get; set; }
    }
}