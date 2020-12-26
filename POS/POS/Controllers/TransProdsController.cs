using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS.DAL;
using POS.Models;

namespace POS.Controllers
{
    public class TransProdsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: TransProds
        public ActionResult Index(int? id)
        {
            var transProds = db.TransProds.Include(t => t.Product).Include(t => t.Transaction).Where(t => t.TransactionId == id).ToList();
            return View(transProds);
        }

        // GET: TransProds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransProd transProd = db.TransProds.Find(id);
            if (transProd == null)
            {
                return HttpNotFound();
            }
            return View(transProd);
        }

        // GET: TransProds/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "product_name");
            ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Id");
            return View();
        }

        // POST: TransProds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,TransactionId,ProductQuantity")] TransProd transProd)
        {
            if (ModelState.IsValid)
            {
                db.TransProds.Add(transProd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "product_name", transProd.ProductId);
            ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Id", transProd.TransactionId);
            return View(transProd);
        }

        // GET: TransProds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransProd transProd = db.TransProds.Find(id);
            if (transProd == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "product_name", transProd.ProductId);
            ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Id", transProd.TransactionId);
            return View(transProd);
        }

        // POST: TransProds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,TransactionId,ProductQuantity")] TransProd transProd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transProd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "product_name", transProd.ProductId);
            ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Id", transProd.TransactionId);
            return View(transProd);
        }

        // GET: TransProds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransProd transProd = db.TransProds.Find(id);
            if (transProd == null)
            {
                return HttpNotFound();
            }
            return View(transProd);
        }

        // POST: TransProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransProd transProd = db.TransProds.Find(id);
            db.TransProds.Remove(transProd);
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
