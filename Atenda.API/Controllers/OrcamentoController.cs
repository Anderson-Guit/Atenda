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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Orcamento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Orcamento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Orcamento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Orcamento/5
        public void Delete(int id)
        {
        }
    }
}
