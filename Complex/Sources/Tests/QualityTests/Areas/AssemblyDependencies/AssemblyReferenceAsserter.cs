using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;

namespace Mmu.CleanDdd.QualityTests.Areas.AssemblyDependencies
{
    internal static class AssemblyReferenceAsserter
    {
        internal static void AssertAssemblyContainsExactReferences(
            Assembly source,
            IReadOnlyCollection<Assembly> allAssemblies,
            params string[] targetNamespaces)
        {
            var refAssemblyNames = source
                .GetReferencedAssemblies()
                .Select(f => f.Name)
                .ToList();

            foreach (var ns in targetNamespaces)
            {
                refAssemblyNames.Should().Contain(ns);
            }

            var oherAssemblyNames = allAssemblies.Except(new List<Assembly> { source })
                .Select(f => f.GetName())
                .Where(f => !targetNamespaces.Contains(f.Name))
                .Select(f => f.Name)
                .ToList();

            foreach (var otherAssemblyName in oherAssemblyNames)
            {
                refAssemblyNames.Should().NotContain(otherAssemblyName);
            }
        }

        internal static void AssertAssemblyContainsReferences(
            Assembly source, params string[] targetNamespaces)
        {
            var refAssemblyNames = source.GetReferencedAssemblies().Select(f => f.Name).ToList();

            foreach (var ns in targetNamespaces)
            {
                refAssemblyNames.Should().Contain(ns);
            }
        }

        internal static void AssertAssemblyDoesNotContainsReferences(
            Assembly source, params string[] targetNamespaces)
        {
            var refAssemblyNames = source.GetReferencedAssemblies().Select(f => f.Name).ToList();

            foreach (var ns in targetNamespaces)
            {
                refAssemblyNames.Should().NotContain(ns);
            }
        }
    }
}