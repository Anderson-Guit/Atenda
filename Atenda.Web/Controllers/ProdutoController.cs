using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Data;
using Atenda.Repository;
using Atenda.Web.Controllers;

namespace Atenda.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Produto/Details/5
        public ActionResult DetailsProduto(int pId)
        {
            try
            {
                var produto = ProdutoRepository.GetOne(pId);
                return View(produto);
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Produto/Create
        public ActionResult CreateProduto()
        {
            return View();
        }

        //
        // POST: /Produto/Create
        [HttpPost]
        public ActionResult CreateProduto(Produto pProduto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProdutoRepository nova = new ProdutoRepository();
                    nova.Create(pProduto);
                    return RedirectToAction("ListProdutos").ComMensagemDeSucesso("Produto cadastrado com sucesso!");
                }
                else
                {
                    return View("CreateProduto");
                }                
            }
            catch
            {
                return RedirectToAction("ListProdutos").ComMensagemDeErro("Preencha todos os campos!");
                throw;
            }
        }

        //
        // GET: /Produto/Edit/5
        public ActionResult EditProduto(int pId)
        {
            try
            {
                var produtos = ProdutoRepository.GetOne(pId);
                return View(produtos);
            }
            catch
            {
                throw;
            }
        }

        //
        // POST: /Produto/Edit/5
        [HttpPost]
        public ActionResult EditProduto(Produto pProduto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProdutoRepository edit = new ProdutoRepository();
                    edit.Update(pProduto);
                    return RedirectToAction("ListProdutos").ComMensagemDeSucesso("Produto editado com sucesso!");
                }
                else
                {
                    return View("EditProduto");
                }
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Produto/Delete/5
        public ActionResult DeleteProduto(int pId)
        {
            try
            {
                var produtos = ProdutoRepository.GetOne(pId);
                return View(produtos);
            }
            catch
            {
                throw;
            }
        }

        //
        // POST: /Produto/Delete/5
        [HttpPost]
        public ActionResult DeleteProduto(Produto pProduto, int pId)
        {
            try
            {
                ProdutoRepository exclui = new ProdutoRepository();
                exclui.Delete(pId);
                return RedirectToAction("ListProdutos").ComMensagemDeSucesso("Produto excluído com sucesso!");
            }
            catch
            {
                return RedirectToAction("ListProdutos").ComMensagemDeErro("Produto não pode ser excluido! Existe pendencias");
            }
        }
        //
        // GET: /Produto/List/5
        public ActionResult ListProdutos()
        {
            var produtos = ProdutoRepository.GetAll();
            return View(produtos);
        }
        //
        // POST: /Produto/Delete/5
        [HttpPost]
        public ActionResult ListProdutos(FormCollection form)
        {
            try
            {
                string nome = form["ProdutoNome"];

                if (nome == "")
                {
                    var produtos = ProdutoRepository.GetAll();
                    return View(produtos).ComMensagemDeErro("Digite nome de um produto!");
                }

                var produtoNome = ProdutoRepository.GetName(nome);

                if (produtoNome.Count == 0)
                {
                    var produtos = ProdutoRepository.GetAll();
                    return View(produtos).ComMensagemDeErro("Produto não encontrado!");
                }
                return View(produtoNome);
            }
            catch
            {
                throw;
            }
        }
    }
}
