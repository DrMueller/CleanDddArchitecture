using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class Participant : Entity
    {
        private long _meetingId;

        public Participant(string name)
        {
            Name = name;
        }

        public Participant()
        {
        }

        public string Name { get; }
    }
}