using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks.Servants
{
    public interface IRepositoryCache
    {
        TRepo GetRepository<TRepo>(IAppDbContext dbContext)
            where TRepo : IRepository;
    }
}