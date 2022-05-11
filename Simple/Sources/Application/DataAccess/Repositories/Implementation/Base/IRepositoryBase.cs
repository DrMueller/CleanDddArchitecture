using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;

namespace Mmu.CleanDddSimple.DataAccess.Repositories.Implementation.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}