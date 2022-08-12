﻿using MonashApp.Context;
using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    public class BrandController : Controller
    {
        BrandContext db = new BrandContext();

        // GET: Brand
        public ActionResult Index()
        {
            return View(db.Brands.ToList()) ;
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            try
            {
                db.Brands.Add(brand);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(brand);
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            var brand = db.Brands.Where(b => b.Id == id).FirstOrDefault();

            return View(brand);
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Brand brand)
        {
            try
            {
                Brand newBrand = db.Brands.Where(b => b.Id == id).FirstOrDefault();
                newBrand.Name = brand.Name;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            Brand deleteBrand = db.Brands.Where(b => b.Id == id).FirstOrDefault();

            return View();
        }

        // POST: Brand/Delete/5
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
