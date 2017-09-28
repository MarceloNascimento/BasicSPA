

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

        private ClientRepository _rep = new ClientRepository();
        // GET: api/Client

        [HttpGet]
        public IList<ClientDTO> Get()
        {
            IList<ClientDTO> clients = _rep.ListAll();
            return clients;
        }

        // GET: api/Client/5    
        [HttpGet]
        public ClientDTO Get(int id)
        {
            ClientDTO client = _rep.GetById(id);
            return client;
        }

        [HttpPost]
        // POST: api/Client
        public HttpResponseMessage Post([FromBody]ClientDTO dto)
        {
            try
            {
                int saved = _rep.Save(dto);
                if(saved > 0) {
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
