using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.Meetings.IntegrationEvents.Areas.IntegrationEvents;

namespace Mmu.CleanDdd.Individuals.Application.Areas.IntegrationEvents
{
    public class ParticipantAddedHandler : INotificationHandler<ParticipantAddedIntegrationEvent>
    {
        public Task Handle(ParticipantAddedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Received event { nameof(ParticipantAddedIntegrationEvent) } with name { notification.ParticipantName }");

            return Task.CompletedTask;
        }
    }
}
