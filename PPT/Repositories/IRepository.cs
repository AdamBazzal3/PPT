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
        void DeleteRange(Expression<Func<T, bool>> condition);
        T GetEntityWithCondition(Expression<Func<T, bool>> condition);
        void UpdateAsync(T instance);
        List<T> GetEntitiesWithCondition<EInclude>(Expression<Func<T, bool>> condition, Expression<Func<T, EInclude>> include);        
        void SaveAsync();
    }
}
