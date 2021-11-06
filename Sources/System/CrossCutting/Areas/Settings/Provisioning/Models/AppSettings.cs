using JetBrains.Annotations;

namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";

        public string ConnectionString { get; set; }

        public SecuritySettings SecuritySettings { get; set; }

        public EmailSettings EmailSettings { get; set; }
    }
}