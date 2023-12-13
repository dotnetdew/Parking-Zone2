
using Parking_Zone.Data;
using Parking_Zone.Repositories;

namespace Parking_Zone.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly ApplicationDbContext _context;
        public Service(IRepository<T> repository, ApplicationDbContext context)
        {
            this._repository = repository;
            this._context = context;
        }
        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _context.SaveChanges();
        }
    }
}
