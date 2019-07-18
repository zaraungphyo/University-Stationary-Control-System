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
    public class ApproveRejectController : Controller
    {

        utitlityApiRequest _utility = new utitlityApiRequest();

        // GET: ApproveReject
        public ActionResult ApproveReject()
        {
            List<ItemRequisitionViewModel> item = null;

            String res = _utility.requestGet("", "api/requisition/getallemp");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<ItemRequisitionViewModel>>(res);
            }
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i] != null)
                {
                    res = _utility.requestGet("id=" + item[i].EmployeeId, "api/requisition/getempinfobyid");

                    if (!string.IsNullOrEmpty(res))
                    {
                        item[i].Employee = JsonConvert.DeserializeObject<EmployeeViewModel>(res);
                    }
                }
            }
            return View(item);
        }

        public ActionResult ViewItemRequistionDetails(int id)
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

        [HttpPost]
        public ActionResult ViewItemRequistionDetails(ItemRequisitionDetailViewModel[] items, FormCollection formCollection, string button, int requestId)
        {
            string status = "5";
            string secondstatus = null;
            bool rejectAll = false;
            if (button == "Approve")
            {
                status = "3";
                secondstatus = "4";
            }
            else if (button == "Reject")
            {
                status = "4";
                secondstatus = "3";
            }
            List<ItemRequisitionDetailViewModel> itemall = null;

            string res = _utility.requestGet("id=" + requestId, "api/requisition/getitemreqdetailbyid");

            if (!string.IsNullOrEmpty(res))
            {
                itemall = JsonConvert.DeserializeObject<List<ItemRequisitionDetailViewModel>>(res);
            }
            res = null;
            if (formCollection["ID"] != null)
            {
                string[] ids = formCollection["ID"].Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    int itemId = Convert.ToInt32(id);
                    for (int i = 0; i < itemall.Count; i++)
                    {
                        if (itemall[i].ItemId == itemId)
                        {
                            itemall.RemoveAt(i);
                        }
                    }

                    ItemRequisitionDetailViewModel item = null;
                    res = _utility.requestGet("id=" + requestId + "&itemId=" + itemId, "api/requisition/getitemdetailbyitemid");

                    if (!string.IsNullOrEmpty(res))
                    {
                        item = JsonConvert.DeserializeObject<ItemRequisitionDetailViewModel>(res);
                        item.ApproveStatus = status;
                        for (int i = 0; i < items.Count(); i++)
                        {
                            if (items[i].ItemId == itemId)
                            {
                                item.Remark = items[i].Remark;
                            }
                        }
                    }

                    res = _utility.requestPost(item, "api/requisition/updateitemdetailstatus");
                }

                if (itemall.Count > 0)
                {
                    for (int i = 0; i < itemall.Count; i++)
                    {
                        int itemId = itemall[i].ItemId;
                        ItemRequisitionDetailViewModel item = null;
                        res = _utility.requestGet("id=" + requestId + "&itemId=" + itemId, "api/requisition/getitemdetailbyitemid");

                        if (!string.IsNullOrEmpty(res))
                        {
                            item = JsonConvert.DeserializeObject<ItemRequisitionDetailViewModel>(res);
                            item.ApproveStatus = secondstatus;
                            for (int j = 0; j < items.Count(); j++)
                            {
                                if (items[j].ItemId == itemId)
                                {
                                    item.Remark = items[j].Remark;
                                }
                            }
                        }

                        res = _utility.requestPost(item, "api/requisition/updateitemdetailstatus");
                    }
                }

                else if (status.Equals("4"))
                {
                    rejectAll = true;
                }
            }
            else
            {
                TempData["Message"] = @"Please check the particularly checkbox to approve/reject.";
                return RedirectToAction("ViewItemRequistionDetails");
            }
            ItemRequisitionViewModel itemreq = null;
            res = _utility.requestGet("id=" + requestId, "api/requisition/getitemreqbyreqid");

            if (!string.IsNullOrEmpty(res))
            {
                itemreq = JsonConvert.DeserializeObject<ItemRequisitionViewModel>(res);
                if (rejectAll)
                {
                    itemreq.FormStatus = 0;
                }
                else
                {
                    itemreq.FormStatus = 1;
                }
            }
            res = _utility.requestPost(itemreq, "api/requisition/update");
            if (res == "1")
            {
                TempData["message"] = "Successfully approved/rejected item requisitions";
                return RedirectToAction("ApproveReject");
            }
            TempData["errorMessage"] = "Failed approved/rejected item requisitions";
            return RedirectToAction("ApproveReject");

        }
    }
}