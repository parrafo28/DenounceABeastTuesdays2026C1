using AutoMapper;
using DenounceBeasts.API.Data.Entities;

namespace DenounceBeasts.API.Models
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

            CreateMap<Sector, SectorDto>().ReverseMap();
            //CreateMap<SectorDto, Sector>();
        }
    }
}
