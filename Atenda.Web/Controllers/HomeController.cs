using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Repository;
using Atenda.Data;

namespace Atenda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Agenda = AgendaRepository.GetAllToIndex();
            ViewBag.Title="Atenda";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Nome, String Senha)
        {
            if (ModelState.IsValid)
            {
                Tecnico tecnico = TecnicoRepository.CheckUser(Nome, Senha);

                if (tecnico.Nome != null)
                {

                    Session["Nome"] = tecnico.Nome;

                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            @Session["Nome"] = null;

            if (Session["Nome"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View("Logout");
            }

        }
    }
}