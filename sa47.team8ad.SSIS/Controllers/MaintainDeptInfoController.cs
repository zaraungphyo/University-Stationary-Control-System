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
    public class MaintainDeptInfoController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();

        // GET: MaintainDeptInfo
        public ActionResult DeptInfo()
        {

            string res = _utility.requestGet("id=1", "api/department/deptinfo");
            string cpResContent = _utility.requestGet("", "api/collectionpoint/get");
            DepartmentViewModel dept = null;
            if (!string.IsNullOrEmpty(res))
            {
                dept= JsonConvert.DeserializeObject<DepartmentViewModel>(res);
            }
            if (!string.IsNullOrEmpty(cpResContent))
            {
                List<CollectionPointViewModel> sup = JsonConvert.DeserializeObject<List<CollectionPointViewModel>>(cpResContent);
                var cpvm = sup.Select(c => new SelectListItem
                {
                    Text = c.CollectionPointAddress,
                    Value = c.CollectionPointId.ToString(),
                }).ToList();
                ViewBag.bindCollectionPoint = cpvm;
            }
            return View(dept);
        }

        [HttpPost]
        public ActionResult DeptInfo(DepartmentViewModel dvm)
        {

            string res = _utility.requestPost(dvm, "api/department/update");
            DepartmentViewModel dept = null;
            if (res == "1")
            {
                //string res1 = _utility.requestGet("id=1", "api/department/deptinfo");

                //if (!string.IsNullOrEmpty(res1))
                //{
                //    ViewBag.message = "Successfully updated.";
                //    dept = JsonConvert.DeserializeObject<DepartmentViewModel>(res1);
                //}
                TempData["message"] = "Successfully updated.";
            }
            else
            {
                TempData["errorMessage"] = "failed to update.";
            }
            return Redirect("DeptInfo");
        }
    }
}