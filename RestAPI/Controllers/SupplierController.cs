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
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {
        ssisdbContext db = new ssisdbContext();
        BizLogic helper = new BizLogic();

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getallsuppliers")]
        public List<Supplier> GetAllSupplier()
        {
            try
            {
                return helper.GetAllSuppliers();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("edit")]
        public int UpdateSupplier(Supplier supplier)
        {
            try
            {
                return helper.UpdateSupplier(supplier);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getsupplierbyid")]
        public Supplier GetSupplierbyID(int sprid)
        {
            try
            {
                return helper.GetSupplierById(sprid);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }       

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("createsupplier")]
        public int CreateNewSupplier(Supplier supplier)
        {
            try
            {
                return helper.CreateNewSupplier(supplier);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }  

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getsupplieritemlistbyid")]
        public List<SupplierItemViewModel> GetSupplierItemListById(int sprid)
        {
            try
            {
                return helper.GetSupplierItemListById(sprid);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getsupplieritembyid")]
        public SupplierItem GetSupplierItemById(int id)
        {
            try
            {
                return helper.GetSupplierItemById(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }


        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("createsupplieritem")]
        public int CreateSupplierItem(SupplierItem item)
        {
            try
            {
                return helper.CreateSupplierItem(item);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("editsupplieritem")]
        public int EditSupplierItem(SupplierItem item)
        {
            try
            {
                return helper.UpdateSupplierItem(item);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("deletesupplieritem")]
        public int DeleteSupplierItem(int id)
        {
            try
            {
                return helper.DeleteSupplierItem(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }


    }
}
