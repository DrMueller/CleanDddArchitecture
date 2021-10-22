using System.Reflection;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.TypeConfigurations.ConfigProvisioning
{
    public interface ITypeConfigAssemblyProvider
    {
        Assembly Provide();
    }
}