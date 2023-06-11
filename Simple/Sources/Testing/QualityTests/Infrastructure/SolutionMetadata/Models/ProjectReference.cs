using System.IO;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Models
{
    internal class ProjectReference
    {
        public ProjectReference(string relativePath)
        {
            RelativePath = relativePath;
        }

        public string AssemblyName
        {
            get
            {
                var fileName = Path.GetFileName(RelativePath);

                return fileName.Replace(".csproj", string.Empty);
            }
        }

        private string RelativePath { get; }
    }
}