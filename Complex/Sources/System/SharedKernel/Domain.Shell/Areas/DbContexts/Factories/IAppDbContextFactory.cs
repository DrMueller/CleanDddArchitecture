using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Contexts;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}