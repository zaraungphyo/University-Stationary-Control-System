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
    public class ChangeCollectionPointController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();

        // GET: ChangeCollectionPoint
        public ActionResult CollectionPoint()
        {
            int id = 0;
            EmployeeViewModel empViewModel = null;
            string currentUser = _utility.requestGet("", "api/employee/getemp");
            if (!string.IsNullOrEmpty(currentUser))
            {
                empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                id = empViewModel.DepartmentId;
            }


            string res = _utility.requestGet("id=" + id, "api/department/deptinfo");
            DepartmentViewModel dept = null;
            if (!string.IsNullOrEmpty(res))
            {
                dept = JsonConvert.DeserializeObject<DepartmentViewModel>(res);
                return View(dept);
            }
            return View(dept);

        }


        [HttpPost]
        public ActionResult CollectionPoint(DepartmentViewModel dvm, string Place)
        {
            int id = 0;
            EmployeeViewModel empViewModel = null;
            string currentUser = _utility.requestGet("", "api/employee/getemp");
            if (!string.IsNullOrEmpty(currentUser))
            {
                empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                id = empViewModel.DepartmentId;
            }

            dvm.CollectionPointId = Convert.ToInt32(Place);

            string res = _utility.requestPost(dvm, "api/department/updatecollectionpt");

            if (res == "1")
            {
                TempData["message"] = "Successfully changed collection point";
                return RedirectToAction("CollectionPoint");
            }
            TempData["errorMessage"] = "Failed to change collection point";
            return RedirectToAction("CollectionPoint");
        }
    }
}