using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class EmpCollectionItemViewModel
    {
        public string EmployeeId { get; set; }
        
        public int ItemId { get; set; }

        public int ActualQuantity { get; set; }
        
    }
}