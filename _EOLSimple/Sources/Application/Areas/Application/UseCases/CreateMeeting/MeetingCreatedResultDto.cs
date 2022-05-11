using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting
{
    [PublicAPI]
    public class MeetingCreatedResultDto
    {
        public long MeetingId { get; set; }
    }
}