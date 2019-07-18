using System;
namespace sa47.team8ad.SSIS.Models
{
    public class ReorderReportViewModel
    {
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public int PurchaseQuantity { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime ExpectedDate { get; set; }
    }
}