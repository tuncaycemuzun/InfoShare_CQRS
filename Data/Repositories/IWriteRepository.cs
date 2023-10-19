using System.Linq.Expressions;

namespace InfoShare_CQRS.Data.Repositories
{
    public interface IWriteRepository<T> where T : class
    {
        
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
