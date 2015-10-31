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
            try
            {
                var agenda = AgendaRepository.GetOne(pId);
                return View(agenda);
            }
            catch
            {
                throw;
            }
            
        }

        //
        // GET: /Agenda/Create
        public ActionResult CreateAgenda()
        {
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome");
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome");
            ViewBag.Status = new SelectList(new Agenda().ListStatus(), "Status", "Status");
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
                    ViewBag.Status = new SelectList(new Agenda().ListStatus(), "Status", "Status", pAgenda.Status);
                    AgendaRepository nova = new AgendaRepository();
                    nova.Create(pAgenda);
                    return RedirectToAction("ListAgendas").ComMensagemDeSucesso("Agendamento cadastrado com sucesso!");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Agenda/Edit/5
        public ActionResult EditAgenda(int pId)
        {
            try
            {
                var agenda = AgendaRepository.GetOne(pId);
                ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", agenda.IdTecnico);
                ViewBag.Status = new SelectList(new Agenda().ListStatus(), "Status", "Status", agenda.Status);
                return View(agenda);
            }
            catch
            {
                throw;
            }
            
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
                    ViewBag.Status = new SelectList(new Agenda().ListStatus(), "Status", "Status", pAgenda.Status);
                    AgendaRepository edit = new AgendaRepository();
                    edit.Update(pAgenda);
                    return RedirectToAction("ListAgendas").ComMensagemDeSucesso("Agendamento editado com sucesso!");
                }
                else
                {
                    return View("EditAgenda");
                }
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Agenda/Delete/5
        public ActionResult DeleteAgenda(int pId)
        {
            try
            {
                var agenda = AgendaRepository.GetOne(pId);
                return View(agenda);
            }
            catch
            {
                throw;
            }
            
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
                return RedirectToAction("ListAgendas").ComMensagemDeSucesso("Agendamento excluído com sucesso!");
            }
            catch
            {
                throw;
            }
        }
        //
        // GET: /Agenda/List/5
        public ActionResult ListAgendas()
        {
            ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search");
            var agendas = AgendaRepository.GetAll();
            return View(agendas);
        }
        //
        // POST: /Agenda/List/5
        [HttpPost]
        public ActionResult ListAgendas(FormCollection form)
        {
            string nome = form["NomeSearch"];
            string search = form["Search"];

            if (nome.Trim() != "")
            {
                if (search != "")
                {
                    if (search == "Tecnico")
                    {
                        var tecnicoAgendas = AgendaRepository.GetTecnicoNome(nome);
                        if (tecnicoAgendas.Count == 0)
                        {
                            var agendas = AgendaRepository.GetAll();
                            ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                            return View(agendas).ComMensagemDeErro("Tecnico não encontrado!");
                        }
                        ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                        return View(tecnicoAgendas);
                    }
                    else
                    {
                        if (search == "Cliente")
                        {
                            var clienteAgendas = AgendaRepository.GetClienteNome(nome);
                            if (clienteAgendas.Count == 0)
                            {
                                var agendas = AgendaRepository.GetAll();
                                ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                                return View(agendas).ComMensagemDeErro("Cliente não encontrado!");
                            }
                            ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                            return View(clienteAgendas);
                        }
                        else
                        {
                            if (search == "Status")
                            {
                                    var statusAgendas = AgendaRepository.GetStatus(nome);
                                    if (statusAgendas.Count == 0)
                                    {
                                        var agendas = AgendaRepository.GetAll();
                                        ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                                        return View(agendas).ComMensagemDeErro("Digite um Status válido!");
                                    }
                                    ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                                    return View(statusAgendas);
                            }
                            else
                            {
                                var agendas = AgendaRepository.GetAll();
                                ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                                return View(agendas);
                            }
                         }
                    }

                }
                else
                {
                    var agendas = AgendaRepository.GetAll();
                    ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                    return View(agendas).ComMensagemDeErro("Escolha um tipo de busca!");
                }
            }
            else
            {
                var agendas = AgendaRepository.GetAll();
                ViewBag.Search = new SelectList(new Agenda().ListSearch(), "Search", "Search", search);
                return View(agendas).ComMensagemDeErro("Digite o que busca!");
            }
        }
    }
}
