using System;
using Atenda.Repository;
using Atenda.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atenda.Controllers
{
    public class TecnicoController : Controller
    {
        //
        // GET: /Tecnico/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tecnico/Details/5
        public ActionResult DetailsTecnico(int pId)
        {
            var tecnico = TecnicoRepository.GetOne(pId);
            return View(tecnico);
        }

        //
        // GET: /Tecnico/Create
        public ActionResult CreateTecnico()
        {
            return View();
        }

        //
        // POST: /Tecnico/Create
        [HttpPost]
        public ActionResult CreateTecnico(Tecnico pTecnico)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
                    TecnicoRepository create = new TecnicoRepository();
                    create.Create(pTecnico);
                    return RedirectToAction("ListTecnicos");
            //    }

            //    return View("CreateTecnico");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //
        // GET: /Tecnico/Edit/5
        public ActionResult EditTecnico(int pId)
        {
            var tecnico = TecnicoRepository.GetOne(pId);
            return View(tecnico);
        }

        //
        // POST: /Tecnico/Edit/5
        [HttpPost]
        public ActionResult EditTecnico(Tecnico pTecnico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TecnicoRepository edit = new TecnicoRepository();
                    edit.Update(pTecnico);
                    return RedirectToAction("ListTecnicos");
                }

                return View("EditTecnico");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tecnico/Delete/5
        public ActionResult DeleteTecnico(int pId)
        {
            var tecnico = TecnicoRepository.GetOne(pId);
            return View(tecnico);
        }

        //
        // POST: /Tecnico/Delete/5
        [HttpPost]
        public ActionResult DeleteTecnico(Tecnico pTecnico, int pId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TecnicoRepository exclui = new TecnicoRepository();
                    exclui.Delete(pId);
                    return RedirectToAction("ListTecnicos");
                }

                return View("ListTecnicos");
            }
            catch
            {
                return View();
            }
        }
        //
        // POST: /Tecnico/List/5
        public ActionResult ListTecnicos()
        {
            var tecnico = TecnicoRepository.GetAll();
            return View(tecnico);
        }
        //
        // POST: /Tecnico/Search/5
        public ActionResult SearchTecnico(String pNome)
        {
            var tecnico = TecnicoRepository.GetBySearch(pNome);
            return View(tecnico);
        }
    }
}
