using Atenda.Data;
using Atenda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atenda.API.Controllers
{
    public class OrcamentoController : ApiController
    {
        // GET: api/Orcamento
        public IEnumerable<Orcamento> GetAll()
        {
            var orcamentos = OrcamentoRepository.GetAll();

            return orcamentos;
        }

        // GET: api/Orcamento/5
        public Orcamento GetOne(int pId)
        {
            Orcamento orcamento = OrcamentoRepository.GetOne(pId);
            if (orcamento == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return orcamento;
        }

        // POST: api/Orcamento
        public HttpResponseMessage Post(Orcamento pOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                OrcamentoRepository create = new OrcamentoRepository();
                create.Create(pOrcamento);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // PUT: api/Orcamento/5
        public HttpResponseMessage Put(int pId, Orcamento pOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (pId != pOrcamento.IdCliente)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                OrcamentoRepository update = new OrcamentoRepository();
                update.Update(pOrcamento);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // DELETE: api/Orcamento/5
        public HttpResponseMessage Delete(int pId)
        {
            try
            {
                OrcamentoRepository update = new OrcamentoRepository();
                var orcamento = OrcamentoRepository.GetOne(pId);
                if (orcamento.IdOrcamento != 0)
                {
                    update.Delete(pId);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
