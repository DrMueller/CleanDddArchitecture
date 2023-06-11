using Lamar;
using MediatR;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services.Implementation;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services;

namespace Mmu.CleanDdd.Meetings.Application.Infrastructure.DependencyInjection
{
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

            this.AddMediatR(typeof(RegistryCollection));
            // Mediator is also transient, needs to be the same
            For<IMediationService>().Use<MediationService>().Transient();
        }
    }
}