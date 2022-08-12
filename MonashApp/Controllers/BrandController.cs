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
        DigiStoreDBContext db = new DigiStoreDBContext();

        // GET: Brand
        public ActionResult Index()
        {
            return View(db.Brands.ToList()) ;
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            var brand = db.Brands.Where(b => b.Id == id);
            return View(brand);
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
                //Check if brand already exists
                if (!db.Brands.Any(b => b.Name == brand.Name))
                {
                    db.Brands.Add(brand);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Brand already exists!";
                    return View(brand);
                }
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
                if (!db.Brands.Any(b => b.Name == brand.Name))
                {
                    Brand newBrand = db.Brands.Where(b => b.Id == id).FirstOrDefault();
                    newBrand.Name = brand.Name;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Brand already exists!";
                    return View(brand);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            Brand brand = db.Brands.Where(b => b.Id == id).FirstOrDefault();
            ViewBag.Name = brand.Name;
            return View();
        }

        // POST: Brand/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Brand brand)
        {
            try
            {
                //Query database for rows to be deleted
                var deleteBrand = from b in db.Brands
                                  where b.Id == id
                                  select b;

                foreach (var br in deleteBrand)
                {
                    db.Brands.Remove(br);
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
