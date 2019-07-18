using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ItemAdjustmentListViewModel
    {
        public int ItemId { get; set; }

        public string ItemDescription { get; set; }

        public int Amount { get; set; }

        public string UnitName { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal AdjustmentValue { get; set; }

        public string Remark { get; set; }
    }
}