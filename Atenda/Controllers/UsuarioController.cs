using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atenda.Repository;
using Atenda.Data;

namespace Atenda.Controllers
{
    
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Nome, String Senha)
        {
            if (ModelState.IsValid)
            {
                var login = UsuarioRepository.CheckUser(Nome, Senha);

                if (login.Nome != null)
                {
              
                    Session["Nome"] = login.Nome;

                    if (login.Adm != false)
                    {
                        Session["Adm"] = login.Adm;
                    }

                    return View("../Home/Index");

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

        //
        // GET: /Usuario/Create
        public ActionResult CreateUsuario()
        {
            return View();
        }

        //
        // POST: /Usuario/CreateUsuario
        [HttpPost]
        public ActionResult CreateUsuario(Usuario pUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioRepository novo = new UsuarioRepository();
                    novo.Create(pUsuario);
                    return RedirectToAction("ListUsuarios");
                }
                return View("CreateUsuario");
            }
            catch (Exception)
            {
                
                return View();
            }
            
        }

        //
        // GET: /Usuario/Edit/5
        public ActionResult EditUsuario(int pId)
        {
            var usuario = UsuarioRepository.GetOne(pId);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5
        [HttpPost]
        public ActionResult EditUsuario(Usuario pUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioRepository edit = new UsuarioRepository();
                    edit.Update(pUsuario);
                    return RedirectToAction("ListUsuarios");
                }

                return View("EditUsuario");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Delete/5
        public ActionResult DeleteUsuario(int pId)
        {
            var usuario = UsuarioRepository.GetOne(pId);
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5
        [HttpPost]
        public ActionResult DeleteUsuario(Usuario usuario, int pId)
        {
            try
            {
                UsuarioRepository deletar = new UsuarioRepository();
                deletar.Delete(pId);
                return RedirectToAction("ListUsuarios");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListUsuarios()
        {
                var usuarios = UsuarioRepository.GetAll();
                return View(usuarios);
        }

    }
}
