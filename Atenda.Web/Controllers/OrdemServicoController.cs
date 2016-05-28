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
    public class OrdemServicoController : Controller
    {
        //
        // GET: /OrdemServico/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /OrdemServico/Details/5
        public ActionResult DetailsOS(int pId)
        {
            try
            {
                var os = OrdemServicoRepository.GetOne(pId);
                return View(os);
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /OrdemServico/Create
        public ActionResult CreateOS()
        {
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome");
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome");
            ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status");
            ViewBag.ListProdutos = null;
            return View();
        }

        //
        // POST: /OrdemServico/Create
        [HttpPost]
        public ActionResult CreateOS(OrdemServico pOS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome", pOS.IdCliente);
                    ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pOS.IdTecnico);
                    ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", pOS.Status);
                    ViewBag.ListProdutos = null;
                    OrdemServicoRepository nova = new OrdemServicoRepository();
                    nova.Create(pOS);
                    return RedirectToAction("ListOS").ComMensagemDeSucesso("OS cadastrada com sucesso!");
                }
                else
                {
                    return View("CreateOS");
                }
            }
            catch
            {
                throw;
            }
        }

        // GET: /OrdemServico/Edit/5
        public ActionResult AddProdutos(OrdemServico pOS)
        {
            ViewBag.IdProduto = new SelectList(ProdutoRepository.GetAll(), "IdProduto", "Nome");
            return View();
        }

        // POST: /OrdemServico/Edit/5
        [HttpPost]
        public ActionResult AddProdutos(OrdemServico pOS, List<Produto> ListProd)
        {
            ViewBag.IdCliente = new SelectList(ClienteRepository.GetAll(), "IdCliente", "Nome", pOS.IdCliente);
            ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pOS.IdTecnico);
            ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", pOS.Status);
            ViewBag.ListProdutos = pOS.IdProduto;
            return View("CreateOS");
        }

        //
        // GET: /OrdemServico/Edit/5
        public ActionResult EditOS(int pId)
        {
            try
            {
                var os = OrdemServicoRepository.GetOne(pId);
                ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", os.IdTecnico);
                ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", os.Status);
                //List<Produto> list = ProdutoRepository.GetAllByOS(pId);
                //ViewBag.ListProdutos = list;
                return View(os);
            }
            catch
            {
                throw;
            }
        }

        //
        // POST: /OrdemServico/Edit/5
        [HttpPost]
        public ActionResult EditOS(OrdemServico pOS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.IdTecnico = new SelectList(TecnicoRepository.GetAll(), "IdTecnico", "Nome", pOS.IdTecnico);
                    ViewBag.Status = new SelectList(new OrdemServico().ListStatus(), "Status", "Status", pOS.Status);
                    OrdemServicoRepository edit = new OrdemServicoRepository();
                    edit.Update(pOS);
                    return RedirectToAction("ListOS").ComMensagemDeSucesso("OS editada com sucesso!");
                }
                else
                {
                    return View("EditOS");
                }               
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /OrdemServico/Delete/5
        public ActionResult DeleteOS(int pId)
        {
            try
            {
                var os = OrdemServicoRepository.GetOne(pId);
                return View(os);
            }
            catch
            {
                throw;
            } 
        }

        //
        // POST: /OrdemServico/Delete/5
        [HttpPost]
        public ActionResult DeleteOS(OrdemServico pOS, int pId)
        {
            try
            {
                OrdemServicoRepository exclui = new OrdemServicoRepository();
                exclui.Delete(pId);
                return RedirectToAction("ListOS").ComMensagemDeSucesso("OS encerrada com sucesso!");
            }
            catch
            {
                throw;
            }
        }
        //
        // GET: /OrdemServico/List/5
        public ActionResult ListOS()
        {
            ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search");
            var os = OrdemServicoRepository.GetAll();
            return View(os);
        }
        //
        // POST: /Agenda/List/5
        [HttpPost]
        public ActionResult ListOS(FormCollection form)
        {
            string nome = form["NomeSearch"];
            string search = form["Search"];

            if (nome.Trim() != "")
            {
                if (search != "")
                {
                    if (search == "Tecnico")
                    {
                        ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                        var nOs = OrdemServicoRepository.GetTecnicoNome(nome);
                        if (nOs.Count == 0)
                        {
                            ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                            var os = OrdemServicoRepository.GetAll();
                            return View(os).ComMensagemDeErro("Técnico não encontrado!");
                        }
                        return View(nOs);
                    }
                    else
                    {
                        if (search == "Cliente")
                        {
                            ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                            var nOs = OrdemServicoRepository.GetClienteNome(nome);
                            if (nOs.Count == 0)
                            {
                                ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                                var os = OrdemServicoRepository.GetAll();
                                return View(os).ComMensagemDeErro("Cliente não encontrado!");
                            }
                            return View(nOs);
                        }
                        else
                        {
                            if (search == "Nº OS")
                            {
                                try
                                {
                                    int id = int.Parse(nome);

                                    if (id > 0)
                                    {
                                        ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                                        var nOs = OrdemServicoRepository.GetIdOS(id);
                                        if (nOs.Count == 0)
                                        {
                                            ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                                            var os = OrdemServicoRepository.GetAll();
                                            return View(os).ComMensagemDeErro("Nº de OS não encontrado!");
                                        }
                                        return View(nOs);
                                    }
                                    else
                                    {
                                        ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                                        var os = OrdemServicoRepository.GetAll();
                                        return View(os).ComMensagemDeErro("Nº de OS não pode ser 0 ou negativo!");
                                    }
                                }
                                catch
                                {
                                    ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                                    var os = OrdemServicoRepository.GetAll();
                                    return View(os).ComMensagemDeErro("Digite um numero!");
                                }
                            }
                            else
                            {
                                ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                                var os = OrdemServicoRepository.GetAll();
                                return View(os);
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                    var os = OrdemServicoRepository.GetAll();
                    return View(os).ComMensagemDeErro("Digite um tipo de busca!");
                }
            }
            else
            {
                ViewBag.Search = new SelectList(new OrdemServico().ListSearch(), "Search", "Search", search);
                var os = OrdemServicoRepository.GetAll();
                return View(os).ComMensagemDeErro("Digite o que busca!");
            }
        }
    }
}
