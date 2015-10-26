using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Data;
using Atenda.Repository;

namespace Atenda.Controllers
{
    public class AgendaController : Controller
    {
        //
        // GET: /Agenda/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Agenda/Details/5
        public ActionResult DetailsAgenda(int pId)
        {
            var agenda = AgendaRepository.GetOne(pId);
            return View(agenda);
        }

        //
        // GET: /Agenda/Create
        public ActionResult CreateAgenda()
        {
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome");
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome");
            return View();
        }

        //
        // POST: /Agenda/Create
        [HttpPost]
        public ActionResult CreateAgenda(Agenda pAgenda)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pAgenda.IdTecnico);
                    ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome", pAgenda.IdCliente);

                    AgendaRepository nova = new AgendaRepository();
                    nova.Create(pAgenda);
                    return RedirectToAction("ListAgendas");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Agenda/Edit/5
        public ActionResult EditAgenda(int pId)
        {
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome");
            var agenda = AgendaRepository.GetOne(pId);
            return View(agenda);
        }

        //
        // POST: /Agenda/Edit/5
        [HttpPost]
        public ActionResult EditAgenda(Agenda pAgenda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pAgenda.IdTecnico);
                    AgendaRepository edit = new AgendaRepository();
                    edit.Update(pAgenda);
                    return RedirectToAction("ListAgendas");
                }

                return View("EditAgenda");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Agenda/Delete/5
        public ActionResult DeleteAgenda(int pId)
        {
            var agenda = AgendaRepository.GetOne(pId);
            return View(agenda);
        }

        //
        // POST: /Agenda/Delete/5
        [HttpPost]
        public ActionResult DeleteAgenda(Agenda pAgenda, int pId)
        {
            try
            {
                AgendaRepository exclui = new AgendaRepository();
                exclui.Delete(pId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Agenda/List/5
        public ActionResult ListAgendas()
        {
            var agendas = AgendaRepository.GetAll();
            return View(agendas);
        }
        //
        // POST: /Agenda/List/5
        [HttpPost]
        public ActionResult ListAgendas(FormCollection form)
        {
            string nome = form["NomeTecnico"];

            if (nome != null)
            {
                var agendas = AgendaRepository.GetTecnicoNome(nome);
                return View(agendas);
            }
            else
            {
                var agendas = AgendaRepository.GetAll();
                return View(agendas);
            }

        }
        //
        // GET: /Agenda/SearchTecnico/5
        public ActionResult SearchTecnicoNome()
        {
            return View();
        }
        //
        // POST: /Agenda/SearchTecnico/5
        [HttpPost]
        public ActionResult SearchTecnicoNome(String pTecnicoNome)
        {
            var tecnico = AgendaRepository.GetTecnicoNome(pTecnicoNome);
            return View(tecnico);
        }
        //
        // POST: /Agenda/SearchCliente/5
        public ActionResult SearchClienteNome(String pClienteNome)
        {
            var cliente = AgendaRepository.GetClienteNome(pClienteNome);
            return View(cliente);
        }

    }
}
