﻿namespace Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Models
{
    public class EmailSettings
    {
        public string Host { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }
    }
}