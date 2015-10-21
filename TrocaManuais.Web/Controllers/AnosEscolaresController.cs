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
    public class AnosEscolaresController : Controller
    {
        private TrocamanuaisEntities db = new TrocamanuaisEntities();

        // GET: AnosEscolares
        public ActionResult Index()
        {
            var anosEscolares = db.AnosEscolares.Include(a => a.Escaloes);
            return View(anosEscolares.ToList());
        }

        // GET: AnosEscolares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnosEscolares anosEscolares = db.AnosEscolares.Find(id);
            if (anosEscolares == null)
            {
                return HttpNotFound();
            }
            return View(anosEscolares);
        }

        // GET: AnosEscolares/Create
        public ActionResult Create()
        {
            ViewBag.Escalao = new SelectList(db.Escaloes, "Escalao", "Escalao");
            return View();
        }

        // POST: AnosEscolares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Escalao,idAEscola,Ano")] AnosEscolares anosEscolares)
        {
            if (ModelState.IsValid)
            {
                db.AnosEscolares.Add(anosEscolares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Escalao = new SelectList(db.Escaloes, "Escalao", "Escalao", anosEscolares.Escalao);
            return View(anosEscolares);
        }

        // GET: AnosEscolares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnosEscolares anosEscolares = db.AnosEscolares.Find(id);
            if (anosEscolares == null)
            {
                return HttpNotFound();
            }
            ViewBag.Escalao = new SelectList(db.Escaloes, "Escalao", "Escalao", anosEscolares.Escalao);
            return View(anosEscolares);
        }

        // POST: AnosEscolares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Escalao,idAEscola,Ano")] AnosEscolares anosEscolares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anosEscolares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Escalao = new SelectList(db.Escaloes, "Escalao", "Escalao", anosEscolares.Escalao);
            return View(anosEscolares);
        }

        // GET: AnosEscolares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnosEscolares anosEscolares = db.AnosEscolares.Find(id);
            if (anosEscolares == null)
            {
                return HttpNotFound();
            }
            return View(anosEscolares);
        }

        // POST: AnosEscolares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnosEscolares anosEscolares = db.AnosEscolares.Find(id);
            db.AnosEscolares.Remove(anosEscolares);
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
