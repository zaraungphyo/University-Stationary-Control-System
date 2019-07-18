using Microsoft.AspNet.Identity;
using RestAPI.Models;
using RestAPI.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/inventory")]
    public class InventoryController : ApiController
    {
        BizLogic helper ;
        public InventoryController()
        {
            helper = new BizLogic();
        }
        /*ZAR AUNG PHYO*/
        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getInvAdj")]
        public IHttpActionResult getInvAdj()
        {
            try
            {
                IList<ItemAdjustmentViewModel> adjs = helper.getAdjItems();
                return Ok(adjs);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("addInvAdj")]
        public IHttpActionResult addInvAdj(ItemAdjustmentViewModel item)
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool res =  helper.addSpoiledItem(item, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("updInvAdj")]
        public IHttpActionResult updateInvAdj(ItemAdjustmentViewModel item)
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool res = helper.updateSpoiledItem(item, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("removeInvAdj")]
        public IHttpActionResult removeInvAdj(string id)
        {
            try
            {
                bool res = helper.removeSpoiledItem(int.Parse(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        //[HttpPost]
        //[Authorize(Roles = "StoreClerk,Administrator")]
        //[Route("submitInvAdj")]
        //public IHttpActionResult submitAdjs(List<ItemAdjustment> items)
        //{
        //    try
        //    {
        //        string id = User.Identity.GetUserId();
        //        bool res = helper.addAdjustedItems(items);
        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
        //    }
        //}

        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("submitInvAdj")]
        public IHttpActionResult submitAdjs(List<ItemAdjustment> items)
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool res = helper.addAdjustedItems(items);
                List<ItemAdjustmentListViewModel> list = helper.GetListForApproval();
                decimal total = 0;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        total = total + item.AdjustmentValue;
                    }

                }
                EmailNotification.SendAdjustmentListApprovalEmail(total);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        /*HANA NORDIN*/
        // Method using Model Object with ItemId and ItemName to populate into Staionery Requisition 
        //Trend Analysis Report Item DropDownList
        [HttpGet]
        [AllowAnonymous]
        [Route("getallitemdetails")]
        public List<ItemViewModel> GetAllItemDetails()
        {
            try
            {
                List<ItemViewModel> itemList = helper.GetAllItemDetails();
                return itemList;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("search")]
        public List<ItemViewModel> GetSearchItemDetails(string search)
        {
            try
            {
                List<ItemViewModel> itemList = helper.GetSearchItemDetails(search);
                return itemList;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        //---------------------------------------------------------------------------------------------------------
        // Approve Item Adjustment List (Store Supervisor, Store Manager)

        [HttpGet]
        [Authorize(Roles = "StoreSupervisor,StoreManager,Administrator")]
        [Route("listadjforapp")]
        public List<ItemAdjustmentListViewModel> ListAdjForApp()
        {
            try
            {
                List<ItemAdjustmentListViewModel> list = helper.GetListForApproval();
                decimal total = 0;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        total = total + item.AdjustmentValue;
                    }
                    if (User.IsInRole("StoreManager") && total < 250)
                        list = null;
                    else if (User.IsInRole("StoreSupervisor") && total >= 250)
                        list = null;
                    return list;
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        [HttpGet]
        [Authorize(Roles = "StoreSupervisor,StoreManager,Administrator")]
        [Route("adj")]
        public List<ItemAdjustmentViewModel> GetAdjDetails(int id)
        {
            try
            {
                List<ItemAdjustmentViewModel> ItemList = helper.GetAdjustmentDetails(id);
                return ItemList;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Authorize(Roles = "StoreSupervisor,StoreManager,Administrator")]
        [Route("adjApproved")]
        public List<ItemAdjustment> ApproveAdjList(string newRemark)
        {
            try
            {
                List<ItemAdjustment> adjList = helper.ApproveItems(newRemark);
                return null;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        //----------------------------------------------------------------------------------------------
        //Reorder Report (Store Supervisor, Store Manager):
        [HttpGet]
        [Authorize(Roles = "StoreSupervisor,StoreManager,Administrator")]
        [Route("reorderreport")]
        public List<ReorderReportViewModel> GetReorderReport()
        {
            try
            {
                List<ReorderReportViewModel> reorderReport = helper.GetReorderReport();
                return reorderReport;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
        //-------------------------------------------------------------------------------------------
        //Maintain Inventory:
        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getallitems")]
        public List<Item> GetAllItem()
        {
            return helper.GetItems();
        }
        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("update")]
        public int UpdateItem(Item item)
        {
            return helper.UpdateItem(item);
        }
        [HttpGet]
        [Authorize]
        [Route("getallcategories")]
        public List<Category> GetCategories()
        {
            return helper.GetCategories();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("getallunits")]
        public List<MeasurementUnit> MeasurementUnit()
        {
            return helper.MeasurementUnit();
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("getitembyid")]
        public Item GetItemById(int id)
        {
            return helper.GetItemById(id);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("getalllocations")]
        public List<ItemLocation> GetAllLocations()
        {
            return helper.GetAllLocations();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("getallitem")]
        public List<Item> GetAllItems()
        {
            return helper.GetItems();
        }
        [HttpPost]
        [Authorize(Roles = "StoreClerk,Administrator")]
        [Route("createitem")]
        public int CreatItem(Item item)
        {
            return helper.CreateItem(item);
        }

        [AllowAnonymous]
        [Route("getbriefcategory")]
        public List<Category> GetBriefCategories()
        {
            return helper.GetCategories();
        }

        [AllowAnonymous]
        [Route("categoryItem")]
        public List<CategoryItemViewModel> GetCategoriesItem(string cat)
        {
            return helper.GetCategoriesItem(cat);
        }


        //Written by Thett Oo Eain
        //Item for Adjustment
        [Authorize(Roles = "StoreClerk")]
        [Route("item")]
        public CategoryItemViewModel GetItem(string item)
        {
            return helper.GetItem(item);
        }

        //Written by Thett Oo Eain
        //GetAllItem for Adjustment
        [AllowAnonymous]
        [Route("allItem1")]
        public IList<ItemAdjustmentViewModel> GetAllItem1()
        {
            string id = User.Identity.GetUserId();
            return helper.getUnsubmittedAdjItems(id);
        }
        [Authorize(Roles = "StoreClerk")]
        [Route("allItem")]
        public List<CategoryItemViewModel> GetAllItemMobile()
        {
            return helper.GetAllItem();
        }

        [HttpGet]
        [Authorize(Roles = "StoreClerk")]
        [Route("getUnsubmittedInvAdj")]
        public IHttpActionResult getUnsubmittedAdjItems()
        {
            try
            {
                string id = User.Identity.GetUserId();
                IList<ItemAdjustmentViewModel> adjs = helper.getUnsubmittedAdjItems(id);
                return Ok(adjs);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "StoreClerk")]
        [Route("submitAdjItem")]
        public IHttpActionResult submitAdjItem(List<ItemAdjustment> items)
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool res = helper.submitAdjItem(items, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "DepartmentRep")]
        [Route("afterQR")]
        public IHttpActionResult afterQR(Disbursement items)
        {
            try
            {
                string id = User.Identity.GetUserId();
                bool res = helper.afterQRScan(items, id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

    }
}
