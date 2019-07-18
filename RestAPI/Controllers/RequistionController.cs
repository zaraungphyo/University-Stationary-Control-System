using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using RestAPI.Utility;
using Microsoft.AspNet.Identity;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/requisition")]
    public class RequistionController : ApiController
    {
        ssisdbContext db = new ssisdbContext();
        BizLogic helper = new BizLogic();

        /*SOE YADANA KO HTET*/

        [Authorize]
        [Route("getallemp")]
        public List<ItemRequisitionsViewModel> getAllEmpItemRequisition()
        {
            try
            {
                string id = User.Identity.GetUserId();
                return helper.GetAllEmpItemRequistion(id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getallemphistory")]
        public List<ItemRequisition> getAllEmpItemRequisitionHistory()
        {
            try
            {
                return helper.getAllEmpItemRequisitionHistory();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }


        [Authorize]
        [Route("create")]
        public int CreateItemRequistion(ItemRequisition item)
        {
            try
            {
                var itemReq = helper.CreateItemRequistion(item);
                string empid = item.EmployeeId;
                EmailNotification.SendRequisitionApprovalEmail(empid);
                return itemReq;
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        //[Authorize(Roles = "DepartmentRep , Employee")]
        [Authorize]
        [Route("createdetails")]
        public int CreateItemRequistionDetails(List<ItemRequisitionDetail> item)
        {
            try
            {
                return helper.CreateItemRequistionDetails(item);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        //[Authorize(Roles = "DepartmentRep , Employee")]
        [Authorize]
        [Route("getbyemp")]
        public List<ItemRequisition> getEmpItemRequistion(string id)
        {
            try
            {
                return helper.GetEmpItemRequistion(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getitemreqbyreqid")]
        public ItemRequisition getItemRequistionByreqId(int id)
        {
            try
            {
                return helper.getItemRequistionByreqId(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }
        [Authorize]
        [Route("getitemdetailbyitemid")]
        public ItemRequisitionDetail getItemRequistionDetailbyItemId(int id, int itemId)
        {
            try
            {
                return helper.getItemRequistionDetailbyItemId(id, itemId);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("updateitemdetailstatus")]
        public int updateItemDetailStatus(ItemRequisitionDetail item)
        {
            try
            {
                return helper.updateItemDetailStatus(item);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getitemreqdetailbyid")]
        public List<ItemRequisitionDetail> getEmpItemRequistionDetailsById(int id)
        {
            try
            {
                return helper.getEmpItemRequistionDetailsById(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }
        [Authorize]
        [Route("returnitemadj")]
        public int ReturnItemAdj(ItemAdjustment itemAdj)
        {
            try
            {
                return helper.ReturnItemAdj(itemAdj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("returnitem")]
        public int ReturnItem(Disbursement disbursement)
        {
            try
            {
                return helper.ReturnItem(disbursement);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }
        //[Authorize(Roles = "DepartmentRep , Employee")]
        [Authorize]
        [Route("getbyemplast")]
        public ItemRequisition getEmpItemRequistionLast(string id)
        {
            try
            {
                List<ItemRequisition> lastItem = helper.GetEmpItemRequistionLast(id);
                return lastItem[lastItem.Count - 1];
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getitembycategory")]
        public List<Item> GetItemsByCategory(int id)
        {
            try
            {
                return helper.GetItemsByCategory(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getcategory")]
        public List<Category> GetCategories()
        {
            try
            {
                return helper.GetCategories();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getcategorybyid")]
        public Category GetCategoryById(int id)
        {
            try
            {
                return helper.GetCategoryById(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getunit")]
        public List<MeasurementUnit> GetMeasurementUnit()
        {
            try
            {
                return helper.GetMeasurementUnit();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        //[Authorize(Roles = "DepartmentHead")]
        [Authorize]
        [Route("update")]
        public int UpdateItemRequisition(ItemRequisition item)
        {
            try
            {
                return helper.UpdateItemRequisition(item);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getallitem")]
        public List<Item> GetAllItem()
        {
            try
            {
                return helper.GetItems();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getitembyid")]
        public Item GetItemById(int id)
        {
            try
            {
                return helper.GetItemById(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getbyempdetail")]
        public List<ItemRequisitionDetail> getEmpItemRequistionDetail(int id)
        {
            try
            {
                return helper.GetEmpItemRequistionDetail(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getempinfobyid")]
        public EmployeeModel getEmpbyId(string id)
        {
            try
            {
                return helper.getEmpbyId(id);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("getdeptdisbursementlist")]
        public List<Disbursement> getDeptDisbursementList(int id)
        {
            try
            {
                return helper.getDeptDisbursementList(id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        /*HANA NORDIN*/

        //------------------------------------------------------------------------------------------
        //Generate Charge-Back Report (Store Supervisor, Store Manager):
        [HttpGet]
        [Authorize(Roles = "StoreSupervisor,StoreManager,Administrator")]
        [Route("chargeBackReport")]
        public List<DeptExpenditureViewModel> GenerateChargeBackRpt()
        {
            try
            {
                List<DeptExpenditureViewModel> chargeBackReport = helper.GenerateChargeBackRpt();
                return chargeBackReport;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------------
        //Generate Stationery Requisition Trend Analysis Report (Store Supervisor, Store Manager):
        //Post method to retrieve values to populate into Stationery Requisition Trend Analysis Report
        [HttpPost]
        [Authorize(Roles = "StoreSupervisor,StoreManager,StoreClerk,Administrator")]
        [Route("strReport")]
        public List<TrendAnalysisReportViewModel> GenerateTrendAnalysisRpt(TrendAnalysisViewModel tar)
        {
            try
            {
                List<TrendAnalysisReportViewModel> trendAnalysisReport = helper.GenerateTrendAnalysisRpt(tar);
                return trendAnalysisReport;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [Route("getempByDept")]
        public IHttpActionResult GetRequisitionByDeptId()
        {
            try
            {
                string id = User.Identity.GetUserId();
                string na = User.Identity.GetUserName();
                IList<ItemRequisitionsViewModel> lst = helper.GetRequisitionByDeptId(id);

                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }

        }

        
        [HttpGet]
        [Authorize]
        [Route("getreqdetails")]
        public IHttpActionResult getAllEmpItemRequisitionDetails(int requisitionId, String approveStatus)
        {
            try
            {
                List<ItemRequisitionsDetailsViewModel> list = helper.GetItemRequisitionDetailByreqId(requisitionId, approveStatus);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }

        }

        [Authorize]
        [Route("getbyemp")]
        public IHttpActionResult getEmpItemRequisition(string empId)
        {
            try
            {
                List<ItemRequisition> lst = helper.GetEmpItemRequisition(empId);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }

        }

        [Authorize]
        [Route("updateDetail")]
        public IHttpActionResult UpdateItemRequisitionDetail(ItemRequisitionDetail item)
        {
            try
            {
                helper.UpdateItemRequisitionDetail(item);
                return Ok("success");
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        //[Authorize]
        //[Route("getempitemcollectiondetail")]
        //public List<EmpCollectionItemViewModel> getEmpItemCollectionDetail(int id, String qrCode)
        //{
        //    try
        //    {
        //        return helper.getEmpItemCollectionDetail(id, qrCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
        //    }
        //}
    }
}