using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class QualityTestsCollectionFixture : ICollectionFixture<QualityTestFixture>
    {
        public const string CollectionName = "QualityTests";
    }
}