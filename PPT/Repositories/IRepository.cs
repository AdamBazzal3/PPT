using Microsoft.EntityFrameworkCore;
using PPT.Models;
using System.Linq.Expressions;

namespace PPT.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        Task<T> GetByGuidAsync(Guid id);
        Task<T> GetByLongAsync(long id);
        Task<T> GetByIntAsync(int id);

        void InsertAsync(T instance);
        Task<int> InsertAllAsync(List<T> instances);
        void DeleteAsync(int id);
        void UpdateAsync(T instance);
        void Update(T instance);

        void DeleteEntitiesWithCondition(Expression<Func<T, bool>> condition);
        void InsertRange(List<T> list);
        void DeleteRange(Expression<Func<T, bool>> condition);
        T GetEntityWithCondition(Expression<Func<T, bool>> condition);
        void UpdateRange(List<T> list);
        List<T> GetEntitiesWithCondition(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);        
        void SaveAsync();
        Task<List<Attendance>> GetAttendanceByDateAsync(int id, DateTime date);
        Department GetDepartment(User secretary);
         List<Attendance> GetAttendanceByDateForDepartment(int id, DateTime date);
        List<T> GetEntitiesWithCondition(Expression<Func<T, bool>> condition);
    }
}
