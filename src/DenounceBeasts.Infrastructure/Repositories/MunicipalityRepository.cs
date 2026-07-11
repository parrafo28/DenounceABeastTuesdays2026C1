using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.Infrastructure.Repositories
{
    public class MunicipalityRepository: GenericRepository<Sector>
    {
        private readonly DenounceBeastsContext _context;

        public MunicipalityRepository(DenounceBeastsContext context):base(context)
        {
            this._context = context;
        }

        //public Municipality GetMunicipalityById(int id)
        //{
        //    return _context.Municipalities.Find(id);
        //}

        public Municipality GetMunicipalityByName(string name)
        {
            return _context.Municipalities.FirstOrDefault(m => m.Name.ToLower().Contains(name.ToLower()));
        }

        //public List<Municipality> GetAllMunicipalities()
        //{
        //    return _context.Municipalities.ToList();
        //}

        public List<Municipality> GetMunicipalitiesWithSectors()
        {
            return _context.Municipalities.Include(m => m.Sectors)
                   .Where(m => m.IsActive).ToList();
        }

        //public void AddMunicipality(Municipality municipality)
        //{
        //    _context.Municipalities.Add(municipality);
        //    _context.SaveChanges();
        //}

        //public void UpdateMunicipality(Municipality municipality)
        //{
        //    _context.Municipalities.Update(municipality);
        //    _context.SaveChanges();
        //}

        //public void DeleteMunicipality(int id)
        //{
        //    var municipality = _context.Municipalities.Find(id);
        //    if (municipality != null)
        //    {
        //        _context.Municipalities.Remove(municipality);
        //        _context.SaveChanges();
        //    }
        //}
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
