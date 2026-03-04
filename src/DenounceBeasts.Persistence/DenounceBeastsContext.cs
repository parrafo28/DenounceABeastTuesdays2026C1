
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Persistence.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.Persistence
{
    public class DenounceBeastsContext : DbContext
    {
        public DenounceBeastsContext(DbContextOptions<DenounceBeastsContext> options) : base(options)
        {
        }

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ComplaintType> ComplaintTypes { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

            // Configurações adicionais, se necessário
            //modelBuilder.Entity<Municipality>()
            //    .Property(m => m.Name)
            //    .IsRequired().HasMaxLength(100);
            modelBuilder.ApplyConfiguration<Status>(new StatusConfiguration());
        }
    }
}
