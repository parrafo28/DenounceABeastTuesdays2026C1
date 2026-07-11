using System.ComponentModel.DataAnnotations;

namespace DenounceBeasts.Application.Dtos.Municipalities
{
    public class MunicipalityDto
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(20)]
        public string? PostalCode { get; set; }

    }
}
