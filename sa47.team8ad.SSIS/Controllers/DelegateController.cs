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
    public class DelegateController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();
        // GET: Delegate
        public ActionResult delegateAuthority()
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

            return View();
        }

        [HttpPost]
        public ActionResult delegateAuthority(DelegateViewModel vm)
        {
            int result = DateTime.Compare(vm.AuthorityStartDate, vm.AuthorityEndDate);

            if (result <= 0)
            {
                result = DateTime.Compare(vm.AuthorityStartDate, System.DateTime.Now.Date);
                if (result >= 0)
                {
                    vm.UserId = vm.Id;
                    string res = _utility.requestPost(vm, "api/employee/assignemprole");
                    if (res == "true")
                    {
                        // return View();
                        TempData["message"] = "Successfully Delegated";
                        return RedirectToAction("delegateAuthority");
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Start Date should not be earlier than current date.";
                    return RedirectToAction("delegateAuthority");
                }
            }
            else
            {
                TempData["errorMessage"] = "End Date should not be earlier than Start Date.";
                return RedirectToAction("delegateAuthority");
            }


            TempData["errorMessage"] = "Failed Delegation";
            return RedirectToAction("delegateAuthority");
        }

        [HttpGet]
        public ActionResult Delegation()
        {
            List<DelegateViewModel> vm = new List<DelegateViewModel>();
            string res = _utility.requestGet("", "api/employee/delegation");
            if (!string.IsNullOrEmpty(res))
            {
                vm = JsonConvert.DeserializeObject<List<DelegateViewModel>>(res);
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult removeDelegate(string id) {
            try
            {
                EmployeeViewModel emp = new EmployeeViewModel() { id = id };
                string res = _utility.requestPost(emp, "api/employee/cancelAssignDH");
                if (!string.IsNullOrEmpty(res))
                {
                    int result = JsonConvert.DeserializeObject<int>(res);
                    if (result == 1)
                    {
                        TempData["message"] = "successfully removed delegation.";
                    }
                    else
                    {
                        TempData["errorMessage"] = "failed to remove delegation.";
                    }
                }
                return RedirectToAction("delegation");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
    }
}