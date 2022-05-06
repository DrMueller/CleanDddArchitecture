using System.IO;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.WebApp.AppFactories
{
    public abstract class TestAppFactoryBase<T> : WebApplicationFactory<T>
        where T : Startup
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseContentRoot(Directory.GetCurrentDirectory());

            return base.CreateHost(builder);
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .UseLamar()
                .ConfigureWebHostDefaults(
                    x =>
                    {
                        x.UseStartup<T>().UseTestServer();
                    });

            return builder;
        }
    }
}