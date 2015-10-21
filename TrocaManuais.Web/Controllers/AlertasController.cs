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
    public class AlertasController : Controller
    {
        private TrocamanuaisEntities db = new TrocamanuaisEntities();

        // GET: Alertas
        public ActionResult Index()
        {
            var alertas = db.Alertas.Include(a => a.manuais).Include(a => a.users);
            return View(alertas.ToList());
        }

        // GET: Alertas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alertas alertas = db.Alertas.Find(id);
            if (alertas == null)
            {
                return HttpNotFound();
            }
            return View(alertas);
        }

        // GET: Alertas/Create
        public ActionResult Create()
        {
            ViewBag.idmanual = new SelectList(db.manuais, "idmanual", "Editora");
            ViewBag.Nick = new SelectList(db.users, "Nick", "email");
            return View();
        }

        // POST: Alertas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nick,idmanual,DataStamp,Activa,IdAlerta")] Alertas alertas)
        {
            if (ModelState.IsValid)
            {
                db.Alertas.Add(alertas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idmanual = new SelectList(db.manuais, "idmanual", "Editora", alertas.idmanual);
            ViewBag.Nick = new SelectList(db.users, "Nick", "email", alertas.Nick);
            return View(alertas);
        }

        // GET: Alertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alertas alertas = db.Alertas.Find(id);
            if (alertas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idmanual = new SelectList(db.manuais, "idmanual", "Editora", alertas.idmanual);
            ViewBag.Nick = new SelectList(db.users, "Nick", "email", alertas.Nick);
            return View(alertas);
        }

        // POST: Alertas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nick,idmanual,DataStamp,Activa,IdAlerta")] Alertas alertas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alertas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idmanual = new SelectList(db.manuais, "idmanual", "Editora", alertas.idmanual);
            ViewBag.Nick = new SelectList(db.users, "Nick", "email", alertas.Nick);
            return View(alertas);
        }

        // GET: Alertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alertas alertas = db.Alertas.Find(id);
            if (alertas == null)
            {
                return HttpNotFound();
            }
            return View(alertas);
        }

        // POST: Alertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alertas alertas = db.Alertas.Find(id);
            db.Alertas.Remove(alertas);
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
