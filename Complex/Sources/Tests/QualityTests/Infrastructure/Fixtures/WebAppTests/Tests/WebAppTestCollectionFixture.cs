using Xunit;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.Tests
{
    [CollectionDefinition(CollectionName)]
    public class WebAppTestCollectionFixture : ICollectionFixture<WebAppTestFixture>
    {
        public const string CollectionName = "QualityWebAppTests";
    }
}