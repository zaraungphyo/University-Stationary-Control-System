using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            //Disbursements = new HashSet<DisbursementViewModel>();
            //ItemAdjustments = new HashSet<ItemAdjustmentViewModel>();
            //ItemRequisitionDetails = new HashSet<ItemRequisitionDetailViewModel>();
            //SupplierItems = new HashSet<SupplierItemViewModel>();
        }

        public int ItemId { get; set; }
        public int supplierId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string ItemDescription { get; set; }


        public int ReorderLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public int QuantityOnHand { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int? LocationId { get; set; }
        public string LocationDesc { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public virtual MeasurementUnitViewModel MeasurementUnit { get; set; }
        public virtual ICollection<SupplierItemViewModel> SupplierItems { get; set; }

        //public virtual CategoryViewModel Category { get; set; }
        //public virtual ICollection<DisbursementViewModel> Disbursements { get; set; }

        //public virtual ItemLocationViewModel ItemLocation { get; set; }

        //public virtual MeasurementUnitViewModel MeasurementUnit { get; set; }
        //public virtual ICollection<ItemAdjustmentViewModel> ItemAdjustments { get; set; }
        //public virtual ICollection<ItemRequisitionDetailViewModel> ItemRequisitionDetails { get; set; }
        //public virtual ICollection<SupplierItemViewModel> SupplierItems { get; set; }
    }
}