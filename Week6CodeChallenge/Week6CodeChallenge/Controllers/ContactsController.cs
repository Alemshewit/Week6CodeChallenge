using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace Week6CodeChallenge.Controllers
{
    public class ContactsController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.ContactForm());
        }


        [HttpPost]
        public ActionResult Index(Models.ContactForm contactForm)
        {
            //sending an email
            //setp1. add using system.Net.Mail
            //step2. create a new message
            //first para is who it is from, and the second is who it's to.
            MailMessage mailmessage = new MailMessage("theRobots@seedpaths.com", "alemshewit@gmail.com");
            //step 3 Set the subject
            mailmessage.Subject = "Contact Request from " + contactForm.FirstName + " " + contactForm.LastName;
            //step 4 Contstruct eh body with a stringBuilder
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("You have a ew contact request");
            sb.AppendLine("Name: " + contactForm.FirstName);
            sb.AppendLine("Email: " + contactForm.Email);
            sb.AppendLine("Message: " + contactForm.Message);
            sb.AppendLine("I love you,");
            sb.AppendLine("The Robots");
            //step5 Add teh body tot he message
            mailmessage.Body = sb.ToString();

            //step6 Declare the SMTP client aka. The mail server
            SmtpClient smtpClient = new SmtpClient("mail.dustinkraft.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");
            //step7 send the message
            smtpClient.Send(mailmessage);
            //done.
            //kick the user to the thank you page
            if (Request.IsAjaxRequest())
            {
                return PartialView("Thankyou");
            }
            else

                return RedirectToAction("ThankYou", "Contact");


        }
    }
}
