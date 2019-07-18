using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Providers
{
    public class AuthRepository : IDisposable
    {
        //  private AuthContext _ctx;
        private ssisdbContext _ctx;
        private UserManager<EmployeeModel> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AuthRepository()
        {
            _ctx = new ssisdbContext();
            _ctx.Configuration.LazyLoadingEnabled = false;
            _ctx.Configuration.ProxyCreationEnabled = false;
           _userManager = new UserManager<EmployeeModel>(new UserStore<EmployeeModel>(_ctx));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(EmployeeModel EmployeeModel)
        {
            //IdentityUser user = new IdentityUser
            //{
            //    UserName = EmployeeModel.UserName
            //};
            //  var iuser = new IdentityUser() { UserName = EmployeeModel.UserName, Email = EmployeeModel.Email, Name = EmployeeModel.EMP_M };
            var result = await _userManager.CreateAsync(EmployeeModel, EmployeeModel.Password);

            return result;
        }
       
        public async Task<IdentityResult> AssignRole(EmployeeModel EmployeeModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = EmployeeModel.UserName
            };
            var result = FindUser(EmployeeModel.UserName, EmployeeModel.Password);
            var roleresult = await _userManager.AddToRoleAsync(result.Id.ToString(), "DepartmentHead");
            return roleresult;
        }
        public async Task<IdentityResult> CreateUserRole(string role)
        {
            IdentityRole urole = new IdentityRole
            {
                Name = role
            };
            if (!_roleManager.RoleExists(role))
            {
                var result = await _roleManager.CreateAsync(urole);

                return result;
            }
            return null;
        }
        public async Task<IdentityResult> assignUserRole(UserRoleModel role)
        {
            EmployeeModel user =  FindUserbyId(role.UserId);
            user.AuthorityStartDate = role.AuthorityStartDate;
            user.AuthorityEndDate = role.AuthorityEndDate;
            user.Remark = role.Remark;
            var upd = await _userManager.UpdateAsync(user);

            if (upd.Succeeded)
            {
                var res = await _userManager.AddToRoleAsync(user.Id, "TemporaryDepartmentHead");
                return res;
            }
            return null;
        }

        public async Task<IdentityResult> assignRep(UserRoleModel role,int currentDeptId)
        {
            try
            {
                EmployeeModel user =  FindUserbyId(role.UserId);
                ssisdbContext db = new ssisdbContext();
                var checkExistedRep = db.AspNetUsers.Where(x => x.RepStatus == 1 && x.DepartmentId == currentDeptId).ToList();
                if (checkExistedRep.Count() > 0)
                {
                    foreach (var item in checkExistedRep)
                    {
                        await removeRep(item.Id);
                    }
                }

                user.RepStatus = 1;
                user.Remark = role.Remark;
                var upd = await _userManager.UpdateAsync(user);

                if (upd.Succeeded)
                {
                    var res = await _userManager.AddToRoleAsync(user.Id, "DepartmentRep");
                    return res;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IdentityResult> removeRep(string userid)
        {
            try
            {
                EmployeeModel user =  FindUserbyId(userid);
                if (user.RepStatus == 1)
                {
                    user.RepStatus = 0;
                    await _userManager.UpdateAsync(user);
                    return await _userManager.RemoveFromRoleAsync(userid, "DepartmentRep");
                }
                throw new Exception(string.Format("{0} is not a department representative.", user.EmployeeName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }
        public async Task<IdentityUser> FindUserbyName(string username)
        {
            EmployeeModel user = await _userManager.FindByNameAsync(username);
            return user;
        }
        public EmployeeModel FindUserbyId(string userid)
        {
            EmployeeModel user = _userManager.FindById(userid);
            return user;
        }

        public List<EmployeeModel> getAllUsers(string userid)
        {
            EmployeeModel currentUser = new EmployeeModel();
             currentUser =  FindUserbyId(userid);
            List<EmployeeModel> user =  _userManager.Users.Where(s=>s.Id != userid && s.DepartmentId == currentUser.DepartmentId).ToList();
            return user;
        }
        public List<EmployeeModel> getDelegatedPerson(string userid)
        {
            EmployeeModel currentUser = new EmployeeModel();
           currentUser =  FindUserbyId(userid);
            List<EmployeeModel> user = _userManager.Users.AsEnumerable()
                .Where(s => s.Id != userid && s.DepartmentId == currentUser.DepartmentId 
                && !string.IsNullOrEmpty(s.AuthorityStartDate.ToString())
                && !string.IsNullOrEmpty(s.AuthorityStartDate.ToString())).ToList();
            return user;
        }
        public async Task<System.Security.Claims.ClaimsIdentity> claimsIdentity(EmployeeModel user)
        {
            System.Security.Claims.ClaimsIdentity res = await _userManager.CreateIdentityAsync(user, Microsoft.Owin.Security.OAuth.OAuthDefaults.AuthenticationType);
            return res;
        }

        public EmployeeModel FindEmpById(String Id)
        {
            var curEmp = _userManager.Users.Where(s => s.Id == Id).First();
            return curEmp;
        }

        public DelegationDH FindDelegatedUserbyId(String Id)
        {
            var curEmp = _userManager.Users.Select<EmployeeModel, DelegationDH>
                                        (c => new DelegationDH()
                                        {
                                            UserId = c.Id,
                                            EmployeeName = c.EmployeeName,
                                            DepartmentId = c.DepartmentId,
                                            RepStatus = c.RepStatus,
                                            DelegationStatus = c.DelegationStatus,
                                            AuthorityStartDate = c.AuthorityStartDate,
                                            AuthorityEndDate = c.AuthorityEndDate

                                        }).Where(d => (d.UserId == Id)).First();
            return curEmp;
        }

        public List<DelegationDH> getAllEmp(int dId, string empname)
        {
            List<DelegationDH> user = _userManager.Users.Select<EmployeeModel, DelegationDH>
                                        (c => new DelegationDH()
                                        {
                                            UserId = c.Id,
                                            EmployeeName = c.EmployeeName,
                                            DepartmentId = c.DepartmentId,
                                            RepStatus = c.RepStatus,
                                            DelegationStatus = c.DelegationStatus,
                                            AuthorityStartDate = c.AuthorityStartDate,
                                            AuthorityEndDate = c.AuthorityEndDate

                                        }).Where(d => (d.DepartmentId == dId) && (d.EmployeeName != empname)).ToList<DelegationDH>();
            return user;
        }
        public IdentityResult cancelDelegation(string userId)
        {
            EmployeeModel user = FindUserbyId(userId);
            user.DelegationStatus = 0;
            var upd = _userManager.Update(user);
            
            var rolesForUser = _userManager.GetRoles(userId);

            if (rolesForUser.Count() > 0 && upd.Succeeded)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    var result = _userManager.RemoveFromRole(user.Id, "DepartmentHead");
                    return result;
                }
            }
            return null;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}