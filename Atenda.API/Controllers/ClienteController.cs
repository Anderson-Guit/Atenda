﻿using Atenda.Data;
using Atenda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atenda.API.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<Cliente> GetAll()
        {
            var clientes = ClienteRepository.GetAll();

            return clientes;
        }

        // GET: api/Cliente/5
        public Cliente GetOne(int pId)
        {
            Cliente cliente = ClienteRepository.GetOne(pId);
            if (cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cliente;
        }

        // POST: api/Cliente
        public HttpResponseMessage Post(Cliente pCliente)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                ClienteRepository create = new ClienteRepository();
                create.Create(pCliente);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // PUT: api/Cliente/5
        public HttpResponseMessage Put(int pId, Cliente pCliente)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (pId != pCliente.IdCliente)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                ClienteRepository update = new ClienteRepository();
                update.Update(pCliente);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // DELETE: api/Cliente/5
        public HttpResponseMessage Delete(int pId)
        {
            try
            {
                ClienteRepository update = new ClienteRepository();
                var cliente = ClienteRepository.GetOne(pId);
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
