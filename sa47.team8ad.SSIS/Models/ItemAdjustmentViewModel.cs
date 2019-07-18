namespace sa47.team8ad.SSIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemAdjustmentViewModel
    {
        public int ItemAdjustmentId { get; set; }

        public int ItemId { get; set; }
        public string ItemDescription { get; set; }

        [Display(Name = "Adjustment Quantity")]
        public int AdjustmentQuantity { get; set; }
        
        public string Reason { get; set; }

        [Column(TypeName = "date")]
        public DateTime ItemAdjustmentDate { get; set; }

        public string EmployeeId { get; set; }
        
        public string Status { get; set; }
        
        public string Remark { get; set; }
        
        public virtual EmployeeViewModel Employee { get; set; }

        public virtual ItemViewModel Item { get; set; }
    }
}
