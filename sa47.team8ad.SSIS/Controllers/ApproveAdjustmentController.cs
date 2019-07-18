using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using sa47.team8ad.SSIS.Utility;

namespace sa47.team8ad.SSIS.Controllers
{
    public class ApproveAdjustmentController : Controller
    {
        utitlityApiRequest _utility;
        public ApproveAdjustmentController()
        {
            _utility = new utitlityApiRequest();
        }

        public ActionResult NoAdjustments()
        {
            return View();
        }

        public ActionResult AdjustmentList()
        {
            try
            {
                string result = _utility.requestGet("", "api/inventory/listadjforapp");

                //!string.IsNullOrEmpty(result)
                if (result != "null")
                {
                    List<ItemAdjustmentListViewModel> adjList = JsonConvert.DeserializeObject<List<ItemAdjustmentListViewModel>>(result);
                    return View(adjList);
                }
                else
                    return RedirectToAction("NoAdjustments");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Approve(string newRemark)
        {
            try
            {
                string result = _utility.requestGet("newRemark=" + newRemark, "api/inventory/adjApproved");
                List<ItemAdjustmentViewModel> itemList = JsonConvert.DeserializeObject<List<ItemAdjustmentViewModel>>(result);
                return RedirectToAction("NoAdjustments");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult AdjustmentByItem(int id)
        {
            try
            {
                string result = _utility.requestGet("id=" + id, "api/inventory/adj");
                List<ItemAdjustmentViewModel> itemList = JsonConvert.DeserializeObject<List<ItemAdjustmentViewModel>>(result);
                return View(itemList);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
    }
}