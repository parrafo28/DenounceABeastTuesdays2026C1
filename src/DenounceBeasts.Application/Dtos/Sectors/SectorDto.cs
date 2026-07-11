namespace DenounceBeasts.Application.Dtos.Sectors
{
    public class SectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public int MunicipalityId { get; set; }
    }
}
