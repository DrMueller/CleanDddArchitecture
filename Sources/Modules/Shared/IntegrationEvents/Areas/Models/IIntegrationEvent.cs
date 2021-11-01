using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Models
{
    public interface IIntegrationEvent : INotification
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }
    }
}
