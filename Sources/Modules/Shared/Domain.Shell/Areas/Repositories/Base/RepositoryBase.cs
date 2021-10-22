using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Shared.Domain.Models;
using Mmu.CleanDdd.Shared.Domain.Services.Repositories;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.Shared.Domain.Specifications;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.Repositories.Base
{
    public abstract class RepositoryBase<TAg> : IRepositoryBase, IRepository<TAg>
        where TAg : AggregateRoot
    {
        protected DbSet<TAg> DbSet { get; private set; }

        public async Task DeleteAsync(long id)
        {
            var loadedEntity = await DbSet.SingleOrDefaultAsync(f => f.Id == id);

            if (loadedEntity == null)
            {
                return;
            }

            DbSet.Remove(loadedEntity);
        }

        public Task DeleteAsync(ISpecification<TAg> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<TAg>> LoadAllAsync(ISpecification<TAg> spec)
        {
            var qry = spec.Apply(DbSet);

            return await qry.ToListAsync();
        }

        public async Task<TAg> LoadAsync(ISpecification<TAg> spec)
        {
            var qry = spec.Apply(DbSet);

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