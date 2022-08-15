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

        //POST: Grab order Id then redirect to order details page
        [HttpPost]
        public ActionResult Index(int orderId)
        {

            return View("Details", orderId);
        }

        // GET: Order/Details/5
        //Display items for that order.

        public ActionResult Details(int orderId)
        {
            return View(db.OrderDetails.Where(m => m.OrderId == orderId).ToList());
        }

        // GET: Order/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            //pass user ID into view if user is logged in.
            ViewBag.UserId = User.Identity.GetUserId();
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            ViewBag.Date = date;
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order newOrder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Order order = newOrder;

                    //Create an OrderDetail for each product
                    foreach (Product item in Startup.ShoppingCart)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.ListPrice = item.BasePrice;
                        orderDetail.Qty = 1;
                        orderDetail.OrderId = order.Id;
                        orderDetail.ProductId = item.Id;
                        
                        //add orderDetail to order
                        order.OrderDetails.Add(orderDetail);
                        db.OrderDetails.Add(orderDetail);
                    }


                    db.Orders.Add(order);
                    db.SaveChanges();

                    Startup.ShoppingCart.Clear();
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Index", "Home");
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
