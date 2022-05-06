using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.Application.Areas.UseCases.LoadMeeting
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