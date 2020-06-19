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
    public class TokensController : Controller
    {
        private new_ecommerceEntities db = new new_ecommerceEntities();

        // GET: Tokens
        public ActionResult Index()
        {
            var tokens = db.Tokens.Include(p => p.Business);
            return View(tokens.ToList());
        }

        // GET: Tokens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                return HttpNotFound();
            }
            return View(token);
        }

        // GET: Tokens/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName");
            return View();
        }

        // POST: Tokens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacketId,BusinessId,TokenDT")] Token token)
        {
            if (ModelState.IsValid)
            {
                db.Tokens.Add(token);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", token.BusinessId);
            return View(token);
        }

        // GET: Tokens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", token.BusinessId);
            return View(token);
        }

        // POST: Tokens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacketId,BusinessId,TokenDT")] Token token)
        {
            if (ModelState.IsValid)
            {
                db.Entry(token).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", token.BusinessId);
            return View(token);
        }

        // GET: Tokens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                return HttpNotFound();
            }
            return View(token);
        }

        // POST: Tokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Token token = db.Tokens.Find(id);
            db.Tokens.Remove(token);
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
