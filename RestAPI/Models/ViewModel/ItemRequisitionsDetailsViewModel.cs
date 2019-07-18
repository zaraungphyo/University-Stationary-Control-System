using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ItemRequisitionsDetailsViewModel
    {

        public int RequisitionDetailsId { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int RequisitionId { get; set; }

        public int NeededQuantity { get; set; }

        public int ActualQuantity { get; set; }

       
        public string ApproveStatus { get; set; }

      
        public DateTime? RetrievalDate { get; set; }

     
        public string Remark { get; set; }

     
        public string ReceiveStatus { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemRequisition ItemRequisition { get; set; }

    }
}