using Xunit;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class WebApiCollectionFixture : ICollectionFixture<WebApiTestFixture>
    {
        public const string CollectionName = "WebApi";
    }
}