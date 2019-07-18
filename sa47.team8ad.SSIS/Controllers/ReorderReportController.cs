using sa47.team8ad.SSIS.Utility;
using sa47.team8ad.SSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using sa47.team8ad.SSIS.ReportsPdf;

namespace sa47.team8ad.SSIS.Controllers
{
    public class ReorderReportController : Controller
    {
        utitlityApiRequest _utility;
        public ReorderReportController()
        {
            _utility = new utitlityApiRequest();
        }
        public ActionResult NoReorderReport()
        {
            return View();
        }
        public ActionResult ViewReorderReport()
        {
            try
            {
                string result = _utility.requestGet("", "api/inventory/reorderreport");
                if (result != "null")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("NoReorderReport");
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(500, ex.Message);
            }
        }
        // Re-order Report to display in iframe:
        public CrystalReportPdfResult ReorderReport()
        {
            string result = _utility.requestGet("", "api/inventory/reorderreport");
            if (result != "null")
            {
                List<ReorderReportViewModel> reorderReport = JsonConvert.DeserializeObject<List<ReorderReportViewModel>>(result);
                string reportPath = Path.Combine(Server.MapPath("~/CrystalReports"), "ReorderReport.rpt");
                return new CrystalReportPdfResult(reportPath, reorderReport);
            }
            else
                return new CrystalReportPdfResult();
        }
    }
}