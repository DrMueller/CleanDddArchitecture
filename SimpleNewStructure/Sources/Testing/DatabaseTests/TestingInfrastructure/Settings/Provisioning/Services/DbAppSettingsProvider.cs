using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker;

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