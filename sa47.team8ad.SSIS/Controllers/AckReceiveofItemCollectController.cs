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
    public class AckReceiveofItemCollectController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();
        // GET: AckReceiveofItemCollect
        public ActionResult CollectionItem()
        {

            int deptid = 0;
            string empid = null;
            EmployeeViewModel empViewModel = null;
            string currentUser = _utility.requestGet("", "api/employee/getemp");
            if (!string.IsNullOrEmpty(currentUser))
            {
                empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                deptid = empViewModel.DepartmentId;
                empid = empViewModel.id;
            }

            string res = _utility.requestGet("id=" + deptid, "api/department/deptinfo");
            DepartmentViewModel dept = null;
            if (!string.IsNullOrEmpty(res))
            {
                dept = JsonConvert.DeserializeObject<DepartmentViewModel>(res);

            }

       //     string collectionpt = dept.CollectionPoint.CollectionPointAddress;

            ViewBag.CollectionPoint = dept.CollectionPoint;

            List<DisbursementViewModel> item = null;
            res = _utility.requestGet("id=" + deptid, "api/requisition/getdeptdisbursementlist");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<DisbursementViewModel>>(res);
                for (int i = 0; i < item.Count; i++)
                {
                    res = _utility.requestGet("id=" + item[i].ItemId, "api/requisition/getitembyid");

                    if (!string.IsNullOrEmpty(res))
                    {
                        item[i].Item = JsonConvert.DeserializeObject<ItemViewModel>(res);
                    }
                }
            }

            return View(item);
        }

        public ActionResult AckCollectionItem()
        {

            int deptid = 0;
            string empid = null;
            EmployeeViewModel empViewModel = null;
            string currentUser = _utility.requestGet("", "api/employee/getemp");
            if (!string.IsNullOrEmpty(currentUser))
            {
                empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                deptid = empViewModel.DepartmentId;
                empid = empViewModel.id;
            }

            string res = _utility.requestGet("id=" + deptid, "api/department/deptinfo");
            DepartmentViewModel dept = null;
            if (!string.IsNullOrEmpty(res))
            {
                dept = JsonConvert.DeserializeObject<DepartmentViewModel>(res);

            }

            string collectionpt = dept.CollectionPoint.CollectionPointAddress;

            ViewBag.CollectionPoint = collectionpt;

            List<DisbursementViewModel> item = null;
            res = _utility.requestGet("id=" + deptid, "api/requisition/getdeptdisbursementlist");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<DisbursementViewModel>>(res);
                for (int i = 0; i < item.Count; i++)
                {
                    res = _utility.requestGet("id=" + item[i].ItemId, "api/requisition/getitembyid");

                    if (!string.IsNullOrEmpty(res))
                    {
                        item[i].Item = JsonConvert.DeserializeObject<ItemViewModel>(res);
                    }
                }
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult AckCollectionItem(List<DisbursementViewModel> item)
        {
            for (int i = 0; i < item.Count; i++)
            {
                String res = _utility.requestPost(item[i], "api/requisition/returnitem");

                if (res == "1")
                {
                    ItemAdjustmentViewModel itemAdj = new ItemAdjustmentViewModel();
                    EmployeeViewModel empViewModel = null;

                    string currentUser = _utility.requestGet("", "api/employee/getemp");
                    if (!string.IsNullOrEmpty(currentUser))
                    {
                        empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                        itemAdj.EmployeeId = empViewModel.id;
                        itemAdj.AdjustmentQuantity = item[i].ReturnQuantity;
                        itemAdj.ItemId = item[i].ItemId;
                        itemAdj.Reason = item[i].Reason;
                        itemAdj.ItemAdjustmentDate = System.DateTime.Now.Date;

                        res = _utility.requestPost(itemAdj, "api/requisition/returnitemadj");

                        if (res == "1")
                        {
                        }

                    }
                }
            }
            return RedirectToAction("CollectionItem");
        }
    }
}