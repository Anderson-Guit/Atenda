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
            ViewBag.Agenda = AgendaRepository.GetAll();
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
                Usuario usuario = UsuarioRepository.CheckUser(Nome, Senha);

                if (usuario.Nome != null)
                {

                    Session["Nome"] = usuario.Nome;

                    if (usuario.Adm != false)
                    {
                        Session["Adm"] = usuario.Adm;
                    }

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
            @Session["Adm"] = null;

            if (Session["Nome"] == null && Session["Adm"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View("Logout");
            }

        }

        public ActionResult IndexListAgendas()
        {
            var agendas = AgendaRepository.GetAll();
            return View(agendas);
        }
    }
}