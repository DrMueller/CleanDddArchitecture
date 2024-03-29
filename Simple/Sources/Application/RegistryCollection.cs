﻿using System.Linq;
using JetBrains.Annotations;
using Lamar;
using Lamar.Scanning.Conventions;
using MediatR;
using Mmu.CleanDddSimple.Application.Mediation.Services.Implementation;
using Mmu.CleanDddSimple.Application.Mediation.Services;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts.Implementation;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories.Implementation;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Implementation;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple
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