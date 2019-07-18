using sa47.team8ad.SSIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sa47.team8ad.SSIS.Models;
using Newtonsoft.Json;

namespace sa47.team8ad.SSIS.Controllers
{
    public class DisbursementController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();

        [HttpGet]
        public ActionResult viewDisbursement() {
            try
            {
                getDepartment();
                return View(getDisbursement());
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult viewDisbursement(int DepartmentId)
        {
            try
            {
                List<DisbursementViewModel> filter = getDisbursement();
                if (DepartmentId > 0)
                {
                    filter = filter.Where(s => s.DepartmentId == DepartmentId).ToList();
                }
                getDepartment();
                return View(filter);
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(505, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult updateDisbursement(DisbursementViewModel vm)
        {
            try
            {
                string resContent = _utility.requestPost(vm, "api/disbursement/updateDis");
                if (!string.IsNullOrEmpty(resContent))
                {
                    string res = JsonConvert.DeserializeObject<string>(resContent);
                    if (res != "success")
                    {
                        throw new Exception("Something went wrong.");
                    }
                }
                return RedirectToAction("updateDisbursement", getDisbursement());
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(500, ex.Message);
            }
        }

        private List<DisbursementViewModel> getDisbursement() {
            List<DisbursementViewModel> vm = new List<DisbursementViewModel>();
            string res = _utility.requestGet("", "api/disbursement/getlist");

            if (!string.IsNullOrEmpty(res))
            {
                vm = JsonConvert.DeserializeObject<List<DisbursementViewModel>>(res);
            }
            return vm;
        }

        private void getDepartment() {
            string resContent = _utility.requestGet("", "api/disbursement/getDepartments");
            if (!string.IsNullOrEmpty(resContent))
            {
                List<DepartmentViewModel> depts = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(resContent);

                var addOptionLabel = depts.Select(s => new SelectListItem
                {
                    Text = s.DepartmentName,
                    Value = s.DepartmentId.ToString()
                }).ToList();
                addOptionLabel.Insert(0,new SelectListItem {Text = "All" , Value="0" });
                ViewBag.bindDepartments = addOptionLabel;
            }
        }
    }
}