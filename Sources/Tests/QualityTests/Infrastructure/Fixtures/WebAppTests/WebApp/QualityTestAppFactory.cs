using System.IO;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.WebApp
{
    public class QualityTestAppFactory : WebApplicationFactory<QualityTestStartup>
    {
        public string ContentRootPath { get; private set; }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            ContentRootPath = Directory.GetCurrentDirectory();
            builder.UseContentRoot(ContentRootPath);

            return base.CreateHost(builder);
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .UseLamar()
                .ConfigureWebHostDefaults(
                    x =>
                    {
                        x.UseStartup<QualityTestStartup>().UseTestServer();
                    });

            return builder;
        }
    }
}