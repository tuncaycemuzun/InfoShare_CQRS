using InfoShare_CQRS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoShare_CQRS.Data.Contexts
{
    public class ReadDbContext : DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
                
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
