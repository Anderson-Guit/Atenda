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
            orcamento.ValorTotal = orcamento.ValorServico + orcamento.ValorProduto;
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
                    pOrcamento.ValorTotal = pOrcamento.ValorServico + pOrcamento.ValorProduto;
                    OrcamentoRepository create = new OrcamentoRepository();
                    create.Create(pOrcamento);
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
            var orcamento = OrcamentoRepository.GetOne(pId);
            ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome", orcamento.IdProduto);
            orcamento.ValorTotal = orcamento.ValorServico + orcamento.ValorProduto;

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
                    pOrcamento.ValorTotal = pOrcamento.ValorServico + pOrcamento.ValorProduto;
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
        //
        // GET: /Orcamento/List/5
        public ActionResult ListOrcamentos()
        {
            var orcamentos = OrcamentoRepository.GetAll();
            return View(orcamentos);
        }
        //
        // POST: /Agenda/List/5
        [HttpPost]
        public ActionResult ListOrcamentos(FormCollection form)
        {
            string nome = form["ClienteNome"];

            if (nome != null)
            {
                var orcamentos = OrcamentoRepository.GetClienteName(nome);
                return View(orcamentos);
            }
            else
            {
                var orcamentos = OrcamentoRepository.GetAll();
                return View(orcamentos);
            }
        }

    }
}
