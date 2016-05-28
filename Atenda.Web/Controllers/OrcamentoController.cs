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
                OrcamentoRepository orc = new OrcamentoRepository();
                List<Produto> produtos = orc.GetProdutos(pId);

                var model = new OrcamentoViewModel
                {
                    Produtos = produtos,
                    Orcamento = orcamento

                };

                return View(model);  
            }
            catch
            {
                throw;
            }
        }

        // GET: Orcamento/Create
        public ActionResult CreateOrcamento(OrcamentoViewModel pOrcamento)
        {
            if (pOrcamento == null)
            {
                var orcamento = OrcamentoRepository.GetOne(pOrcamento.Orcamento.IdOrcamento);
                OrcamentoRepository orc = new OrcamentoRepository();
                List<Produto> produtos = orc.GetProdutos(pOrcamento.Orcamento.IdOrcamento);

                var model = new OrcamentoViewModel
                {
                    Produtos = produtos,
                    Orcamento = orcamento

                };

                ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome");
                return View(model);
            }
            else
            {
                ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome");
                var model = "";
                return View(model);
            }         
            
            
        }

        // POST: Orcamento/Create
        [HttpPost]
        public ActionResult CreateOrcamento(OrcamentoViewModel pOrcamento, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //int? IdProd = pOrcamento.IdProduto;
                    //var getProd = ProdutoRepository.GetOne(IdProd);

                    //if (pOrcamento.Valor != null && getProd == null)
                    //    pOrcamento.ValorTotal = pOrcamento.Valor + getProd.Valor;
                    //else if (pOrcamento.Valor == null)
                    //    pOrcamento.ValorTotal = getProd.Valor;
                    //else
                        pOrcamento.Orcamento.ValorTotal = pOrcamento.Orcamento.Valor;

                    OrcamentoRepository create = new OrcamentoRepository();
                    create.Create(pOrcamento.Orcamento);
                    return RedirectToAction("ListOrcamentos").ComMensagemDeSucesso("Orçamento cadastrado com sucesso!");
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
        
        public ActionResult AddProdutos(OrcamentoViewModel pOrcamento)
        {
            ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome");
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome", pOrcamento.Orcamento.IdCliente);
            return View(pOrcamento);
        }

        [HttpPost]
        public ActionResult AddProdutos(FormCollection orcamentoForm, OrcamentoViewModel pOrcamento)
        {
            OrcamentoRepository orcamento = new OrcamentoRepository();
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome", pOrcamento.Orcamento.IdCliente);
            orcamento.AddProdutos(pOrcamento.Orcamento);
            var orc = orcamento.GetLast();
            pOrcamento.Produtos = orcamento.GetProdutos(orc.IdOrcamento);
            return View("CreateOrcamento" + pOrcamento.Orcamento);
        }

        // GET: Orcamento/Edit/5
        public ActionResult EditOrcamento(int pId)
        {
            try
            {
                    var orcamento = OrcamentoRepository.GetOne(pId);
                    ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome", orcamento.IdProduto);
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
                    //int? IdProd = pOrcamento.IdProduto;
                    //var getProd = ProdutoRepository.GetOne(IdProd);
                    //pOrcamento.ValorTotal = pOrcamento.Valor + getProd.Valor;

                    OrcamentoRepository edit = new OrcamentoRepository();
                    edit.Update(pOrcamento);
                    return RedirectToAction("ListOrcamentos").ComMensagemDeSucesso("Orçamento editado com sucesso!");
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
                return RedirectToAction("ListOrcamentos").ComMensagemDeSucesso("Orçamento excluído com sucesso!");
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
