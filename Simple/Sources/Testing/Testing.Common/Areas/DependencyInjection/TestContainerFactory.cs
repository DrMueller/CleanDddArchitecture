using Lamar;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.DependencyInjection
{
    public static class TestContainerFactory
    {
        public static IContainer Create()
        {
            return new Container(
                cfg =>
                {
                    cfg.Scan(
                        scanner =>
                        {
                            scanner.AssembliesFromApplicationBaseDirectory();
                            scanner.LookForRegistries();
                        });
                });
        }
    }
}