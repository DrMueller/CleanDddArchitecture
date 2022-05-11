using System.Collections.Generic;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Application.UseCases.LoadAgendaOverview
{
    [PublicAPI]
    public class AgendaOverviewResultDto
    {
        public long AgendaId { get; set; }

        public List<string> AgendaPoints { get; set; } = null!;

        public long MeetingId { get; set; }
    }
}