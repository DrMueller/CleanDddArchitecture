using Lamar;
using MediatR;
using Mmu.CleanDdd.Individuals.Application.Areas.Module;

namespace Mmu.CleanDdd.Individuals.Application.Infrastructure.DependencyInjection
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
        }
    }
}