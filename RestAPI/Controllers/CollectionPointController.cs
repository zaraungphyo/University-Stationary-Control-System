using RestAPI.Models;
using RestAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using RestAPI.Providers;
using Microsoft.AspNet.Identity;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/collectionpoint")]
    public class CollectionPointController : ApiController
    {

        ssisdbContext db = new ssisdbContext();
        BizLogic helper = new BizLogic();

        [HttpGet]
        [Authorize(Roles = "DepartmentHead,DepartmentRep,TemporaryDepartmentHead")]
        [Route("get")]
        public IHttpActionResult getAllCollectionsPoints()
        {
            try
            {
                List<CollectionPoint> list = helper.GetCollectionPoints();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }

        }




        [HttpGet]
        [Authorize(Roles = "DepartmentHead,DepartmentRep,TemporaryDepartmentHead")]
        [Route("getDept")]
        public IHttpActionResult getDepartmentById(int deptId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            try
            {
                Department d = db.Departments.Where(x => x.DepartmentId == deptId).First();
                return Ok(d);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }

        }

        [Authorize(Roles = "DepartmentHead,DepartmentRep,TemporaryDepartmentHead")]
        [Route("update")]
        public IHttpActionResult UpdateCollectionPoint(Department d)
        {
            try
            {
                helper.UpdateCollectionPt(d);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }


        [Authorize(Roles = "DepartmentHead,DepartmentRep,TemporaryDepartmentHead")]

        [Route("getempDept")]
        public IHttpActionResult getEmp()
        {
            try
            {
                using (AuthRepository _repo = new AuthRepository())
                {
                    string na = User.Identity.Name;
                    string id = User.Identity.GetUserId();
                    // List<EmployeeModel> userInfo = _repo.getAllUsers();
                    EmployeeModel currentUser = _repo.FindUserbyId(id);
                    EmployeeDepartmentViewModel ed = helper.GetDepartmentbyEmployeeId(currentUser.Id);
                    return Ok(ed);

                }
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}