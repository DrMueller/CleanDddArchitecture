using System.Linq;
using JetBrains.Annotations;
using Lamar;
using Lamar.Scanning.Conventions;
using MediatR;
using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Services.Implementation;
using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Services;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts.Implementation;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories.Implementation;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks.Implementation;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Infrastructure.DependencyInjection
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
                    ExcludeAggregates(scanner);
                    scanner.WithDefaultConventions();
                });

            this.AddMediatR(typeof(RegistryCollection));
            // Mediator is also transient, needs to be the same
            For<IMediationService>().Use<MediationService>().Transient();
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>().Singleton();
            For<IAppDbContextFactory>().Use<AppDbContextFactory>().Singleton();
        }

        private static void ExcludeAggregates(IAssemblyScanner scanner)
        {
            var agType = typeof(IAggregateRoot);

            var agTypes = typeof(RegistryCollection)
                .Assembly.GetTypes().Where(f => agType.IsAssignableFrom(f) && !f.IsAbstract)
                .ToList();

            agTypes.ForEach(ag => scanner.Exclude(f => f == ag));
        }
    }
}