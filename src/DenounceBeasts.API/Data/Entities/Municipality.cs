using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.API.Data.Entities
{
    [Table("Municipality")]
    public class Municipality
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(20)]
        public string? PostalCode { get; set; }
        public bool IsActive { get; set; } 
        public List<Sector> Sectors { get; set; }
    }
}
