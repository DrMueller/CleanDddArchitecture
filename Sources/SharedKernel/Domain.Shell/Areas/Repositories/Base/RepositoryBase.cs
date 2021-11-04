using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Shared.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.Repositories;
using Mmu.CleanDdd.Shared.Domain.Areas.Specifications;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.Repositories.Base
{
    public abstract class RepositoryBase<TAg> : IRepositoryBase, IRepository<TAg>
        where TAg : AggregateRoot
    {
        private DbSet<TAg> DbSet { get; set; }
        private IQueryable<TAg> Query => InitializeIncludes(DbSet);

        protected abstract IQueryable<TAg> InitializeIncludes(IQueryable<TAg> query);

        public async Task DeleteAsync(long id)
        {
            var loadedEntity = await Query.SingleOrDefaultAsync(f => f.Id == id);

            if (loadedEntity == null)
            {
                return;
            }

            DbSet.Remove(loadedEntity);
        }

        public async Task<IReadOnlyCollection<TAg>> LoadAllAsync(ISpecification<TAg> spec)
        {
            var qry = spec.Apply(Query);

            return await qry.ToListAsync();
        }

        public async Task<TAg> LoadAsync(ISpecification<TAg> spec)
        {
            var qry = spec.Apply(Query);

            return await qry.SingleOrDefaultAsync();
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

        public async Task UpsertRangeAsync(IReadOnlyCollection<TAg> entities)
        {
            foreach (var entity in entities)
            {
                await UpsertAsync(entity);
            }
        }

        void IRepositoryBase.Initialize(IAppDbContext dbContext)
        {
           DbSet = dbContext.Set<TAg>();
        }
    }
}