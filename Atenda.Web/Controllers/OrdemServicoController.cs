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
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome");
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome");
            ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status");
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
                    ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome", pOS.IdCliente);
                    ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pOS.IdTecnico);
                    ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", pOS.Status);
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
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", os.IdTecnico);
            ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", os.Status);
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
                    ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pOS.IdTecnico);
                    ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", pOS.Status);
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
        // GET: /OrdemServico/List/5
        public ActionResult ListOS()
        {
            var os = OrdemServicoRepository.GetAll();
            return View(os);
        }
        //
        // POST: /Agenda/List/5
        [HttpPost]
        public ActionResult ListAgendas(FormCollection form)
        {
            string nome = form["TecnicoNome"];

            if (nome != null)
            {
                var agendas = OrdemServicoRepository.GetTecnicoNome(nome);
                return View(agendas);
            }
            else
            {
                var agendas = OrdemServicoRepository.GetAll();
                return View(agendas);
            }
        }
    }
}
