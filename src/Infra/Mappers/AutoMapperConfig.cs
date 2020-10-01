using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infra.Mappers
{
    using AutoMapper;
    using Infra.Mappers;
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ClientProfile>();               
            });

        }

    }
}
