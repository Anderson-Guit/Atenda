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
    public class AgendaController : ApiController
    {
        // GET: api/Agenda
        [ActionName("Listar")]
        public IEnumerable<Agenda> GetAll()
        {
            var agendas = AgendaRepository.GetAll();
            return agendas;
        }

        // GET: api/Agenda/5
        public Agenda GetOne(int pId)
        {
            var agenda = AgendaRepository.GetOne(pId);
            if (agenda == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return agenda;
        }

        // POST: api/Agenda
        public HttpResponseMessage Post(Agenda pAgenda)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                AgendaRepository create = new AgendaRepository();
                create.Create(pAgenda);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // PUT: api/Agenda/5
        public HttpResponseMessage Put(int pId, Agenda pAgenda)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (pId != pAgenda.IdAgenda)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                AgendaRepository update = new AgendaRepository();
                update.Update(pAgenda);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // DELETE: api/Agenda/5
        public HttpResponseMessage Delete(int pId)
        {
            try
            {
                AgendaRepository update = new AgendaRepository();
                var cliente = AgendaRepository.GetOne(pId);
                if (cliente.IdCliente != 0)
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
