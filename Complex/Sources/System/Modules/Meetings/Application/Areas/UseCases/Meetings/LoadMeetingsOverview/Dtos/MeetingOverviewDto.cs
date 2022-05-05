using System.Collections.Generic;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos
{
    public class MeetingOverviewDto
    {
        public AgendaDto Agenda { get; set; }
        public long MeetingId { get; set; }

        public string Name { get; set; }

        public IEnumerable<ParticipantDto> Participants { get; set; }

        public string Type { get; set; }
    }
}