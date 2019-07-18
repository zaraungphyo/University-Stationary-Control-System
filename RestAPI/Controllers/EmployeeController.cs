using Microsoft.AspNet.Identity;
using RestAPI.Models;
using RestAPI.Providers;
using RestAPI.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        BizLogic helper = new BizLogic();
        AuthRepository _repo = new AuthRepository();
        [Authorize]
        [Route("getemp")]
        public IHttpActionResult getEmp() {

                string na = User.Identity.Name;
                string id = User.Identity.GetUserId();
                EmployeeModel currentUser =  _repo.FindUserbyId(id);
                return Ok(currentUser);
        }

        [Authorize]
        [Route("getcurrentuser")]
        public IHttpActionResult getCurrentUser()
        {
            try
            {
                string id = User.Identity.GetUserId();
                EmployeeViewModel currentUser = helper.getCurrentUser(id);
                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(RestAPI.Utility.APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize(Roles = "DepartmentHead,Administrator")]
        [Route("getallemp")]
        public IHttpActionResult getEmps()
        {
            using (AuthRepository _repo = new AuthRepository())
            {
                string id = User.Identity.GetUserId();
                List<EmployeeModel> currentUser = _repo.getAllUsers(id);
                return Ok(currentUser);
            }
        }

        [HttpPost]
        [Authorize(Roles = "DepartmentHead,Administrator")]
        [Route("assignemprole")]
        public async Task<IHttpActionResult> assign(UserRoleModel model)
        {
            using (AuthRepository _repo = new AuthRepository())
            {
                string deptHeadName = User.Identity.Name;
                IdentityResult res = await _repo.assignUserRole(model);
                EmailNotification.SendDelegationEmail(model.UserId, deptHeadName);

                return Ok(res.Succeeded);
            }
        }

        [HttpGet]
        [Authorize(Roles = "DepartmentHead,Administrator")]
        [Route("delegation")]
        public IHttpActionResult delegated()
        {

            try
            {
                string id = User.Identity.GetUserId();
                List<EmployeeModel> res = _repo.getDelegatedPerson(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }
        [Authorize]
        [Route("getallempbydept")]
        public IHttpActionResult getAllEmpByDept()
        {
            try
            {
                string DeptHeadId = User.Identity.GetUserId();
                EmployeeModel currentUser =_repo.FindUserbyId(DeptHeadId);
                var deptInfo = helper.getAllEmpByDept(currentUser.DepartmentId, currentUser.Id);
                return Ok(deptInfo);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }
        }

        [Authorize(Roles = "DepartmentHead")]
        [Route("assignrepresentative")]
        public async Task<IHttpActionResult> AssignRepresentative(UserRoleModel roleModel)
        {
            try
            {
                EmployeeModel currentUser =  _repo.FindUserbyId(User.Identity.GetUserId());
                string deptHeadName = User.Identity.Name;
                var res = await _repo.assignRep(roleModel, currentUser.DepartmentId);
                EmailNotification.SendRepAssignmentEmail(roleModel.UserId, deptHeadName);
                return Ok(res.Succeeded);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(APIErrors.ApiError(ex.Message));
            }

        }
        /*Android*/
        [Authorize]
        [Route("getempA")]
        public IHttpActionResult getEmpA()
        {
            using (AuthRepository _repo = new AuthRepository())
            {
                string na = User.Identity.Name;
                string id = User.Identity.GetUserId();
                // List<EmployeeModel> userInfo = _repo.getAllUsers();
                EmployeeModel currentUser = _repo.FindUserbyId(id);
                return Ok(currentUser);

            }
        }

        //Thett
        [Authorize(Roles = "DepartmentHead")]
        [Route("getemp1")]
        public IHttpActionResult getemp1()
        {
            using (AuthRepository _repo = new AuthRepository())
            {
                string na = User.Identity.Name;
                string id = User.Identity.GetUserId();
                DelegationDH currentUser = _repo.FindDelegatedUserbyId(id);

                if (currentUser != null)

                    return Ok(currentUser);
                else
                    return null;

            }
        }



        //Coded by Thett Oo Eain
        [Authorize(Roles = "DepartmentHead")]
        [Route("getallemp1")]
        public async Task<IHttpActionResult> getAllEmpByDepartment()
        {
            using (AuthRepository _repo = new AuthRepository())
            {
                string na = User.Identity.Name;
                string id = User.Identity.GetUserId();
                EmployeeModel currentUser = _repo.FindEmpById(id);
                int deptId = currentUser.DepartmentId;
                string empname = currentUser.EmployeeName;
                List<DelegationDH> userInfo = _repo.getAllEmp(deptId, empname);
                if (userInfo.Count > 0)
                    return Ok(userInfo);
                else
                    return null;
            }
        }

        //Coded by Thett Oo Eain
        [Authorize(Roles = "DepartmentHead")]
        [Route("getemp")]
        public IHttpActionResult getEmpByDepartment(String id)
        {
            using (AuthRepository _repo = new AuthRepository())
            {
                string na = User.Identity.Name;
                string cId = User.Identity.GetUserId();
                DelegationDH currentUser = _repo.FindDelegatedUserbyId(id);

                if (currentUser != null)

                    return Ok(currentUser);
                else
                    return null;
            }
        }
        

        //Written by Thett Oo Eain
        [Authorize(Roles = "DepartmentHead")]
        [Route("assignDH")]
        public int delegateDH(EmployeeModel emp)
        {
            string na = User.Identity.Name;
            return helper.delegateDH(emp, na);
        }

        //Written by Thett Oo Eain
        [Authorize(Roles = "DepartmentHead")]
        [Route("cancelAssignDH")]
        public int cancelDelegateDH(EmployeeModel emp)
        {
            return helper.cancelDelegateDH(emp);
        }

        //Written by Thett Oo Eain
        [Authorize(Roles = "DepartmentHead")]
        [Route("assignRep")]
        public int assignRep(EmployeeModel emp)
        {
            return helper.assignRep(emp);
        }
    }
}
