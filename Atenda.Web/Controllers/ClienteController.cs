using System;
using Atenda.Repository;
using Atenda.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if (pId != 0)
            {
                var cliente = ClienteRepository.GetOne(pId);
                return View(cliente);
            }
            else 
            {
                var busca = ViewBag.IdCliente;
                var cliente = ClienteRepository.GetOne(busca);
                return View();
            }
        }

        //
        // GET: /Cliente/Create
        public ActionResult CreateCliente()
        {
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
                    ClienteRepository create = new ClienteRepository();
                    create.Create(pCliente);
                    return RedirectToAction("ListClientes");
                }

                return View("CreateCliente");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cliente/Edit/5
        public ActionResult EditCliente(int pId)
        {
            var cliente = ClienteRepository.GetOne(pId);
            return View(cliente);
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
                    ClienteRepository edit = new ClienteRepository();
                    edit.Update(pCliente);
                    return RedirectToAction("ListClientes");
                }

                return View("EditCliente");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cliente/Delete/5
        public ActionResult DeleteCliente(int pId)
        {
            var pCliente = ClienteRepository.GetOne(pId);
            return View(pCliente);
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
                return RedirectToAction("ListClientes");

            }
            catch
            {
                return View();
            }
        }
        //
        // POST: /Cliente/List/5
        public ActionResult ListClientes()
        {
            var Cliente = ClienteRepository.GetAll();
            return View(Cliente);
        }
        //
        // GET: /Cliente/Search/5
        public ActionResult SearchCliente()
        {
            return View();
        }
        //
        // POST: /Cliente/Search/5
        [HttpPost]
        public ActionResult SearchCliente(String Nome)
        {
            var cliente = ClienteRepository.GetName(Nome);
            ViewBag.IdCliente = cliente.IdCliente;
            return RedirectToAction("DetailsCliente", null, cliente.IdCliente);
        }
    }
}
