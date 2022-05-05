using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.WebApp;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.Tests
{
    public class WebAppTestFixture
    {
        public WebAppTestFixture()
        {
            AppFactory = new QualityTestAppFactory();
        }

        internal QualityTestAppFactory AppFactory { get; }
    }
}
