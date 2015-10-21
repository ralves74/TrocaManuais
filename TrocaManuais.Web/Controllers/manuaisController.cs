using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrocaManuais.Web.Models;

namespace TrocaManuais.Web.Controllers
{
    public class manuaisController : Controller
    {
        private TrocamanuaisEntities db = new TrocamanuaisEntities();

        // GET: manuais
        public ActionResult Index()
        {
            var manuais = db.manuais.Include(m => m.AnosEscolares).Include(m => m.Disciplinas).Include(m => m.Editoras);
            return View(manuais.ToList());
        }

        // GET: manuais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manuais manuais = db.manuais.Find(id);
            if (manuais == null)
            {
                return HttpNotFound();
            }
            return View(manuais);
        }

        

        // GET: manuais/Create
        public ActionResult Create()
        {
            ViewBag.idAEscola = new SelectList(db.AnosEscolares, "idAEscola", "Ano");
            ViewBag.disciplina = new SelectList(db.Disciplinas, "disciplina", "disciplina");
            ViewBag.Editora = new SelectList(db.Editoras, "Editora", "Editora");
            return View();
        }

        // POST: manuais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmanual,Editora,disciplina,ISBN,titulo,Autores,foto,idAEscola,inactivo")] manuais manuais, HttpPostedFileBase file)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };


           
            if (ModelState.IsValid)
            {
                 if (file != null && file.ContentLength > 0)
                    {
                        var uploadDir = "~/images/";
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), file.FileName);
                        var imageUrl = Path.Combine(uploadDir, file.FileName);
                        file.SaveAs(imagePath);
                        manuais.foto = "~/images/" + file.FileName;
                    }
                else
                 {
                     manuais.foto = "~/images/ImageNull.png";
                 }

                DAL.Manuais.DLManuais IDAM = new DAL.Manuais.DLManuais(db);
                int IdAddManual = IDAM.GetMaxIdManual();
                manuais.idmanual = IdAddManual;
                manuais.Inactivo = false;
                
                db.manuais.Add(manuais);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = manuais.idmanual });
            }

            ViewBag.idAEscola = new SelectList(db.AnosEscolares, "idAEscola", "Escalao", manuais.idAEscola);
            ViewBag.disciplina = new SelectList(db.Disciplinas, "disciplina", "disciplina", manuais.disciplina);
            ViewBag.Editora = new SelectList(db.Editoras, "Editora", "Editora", manuais.Editora);
            return View(manuais);
        }

       

        // GET: manuais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manuais manuais = db.manuais.Find(id);
            if (manuais == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAEscola = new SelectList(db.AnosEscolares, "idAEscola", "Escalao", manuais.idAEscola);
            ViewBag.disciplina = new SelectList(db.Disciplinas, "disciplina", "disciplina", manuais.disciplina);
            ViewBag.Editora = new SelectList(db.Editoras, "Editora", "Editora", manuais.Editora);
            return View(manuais);
        }

        // POST: manuais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmanual,Editora,disciplina,ISBN,titulo,Autores,foto,idAEscola,Inactivo")] manuais manuais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manuais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAEscola = new SelectList(db.AnosEscolares, "idAEscola", "Escalao", manuais.idAEscola);
            ViewBag.disciplina = new SelectList(db.Disciplinas, "disciplina", "disciplina", manuais.disciplina);
            ViewBag.Editora = new SelectList(db.Editoras, "Editora", "Editora", manuais.Editora);
            return View(manuais);
        }

        // GET: manuais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manuais manuais = db.manuais.Find(id);
            if (manuais == null)
            {
                return HttpNotFound();
            }
            return View(manuais);
        }

        // POST: manuais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manuais manuais = db.manuais.Find(id);
            db.manuais.Remove(manuais);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Catalogo()
        {
            var manuais = db.manuais.Include(m => m.AnosEscolares).Include(m => m.Disciplinas).Include(m => m.Editoras);
            return View(manuais.ToList());
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
