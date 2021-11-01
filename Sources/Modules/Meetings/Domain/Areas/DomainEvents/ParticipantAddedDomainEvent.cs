using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.Shared.Domain.Areas.DomainEvents;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.DomainEvents
{
    public class ParticipantAddedDomainEvent : DomainEventBase
    {
        public string ParticipantName { get; }

        public ParticipantAddedDomainEvent(string participantName)
        {
            Guard.StringNotNullOrEmpty(() => participantName);

            ParticipantName = participantName;
        }

    }
}
