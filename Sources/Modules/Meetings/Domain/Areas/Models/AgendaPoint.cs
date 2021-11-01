using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class AgendaPoint : Entity
    {
        private long _agendaId;

        public AgendaPointDescription Description { get; set; }

        public int Index { get; }
    }
}