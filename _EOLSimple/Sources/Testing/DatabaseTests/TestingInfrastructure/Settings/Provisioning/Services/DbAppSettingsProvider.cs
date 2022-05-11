using Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Settings.Provisioning.Services
{
    public class DbAppSettingsProvider : IAppSettingsProvider
    {
        public DbAppSettingsProvider()
        {
            Settings = new AppSettings
            {
                ConnectionString = DockerConstants.ConnectionString
            };
        }

        public AppSettings Settings { get; }
    }
}