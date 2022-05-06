using Microsoft.EntityFrameworkCore;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts.Implementation
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : class
        {
            var set = Set<TEntity>();

            return new DbSetProxy<TEntity>(set);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}