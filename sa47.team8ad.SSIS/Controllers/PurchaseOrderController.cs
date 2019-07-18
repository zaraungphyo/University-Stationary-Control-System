using sa47.team8ad.SSIS.Utility;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using sa47.team8ad.SSIS.Models;
using Newtonsoft.Json;
using System.Linq;

namespace sa47.team8ad.SSIS.Controllers
{
    public class PurchaseOrderController : Controller
    {
        utitlityApiRequest _utility;
        public PurchaseOrderController()
        {
            _utility = new utitlityApiRequest();
        }
        // GET: PurchaseOrder
        public ActionResult GenerateOrder()
        {
            try
            {
                List <ItemViewModel> items = new List<ItemViewModel>();
                string supplierContent = _utility.requestGet("", "api/purchaseorder/getallsupplier");
                if (Session["ItemLists"] == null)
                {
                    string resContent = _utility.requestGet("", "api/purchaseorder/lowstockitem");
                    if (!string.IsNullOrEmpty(resContent))
                    {
                        items = JsonConvert.DeserializeObject<List<ItemViewModel>>(resContent);
                        Session["ItemLists"] = items;
                    }
                }
                else  {
                    items = (List<ItemViewModel>)Session["ItemLists"];
                }
                if (!string.IsNullOrEmpty(supplierContent))
                {
                    List<SupplierViewModel> sup = JsonConvert.DeserializeObject<List<SupplierViewModel>>(supplierContent);
                    var supplier = sup.Select(c => new SelectListItem
                    {
                        Text = c.SupplierName,
                        Value = c.SupplierId.ToString(),
                    }).ToList();
                    ViewBag.bindSuppliers = supplier;
                }
                return View(items);
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(404, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GenerateOrder(string purchaseItems)
        {
            try
            {
                if (!string.IsNullOrEmpty(purchaseItems))
                {
                    List<ItemViewModel> items = JsonConvert.DeserializeObject<List<ItemViewModel>>(purchaseItems);
                    string resContent = _utility.requestPost(items, "api/purchaseorder/generateorder");
                    if (!string.IsNullOrEmpty(resContent))
                    {
                        string sup = JsonConvert.DeserializeObject<string>(resContent);
                        if (sup == "true")
                        {
                            TempData["message"] = "successfully generated purchase orders to supplier.";
                            Session["ItemLists"] = null;
                        }
                        else
                        {
                            throw new System.Web.HttpException(505, "An error has errored.");
                        }
                    }
                }
                return RedirectToAction("GenerateOrder");
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(500, ex.Message+"?PurchaseOrder/GenerateOrder");
            }
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            try
            {
                string resContent = _utility.requestGet("", "api/purchaseorder/getunits");
                string supplierContent = _utility.requestGet("", "api/purchaseorder/getallsupplier");

                if (!string.IsNullOrEmpty(resContent))
                {
                    List<MeasurementUnitViewModel> units = JsonConvert.DeserializeObject<List<MeasurementUnitViewModel>>(resContent);
                    ViewBag.UnitId = units.Select(c => new SelectListItem
                    {
                        Text = c.UnitName,
                        Value = c.UnitId.ToString(),
                    }).ToList();
                }
                if (!string.IsNullOrEmpty(supplierContent))
                {
                    List<SupplierViewModel> sup = JsonConvert.DeserializeObject<List<SupplierViewModel>>(supplierContent);
                    ViewBag.bindSuppliers = sup.Select(c => new SelectListItem
                    {
                        Text = c.SupplierName,
                        Value = c.SupplierId.ToString(),
                    }).ToList();
                }
               
                    return View(new ItemViewModel());
              
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(404, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddOrder(ItemViewModel item, string a)
        {
            List<ItemViewModel> items = (List<ItemViewModel>)Session["ItemLists"];
            items.Add(item);
            Session["ItemLists"] = items;
            return RedirectToAction("GenerateOrder");
        }

        [HttpGet]
        public ActionResult updatePurchaseOrder()
        {
            try
            {
                List<PurchaseOrderViewModel> vm = new List<PurchaseOrderViewModel>();
                string resContent = _utility.requestGet("", "api/purchaseorder/getPurchaseOrder");
                if (!string.IsNullOrEmpty(resContent))
                {
                   vm = JsonConvert.DeserializeObject<List<PurchaseOrderViewModel>>(resContent);
                }
                return View(vm);
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(404, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult updatePurchaseOrder(string vm)
        {
            try
            {
                List<PurchaseOrderViewModel> po = JsonConvert.DeserializeObject<List<PurchaseOrderViewModel>>(vm);
                string resContent = _utility.requestPost(po, "api/purchaseorder/closedPO");
                if (!string.IsNullOrEmpty(resContent))
                {
                    if (JsonConvert.DeserializeObject<bool>(resContent))
                    {
                        TempData["message"] = "Purchase Order has successfully delivered.";
                    }
                }
                return RedirectToAction("updatePurchaseOrder");
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(404, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult updatePurchaseOrderDetail(string vm)
        {
            try
            {
                PurchaseOrderViewModel po = JsonConvert.DeserializeObject<PurchaseOrderViewModel>(vm);
                string resContent = _utility.requestPost(po, "api/purchaseorder/updatePOD");
                if (!string.IsNullOrEmpty(resContent))
                {
                    if (JsonConvert.DeserializeObject<bool>(resContent))
                    {
                        TempData["message"] = "Successfully updated purchase order.";
                    }
                }
                return RedirectToAction("updatePurchaseOrder");
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(404, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult removePurchaseOrderDetail(string vm)
        {
            try
            {
                PurchaseOrderViewModel po = JsonConvert.DeserializeObject<PurchaseOrderViewModel>(vm);
                string resContent = _utility.requestPost(po, "api/purchaseorder/removePOD");
                if (!string.IsNullOrEmpty(resContent))
                {
                    if (JsonConvert.DeserializeObject<bool>(resContent))
                    {
                        TempData["message"] = "Successfully cancelled purchase order.";
                    }
                }
                return RedirectToAction("updatePurchaseOrder");
            }
            catch (Exception ex)
            {
                throw new System.Web.HttpException(404, ex.Message);
            }
        }

        [HttpGet]
        public JsonResult itemsAutoComplete() {
            string resContent = _utility.requestGet("", "api/purchaseorder/getitems");
            if (!string.IsNullOrEmpty(resContent))
            {
                List<ItemViewModel> vm = JsonConvert.DeserializeObject<List<ItemViewModel>>(resContent);
                return Json(vm, JsonRequestBehavior.AllowGet);
            }
            return Json("Not Found", JsonRequestBehavior.DenyGet);
        }

    }
}