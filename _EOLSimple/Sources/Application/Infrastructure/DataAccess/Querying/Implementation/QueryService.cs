﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.Querying.Implementation
{
    [UsedImplicitly]
    public class QueryService : IQueryService
    {
        private readonly IAppDbContext _appDbContext;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContext = appDbContextFactory.Create();
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<T, TResult>(IQuerySpecification<T, TResult> spec)
            where T : Entity
        {
            var dbSet = _appDbContext.DbSet<T>().AsNoTracking();

            var query = spec.Apply(dbSet);

            var selectSet = query.Select(spec.Selector);
            var result = await selectSet.ToListAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<T>> QueryAsync<T>(IQuerySpecification<T> spec)
            where T : Entity
        {
            var dbSet = _appDbContext.DbSet<T>().AsNoTracking();
            var query = spec.Apply(dbSet);

            var result = await query.ToListAsync();

            return result;
        }
    }
}