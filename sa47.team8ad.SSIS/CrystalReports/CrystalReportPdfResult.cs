using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Routing;

namespace sa47.team8ad.SSIS.ReportsPdf
{
    // Code to generate pdf versions of crystal reports
    public class CrystalReportPdfResult : ActionResult
    {
        private readonly byte[] _contentBytes;
        public CrystalReportPdfResult()
        {

        }
        public CrystalReportPdfResult(string reportPath, object dataSet)
        {

                ReportDocument rd = new ReportDocument();
                rd.Load(reportPath);
                rd.SetDataSource(dataSet);
                _contentBytes = StreamToBytes(rd.ExportToStream(ExportFormatType.PortableDocFormat));
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_contentBytes == null)
            {
                string controllerName = context.RouteData.Values["controller"].ToString();
                string destinationUrl = string.Empty;
                switch (controllerName)
                {
                    case "ChargeBackReport":
                        destinationUrl = UrlHelper.GenerateUrl(null, "NoChargeBackReport", controllerName, null, RouteTable.Routes, HttpContext.Current.Request.RequestContext, false);
                        context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
                        break;
                    case "ReorderReport":
                        destinationUrl = UrlHelper.GenerateUrl(null, "NoReorderReport", controllerName, null, RouteTable.Routes, HttpContext.Current.Request.RequestContext, false);
                        context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
                        break;
                    case "TrendAnalysisReport":
                        destinationUrl = UrlHelper.GenerateUrl(null, "NoTrendAnalysisReport", controllerName, null, RouteTable.Routes, HttpContext.Current.Request.RequestContext, false);
                        context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
                        break;
                }
            }
            else
            {
                var response = context.HttpContext.ApplicationInstance.Response;
                response.Clear();
                response.Buffer = false;
                response.ClearContent();
                response.ClearHeaders();
                response.Cache.SetCacheability(HttpCacheability.Public);
                response.ContentType = "application/pdf";

                using (var stream = new MemoryStream(_contentBytes))
                {
                    stream.WriteTo(response.OutputStream);
                    stream.Flush();
                }
            }
        }

        private static byte[] StreamToBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}