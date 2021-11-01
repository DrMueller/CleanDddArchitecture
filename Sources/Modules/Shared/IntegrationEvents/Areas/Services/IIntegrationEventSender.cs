using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Services
{
    public interface IIntegrationEventSender
    {
        Task PublishAsync(IIntegrationEvent integrationEvent);
    }
}
