namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrder")]
    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public int PurchaseOrderId { get; set; }

        public string EmployeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseOrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpectedDate { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

       // public int SupplierId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeModel Employee { get; set; }

    //    public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
