using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Application.UseCases.CreateMeeting
{
    [PublicAPI]
    public class MeetingCreatedResultDto
    {
        public long MeetingId { get; set; }
    }
}