using System.Diagnostics;

namespace Mmu.CleanDdd.Dependencies
{
    public static class DependencyCollector
    {
        public static void Initialize()
        {
            var _ = typeof(Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation.AppDbContext);
            
            _ = typeof(Mmu.CleanDdd.Individuals.Application.Shell.Infrastructure.DependencyInjection.RegistryCollection);

            _ = typeof(Mmu.CleanDdd.Individuals.Domain.Shell.Infrastructure.DependencyInjection.RegistryCollection);

            _ = typeof(Mmu.CleanDdd.Meetings.Application.Shell.Infrastructure.DependencyInjection.RegistryCollection);

            _ = typeof(Mmu.CleanDdd.Meetings.Domain.Shell.Infrastructure.DependencyInjection.RegistryCollection);
        }
    }
}