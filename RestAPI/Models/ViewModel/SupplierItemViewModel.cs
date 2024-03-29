namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class SupplierItemViewModel
    {
        public SupplierItemViewModel()
        {
          //  PurchaseOrderDetails = new HashSet<PurchaseOrderDetailViewModel>();
        }

        public int SupplierItemId { get; set; }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public int ItemId { get; set; }
        public string ItemDescription { get; set; }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public decimal TenderPrice { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }
        //hana
        public int Priority { get; set; }
        //ucmt by zap
        public virtual ItemViewModel Item { get; set; }

        //public virtual MeasurementUnitViewModel MeasurementUnit { get; set; }

      //public virtual ICollection<PurchaseOrderDetailViewModel> PurchaseOrderDetails { get; set; }

        public virtual SupplierViewModel Supplier { get; set; }
    }
}
