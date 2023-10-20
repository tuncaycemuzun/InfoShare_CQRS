using InfoShare_CQRS.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfoShare_CQRS.Data.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
    {
        protected readonly WriteDbContext _writeDbContext;

        public WriteRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _writeDbContext.Set<T>().AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _writeDbContext.Set<T>().Remove(entity);
            await _writeDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _writeDbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _writeDbContext.Set<T>().Update(entity);
            await _writeDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
