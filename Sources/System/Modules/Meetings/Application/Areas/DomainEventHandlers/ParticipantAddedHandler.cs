using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.Meetings.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.Meetings.IntegrationEvents.Areas.IntegrationEvents;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Models;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Services;
using Mmu.CleanDdd.SharedKernel.Application.Areas.IntegrationEvents.Services;

namespace Mmu.CleanDdd.Meetings.Application.Areas.DomainEventHandlers
{
    public class ParticipantAddedHandler : INotificationHandler<ParticipantAddedDomainEvent>
    {
        private readonly IEmailSender _emailSender;
        private readonly IIntegrationEventSender _integrationEventSender;

        public ParticipantAddedHandler(
            IEmailSender emailSender,
            IIntegrationEventSender integrationEventSender)
        {
            _emailSender = emailSender;
            _integrationEventSender = integrationEventSender;
        }

        public async Task Handle(ParticipantAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            await SendEmailAsync(notification);
            await SendIntegrationEventAsync(notification);
        }

        private async Task SendEmailAsync(ParticipantAddedDomainEvent notification)
        {
            var email = new Email(
                "matthiasm@live.de",
                new List<string>
                {
                    "matthias.mueller@trivadis.com"
                },
                "Participant added",
                new EmailBody($"Participant {notification.ParticipantName} was added on the {notification.OccurredOn}", false));

            await _emailSender.SendEmailAsync(email);
        }

        private async Task SendIntegrationEventAsync(ParticipantAddedDomainEvent notification)
        {
            await _integrationEventSender.PublishAsync(new ParticipantAddedIntegrationEvent(notification.ParticipantName));
        }
    }
}