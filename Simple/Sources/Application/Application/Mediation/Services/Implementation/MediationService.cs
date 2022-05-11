using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDddSimple.Application.Mediation.Models;

namespace Mmu.CleanDddSimple.Application.Mediation.Services.Implementation
{
    public class MediationService : IMediationService
    {
        private readonly IMediator _mediator;

        public MediationService(IMediator mediator)
        {
            _mediator = mediator;
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