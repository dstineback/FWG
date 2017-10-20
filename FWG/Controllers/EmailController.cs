using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;

using System.Net;

namespace FWG.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Email()
        {
            return View();
        }

        public ActionResult SendEmail()
        {
            sendEmail();
            return RedirectToAction("Index", "Home");
        }

        protected void sendEmail()
        {
            JavaScriptResult result = new JavaScriptResult() { Script = "alert('Email was sent');" };
            return;
        }

        [HttpPost]
        public ActionResult Login(string from, string emailFrom, string emailSubject, string emailBody)
        {
            try
            {

                string s1 = emailFrom;
                string s2 = from;
                string s3 = emailSubject;
                string s4 = emailBody;

                

                MailMessage mm = new MailMessage();
                SmtpClient smtp = new SmtpClient();


                mm.To.Add("developerfwg@gmail.com");
                mm.To.Add(s1);


                mm.From = new MailAddress("developerfwg@gmail.com");
                mm.Body = s2 + Environment.NewLine + s1 + Environment.NewLine + s4;
                mm.Subject = s3;
                mm.IsBodyHtml = true;
                smtp.Host = ("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("developerfwg@gmail.com", "FWGinc3411");
                smtp.EnableSsl = true;

                smtp.Send(mm);


                return RedirectToAction("Index", "Home");
            } catch
            {
                return RedirectToAction("Email", "Email");
            }
        }
    }
}