using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using sa47.team8ad.SSIS.ReportsPdf;
using sa47.team8ad.SSIS.Utility;

namespace sa47.team8ad.SSIS.Controllers
{
    public class TrendAnalysisReportController : Controller
    {
        utitlityApiRequest _utility;
        public TrendAnalysisReportController()
        {
            _utility = new utitlityApiRequest();
        }
        
        public ActionResult NoTrendAnalysisReport()
        {
            return View();
        }
        // Generate Trend Analysis Report Page:
        [HttpGet]
        public ActionResult GenerateTrendAnalysisReport()
        {
            // Get list of all departments (departmentId & departmentName): 
            string result = _utility.requestGet("", "api/department/getalldeptnames");
            List<DeptItemsViewModel> depts = JsonConvert.DeserializeObject<List<DeptItemsViewModel>>(result);

            //populate department listBox:
            List<SelectListItem> deptListBoxItems = new List<SelectListItem>();

            foreach (DeptItemsViewModel dept in depts)
            {
                SelectListItem selectedList = new SelectListItem()
                {
                    Text = dept.DepartmentName,
                    Value = dept.DepartmentId.ToString()
                };
                deptListBoxItems.Add(selectedList);
            }
            ViewBag.bindDepartments = deptListBoxItems;

            // Get list of all items (itemId & itemName): 
            string result2 = _utility.requestGet("", "api/inventory/getallitemdetails");
            List<ItemViewModel> items = JsonConvert.DeserializeObject<List<ItemViewModel>>(result2);
            var y = items.Select(b => new SelectListItem
            {
                Text = b.ItemDescription,
                Value = b.ItemId.ToString()
            }).ToList();
            ViewBag.bindItems = y;
            return View();
        }

        // Opens generated Stationery Requistion Trend Analysis Report in a PDF Viewer in a new browser tab
        // In html: 1) Post method target is iframe name  2) iframe only shows if IsPost=true
        [HttpPost]
        public CrystalReportPdfResult GenerateTrendAnalysisReport(TrendAnalysisViewModel vm)
        {
            string result = _utility.requestPost(vm, "api/requisition/strReport");
            if (result != "null")
            {
                List<TrendAnalysisReportViewModel> stationeryTrendAnalysisReport = JsonConvert.DeserializeObject<List<TrendAnalysisReportViewModel>>(result);
                string reportPath = Path.Combine(Server.MapPath("~/CrystalReports"), "StationeryTrendAnalysisReport.rpt");
                return new CrystalReportPdfResult(reportPath, stationeryTrendAnalysisReport);
            }
            else
                return new CrystalReportPdfResult();
        }

    }
}