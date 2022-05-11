using System.Collections.Generic;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Application.UseCases.LoadMeeting
{
    [PublicAPI]
    public class LoadMeetingResultDto
    {
        public long MeetingId { get; set; }

        public List<string> Participants { get; set; } = null!;
    }
}