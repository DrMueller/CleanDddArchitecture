using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.Repositories.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}