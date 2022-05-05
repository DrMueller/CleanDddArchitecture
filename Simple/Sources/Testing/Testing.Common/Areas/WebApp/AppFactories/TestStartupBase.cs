using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.Testing.Common.Areas.WebApp.AppFactories.Handler;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.WebApp.AppFactories
{
    [PublicAPI]
    public abstract class TestStartupBase : Startup
    {
        protected override void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = TestAuthenticationHandler.TestSchemeName;
                    options.DefaultChallengeScheme = TestAuthenticationHandler.TestSchemeName;
                }).AddTestAuth(
                _ =>
                {
                });
        }
    }
}