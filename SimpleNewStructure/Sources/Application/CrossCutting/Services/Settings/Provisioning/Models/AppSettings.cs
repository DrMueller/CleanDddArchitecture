using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";

        public string ConnectionString { get; set; } = null!;

        public SecuritySettings SecuritySettings { get; set; } = null!;
    }
}