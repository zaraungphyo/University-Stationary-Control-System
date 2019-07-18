using Microsoft.AspNet.Identity;
using RestAPI.Models;
using RestAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/purchaseorder")]
    public class OrderController : ApiController
    {
        BizLogic helper = new BizLogic();
        public OrderController()
        { }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("lowstockitem")]
        public IHttpActionResult lowStock()
        {
            try
            {
                List<ItemViewModel> items = helper.generateOrders();
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("generateorder")]
        public IHttpActionResult purchaseOrder(List<ItemViewModel> items)
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool res = helper.purchaseOrder(items, id);
                if (res)
                {
                    EmailNotification.sendSupplieronPurchase(items);
                    return Ok(res);
                }
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error has occurred"));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getPurchaseOrder")]
        public IHttpActionResult getOrders()
        {
            try
            {
                string id = User.Identity.GetUserId();
                IList<PurchaseOrderViewModel> res = helper.GetPurchaseOrders();
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("updatePOD")]
        public IHttpActionResult updatePurchaseOrderDetail(PurchaseOrderViewModel vm)
        {
            try
            {
               
                bool res = helper.updatePurchaseOrderDetail(vm);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("removePOD")]
        public IHttpActionResult removePurchaseOrderDetail(PurchaseOrderViewModel vm)
        {
            try
            {

                bool res = helper.removePurchaseOrderDetail(vm);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("closedPO")]
        public IHttpActionResult closedPurchaseOrder(List<PurchaseOrderViewModel> vm)
        {
            try
            {
                bool res = helper.closedPurchaseOrder(vm);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getallsupplier")]
        public IHttpActionResult getSupplier()
        {
            try
            {
                List<Supplier> items = helper.getSupplier();
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getunits")]
        public IHttpActionResult getItemUnits()
        {
            try
            {
                List<MeasurementUnit> items = helper.getUnits();
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getItems")]
        public IHttpActionResult items()
        {
            try
            {
                List<Item> items = helper.getItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
    }
}
