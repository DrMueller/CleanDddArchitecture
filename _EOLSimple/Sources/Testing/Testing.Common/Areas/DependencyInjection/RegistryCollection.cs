using JetBrains.Annotations;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Logging;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.Testing.Common.Areas.Stubs;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DependencyInjection
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

            // There are the stubs we want to have registerred for all tests
            For<ILoggingService>().Use<LoggingServiceStub>();
            For<IAppSettingsProvider>().Use<AppSettingsProviderStub>();
        }
    }
}