using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class EmployeeDepartmentViewModel
    {
        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int CollectionPointId { get; set; }


    }
}