using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce1.Models;

namespace Ecommerce1.Controllers
{
    public class ProductListController : Controller
    {
        private new_ecommerceEntities db = new new_ecommerceEntities();
        // GET: ProductList
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Business);
            return View(products.ToList());
        }

        // GET: ProductList/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ProductList/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName");
            return View();
        }

        // POST: ProductList/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,BusinessId,ProductPrice,ProductDescription,ProductImg")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", product.BusinessId);
            return View(product);
        }

        // GET: ProductList/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", product.BusinessId);
            return View(product);
        }

        // POST: ProductList/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,BusinessId,ProductPrice,ProductDescription,ProductImg")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", product.BusinessId);
            return View(product);
        }


        // GET: ProductList/Edit/5
        public ActionResult AddOrder()
        {

            return View("Index", db.Products);

        }


        // POST: ProductList/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(string id, string qty)
        {

            Product product = db.Products.Find(id);
            var order = new Order();

            order.OrderId = db.Orders.Select(t => t.OrderId).DefaultIfEmpty(0).Max();
            order.OrderId = order.OrderId + 1;
            order.ProductId = product.ProductId;
            order.UserId = 2;
            order.Price = int.Parse(qty) * product.ProductPrice;
            order.Quantity = int.Parse(qty);
            order.ProcessType = "InCart";
            order.PacketId = (db.Orders.Where(t => t.Product.BusinessId.Equals(product.BusinessId)).Where(t => t.ProcessType.Equals("InCart"))).Select(t => t.PacketId).DefaultIfEmpty(db.Orders.Select(t => t.PacketId).DefaultIfEmpty(0).Max() + 1).Max();
            if (ModelState.IsValid)
            {

                db.Orders.Add(order);
                db.SaveChanges();
                return View("Index", db.Products);
            }
            return View("Index", db.Products);
        }



        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
