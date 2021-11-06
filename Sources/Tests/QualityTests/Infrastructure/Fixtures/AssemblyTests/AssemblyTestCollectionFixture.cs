using Xunit;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests
{
    [CollectionDefinition(CollectionName)]
    public class AssemblyTestCollectionFixture : ICollectionFixture<AssemblyTestFixture>
    {
        public const string CollectionName = "QualityAssemblyTests";
    }
}
