namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemRequisitionDetail")]
    public partial class ItemRequisitionDetail
    {
        [Key]
        public int RequisitionDetailsId { get; set; }

        public int ItemId { get; set; }

        public int RequisitionId { get; set; }

        public int NeededQuantity { get; set; }

        public int ActualQuantity { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RetrievalDate { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string ReceiveStatus { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemRequisition ItemRequisition { get; set; }
    }
}
