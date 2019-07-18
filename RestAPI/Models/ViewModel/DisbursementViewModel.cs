using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class DisbursementViewModel
    {
        public int DisbursementId { get; set; }

        public int ItemId { get; set; }
        public string ItemDescription { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string QRCode { get; set; }

        public int? ActualQuantity { get; set; }

        public int? NeededQuantity { get; set; }

        public int ReturnQuantity { get; set; }
        public int QuantityOnHand { get; set; }
        public int OutstandingAmount { get; set; }

        public DateTime? RetrievalDate { get; set; }
        
        public string ACKStatus { get; set; }
        
        public int Status { get; set; }
        
        public string Remark { get; set; }
        
        public string Reason { get; set; }
        public DateTime? CollectDate { get; set; }
        public string collectionpoint { get; set; }
        //public virtual Department Department { get; set; }

        //public virtual ItemViewModel Item { get; set; }
    }
}