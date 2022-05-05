using Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanDdd.Individuals.Application.Shell.Infrastructure.DependencyInjection;

namespace Mmu.CleanDdd.Dependencies
{
    public static class DependencyCollector
    {
        public static void Initialize()
        {
            var _ = typeof(AppDbContext);

            _ = typeof(RegistryCollection);

            _ = typeof(Individuals.Domain.Shell.Infrastructure.DependencyInjection.RegistryCollection);

            _ = typeof(Meetings.Application.Shell.Infrastructure.DependencyInjection.RegistryCollection);

            _ = typeof(Meetings.Domain.Shell.Infrastructure.DependencyInjection.RegistryCollection);
        }
    }
}