using Microsoft.AspNet.Identity;
using MonashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonashApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        DigiStoreDBContext db = new DigiStoreDBContext();


        // GET: Order
        public ActionResult Index(string id)
        {
            //Return only the user's order
            return View(db.Orders.Where(m => m.AspNetUserId == id).ToList());
        }

        // GET: Order/Details/5
        //Display items for that order.
        public ActionResult Details(int orderId)
        {
            return View(db.OrderDetails.Where(m => m.OrderId == orderId).ToList());
        }

        // GET: Order/Create
        //Shows shopping cart list - same concept
        public ActionResult Create()
        {
            //pass user ID into view if user is logged in.
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
