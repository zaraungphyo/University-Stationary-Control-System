using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sa47.team8ad.SSIS.Models
{
    public class EmployeeRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public string UserId { get; set; }
    }
}