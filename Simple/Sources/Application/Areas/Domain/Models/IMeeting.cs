using System.Collections.Generic;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Areas.Domain.Models
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