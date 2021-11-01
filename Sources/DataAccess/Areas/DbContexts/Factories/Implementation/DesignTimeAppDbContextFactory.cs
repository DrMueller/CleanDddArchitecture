using Lamar;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Config.Services;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Models;
using Mmu.CleanDdd.DataAccess.Areas.DbContexts.Contexts.Implementation;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Factories;

namespace Mmu.CleanDdd.DataAccess.Areas.DbContexts.Factories.Implementation
{
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

                    var config = ConfigurationFactory.Create(typeof(DesignTimeAppDbContextFactory).Assembly);
                    cfg.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));
                });
        }
    }
}