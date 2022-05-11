using Lamar;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.DbContexts.Factories;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DependencyInjection
{
    // These methods are called by the test-type assemblies as they can define, if they want to have some specific components mocked or not
    public static class StubServiceRegistry
    {
        public static void RegisterInMemoryDataAccess(ServiceRegistry serviceRegistry)
        {
            serviceRegistry.For<IAppDbContextFactory>().Use<InMemoryAppDbContextFactory>().Singleton();
        }
    }
}