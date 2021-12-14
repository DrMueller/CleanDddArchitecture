using Lamar;
using MediatR.Pipeline;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services.Servants;

namespace Mmu.CleanDdd.SharedKernel.Application.Infrastructure.DependencyInjection
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

            For(typeof(IRequestPreProcessor<>)).Use(typeof(LogOperationPreRequestHandler<>)).Singleton();
        }
    }
}