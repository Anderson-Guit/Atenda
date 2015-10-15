using Atenda.Data;
using Atenda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atenda.Web.Controllers
{
    public class OrcamentoController : Controller
    {
        // GET: Orcamento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Orcamento/Details/5
        public ActionResult DetailsOrcamento(int pId)
        {
            return View();
        }

        // GET: Orcamento/Create
        public ActionResult CreateOrcamento()
        {
            return View();
        }

        // POST: Orcamento/Create
        [HttpPost]
        public ActionResult CreateOrcamento(Orcamento pOrcamento)
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

        // GET: Orcamento/Edit/5
        public ActionResult EditOrcamento(int pId)
        {
            return View();
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        public ActionResult EditOrcamento(int pId, Orcamento pOrcamento)
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

        // GET: Orcamento/Delete/5
        public ActionResult DeleteOrcamento(int pId)
        {
            return View();
        }

        // POST: Orcamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int pId, Orcamento pOrcamento)
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

        public ActionResult ListOrcamentos()
        {
            var orcamentos = OrcamentoRepository.GetAll();
            return View(orcamentos);
        }
        //
        // POST: /Orcamento/SearchCliente/5
        public ActionResult SearchClienteNome(String pClienteNome)
        {
            var orcamento = OrcamentoRepository.GetClienteName(pClienteNome);
            return View(orcamento);
        }

    }
}
