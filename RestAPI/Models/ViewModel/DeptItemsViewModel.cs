using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class DeptItemsViewModel
    {
        public int ItemId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DeptItemTotal { get; set; }
    }
}