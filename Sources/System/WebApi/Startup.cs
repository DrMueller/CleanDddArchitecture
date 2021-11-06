using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Config.Services;
using Mmu.CleanDdd.WebApi.Infrastructure.Initialization;

namespace Mmu.CleanDdd.WebApi
{
    public class Startup
    {
        public Startup()
        {
            Configuration = ConfigurationFactory.Create(typeof(Startup).Assembly);
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            AppInitialization.InitializeApplication(app);
        }

        protected virtual void ConfigureAuthentication(IServiceCollection services)
        {
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            ServiceInitialization.InitializeServices(services, Configuration);
        }
    }
}