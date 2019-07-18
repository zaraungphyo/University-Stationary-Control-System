using RestAPI.Models;
using RestAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/stationeryretrieval")]
    public class ItemRetrievalController : ApiController
    {
        BizLogic helper = new BizLogic();

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getRetrieval")]  /*webapp*/
        public IHttpActionResult retrieval() {
            try
            {
                IList<StationeryRetrievalView> lst = helper.getRetrievalList();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("updateRetrieval")]
        public IHttpActionResult updateRetrieval(IList<StationeryRetrievalView> lst)
        {
            try
            {
                helper.updateRetrievalt(lst);
                EmailNotification.SendLowStockEmail();
                return Ok("success");
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        /*mobile use*/
        [HttpGet]
        [Authorize(Roles = "StoreClerk")]
        [Route("getRet")]
        public IHttpActionResult retrievalbyItem()
        {
            try
            {
                IList<StationeryRetrievalView> lst = helper.getRetrievalListGroupByItemId();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk")]
        [Route("getRetrievalByDept")]
        public IHttpActionResult retrievalByDept(int itemId)
        {
            try
            {
                IList<StationeryRetrievalView> lst = helper.getRetrievalListGroupByDepartment(itemId);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk")]
        [Route("createDisList")]
        public IHttpActionResult createDisbursment(IList<StationeryRetrievalView> lst)
        {
            try
            {
                helper.createDisbursement(lst);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }


        [HttpPost]
        [Authorize(Roles = "StoreClerk")]
        [Route("updateReceiveStatus")]
        public IHttpActionResult updateReceiveStatus(IList<StationeryRetrievalView> lst)
        {
            try
            {
                helper.updateItemReqDetailsRecieveStatus(lst);
                EmailNotification.SendLowStockEmail();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
