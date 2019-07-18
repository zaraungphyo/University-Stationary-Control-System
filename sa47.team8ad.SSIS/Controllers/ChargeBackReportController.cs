using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using sa47.team8ad.SSIS.Models;
using sa47.team8ad.SSIS.ReportsPdf;
using sa47.team8ad.SSIS.Utility;

namespace sa47.team8ad.SSIS.Controllers
{
    public class ChargeBackReportController : Controller
    {
        utitlityApiRequest _utility;
        public ChargeBackReportController()
        {
            _utility = new utitlityApiRequest();
        }
        // NOTE: Screen is not needed when there is a menu bar! 
        public ActionResult NoChargeBackReport()
        {
            return View();
        }

        public ActionResult ViewChargeBackReport()
        {
            string result = _utility.requestGet("", "api/requisition/chargeBackReport");
            if (result != "null")
            {
                return View();
            }
            else
                return RedirectToAction("NoChargeBackReport");
        }

        // Charge-Back Report to display in iframe:
        public CrystalReportPdfResult ChargeBackReport()
        {
            string result = _utility.requestGet("", "api/requisition/chargeBackReport");
            if (result != "null")
            {
                List<ChargeBackReportViewModel> chargeBackReport = JsonConvert.DeserializeObject<List<ChargeBackReportViewModel>>(result);
                string reportPath = Path.Combine(Server.MapPath("~/CrystalReports"), "ChargeBackReport.rpt");
                return new CrystalReportPdfResult(reportPath, chargeBackReport);
            }
            else
                return new CrystalReportPdfResult();
        }
    }
}