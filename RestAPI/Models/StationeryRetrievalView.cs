using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    //[Table("StationeryRetrievalView")]
    public class StationeryRetrievalView
    {
        public int RequisitionDetailsId { get; set; }
                                           // [Key,Column(Order = 0)]
        public int DepartmentId { get; set; }
       // [Key, Column(Order = 1)]
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public string DepartmentName { get; set; }
        public int ActualQuantity { get; set; }
        public int NeededQuantity { get; set; }
        public int QuantityOnHand { get; set; }
        public string ItemLocation { get; set; }
        public string ReceivedStatus { get; set; }
    }
}