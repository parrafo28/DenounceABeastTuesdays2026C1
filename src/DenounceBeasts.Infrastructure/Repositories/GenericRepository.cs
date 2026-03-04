using DenounceBeasts.Persistence;

namespace DenounceBeasts.Infrastructure.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private readonly DenounceBeastsContext _context;

        public GenericRepository(DenounceBeastsContext context)
        {
            this._context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            //_context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                //_context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
