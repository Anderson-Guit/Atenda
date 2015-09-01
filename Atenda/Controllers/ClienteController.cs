﻿using System;
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
            var cliente = ClienteRepository.GetOne(pId);
            return View(cliente);
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
        public ActionResult EditCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClienteRepository edit = new ClienteRepository();
                    edit.Update(cliente);
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
            return View();
        }

        //
        // POST: /Cliente/Delete/5
        [HttpPost]
        public ActionResult DeleteCliente(int pId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClienteRepository exclui = new ClienteRepository();
                    exclui.Delete(pId);
                    return RedirectToAction("ListClientes");
                }

                return View("ListClientes");
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
        // POST: /Cliente/Search/5
        public ActionResult SearchCliente(String pNome)
        {
            var cliente = ClienteRepository.GetName(pNome);
            return View(cliente);
        }
    }
}