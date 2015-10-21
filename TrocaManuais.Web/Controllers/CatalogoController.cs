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
using PagedList;
using PagedList.Mvc;
using GridMvc.Html;

namespace TrocaManuais.Web.Controllers
{
    public class CatalogoController : Controller
    {

        private TrocamanuaisEntities db = new TrocamanuaisEntities();
        // GET: Catalogo
        public ActionResult Catalogo(int? page)
        {
            var manuais = db.manuais.Include(m => m.AnosEscolares).Include(m => m.Disciplinas).Include(m => m.Editoras).OrderBy(m=>m.ISBN);
            var pageNumber = page ?? 1;
            var onePageOfProducts = manuais.ToPagedList(pageNumber, 8);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(onePageOfProducts);
        }

        public ActionResult CatalogoPorAno(int? page,string EscalaoEscola)
        {
            DAL.Manuais.DLManuais IDAM = new DAL.Manuais.DLManuais(db);
            var manuais = IDAM.manuaisporescalao(EscalaoEscola);
            var pageNumber = page ?? 1;
            var onePageOfProducts = manuais.ToPagedList(pageNumber, 8);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(onePageOfProducts);
        }

        
        public ViewResult CatalogoAnoDisciplina(int? page, string AnoEscola, string disc)
        {
            DAL.Manuais.DLManuais IDAM = new DAL.Manuais.DLManuais(db);
            ViewBag.disc = new SelectList(db.Disciplinas, "disciplina", "disciplina");
            ViewBag.AnoEscola = new SelectList(db.AnosEscolares, "Ano", "ano");
          
            var manuais = IDAM.manuaisporDisciplinaAno(AnoEscola,disc).ToList();
            var pageNumber = page ?? 1;
            var onePageOfProductst = manuais.ToPagedList(pageNumber, 8);
            ViewBag.OnePageOfProducts = onePageOfProductst;
            return View(onePageOfProductst);
        }

        public ActionResult Detalhes(int? id)
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


        public ActionResult CatalogoEstabelecimentos(int? page, string estab, string Anol)
        {
            DAL.Pesquisa.pesquisas Pesq = new DAL.Pesquisa.pesquisas(db);
            ViewBag.Agrup = new SelectList(db.Agrupamentos, "agrupamento", "agrupamento");
            ViewBag.Estab = new SelectList(db.estabelecimentos, "design", "design");
            ViewBag.Anol = new SelectList(db.ALetivo,"Aletivo1","Aletivo1");
            var PesqMan = Pesq.manuaisporEstabelecimento(estab,Anol).ToList();
            var pageNumber = page ?? 1;
            var onePageOfProducts = PesqMan.ToPagedList(pageNumber, 8);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(onePageOfProducts);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadEstabs(string idAgrup)
        {
            DAL.Pesquisa.pesquisas Pesq = new DAL.Pesquisa.pesquisas(db);
            var modelList = Pesq.GetAllEstabByAgrupID(Convert.ToInt32(idAgrup));
            var modelData = modelList.Select(m => new SelectListItem()
            {
                Text = m.design,
                Value = m.idestab.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CatalogoManuaisStock(int? page, string isbn)
        {
            DAL.Manuais.DLManuais PesqIsbn = new DAL.Manuais.DLManuais(db);
            var IsbnFind = PesqIsbn.GetManualEmStock(isbn).ToList();
            var pageNumber = page ?? 1;
            var onePageOfProducts = IsbnFind.ToPagedList(pageNumber, 8);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(onePageOfProducts);
        }


    }
}