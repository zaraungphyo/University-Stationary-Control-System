using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using sa47.team8ad.SSIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sa47.team8ad.SSIS.Controllers
{
    public class HomeController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();
        public ActionResult Index()
        {
            string res = _utility.requestGet("", "api/employee/getallemp");

            if (!string.IsNullOrEmpty(res))
            {
                List<EmployeeViewModel> emps = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(res);
                var x = emps.Select(c => new SelectListItem
                {
                    Text = c.EmployeeName,
                    Value = c.id,
                    // Selected = (c.CurrencyID == 68)
                }).ToList();
                ViewBag.bindEmployees = x;
            }
            return View(new DelegateViewModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}