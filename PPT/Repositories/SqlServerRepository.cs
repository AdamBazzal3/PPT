﻿using Microsoft.EntityFrameworkCore;
using PPT.Data;

namespace PPT.Repositories
{
    public class SqlServerRepository<T> : IDisposable, IRepository<T> where T : class
    {
        private PPTDatacontext? _context;
        private DbSet<T> table;

        public DbSet<T> Table { get; }

        public SqlServerRepository(PPTDatacontext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            List<T> list = table.ToList();
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
        public async void InsertAsync(T obj)
        {
            table.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async void DeleteAsync(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
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


        
    }
}
