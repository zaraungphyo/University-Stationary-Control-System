using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    public class PurchaseOrderViewModel
    {
        public int PurchaseOrderId { get; set; }

        public string EmployeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseOrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpectedDate { get; set; }
        
        public string Status { get; set; }
        
        public string Remark { get; set; }

        // public int SupplierId { get; set; }
        
        public virtual EmployeeModel Employee { get; set; }
        
        public virtual ICollection<PurchaseOrderDetailViewModel> PurchaseOrderDetails { get; set; }
    }
}