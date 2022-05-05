using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.WebApp;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.Tests
{
    [Collection(WebAppTestCollectionFixture.CollectionName)]
    public abstract class WebAppTestBase
    {
        private readonly WebAppTestFixture _fixture;

        protected WebAppTestBase(WebAppTestFixture fixture)
        {
            _fixture = fixture;
        }

        protected QualityTestAppFactory AppFactory => _fixture.AppFactory;
    }
}
