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
            try
            {
                var tecnico = TecnicoRepository.GetOne(pId);
                return View(tecnico);
            }
            catch
            {
                throw;
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    TecnicoRepository create = new TecnicoRepository();
                    create.Create(pTecnico);
                    return RedirectToAction("ListTecnicos").ComMensagemDeSucesso("Técnico cadastrado com sucesso!");
                }
                else
                {
                    return View("CreateTecnico");
                }
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Tecnico/Edit/5
        public ActionResult EditTecnico(int pId)
        {
            try
            {
                var tecnico = TecnicoRepository.GetOne(pId);
                return View(tecnico);
            }
            catch
            {
                throw;
            }
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
                    return RedirectToAction("ListTecnicos").ComMensagemDeSucesso("Técnico editado com sucesso!");
                }
                else
                {
                    return View("EditTecnico");
                }               
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Tecnico/Delete/5
        public ActionResult DeleteTecnico(int pId)
        {
            try
            {
                var tecnico = TecnicoRepository.GetOne(pId);
                return View(tecnico);
            }
            catch
            {
                throw;
            }
        }

        //
        // POST: /Tecnico/Delete/5
        [HttpPost]
        public ActionResult DeleteTecnico(Tecnico pTecnico, int pId)
        {
            try
            {
                    TecnicoRepository exclui = new TecnicoRepository();
                    exclui.Delete(pId);
                    return RedirectToAction("ListTecnicos").ComMensagemDeSucesso("Técnico deletado com sucesso!");
            }
            catch
            {
                return RedirectToAction("ListTecnicos").ComMensagemDeErro("Técnico não pode ser deletado! Existe pendencias");
            }
        }
        //
        // GET: /Tecnico/List/5
        public ActionResult ListTecnicos()
        {
            var tecnicos = TecnicoRepository.GetAll();
            return View(tecnicos);
        }
        //
        // POST: /Tecnico/List/5
        [HttpPost]
        public ActionResult ListTecnicos(FormCollection form)
        {
                string nome = form["TecnicoNome"];

                if (nome.Trim() == "")
                {
                    var tecnicos = TecnicoRepository.GetAll();
                    return View(tecnicos).ComMensagemDeErro("Digite um nome!");
                }

                var TecnicoNome = TecnicoRepository.GetName(nome);

                if (TecnicoNome.Count == 0)
                {
                    var tecnicos = TecnicoRepository.GetAll();
                    return View(tecnicos).ComMensagemDeErro("Tecnico não encontrado!");
                }
                return View(TecnicoNome);                
        }
    }
}
