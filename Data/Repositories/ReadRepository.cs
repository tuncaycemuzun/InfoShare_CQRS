using InfoShare_CQRS.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfoShare_CQRS.Data.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, new()
    { 

        protected readonly ReadDbContext _readContext;

        public ReadRepository(ReadDbContext readDbContext)
        {
            _readContext = readDbContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _readContext.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _readContext.Set<T>().CountAsync(predicate);
            else
                return await _readContext.Set<T>().CountAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _readContext.Set<T>().FirstOrDefaultAsync(predicate);
            else
                return await _readContext.Set<T>().FirstOrDefaultAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _readContext.Set<T>().Where(predicate).ToListAsync();
            else
                return await _readContext.Set<T>().ToListAsync();
        }
    }
}
