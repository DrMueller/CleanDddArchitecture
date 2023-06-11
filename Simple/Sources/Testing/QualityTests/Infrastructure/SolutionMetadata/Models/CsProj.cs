using System.Collections.Generic;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Models
{
   internal class CsProj
    {
        public string AssemblyName { get; }
        public IReadOnlyCollection<NugetPackageReference> NugetReferences { get; }
        public IReadOnlyCollection<ProjectReference> ProjectReferences { get; }

        public CsProj(
            string assemblyName,
            IReadOnlyCollection<NugetPackageReference> nugetReferences,
            IReadOnlyCollection<ProjectReference> projectReferences)
        {
            AssemblyName = assemblyName;
            NugetReferences = nugetReferences;
            ProjectReferences = projectReferences;
        }
    }
}
