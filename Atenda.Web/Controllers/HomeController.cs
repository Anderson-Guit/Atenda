using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Repository;
using Atenda.Data;
using Atenda.Web.Controllers;

namespace Atenda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ViewBag.Agenda = AgendaRepository.GetAllToIndex();
                ViewBag.Title = "Atenda";
                return View();
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login pLogin)
        {
            if (ModelState.IsValid)
            {
                Tecnico tecnico = TecnicoRepository.CheckUser(pLogin);

                if (tecnico.Nome != null)
                {

                    Session["Nome"] = tecnico.Nome;

                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Login").ComMensagemDeErro("Nome ou senha inválidos!");
                }

            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            @Session["Nome"] = null;

            if (Session["Nome"] == null)
            {
                return RedirectToAction("Login").ComMensagemDeSucesso("Logout feito com sucesso!");
            }
            else
            {
                return View("Logout");
            }

        }
    }
}