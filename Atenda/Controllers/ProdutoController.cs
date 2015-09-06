using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Data;
using Atenda.Repository;

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
            var produto = ProdutoRepository.GetOne(pId);
            return View(produto);
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
                    return RedirectToAction("ListProdutos");
                }

                return View("CreateProduto");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produto/Edit/5
        public ActionResult EditProduto(int pId)
        {
            var produtos = ProdutoRepository.GetOne(pId);
            return View(produtos);
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
                    return RedirectToAction("ListProdutos");
                }

                return View("EditProduto");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produto/Delete/5
        public ActionResult DeleteProduto(int pId)
        {
            var produtos = ProdutoRepository.GetOne(pId);
            return View(produtos);
        }

        //
        // POST: /Produto/Delete/5
        [HttpPost]
        public ActionResult DeleteProduto(Produto pProduto)
        {
            try
            {
                ProdutoRepository exclui = new ProdutoRepository();
                exclui.Delete(pProduto);
                return RedirectToAction("ListProdutos");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListProdutos()
        {
            var produto = ProdutoRepository.GetAll();

            return View(produto);

        }

        public ActionResult SearchProduto(String pNome)
        {
            var produto = ProdutoRepository.GetName(pNome);
            return View(produto);

        }

    }
}
