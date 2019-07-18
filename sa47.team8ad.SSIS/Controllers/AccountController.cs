using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using sa47.team8ad.SSIS.Utility;

namespace sa47.team8ad.SSIS.Controllers
{
    public class AccountController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        utitlityApiRequest utility = new utitlityApiRequest();
        public AccountController(){ }
        
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    bool isAuthorize = await utility.AuthorizeApiToken(model);
                    if (isAuthorize)
                    {
                        string stringContent = utility.requestGet("", "api/employee/getcurrentuser");
                        if (!string.IsNullOrEmpty(stringContent))
                        {
                            EmployeeViewModel currentUser = JsonConvert.DeserializeObject<EmployeeViewModel>(stringContent);
                            
                            System.Web.HttpContext.Current.Session["currentUser"] = currentUser;
                            if (currentUser.Roles.Any(s => s.RoleName.Contains("Administrator")))
                            {
                                return RedirectToAction("RetrieveStationery", "Retrieval");
                            }
                            if (currentUser.Roles.Any(s=>s.RoleName.Contains("StoreClerk")))
                            {
                                return RedirectToAction("RetrieveStationery", "Retrieval");
                            }
                            else if(currentUser.Roles.Any(s => s.RoleName.Contains("DepartmentHead")))
                            {
                                return RedirectToAction("ApproveReject", "ApproveReject");
                            }
                            else if (currentUser.Roles.Any(s => s.RoleName.Contains("StoreSupervisor")))
                            {
                                return RedirectToAction("GenerateTrendAnalysisReport", "TrendAnalysisReport");
                            }
                            else if (currentUser.Roles.Any(s => s.RoleName.Contains("StoreManager")))
                            {
                                return RedirectToAction("GenerateTrendAnalysisReport", "TrendAnalysisReport");
                            }
                            else if (currentUser.Roles.Any(s => s.RoleName.Contains("DepartmentRep")))
                            {
                                return RedirectToAction("CollectionItem", "AckReceiveofItemCollect");
                            }
                            else if (currentUser.Roles.Any(s => s.RoleName.Contains("Employee")))
                            {
                                return RedirectToAction("EmpRequisitionHistoryForm", "ViewRequisitionHistory");
                            }
                        }
                    }
                }
                return View(model);
            }
            catch (System.Exception ex)
            {
                throw new HttpException(404, ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserProfile() {
            EmployeeViewModel user = (EmployeeViewModel)Session["currentUser"];
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserProfile(EmployeeViewModel vm)
        {
            return View(vm);
        }
        //
        // POST: /Account/LogOff
        [HttpGet]
        public ActionResult LogOff()
        {
            Session["currentUser"] = null;
            Session["sessionString"] = null;
            Session["ItemLists"] = null;
            Session["message"] = null;
            Session["messageError"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}