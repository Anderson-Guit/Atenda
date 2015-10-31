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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrdemServico/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrdemServico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrdemServico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrdemServico/5
        public void Delete(int id)
        {
        }
    }
}
