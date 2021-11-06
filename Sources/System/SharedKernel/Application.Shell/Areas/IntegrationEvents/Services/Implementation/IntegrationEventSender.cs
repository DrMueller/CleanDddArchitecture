using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.SharedKernel.Application.Areas.IntegrationEvents.Services;
using Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.SharedKernel.Application.Shell.Areas.IntegrationEvents.Services.Implementation
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