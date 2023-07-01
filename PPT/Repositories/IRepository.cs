using PPT.Models;
using System.Linq.Expressions;

namespace PPT.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        Task<T> GetByGuidAsync(Guid id);
        Task<T> GetByLongAsync(long id);
        void InsertAsync(T instance);
        void InsertRange(List<T> list);
        void DeleteRange(Expression<Func<T, bool>> condition);
        T GetEntityWithCondition(Expression<Func<T, bool>> condition);
        void UpdateRange(List<T> list);
        List<T> GetEntitiesWithCondition(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);        
        void SaveAsync();
    }
}
