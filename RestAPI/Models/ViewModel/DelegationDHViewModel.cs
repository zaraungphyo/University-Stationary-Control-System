using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class DelegationDH
    {
        public string UserId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public int? RepStatus { get; set; }
        public int? DelegationStatus { get; set; }
        public DateTime? AuthorityStartDate { get; set; }
        public DateTime? AuthorityEndDate { get; set; }

        public string roleId { get; set; }
        public string roleName { get; set; }


    }
}