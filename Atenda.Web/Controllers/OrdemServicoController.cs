using System;
using Atenda.Repository;
using Atenda.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atenda.Controllers
{
    public class OrdemServicoController : Controller
    {
        //
        // GET: /OrdemServico/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /OrdemServico/Details/5
        public ActionResult DetailsOS(int pId)
        {
            var os = OrdemServicoRepository.GetOne(pId);
            return View(os);
        }

        //
        // GET: /OrdemServico/Create
        public ActionResult CreateOS()
        {
            ViewBag.IdCliente = new SelectList
            (
                ClienteRepository.GetAll(),
                "IdCliente",
                "Nome"
            );
            ViewBag.IdTecnico = new SelectList
            (
                TecnicoRepository.GetAll(),
                "IdTecnico",
                "Nome"
            );
            return View();
        }

        //
        // POST: /OrdemServico/Create
        [HttpPost]
        public ActionResult CreateOS(OrdemServico pOS)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    ViewBag.IdCliente = new SelectList
                    (
                        ClienteRepository.GetAll(),
                        "IdCliente",
                        "Nome",
                        pOS.IdCliente
                    );
                    ViewBag.IdTecnico = new SelectList
                    (
                        TecnicoRepository.GetAll(),
                        "IdTecnico",
                        "Nome",
                        pOS.IdTecnico
                    );

                    OrdemServicoRepository nova = new OrdemServicoRepository();
                    nova.Create(pOS);
                    return RedirectToAction("ListOS");
                }

                return View("CreateOS");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //
        // GET: /OrdemServico/Edit/5
        public ActionResult EditOS(int pId)
        {
            var os = OrdemServicoRepository.GetOne(pId);
            return View(os);
        }

        //
        // POST: /OrdemServico/Edit/5
        [HttpPost]
        public ActionResult EditOS(OrdemServico pOS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrdemServicoRepository edit = new OrdemServicoRepository();
                    edit.Update(pOS);
                    return RedirectToAction("ListOS");
                }


                return View("EditOS");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrdemServico/Delete/5
        public ActionResult DeleteOS(int pId)
        {
            var os = OrdemServicoRepository.GetOne(pId);
            return View(os);
        }

        //
        // POST: /OrdemServico/Delete/5
        [HttpPost]
        public ActionResult DeleteOS(OrdemServico pOS, int pId)
        {
            try
            {
                OrdemServicoRepository exclui = new OrdemServicoRepository();
                exclui.Delete(pId);
                return RedirectToAction("ListOS");
            }
            catch
            {
                return View();
            }
        }
        //
        // POST: /OrdemServico/List/5
        public ActionResult ListOS()
        {
            var os = OrdemServicoRepository.GetAll();
            return View(os);
        }
        //
        // GET: /Cliente/Search/5
        public ActionResult SearchOS()
        {
            return View();
        }
        //
        // POST: /Cliente/Search/5
        [HttpPost]
        public ActionResult SearchOS(FormCollection form)
        {
            var nome = form["NumOS"];
            return RedirectToAction("NumOS", form);
        }
        //
        // POST: /OrdemServico/SearchTecnico/5
        public ActionResult SearchTecnicoNome(String pTecnicoNome)
        {
            var tecnico = OrdemServicoRepository.GetSearchByTecnico(pTecnicoNome);
            return View(tecnico);
        }
        //
        // POST: /OrdemServico/SearchCliente/5
        public ActionResult SearchClienteNome(String pClienteNome)
        {
            var cliente = OrdemServicoRepository.GetSearchByCliente(pClienteNome);
            return View(cliente);
        }
    }
}
