using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Persistence;

namespace DenounceBeasts.Infrastructure.Repositories
{
    public class SectorRepository
    {
        private readonly DenounceBeastsContext _context;

        public SectorRepository(DenounceBeastsContext context)
        {
            this._context = context;
        }

        public Sector GetSectorById(int id)
        {
            return _context.Sectors.Find(id);
        }

        public Sector GetSectorByName(string name)
        {
            return _context.Sectors.FirstOrDefault(m => m.Name.ToLower().Contains(name.ToLower()));
        }

        public List<Sector> GetAllSectors()
        {
            return _context.Sectors.ToList();
        }

        public void AddSector(Sector sector)
        {
            _context.Sectors.Add(sector);
            //_context.SaveChanges();
        }

        public void UpdateSector(Sector sector)
        {
            _context.Sectors.Update(sector);
            //_context.SaveChanges();
        }

        public void DeleteSector(int id)
        {
            var sector = _context.Sectors.Find(id);
            if (sector != null)
            {
                _context.Sectors.Remove(sector);
                //_context.SaveChanges();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
