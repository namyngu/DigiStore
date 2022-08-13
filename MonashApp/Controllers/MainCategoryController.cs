using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    [Authorize]
    [RequireHttps]
    public class MainCategoryController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();

        // GET: MainCategory
        public ActionResult Index()
        {
            return View(db.MainCategories.ToList());
        }

        // GET: MainCategory/Details/5
        public ActionResult Details(int id)
        {
            return View(db.MainCategories.Where(m => m.Id == id).FirstOrDefault());
        }

        // GET: MainCategory/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: MainCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainCategory mainCategory)
        {
            try
            {
                //Check if category already exists
                if (!db.MainCategories.Any(m => m.Name.ToLower() == mainCategory.Name.ToLower()))
                {
                    db.MainCategories.Add(mainCategory);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Brand already exists!";
                    return View(mainCategory);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MainCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var mainCategory = db.MainCategories.Where(m => m.Id == id).FirstOrDefault();
            return View(mainCategory);
        }

        // POST: MainCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MainCategory category)
        {
            try
            {
                if (!db.MainCategories.Any(cat => cat.Name == category.Name))
                {
                    MainCategory newCat = db.MainCategories.Where(cat => cat.Id == id).FirstOrDefault();
                    newCat.Name = category.Name;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Main Category already exists!";
                    return View(category);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MainCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainCategory/Delete/5
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
