
using Parking_Zone.Data;
using Parking_Zone.Repositories;

namespace Parking_Zone.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _repository.Save();
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
            _repository.Save();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
    }
}
