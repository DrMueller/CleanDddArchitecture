using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Servants;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Models.Base;
using Mmu.CleanDddSimple.Domain.Models.Base.Technical;

namespace Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Implementation
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache _repoCache;
        private IAppDbContext _dbContext = null!;

        public UnitOfWork(
            IRepositoryCache repoCache)
        {
            _repoCache = repoCache;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public TRepo GetRepository<TRepo>() where TRepo : IRepository
        {
            return _repoCache.GetRepository<TRepo>(_dbContext);
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
            var entries = _dbContext
                .ChangeTracker
                .Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is Entity entity)
                {
                    var casted = (IHasTimeStamps)entity;

                    casted.UpdatedDate = DateTime.Now;

                    if (entityEntry.State == EntityState.Added)
                    {
                        casted.CreatedDate = DateTime.Now;
                    }
                }
            }
        }
    }
}