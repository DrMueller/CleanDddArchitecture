using System.Collections.Generic;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Models
{
    public interface IMeeting : IAggregateRoot
    {
        Agenda Agenda { get; }
        public string Description { get; }
        public long Id { get; }
        public MeetingType MeetingType { get; }
        public string Name { get; }
        IReadOnlyCollection<Participant> Participants { get; }

        Either<ServerError, Participant> AddParticipant(string name);
    }
}