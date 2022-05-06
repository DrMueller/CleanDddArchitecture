using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts
{
    public interface IDbSetProxy<TEntity>
        where TEntity : class
    {
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        IQueryable<TEntity> AsNoTracking();

        IQueryable<TEntity> AsQueryable();

        void Remove(TEntity entity);
    }
}