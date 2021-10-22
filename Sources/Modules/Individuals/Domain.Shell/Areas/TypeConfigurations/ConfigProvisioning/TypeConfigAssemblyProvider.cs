using System.Reflection;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.ConfigProvisioning;

namespace Mmu.CleanDdd.Individuals.Domain.Shell.Areas.TypeConfigurations.ConfigProvisioning
{
    public class TypeConfigAssemblyProvider : ITypeConfigAssemblyProvider
    {
        public Assembly Provide()
        {
            return typeof(TypeConfigAssemblyProvider).Assembly;
        }
    }
}