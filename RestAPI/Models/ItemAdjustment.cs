namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemAdjustment")]
    public partial class ItemAdjustment
    {
        public int ItemAdjustmentId { get; set; }

        public int ItemId { get; set; }

        public int AdjustmentQuantity { get; set; }

        [StringLength(300)]
        public string Reason { get; set; }

        [Column(TypeName = "date")]
        public DateTime ItemAdjustmentDate { get; set; }

        public string EmployeeId { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeModel Employee { get; set; }

        public virtual Item Item { get; set; }
    }
}
