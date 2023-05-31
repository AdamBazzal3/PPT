namespace PPT.Repositories
{
    public interface IRepository<T>: IDisposable
    {
        List<T> GetAll();
        Task<T> GetByGuidAsync(Guid id);
        Task<T> GetByLongAsync(long id);
        void InsertAsync(T instance);
        void DeleteAsync(int id);
        void UpdateAsync(T instance);
        void SaveAsync();
    }
}
