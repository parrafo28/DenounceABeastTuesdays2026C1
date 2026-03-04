namespace DenounceBeasts.API.Models.Dtos
{
    public class CreateMunicipalityWithSectors
    {
        public MunicipalityDto Municipality { get; set; }
        public List<SectorDto> Sectors { get; set; } = new List<SectorDto>();
    }
}
