using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sa47.team8ad.SSIS.Models
{
    public class TrendAnalysisReportViewModel
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int RequisitionQuantity { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RequisitionDate { get; set; }

    }
}