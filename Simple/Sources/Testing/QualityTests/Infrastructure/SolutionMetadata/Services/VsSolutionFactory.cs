using System.IO;
using System.Linq;
using System.Xml.Linq;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Models;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Services
{
    internal static class VsSolutionFactory
    {
        internal static VsSolution Create()
        {
            var sourcesDir = GetSourcesDirectory();
            var projects = Directory
                .GetFiles(sourcesDir.FullName, "*.csproj", SearchOption.AllDirectories)
                .Select(CreateCsPrj)
                .ToList();

            return new VsSolution(projects);
        }

        private static CsProj CreateCsPrj(string filePath)
        {
            var xDoc = XDocument.Load(filePath);
            var packageReferences = xDoc.Descendants().Where(f => f.Name == "PackageReference")
                .Select(f => new NugetPackageReference(f.Attribute("Include")!.Value))
                .ToList();

            var projectReferences = xDoc.Descendants().Where(f => f.Name == "ProjectReference")
                .Select(f => new ProjectReference(f.Attribute("Include")!.Value))
                .ToList();

            return new CsProj(
                Path.GetFileName(filePath).Replace(".csproj", string.Empty),
                packageReferences,
                projectReferences);
        }

        private static DirectoryInfo GetSourcesDirectory()
        {
            var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (!currentDir!.FullName.EndsWith("Sources"))
            {
                currentDir = currentDir.Parent;
            }

            return currentDir;
        }
    }
}