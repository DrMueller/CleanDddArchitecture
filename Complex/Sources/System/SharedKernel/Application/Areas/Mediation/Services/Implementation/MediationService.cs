﻿using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models;
using Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services.Implementation
{
    public class MediationService : IMediationService
    {
        private readonly IMediator _mediator;

        public MediationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync(IIntegrationEvent integrationEvent)
        {
            await _mediator.Publish(integrationEvent);
        }

        public async Task<T> SendAsync<T>(ICommand<T> command)
        {
            return await _mediator.Send(command);
        }

        public async Task SendAsync(ICommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<T> SendAsync<T>(IQuery<T> query)
        {
            return await _mediator.Send(query);
        }
    }
}