using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.Meetings.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.Meetings.IntegrationEvents.Areas.IntegrationEvents;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Models;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Emails.Services;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services;

namespace Mmu.CleanDdd.Meetings.Application.Areas.DomainEventHandlers
{
    public class ParticipantAddedHandler : INotificationHandler<ParticipantAddedDomainEvent>
    {
        private readonly IEmailSender _emailSender;
        private readonly IMediationService _mediator;

        public ParticipantAddedHandler(
            IEmailSender emailSender,
            IMediationService mediator)
        {
            _emailSender = emailSender;
            _mediator = mediator;
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
            await _mediator.PublishAsync(new ParticipantAddedIntegrationEvent(notification.ParticipantName));
        }
    }
}