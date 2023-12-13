
using Microsoft.EntityFrameworkCore;
using Parking_Zone.Data;

namespace Parking_Zone.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(Guid id)
        {
            return entities.Find(id);
        }
        public void Insert(T entity)
        {
            if(entity == null) { throw new ArgumentNullException(nameof(entity)); }

            entities.Add(entity);

            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }
            entities.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if(entity == null) { throw new ArgumentNullException(nameof(entity)); }
            entities.Update(entity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            T existing = entities.Find(id);

            if(existing != null) { entities.Remove(existing); }

            else throw new ArgumentNullException($"{nameof(existing)} is null");

            _context.SaveChanges();
        }
    }
}
