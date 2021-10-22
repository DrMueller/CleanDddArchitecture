using System;
using Mmu.CleanDdd.Shared.Domain.DomainServices.Repositories;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Servants
{
    public interface IRepositoryCache
    {
        TRepo GetRepository<TRepo>(Type repositoryType, IAppDbContext dbContext)
            where TRepo : IRepository;
    }
}