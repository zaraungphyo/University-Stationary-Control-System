namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrderDetail
    {

        [Key]
        public int PurchaseOrderDetailsId { get; set; }

        public int SupplierItemId { get; set; }

        public int PurchaseItemQuantity { get; set; }
        public int? QuantityDelivered { get; set; }

        public int PurchaseOrderId { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
    }
}
