using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sa47.team8ad.SSIS.Controllers
{
    public class InventoryAdjustmentController : Controller
    {
        Utility.utitlityApiRequest _utility;
        public InventoryAdjustmentController()
        {
            _utility = new Utility.utitlityApiRequest();
        }
        // GET: InventoryAdjustment
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<ItemAdjustmentViewModel> items = new List<ItemAdjustmentViewModel>();
                string resContent = _utility.requestGet("", "api/inventory/getInvAdj");
                if (!string.IsNullOrEmpty(resContent))
                {
                    items = JsonConvert.DeserializeObject<List<ItemAdjustmentViewModel>>(resContent);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Index(string itemAdjustment)
        {
            try
            {
                List<ItemAdjustmentViewModel> vm = JsonConvert.DeserializeObject<List<ItemAdjustmentViewModel>>(itemAdjustment);
                string a = JsonConvert.SerializeObject(vm);
                string resContent = _utility.requestPost(vm, "api/inventory/submitInvAdj");
                if (!string.IsNullOrEmpty(resContent))
                {
                    bool res = JsonConvert.DeserializeObject<bool>(resContent);
                    if (res)
                    {
                        TempData["message"] = "Successfully adjusted spoiled items.";
                    }
                    else
                    {
                        TempData["errorMessage"] = "failed adjusted spoiled items.";
                    }
                }
                return RedirectToAction("Index","InventoryAdjustment");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult AddAdjustmentItem() {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdjustmentItem(ItemAdjustmentViewModel vm)
        {
            try
            {
                string aa = JsonConvert.SerializeObject(vm);
                string resContent = _utility.requestPost(vm, "api/inventory/addInvAdj");
                if (!string.IsNullOrEmpty(resContent))
                {
                    bool sup = JsonConvert.DeserializeObject<bool>(resContent);
                    if (sup)
                    {
                        TempData["message"] = "successfully adjusted item.";
                        return Redirect("Index");
                    }
                    else
                    {
                        throw new System.Web.HttpException(505, "An error has errored.");
                    }
                }
                TempData["errorMessage"] = "An error has occurred.";
                return View();
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }


        [HttpGet]
        public ActionResult EditAdjustmentItem(ItemAdjustmentViewModel vm)
        {
            return View(vm);
        }

        [HttpPost]
        public ActionResult SaveAdjustmentItem(ItemAdjustmentViewModel vm)
        {
            try
            {
                string resContent = _utility.requestPost(vm, "api/inventory/updInvAdj");
                if (!string.IsNullOrEmpty(resContent))
                {
                    bool res = JsonConvert.DeserializeObject<bool>(resContent);
                    if (res)
                    {
                        TempData["message"] = "Successfully updated spoiled items.";
                    }
                    else
                    {
                        TempData["errorMessage"] = "failed to update spoiled items.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
            
        }

        [HttpGet]
        public ActionResult removeAdjustmentItem(int id)
        {
            try
            {
                string resContent = _utility.requestGet("id="+id, "api/inventory/removeInvAdj");
                if (!string.IsNullOrEmpty(resContent))
                {
                    bool res = JsonConvert.DeserializeObject<bool>(resContent);
                    if (res)
                    {
                        TempData["message"] = "Successfully deleted spoiled items.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
    }
}