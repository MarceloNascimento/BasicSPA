
namespace Tests
{
    using DTO;
    using Infra.Mappers;
    using Infra.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class ClientTest
    {
        private ClientRepository rep = new ClientRepository();



        [TestMethod]
        public void ListAllClientTest()
        {
            AutoMapperConfig.RegisterMappings();
            List<ClientDTO> clients = (List<ClientDTO>)rep.ListAll();
            Assert.IsTrue(clients.Count > 0);

        }

        [TestMethod]
        public void SaveNewClientTest()
        {
            AutoMapperConfig.RegisterMappings();
            ClientDTO dto = new ClientDTO();
            dto.nome = "Marcelo";
            dto.telefone = "022998701555";
            dto.CPF = "01010100101";
            dto.tipo = "F";
            rep.Save(dto);
        }

        [TestMethod]
        public void UpdateAClientTest()
        {
            AutoMapperConfig.RegisterMappings();
            ClientDTO dto = new ClientDTO();
            dto.codigo = 1;
            dto.nome = "Marcelo ";
            dto.telefone = "022998701555";
            dto.CPF = "";
            dto.tipo = "J";
            dto.CNPJ = "01010100101";
            rep.Update(dto);
        }

        [TestMethod]
        public void DeletelientTest()
        {

            rep.Delete(1);
        }
    }
}
