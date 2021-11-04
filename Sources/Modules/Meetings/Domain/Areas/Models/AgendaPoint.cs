using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class AgendaPoint : Entity
    {
        public long AgendaId { get; set; }

        public AgendaPoint(int index)
        {
            Index = index;
        }

        public void AddDescription(string desc)
        {
            Description = new AgendaPointDescription(desc);
        }

        public AgendaPointDescription Description { get; private set; }

        public int Index { get; }
    }
}