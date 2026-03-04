using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Persistence;

namespace DenounceBeasts.Infrastructure.Repositories
{
    public class UnitOfWork
    {
        private readonly DenounceBeastsContext _context;
        private readonly MunicipalityRepository _municipalityRepository;
        private readonly SectorRepository _sectorRepository;
        private readonly GenericRepository<Status> _statusRepository;

        public UnitOfWork(DenounceBeastsContext context,
            MunicipalityRepository municipalityRepository,
            SectorRepository sectorRepository,
            GenericRepository<Status> statusRepository)
        {
            _context = context;
            _municipalityRepository = municipalityRepository;
            _sectorRepository = sectorRepository;
            this._statusRepository = statusRepository;
        }

        public MunicipalityRepository MunicipalityRepository => _municipalityRepository;
        public SectorRepository SectorRepository => _sectorRepository;
        public GenericRepository<Status> StatusRepository => _statusRepository;

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
