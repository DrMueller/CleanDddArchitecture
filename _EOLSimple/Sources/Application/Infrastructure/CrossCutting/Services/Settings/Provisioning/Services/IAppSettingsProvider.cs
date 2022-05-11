using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Models;

namespace Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}