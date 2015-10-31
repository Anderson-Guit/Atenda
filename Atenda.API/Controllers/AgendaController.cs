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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Agenda/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Agenda
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Agenda/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Agenda/5
        public void Delete(int id)
        {
        }
    }
}
