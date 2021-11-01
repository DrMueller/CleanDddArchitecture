using System;

namespace Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Models
{
    public abstract class IntegrationEventBase : IIntegrationEvent
    {
        protected IntegrationEventBase()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime OccurredOn { get; }
    }
}