using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using MonashApp.Models;
using Microsoft.AspNet.Identity;

namespace MonashApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            ViewBag.userId = User.Identity.GetUserId();

            return View(db.Products.ToList());
        }

        //POST: Add product to cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(int productId)
        {
            Product newItem = db.Products.Find(productId);
            Startup.ShoppingCart.Add(newItem);

            return View(db.Products.ToList());
        }
           
        /*
        //POST: Home/Index - method to display items in their categories.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(string mainCategory)
        {
            //Get main category from name
            MainCategory category = db.MainCategories.Where(cat => cat.Name == mainCategory).FirstOrDefault();
            List<SubCategory> subcategories = new List<SubCategory>();
            subcategories = category.SubCategories.ToList();

            List<Product> filterItems = new List<Product>();

            foreach (SubCategory cat in subcategories)
            {
                foreach (Product product in db.Products)
                {
                    if (product.SubCategoryId == cat.Id)
                    {
                        filterItems.Add(product);
                    }
                }
            }

            return View(filterItems.ToList());
        }
        */

        //GET: View cart
        [AllowAnonymous]
        public ActionResult ViewCart()
        {
            return View(Startup.ShoppingCart);
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