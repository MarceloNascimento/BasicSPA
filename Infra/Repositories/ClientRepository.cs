

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
        public ClientDTO GetById(int codigo)
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
        public IList<ClientDTO> ListAll()
        {
            List<ClientDTO> AllObj;
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
        /// function to validate if this dto is according into business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public bool ValidateRepository(IDTO dto)
        {
            ClientDTO validatingDTO = (ClientDTO)dto;
            bool validated = false;
            if(string.IsNullOrEmpty(validatingDTO.nome) || string.IsNullOrWhiteSpace(validatingDTO.nome))
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
        /// to insert a new object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Save(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateRepository(dto))
                {
                    Client client = Mapper.Map<Client>(dto);

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
                if (ValidateRepository(dto))
                {
                    Client client = Mapper.Map<Client>(dto);
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

    }
}
