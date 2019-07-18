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
    public class ViewTransactionHistoryofDeptReqController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();

        // GET: ViewTransactionHistoryofDeptReq
        public ActionResult HistoryAll()
        {
            List<ItemRequisitionViewModel> item = null;

            String res = _utility.requestGet("", "api/requisition/getallemphistory");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<ItemRequisitionViewModel>>(res);
            }

            for (int i = 0; i < item.Count; i++)
            {
                res = _utility.requestGet("id=" + item[i].EmployeeId, "api/requisition/getempinfobyid");

                if (!string.IsNullOrEmpty(res))
                {
                    item[i].Employee = JsonConvert.DeserializeObject<EmployeeViewModel>(res);
                }
            }

            return View(item);
        }
        public ActionResult HistoryDetails(int id)
        {

            List<ItemRequisitionDetailViewModel> item = null;

            String res = _utility.requestGet("id=" + id, "api/requisition/getitemreqdetailbyid");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<ItemRequisitionDetailViewModel>>(res);
            }

            for (int i = 0; i < item.Count; i++)
            {
                res = _utility.requestGet("id=" + item[i].ItemId, "api/requisition/getitembyid");

                if (!string.IsNullOrEmpty(res))
                {
                    item[i].Item = JsonConvert.DeserializeObject<ItemViewModel>(res);
                }
            }
            ViewBag.requestId = id;

            return View(item);
            
        }
        }
}