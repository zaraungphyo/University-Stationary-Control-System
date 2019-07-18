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
    [RoutePrefix("api/disbursement")]
    public class ItemDisbursementController : ApiController
    {
        BizLogic helper;
        public ItemDisbursementController()
        {
            helper = new BizLogic();
        }

        //[HttpGet]
        //[Authorize(Roles = "StoreClerk")]
        //[Route("notiLowStock")]
        //public IHttpActionResult sendLowStockMail()
        //{
        //    try
        //    {
        //        EmailNotification.SendLowStockEmail(0);
        //        return Ok("success");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
        //    }
        //}


        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getlist")]
        public IHttpActionResult getDisbursements()
        {
            try
            {
                IList<DisbursementViewModel> lst = helper.GetDisbursements();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getDepartments")]
        public IHttpActionResult depts()
        {
            try
            {
                IList<Department> lst = helper.GetDepartments();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("updateDis")]
        public IHttpActionResult update(Disbursement model)
        {
            try
            {
                helper.updateDisbursement(model);
                return Ok("success");
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
    }
}
