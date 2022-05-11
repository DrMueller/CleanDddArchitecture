using JetBrains.Annotations;
using Lamar;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Config.Services;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts.Implementation;

namespace Mmu.CleanDddSimple.DataAccess.DbContexts.Factories.Implementation
{
    [UsedImplicitly]
    public class DesignTimeAppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var container = CreateContainer();

            var appDbContextFactory = container.GetInstance<IAppDbContextFactory>();

            return (AppDbContext)appDbContextFactory.Create();
        }

        private static IContainer CreateContainer()
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

                    var config = ConfigurationFactory.Create();
                    cfg.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));
                });
        }
    }
}