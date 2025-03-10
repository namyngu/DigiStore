﻿using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    public class DiscountController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();

        // GET: Discount
        public ActionResult Index()
        {
            return View(db.Discounts.ToList());
        }

        // GET: Discount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discount/Create
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

        // GET: Discount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Discount/Edit/5
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

        // GET: Discount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Discount/Delete/5
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
