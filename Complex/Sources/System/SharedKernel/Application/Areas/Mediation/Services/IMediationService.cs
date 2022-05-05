using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models;
using Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services
{
    public interface IMediationService
    {
        Task PublishAsync(IIntegrationEvent integrationEvent);

        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}