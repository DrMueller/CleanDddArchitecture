using Xunit;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests
{
    [Collection(AssemblyTestCollectionFixture.CollectionName)]
    public abstract class AssemblyTestBase
    {
        protected AssemblyTestBase(AssemblyTestFixture fixture)
        {
            Fixture = fixture;
        }

        protected AssemblyTestFixture Fixture { get; }
    }
}