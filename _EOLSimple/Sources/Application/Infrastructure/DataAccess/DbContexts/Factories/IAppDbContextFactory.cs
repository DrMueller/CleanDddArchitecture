using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}