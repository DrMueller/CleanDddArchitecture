using Mmu.CleanDddSimple.Application.Mediation.Models;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.Application.UseCases.LoadMeeting
{
    public class LoadMeetingQuery : IQuery<Maybe<LoadMeetingResultDto>>
    {
        public LoadMeetingQuery(long meetingId)
        {
            MeetingId = meetingId;
        }

        public long MeetingId { get; }
    }
}