using JetBrains.Annotations;
using Lamar;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Querying;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.Querying.Implementation;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.UnitOfWorks.Implementation;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.UnitOfWorks.Servants;
using Mmu.CleanDdd.SharedKernel.Domain.Shell.Areas.UnitOfWorks.Servants.Implementation;

namespace Mmu.CleanDdd.SharedKernel.Domain.Shell.Infrastructure.DependencyInjection
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