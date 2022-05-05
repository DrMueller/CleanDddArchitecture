using System;

namespace Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models
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