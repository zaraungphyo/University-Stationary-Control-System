using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class SuppliedItemPriceModel
    {
        public int ItemId { get; set; }
        public decimal AveItemPrice { get; set; }
    }
}