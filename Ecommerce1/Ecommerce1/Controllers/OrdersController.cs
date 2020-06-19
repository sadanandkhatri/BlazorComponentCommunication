using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce1.Models;

namespace LinqGrouping.Models
{
    public class Group<K, T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
}

namespace Ecommerce1.Controllers
{

    public class TagViewModel<K, T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
    public class OrdersController : Controller
    {
        private new_ecommerceEntities db = new new_ecommerceEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Product).Include(o => o.User).Where(o => o.User.UserId == 2).
                GroupBy(o => o.Product.Business.BusinessName, (key, value) => new LinqGrouping.Models.Group<string, Order> { Key = key, Values = value });
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ProductId,UserId,Price,Quantity,ProcessType")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", order.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", order.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ProductId,UserId,Price,Quantity,ProcessType")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", order.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(string datax)
        {

            int data;
            data = Int32.Parse(datax);
            var ordersIt = (db.Orders.Where(t => t.PacketId == data));
            int flag = 0;
            var timex = DateTime.Now;
            foreach (var item in ordersIt)
            {
                Order order = db.Orders.Find(item.OrderId);
                order.ProcessType = "Paid";
                //order.PacketId = db.Orders.Select(t => t.PacketId).DefaultIfEmpty(0).Max();
                //order.PacketId = order.PacketId + 1;
                //Del from cart add where to upper function?
                if (flag == 0)
                {
                    Token token = new Token()
                    {
                        PacketId = db.Tokens.Select(t => t.PacketId).DefaultIfEmpty(0).Max() + 1,
                        BusinessId = order.Product.BusinessId,
                        TokenDT = (db.Tokens.Where(o => o.BusinessId.Equals(order.Product.BusinessId)).Select(t => t.TokenDT).DefaultIfEmpty(DateTime.Now).Max()).AddMinutes(5)
                    };
                    db.Tokens.Add(token);
                    timex = token.TokenDT;
                    flag = 1;
                }

                db.Orders.Remove(order);

            }

            db.SaveChanges();
            return View(timex);
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
