using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sa47.team8ad.SSIS.Models
{
    public class EmployeeViewModel
    {
        public string id { get; set; }
        [Display(Name = "Login UserName")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name ="Full Name")]
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public decimal? Salary { get; set; }
        public int DepartmentId { get; set; }
        public int? RepStatus { get; set; }
        public int? DelegationStatus { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        [Display(Name="Old Password")]
        public string OldPassword { get; set; }
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        public DateTime? AuthorityStartDate { get; set; }
        public DateTime? AuthorityEndDate { get; set; }

        public virtual ICollection<EmployeeRoleViewModel> Roles { get; set; }
    }
}