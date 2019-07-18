namespace sa47.team8ad.SSIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

 
    public partial class ItemRequisitionViewModel
    {
      
        public ItemRequisitionViewModel()
        {
          
        }
        public int RequisitionId { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequisitionDate { get; set; }

        [StringLength(10)]
        public string ApproveStatus { get; set; }
        
        public int FormStatus { get; set; }
        
        public int Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApproveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReceiveDate { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

    
        public virtual EmployeeViewModel Employee { get; set; }

       
    }
}
