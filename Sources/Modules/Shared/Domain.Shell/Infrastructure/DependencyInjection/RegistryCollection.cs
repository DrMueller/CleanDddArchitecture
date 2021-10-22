using JetBrains.Annotations;
using Lamar;
using Mmu.CleanDdd.Shared.Domain.DomainServices.Querying;
using Mmu.CleanDdd.Shared.Domain.DomainServices.Repositories;
using Mmu.CleanDdd.Shared.Domain.DomainServices.UnitOfWorks;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.Querying.Services.Implementation;
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
                    scanner.AddAllTypesOf<IRepository>();
                    scanner.Exclude(type => type == typeof(AppDbContext));
                    scanner.WithDefaultConventions();
                });

            For<IRepositoryCache>().Use<RepositoryCache>().Transient();
            For<IAppDbContextFactory>().Use<AppDbContextFactory>().Singleton();
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>().Singleton();
            For<IQueryService>().Use<QueryService>().Singleton();
            For<IUnitOfWork>().Use<UnitOfWork>().Transient();
        }
    }
}