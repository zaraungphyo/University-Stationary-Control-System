using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class TrendAnalysisReportViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int RequisitionQuantity { get; set; }
        public DateTime RequisitionDate { get; set; }

    }
}