namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupplierItem")]
    public partial class SupplierItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierItem()
        {
             PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
           
        }

        public int SupplierItemId { get; set; }

        public int SupplierId { get; set; }

        public int ItemId { get; set; }

        public int UnitId { get; set; }

        public decimal TenderPrice { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        public int Priority { get; set; }

        public virtual Item Item { get; set; }

        public virtual MeasurementUnit MeasurementUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
