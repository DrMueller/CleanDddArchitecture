using JetBrains.Annotations;
using Lamar;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.Querying;
using Mmu.CleanDdd.Shared.Domain.Areas.Services.UnitOfWorks;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.Querying.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Servants;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.UnitOfWorks.Servants.Implementation;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Infrastructure.DependencyInjection
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
                    scanner.WithDefaultConventions();
                });

            For<IRepositoryCache>().Use<RepositoryCache>().Transient();
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>().Singleton();
            For<IQueryService>().Use<QueryService>().Singleton();
            For<IUnitOfWork>().Use<UnitOfWork>().Transient();
        }
    }
}