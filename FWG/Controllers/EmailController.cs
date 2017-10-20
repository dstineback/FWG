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

        public ActionResult SignUpView()
        {
            return View();
        }

        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string company, string contactNumber, string from,  string email,  string comments)
        {
            try
            {
            string _from = from;
            string _ConactNumber = contactNumber;
            string _email = email;
            string _Company = company;
            string _Comments = comments;

                MailMessage mm = new MailMessage();
                MailMessage mmr = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                mm.To.Add("developerfwg@gmail.com");
                //mm.To.Add(_email);
                mm.From = new MailAddress("developerfwg@gmail.com");
                mm.Body = "Client Name: " + _from + Environment.NewLine +
                    "Email: " + _email + Environment.NewLine +
                    "Contact Number: " + _ConactNumber + Environment.NewLine +
                    "Company: " + _Company + Environment.NewLine +
                    "Comments: " + _Comments;
                mm.Subject = "Sign up request - " + _from + " " + _Company;
                mm.IsBodyHtml = true;
                smtp.Host = ("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("developerfwg@gmail.com", "FWGinc3411");
                smtp.EnableSsl = true;
                //smtp.Send(mm);

                mmr.To.Add(_email);
                mmr.From = mm.From;
                mmr.Body = "Thank you " + _from + " for requesting to sign up for M-Pet. A Four Winds represenative has been informed will be contacting you in the near future. Until then if you have any other quesitons please feel free to browse our prodcut sites. Thank you for choosing M-PET & look forward with to speaking with you." + Environment.NewLine +
                    "Thank you, " + Environment.NewLine + "Jon Mangerich" + Environment.NewLine +
                    "President" + Environment.NewLine +
                    "Four Winds Group, inc.";
                mmr.Subject = "Confirmation sign up request - Four Winds Group, inc.";
                mmr.IsBodyHtml = true;
                smtp.Host = ("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("developerfwg@gmail.com", "FWGinc3411");
                smtp.EnableSsl = true;
                smtp.Send(mmr);


                TempData["messageSuccess"] = "Request Sent, a representative will contact you.";




                return View("SignUpView");

            }
            catch
            {
                TempData["messageError"] = "Error, could not send request.";
                return View("SignUpView");
            }
         
        }      
        [HttpPost]
        public ActionResult SendEmail(string from, string emailFrom, string emailSubject, string emailBody)
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

                TempData["messageSuccess"] = "Email Sent";

                return View("Email");
            } catch
            {
                TempData["messageError"] = "Error, Could not send Email.";
               
                return View("Email");
            }
        }
    }
}