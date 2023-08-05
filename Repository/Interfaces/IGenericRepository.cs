
using System.Linq.Expressions;

namespace MiddleLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(object id);

        void add(T entity);

        void addRange(IEnumerable<T> entities);

        void update(T entity);

        void delete(T entity);

        void Save();
    }
}
