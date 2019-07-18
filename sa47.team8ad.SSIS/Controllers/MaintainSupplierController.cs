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
    public class MaintainSupplierController : Controller
    {
        utitlityApiRequest _utility;
        public static int supplierId;
        public MaintainSupplierController()
        {
            _utility = new utitlityApiRequest();
        }
        public ActionResult SupplierList()
        {
            try
            {
                List<SupplierViewModel> supplierList = new List<SupplierViewModel>();
                string res = _utility.requestGet("", "api/supplier/getallsuppliers");

                if (!string.IsNullOrEmpty(res))
                {
                    supplierList = JsonConvert.DeserializeObject<List<SupplierViewModel>>(res);
                }

                return View(supplierList);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult EditSupplier(int id)
        {
            try
            {
                SupplierViewModel supplier = new SupplierViewModel();
                string res = _utility.requestGet("sprid=" + id, "api/supplier/getsupplierbyid");

                if (!string.IsNullOrEmpty(res))
                {
                    supplier = JsonConvert.DeserializeObject<SupplierViewModel>(res);
                }

                return View(supplier);

            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditSupplier(SupplierViewModel supplier)
        {
            try
            {
                string res = _utility.requestPost(supplier, "api/supplier/edit");
                return RedirectToAction("SupplierList");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(SupplierViewModel supplier)
        {
            string res = _utility.requestPost(supplier, "api/supplier/createsupplier");
            return RedirectToAction("SupplierList");
        }

        public ActionResult SupplierItemDetails(int id)
        {
            try
            {
                //save supplier id for easy redirect to SupplierItems List after add/edit
                supplierId = id;
                string res = _utility.requestGet("sprid=" + id, "api/supplier/getsupplieritemlistbyid");


                if (res != "null")
                {
                    List<SupplierItemViewModel> supplierItems = JsonConvert.DeserializeObject<List<SupplierItemViewModel>>(res);
                    return View(supplierItems);
                }
                else
                    return RedirectToAction("AddSupplierItem", new { id = supplierId });
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
        [HttpGet]
        public ActionResult AddSupplierItem(int id)
        {
            try
            {
                string res = _utility.requestGet("sprid=" + id, "api/supplier/getsupplierbyid");

                if (!string.IsNullOrEmpty(res))
                {
                    SupplierViewModel supplier = JsonConvert.DeserializeObject<SupplierViewModel>(res);
                    var x = supplier.SupplierName;
                    ViewBag.BindId = id;
                    ViewBag.BindName = x;
                }

                // Get list of all items (itemId & itemName): 

                string result2 = _utility.requestGet("", "api/inventory/getallitemdetails");
                if (!string.IsNullOrEmpty(result2))
                {
                    List<ItemViewModel> items = JsonConvert.DeserializeObject<List<ItemViewModel>>(result2);
                    var y = items.Select(b => new SelectListItem
                    {
                        Text = b.ItemDescription,
                        Value = b.ItemId.ToString()
                    }).ToList();
                    ViewBag.bindItems = y;
                }

                return View();
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddSupplierItem(SupplierItemViewModel item)
        {
            try
            {
                string result = _utility.requestPost(item, "api/supplier/createsupplieritem");
                if (result == "1")
                {
                    //SupplierItemViewModel supItem = JsonConvert.DeserializeObject<SupplierItemViewModel>(result);
                    return RedirectToAction("SupplierItemDetails", new { id = supplierId });
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
        public ActionResult EditSupplierItem(int id)
        {
            try
            {
                SupplierItemViewModel supItem = new SupplierItemViewModel();
                string result = _utility.requestGet("id=" + id, "api/supplier/getsupplieritembyid");
                if (!string.IsNullOrEmpty(result))
                {
                    supItem = JsonConvert.DeserializeObject<SupplierItemViewModel>(result);
                }

                return View(supItem);
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
        [HttpPost]
        // public ActionResult EditSupplierItem(SupplierItemViewModel item)
        public ActionResult EditSupplierItem(string supplierItemObj)
        {
            try
            {
                SupplierItemViewModel item = JsonConvert.DeserializeObject<SupplierItemViewModel>(supplierItemObj);
                string result = _utility.requestPost(item, "api/supplier/editsupplieritem");
                if (result == "1")
                {
                    TempData["message"] = "Successfully updated.";
                }
                else
                    TempData["message"] = "Failed to update.";
                return RedirectToAction("SupplierItemDetails", new { id = supplierId });
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult DeleteSupplierItem(int id)
        {
            try
            {
                string result = _utility.requestGet("id=" + id, "api/supplier/deletesupplieritem");
                if (result == "1")
                    return RedirectToAction("SupplierItemDetails", new { id = supplierId });
                else
                    return View();
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
    }

}