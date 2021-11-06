using System.Collections.Generic;
using System.Reflection;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests
{
    public class AssemblyTestFixture
    {
        public IReadOnlyCollection<Assembly> Assemblies { get; }

        public AssemblyTestFixture()
        {
            Assemblies = AssemblyFetcher.FetchAll();
        }
    }
}
