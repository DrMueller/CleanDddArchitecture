using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Repositories;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DomainEvents.Services;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.UnitOfWorks.Servants;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.UnitOfWorks.Implementation
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache _repoCache;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private IAppDbContext _dbContext;

        public UnitOfWork(
            IRepositoryCache repoCache,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _repoCache = repoCache;
            _domainEventDispatcher = domainEventDispatcher;
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
            await _domainEventDispatcher.DispatchEventsAsync(_dbContext);
        }

        private void SetTechnicalFields()
        {
            var entries = _dbContext
                .ChangeTracker
                .Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is Entity entity)
                {
                    entity.UpdatedDate = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Added && entityEntry.Entity is IHasCreatedDate cd)
                {
                    cd.CreatedDate = DateTime.Now;
                }
            }
        }
    }
}