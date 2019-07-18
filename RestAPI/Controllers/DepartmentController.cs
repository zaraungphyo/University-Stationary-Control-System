using RestAPI.Models;
using RestAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace RestAPI.Controllers
{

    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        ssisdbContext db = new ssisdbContext();
        BizLogic helper = new BizLogic();


        //[Authorize(Roles = "DepartmentHead")]
        [Authorize]
        [Route("deptinfo")]
        public Department getDeptInfo(int id)
        {
            try
            {
                return helper.GetDeptInfo(id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }


        [Authorize]
        [Route("update")]
        public int UpdateDeptInfo(Department department)
        {
            try
            {
                return helper.UpdateDeptInfo(department);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize]
        [Route("updatecollectionpt")]
        public int UpdateCollectionPt(Department department)
        {
            try
            {
                return helper.UpdateCollectionPt(department);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [HttpGet]
        [Route("getalldeptnames")]
        public List<DeptItemsViewModel> GetAllDeptNames()
        {
            try
            {
                List<DeptItemsViewModel> deptList = helper.GetAllDeptNames();
                return deptList;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }
    }
}