using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Services.Implementation
{
    public class IntegrationEventSender : IIntegrationEventSender
    {
        private readonly IMediator _mediator;

        public IntegrationEventSender(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync(IIntegrationEvent integrationEvent)
        {
            await _mediator.Publish(integrationEvent);
        }
    }
}