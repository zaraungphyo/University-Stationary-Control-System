using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class EmployeeRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}