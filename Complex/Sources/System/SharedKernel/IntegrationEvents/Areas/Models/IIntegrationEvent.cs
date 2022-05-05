using System;
using MediatR;

namespace Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models
{
    public interface IIntegrationEvent : INotification
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }
    }
}