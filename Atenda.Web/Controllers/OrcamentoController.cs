using Atenda.Data;
using Atenda.Repository;
using Atenda.Web.ViewModel;
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
            try
            {
                var orcamento = OrcamentoRepository.GetOne(pId);
                orcamento.ValorTotal = orcamento.ValorServico + orcamento.ValorProduto;
                return View(orcamento);  
            }
            catch
            {
                throw;
            }
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
        public ActionResult CreateOrcamento(Orcamento pOrcamento, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.IdProduto = new SelectList (ProdutoRepository.GetAll(), "IdProduto", "Nome", pOrcamento.IdProduto);
                    ViewBag.IdCliente = new SelectList (ClienteRepository.GetAll(), "IdCliente", "Nome", pOrcamento.IdProduto);
                    OrcamentoRepository create = new OrcamentoRepository();
                    create.Create(pOrcamento);
                    return RedirectToAction("ListOrcamentos").ComMensagemDeErro("Orçamento cadastrado com sucesso!");
                }
                else
                {
                    return View("CreateOrcamento");
                }
            }
            catch
            {
                throw;
            }
        }

        public ActionResult AddProdutos()
        {
            return View();
        }

        // GET: Orcamento/Edit/5
        public ActionResult EditOrcamento(int pId)
        {
            try
            {
                    var orcamento = OrcamentoRepository.GetOne(pId);
                    ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome", orcamento.IdProduto);
                    orcamento.ValorTotal = orcamento.ValorServico + orcamento.ValorProduto;
                    return View(orcamento);
            }
            catch
            {
                throw;
            }
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
                    return RedirectToAction("ListOrcamentos").ComMensagemDeErro("Orçamento editado com sucesso!");
                }
                else
                {
                    return View("EditOrcamento");
                }
            }
            catch
            {
                throw;
            }
        }

        // GET: Orcamento/Delete/5
        public ActionResult DeleteOrcamento(int pId)
        {
            try
            {
                var orcamento = OrcamentoRepository.GetOne(pId);
                return View(orcamento);
            }
            catch
            {
                throw;
            }
        }

        // POST: Orcamento/Delete/5
        [HttpPost]
        public ActionResult DeleteOrcamento(int pId, Orcamento pOrcamento)
        {
            try
            {
                OrcamentoRepository exclui = new OrcamentoRepository();
                exclui.Delete(pId);
                return RedirectToAction("ListOrcamentos").ComMensagemDeErro("Orçamento excluído com sucesso!");
            }
            catch
            {
                throw;
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

                if (nome.Trim() != "")
                {
                    var orcamentos = OrcamentoRepository.GetAll();
                    return View(orcamentos).ComMensagemDeErro("Digite um nome!");
                }

                var clienteOrcamentos = OrcamentoRepository.GetClienteName(nome);

                if (clienteOrcamentos.Count == 0)
                {
                    var orcamentos = OrcamentoRepository.GetAll();
                    return View(orcamentos).ComMensagemDeErro("Técnico não encontrado!");
                }

                return View(clienteOrcamentos);
        }
    }
}
