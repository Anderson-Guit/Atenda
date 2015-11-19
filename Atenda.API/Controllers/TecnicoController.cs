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
    public class TecnicoController : ApiController
    {
        // GET: api/Tecnico
        public IEnumerable<Tecnico> GetAll()
        {
            var tecnicos = TecnicoRepository.GetAll();
            return tecnicos;
        }

        // GET: api/Tecnico/5
        public Tecnico GetOne(int pId)
        {
            Tecnico cliente = TecnicoRepository.GetOne(pId);
            if (cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cliente;
        }

        //// POST: api/Tecnico
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Tecnico/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Tecnico/5
        //public void Delete(int id)
        //{
        //}
    }
}
