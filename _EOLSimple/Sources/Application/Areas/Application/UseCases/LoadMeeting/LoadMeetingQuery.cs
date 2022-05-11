using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.LoadMeeting
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