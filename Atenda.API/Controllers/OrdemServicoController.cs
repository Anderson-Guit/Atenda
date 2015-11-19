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
    public class OrdemServicoController : ApiController
    {
        // GET: api/OrdemServico
        public IEnumerable<OrdemServico> GetAll()
        {
            var os = OrdemServicoRepository.GetAll();

            return os;
        }

        // GET: api/OrdemServico/5
        public OrdemServico GetOne(int pId)
        {
            OrdemServico os = OrdemServicoRepository.GetOne(pId);
            if (os == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return os;
        }

        // POST: api/OrdemServico
        public HttpResponseMessage Post(OrdemServico pOS)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                OrdemServicoRepository create = new OrdemServicoRepository();
                create.Create(pOS);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // PUT: api/OrdemServico/5
        public HttpResponseMessage Put(int pId, OrdemServico pOS)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (pId != pOS.IdCliente)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                OrdemServicoRepository update = new OrdemServicoRepository();
                update.Update(pOS);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // DELETE: api/OrdemServico/5
        public HttpResponseMessage Delete(int pId)
        {
            try
            {
                OrdemServicoRepository update = new OrdemServicoRepository();
                var os = OrdemServicoRepository.GetOne(pId);
                if (os.IdOS != 0)
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
