using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrocaManuais.Web.Models;

namespace TrocaManuais.Web.Controllers
{
    public class stocksController : Controller
    {
        private TrocamanuaisEntities db = new TrocamanuaisEntities();

        // GET: stocks
        public ActionResult Index()
        {
            var stock = db.stock.Include(s => s.manuais).Include(s => s.users);
            return View(stock.ToList());
        }

        // GET: stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: stocks/Create
        public ActionResult Create()
        {
            ViewBag.idManual = new SelectList(db.manuais, "titulo", "titulo");
            ViewBag.Nick = new SelectList(db.users, "Nick", "Nick");
            ViewBag.QTT = 1;
            return View();
        }

        // POST: stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStock,idManual,Qtt,Nick,DataStamp")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idManual = new SelectList(db.manuais, "titulo", "titulo", stock.idManual);
            ViewBag.Nick = new SelectList(db.users, "Nick", "email", stock.Nick);
            return View(stock);
        }

        // GET: stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.idManual = new SelectList(db.manuais, "idmanual", "Editora", stock.idManual);
            ViewBag.Nick = new SelectList(db.users, "Nick", "email", stock.Nick);
            return View(stock);
        }

        // POST: stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStock,idManual,Qtt,Nick,DataStamp")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idManual = new SelectList(db.manuais, "idmanual", "Editora", stock.idManual);
            ViewBag.Nick = new SelectList(db.users, "Nick", "email", stock.Nick);
            return View(stock);
        }

        // GET: stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock stock = db.stock.Find(id);
            db.stock.Remove(stock);
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
