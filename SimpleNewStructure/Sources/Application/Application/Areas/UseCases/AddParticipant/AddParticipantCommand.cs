using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Invariance;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.Application.Areas.UseCases.AddParticipant
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