using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class Participant : Entity
    {
        public Participant(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}