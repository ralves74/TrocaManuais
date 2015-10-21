using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrocaManuais.Web.Controllers
{
    public class ManuaisPorEscalaoController : Controller
    {
        private TrocaManuais.Web.Models.TrocamanuaisEntities db = new TrocaManuais.Web.Models.TrocamanuaisEntities();
        // GET: ManuaisPorEscalao
        public ActionResult Index()
        {
            return View(db.manuais.ToList());
        }
    }
}