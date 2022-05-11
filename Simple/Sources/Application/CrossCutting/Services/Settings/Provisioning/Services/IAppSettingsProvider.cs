using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Models;

namespace Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}