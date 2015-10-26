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
            var orcamento = OrcamentoRepository.GetOne(pId);
            return View(orcamento);
        }

        // GET: Orcamento/Create
        public ActionResult CreateOrcamento()
        {
            ViewBag.IdProduto = new SelectList (ProdutoRepository.GetAll(), "IdProduto", "Nome");
            ViewBag.IdCliente = new SelectList (ClienteRepository.GetAll(), "IdCliente", "Nome");
            return View();
        }

        // POST: Orcamento/Create
        [HttpPost]
        public ActionResult CreateOrcamento(Orcamento pOrcamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.IdProduto = new SelectList (ProdutoRepository.GetAll(), "IdProduto", "Nome", pOrcamento.IdProduto);
                    ViewBag.IdCliente = new SelectList (ClienteRepository.GetAll(), "IdCliente", "Nome", pOrcamento.IdProduto);
                    OrcamentoRepository nova = new OrcamentoRepository();
                    nova.Create(pOrcamento);
                    return RedirectToAction("ListOrcamentos");
                }
                return View("CreateOrcamento");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Edit/5
        public ActionResult EditOrcamento(int pId)
        {
            ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome");
            var orcamento = OrcamentoRepository.GetOne(pId);
            return View(orcamento);
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        public ActionResult EditOrcamento(int pId, Orcamento pOrcamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome", pOrcamento.IdProduto);
                    OrcamentoRepository edit = new OrcamentoRepository();
                    edit.Update(pOrcamento);
                    return RedirectToAction("ListOrcamentos");
                }

                return View("EditOrcamento");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orcamento/Delete/5
        public ActionResult DeleteOrcamento(int pId)
        {
            var orcamento = OrcamentoRepository.GetOne(pId);
            return View(orcamento);
        }

        // POST: Orcamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int pId, Orcamento pOrcamento)
        {
            try
            {
                OrcamentoRepository exclui = new OrcamentoRepository();
                exclui.Delete(pId);
                return RedirectToAction("ListOrcamentos");
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
        // GET: /Orcamento/SearchClienteNome/5
        public ActionResult SearchClienteNome()
        {
            return View();
        }
        //
        // POST: /Orcamento/SearchCliente/5
        [HttpPost]
        public ActionResult SearchClienteNome(String pClienteNome)
        {
            var cliente = OrcamentoRepository.GetByClienteName(pClienteNome);
            return View(cliente);
        }

    }
}
