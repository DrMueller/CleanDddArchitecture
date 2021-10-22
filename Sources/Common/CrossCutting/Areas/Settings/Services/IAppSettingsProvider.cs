using Mmu.CleanDdd.CrossCutting.Areas.Settings.Models;

namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}