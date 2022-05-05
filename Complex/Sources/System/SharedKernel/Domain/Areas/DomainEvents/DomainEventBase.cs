using System;

namespace Mmu.CleanDdd.SharedKernel.Domain.Areas.DomainEvents
{
    public abstract class DomainEventBase : IDomainEvent
    {
        protected DomainEventBase()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime OccurredOn { get; }
    }
}