using AutoMapper;
using DenounceBeasts.Application.Dtos.Municipalities;
using DenounceBeasts.Application.Dtos.Sectors;
using DenounceBeasts.Domain.Entities;

namespace DenounceBeasts.Application.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Municipality, MunicipalityDto>().ReverseMap();
            //CreateMap<Municipality, MunicipalityDto>()
            //    .ForMember( p=> p.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            //    .ReverseMap();
            //CreateMap<MunicipalityDto, Municipality>();

            CreateMap<DenounceBeasts.Domain.Entities.Sector, SectorDto>().ReverseMap();
            //CreateMap<SectorDto, Sector>();
        }
    }
}
