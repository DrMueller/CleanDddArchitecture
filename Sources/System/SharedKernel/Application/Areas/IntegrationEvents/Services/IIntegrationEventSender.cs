using System.Threading.Tasks;
using Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.IntegrationEvents.Services
{
    public interface IIntegrationEventSender
    {
        Task PublishAsync(IIntegrationEvent integrationEvent);
    }
}
