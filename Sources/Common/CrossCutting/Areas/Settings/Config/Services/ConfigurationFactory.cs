using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Config.Services
{
    public static class ConfigurationFactory
    {
        public static IConfiguration Create(Assembly assembly)
        {
            var runDir = Path.GetDirectoryName(assembly.Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(runDir)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}