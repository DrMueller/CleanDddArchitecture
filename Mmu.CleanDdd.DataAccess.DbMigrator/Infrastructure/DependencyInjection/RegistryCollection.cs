using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Config.Services.Implementation;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Models;

namespace Mmu.CleanDdd.DataAccess.DbMigrator.Infrastructure.DependencyInjection
{
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            var config = ConfigurationFactory.Create();
            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));

            this.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));
        }
    }
}