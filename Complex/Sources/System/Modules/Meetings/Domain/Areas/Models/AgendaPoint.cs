using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class AgendaPoint : Entity
    {
        public AgendaPoint(int index)
        {
            Index = index;
        }

        public long AgendaId { get; set; }

        public AgendaPointDescription Description { get; private set; }

        public int Index { get; }

        public void AddDescription(string desc)
        {
            Description = new AgendaPointDescription(desc);
        }
    }
}