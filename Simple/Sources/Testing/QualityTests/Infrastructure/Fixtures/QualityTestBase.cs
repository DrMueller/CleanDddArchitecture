using Mmu.CleanDddSimple.QualityTests.Infrastructure.Startups;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures
{
    [Collection(QualityTestsCollectionFixture.CollectionName)]
    public abstract class QualityTestBase
    {
        private readonly QualityTestFixture _fixture;

        protected QualityTestBase(QualityTestFixture fixture)
        {
            _fixture = fixture;
        }

        protected QualityTestAppFactory AppFactory => _fixture.AppFactory;
    }
}