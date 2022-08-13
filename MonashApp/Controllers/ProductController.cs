using MonashApp.Models;
using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    public class ProductController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Products.Where(p => p.Id == id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Product viewModel = new Product();
            viewModel.Brands = db.Brands.ToList();
            viewModel.SubCategories = db.SubCategories.ToList();

            return View(viewModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                //Check if product already exists
                if (!db.Products.Any(b => b.Name.ToLower() == product.Name.ToLower()))
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Product already exists!";
                    return View(product);
                };
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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

        //Method to get all brands from database
        private List<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();
            foreach (Brand item in db.Brands)
            {
                brands.Add(item);
            }
            return brands;
        }

        //Method to get all SubCategories from database
        private List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            foreach (SubCategory item in db.SubCategories)
            {
                subCategories.Add(item);
            }
            return subCategories;
        }
    }
}
