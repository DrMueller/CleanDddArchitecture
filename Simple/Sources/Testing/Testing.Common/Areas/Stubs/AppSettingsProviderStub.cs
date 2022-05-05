using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.Stubs
{
    [UsedImplicitly]
    public class AppSettingsProviderStub : IAppSettingsProvider
    {
        public AppSettingsProviderStub()
        {
            Settings = new AppSettings();
        }

        public AppSettings Settings { get; }
    }
}