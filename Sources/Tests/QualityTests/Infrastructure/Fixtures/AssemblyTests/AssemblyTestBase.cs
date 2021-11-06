using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests
{
    [Collection(AssemblyTestCollectionFixture.CollectionName)]
    public abstract class AssemblyTestBase
    {
        protected AssemblyTestFixture Fixture { get; }

        protected AssemblyTestBase(AssemblyTestFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
