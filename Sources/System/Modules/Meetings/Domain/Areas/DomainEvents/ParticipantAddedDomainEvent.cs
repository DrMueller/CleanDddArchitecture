using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.DomainEvents;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.DomainEvents
{
    public class ParticipantAddedDomainEvent : DomainEventBase
    {
        public ParticipantAddedDomainEvent(string participantName)
        {
            Guard.StringNotNullOrEmpty(() => participantName);

            ParticipantName = participantName;
        }

        public string ParticipantName { get; }
    }
}