using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.Repositories.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}