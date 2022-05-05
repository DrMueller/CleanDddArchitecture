﻿using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Models
{
    [PublicAPI]
    public class SecuritySettings
    {
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}