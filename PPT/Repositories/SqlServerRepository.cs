using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using PPT.Data;
using PPT.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PPT.Repositories
{
    public class SqlServerRepository<T> : IRepository<T>  where T : class
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
        public List<T> GetEntitiesWithCondition(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.Where(condition).ToList();
        }
        public T GetEntityWithCondition(Expression<Func<T, bool>> condition)
        {
            return Table.FirstOrDefault(condition);
        }
        public Department GetDepartmentByHead(User head)
        {
            return _context.Departments.FirstOrDefault(d => d.HeadID == head.Id);
        }

        public async void InsertAsync(T obj)
        {
            Table.Add(obj);
            
            await Table.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<int> InsertAllAsync(List<T> list)
        {
            Table.AddRange(list);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<Attendance>> GetAttendanceByDateAsync(int id,DateTime date)
        {
            List<Attendance> list = await _context.Attendances.Where(m => m.ID == id && m.Date.Year == date.Year && m.Date.Month == date.Month).ToListAsync();
            return list;    
        }
        public List<Attendance> GetAttendanceByDateForDepartment(int id, DateTime date)
        {
            List<Attendance> list = _context.Attendances.Where(m => m.Doctor.DepartmentID == id && m.Date.Year == date.Year && m.Date.Month == date.Month).OrderBy(d=> d.DoctorID).ThenBy(d=>d.Date).Include(d=>d.Doctor).ToList();
            return list;
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

        public void DeleteRange(Expression<Func<T, bool>> condition)
        {
            var entitiesToDelete = Table.Where(condition).ToList();

            Table.RemoveRange(entitiesToDelete);

            _context.SaveChanges();
        }

        public void InsertRange(List<T> list)
        {
            Table.AddRange(list);

            _context.SaveChanges();
        }

        public void UpdateRange(List<T> list)
        {

            foreach (var record in list)
            {
                Table.Update(record);
            }

            _context.SaveChanges();
        }


        public void DeleteEntitiesWithCondition(Expression<Func<T, bool>> condition)
        {
            var entitiesToDelete = Table.Where(condition);
            Table.RemoveRange(entitiesToDelete);
            _context.SaveChanges();
        }
    }
}
