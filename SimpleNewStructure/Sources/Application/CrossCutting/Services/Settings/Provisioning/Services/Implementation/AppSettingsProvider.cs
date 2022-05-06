using Microsoft.Extensions.Options;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Models;

namespace Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _settings;

        public AppSettingsProvider(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public AppSettings Settings => _settings.Value;
    }
}