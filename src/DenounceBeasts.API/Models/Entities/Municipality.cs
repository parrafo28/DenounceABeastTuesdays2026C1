namespace DenounceBeasts.API.Models
{
    public class Municipality
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public bool IsActive { get; set; }

        public List<Sector> Sectors { get; set; }
    }
}
