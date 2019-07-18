using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class PurchaseOrderDetailViewModel
    {
        public int PurchaseOrderDetailsId { get; set; }

        public int SupplierItemId { get; set; }

        public int PurchaseItemQuantity { get; set; }
        public int QuantityDelivered { get; set; }

        public int PurchaseOrderId { get; set; }
        
        public string Status { get; set; }
        
        public string Remark { get; set; }

        //public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual SupplierItemViewModel SupplierItem { get; set; }
    }
}