namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Disbursements = new HashSet<Disbursement>();
            ItemAdjustments = new HashSet<ItemAdjustment>();
            ItemRequisitionDetails = new HashSet<ItemRequisitionDetail>();
            SupplierItems = new HashSet<SupplierItem>();
         //   PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        [Key]
        public int ItemId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemDescription { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }

        public int QuantityOnHand { get; set; }

        public int UnitId { get; set; }

        public int? LocationId { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement> Disbursements { get; set; }

        public virtual ItemLocation ItemLocation { get; set; }

        public virtual MeasurementUnit MeasurementUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemAdjustment> ItemAdjustments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequisitionDetail> ItemRequisitionDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierItem> SupplierItems { get; set; }

    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }

    }
}
