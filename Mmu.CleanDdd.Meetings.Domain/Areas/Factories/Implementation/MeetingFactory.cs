using Mmu.CleanDdd.Meetings.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Factories.Implementation
{
    public class MeetingFactory : IMeetingFactory
    {
        public Meeting Create(string name, string description, MeetingType type)
        {
            return new Meeting(name, description, type);
        }
    }
}