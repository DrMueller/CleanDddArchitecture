using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Mmu.Cca.WebApi.Infrastructure.Initialization;

namespace Mmu.CleanDdd.WebApi
{
    public class Startup
    {
        public Startup()
        {
            var runDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(runDir)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            AppInitialization.InitializeApplication(app);
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            ServiceInitialization.InitializeServices(services, Configuration);
        }
    }
}
