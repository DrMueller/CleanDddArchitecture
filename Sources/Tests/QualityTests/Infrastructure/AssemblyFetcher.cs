using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mmu.CleanDdd.Dependencies;
using Mmu.CleanDdd.WebApi;

namespace Mmu.CleanDdd.QualityTests.Infrastructure
{
    public static class AssemblyFetcher
    {
        public static IReadOnlyCollection<Assembly> FetchAll()
        {
            var sourceAssemblies = new List<Assembly>
            {
                typeof(Startup).Assembly,
                typeof(DependencyCollector).Assembly
            };

            var allAssemblies = new List<Assembly>();
            foreach(var sa in sourceAssemblies)
            {
                CollectAssemblies(sa, allAssemblies);
            }

            return allAssemblies;
        }

        private static void CollectAssemblies(Assembly currentAssembly, ICollection<Assembly> assemblies)
        {
            var relevantAssemblies =
                currentAssembly
                    .GetReferencedAssemblies()
                    .Where(f => f.Name.StartsWith(Constants.Namespaces.Prefix, StringComparison.Ordinal));

            foreach (var assemblyName in relevantAssemblies)
            {
                var loadedAssembly = Assembly.Load(assemblyName);
                if (!assemblies.Contains(loadedAssembly))
                {
                    assemblies.Add(loadedAssembly);
                }

                CollectAssemblies(loadedAssembly, assemblies);
            }
        }
    }
}
