using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Invariance;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.AddParticipant
{
    public class AddParticipantCommand : ICommand<Maybe<ServerError>>
    {
        public AddParticipantCommand(
            long meetingId,
            string participantName)
        {
            Guard.ValueNotDefault(() => meetingId);
            Guard.StringNotNullOrEmpty(() => participantName);

            MeetingId = meetingId;
            ParticipantName = participantName;
        }

        public long MeetingId { get; }
        public string ParticipantName { get; }
    }
}