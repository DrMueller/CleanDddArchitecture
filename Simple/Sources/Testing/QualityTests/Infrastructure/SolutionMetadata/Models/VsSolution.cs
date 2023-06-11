using System.Collections.Generic;
using System.Linq;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Models
{
    internal class VsSolution
    {
        private static readonly IReadOnlyCollection<string> _namespacesToIgnore = new
            List<string>
            {
                "Analyzers",
                "CodeAnalysis",
                "Microsoft.NET.Test.Sdk"
            };

        public VsSolution(IReadOnlyCollection<CsProj> projects)
        {
            Projects = projects;
        }

        private IReadOnlyCollection<NugetPackageReference> DuplicatedNugetReferences
        {
            get
            {
                return Projects
                    .SelectMany(f => f.NugetReferences)
                    .Where(f => _namespacesToIgnore.All(ns => !f.PackageName.Contains(ns)))
                    .GroupBy(f => f)
                    .Where(f => f.Count() > 1)
                    .SelectMany(f => f)
                    .ToList();
            }
        }

        private IReadOnlyCollection<CsProj> Projects { get; }

        public IReadOnlyCollection<NugetPackageReference> CalculateDuplicatedNugets()
        {
            var actualDuplicates = new List<NugetPackageReference>();

            foreach (var dup in DuplicatedNugetReferences)
            {
                var projsWithDuplicate = Projects
                    .Where(f => f.NugetReferences.Contains(dup))
                    .ToList();

                foreach (var proj in projsWithDuplicate)
                {
                    var dependantProjects = new List<CsProj>();
                    GatherDependencies(proj, dependantProjects);

                    if (dependantProjects.Count(f => f.NugetReferences.Contains(dup)) > 1)
                    {
                        actualDuplicates.Add(dup);
                    }
                }
            }

            var distinctDuplicates = actualDuplicates
                .Distinct()
                .ToList();

            return distinctDuplicates;
        }

        private void GatherDependencies(CsProj proj, ICollection<CsProj> references)
        {
            if (!references.Contains(proj))
            {
                references.Add(proj);
            }

            foreach (var refProj in proj.ProjectReferences)
            {
                var childProj = Projects.Single(f => f.AssemblyName == refProj.AssemblyName);
                GatherDependencies(childProj, references);
            }
        }
    }
}