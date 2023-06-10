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
        void DeleteAsync(int id);
        Department GetDepartment(User secretary);
        void UpdateAsync(T instance);
        void DeleteEntitiesWithCondition(Expression<Func<T, bool>> condition);
        List<T> GetEntitiesWithCondition(Expression<Func<T, bool>> condition);
        void SaveAsync();
    }
}
