using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using MonashApp.Models;


namespace MonashApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us Here!";

            return View();
        }
        
        //POST: Home/Contact
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactViewModel model)
        {
            async Task SendMail(string name, string fromEmail, string message)
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail, name);
                var subject = "Sending with Twilio SendGrid is Fun";
                var to = new EmailAddress("namy.ngu@gmail.com", "Nam's inbox");
                var plainTextContent = message;
                var htmlContent = message;
                Console.WriteLine("Sending email...");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }
            
    }
}