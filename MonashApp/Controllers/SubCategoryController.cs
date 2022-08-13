using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    [RequireHttps]
    [Authorize]
    public class SubCategoryController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();

        // GET: SubCategory
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.SubCategories.ToList());
        }

        // GET: SubCategory/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubCategory/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: SubCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var subCategory = db.SubCategories.Where(sub => sub.Id == id).FirstOrDefault();
            return View(subCategory);
        }

        // POST: SubCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubCategory category)
        {
            try
            {
                if (!db.SubCategories.Any(cat => cat.Name == category.Name))
                {
                    SubCategory newCat = db.SubCategories.Where(cat => cat.Id == id).FirstOrDefault();
                    newCat.Name = category.Name;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Sub Category already exists!";
                    return View(category);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
