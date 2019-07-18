using Microsoft.AspNet.Identity;
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
    public class DisbursementController : ApiController
    {

        BizLogic helper = new BizLogic();



        [HttpGet]
        [Authorize(Roles = "StoreClerk")]//
        [Route("getdepartment")]
        public IHttpActionResult retrivel()
        {
            try
            {
                IList<DisbursementViewModel> lst = helper.getDisbursementbyDepartment();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }



        [HttpGet]
        [Authorize(Roles = "StoreClerk")]//
        [Route("getByDeptId")]
        public IHttpActionResult retrievalByDept(int deptId)
        {
            try
            {
                IList<DisbursementViewModel> dis = helper.getDisbursementbyDeptID(deptId);
                return Ok(dis);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }






        [HttpGet]
        [Authorize(Roles = "StoreClerk")]//
        [Route("getDisById")]
        public IHttpActionResult retrievalByDeptAndItem(int id)
        {
            try
            {
                DisbursementViewModel dis = helper.getDisbursementbyId(id);
                return Ok(dis);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk")]
        [Route("updatecode")]
        public IHttpActionResult updateQRCode(IList<DisbursementViewModel> lst)
        {
            try
            {
                helper.updateQRCode(lst);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }



        [HttpPost]
        [Authorize(Roles = "StoreClerk")]
        [Route("updateDisItem")]
        public IHttpActionResult updateDisbursement(DisbursementViewModel lst)
        {
            try
            {
                helper.updateDisbursementById(lst);
              
                return Ok("success");
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk")]
        [Route("updateAdjustment")]
        public IHttpActionResult AddSpoiledItemsMoblie(ItemAdjustmentViewModel lst)
        {
            try
            {
                string id = User.Identity.GetUserId();
                string na = User.Identity.GetUserName();
                helper.addSpoiledItem(lst, id);
               

              

                return Ok("success");
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "DepartmentRep")]
        [Route("afterQRDList")]
        public IHttpActionResult afterQRDisbList(String QRCode)
        {
            string id = User.Identity.GetUserId();
            IList<DisbursementViewModel> dis = helper.afterQRDisbList(QRCode, id);
            return Ok(dis);
        }

        [HttpGet]
        [Authorize(Roles = "DepartmentRep")]
        [Route("disbDetail")]
        public IHttpActionResult disbDetail(String disbId)
        {

            int disId = Convert.ToInt32(disbId);
            string id = User.Identity.GetUserId();
            IList<DisbursementViewModel> dis = helper.getDisbDetail(disId, id);
            return Ok(dis);

        }

        [HttpGet]
        [Authorize(Roles = "DepartmentRep")]
        [Route("existQR")]
        public IHttpActionResult existQR(String QRCode)
        {


            string id = User.Identity.GetUserId();
            IList<DisbursementViewModel> dis = helper.existQRCode(QRCode, id);
            return Ok(dis);

        }

        [HttpPost]
        [Authorize(Roles = "DepartmentRep")]
        [Route("afterQR")]
        public bool afterQR(Disbursement items)
        {
            string id = User.Identity.GetUserId();
            bool res = helper.afterQRScan(items, id);

            return res;

        }



    }
}