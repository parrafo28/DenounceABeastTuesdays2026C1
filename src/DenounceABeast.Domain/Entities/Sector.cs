using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.Domain.Entities
{
    public class Sector
    {
        [Key] 
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(20)]
        public string? PostalCode { get; set; }
        public bool IsActive { get; set; }
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set;  }  
    }
}
