using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sa47.team8ad.SSIS.Models
{
    
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            
        }

        public int ItemId { get; set; }

        [Display(Name ="Supplier")]
        public int supplierId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Display(Name ="Item Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        [Display(Name = "Reorder Qty")]
        public int ReorderQuantity { get; set; }
        [Display(Name = "Quantity OnHand")]
        public int QuantityOnHand { get; set; }
        [Display(Name = "Unit Name")]
        public int UnitId { get; set; }
        [Display(Name = "Unit Name")]
        public string UnitName { get; set; }

        public int? LocationId { get; set; }
        public string LocationDesc { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }

      //  [Newtonsoft.Json.JsonIgnore]
        public virtual CategoryViewModel Category { get; set; }

    //    [Newtonsoft.Json.JsonIgnore]
      //  public virtual ICollection<DisbursementViewModel> Disbursements { get; set; }

      //  [Newtonsoft.Json.JsonIgnore]
        public virtual ItemLocationViewModel ItemLocation { get; set; }

       // [Newtonsoft.Json.JsonIgnore]
        public virtual MeasurementUnitViewModel MeasurementUnit { get; set; }

       //// [Newtonsoft.Json.JsonIgnore]
       // public virtual ICollection<ItemAdjustmentViewModel> ItemAdjustments { get; set; }

       // [Newtonsoft.Json.JsonIgnore]
     //   public virtual ICollection<ItemRequisitionDetailViewModel> ItemRequisitionDetails { get; set; }

        //[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<SupplierItemViewModel> SupplierItems { get; set; }
    }
}
