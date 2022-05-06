using Lamar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Config.Services;
using Mmu.CleanDddSimple.Web.Infrastructure.Initialization;
using Mmu.CleanDddSimple.Web.Infrastructure.Security;

namespace Mmu.CleanDddSimple
{
    public class Startup
    {
        public Startup()
        {
            Configuration = ConfigurationFactory.Create();
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            AppInitialization.InitializeApplication(app);
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            ConfigureAuthentication(services);
            ServiceInitialization.InitializeServices(services, Configuration);
        }

        // We do this here in order to let test-web apis overwrite the securit
        protected virtual void ConfigureAuthentication(IServiceCollection services)
        {
            services
                .AddAuthentication(BasicAuthenticationHandler.SchemeName)
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthenticationHandler.SchemeName, null);
        }
    }
}