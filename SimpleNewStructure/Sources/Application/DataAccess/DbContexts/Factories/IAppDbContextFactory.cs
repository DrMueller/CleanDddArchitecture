using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}