using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDdd.WebApi;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.WebApp
{
    public class QualityTestStartup : Startup
    {
        protected override void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = TestAuthenticationHandler.TestSchemeName;
                    options.DefaultChallengeScheme = TestAuthenticationHandler.TestSchemeName;
                }).AddTestAuth(
                o =>
                {
                });
        }
    }
}