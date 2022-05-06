using JetBrains.Annotations;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Settings.Provisioning.Services;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.DependencyInjection
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
                    scanner.WithDefaultConventions(ServiceLifetime.Singleton);
                });

            For<IAppSettingsProvider>().Use<DbAppSettingsProvider>().Singleton();
        }
    }
}