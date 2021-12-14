using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Mmu.CleanDdd.CrossCutting.Areas.Logging.Services;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services.Servants
{
    public class LogOperationPreRequestHandler<TRequest> : IRequestPreProcessor<TRequest>
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