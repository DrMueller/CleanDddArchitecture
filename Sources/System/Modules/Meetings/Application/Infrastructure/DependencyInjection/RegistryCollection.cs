using Lamar;
using MediatR;

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
        }
    }
}