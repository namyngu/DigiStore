using MonashApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    public class CustomerReviewController : Controller
    {
        DigiStoreDB db = new DigiStoreDB();

        // GET: CustomerReview
        public ActionResult Index()
        {
            return View(db.CustomerReviews.ToList());
        }

        // GET: CustomerReview/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerReview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerReview/Create
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

        // GET: CustomerReview/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerReview/Edit/5
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

        // GET: CustomerReview/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerReview/Delete/5
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
