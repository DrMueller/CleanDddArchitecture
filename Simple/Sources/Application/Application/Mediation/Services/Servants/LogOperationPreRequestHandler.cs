using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR.Pipeline;
using Mmu.CleanDddSimple.CrossCutting.Services.Logging;

namespace Mmu.CleanDddSimple.Application.Mediation.Services.Servants
{
    [UsedImplicitly]
    public class LogOperationPreRequestHandler<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : notnull
    {
        private readonly ILoggingService _loggingService;

        public LogOperationPreRequestHandler(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _loggingService.LogInformation($"Received message {request.GetType().Name}");

            return Task.CompletedTask;
        }
    }
}