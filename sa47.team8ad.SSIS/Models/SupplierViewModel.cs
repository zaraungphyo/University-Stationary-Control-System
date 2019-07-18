namespace sa47.team8ad.SSIS.Models
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
            //PurchaseOrders = new HashSet<PurchaseOrderViewModel>();
            //SupplierItems = new HashSet<SupplierItemViewModel>();
        }

        public int SupplierId { get; set; }

        [Display(Name = "Supplier")]
        [Required]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Contact Person is required")]
        [Display(Name = "Contact Person")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        [Display(Name = "Fax Number")]
        public string FaxNo { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "GST Reg No")]
        public string GSTRegistrationNo { get; set; }

        [Display(Name = "Status")]
        [StringLength(20)]
        [Required]
        public string Status { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(300)]
        public string Remark { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public virtual ICollection<PurchaseOrderViewModel> PurchaseOrders { get; set; }

       public virtual ICollection<SupplierItemViewModel> SupplierItems { get; set; }
    }
}
