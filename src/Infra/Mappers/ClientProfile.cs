namespace Infra.Mappers
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    class ClientProfile : Profile
    {

        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>()
            .ForMember(dest => dest.codigo, map => map.MapFrom(source => source.codigo))
             .ForMember(dest => dest.nome, map => map.MapFrom(source => source.nome))
             .ForMember(dest => dest.tipo, map => map.MapFrom(source => source.tipo))
             .ForMember(dest => dest.telefone, map => map.MapFrom(source => source.telefone))
             .ForMember(dest => dest.CPF, map => map.MapFrom(source => source.CPF))
             .ForMember(dest => dest.CNPJ, map => map.MapFrom(source => source.CNPJ))
            .ReverseMap();
        }

    }
}
