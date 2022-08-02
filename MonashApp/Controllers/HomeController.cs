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
            if(ModelState.IsValid)
            {
                SendMail(model.Name, model.Email, model.Subject, model.Message, model.File).Wait();
            }
            else
            {
                return View(model);
            }

            ModelState.Clear();
            return View();
        }

        //Method to send email using SendGrid
        public async Task SendMail(string name, string fromEmail, string emailSubject, string message, HttpPostedFileBase file)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, name);
            var subject = emailSubject;
            var to = new EmailAddress("namy.ngu@gmail.com", "Nam's inbox");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            //upload file as attachment
            if (file != null && file.ContentLength > 0)
            {
                string content = System.IO.File.ReadAllText(file.ToString());
                msg.AddAttachment(file.FileName, content);
            }

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }

        //Method to convert string to base64content
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}