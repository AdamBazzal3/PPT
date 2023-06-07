using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;
using System.Linq;
using System.Linq.Expressions;

namespace PPT.Repositories
{
    public class SqlServerRepository<T> : IDisposable,IRepository<T>  where T : class
    {
        private PPTDatacontext? _context;

        public DbSet<T> Table { get; }

        public SqlServerRepository(PPTDatacontext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            List<T> list = Table.ToList();
            return list;
        }
        public async Task<T> GetByGuidAsync(Guid id)
        {
            T result = await Table.FindAsync(id);
            return result;
        }
        public async Task<T> GetByLongAsync(long id)
        {
            T result = await Table.FindAsync(id);
            return result;
        }
        public List<T> GetEntitiesWithCondition(Expression<Func<T, bool>> condition)
        {
            return Table
                .Where(condition)
                .ToList();
        }
        public Department GetDepartment(User secretary)
        {
            return _context.Departments.FirstOrDefault(d => d.Secretary.Id == secretary.Id);
        }

        public async void InsertAsync(T obj)
        {
            Table.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(T obj)
        {
            Table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async void DeleteAsync(int id)
        {
            T existing = Table.Find(id);
            Table.Remove(existing);
            await _context.SaveChangesAsync();
        }
        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public  void DeleteEntitiesWithCondition(Expression<Func<T, bool>> condition)
        {
            var entitiesToDelete = Table.Where(condition).ToList();
            Table.RemoveRange(entitiesToDelete);
            _context.SaveChanges();
        }
    }
}
