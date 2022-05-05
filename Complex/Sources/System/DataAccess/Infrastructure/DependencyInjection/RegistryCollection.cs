using JetBrains.Annotations;
using Lamar;
using Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation;

namespace Mmu.CleanDdd.DataAccess.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    scanner.ExcludeType<AppDbContext>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}