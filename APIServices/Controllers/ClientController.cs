

namespace APIServices.Controllers
{
    using DTO;
    using Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/Client")]

    public class ClientController : ApiController
    {

        private static ClientRepository _rep;
        // GET: api/Client

        [HttpGet]
        public IList<ClientDTO> Get()
        {
            _rep = new ClientRepository();
            IList<ClientDTO> clients = (List<ClientDTO>)_rep.ListAll();
            return clients;
        }

        // GET: api/Client/5    
        [HttpGet]
        public ClientDTO Get(int id)
        {
            _rep = new ClientRepository();
            ClientDTO client = (ClientDTO)_rep.GetById(id);
            return client;
        }

        [HttpPost]
        // POST: api/Client
        public HttpResponseMessage Post([FromBody]ClientDTO dto)
        {
            _rep = new ClientRepository();
            try
            {
                int saved = _rep.Save(dto);
                if (saved > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível salvar os dados do cliente, contacte o administrador !");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        // PUT: api/Client/5
        public HttpResponseMessage Put([FromBody]ClientDTO dto)
        {
            _rep = new ClientRepository();
            try
            {
                int saved = _rep.Update(dto);
                if (saved > 0 && dto.codigo > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível atualizar os dados do cliente, contacte o administrador!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        // DELETE: api/Client/5
        public HttpResponseMessage Delete(int id)
        {
            _rep = new ClientRepository();
            try
            {
                _rep.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
