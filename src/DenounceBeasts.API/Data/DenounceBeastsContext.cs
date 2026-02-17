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
        public DbSet<Entities.Status> Status { get; set; }
        public DbSet<Entities.ComplaintType> ComplaintTypes { get; set; }
    }
}
