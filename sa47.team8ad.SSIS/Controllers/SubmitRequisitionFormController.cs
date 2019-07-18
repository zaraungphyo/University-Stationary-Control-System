using sa47.team8ad.SSIS.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sa47.team8ad.SSIS.Models;

namespace sa47.team8ad.SSIS.Controllers
{
    public class SubmitRequisitionFormController : Controller
    {
        //    static List<ItemRequisitionDetailViewModel> items = new List<ItemRequisitionDetailViewModel>();
       // List<ItemRequisitionDetailViewModel> items;
        utitlityApiRequest _utility;
      //  utitlityApiRequest _utility = new utitlityApiRequest();
        public SubmitRequisitionFormController()
        {
             //items = new List<ItemRequisitionDetailViewModel>();
            _utility = new utitlityApiRequest();
            //System.Web.HttpContext.Current.Session["items"] = new List<ItemRequisitionDetailViewModel>();
        }

        // GET: SubmitRequisitionForm
        public ActionResult RequistionForm()
        {
            var vm = (List<ItemRequisitionDetailViewModel>)System.Web.HttpContext.Current.Session["items"];
            return View(vm);
        }

        [HttpPost]
        public ActionResult RequistionForm(string button)
        {
            ItemRequisitionViewModel lastItem = null;
            ItemRequisitionViewModel itemform = new ItemRequisitionViewModel();
            EmployeeViewModel empViewModel = null;

            string currentUser = _utility.requestGet("", "api/employee/getemp");
            if (!string.IsNullOrEmpty(currentUser))
            {
                empViewModel = JsonConvert.DeserializeObject<EmployeeViewModel>(currentUser);
                itemform.EmployeeId = empViewModel.id;
            }
            if (button == "Confirm")
            {
                itemform.RequisitionDate = System.DateTime.Now.Date;
                itemform.ApproveStatus = "";
                //itemform.Employee = empViewModel;
                itemform.Status = 0;
                var items = (List<ItemRequisitionDetailViewModel>)System.Web.HttpContext.Current.Session["items"];
                for (int i = 0; i < items.Count(); i++)
                {
                    items[i].Item.Category = null;
                    items[i].Item = null;
                }
                
                string res = _utility.requestPost(itemform, "api/requisition/create");

                if (res == "1")
                {
                    //Success
                    res = _utility.requestGet("id="+empViewModel.id, "api/requisition/getbyemplast");
                    if (!string.IsNullOrEmpty(res))
                    {
                        lastItem = JsonConvert.DeserializeObject<ItemRequisitionViewModel>(res);

                        for (int i = 0; i < items.Count; i++)
                        {
                            items[i].RequisitionId = lastItem.RequisitionId;
                        }


                        res = _utility.requestPost(items, "api/requisition/createdetails");

                        if (res == "1")
                        {
                            TempData["message"] = "successfully submitted requisition.";
                            System.Web.HttpContext.Current.Session["items"] = null;
                            return RedirectToAction("AddItem");
                        }

                    }
                }
            }
            else if (button == "Cancel")
            {
                TempData["message"] = "Successfully cancelled.";
                System.Web.HttpContext.Current.Session["items"] = null;
                return Redirect("AddItem");
            }
            TempData["errorMessage"] = "Failed to submit item requisition";
            return Redirect("RequistionForm");

        }

        public ActionResult AddItem()
        {
            if (Session["items"] == null)
            {
                System.Web.HttpContext.Current.Session["items"] = new List<ItemRequisitionDetailViewModel>();
            }
            string res = _utility.requestGet("", "api/requisition/getallitem");
            if (!string.IsNullOrEmpty(res))
            {
                List<ItemViewModel> category = JsonConvert.DeserializeObject<List<ItemViewModel>>(res);
                ViewBag.ItemDropDown = category;
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(ItemRequisitionDetailViewModel item, String submit)
        {
            if (submit == "Add")
            {
                string res = _utility.requestGet("id=" + item.ItemId, "api/requisition/getitembyid");
                ItemViewModel subItem = null;
                if (!string.IsNullOrEmpty(res))
                {
                    subItem = JsonConvert.DeserializeObject<ItemViewModel>(res);

                }
                res = _utility.requestGet("id=" + subItem.CategoryId.ToString(), "api/requisition/getcategorybyid");
                CategoryViewModel catItem = null;
                if (!string.IsNullOrEmpty(res))
                {
                    catItem = JsonConvert.DeserializeObject<CategoryViewModel>(res);
                }
                item.Item = subItem;
                item.Item.Category = catItem;
                //items.Add(item);
                var items = (List<ItemRequisitionDetailViewModel>)System.Web.HttpContext.Current.Session["items"];
                items.Add(item);
                System.Web.HttpContext.Current.Session["items"] = items;

                return RedirectToAction("RequistionForm");
            }
            return RedirectToAction("AddItem");
        }

        

        public ActionResult EditItem(int itemId)
        {
            var items = (List<ItemRequisitionDetailViewModel>)System.Web.HttpContext.Current.Session["items"];
       
            int i = items.FindIndex(x=> x.ItemId == itemId);
            ItemRequisitionDetailViewModel itemdetail = items[i];
            return View(itemdetail);
        }
        [HttpPost]
        public ActionResult EditItem(ItemRequisitionDetailViewModel editItem)
        {
            var items = (List<ItemRequisitionDetailViewModel>)System.Web.HttpContext.Current.Session["items"];
           // items.Add(item);
           

            int i = items.FindIndex(x => x.ItemId == editItem.ItemId);
            items[i].NeededQuantity=editItem.NeededQuantity;
            System.Web.HttpContext.Current.Session["items"] = items;
            return RedirectToAction("RequistionForm");
        }
        public ActionResult RemoveItem(int itemId)
        {
            var items = (List<ItemRequisitionDetailViewModel>)System.Web.HttpContext.Current.Session["items"];
            int i = items.FindIndex(x => x.ItemId == itemId);
            items.RemoveAt(i);
            System.Web.HttpContext.Current.Session["items"] = items;
            return RedirectToAction("RequistionForm");
        }
    }
}