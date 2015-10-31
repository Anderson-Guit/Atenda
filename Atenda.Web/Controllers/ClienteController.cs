using System;
using Atenda.Repository;
using Atenda.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Web.Controllers;

namespace Atenda.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Cliente/Details/5
        public ActionResult DetailsCliente(int pId)
        {
            try
            {
                var cliente = ClienteRepository.GetOne(pId);
                return View(cliente);
            }
            catch
            {
                throw;
            }
            
        }

        //
        // GET: /Cliente/Create
        public ActionResult CreateCliente()
        {
            ViewBag.Estado = new SelectList(new Cliente().ListaEstados(), "Estado", "Estado");
            return View();
        }

        //
        // POST: /Cliente/Create
        [HttpPost]
        public ActionResult CreateCliente(Cliente pCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Estado = new SelectList(new Cliente().ListaEstados(), "Estado", "Estado", pCliente.Estado);

                    ClienteRepository create = new ClienteRepository();
                    create.Create(pCliente);
                    return RedirectToAction("ListClientes").ComMensagemDeSucesso("Cliente cadastrado com sucesso!");
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
        // GET: /Cliente/Edit/5
        public ActionResult EditCliente(int pId)
        {
            try
            {
                var cliente = ClienteRepository.GetOne(pId);
                ViewBag.Estado = new SelectList(new Cliente().ListaEstados(), "Estado", "Estado", cliente.Estado);
                return View(cliente);
            }
            catch
            {
                throw;
            }
        }

        //
        // POST: /Cliente/Edit/5
        [HttpPost]
        public ActionResult EditCliente(Cliente pCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Estado = new SelectList(new Cliente().ListaEstados(), "Estado", "Estado", pCliente.Estado);
                    ClienteRepository edit = new ClienteRepository();
                    edit.Update(pCliente);
                    return RedirectToAction("ListClientes").ComMensagemDeSucesso("Cliente editado com sucesso!");
                }

                return View("EditCliente");
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Cliente/Delete/5
        public ActionResult DeleteCliente(int pId)
        {
            try
            {
                var pCliente = ClienteRepository.GetOne(pId);
                return View(pCliente);
            }
            catch
            {
                throw;
            }
        }

        //
        // POST: /Cliente/Delete/5
        [HttpPost]
        public ActionResult DeleteCliente(Cliente pCliente, int pId)
        {
            try
            {
                ClienteRepository exclui = new ClienteRepository();
                exclui.Delete(pId);
                return RedirectToAction("ListClientes").ComMensagemDeSucesso("Cliente excluído com sucesso!");
            }
            catch
            {
                return RedirectToAction("ListClientes").ComMensagemDeErro("Cliente não pode ser excluido! Existe pendências no sistema.");
            }
        }
        //
        // GET: /Cliente/List/5
        public ActionResult ListClientes()
        {
                var Cliente = ClienteRepository.GetAll();
                return View(Cliente);
        }
        //
        // POST: /Cliente/List/5
        [HttpPost]
        public ActionResult ListClientes(FormCollection form)
        {
                    string nome = form["ClienteNome"];

                    if (nome.Trim() == "")
                    {
                        var Cliente = ClienteRepository.GetAll();
                        return View(Cliente).ComMensagemDeErro("Digite um nome!");
                    }

                    var ClienteNome = ClienteRepository.GetName(nome);

                    if (ClienteNome.Count == 0)
                    {
                        var Cliente = ClienteRepository.GetAll();
                        return View(Cliente).ComMensagemDeErro("Cliente não encontrado!");
                    }
                    return View(ClienteNome);
        }
    }
    
}