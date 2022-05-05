using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Areas.Domain.Models
{
    [PublicAPI]
    public class AgendaPoint : Entity
    {
        public AgendaPoint(int index)
        {
            Index = index;
            Description = new AgendaPointDescription(string.Empty);
        }

        public AgendaPointDescription Description { get; private set; }

        public int Index { get; }

        public void AddDescription(string desc)
        {
            Description = new AgendaPointDescription(desc);
        }
    }
}