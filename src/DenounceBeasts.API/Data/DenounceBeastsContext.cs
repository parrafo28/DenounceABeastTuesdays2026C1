using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Data
{
    public class DenounceBeastsContext : DbContext
    {
        public DenounceBeastsContext(DbContextOptions<DenounceBeastsContext> options) : base(options)
        {
        }

        public DbSet<Entities.Municipality> Municipalities { get; set; }
        public DbSet<Entities.Sector> Sectors { get; set; }
    }
}
