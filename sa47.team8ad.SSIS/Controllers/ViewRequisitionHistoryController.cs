using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using sa47.team8ad.SSIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sa47.team8ad.SSIS.Controllers
{
    public class ViewRequisitionHistoryController : Controller
    {
        utitlityApiRequest _utility = new utitlityApiRequest();


        // GET: ViewRequisitionHistory
        public ActionResult EmpRequisitionHistory(int id)
        {
            List<ItemRequisitionDetailViewModel> item = null;
            String res = _utility.requestGet("id=" + id, "api/requisition/getbyempdetail");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<ItemRequisitionDetailViewModel>>(res);
                for (int i = 0; i < item.Count; i++)
                {
                    res = _utility.requestGet("id=" + item[i].ItemId, "api/requisition/getitembyid");

                    if (!string.IsNullOrEmpty(res))
                    {
                        item[i].Item = JsonConvert.DeserializeObject<ItemViewModel>(res);
                    }
                }
            }

            

            return View(item);
            
        }

        public ActionResult EmpRequisitionHistoryForm()
        {
            
            String id = null;

            EmployeeViewModel empViewModel = null;
            List<ItemRequisitionViewModel> item = null;


            string currentUser = _utility.requestGet("", "api/employee/getemp");
            if (!string.IsNullOrEmpty(currentUser))
            {
                empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                id = empViewModel.id;
            }

            String res = _utility.requestGet("id="+id, "api/requisition/getbyemp");

            if (!string.IsNullOrEmpty(res))
            {
                item = JsonConvert.DeserializeObject<List<ItemRequisitionViewModel>>(res);
            }

            return View(item);
        }

        

    }
}