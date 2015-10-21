using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrocaManuais.Web.Controllers
{
    public class EnvioMensagemController : Controller
    {
        private ViewModels.MensagemViewModel db = new ViewModels.MensagemViewModel();
        // GET: EnvioMensagem
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnvioMensagem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnvioMensagem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnvioMensagem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EnvioMensagem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnvioMensagem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EnvioMensagem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnvioMensagem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
