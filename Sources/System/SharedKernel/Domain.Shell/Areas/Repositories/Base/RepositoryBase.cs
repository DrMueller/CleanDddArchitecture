using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Repositories;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.Repositories.Base
{
    public abstract class RepositoryBase<TAg> : IRepositoryBase, IRepository<TAg>
        where TAg : AggregateRoot
    {
        private DbSet<TAg> DbSet { get; set; }
        private IQueryable<TAg> Query => InitializeIncludes(DbSet);

        public async Task DeleteAsync(long id)
        {
            var loadedEntity = await Query.SingleOrDefaultAsync(f => f.Id == id);

            if (loadedEntity == null)
            {
                return;
            }

            DbSet.Remove(loadedEntity);
        }

        public async Task<TAg> LoadAsync(long id)
        {
            return await DbSet.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpsertAsync(TAg entity)
        {
            if (entity.Id.Equals(default))
            {
                await DbSet.AddAsync(entity);
            }
            else
            {
                DbSet.Update(entity);
            }
        }

        protected abstract IQueryable<TAg> InitializeIncludes(IQueryable<TAg> query);

        void IRepositoryBase.Initialize(IAppDbContext dbContext)
        {
            DbSet = dbContext.Set<TAg>();
        }
    }
}