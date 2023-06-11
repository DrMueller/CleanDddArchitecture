using System;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Models
{
    internal class NugetPackageReference : IEquatable<NugetPackageReference>
    {
        public NugetPackageReference(
            string packageName)
        {
            PackageName = packageName;
        }

        public string PackageName { get; }

        public bool Equals(NugetPackageReference? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return PackageName == other.PackageName;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((NugetPackageReference)obj);
        }

        public override int GetHashCode()
        {
            return PackageName.GetHashCode();
        }
    }
}