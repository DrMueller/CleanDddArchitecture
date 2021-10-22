using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Shared.Domain.DomainModels;
using Mmu.CleanDdd.Shared.Domain.DomainServices.Repositories;
using Mmu.CleanDdd.Shared.Domain.DomainServices.UnitOfWorks;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Servants;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Implementation
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache _repoCache;
        private IAppDbContext _dbContext;

        public UnitOfWork(IRepositoryCache repoCache)
        {
            _repoCache = repoCache;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public TRepo GetRepository<TRepo>() where TRepo : IRepository
        {
            var repoType = typeof(TRepo);

            return _repoCache.GetRepository<TRepo>(repoType, _dbContext);
        }

        public void Initialize(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            SetTechnicalFields();
            await _dbContext.SaveChangesAsync();
        }

        private void SetTechnicalFields()
        {
            var entries = _dbContext.ChangeTrackerr
                .Entries()
                .Where(
                    e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((Entity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
        }
    }
}