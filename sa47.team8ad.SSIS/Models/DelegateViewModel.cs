using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sa47.team8ad.SSIS.Models
{
    public class DelegateViewModel
    {
       // public string Id { get; set; }


        [Display(Name ="Delegate To")]
        public string Id { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }
        public string  EmployeeName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime AuthorityStartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime AuthorityEndDate { get; set; }

        [Display(Name = "Reason")]
        public string Remark { get; set; }
    }
}