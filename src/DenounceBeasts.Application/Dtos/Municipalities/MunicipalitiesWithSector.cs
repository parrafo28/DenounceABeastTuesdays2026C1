using DenounceBeasts.Application.Dtos.Sectors;

namespace DenounceBeasts.Application.Dtos.Municipalities
{
    public class MunicipalitiesWithSector
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public List<SectorDto> Sectors { get; set; } = new();
    }
}
