using System.Linq.Expressions;

namespace InfoShare_CQRS.Data.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
