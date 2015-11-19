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
    public class ProdutoController : ApiController
    {
        // GET: api/Produto
        public IEnumerable<Produto> GetAll()
        {
            var produtos = ProdutoRepository.GetAll();
            return produtos;
        }

        // GET: api/Produto/5
        public Produto GetOne(int pId)
        {
            var produto = ProdutoRepository.GetOne(pId);
            if (produto == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return produto;
        }

        //// POST: api/Produto
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Produto/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Produto/5
        //public void Delete(int id)
        //{
        //}
    }
}
