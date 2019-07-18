namespace RestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Disbursement")]
    public partial class Disbursement
    {
        public int DisbursementId { get; set; }

        public int ItemId { get; set; }

        public int DepartmentId { get; set; }

        [StringLength(10)]
        public string QRCode { get; set; }

        public int? ActualQuantity { get; set; }

        public int? NeededQuantity { get; set; }

        public int ReturnQuantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RetrievalDate { get; set; }

        [StringLength(10)]
        public string ACKStatus { get; set; }
        
        public int Status { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        [StringLength(300)]
        public string Reason { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CollectDate { get; set; }

        public virtual Department Department { get; set; }

        public virtual Item Item { get; set; }
    }
}
