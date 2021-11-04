using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class AgendaPointDescription : ValueObject<AgendaPointDescription>
    {
        public AgendaPointDescription(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}