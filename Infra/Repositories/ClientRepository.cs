

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ClientRepository : IRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public ClientRepository()
        {

        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IDTO GetById(int codigo)
        {
            ClientDTO obj;
            using (var db = new EFModel())
            {
                // Display all Blogs from the database 
                var query = from b in db.Client where b.codigo == codigo select b;
                Client Client = query.FirstOrDefault();
                obj = Mapper.Map<Client, ClientDTO>(Client);
            }


            return obj;
        }

        /// <summary>
        /// to delete a user from database
        /// </summary>
        /// <param name="id">the id primary key from object</param>
        public void Delete(int codigo)
        {
            try
            {
                ClientDTO obj = new ClientDTO();
                using (var db = new EFModel())
                {
                    // Display all Blogs from the database 
                    var query = from b in db.Client where b.codigo == codigo select b;
                    Client client = query.FirstOrDefault();
                    //Delete it from memory
                    db.Client.Remove(client);
                    //Save to database\ 
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IEnumerable<IDTO> ListAll()
        {
            IEnumerable<IDTO> AllObj = new List<ClientDTO>();
                using (var db = new EFModel())
                {
                    // Display all Clients from the database 
                    var query = from b in db.Client select b;
                    List<Client> list = query.ToList();
                    AllObj = Mapper.Map<List<Client>, List<ClientDTO>>(list);

                }


                return AllObj;
            
        }



      

        /// <summary>
        /// to insert a new object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Save(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    Client client = Mapper.Map<Client>(ValidateBusiness(dto));

                    using (var db = new EFModel())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            // Display all Clients from the database                        
                            db.Client.Add(client);
                            id = db.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// to update an object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Update(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    Client client = Mapper.Map<Client>(ValidateBusiness(dto));
                    using (var db = new EFModel())
                    {
                        // Display all Clients from the database                        
                        db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                        id = db.SaveChanges();

                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// function to validate if this dto is according into business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public bool ValidateEntitie(IDTO dto)
        {
            ClientDTO clientDTO = (ClientDTO)dto;
            bool validated = false;
            if (string.IsNullOrEmpty(clientDTO.nome) || string.IsNullOrWhiteSpace(clientDTO.nome))
            {
                throw new Exception("O campo nome é obrigatório");
            }
            else
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// function to validate business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public IDTO ValidateBusiness(IDTO dto)
        {
            ClientDTO clientdto = (ClientDTO)dto;
            bool validated = false;
            if (!string.IsNullOrEmpty(clientdto.tipo) &&
                !string.IsNullOrWhiteSpace(clientdto.tipo))
            {
                if (clientdto.tipo == "Física")
                {
                    clientdto.CNPJ = "";
                }
                else if(clientdto.tipo != "Física")
                {
                    clientdto.CPF = "";
                }

            }
            return clientdto;
        }
    }
}
