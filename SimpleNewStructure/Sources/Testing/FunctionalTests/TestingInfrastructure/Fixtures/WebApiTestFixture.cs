using JetBrains.Annotations;
using Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.Startups;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.Fixtures
{
    [UsedImplicitly]
    public class WebApiTestFixture
    {
        // We start the inmemory web app once for all tests
        public WebApiTestFixture()
        {
            AppFactory = new FunctionalTestAppFactory();
        }

        internal FunctionalTestAppFactory AppFactory { get; }
    }
}