using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class Participant : Entity
    {
        private long _meetingId;

        public Participant(string name)
        {
            _name = name;
        }

        public Participant()
        {
        }

        private string _name;
        public string Name => _name;
    }
}