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
    public class estabelecimentosController : Controller
    {
        private TrocamanuaisEntities db = new TrocamanuaisEntities();

        // GET: estabelecimentos
        public ActionResult Index()
        {
            var estabelecimentos = db.estabelecimentos.Include(e => e.Agrupamentos).Include(e => e.CPostal);
            return View(estabelecimentos.ToList());
        }

        // GET: estabelecimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estabelecimentos estabelecimentos = db.estabelecimentos.Find(id);
            if (estabelecimentos == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimentos);
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
