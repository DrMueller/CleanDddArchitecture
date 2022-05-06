using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts.Implementation
{
    public class DbSetProxy<TEntity> : IDbSetProxy<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public DbSetProxy(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return await _dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}