using Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Models;

namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}