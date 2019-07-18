using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sa47.team8ad.SSIS.Models
{
    public class DeptItemsViewModel
    {
        public int ItemId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DeptItemTotal { get; set; }
    }
}