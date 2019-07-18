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
    public class RetrievalController : Controller
    {
        utitlityApiRequest _utility;
        public RetrievalController()
        {
            _utility = new utitlityApiRequest();
        }
        // GET: Retrieval
        public ActionResult RetrieveStationery()
        {
            try
            {
                List<RetrievalViewModel> retrievalLst = new List<RetrievalViewModel>();

                string resContent = _utility.requestGet("", "api/stationeryretrieval/getRetrieval");
                if (!string.IsNullOrEmpty(resContent))
                {
                    retrievalLst = JsonConvert.DeserializeObject<List<RetrievalViewModel>>(resContent);
                    retrievalLst = retrievalLst.OrderBy(s => s.ItemId).ToList();
                }
                return View(retrievalLst);
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(505, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult RetrieveStationery(string vm)
        {
            try
            {
                List<RetrievalViewModel> _vm = JsonConvert.DeserializeObject<List<RetrievalViewModel>>(vm);
                string resContent = _utility.requestPost(_vm, "api/stationeryretrieval/updateRetrieval");
                if (!string.IsNullOrEmpty(resContent))
                {
                    string res = JsonConvert.DeserializeObject<string>(resContent);
                    if (res == "success")
                    {
                        TempData["message"] = "Successfully retrieved.";
                    }
                    else
                        throw new System.Web.HttpException(505, "failed updated");
                }
                return RedirectToAction("RetrieveStationery");
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(505, ex.Message);
            }
        }
    }
}