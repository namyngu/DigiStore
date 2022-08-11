using MonashApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    public class MainCategoryController : Controller
    {
        MainCategoryContext db = new MainCategoryContext();

        // GET: MainCategory
        public ActionResult Index()
        {
            return View(db.MainCategories.ToList());
        }

        // GET: MainCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainCategory/Create
        [HttpPost]
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

        // GET: MainCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
