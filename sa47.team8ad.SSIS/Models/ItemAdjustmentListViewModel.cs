using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;



namespace sa47.team8ad.SSIS.Models
{
    public class ItemAdjustmentListViewModel
    {
        public int ItemId { get; set; }

        [DisplayName("Item")]
        public string ItemDescription { get; set; }

        [DisplayName("Adjustment Quantity")]
        public int Amount { get; set; }

        [DisplayName("Unit of Measure")]
        public string UnitName { get; set; }

        [DisplayName("Average Price")]
        public decimal AveragePrice { get; set; }

        [DisplayName("Adjustment Value")]
        public decimal AdjustmentValue { get; set; }

        public string Remark { get; set; }


    }
}
