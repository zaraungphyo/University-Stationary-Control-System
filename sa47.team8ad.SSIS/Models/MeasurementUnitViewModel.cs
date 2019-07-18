namespace sa47.team8ad.SSIS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MeasurementUnitViewModel
    {
        public MeasurementUnitViewModel()
        {
            //Items = new HashSet<ItemViewModel>();
            //SupplierItems = new HashSet<SupplierItemViewModel>();
        }
        
        public int UnitId { get; set; }

        [Display(Name ="Unit")]
        public string UnitName { get; set; }

        public int UnitQuantity { get; set; }

        //public virtual ICollection<ItemViewModel> Items { get; set; }
        //public virtual ICollection<SupplierItemViewModel> SupplierItems { get; set; }
    }
}
