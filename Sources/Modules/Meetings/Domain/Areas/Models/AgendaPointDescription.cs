using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class AgendaPointDescription : ValueObject<AgendaPointDescription>
    {
        public string Text { get; set; }
    }
}