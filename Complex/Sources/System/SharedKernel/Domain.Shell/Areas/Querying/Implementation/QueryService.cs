using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Querying;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Specifications;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Factories;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.Querying.Implementation
{
    public class QueryService : IQueryService
    {
        private readonly IAppDbContext _appDbContext;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContext = appDbContextFactory.Create();
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<TAg, TResult>(ISpecification<TAg, TResult> spec) where TAg : AggregateRoot
        {
            var dbSet = _appDbContext.Set<TAg>().AsNoTracking();

            var query = spec.Apply(dbSet);

            var selectSet = query.Select(spec.Selector);
            var result = await selectSet.ToListAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<TAg>> QueryAsync<TAg>(ISpecification<TAg> spec) where TAg : AggregateRoot
        {
            var dbSet = _appDbContext.Set<TAg>().AsNoTracking();
            var query = spec.Apply(dbSet);

            var result = await query.ToListAsync();

            return result;
        }
    }
}