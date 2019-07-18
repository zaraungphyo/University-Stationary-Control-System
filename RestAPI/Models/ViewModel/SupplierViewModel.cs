namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class SupplierViewModel
    {
         public SupplierViewModel()
        {
          
        }
        
        public int SupplierId { get; set; }
        
        [Display(Name ="Supplier")]
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Address { get; set; }
        public string GstRegistrationNo { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public string Email { get; set; }

       //public virtual ICollection<PurchaseOrderViewModel> PurchaseOrders { get; set; }

       //public virtual ICollection<SupplierItemViewModel> SupplierItems { get; set; }
    }
}
