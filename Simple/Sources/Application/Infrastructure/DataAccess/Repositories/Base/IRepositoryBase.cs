using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}