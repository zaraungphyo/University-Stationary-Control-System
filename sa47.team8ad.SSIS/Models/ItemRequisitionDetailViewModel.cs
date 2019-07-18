namespace sa47.team8ad.SSIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class ItemRequisitionDetailViewModel
    {

        public int RequisitionDetailsId { get; set; }

        [Display(Name ="Item Description")]
        public int ItemId { get; set; }

        public int RequisitionId { get; set; }

        [Display(Name = "Needed Quantity")]
        public int NeededQuantity { get; set; }

        [Display(Name = "Actual Quantity")]
        public int ActualQuantity { get; set; }


        public string ApproveStatus { get; set; }


        public DateTime? RetrievalDate { get; set; }


        public string Remark { get; set; }


        public string ReceiveStatus { get; set; }

        public virtual ItemViewModel Item { get; set; }

    //    public virtual ItemRequisitionViewModel ItemRequisition { get; set; }
    }
}
