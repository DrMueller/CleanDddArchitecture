using Xunit;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class DatabaseCollectionFixture : ICollectionFixture<DatabaseTestFixture>
    {
        public const string CollectionName = "Database";
    }
}