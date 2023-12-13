
namespace Parking_Zone.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public BaseService()
        {
            
        }
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
