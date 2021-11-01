using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.Shared.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.Meetings.IntegrationEvents.Areas.IntegrationEvents
{
    public class ParticipantAddedIntegrationEvent : IntegrationEventBase
    {
        public string ParticipantName { get; }

        public ParticipantAddedIntegrationEvent(string participantName)
        {
            ParticipantName = participantName;
        }
    }
}
