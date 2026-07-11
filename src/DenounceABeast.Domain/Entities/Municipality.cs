using DenounceBeasts.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace DenounceBeasts.Domain.Entities
{
    public class Municipality : BaseEntity 
    { 

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string? PostalCode { get; set; }

        public bool IsActive { get; set; } 

        public List<Sector> Sectors { get; set; }
    }
}
