using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ItemRequisitionsViewModel
    {

         public ItemRequisitionsViewModel()
        {
           
        }

        public int RequisitionId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string ApproveStatus { get; set; }

        public int FormStatus { get; set; }

        public int Status { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string Remark { get; set; }
        public virtual EmployeeModel Employee { get; set; }

       //public virtual ICollection<ItemRequisitionDetail> ItemRequisitionDetails { get; set; }
    }
}