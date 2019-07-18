namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemRequisitions")]
    public partial class ItemRequisition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemRequisition()
        {
            ItemRequisitionDetails = new HashSet<ItemRequisitionDetail>();
        }

        [Key]
        public int RequisitionId { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequisitionDate { get; set; }

        [StringLength(10)]
        public string ApproveStatus { get; set; }
        
        public int FormStatus { get; set; }
        
        public int Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApproveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceiveDate { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeModel Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequisitionDetail> ItemRequisitionDetails { get; set; }
    }
}
