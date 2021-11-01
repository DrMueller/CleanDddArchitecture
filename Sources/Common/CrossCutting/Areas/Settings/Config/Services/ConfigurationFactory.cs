using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Config.Services
{
    public static class ConfigurationFactory
    {
        public static IConfiguration Create(Assembly assembly)
        {
            const string SettingsDir = @"C:\Users\mlm\Dropbox\Apps\CleanDddArchitecture";

            var builder = new ConfigurationBuilder()
                .SetBasePath(SettingsDir)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}