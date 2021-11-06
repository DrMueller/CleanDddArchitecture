using Mmu.CleanDdd.SharedKernel.IntegrationEvents.Areas.Models;

namespace Mmu.CleanDdd.Meetings.IntegrationEvents.Areas.IntegrationEvents
{
    public class ParticipantAddedIntegrationEvent : IntegrationEventBase
    {
        public ParticipantAddedIntegrationEvent(string participantName)
        {
            ParticipantName = participantName;
        }

        public string ParticipantName { get; }
    }
}