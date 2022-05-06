using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Application.Areas.UseCases.CreateMeeting
{
    [PublicAPI]
    public class MeetingCreatedResultDto
    {
        public long MeetingId { get; set; }
    }
}