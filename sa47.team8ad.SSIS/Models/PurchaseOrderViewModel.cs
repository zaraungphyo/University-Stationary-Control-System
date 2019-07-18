namespace sa47.team8ad.SSIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class PurchaseOrderViewModel
    {
        public PurchaseOrderViewModel()
        {
           // PurchaseOrderDetails = new HashSet<PurchaseOrderDetailViewModel>();
        }

        public int PurchaseOrderId { get; set; }

        public string EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseOrderDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpectedDate { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        public int SupplierId { get; set; }

        public virtual EmployeeViewModel Employee { get; set; }

       // public virtual Supplier Supplier { get; set; }

       public virtual ICollection<PurchaseOrderDetailViewModel> PurchaseOrderDetails { get; set; }
    }
}
