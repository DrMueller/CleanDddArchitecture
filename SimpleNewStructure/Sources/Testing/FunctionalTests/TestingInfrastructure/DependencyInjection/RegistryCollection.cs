using JetBrains.Annotations;
using Lamar;
using Mmu.CleanDddSimple.Testing.Common.Areas.DependencyInjection;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.DependencyInjection
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

            StubServiceRegistry.RegisterInMemoryDataAccess(this);
        }
    }
}