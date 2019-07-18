using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace RestAPI.Utility
{
    public static class EmailNotification
    {
        private static ssisdbContext db = new ssisdbContext();
        private static readonly string from_email = "sa47.logic.university@gmail.com";

        public static bool SendLowStockEmail()
        {
            try
            {
                BizLogic helper = new BizLogic();
                List<ItemViewModel> lowStockItem = helper.generateOrders(); //get lowstock item
                if (lowStockItem.Count() > 0)
                {
                    string roleId = db.Roles.Where(s => s.Name == "StoreClerk").FirstOrDefault().Id;
                    var storeClerkMail = db.AspNetUsers.Where(x => x.Id == x.Roles.Where(s => s.RoleId == roleId)
                    .FirstOrDefault().UserId).Select(x => new { EmployeeName = x.EmployeeName, Email = x.Email }).ToList();

                    string type = "Low Stock";
                    string content = "You have recently requested for a low stock item report for the Logic University on";
                    byte[] pdfByte = generatePDF(lowStockItem,"Low Stock Items");
                    for (int i = 0; i < storeClerkMail.Count(); i++)
                    {
                        var _to = storeClerkMail.ElementAt(i).EmployeeName;
                        sendEmail(storeClerkMail.ElementAt(i).Email, type, content, _to, pdfByte);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool SendDelegationEmail(string empid,string depthead) {
            try
            {
                var emp = db.AspNetUsers.Where(s => s.Id == empid).FirstOrDefault();
                string type = "Delegate Authority";
                string content = "Please be informed that " + depthead + " has delegated the Approval of Department Staff's Stationery Request to you for the period from " + emp.AuthorityStartDate.Value.Date + " to " + emp.AuthorityEndDate.Value.Date + ".";
                sendEmail(emp.Email, type, content, emp.EmployeeName, null);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool sendSupplieronPurchase(List<ItemViewModel> items) {
            try
            {
                string type = "Purchase Order from Logic University";
                string content = "The following attachment is a purchase order from Logic University. Please Confirm whether you can supply the following items.";

                foreach (ItemViewModel item in items)
                {
                    var purchasedItems = items.Where(x => x.supplierId == item.supplierId).ToList();
                    var supplier = db.Suppliers.Where(x => x.SupplierId == item.supplierId).FirstOrDefault();

                    byte[] pdfByte = generatePDF(purchasedItems, "Purchase Order from Logic University");
                    sendEmail(supplier.Email, type, content, string.Format("{0} ({1})", supplier.ContactName, supplier.SupplierName), pdfByte);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static bool SendRepAssignmentEmail(string empid, string depthead)
        {
            try
            {
                var emp = db.AspNetUsers.Where(s => s.Id == empid).FirstOrDefault();
                string type = "Department Representative Assignment";
                string content = "Please be informed that " + depthead + " has assigned you to be the Department Representative for all stationery-related matters.";
                sendEmail(emp.Email, type, content, emp.EmployeeName, null);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static bool SendRequisitionApprovalEmail(string empid)
        {
            try
            {
                var emp = db.AspNetUsers.Where(s => s.Id == empid).FirstOrDefault();
                string roleId = db.Roles.Where(s => s.Name == "DepartmentHead").FirstOrDefault().Id;
                var depthead = db.AspNetUsers.Where(x => x.DepartmentId == emp.DepartmentId && x.Id == x.Roles.Where(s => s.RoleId == roleId)
               .FirstOrDefault().UserId).Select(x => new { EmployeeName = x.EmployeeName, Email = x.Email }).FirstOrDefault();

                string type = "Department Employee Stationery Requisition Form for Your Approval";
                string content = "Please be informed that " + emp.EmployeeName + " has submitted a Stationery Requisiton Form for your approval. " +
                    "Please log in to the SSIS to approve or reject the request.";
                sendEmail(depthead.Email, type, content, depthead.EmployeeName, null);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static bool SendAdjustmentListApprovalEmail(decimal total)
        {
            try
            {
                if (total < 250)
                {
                    string roleId = db.Roles.Where(s => s.Name == "StoreSupervisor").FirstOrDefault().Id;
                    var storesupervisor = db.AspNetUsers.Where(x => x.Id == x.Roles.Where(s => s.RoleId == roleId)
                   .FirstOrDefault().UserId).Select(x => new { EmployeeName = x.EmployeeName, Email = x.Email }).FirstOrDefault();

                    string type = "Inventory Adjustment Voucher for Your Approval";
                    string content = "Please be informed that the monthly inventory adjustment voucher has been submitted for your approval. " +
                        "Please log in to the SSIS to view and approve the voucher.";
                    sendEmail(storesupervisor.Email, type, content, storesupervisor.EmployeeName, null);
                    return true;
                }
                if (total >= 250)
                {
                    string roleId = db.Roles.Where(s => s.Name == "StoreManager").FirstOrDefault().Id;
                    var storemanager = db.AspNetUsers.Where(x => x.Id == x.Roles.Where(s => s.RoleId == roleId)
                   .FirstOrDefault().UserId).Select(x => new { EmployeeName = x.EmployeeName, Email = x.Email }).FirstOrDefault();

                    string type = "Inventory Adjustment Voucher for Your Approval";
                    string content = "Please be informed that the monthly inventory adjustment voucher has been submitted for your approval. " +
                        "Please log in to the SSIS to view and approve the voucher.";
                    sendEmail(storemanager.Email, type, content, storemanager.EmployeeName, null);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        private static byte[] generatePDF(List<ItemViewModel> lowStockItem,string Title)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    string companyName = "Logic University";

                    #region generate table
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>"+ Title + "</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td>");
                    sb.Append(companyName);
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    sb.Append("<td align='center'> Item Desc </td>");
                    sb.Append("<td align='center'> Reorder Level </td>");
                    sb.Append("<td align='center'> Reorder Quantity </td>");
                    sb.Append("<td align='center'> Quantity On Hand </td>");
                    sb.Append("</tr>");
                    #endregion

                    foreach (ItemViewModel row in lowStockItem)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td align='center'>" + row.ItemDescription + "</td>");
                        sb.Append("<td align='center'>" + row.ReorderLevel + "</td>");
                        sb.Append("<td align='center'>" + row.ReorderQuantity + "</td>");
                        sb.Append("<td align='center'>" + row.QuantityOnHand + "</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        return bytes;
                    }
                }
            }
        }
        private static void sendEmail(string to_email,string type,string content,string _to,byte[] pdfByte) {
            using (SmtpClient client = new SmtpClient())
            {
                var date = DateTime.Now.ToString("dd MMMM yyyy h:mm tt");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from_email);
                msg.To.Add(to_email);
                msg.Subject = type;
                msg.IsBodyHtml = false;
                string attachWord = pdfByte == null ? "" : "Kindly refer to the attachment." + Environment.NewLine;

                msg.Body = "Dear" + " " + _to + "," + Environment.NewLine + Environment.NewLine 
                            +  content + " " + date + Environment.NewLine + Environment.NewLine 
                            + attachWord + Environment.NewLine + "Thank you.";
                if (pdfByte != null)
                {
                    msg.Attachments.Add(new Attachment(new MemoryStream(pdfByte), "LowStockItems.pdf"));
                }
                msg.Priority = MailPriority.High;
                client.Send(msg);
            }
        }
    }
}