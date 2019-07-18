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
    public class SetRepresentativeController : Controller
    {

        utitlityApiRequest _utility = new utitlityApiRequest();

        // GET: SetRepresentative
        public ActionResult SetRepresentative()
        {
            try
            {
                string res = _utility.requestGet("", "api/employee/getallempbydept");
                if (!string.IsNullOrEmpty(res))
                {
                    List<EmployeeViewModel> emps = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(res);

                    ViewBag.bindEmployees = emps;
                }
                return View(new EmployeeRoleViewModel());
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SetRepresentative(EmployeeRoleViewModel emp)
        {
            try
            {
                string res = _utility.requestPost(emp, "api/employee/assignrepresentative");
                if (res == "true")
                {
                    TempData["message"] = "Successfully assigned department representative.";
                }
                else
                {
                    TempData["message"] = "failed to assign department representative.";
                }
                return Redirect("SetRepresentative");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
    }
}