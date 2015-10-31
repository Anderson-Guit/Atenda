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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tecnico/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tecnico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tecnico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tecnico/5
        public void Delete(int id)
        {
        }
    }
}
