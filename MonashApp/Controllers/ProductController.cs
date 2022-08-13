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
    public class ProductController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();

        // GET: Product
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                //Check if product already exists
                if (!db.Products.Any(b => b.Name.ToLower() == product.Name.ToLower()))
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    //Add ImageLink to product
                    Product newProduct = new Product();

                    foreach (Product item in db.Products)
                    {
                        if (item.Name.ToLower().Equals(product.Name.ToLower()))
                        {
                            newProduct = item;
                            break;
                        }
                    }
                    newProduct.ImageLink = "~/Images/ProductImages/" + newProduct.Id + ".jpg";
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
            Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (!db.Products.Any(p => p.Name == product.Name))
                {
                    Product newProduct = db.Products.Where(p => p.Id == id).FirstOrDefault();
                    newProduct.Name = product.Name;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Product Name already exists!";
                    return View(product);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            ViewBag.Name = product.Name;
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                //Query database for rows to be deleted
                Product deleteProduct = db.Products.Where(p => p.Id == id).FirstOrDefault();

                //Do not delete products if it's committed to a sales order, or if it's being purchased from supplier
                if (deleteProduct.CommittedToOrder > 0 || deleteProduct.Backorder > 0)
                {
                    ViewBag.Error2 = "Error sales order or backorder is greater than 0.";
                    return View(deleteProduct);
                }

                db.Products.Remove(deleteProduct);
                db.SaveChanges();

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
