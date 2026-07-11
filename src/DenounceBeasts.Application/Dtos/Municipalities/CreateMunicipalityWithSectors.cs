using DenounceBeasts.Application.Dtos.Sectors;

namespace DenounceBeasts.Application.Dtos.Municipalities
{
    public class CreateMunicipalityWithSectors
    {
        public MunicipalityDto Municipality { get; set; }
        public List<SectorDto> Sectors { get; set; } = new List<SectorDto>();
    }
}
