using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class EmployeeViewModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public decimal? Salary { get; set; }

        public int DepartmentId { get; set; }

        public int? RepStatus { get; set; }

        public int? DelegationStatus { get; set; }
        
        public string Remark { get; set; }

        public DateTime? AuthorityStartDate { get; set; }
        public DateTime? AuthorityEndDate { get; set; }

       
        public string Status { get; set; }

        public virtual ICollection<EmployeeRoleViewModel> Roles { get; set; }
    }
}