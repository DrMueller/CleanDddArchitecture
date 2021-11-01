using Mmu.CleanDdd.Meetings.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Factories
{
    public interface IMeetingFactory
    {
        Meeting Create(string name, string description, MeetingType type);
    }
}