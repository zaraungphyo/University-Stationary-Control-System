using sa47.team8ad.SSIS.Utility;
using sa47.team8ad.SSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace sa47.team8ad.SSIS.Controllers
{
    public class MaintainInventoryController : Controller
    {
        utitlityApiRequest _utility;
        public MaintainInventoryController()
        {
            _utility = new utitlityApiRequest();
        }


        /*commented by zar aung phyo*/
        public ActionResult ItemsList()
        {
            try
            {
                List<ItemViewModel> itemsList = new List<ItemViewModel>();
                string result = _utility.requestGet("", "api/inventory/getallitemdetails");
                if (!string.IsNullOrEmpty(result))
                {
                    itemsList = JsonConvert.DeserializeObject<List<ItemViewModel>>(result);
                }
                return View(itemsList);
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult ItemsList(string search)
        {
            try
            {
                string result = _utility.requestGet("search=" + search, "api/inventory/search");
                if (!string.IsNullOrEmpty(result))
                {
                    List<ItemViewModel> itemsList =
                        JsonConvert.DeserializeObject<List<ItemViewModel>>(result);

                    return View(itemsList);
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }

        }

        [HttpGet]
        public ActionResult EditItem(int id)
        {
            try
            {
                string result = _utility.requestGet("id=" + id, "api/inventory/getitembyid");

                if (!string.IsNullOrEmpty(result))
                {
                    ItemViewModel item =
                        JsonConvert.DeserializeObject<ItemViewModel>(result);

                    string result2 = _utility.requestGet("", "api/inventory/getalllocations");
                    List<ItemLocationViewModel> locations = JsonConvert.DeserializeObject<List<ItemLocationViewModel>>(result2);
                    var y = locations.Select(b => new SelectListItem
                    {
                        Text = b.LocationDesc,
                        Value = b.LocationId.ToString()
                    }).ToList();
                    ViewBag.bindLocations = y;

                    return View(item);
                }
                else
                    return Redirect("ItemsList");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult EditItem(ItemViewModel item)
        {
            try
            {
                string result = _utility.requestPost(item, "api/inventory/update");

                if (result == "1")
                {
                    TempData["message"] = "successfully Updated.";
                }
                else
                    ViewBag.errorMessage = "failed to update";


               return RedirectToAction("ItemsList");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            try
            {
                // Categories dropdown list:
                string result = _utility.requestGet("", "api/inventory/getallcategories");
                List<CategoryViewModel> cats = JsonConvert.DeserializeObject<List<CategoryViewModel>>(result);
                var x = cats.Select(b => new SelectListItem
                {
                    Text = b.CategoryName,
                    Value = b.CategoryId.ToString()
                }).ToList();
                ViewBag.bindCats = x;
                // Locations dropdown list:
                string result2 = _utility.requestGet("", "api/inventory/getalllocations");
                List<ItemLocationViewModel> locations = JsonConvert.DeserializeObject<List<ItemLocationViewModel>>(result2);
                var y = locations.Select(b => new SelectListItem
                {
                    Text = b.LocationDesc,
                    Value = b.LocationId.ToString()
                }).ToList();
                ViewBag.bindLocations = y;
                // Measurement Unit dropdown list:
                string result3 = _utility.requestGet("", "api/inventory/getallunits");
                List<MeasurementUnitViewModel> units = JsonConvert.DeserializeObject<List<MeasurementUnitViewModel>>(result3);
                var z = units.Select(b => new SelectListItem
                {
                    Text = b.UnitName,
                    Value = b.UnitId.ToString()
                }).ToList();
                ViewBag.bindUnits = z;

                return View();
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateItem(ItemViewModel item)
        {
            try
            {
                string result = _utility.requestPost(item, "api/inventory/createitem");
                if (result == "1")
                {
                    TempData["message"] = "successfully Updated.";
                   
                }
                else
                    ViewBag.errorMessage = "Failed to Update.";
                return RedirectToAction("ItemsList");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
    }
   
}