using JetBrains.Annotations;

namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Models
{
    [PublicAPI]
    public class SecuritySettings
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}