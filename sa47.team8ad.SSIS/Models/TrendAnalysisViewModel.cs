using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sa47.team8ad.SSIS.Models
{
    public class TrendAnalysisViewModel
    {
        [Required(ErrorMessage = "Departments selection is required")]
        [DisplayName("Departments")]
        public List<int> DepartmentIds { get; set; }
        [Required(ErrorMessage = "Item selection is required")]
        [DisplayName("Item")]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Start Date field is required")]
        [DisplayName("From Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date field is required")]
        [DisplayName("To Date")]        
        public DateTime EndDate { get; set; }
    }
}