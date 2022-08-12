﻿using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    public class SubCategoryController : Controller
    {
        DigiStoreModels db = new DigiStoreModels();

        // GET: SubCategory
        public ActionResult Index()
        {
            return View(db.SubCategories.ToList());
        }

        // GET: SubCategory/Details/5
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
            return View();
        }

        // POST: SubCategory/Edit/5
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

        // GET: SubCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubCategory/Delete/5
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
