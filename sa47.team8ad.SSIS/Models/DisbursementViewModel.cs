namespace sa47.team8ad.SSIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DisbursementViewModel
    {
        public int DisbursementId { get; set; }

        public int ItemId { get; set; }

        [Display(Name ="Item Desc")]
        public string ItemDescription { get; set; }

        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public string QRCode { get; set; }
        [Display(Name = "Actual Quantity")]
        public int? ActualQuantity { get; set; }
        [Display(Name = "Needed Quantity")]
        public int? NeededQuantity { get; set; }
        [Display(Name = "Quantity OnHand")]
        public int QuantityOnHand { get; set; }
        public int ReturnQuantity { get; set; }

        [Display(Name = "Outstanding Amount")]
        public int OutstandingAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RetrievalDate { get; set; }

        public string ACKStatus { get; set; }

        public string Status { get; set; }

        public string Remark { get; set; }

        public string Reason { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CollectDate { get; set; }

        //public virtual Department Department { get; set; }

        public virtual ItemViewModel Item { get; set; }
    }
}
