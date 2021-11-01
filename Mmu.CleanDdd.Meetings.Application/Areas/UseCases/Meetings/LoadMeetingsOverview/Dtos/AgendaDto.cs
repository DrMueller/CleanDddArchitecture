using System.Collections.Generic;

namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.LoadMeetingsOverview.Dtos
{
    public class AgendaDto
    {
        public IEnumerable<AgendaPointDto> Points { get; set; }
    }
}