namespace Parking_Zone.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Delete(Guid id);
        void Update(T entity);
        void Create(T entity);
    }
}
