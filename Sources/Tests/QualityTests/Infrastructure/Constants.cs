using System.Collections.Generic;

namespace Mmu.CleanDdd.QualityTests.Infrastructure
{
    internal static class Constants
    {
        
        internal static class Namespaces
        {
            public const string Prefix = "Mmu.CleanDdd";

            public const string CrossCutting = "Mmu.CleanDdd.CrossCutting";
            public const string DataAccess = "Mmu.CleanDdd.DataAccess";
            public const string Dependencies = "Mmu.CleanDdd.Dependencies";
            public const string WebApi = "Mmu.CleanDdd.WebApi";

            internal static class Modules
            {
                internal static class Individuals
                {
                    public const string Application = "Mmu.CleanDdd.Individuals.Application";
                    public const string ApplicationShell = "Mmu.CleanDdd.Individuals.Application.Shell";
                    public const string Domain = "Mmu.CleanDdd.Individuals.Domain";
                    public const string DomainShell = "Mmu.CleanDdd.Individuals.Domain.Shell";
                    public const string IntegrationEvents = "Mmu.CleanDdd.Individuals.IntegrationEvents";
                }

                internal static class Meetings
                {
                    public const string Application = "Mmu.CleanDdd.Meetings.Application";
                    public const string ApplicationShell = "Mmu.CleanDdd.Meetings.Application.Shell";
                    public const string Domain = "Mmu.CleanDdd.Meetings.Domain";
                    public const string DomainShell = "Mmu.CleanDdd.Meetings.Domain.Shell";
                    public const string IntegrationEvents = "Mmu.CleanDdd.Meetings.IntegrationEvents";
                }
            }

            internal static class SharedKernel
            {
                internal static string[] All { get; } = {
                    Application,
                    ApplicationShell,
                    Domain,
                    DomainShell,
                    IntegrationEvents
                };

                public const string Application = "Mmu.CleanDdd.SharedKernel.Application";
                public const string ApplicationShell = "Mmu.CleanDdd.SharedKernel.Application.Shell";
                public const string Domain = "Mmu.CleanDdd.SharedKernel.Domain";
                public const string DomainShell = "Mmu.CleanDdd.SharedKernel.Domain.Shell";
                public const string IntegrationEvents = "Mmu.CleanDdd.SharedKernel.IntegrationEvents";
            }
        }
    }
}