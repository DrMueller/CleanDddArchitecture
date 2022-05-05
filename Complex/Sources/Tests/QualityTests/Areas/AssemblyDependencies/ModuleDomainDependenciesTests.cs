using System.Linq;
using Mmu.CleanDdd.QualityTests.Infrastructure;
using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Areas.AssemblyDependencies
{
    public class ModuleDomainDependenciesTests : AssemblyTestBase
    {
        public ModuleDomainDependenciesTests(AssemblyTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void ModuleDomains_OnlyReference_SharedKernelAndCrossCutting()
        {
            var moduleDomainAssemblies = Fixture.Assemblies.Where(
                f => f.FullName.Contains(".Domain")
                    && !f.FullName.Contains(".SharedKernel")
                    && !f.FullName.Contains("Shell"));

            foreach (var assembly in moduleDomainAssemblies)
            {
                AssemblyReferenceAsserter.AssertAssemblyContainsExactReferences(
                    assembly,
                    Fixture.Assemblies,
                    Constants.Namespaces.CrossCutting,
                    Constants.Namespaces.SharedKernel.Domain);
            }
        }
    }
}