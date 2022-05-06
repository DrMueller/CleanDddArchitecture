using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.DataAccess.Repositories.Implementation.Base
{
    public abstract class RepositoryBase<TIAg, TAg> : IRepositoryBase, IRepository<TIAg>
        where TIAg : IAggregateRoot
        where TAg : AggregateRoot, TIAg
    {
        protected IQueryable<TAg> Query => InitializeIncludes(DbSet.AsQueryable());
        private IDbSetProxy<TAg> DbSet { get; set; } = null!;

        public async Task DeleteAsync(long id)
        {
            var loadedEntity = await Query.SingleOrDefaultAsync(f => f.Id == id);

            if (loadedEntity is null)
            {
                return;
            }

            DbSet.Remove(loadedEntity);
        }

        public async Task InsertAsync(TIAg entity)
        {
            await DbSet.AddAsync((TAg)entity);
        }

        public async Task<IReadOnlyCollection<TIAg>> LoadCollectionAsync(IAggregateSpecification<TIAg> spec)
        {
            var list = await Query.Where(spec.Filter).ToListAsync();

            return list;
        }

        public async Task<Maybe<TIAg>> LoadSingleAsync(IAggregateSpecification<TIAg> spec)
        {
            var ag = await Query.SingleOrDefaultAsync(spec.Filter);

            return Maybe.CreateFromNullable(ag);
        }

        public async Task<Maybe<TIAg>> LoadSingleAsync(long id)
        {
            var ag = await Query.SingleOrDefaultAsync(f => f.Id == id);

            return Maybe.CreateFromNullable((TIAg)ag);
        }

        protected abstract IQueryable<TAg> InitializeIncludes(IQueryable<TAg> query);

#pragma warning disable SA1202 // Elements should be ordered by access
        void IRepositoryBase.Initialize(IAppDbContext dbContext)
#pragma warning restore SA1202 // Elements should be ordered by access
        {
            DbSet = dbContext.DbSet<TAg>();
        }
    }
}